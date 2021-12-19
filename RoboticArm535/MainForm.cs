using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboticArm535Library;

namespace RoboticArm535
{
    public partial class MainForm : Form
    {
        private UsbComms usbComms = new UsbComms();
        private Stopwatch stopwatch = new Stopwatch();

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"{Application.ProductName} V{Application.ProductVersion}";
            listBox_Commands.DataSource = Enum.GetValues<OpCode>();

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

        private bool sendLedCommand(bool isOn)
        {
            try
            {
                usbComms.TurnLed(isOn);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB command:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool sendMotorCommand(OpCode opCode, bool isPressed)
        {
            try
            {
                if (isPressed)
                    usbComms.MoveMotor(opCode);
                else
                    usbComms.MoveMotor(OpCode.AllOff);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send USB command:\r\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool sendTimedMotorCommand(OpCode opCode, float durationSecs)
        {
            try
            {
                usbComms.Cmd(opCode, durationSecs);
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

        private void buttonPressStarted(object sender)
        {
            var opCode = (OpCode)(sender as Button).Tag;
            stopwatch.Restart();
            sendMotorCommand(opCode, isPressed: true);
        }

        private void buttonPressEnded(object sender)
        {
            var opCode = (OpCode)(sender as Button).Tag;
            stopwatch.Stop();
            sendMotorCommand(opCode, isPressed: false);
            recordAction(opCode);
        }

        private void recordAction(OpCode opCode)
        {
            if (!checkBox_Record.Checked)
                return;

            var timedAction = new TimedAction(opCode, stopwatch.ElapsedMilliseconds / 1000.0f);
            textBox_TimedActions.AppendText(timedAction + "\r\n");
        }

        private void checkBox_LED_CheckedChanged(object sender, EventArgs e)
        {
            stopwatch.Reset();
            sendLedCommand(checkBox_LED.Checked);
            recordAction(checkBox_LED.Checked ? OpCode.LedOn : OpCode.AllOff);
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressEnded(sender);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressStarted(sender);
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            buttonPressEnded(sender);
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            buttonPressStarted(sender);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void reconnectUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectUSB();
        }

        private void timer_ButtonPresses_Tick(object sender, EventArgs e)
        {
            label_TimeButtonPressed.Text = $"{(stopwatch.ElapsedMilliseconds/1000.0f):F2} s";
        }

        private void checkBox_Record_CheckedChanged(object sender, EventArgs e)
        {
            stopwatch.Reset();
            if (checkBox_Record.Checked)
                timer_ButtonPresses.Start();
            else
                timer_ButtonPresses.Stop();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_TimedActions.Clear();
        }

        private void button_Replay_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var action in TimedAction.ParseLines(textBox_TimedActions.Text))
                {
                    if (action.OpCode == OpCode.AllOff)
                        sendLedCommand(false);
                    else
                        sendTimedMotorCommand(action.OpCode, action.DurationSecs);
                }
            }
            catch (Exception ex)
            {
                sendMotorCommand(OpCode.AllOff, false);
                MessageBox.Show("Error parsing commands script:\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox_Commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_TimedActions.AppendText((OpCode)listBox_Commands.SelectedItem + " 1.0\r\n");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connectUSB();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                usbComms.TurnLed(false);
                usbComms.MoveMotor(OpCode.AllOff); // we don't want any motors running after we close
                usbComms.Close();
            }
            catch { }
        }
    }
}