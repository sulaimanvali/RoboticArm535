using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using Microsoft.Extensions.Logging;

namespace RoboticArm535
{
    public partial class MainForm : Form
    {
        IUsbDevice usbDevice = null;
        private const int VendorId = 0x1267;
        private const int ProductId = 0x0000;
        readonly UsbSetupPacket setupPacket = new UsbSetupPacket(
            bRequestType: 0x40, bRequest: 6, wValue: 0x100, wIndex: 0, wlength: PacketGenerator.CommandLength);

        public MainForm()
        {
            InitializeComponent();

            this.Text = Application.ProductName;

            var buttons = new Button[] {
                button_GripOpen , button_GripClose,
                button_WristUp  , button_WristDown,
                button_ElbowUp  , button_ElbowDown,
                button_StemAhead, button_StemBack,
                button_BaseLeft , button_BaseRight };

            button_GripOpen.Tag  = ControlTriggered.GripOpen;
            button_GripClose.Tag = ControlTriggered.GripClose;
            button_WristUp.Tag   = ControlTriggered.WristUp;
            button_WristDown.Tag = ControlTriggered.WristDown;
            button_ElbowUp.Tag   = ControlTriggered.ElbowUp;
            button_ElbowDown.Tag = ControlTriggered.ElbowDown;
            button_StemAhead.Tag = ControlTriggered.StemAhead;
            button_StemBack.Tag  = ControlTriggered.StemBack;
            button_BaseLeft.Tag  = ControlTriggered.BaseLeft;
            button_BaseRight.Tag = ControlTriggered.BaseRight;

            foreach (var button in buttons)
            {
                button.MouseDown += Button_MouseDown;
                button.MouseUp += Button_MouseUp;
            }
        }

        private void checkBox_LED_CheckedChanged(object sender, EventArgs e)
        {
            sendCommand(ControlTriggered.Led, checkBox_LED.Checked);
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            sendCommand((ControlTriggered)(sender as Button).Tag, isPressed: false);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            sendCommand((ControlTriggered)(sender as Button).Tag, isPressed: true);
        }

        private void sendCommand(ControlTriggered controlTriggered, bool isPressed)
        {
            if (usbDevice == null && !tryConnect())
                return;

            try
            {
                var buffer = PacketGenerator.GenerateFor(controlTriggered, isPressed);
                var bytesSent = usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
                Debug.WriteLine($"Bytes sent: {bytesSent}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB control transfer packet:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool tryConnect()
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

                        sendCommand(ControlTriggered.Led, false);

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

        private void linkLabel_Reconnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tryConnect();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (usbDevice != null && usbDevice.IsOpen)
                usbDevice.Close();
        }
    }
}