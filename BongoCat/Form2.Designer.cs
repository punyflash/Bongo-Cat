namespace BongoCat
{
    partial class Settings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Modes = new System.Windows.Forms.TabControl();
            this.Default = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Right = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Left = new System.Windows.Forms.ListBox();
            this.AddRight = new System.Windows.Forms.Button();
            this.AddLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Background = new System.Windows.Forms.Button();
            this.Instrument = new System.Windows.Forms.ComboBox();
            this.Mouse = new System.Windows.Forms.CheckBox();
            this.Table = new System.Windows.Forms.CheckBox();
            this.Modes.SuspendLayout();
            this.Default.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Modes
            // 
            this.Modes.Controls.Add(this.Default);
            this.Modes.Location = new System.Drawing.Point(0, 0);
            this.Modes.Name = "Modes";
            this.Modes.SelectedIndex = 0;
            this.Modes.Size = new System.Drawing.Size(246, 213);
            this.Modes.TabIndex = 0;
            this.Modes.TabStop = false;
            // 
            // Default
            // 
            this.Default.Controls.Add(this.Table);
            this.Default.Controls.Add(this.Mouse);
            this.Default.Controls.Add(this.Instrument);
            this.Default.Controls.Add(this.Background);
            this.Default.Controls.Add(this.label3);
            this.Default.Controls.Add(this.label2);
            this.Default.Controls.Add(this.label1);
            this.Default.Controls.Add(this.AddLeft);
            this.Default.Controls.Add(this.AddRight);
            this.Default.Controls.Add(this.groupBox2);
            this.Default.Controls.Add(this.groupBox1);
            this.Default.Location = new System.Drawing.Point(4, 22);
            this.Default.Name = "Default";
            this.Default.Padding = new System.Windows.Forms.Padding(3);
            this.Default.Size = new System.Drawing.Size(238, 187);
            this.Default.TabIndex = 0;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 211);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(244, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel1.Text = "Version 1.2.0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(102, 17);
            this.toolStripStatusLabel2.Text = "App by PunyFlash";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Right);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(65, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key 1";
            // 
            // Right
            // 
            this.Right.FormattingEnabled = true;
            this.Right.Location = new System.Drawing.Point(6, 19);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(53, 56);
            this.Right.TabIndex = 0;
            this.Right.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Left);
            this.groupBox2.Location = new System.Drawing.Point(167, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(65, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key 2";
            // 
            // Left
            // 
            this.Left.FormattingEnabled = true;
            this.Left.Location = new System.Drawing.Point(6, 19);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(53, 56);
            this.Left.TabIndex = 1;
            this.Left.TabStop = false;
            // 
            // AddRight
            // 
            this.AddRight.Location = new System.Drawing.Point(77, 25);
            this.AddRight.Name = "AddRight";
            this.AddRight.Size = new System.Drawing.Size(84, 23);
            this.AddRight.TabIndex = 2;
            this.AddRight.TabStop = false;
            this.AddRight.Text = "<= Add";
            this.AddRight.UseVisualStyleBackColor = true;
            this.AddRight.Click += new System.EventHandler(this.AddRight_Click);
            // 
            // AddLeft
            // 
            this.AddLeft.Location = new System.Drawing.Point(77, 58);
            this.AddLeft.Name = "AddLeft";
            this.AddLeft.Size = new System.Drawing.Size(84, 23);
            this.AddLeft.TabIndex = 3;
            this.AddLeft.TabStop = false;
            this.AddLeft.Text = "Add =>";
            this.AddLeft.UseVisualStyleBackColor = true;
            this.AddLeft.Click += new System.EventHandler(this.AddLeft_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(31, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Doubleclick on key value to delete it";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Backbround:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Instrument:";
            // 
            // Background
            // 
            this.Background.Location = new System.Drawing.Point(77, 110);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(155, 23);
            this.Background.TabIndex = 7;
            this.Background.TabStop = false;
            this.Background.UseVisualStyleBackColor = true;
            this.Background.Click += new System.EventHandler(this.Background_Click);
            // 
            // Instrument
            // 
            this.Instrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Instrument.FormattingEnabled = true;
            this.Instrument.Items.AddRange(new object[] {
            "None",
            "Bongo",
            "Controller",
            "Keyboard"});
            this.Instrument.Location = new System.Drawing.Point(77, 139);
            this.Instrument.Name = "Instrument";
            this.Instrument.Size = new System.Drawing.Size(155, 21);
            this.Instrument.TabIndex = 8;
            this.Instrument.TabStop = false;
            this.Instrument.SelectedIndexChanged += new System.EventHandler(this.Instrument_SelectedIndexChanged);
            // 
            // Mouse
            // 
            this.Mouse.AutoSize = true;
            this.Mouse.Location = new System.Drawing.Point(6, 166);
            this.Mouse.Name = "Mouse";
            this.Mouse.Size = new System.Drawing.Size(114, 17);
            this.Mouse.TabIndex = 9;
            this.Mouse.TabStop = false;
            this.Mouse.Text = "Track mouse input";
            this.Mouse.UseVisualStyleBackColor = true;
            this.Mouse.CheckedChanged += new System.EventHandler(this.Mouse_CheckedChanged);
            // 
            // Table
            // 
            this.Table.AutoSize = true;
            this.Table.Location = new System.Drawing.Point(123, 166);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(109, 17);
            this.Table.TabIndex = 10;
            this.Table.TabStop = false;
            this.Table.Text = "Transparent table";
            this.Table.UseVisualStyleBackColor = true;
            this.Table.CheckedChanged += new System.EventHandler(this.Table_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 233);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Modes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Modes.ResumeLayout(false);
            this.Default.ResumeLayout(false);
            this.Default.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Modes;
        private System.Windows.Forms.TabPage Default;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.CheckBox Table;
        private System.Windows.Forms.CheckBox Mouse;
        private System.Windows.Forms.ComboBox Instrument;
        private System.Windows.Forms.Button Background;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddLeft;
        private System.Windows.Forms.Button AddRight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox Left;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox Right;
    }
}