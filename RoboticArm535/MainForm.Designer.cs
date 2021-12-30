
namespace RoboticArm535
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_GripOpen = new System.Windows.Forms.Button();
            this.checkBox_LED = new System.Windows.Forms.CheckBox();
            this.button_GripClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_WristUp = new System.Windows.Forms.Button();
            this.button_WristDown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ElbowUp = new System.Windows.Forms.Button();
            this.button_ElbowDown = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_StemBack = new System.Windows.Forms.Button();
            this.button_StemAhead = new System.Windows.Forms.Button();
            this.button_BaseLeft = new System.Windows.Forms.Button();
            this.button_BaseRight = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_RunScript = new System.Windows.Forms.Button();
            this.checkBox_Record = new System.Windows.Forms.CheckBox();
            this.label_TimeButtonPressed = new System.Windows.Forms.Label();
            this.timer_ButtonPresses = new System.Windows.Forms.Timer(this.components);
            this.textBox_TimedActions = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_Commands = new System.Windows.Forms.ListBox();
            this.saveFileDialog_Script = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog_Script = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Abort = new System.Windows.Forms.Button();
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.label_CurrentLineRunning = new System.Windows.Forms.Label();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel_Buttons.SuspendLayout();
            this.panel_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_GripOpen
            // 
            this.button_GripOpen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_GripOpen.Location = new System.Drawing.Point(68, 39);
            this.button_GripOpen.Name = "button_GripOpen";
            this.button_GripOpen.Size = new System.Drawing.Size(111, 36);
            this.button_GripOpen.TabIndex = 2;
            this.button_GripOpen.Text = "◄ Open ►";
            this.button_GripOpen.UseVisualStyleBackColor = true;
            // 
            // checkBox_LED
            // 
            this.checkBox_LED.AutoSize = true;
            this.checkBox_LED.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_LED.Location = new System.Drawing.Point(138, 4);
            this.checkBox_LED.Name = "checkBox_LED";
            this.checkBox_LED.Size = new System.Drawing.Size(63, 29);
            this.checkBox_LED.TabIndex = 1;
            this.checkBox_LED.Text = "LED";
            this.checkBox_LED.UseVisualStyleBackColor = true;
            this.checkBox_LED.CheckedChanged += new System.EventHandler(this.checkBox_LED_CheckedChanged);
            // 
            // button_GripClose
            // 
            this.button_GripClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_GripClose.Location = new System.Drawing.Point(185, 39);
            this.button_GripClose.Name = "button_GripClose";
            this.button_GripClose.Size = new System.Drawing.Size(66, 36);
            this.button_GripClose.TabIndex = 3;
            this.button_GripClose.Text = "Close";
            this.button_GripClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grip";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_WristUp
            // 
            this.button_WristUp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_WristUp.Location = new System.Drawing.Point(106, 94);
            this.button_WristUp.Name = "button_WristUp";
            this.button_WristUp.Size = new System.Drawing.Size(95, 38);
            this.button_WristUp.TabIndex = 4;
            this.button_WristUp.Text = "Up";
            this.button_WristUp.UseVisualStyleBackColor = true;
            // 
            // button_WristDown
            // 
            this.button_WristDown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_WristDown.Location = new System.Drawing.Point(106, 138);
            this.button_WristDown.Name = "button_WristDown";
            this.button_WristDown.Size = new System.Drawing.Size(95, 38);
            this.button_WristDown.TabIndex = 5;
            this.button_WristDown.Text = "Down";
            this.button_WristDown.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(37, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wrist";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_ElbowUp
            // 
            this.button_ElbowUp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ElbowUp.Location = new System.Drawing.Point(106, 195);
            this.button_ElbowUp.Name = "button_ElbowUp";
            this.button_ElbowUp.Size = new System.Drawing.Size(95, 38);
            this.button_ElbowUp.TabIndex = 6;
            this.button_ElbowUp.Text = "Up";
            this.button_ElbowUp.UseVisualStyleBackColor = true;
            // 
            // button_ElbowDown
            // 
            this.button_ElbowDown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ElbowDown.Location = new System.Drawing.Point(106, 239);
            this.button_ElbowDown.Name = "button_ElbowDown";
            this.button_ElbowDown.Size = new System.Drawing.Size(95, 38);
            this.button_ElbowDown.TabIndex = 7;
            this.button_ElbowDown.Text = "Down";
            this.button_ElbowDown.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(30, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Elbow";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_StemBack
            // 
            this.button_StemBack.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StemBack.Location = new System.Drawing.Point(106, 370);
            this.button_StemBack.Name = "button_StemBack";
            this.button_StemBack.Size = new System.Drawing.Size(95, 64);
            this.button_StemBack.TabIndex = 11;
            this.button_StemBack.Text = "Stem Back";
            this.button_StemBack.UseVisualStyleBackColor = true;
            // 
            // button_StemAhead
            // 
            this.button_StemAhead.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StemAhead.Location = new System.Drawing.Point(106, 300);
            this.button_StemAhead.Name = "button_StemAhead";
            this.button_StemAhead.Size = new System.Drawing.Size(95, 64);
            this.button_StemAhead.TabIndex = 10;
            this.button_StemAhead.Text = "Stem Ahead";
            this.button_StemAhead.UseVisualStyleBackColor = true;
            // 
            // button_BaseLeft
            // 
            this.button_BaseLeft.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_BaseLeft.Location = new System.Drawing.Point(14, 339);
            this.button_BaseLeft.Name = "button_BaseLeft";
            this.button_BaseLeft.Size = new System.Drawing.Size(86, 61);
            this.button_BaseLeft.TabIndex = 8;
            this.button_BaseLeft.Text = "Base Left";
            this.button_BaseLeft.UseVisualStyleBackColor = true;
            // 
            // button_BaseRight
            // 
            this.button_BaseRight.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_BaseRight.Location = new System.Drawing.Point(207, 339);
            this.button_BaseRight.Name = "button_BaseRight";
            this.button_BaseRight.Size = new System.Drawing.Size(86, 61);
            this.button_BaseRight.TabIndex = 9;
            this.button_BaseRight.Text = "Base Right";
            this.button_BaseRight.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(12, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(360, 37);
            this.label6.TabIndex = 5;
            this.label6.Text = "Connect via USB. Ensure device has working batteries inside and is powered on. Ho" +
    "ld down button to move relevant motor.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openToolStripMenuItem.Text = "&Open Script";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveToolStripMenuItem.Text = "&Save Script";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reconnectUSBToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // reconnectUSBToolStripMenuItem
            // 
            this.reconnectUSBToolStripMenuItem.Name = "reconnectUSBToolStripMenuItem";
            this.reconnectUSBToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reconnectUSBToolStripMenuItem.Text = "&Reconnect USB";
            this.reconnectUSBToolStripMenuItem.Click += new System.EventHandler(this.reconnectUSBToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(432, 501);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 14;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_RunScript
            // 
            this.button_RunScript.Location = new System.Drawing.Point(513, 501);
            this.button_RunScript.Name = "button_RunScript";
            this.button_RunScript.Size = new System.Drawing.Size(101, 23);
            this.button_RunScript.TabIndex = 15;
            this.button_RunScript.Text = "Run Script";
            this.button_RunScript.UseVisualStyleBackColor = true;
            this.button_RunScript.Click += new System.EventHandler(this.button_RunScript_Click);
            // 
            // checkBox_Record
            // 
            this.checkBox_Record.AutoSize = true;
            this.checkBox_Record.Location = new System.Drawing.Point(3, 4);
            this.checkBox_Record.Name = "checkBox_Record";
            this.checkBox_Record.Size = new System.Drawing.Size(143, 19);
            this.checkBox_Record.TabIndex = 12;
            this.checkBox_Record.Text = "Record Button Presses";
            this.checkBox_Record.UseVisualStyleBackColor = true;
            this.checkBox_Record.CheckedChanged += new System.EventHandler(this.checkBox_Record_CheckedChanged);
            // 
            // label_TimeButtonPressed
            // 
            this.label_TimeButtonPressed.AutoSize = true;
            this.label_TimeButtonPressed.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_TimeButtonPressed.Location = new System.Drawing.Point(180, 2);
            this.label_TimeButtonPressed.Name = "label_TimeButtonPressed";
            this.label_TimeButtonPressed.Size = new System.Drawing.Size(40, 22);
            this.label_TimeButtonPressed.TabIndex = 16;
            this.label_TimeButtonPressed.Text = "---";
            // 
            // timer_ButtonPresses
            // 
            this.timer_ButtonPresses.Tick += new System.EventHandler(this.timer_ButtonPresses_Tick);
            // 
            // textBox_TimedActions
            // 
            this.textBox_TimedActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_TimedActions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TimedActions.Location = new System.Drawing.Point(3, 30);
            this.textBox_TimedActions.Multiline = true;
            this.textBox_TimedActions.Name = "textBox_TimedActions";
            this.textBox_TimedActions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_TimedActions.Size = new System.Drawing.Size(252, 412);
            this.textBox_TimedActions.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Click to Add for 1.0 s:";
            // 
            // listBox_Commands
            // 
            this.listBox_Commands.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox_Commands.FormattingEnabled = true;
            this.listBox_Commands.ItemHeight = 20;
            this.listBox_Commands.Location = new System.Drawing.Point(264, 30);
            this.listBox_Commands.Name = "listBox_Commands";
            this.listBox_Commands.Size = new System.Drawing.Size(132, 364);
            this.listBox_Commands.TabIndex = 16;
            this.listBox_Commands.SelectedIndexChanged += new System.EventHandler(this.listBox_Commands_SelectedIndexChanged);
            // 
            // saveFileDialog_Script
            // 
            this.saveFileDialog_Script.DefaultExt = "535script";
            this.saveFileDialog_Script.Filter = "RoboticArm535 Scripts|*.535script|All files|*.*";
            this.saveFileDialog_Script.Title = "Save Script";
            // 
            // openFileDialog_Script
            // 
            this.openFileDialog_Script.DefaultExt = "535script";
            this.openFileDialog_Script.Filter = "RoboticArm535 Scripts|*.535script|All files|*.*";
            this.openFileDialog_Script.Title = "Open Script";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(261, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 47);
            this.label5.TabIndex = 19;
            this.label5.Text = "Duration of 0 s implies output is left in that state.";
            // 
            // button_Abort
            // 
            this.button_Abort.Location = new System.Drawing.Point(620, 501);
            this.button_Abort.Name = "button_Abort";
            this.button_Abort.Size = new System.Drawing.Size(64, 23);
            this.button_Abort.TabIndex = 20;
            this.button_Abort.Text = "Abort";
            this.button_Abort.UseVisualStyleBackColor = true;
            this.button_Abort.Click += new System.EventHandler(this.button_Abort_Click);
            // 
            // panel_Buttons
            // 
            this.panel_Buttons.Controls.Add(this.button_GripOpen);
            this.panel_Buttons.Controls.Add(this.button_WristUp);
            this.panel_Buttons.Controls.Add(this.button_WristDown);
            this.panel_Buttons.Controls.Add(this.label2);
            this.panel_Buttons.Controls.Add(this.button_GripClose);
            this.panel_Buttons.Controls.Add(this.button_ElbowUp);
            this.panel_Buttons.Controls.Add(this.label3);
            this.panel_Buttons.Controls.Add(this.button_ElbowDown);
            this.panel_Buttons.Controls.Add(this.button_StemAhead);
            this.panel_Buttons.Controls.Add(this.button_BaseLeft);
            this.panel_Buttons.Controls.Add(this.button_StemBack);
            this.panel_Buttons.Controls.Add(this.checkBox_LED);
            this.panel_Buttons.Controls.Add(this.label1);
            this.panel_Buttons.Controls.Add(this.button_BaseRight);
            this.panel_Buttons.Location = new System.Drawing.Point(21, 35);
            this.panel_Buttons.Name = "panel_Buttons";
            this.panel_Buttons.Size = new System.Drawing.Size(307, 438);
            this.panel_Buttons.TabIndex = 21;
            // 
            // label_CurrentLineRunning
            // 
            this.label_CurrentLineRunning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CurrentLineRunning.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_CurrentLineRunning.Location = new System.Drawing.Point(432, 476);
            this.label_CurrentLineRunning.Name = "label_CurrentLineRunning";
            this.label_CurrentLineRunning.Size = new System.Drawing.Size(255, 18);
            this.label_CurrentLineRunning.TabIndex = 22;
            this.label_CurrentLineRunning.Text = "---";
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.textBox_TimedActions);
            this.panel_Right.Controls.Add(this.label4);
            this.panel_Right.Controls.Add(this.checkBox_Record);
            this.panel_Right.Controls.Add(this.listBox_Commands);
            this.panel_Right.Controls.Add(this.label5);
            this.panel_Right.Controls.Add(this.label_TimeButtonPressed);
            this.panel_Right.Location = new System.Drawing.Point(432, 27);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(402, 446);
            this.panel_Right.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 533);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.label_CurrentLineRunning);
            this.Controls.Add(this.panel_Buttons);
            this.Controls.Add(this.button_Abort);
            this.Controls.Add(this.button_RunScript);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_Buttons.ResumeLayout(false);
            this.panel_Buttons.PerformLayout();
            this.panel_Right.ResumeLayout(false);
            this.panel_Right.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GripOpen;
        private System.Windows.Forms.CheckBox checkBox_LED;
        private System.Windows.Forms.Button button_GripClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_WristUp;
        private System.Windows.Forms.Button button_WristDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ElbowUp;
        private System.Windows.Forms.Button button_ElbowDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_StemBack;
        private System.Windows.Forms.Button button_StemAhead;
        private System.Windows.Forms.Button button_BaseLeft;
        private System.Windows.Forms.Button button_BaseRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectUSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_RunScript;
        private System.Windows.Forms.CheckBox checkBox_Record;
        private System.Windows.Forms.Label label_TimeButtonPressed;
        private System.Windows.Forms.Timer timer_ButtonPresses;
        private System.Windows.Forms.TextBox textBox_TimedActions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_Commands;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Script;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Script;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Abort;
        private System.Windows.Forms.Panel panel_Buttons;
        private System.Windows.Forms.Label label_CurrentLineRunning;
        private System.Windows.Forms.Panel panel_Right;
    }
}

