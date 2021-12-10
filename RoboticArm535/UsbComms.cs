using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboticArm535
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

            try
            {
                var buffer = PacketGenerator.GenSinglePress(controlTriggered, isPressed);
                usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB control transfer packet:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool TryConnect()
        {
            bool result = false;
            try
            {
                using (var context = new UsbContext())
                {
                    context.SetDebugLevel(LibUsbDotNet.LogLevel.Info);

                    //Get a list of all connected devices
                    usbDevice = context.Find(d => d.VendorId == VendorId && d.ProductId == ProductId);

                    if (usbDevice == null)
                    {
                        MessageBox.Show($"Unable to find USB device: VID:0x{VendorId:X4} PID:0x{ProductId:X4}.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect to USB device:\r\n{ex.Message}.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
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
