
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.ChildForms
{
    partial class childFormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(childFormSettings));
            this.panelSettingsBack = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupBoxnotify = new System.Windows.Forms.GroupBox();
            this.labeldingding = new System.Windows.Forms.Label();
            this.labeltelegram = new System.Windows.Forms.Label();
            this.labeldiscord = new System.Windows.Forms.Label();
            this.buttondiscordbind = new System.Windows.Forms.Button();
            this.buttontelegrambind = new System.Windows.Forms.Button();
            this.labelmail = new System.Windows.Forms.Label();
            this.buttondingdingbind = new System.Windows.Forms.Button();
            this.buttonmailbind = new System.Windows.Forms.Button();
            this.groupBoxtheme = new System.Windows.Forms.GroupBox();
            this.comboBoxlanguage = new System.Windows.Forms.ComboBox();
            this.labellanguage = new System.Windows.Forms.Label();
            this.trackBaropacity = new System.Windows.Forms.TrackBar();
            this.radioButtonlight = new System.Windows.Forms.RadioButton();
            this.radioButtondark = new System.Windows.Forms.RadioButton();
            this.labelopacity = new System.Windows.Forms.Label();
            this.labelcolor = new System.Windows.Forms.Label();
            this.panelSettingsBack.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBoxnotify.SuspendLayout();
            this.groupBoxtheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBaropacity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSettingsBack
            // 
            resources.ApplyResources(this.panelSettingsBack, "panelSettingsBack");
            this.panelSettingsBack.Controls.Add(this.panelSettings);
            this.panelSettingsBack.Name = "panelSettingsBack";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.groupBoxnotify);
            this.panelSettings.Controls.Add(this.groupBoxtheme);
            resources.ApplyResources(this.panelSettings, "panelSettings");
            this.panelSettings.Name = "panelSettings";
            // 
            // groupBoxnotify
            // 
            resources.ApplyResources(this.groupBoxnotify, "groupBoxnotify");
            this.groupBoxnotify.Controls.Add(this.labeldingding);
            this.groupBoxnotify.Controls.Add(this.labeltelegram);
            this.groupBoxnotify.Controls.Add(this.labeldiscord);
            this.groupBoxnotify.Controls.Add(this.buttondiscordbind);
            this.groupBoxnotify.Controls.Add(this.buttontelegrambind);
            this.groupBoxnotify.Controls.Add(this.labelmail);
            this.groupBoxnotify.Controls.Add(this.buttondingdingbind);
            this.groupBoxnotify.Controls.Add(this.buttonmailbind);
            this.groupBoxnotify.Name = "groupBoxnotify";
            this.groupBoxnotify.TabStop = false;
            // 
            // labeldingding
            // 
            resources.ApplyResources(this.labeldingding, "labeldingding");
            this.labeldingding.Name = "labeldingding";
            // 
            // labeltelegram
            // 
            resources.ApplyResources(this.labeltelegram, "labeltelegram");
            this.labeltelegram.Name = "labeltelegram";
            // 
            // labeldiscord
            // 
            resources.ApplyResources(this.labeldiscord, "labeldiscord");
            this.labeldiscord.Name = "labeldiscord";
            // 
            // buttondiscordbind
            // 
            resources.ApplyResources(this.buttondiscordbind, "buttondiscordbind");
            this.buttondiscordbind.Name = "buttondiscordbind";
            this.buttondiscordbind.UseVisualStyleBackColor = true;
            this.buttondiscordbind.Click += new System.EventHandler(this.buttondiscordbind_Click);
            // 
            // buttontelegrambind
            // 
            resources.ApplyResources(this.buttontelegrambind, "buttontelegrambind");
            this.buttontelegrambind.Name = "buttontelegrambind";
            this.buttontelegrambind.UseVisualStyleBackColor = true;
            this.buttontelegrambind.Click += new System.EventHandler(this.buttontelegrambind_Click);
            // 
            // labelmail
            // 
            resources.ApplyResources(this.labelmail, "labelmail");
            this.labelmail.Name = "labelmail";
            // 
            // buttondingdingbind
            // 
            resources.ApplyResources(this.buttondingdingbind, "buttondingdingbind");
            this.buttondingdingbind.Name = "buttondingdingbind";
            this.buttondingdingbind.UseVisualStyleBackColor = true;
            this.buttondingdingbind.Click += new System.EventHandler(this.buttondingdingbind_Click);
            // 
            // buttonmailbind
            // 
            resources.ApplyResources(this.buttonmailbind, "buttonmailbind");
            this.buttonmailbind.Name = "buttonmailbind";
            this.buttonmailbind.UseVisualStyleBackColor = true;
            this.buttonmailbind.Click += new System.EventHandler(this.buttonmailbind_Click);
            // 
            // groupBoxtheme
            // 
            resources.ApplyResources(this.groupBoxtheme, "groupBoxtheme");
            this.groupBoxtheme.Controls.Add(this.comboBoxlanguage);
            this.groupBoxtheme.Controls.Add(this.labellanguage);
            this.groupBoxtheme.Controls.Add(this.trackBaropacity);
            this.groupBoxtheme.Controls.Add(this.radioButtonlight);
            this.groupBoxtheme.Controls.Add(this.radioButtondark);
            this.groupBoxtheme.Controls.Add(this.labelopacity);
            this.groupBoxtheme.Controls.Add(this.labelcolor);
            this.groupBoxtheme.Name = "groupBoxtheme";
            this.groupBoxtheme.TabStop = false;
            // 
            // comboBoxlanguage
            // 
            this.comboBoxlanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxlanguage.FormattingEnabled = true;
            this.comboBoxlanguage.Items.AddRange(new object[] {
            resources.GetString("comboBoxlanguage.Items"),
            resources.GetString("comboBoxlanguage.Items1")});
            resources.ApplyResources(this.comboBoxlanguage, "comboBoxlanguage");
            this.comboBoxlanguage.Name = "comboBoxlanguage";
            this.comboBoxlanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxlanguage_SelectedIndexChanged);
            // 
            // labellanguage
            // 
            resources.ApplyResources(this.labellanguage, "labellanguage");
            this.labellanguage.Name = "labellanguage";
            // 
            // trackBaropacity
            // 
            this.trackBaropacity.LargeChange = 1;
            resources.ApplyResources(this.trackBaropacity, "trackBaropacity");
            this.trackBaropacity.Maximum = 100;
            this.trackBaropacity.Minimum = 80;
            this.trackBaropacity.Name = "trackBaropacity";
            this.trackBaropacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBaropacity.Value = 97;
            this.trackBaropacity.Scroll += new System.EventHandler(this.trackBaropacity_Scroll);
            // 
            // radioButtonlight
            // 
            resources.ApplyResources(this.radioButtonlight, "radioButtonlight");
            this.radioButtonlight.Checked = true;
            this.radioButtonlight.Name = "radioButtonlight";
            this.radioButtonlight.TabStop = true;
            this.radioButtonlight.UseVisualStyleBackColor = true;
            this.radioButtonlight.CheckedChanged += new System.EventHandler(this.radioButtonlight_CheckedChanged);
            // 
            // radioButtondark
            // 
            resources.ApplyResources(this.radioButtondark, "radioButtondark");
            this.radioButtondark.Name = "radioButtondark";
            this.radioButtondark.UseVisualStyleBackColor = true;
            // 
            // labelopacity
            // 
            resources.ApplyResources(this.labelopacity, "labelopacity");
            this.labelopacity.Name = "labelopacity";
            // 
            // labelcolor
            // 
            resources.ApplyResources(this.labelcolor, "labelcolor");
            this.labelcolor.Name = "labelcolor";
            // 
            // childFormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSettingsBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "childFormSettings";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.childFormSettings_Load);
            this.panelSettingsBack.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.groupBoxnotify.ResumeLayout(false);
            this.groupBoxtheme.ResumeLayout(false);
            this.groupBoxtheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBaropacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelSettingsBack;
        private Panel panelSettings;
        private GroupBox groupBoxtheme;
        private GroupBox groupBoxnotify;
        private Label labeldingding;
        private Label labeltelegram;
        private Label labeldiscord;
        private Label labelmail;
        private Button buttonmailbind;
        private Button buttondingdingbind;
        private Button buttontelegrambind;
        private Button buttondiscordbind;
        private Label labelopacity;
        private Label labelcolor;
        private TrackBar trackBaropacity;
        private RadioButton radioButtonlight;
        private RadioButton radioButtondark;
        private ComboBox comboBoxlanguage;
        private Label labellanguage;
    }
}