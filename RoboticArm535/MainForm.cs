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
using RoboticArm535Library;

namespace RoboticArm535
{
    public partial class MainForm : Form
    {
        private UsbComms usbComms = new UsbComms();

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"{Application.ProductName} V{Application.ProductVersion}";

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
                button.KeyDown += Button_KeyDown;
                button.KeyUp += Button_KeyUp;
            }
        }

        private void sendCommand(ControlTriggered control, bool isPressed)
        {
            try
            {
                usbComms.SendCommand(control, isPressed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB control transfer packet:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            sendCommand((ControlTriggered)(sender as Button).Tag, isPressed: false);
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            sendCommand((ControlTriggered)(sender as Button).Tag, isPressed: true);
        }

        private void linkLabel_Reconnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                usbComms.TryConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to USB device:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            usbComms.Close();
        }
    }
}