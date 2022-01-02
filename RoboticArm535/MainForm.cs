using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private readonly string ScriptsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.ProductName+"_scripts");
        private readonly UsbComms usbComms = new();

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"{Application.ProductName} V{Application.ProductVersion}";
            listBox_Commands.DataSource = Enum.GetValues<OpCode>();
            textBox_TimedActions.Clear();
            setMotorDurationLimits();

            openFileDialog_Script.InitialDirectory = 
                saveFileDialog_Script.InitialDirectory = ScriptsFolder;

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
            }

            setScriptRunning(false);
        }

        private void setMotorDurationLimits()
        {
            var culture = CultureInfo.InvariantCulture;
            var limits = usbComms.MotorLimits;
            limits.MaxTimeGrip  = float.Parse(Properties.Resources.MotorDurationLimitGrip, culture);
            limits.MaxTimeWrist = float.Parse(Properties.Resources.MotorDurationLimitWrist, culture);
            limits.MaxTimeElbow = float.Parse(Properties.Resources.MotorDurationLimitElbow, culture);
            limits.MaxTimeStem  = float.Parse(Properties.Resources.MotorDurationLimitStem, culture);
            limits.MaxTimeBase  = float.Parse(Properties.Resources.MotorDurationLimitBase, culture);
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
                if (isPressed) // button press started
                    usbComms.MoveMotor(checkBox_LED.Checked ? (opCode | OpCode.LedOn) : opCode);
                else           // button released
                    usbComms.MoveMotor(checkBox_LED.Checked ? OpCode.LedOn : OpCode.AllOff);
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
            buttonPressTimerControl.Start();
            sendMotorCommand(opCode, isPressed: true);
        }

        private void buttonPressEnded(object sender)
        {
            var opCode = (OpCode)(sender as Button).Tag;
            buttonPressTimerControl.Stop();
            sendMotorCommand(opCode, isPressed: false);
            recordAction(opCode);
        }

        private void recordAction(OpCode opCode)
        {
            if (!buttonPressTimerControl.IsRecording)
                return;

            var timedAction = new TimedAction(opCode, buttonPressTimerControl.GetElapsedTimeSecs());
            textBox_TimedActions.AppendText(timedAction + "\r\n");
        }

        private void selectLineRunning(int lineIndex)
        {
            label_CurrentLineRunning.Text = $"Line {lineIndex}: {textBox_TimedActions.Lines[lineIndex]}";
        }

        private void setScriptRunning(bool scriptRunning)
        {
            panel_Buttons.Enabled = panel_Right.Enabled = button_RunScript.Enabled = button_Clear.Enabled = !scriptRunning;
            button_Abort.Enabled = scriptRunning;

            if (!scriptRunning)
                label_CurrentLineRunning.Text = "";
        }

        private void checkBox_LED_CheckedChanged(object sender, EventArgs e)
        {            
            sendLedCommand(checkBox_LED.Checked);
            if (checkBox_LED.Checked)
            {
                buttonPressTimerControl.Start();
                recordAction(OpCode.LedOn);
            }
            else
            {
                buttonPressTimerControl.Stop();
                recordAction(OpCode.LedOff);
            }
         }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressEnded(sender);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
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

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_TimedActions.Clear();
        }

        private async void button_RunScript_Click(object sender, EventArgs e)
        {
            setScriptRunning(true);
            try
            {
                await usbComms.RunScript(textBox_TimedActions.Text, new Progress<int>(lineIndex => selectLineRunning(lineIndex)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running script:\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            setScriptRunning(false);
        }

        private void button_Abort_Click(object sender, EventArgs e)
        {
            setScriptRunning(false);
            usbComms.AbortScript();
        }

        private void listBox_Commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_TimedActions.AppendText((OpCode)listBox_Commands.SelectedItem + " 1.0\r\n");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Script.ShowDialog() == DialogResult.OK)
            {
                var fileText = File.ReadAllText(openFileDialog_Script.FileName);
                if (textBox_TimedActions.Text != "")
                    if (MessageBox.Show("Replace existing script?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        textBox_TimedActions.Text = fileText;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ScriptsFolder))
                try { Directory.CreateDirectory(ScriptsFolder); } catch { }

            if (saveFileDialog_Script.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog_Script.FileName, textBox_TimedActions.Text);
        }

        private void setMotorDurationLimitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MotorDurationLimitsForm(usbComms.MotorLimits);
            if (form.ShowDialog() == DialogResult.OK)
                usbComms.MotorLimits = form.MotorLimits;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connectUSB();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                usbComms.MoveMotor(OpCode.AllOff); // we don't want any motors (or LED) left on after we close
                usbComms.Close();
            }
            catch { }
        }
    }
}