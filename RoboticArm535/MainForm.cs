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

            button_GripOpen.Tag  = OpCode.GripOpen;
            button_GripClose.Tag = OpCode.GripClose;
            button_WristUp.Tag   = OpCode.WristUp;
            button_WristDown.Tag = OpCode.WristDown;
            button_ElbowUp.Tag   = OpCode.ElbowUp;
            button_ElbowDown.Tag = OpCode.ElbowDown;
            button_StemAhead.Tag = OpCode.StemAhead;
            button_StemBack.Tag  = OpCode.StemBack;
            button_BaseLeft.Tag  = OpCode.BaseLeft;
            button_BaseRight.Tag = OpCode.BaseRight;

            foreach (var button in buttons)
            {
                button.MouseDown += Button_MouseDown;
                button.MouseUp   += Button_MouseUp;
                button.KeyDown   += Button_KeyDown;
                button.KeyUp     += Button_KeyUp;
            }
        }

        private bool sendCommand(OpCode control, bool isPressed)
        {
            try
            {
                usbComms.CmdSingle(control, isPressed);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB command:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void connectUSB()
        {
            try
            {
                var errorCode = usbComms.Connect();
                if (errorCode != UsbConnErrorCode.NoError)
                    MessageBox.Show("Failed to connect to USB device:\r\n" + errorCode,
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to USB device:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_LED_CheckedChanged(object sender, EventArgs e)
        {
            sendCommand(OpCode.Led, checkBox_LED.Checked);
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            sendCommand((OpCode)(sender as Button).Tag, isPressed: false);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            sendCommand((OpCode)(sender as Button).Tag, isPressed: true);
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            sendCommand((OpCode)(sender as Button).Tag, isPressed: false);
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            sendCommand((OpCode)(sender as Button).Tag, isPressed: true);
        }

        private void linkLabel_Reconnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            connectUSB();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connectUSB();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            usbComms.Close();
        }
    }
}