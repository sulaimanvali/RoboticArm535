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
        private const int VendorId = 0x1267;
        private const int ProductId = 0x0000;
        readonly UsbSetupPacket setupPacket = new(bRequestType: 0x40, bRequest: 6,
            wValue: 0x100, wIndex: 0, wlength: Packet.CommandLength);
        CancellationTokenSource tokenSource;

        #region
        /// <summary>
        /// Connects to USB device.
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
                    Debug.WriteLine($"Unable to find USB device: VID:0x{VendorId:X4} PID:0x{ProductId:X4}.");
                    errorCode = UsbConnErrorCode.DeviceNotFound;
                }
                else
                {
                    usbDevice.Open();

                    //Get the first config number of the interface
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
        public void TurnLed(bool on)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            sendPacket(PacketGenerator.GenSinglePress(on ? OpCode.LedOn : OpCode.LedOff));
        }

        #region Motor control commands
        /// <summary>
        /// Sends command to start or stop motors individually.
        /// This can be used for button down or up events.
        /// </summary>
        /// <param name="opCode"></param>
        public void MoveMotor(OpCode opCode)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");
            
            sendPacket(PacketGenerator.GenSinglePress(opCode));
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
        public void Cmd(Out.Led led, Out.Grip grip, Out.Wrist wrist,
                        Out.Elbow elbow, Out.Stem stem, Out.Base baseMotor)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            sendPacket(PacketGenerator.GenMultiPress(led, grip, wrist, elbow, stem, baseMotor));
        }

        /// <summary>
        /// Sends command to start or stop motors individually.
        /// This can be used for button down or up events or in a script.
        /// </summary>
        /// <param name="opCode">Enum values can be or'd together but they should make sense.</param>
        /// <param name="durationSecs">Time duration in seconds between turning on and off the given command.
        /// 0 to leave on and return immediately.</param>
        public void Cmd(OpCode opCode, float durationSecs)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            if (opCode == OpCode.Wait)
            {
                Thread.Sleep((int)(durationSecs * 1000));
                return;
            }

            sendPacket(PacketGenerator.GenSinglePress(opCode));

            if (durationSecs == 0)
                return;

            Thread.Sleep((int)(durationSecs * 1000));

            // turn off everything
            sendPacket(PacketGenerator.GenSinglePress(OpCode.AllOff));
        }

        /// <summary>
        /// Runs the given script of TimedActions.
        /// </summary>
        /// <param name="script"></param>
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
                Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        public void AbortScript()
        {
            tokenSource?.Cancel();
        }
        #endregion

        private void sendPacket(byte[] buffer)
        {
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
            Debug.WriteLine(BitConverter.ToString(buffer));
        }
    }
}
