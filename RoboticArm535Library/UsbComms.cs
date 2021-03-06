using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboticArm535Library
{
    public enum UsbConnErrorCode {  NoError, DeviceNotFound }

    public class UsbComms
    {
        IUsbDevice usbDevice = null;
        readonly UsbSetupPacket setupPacket = new(bRequestType: 0x40, bRequest: 6,
            wValue: 0x100, wIndex: 0, wlength: Packet.CommandLength);
        CancellationTokenSource tokenSource;

        public UsbComms()
        { }

        public UsbComms(IUsbDevice usbDevice)
        {
            this.usbDevice = usbDevice;
        }

        public UInt16 VendorId { get; private set; } = 0x1267;
        public UInt16 ProductId { get; private set; } = 0x0000;

        /// <summary>
        /// Contains the duration limits for each of the motors, beyond which 
        /// script duration requests will be capped. Properties are settable.
        /// Feel free to modify caps as required.
        /// </summary>
        public MotorLimits MotorLimits { get; set; } = new();

        /// <summary>
        /// True to cap durations when running scripts.
        /// </summary>
        public bool CheckMotorLimits { get; set; } = true;

        #region Connection methods
        /// <summary>
        /// Connects to USB device.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public UsbConnErrorCode Connect(UInt16 vendorId, UInt16 productId)
        {
            this.VendorId = vendorId;
            this.ProductId = productId;
            return Connect();
        }

        /// <summary>
        /// Connects to USB device, using default OWI-535 robotic arm Vendor and Product IDs.
        /// </summary>
        /// <returns></returns>
        public UsbConnErrorCode Connect()
        {
            UsbConnErrorCode errorCode = UsbConnErrorCode.NoError;
            using (var context = new UsbContext())
            {
                context.SetDebugLevel(LibUsbDotNet.LogLevel.Info);

                //Get a list of all connected devices
                usbDevice = context.Find(d => d.VendorId == VendorId && d.ProductId == ProductId);

                if (usbDevice == null)
                {
                    Console.Error.WriteLine($"Unable to find USB device: VID:0x{VendorId:X4} PID:0x{ProductId:X4}.");
                    errorCode = UsbConnErrorCode.DeviceNotFound;
                }
                else
                {
                    usbDevice.Open();
                    usbDevice.ClaimInterface(usbDevice.Configs[0].Interfaces[0].Number);
                }
            }

            return errorCode;
        }

        /// <summary>
        /// Closes USB device if open.
        /// </summary>
        public void Close()
        {
            if (usbDevice != null && usbDevice.IsOpen)
                usbDevice.Close();
        }
        #endregion

        /// <summary>
        /// Turns LED on or off in single press mode (all running motors will be stopped).
        /// </summary>
        /// <param name="on"></param>
        /// <exception cref="UsbDeviceNotConnectedException"></exception>
        public void TurnLed(bool on)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new UsbDeviceNotConnectedException("USB device not connected.");

            SendPacket(PacketGenerator.GenByOpCode(on ? OpCode.LedOn : OpCode.LedOff));
        }

        #region Motor control commands
        /// <summary>
        /// Sends command to start or stop motors individually.
        /// This can be used for button down or up events.
        /// </summary>
        /// <param name="opCode"></param>
        /// <exception cref="UsbDeviceNotConnectedException"></exception>
        public void MoveMotor(OpCode opCode)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new UsbDeviceNotConnectedException("USB device not connected.");
            
            SendPacket(PacketGenerator.GenByOpCode(opCode));
        }

        /// <summary>
        /// Sends command to start or stop multiple motors simultaneously.
        /// This can be used in a script or even a user interface that supports multiple button presses.
        /// </summary>
        /// <param name="led"></param>
        /// <param name="grip"></param>
        /// <param name="wrist"></param>
        /// <param name="elbow"></param>
        /// <param name="stem"></param>
        /// <param name="baseMotor"></param>
        /// <exception cref="UsbDeviceNotConnectedException"></exception>
        public void Cmd(Out.Led led, Out.Grip grip, Out.Wrist wrist,
                        Out.Elbow elbow, Out.Stem stem, Out.Base baseMotor)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new UsbDeviceNotConnectedException("USB device not connected.");

            SendPacket(PacketGenerator.GenByOutputs(led, grip, wrist, elbow, stem, baseMotor));
        }

        /// <summary>
        /// Sends command to start or stop motors individually.
        /// This can be used for button down or up events or in a script.
        /// </summary>
        /// <param name="opCode">Enum values can be or'd together but they should make sense.</param>
        /// <param name="durationSecs">Time duration in seconds between turning on and off the given command.
        /// 0 to leave on and return immediately.</param>
        /// <exception cref="UsbDeviceNotConnectedException"></exception>
        public void Cmd(OpCode opCode, float durationSecs)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new UsbDeviceNotConnectedException("USB device not connected.");

            if (opCode == OpCode.Wait)
            {
                Thread.Sleep((int)(durationSecs * 1000));
                return;
            }

            SendPacket(PacketGenerator.GenByOpCode(opCode));

            if (durationSecs == 0)
                return;

            if (CheckMotorLimits)
            {
                var origDurationSecs = durationSecs;
                durationSecs = MotorLimits.CapDuration(opCode, durationSecs);
                if (durationSecs != origDurationSecs)
                    Console.Error.WriteLine($"Duration for {opCode} capped from {origDurationSecs}s to {durationSecs}s");
            }

            Thread.Sleep((int)(durationSecs * 1000));

            // turn off everything
            SendPacket(PacketGenerator.GenByOpCode(OpCode.AllOff));
        }

        /// <summary>
        /// Runs the given script of TimedActions.
        /// </summary>
        /// <param name="script"></param>
        /// <param name="progress"></param>
        public async Task RunScript(string script, IProgress<int> progress)
        {
            var timedActions = TimedAction.ParseLines(script);

            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var task = Task.Run(() =>
            {
                token.ThrowIfCancellationRequested();
                for (int lineIndex = 0; lineIndex < timedActions.Length; lineIndex++)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    progress.Report(lineIndex);
                    var action = timedActions[lineIndex];
                    Cmd(action.OpCode, action.DurationSecs);                    
                }
            }, tokenSource.Token);

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                // stop all motors and turn off LED
                Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        /// <summary>
        /// Sends raw packet.
        /// </summary>
        /// <param name="buffer"></param>
        public void SendPacket(byte[] buffer)
        {
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
            Debug.WriteLine(BitConverter.ToString(buffer));
        }

        /// <summary>
        /// Abort currently running script. Stops any motors and turns off LED if on.
        /// </summary>
        public void AbortScript()
        {
            tokenSource?.Cancel();
        }
        #endregion
    }
}
