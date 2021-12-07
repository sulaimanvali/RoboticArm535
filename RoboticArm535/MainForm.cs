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
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using Microsoft.Extensions.Logging;

namespace RoboticArm535
{
    public partial class MainForm : Form
    {
        private const int ProductId = 0x0000;
        private const int VendorId = 0x1267;
        private const int CommandLength = 3;
        IUsbDevice usbDevice = null;
        readonly UsbSetupPacket setupPacket = new UsbSetupPacket(0x40, 6, 0x100, 0, CommandLength);
        private Button[] buttons;

        public MainForm()
        {
            InitializeComponent();

            this.Text = Application.ProductName;

            buttons = new Button[] {
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
            if (usbDevice == null)
            {
                MessageBox.Show("USB device not connected", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var buffer = PacketGenerator.GenerateFor(controlTriggered, isPressed);
                var bytesSent = usbDevice.ControlTransfer(setupPacket, buffer, 0, buffer.Length);
                Debug.WriteLine("Bytes sent: " + bytesSent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB control transfer packet:\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void connect()
        {
            try
            {
                using (var context = new UsbContext())
                {
                    context.SetDebugLevel(LibUsbDotNet.LogLevel.Info);

                    //Get a list of all connected devices
                    var usbDeviceCollection = context.List();

                    //Narrow down the device by vendor and pid
                    usbDevice = usbDeviceCollection.FirstOrDefault(d => d.ProductId == ProductId && d.VendorId == VendorId);

                    if (usbDevice != null)
                    {
                        //Open the device
                        usbDevice.Open();

                        //Get the first config number of the interface
                        usbDevice.ClaimInterface(usbDevice.Configs[0].Interfaces[0].Number);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to USB device:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connect();
        }
    }
}