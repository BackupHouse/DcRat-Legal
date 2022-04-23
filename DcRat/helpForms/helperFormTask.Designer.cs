
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.helpForms
{
    partial class helperFormTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helperFormTask));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonok = new System.Windows.Forms.Button();
            this.groupBoxtrigger = new System.Windows.Forms.GroupBox();
            this.radioButtonnewconnection = new System.Windows.Forms.RadioButton();
            this.radioButtonnewmachine = new System.Windows.Forms.RadioButton();
            this.labelname = new System.Windows.Forms.Label();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.groupBoxaction = new System.Windows.Forms.GroupBox();
            this.radioButtoncodedom = new System.Windows.Forms.RadioButton();
            this.radioButtondownloadfile = new System.Windows.Forms.RadioButton();
            this.radioButtonsendfile = new System.Windows.Forms.RadioButton();
            this.radioButtoninstall = new System.Windows.Forms.RadioButton();
            this.radioButtonupdate = new System.Windows.Forms.RadioButton();
            this.radioButtonopenwebsite = new System.Windows.Forms.RadioButton();
            this.radioButtonmessagebox = new System.Windows.Forms.RadioButton();
            this.paneltop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxtrigger.SuspendLayout();
            this.groupBoxaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.BackColor = System.Drawing.SystemColors.Control;
            this.paneltop.Controls.Add(this.labelDcRat);
            this.paneltop.Controls.Add(this.buttonclose);
            this.paneltop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
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
            // buttonclose
            // 
            resources.ApplyResources(this.buttonclose, "buttonclose");
            this.buttonclose.BackColor = System.Drawing.SystemColors.Control;
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
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.buttonok);
            this.panel1.Controls.Add(this.groupBoxtrigger);
            this.panel1.Controls.Add(this.labelname);
            this.panel1.Controls.Add(this.textBoxname);
            this.panel1.Controls.Add(this.groupBoxaction);
            this.panel1.Name = "panel1";
            // 
            // buttonok
            // 
            resources.ApplyResources(this.buttonok, "buttonok");
            this.buttonok.Name = "buttonok";
            this.buttonok.UseVisualStyleBackColor = true;
            this.buttonok.Click += new System.EventHandler(this.buttonok_Click);
            // 
            // groupBoxtrigger
            // 
            resources.ApplyResources(this.groupBoxtrigger, "groupBoxtrigger");
            this.groupBoxtrigger.Controls.Add(this.radioButtonnewconnection);
            this.groupBoxtrigger.Controls.Add(this.radioButtonnewmachine);
            this.groupBoxtrigger.Name = "groupBoxtrigger";
            this.groupBoxtrigger.TabStop = false;
            // 
            // radioButtonnewconnection
            // 
            resources.ApplyResources(this.radioButtonnewconnection, "radioButtonnewconnection");
            this.radioButtonnewconnection.Checked = true;
            this.radioButtonnewconnection.Name = "radioButtonnewconnection";
            this.radioButtonnewconnection.TabStop = true;
            this.radioButtonnewconnection.UseVisualStyleBackColor = true;
            // 
            // radioButtonnewmachine
            // 
            resources.ApplyResources(this.radioButtonnewmachine, "radioButtonnewmachine");
            this.radioButtonnewmachine.Name = "radioButtonnewmachine";
            this.radioButtonnewmachine.TabStop = true;
            this.radioButtonnewmachine.UseVisualStyleBackColor = true;
            // 
            // labelname
            // 
            resources.ApplyResources(this.labelname, "labelname");
            this.labelname.Name = "labelname";
            // 
            // textBoxname
            // 
            resources.ApplyResources(this.textBoxname, "textBoxname");
            this.textBoxname.Name = "textBoxname";
            // 
            // groupBoxaction
            // 
            resources.ApplyResources(this.groupBoxaction, "groupBoxaction");
            this.groupBoxaction.Controls.Add(this.radioButtoncodedom);
            this.groupBoxaction.Controls.Add(this.radioButtondownloadfile);
            this.groupBoxaction.Controls.Add(this.radioButtonsendfile);
            this.groupBoxaction.Controls.Add(this.radioButtoninstall);
            this.groupBoxaction.Controls.Add(this.radioButtonupdate);
            this.groupBoxaction.Controls.Add(this.radioButtonopenwebsite);
            this.groupBoxaction.Controls.Add(this.radioButtonmessagebox);
            this.groupBoxaction.Name = "groupBoxaction";
            this.groupBoxaction.TabStop = false;
            // 
            // radioButtoncodedom
            // 
            resources.ApplyResources(this.radioButtoncodedom, "radioButtoncodedom");
            this.radioButtoncodedom.Name = "radioButtoncodedom";
            this.radioButtoncodedom.TabStop = true;
            this.radioButtoncodedom.UseVisualStyleBackColor = true;
            // 
            // radioButtondownloadfile
            // 
            resources.ApplyResources(this.radioButtondownloadfile, "radioButtondownloadfile");
            this.radioButtondownloadfile.Name = "radioButtondownloadfile";
            this.radioButtondownloadfile.TabStop = true;
            this.radioButtondownloadfile.UseVisualStyleBackColor = true;
            // 
            // radioButtonsendfile
            // 
            resources.ApplyResources(this.radioButtonsendfile, "radioButtonsendfile");
            this.radioButtonsendfile.Checked = true;
            this.radioButtonsendfile.Name = "radioButtonsendfile";
            this.radioButtonsendfile.TabStop = true;
            this.radioButtonsendfile.UseVisualStyleBackColor = true;
            // 
            // radioButtoninstall
            // 
            resources.ApplyResources(this.radioButtoninstall, "radioButtoninstall");
            this.radioButtoninstall.Name = "radioButtoninstall";
            this.radioButtoninstall.UseVisualStyleBackColor = true;
            // 
            // radioButtonupdate
            // 
            resources.ApplyResources(this.radioButtonupdate, "radioButtonupdate");
            this.radioButtonupdate.Name = "radioButtonupdate";
            this.radioButtonupdate.UseVisualStyleBackColor = true;
            // 
            // radioButtonopenwebsite
            // 
            resources.ApplyResources(this.radioButtonopenwebsite, "radioButtonopenwebsite");
            this.radioButtonopenwebsite.Name = "radioButtonopenwebsite";
            this.radioButtonopenwebsite.UseVisualStyleBackColor = true;
            // 
            // radioButtonmessagebox
            // 
            resources.ApplyResources(this.radioButtonmessagebox, "radioButtonmessagebox");
            this.radioButtonmessagebox.Name = "radioButtonmessagebox";
            this.radioButtonmessagebox.UseVisualStyleBackColor = true;
            // 
            // helperFormTask
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "helperFormTask";
            this.ShowInTaskbar = false;
            this.paneltop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxtrigger.ResumeLayout(false);
            this.groupBoxtrigger.PerformLayout();
            this.groupBoxaction.ResumeLayout(false);
            this.groupBoxaction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel paneltop;
        private Label labelDcRat;
        private Button buttonclose;
        private Panel panel1;
        private Label labelname;
        private RadioButton radioButtonnewconnection;
        private RadioButton radioButtonnewmachine;
        private TextBox textBoxname;
        private GroupBox groupBoxaction;
        private RadioButton radioButtonsendfile;
        private RadioButton radioButtoninstall;
        private RadioButton radioButtonupdate;
        private RadioButton radioButtonopenwebsite;
        private RadioButton radioButtonmessagebox;
        private Button buttonok;
        private GroupBox groupBoxtrigger;
        private RadioButton radioButtondownloadfile;
        private RadioButton radioButtoncodedom;
    }
}