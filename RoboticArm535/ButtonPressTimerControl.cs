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

namespace RoboticArm535
{
    public partial class ButtonPressTimerControl : UserControl
    {
        private readonly Stopwatch stopwatch = new();

        public ButtonPressTimerControl()
        {
            InitializeComponent();
        }

        public bool IsRecording { get { return checkBox_Record.Checked; } }

        public void Start()
        {
            if (checkBox_Record.Checked)
                stopwatch.Restart();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public void Reset()
        {
            stopwatch.Reset();
        }

        public float GetElapsedTimeSecs()
        {
            return stopwatch.ElapsedMilliseconds / 1000.0f;
        }

        private void timer_ButtonPresses_Tick(object sender, EventArgs e)
        {
            label_TimeButtonPressed.Text = $"{(stopwatch.ElapsedMilliseconds / 1000.0f):F2} s";
        }

        private void checkBox_Record_CheckedChanged(object sender, EventArgs e)
        {
            stopwatch.Reset();
            if (checkBox_Record.Checked)
                timer_ButtonPresses.Start();
            else
                timer_ButtonPresses.Stop();
        }
    }
}
