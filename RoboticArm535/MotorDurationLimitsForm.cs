using RoboticArm535Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboticArm535
{
    public partial class MotorDurationLimitsForm : Form
    {
        public MotorDurationLimitsForm(MotorLimits motorLimits)
        {
            InitializeComponent();

            this.MotorLimits = motorLimits;
            numericUpDown_Grip.Value =  (decimal)MotorLimits.MaxTimeGrip;
            numericUpDown_Wrist.Value = (decimal)MotorLimits.MaxTimeWrist;
            numericUpDown_Elbow.Value = (decimal)MotorLimits.MaxTimeElbow;
            numericUpDown_Stem.Value =  (decimal)MotorLimits.MaxTimeStem;
            numericUpDown_Base.Value =  (decimal)MotorLimits.MaxTimeBase;
        }

        public MotorLimits MotorLimits { get; private set; }

        private void button_OK_Click(object sender, EventArgs e)
        {
            MotorLimits.MaxTimeGrip  = (float)numericUpDown_Grip.Value;
            MotorLimits.MaxTimeWrist = (float)numericUpDown_Wrist.Value;
            MotorLimits.MaxTimeElbow = (float)numericUpDown_Elbow.Value;
            MotorLimits.MaxTimeStem  = (float)numericUpDown_Stem.Value;
            MotorLimits.MaxTimeBase  = (float)numericUpDown_Base.Value;

            this.DialogResult = DialogResult.OK;
        }
    }
}
