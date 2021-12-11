using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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

        /// <summary>
        /// Sends command to start or stop motors individually.
        /// This can be used for button down or up events.
        /// </summary>
        /// <param name="controlTriggered"></param>
        /// <param name="isPressed"></param>
        public void SendCommand(ControlTriggered controlTriggered, bool isPressed)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            var buffer = PacketGenerator.GenSinglePress(controlTriggered, isPressed);
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
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
        public void SendCommandMulti(Outputs.Led led, Outputs.Grip grip, Outputs.Wrist wrist,
                                     Outputs.Elbow elbow, Outputs.Stem stem, Outputs.Base baseMotor)
        {
            if (usbDevice == null || !usbDevice.IsOpen)
                throw new Exception("USB device not connected.");

            var buffer = PacketGenerator.GenMultiPress(led, grip, wrist, elbow, stem, baseMotor);
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
        }

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
    }
}
