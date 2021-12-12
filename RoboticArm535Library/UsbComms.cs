using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace RoboticArm535Library
{
    public enum UsbConnErrorCode {  NoError, DeviceNotFound }

    public class UsbComms
    {
        IUsbDevice usbDevice = null;
        private const int VendorId = 0x1267;
        private const int ProductId = 0x0000;
        readonly UsbSetupPacket setupPacket = new UsbSetupPacket(
            bRequestType: 0x40, bRequest: 6, wValue: 0x100, wIndex: 0, wlength: Packet.CommandLength);

        public bool LedOn { get; private set; }

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

        public void TurnLedOn(bool on)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            sendPacket(PacketGenerator.GenSinglePress(on ? OpCode.LedOn : OpCode.AllOff));
            LedOn = on;
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

            if (LedOn)
                opCode |= OpCode.LedOn;

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
        /// Sends command to start or stop multiple motors simultaneously.
        /// This can be used in a script or app.
        /// Each byte argument can be a bitmask of multiple enum values or'ed together.
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="byte1"></param>
        /// <param name="byte2"></param>
        public void Cmd(Packet.Byte0 byte0, Packet.Byte1 byte1, Packet.Byte2 byte2)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            sendPacket(new byte[] { (byte)byte0, (byte)byte1, (byte)byte2 });
        }

        /// <summary>
        /// Sends command to start or stop motors individually.
        /// This can be used for button down or up events.
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="durationSecs">Time duration in seconds between turning on and off the given command.
        /// 0 to leave on and return immediately.</param>
        public void Cmd(OpCode opCode, float durationSecs)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            if (LedOn)
                opCode |= OpCode.LedOn;

            sendPacket(PacketGenerator.GenSinglePress(opCode));

            if (durationSecs == 0)
                return;

            Thread.Sleep((int)(durationSecs * 1000));
            Debug.WriteLine("sleep " + durationSecs);

            sendPacket(PacketGenerator.GenSinglePress(LedOn ? OpCode.LedOn : OpCode.AllOff));
        }
        #endregion

        private void sendPacket(byte[] buffer)
        {
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
            Debug.WriteLine(BitConverter.ToString(buffer));
        }
    }
}
