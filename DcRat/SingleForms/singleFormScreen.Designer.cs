
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.singleForms
{
    partial class singleFormScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormScreen));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.toolStripscreen = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonstart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonstop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorstart = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelquality = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxquality = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelswichscreen = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxswitch = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtoncapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonmouse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonkeyboard = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxscreen = new System.Windows.Forms.PictureBox();
            this.timerSave = new System.Windows.Forms.Timer(this.components);
            this.paneltop.SuspendLayout();
            this.toolStripscreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxscreen)).BeginInit();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.Controls.Add(this.labelDcRat);
            this.paneltop.Controls.Add(this.buttonmin);
            this.paneltop.Controls.Add(this.buttonmax);
            this.paneltop.Controls.Add(this.buttonclose);
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.Name = "paneltop";
            this.paneltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltop_MouseDown);
            // 
            // labelDcRat
            // 
            resources.ApplyResources(this.labelDcRat, "labelDcRat");
            this.labelDcRat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.labelDcRat.Name = "labelDcRat";
            this.labelDcRat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDcRat_MouseDown);
            // 
            // buttonmin
            // 
            resources.ApplyResources(this.buttonmin, "buttonmin");
            this.buttonmin.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonmin.FlatAppearance.BorderSize = 0;
            this.buttonmin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonmin.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmin.Image = global::DcRat.Properties.Resources.min_dark;
            this.buttonmin.Name = "buttonmin";
            this.buttonmin.UseVisualStyleBackColor = false;
            this.buttonmin.Click += new System.EventHandler(this.buttonmin_Click);
            // 
            // buttonmax
            // 
            resources.ApplyResources(this.buttonmax, "buttonmax");
            this.buttonmax.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonmax.FlatAppearance.BorderSize = 0;
            this.buttonmax.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmax.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonmax.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmax.Image = global::DcRat.Properties.Resources.max_dark;
            this.buttonmax.Name = "buttonmax";
            this.buttonmax.UseVisualStyleBackColor = false;
            this.buttonmax.Click += new System.EventHandler(this.buttonmax_Click);
            // 
            // buttonclose
            // 
            resources.ApplyResources(this.buttonclose, "buttonclose");
            this.buttonclose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonclose.FlatAppearance.BorderSize = 0;
            this.buttonclose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonclose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonclose.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonclose.Image = global::DcRat.Properties.Resources.close_dark;
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // toolStripscreen
            // 
            resources.ApplyResources(this.toolStripscreen, "toolStripscreen");
            this.toolStripscreen.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripscreen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonstart,
            this.toolStripButtonstop,
            this.toolStripSeparatorstart,
            this.toolStripLabelquality,
            this.toolStripComboBoxquality,
            this.toolStripSeparator2,
            this.toolStripLabelswichscreen,
            this.toolStripComboBoxswitch,
            this.toolStripSeparator3,
            this.toolStripButtoncapture,
            this.toolStripSeparator4,
            this.toolStripButtonmouse,
            this.toolStripSeparator5,
            this.toolStripButtonkeyboard});
            this.toolStripscreen.Name = "toolStripscreen";
            // 
            // toolStripButtonstart
            // 
            resources.ApplyResources(this.toolStripButtonstart, "toolStripButtonstart");
            this.toolStripButtonstart.Image = global::DcRat.Properties.Resources.play_dark;
            this.toolStripButtonstart.Name = "toolStripButtonstart";
            this.toolStripButtonstart.Click += new System.EventHandler(this.toolStripButtonstart_Click);
            // 
            // toolStripButtonstop
            // 
            this.toolStripButtonstop.Image = global::DcRat.Properties.Resources.stop_dark;
            resources.ApplyResources(this.toolStripButtonstop, "toolStripButtonstop");
            this.toolStripButtonstop.Name = "toolStripButtonstop";
            this.toolStripButtonstop.Click += new System.EventHandler(this.toolStripButtonstop_Click);
            // 
            // toolStripSeparatorstart
            // 
            this.toolStripSeparatorstart.Name = "toolStripSeparatorstart";
            resources.ApplyResources(this.toolStripSeparatorstart, "toolStripSeparatorstart");
            // 
            // toolStripLabelquality
            // 
            this.toolStripLabelquality.Name = "toolStripLabelquality";
            resources.ApplyResources(this.toolStripLabelquality, "toolStripLabelquality");
            // 
            // toolStripComboBoxquality
            // 
            this.toolStripComboBoxquality.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxquality.Items"),
            resources.GetString("toolStripComboBoxquality.Items1"),
            resources.GetString("toolStripComboBoxquality.Items2"),
            resources.GetString("toolStripComboBoxquality.Items3"),
            resources.GetString("toolStripComboBoxquality.Items4"),
            resources.GetString("toolStripComboBoxquality.Items5"),
            resources.GetString("toolStripComboBoxquality.Items6"),
            resources.GetString("toolStripComboBoxquality.Items7")});
            this.toolStripComboBoxquality.Name = "toolStripComboBoxquality";
            resources.ApplyResources(this.toolStripComboBoxquality, "toolStripComboBoxquality");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripLabelswichscreen
            // 
            this.toolStripLabelswichscreen.Name = "toolStripLabelswichscreen";
            resources.ApplyResources(this.toolStripLabelswichscreen, "toolStripLabelswichscreen");
            // 
            // toolStripComboBoxswitch
            // 
            this.toolStripComboBoxswitch.Name = "toolStripComboBoxswitch";
            resources.ApplyResources(this.toolStripComboBoxswitch, "toolStripComboBoxswitch");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtoncapture
            // 
            this.toolStripButtoncapture.Image = global::DcRat.Properties.Resources.capture_dark;
            resources.ApplyResources(this.toolStripButtoncapture, "toolStripButtoncapture");
            this.toolStripButtoncapture.Name = "toolStripButtoncapture";
            this.toolStripButtoncapture.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtoncapture.Click += new System.EventHandler(this.toolStripButtoncapture_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButtonmouse
            // 
            this.toolStripButtonmouse.Image = global::DcRat.Properties.Resources.mouse_dark;
            resources.ApplyResources(this.toolStripButtonmouse, "toolStripButtonmouse");
            this.toolStripButtonmouse.Name = "toolStripButtonmouse";
            this.toolStripButtonmouse.Click += new System.EventHandler(this.toolStripButtonmouse_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripButtonkeyboard
            // 
            this.toolStripButtonkeyboard.Image = global::DcRat.Properties.Resources.keyboard_dark;
            resources.ApplyResources(this.toolStripButtonkeyboard, "toolStripButtonkeyboard");
            this.toolStripButtonkeyboard.Name = "toolStripButtonkeyboard";
            this.toolStripButtonkeyboard.Click += new System.EventHandler(this.toolStripButtonkeyboard_Click);
            // 
            // pictureBoxscreen
            // 
            this.pictureBoxscreen.BackColor = System.Drawing.SystemColors.Desktop;
            resources.ApplyResources(this.pictureBoxscreen, "pictureBoxscreen");
            this.pictureBoxscreen.Name = "pictureBoxscreen";
            this.pictureBoxscreen.TabStop = false;
            this.pictureBoxscreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxscreen_MouseDown);
            this.pictureBoxscreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxscreen_MouseMove);
            this.pictureBoxscreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxscreen_MouseUp);
            // 
            // timerSave
            // 
            this.timerSave.Interval = 1000;
            this.timerSave.Tick += new System.EventHandler(this.timerSave_Tick);
            // 
            // singleFormScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxscreen);
            this.Controls.Add(this.toolStripscreen);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "singleFormScreen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleFormScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.singleFormScreen_KeyUp);
            this.paneltop.ResumeLayout(false);
            this.toolStripscreen.ResumeLayout(false);
            this.toolStripscreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxscreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel paneltop;
        private Label labelDcRat;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonclose;
        private ToolStrip toolStripscreen;
        private ToolStripButton toolStripButtonstart;
        private ToolStripButton toolStripButtonstop;
        private ToolStripSeparator toolStripSeparatorstart;
        private ToolStripLabel toolStripLabelquality;
        private ToolStripComboBox toolStripComboBoxquality;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButtoncapture;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButtonmouse;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButtonkeyboard;
        private ToolStripLabel toolStripLabelswichscreen;
        private Timer timerSave;
        public ToolStripComboBox toolStripComboBoxswitch;
        public PictureBox pictureBoxscreen;
    }
}