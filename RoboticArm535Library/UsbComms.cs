using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535Library
{
    public class UsbComms
    {
        IUsbDevice usbDevice = null;
        private const int VendorId = 0x1267;
        private const int ProductId = 0x0000;
        readonly UsbSetupPacket setupPacket = new UsbSetupPacket(
            bRequestType: 0x40, bRequest: 6, wValue: 0x100, wIndex: 0, wlength: Packet.CommandLength);


        public void SendCommand(ControlTriggered controlTriggered, bool isPressed)
        {
            if (usbDevice == null && !TryConnect())
                return;

            var buffer = PacketGenerator.GenSinglePress(controlTriggered, isPressed);
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
        }

        public void SendCommandMulti(bool ledOn, Motors.Grip grip, Motors.Wrist wrist, Motors.Elbow elbow,
                                                 Motors.Stem stem, Motors.Base baseMotor)
        {
            if (usbDevice == null && !TryConnect())
                return;

            var buffer = PacketGenerator.GenMultiPress(ledOn, grip, wrist, elbow, stem, baseMotor);
            usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
        }

        public bool TryConnect()
        {
            bool result = false;
            using (var context = new UsbContext())
            {
                context.SetDebugLevel(LibUsbDotNet.LogLevel.Info);

                //Get a list of all connected devices
                usbDevice = context.Find(d => d.VendorId == VendorId && d.ProductId == ProductId);

                if (usbDevice == null)
                {
                    throw new Exception($"Unable to find USB device: VID:0x{VendorId:X4} PID:0x{ProductId:X4}.");
                }
                else
                {
                    //Open the device
                    usbDevice.Open();

                    //Get the first config number of the interface
                    usbDevice.ClaimInterface(usbDevice.Configs[0].Interfaces[0].Number);

                    result = true;
                }
            }

            return result;
        }

        public void Close()
        {
            if (usbDevice != null && usbDevice.IsOpen)
                usbDevice.Close();
        }
    }
}
