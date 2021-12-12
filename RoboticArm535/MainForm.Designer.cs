
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
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_GripOpen
            // 
            this.button_GripOpen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_GripOpen.Location = new System.Drawing.Point(109, 68);
            this.button_GripOpen.Name = "button_GripOpen";
            this.button_GripOpen.Size = new System.Drawing.Size(79, 36);
            this.button_GripOpen.TabIndex = 2;
            this.button_GripOpen.Text = "Open";
            this.button_GripOpen.UseVisualStyleBackColor = true;
            // 
            // checkBox_LED
            // 
            this.checkBox_LED.AutoSize = true;
            this.checkBox_LED.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_LED.Location = new System.Drawing.Point(172, 33);
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
            this.button_GripClose.Location = new System.Drawing.Point(194, 68);
            this.button_GripClose.Name = "button_GripClose";
            this.button_GripClose.Size = new System.Drawing.Size(79, 36);
            this.button_GripClose.TabIndex = 3;
            this.button_GripClose.Text = "Close";
            this.button_GripClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(-456, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grip";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_WristUp
            // 
            this.button_WristUp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_WristUp.Location = new System.Drawing.Point(140, 123);
            this.button_WristUp.Name = "button_WristUp";
            this.button_WristUp.Size = new System.Drawing.Size(95, 38);
            this.button_WristUp.TabIndex = 4;
            this.button_WristUp.Text = "Up";
            this.button_WristUp.UseVisualStyleBackColor = true;
            // 
            // button_WristDown
            // 
            this.button_WristDown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_WristDown.Location = new System.Drawing.Point(140, 167);
            this.button_WristDown.Name = "button_WristDown";
            this.button_WristDown.Size = new System.Drawing.Size(95, 38);
            this.button_WristDown.TabIndex = 5;
            this.button_WristDown.Text = "Down";
            this.button_WristDown.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(-435, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wrist";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_ElbowUp
            // 
            this.button_ElbowUp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ElbowUp.Location = new System.Drawing.Point(140, 224);
            this.button_ElbowUp.Name = "button_ElbowUp";
            this.button_ElbowUp.Size = new System.Drawing.Size(95, 38);
            this.button_ElbowUp.TabIndex = 6;
            this.button_ElbowUp.Text = "Up";
            this.button_ElbowUp.UseVisualStyleBackColor = true;
            // 
            // button_ElbowDown
            // 
            this.button_ElbowDown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ElbowDown.Location = new System.Drawing.Point(140, 268);
            this.button_ElbowDown.Name = "button_ElbowDown";
            this.button_ElbowDown.Size = new System.Drawing.Size(95, 38);
            this.button_ElbowDown.TabIndex = 7;
            this.button_ElbowDown.Text = "Down";
            this.button_ElbowDown.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(-442, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Elbow";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_StemBack
            // 
            this.button_StemBack.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StemBack.Location = new System.Drawing.Point(140, 399);
            this.button_StemBack.Name = "button_StemBack";
            this.button_StemBack.Size = new System.Drawing.Size(95, 64);
            this.button_StemBack.TabIndex = 11;
            this.button_StemBack.Text = "Stem Back";
            this.button_StemBack.UseVisualStyleBackColor = true;
            // 
            // button_StemAhead
            // 
            this.button_StemAhead.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StemAhead.Location = new System.Drawing.Point(140, 329);
            this.button_StemAhead.Name = "button_StemAhead";
            this.button_StemAhead.Size = new System.Drawing.Size(95, 64);
            this.button_StemAhead.TabIndex = 10;
            this.button_StemAhead.Text = "Stem Ahead";
            this.button_StemAhead.UseVisualStyleBackColor = true;
            // 
            // button_BaseLeft
            // 
            this.button_BaseLeft.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_BaseLeft.Location = new System.Drawing.Point(48, 368);
            this.button_BaseLeft.Name = "button_BaseLeft";
            this.button_BaseLeft.Size = new System.Drawing.Size(86, 61);
            this.button_BaseLeft.TabIndex = 8;
            this.button_BaseLeft.Text = "Base Left";
            this.button_BaseLeft.UseVisualStyleBackColor = true;
            // 
            // button_BaseRight
            // 
            this.button_BaseRight.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_BaseRight.Location = new System.Drawing.Point(241, 368);
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
            this.connectionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 533);
            this.Controls.Add(this.button_StemBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_BaseRight);
            this.Controls.Add(this.checkBox_LED);
            this.Controls.Add(this.button_BaseLeft);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_StemAhead);
            this.Controls.Add(this.button_ElbowDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_ElbowUp);
            this.Controls.Add(this.button_GripClose);
            this.Controls.Add(this.button_GripOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_WristDown);
            this.Controls.Add(this.button_WristUp);
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
    }
}

