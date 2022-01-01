
namespace RoboticArm535
{
    partial class ButtonPressTimerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox_Record = new System.Windows.Forms.CheckBox();
            this.label_TimeButtonPressed = new System.Windows.Forms.Label();
            this.timer_ButtonPresses = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // checkBox_Record
            // 
            this.checkBox_Record.AutoSize = true;
            this.checkBox_Record.Location = new System.Drawing.Point(3, 3);
            this.checkBox_Record.Name = "checkBox_Record";
            this.checkBox_Record.Size = new System.Drawing.Size(143, 19);
            this.checkBox_Record.TabIndex = 17;
            this.checkBox_Record.Text = "Record Button Presses";
            this.checkBox_Record.UseVisualStyleBackColor = true;
            this.checkBox_Record.CheckedChanged += new System.EventHandler(this.checkBox_Record_CheckedChanged);
            // 
            // label_TimeButtonPressed
            // 
            this.label_TimeButtonPressed.AutoSize = true;
            this.label_TimeButtonPressed.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_TimeButtonPressed.Location = new System.Drawing.Point(165, 1);
            this.label_TimeButtonPressed.Name = "label_TimeButtonPressed";
            this.label_TimeButtonPressed.Size = new System.Drawing.Size(40, 22);
            this.label_TimeButtonPressed.TabIndex = 18;
            this.label_TimeButtonPressed.Text = "---";
            // 
            // timer_ButtonPresses
            // 
            this.timer_ButtonPresses.Tick += new System.EventHandler(this.timer_ButtonPresses_Tick);
            // 
            // ButtonPressTimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_Record);
            this.Controls.Add(this.label_TimeButtonPressed);
            this.Name = "ButtonPressTimerControl";
            this.Size = new System.Drawing.Size(244, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Record;
        private System.Windows.Forms.Label label_TimeButtonPressed;
        private System.Windows.Forms.Timer timer_ButtonPresses;
    }
}
