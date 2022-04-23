
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.singleForms
{
    partial class singleFormCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormCamera));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.toolStripcamera = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonstartcam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonstopcam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelquality = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxquality = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelswitch = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxswitch = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtoncapture = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxcamera = new System.Windows.Forms.PictureBox();
            this.paneltop.SuspendLayout();
            this.toolStripcamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxcamera)).BeginInit();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.SystemColors.Control;
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
            this.labelDcRat.BackColor = System.Drawing.SystemColors.Control;
            this.labelDcRat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.labelDcRat.Name = "labelDcRat";
            this.labelDcRat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDcRat_MouseDown);
            // 
            // buttonmin
            // 
            resources.ApplyResources(this.buttonmin, "buttonmin");
            this.buttonmin.BackColor = System.Drawing.SystemColors.Control;
            this.buttonmin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.buttonmin.FlatAppearance.BorderSize = 0;
            this.buttonmin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonmin.Image = global::DcRat.Properties.Resources.min_dark;
            this.buttonmin.Name = "buttonmin";
            this.buttonmin.UseVisualStyleBackColor = false;
            this.buttonmin.Click += new System.EventHandler(this.buttonmin_Click);
            // 
            // buttonmax
            // 
            resources.ApplyResources(this.buttonmax, "buttonmax");
            this.buttonmax.BackColor = System.Drawing.SystemColors.Control;
            this.buttonmax.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.buttonmax.FlatAppearance.BorderSize = 0;
            this.buttonmax.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmax.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonmax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonmax.Image = global::DcRat.Properties.Resources.max_dark;
            this.buttonmax.Name = "buttonmax";
            this.buttonmax.UseVisualStyleBackColor = false;
            this.buttonmax.Click += new System.EventHandler(this.buttonmax_Click);
            // 
            // buttonclose
            // 
            resources.ApplyResources(this.buttonclose, "buttonclose");
            this.buttonclose.BackColor = System.Drawing.SystemColors.Control;
            this.buttonclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.buttonclose.FlatAppearance.BorderSize = 0;
            this.buttonclose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonclose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonclose.Image = global::DcRat.Properties.Resources.close_dark;
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // toolStripcamera
            // 
            resources.ApplyResources(this.toolStripcamera, "toolStripcamera");
            this.toolStripcamera.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripcamera.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripcamera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonstartcam,
            this.toolStripButtonstopcam,
            this.toolStripSeparator1,
            this.toolStripLabelquality,
            this.toolStripComboBoxquality,
            this.toolStripSeparator2,
            this.toolStripLabelswitch,
            this.toolStripComboBoxswitch,
            this.toolStripSeparator3,
            this.toolStripButtoncapture});
            this.toolStripcamera.Name = "toolStripcamera";
            // 
            // toolStripButtonstartcam
            // 
            this.toolStripButtonstartcam.Image = global::DcRat.Properties.Resources.play_dark;
            resources.ApplyResources(this.toolStripButtonstartcam, "toolStripButtonstartcam");
            this.toolStripButtonstartcam.Name = "toolStripButtonstartcam";
            this.toolStripButtonstartcam.Click += new System.EventHandler(this.toolStripButtonstartcam_Click);
            // 
            // toolStripButtonstopcam
            // 
            resources.ApplyResources(this.toolStripButtonstopcam, "toolStripButtonstopcam");
            this.toolStripButtonstopcam.Image = global::DcRat.Properties.Resources.stop_dark;
            this.toolStripButtonstopcam.Name = "toolStripButtonstopcam";
            this.toolStripButtonstopcam.Click += new System.EventHandler(this.toolStripButtonstopcam_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripLabelquality
            // 
            this.toolStripLabelquality.Name = "toolStripLabelquality";
            resources.ApplyResources(this.toolStripLabelquality, "toolStripLabelquality");
            // 
            // toolStripComboBoxquality
            // 
            resources.ApplyResources(this.toolStripComboBoxquality, "toolStripComboBoxquality");
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
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripLabelswitch
            // 
            this.toolStripLabelswitch.Name = "toolStripLabelswitch";
            resources.ApplyResources(this.toolStripLabelswitch, "toolStripLabelswitch");
            // 
            // toolStripComboBoxswitch
            // 
            this.toolStripComboBoxswitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.toolStripComboBoxswitch, "toolStripComboBoxswitch");
            this.toolStripComboBoxswitch.Name = "toolStripComboBoxswitch";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtoncapture
            // 
            resources.ApplyResources(this.toolStripButtoncapture, "toolStripButtoncapture");
            this.toolStripButtoncapture.Image = global::DcRat.Properties.Resources.capture_dark;
            this.toolStripButtoncapture.Name = "toolStripButtoncapture";
            this.toolStripButtoncapture.Click += new System.EventHandler(this.toolStripButtoncapture_Click);
            // 
            // pictureBoxcamera
            // 
            this.pictureBoxcamera.BackColor = System.Drawing.SystemColors.Desktop;
            resources.ApplyResources(this.pictureBoxcamera, "pictureBoxcamera");
            this.pictureBoxcamera.Name = "pictureBoxcamera";
            this.pictureBoxcamera.TabStop = false;
            // 
            // singleFormCamera
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxcamera);
            this.Controls.Add(this.toolStripcamera);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singleFormCamera";
            this.paneltop.ResumeLayout(false);
            this.toolStripcamera.ResumeLayout(false);
            this.toolStripcamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxcamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel paneltop;
        private Label labelDcRat;
        private ToolStrip toolStripcamera;
        private ToolStripButton toolStripButtonstopcam;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabelquality;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabelswitch;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButtoncapture;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonclose;
        private ToolStripComboBox toolStripComboBoxquality;
        public ToolStripComboBox toolStripComboBoxswitch;
        public ToolStripButton toolStripButtonstartcam;
        public PictureBox pictureBoxcamera;
    }
}