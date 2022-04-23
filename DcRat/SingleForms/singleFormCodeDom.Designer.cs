
using System.ComponentModel;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace DcRat.singleForms
{
    partial class singleFormCodeDom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormCodeDom));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.fastColoredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.label = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox)).BeginInit();
            this.paneltop.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.fastColoredTextBox);
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonSend);
            this.splitContainer.Panel2.Controls.Add(this.checkedListBox);
            this.splitContainer.Panel2.Controls.Add(this.label);
            // 
            // fastColoredTextBox
            // 
            this.fastColoredTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            resources.ApplyResources(this.fastColoredTextBox, "fastColoredTextBox");
            this.fastColoredTextBox.BackBrush = null;
            this.fastColoredTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox.CharHeight = 14;
            this.fastColoredTextBox.CharWidth = 8;
            this.fastColoredTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox.IsReplaceMode = false;
            this.fastColoredTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fastColoredTextBox.LeftBracket = '(';
            this.fastColoredTextBox.LeftBracket2 = '{';
            this.fastColoredTextBox.Name = "fastColoredTextBox";
            this.fastColoredTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox.RightBracket = ')';
            this.fastColoredTextBox.RightBracket2 = '}';
            this.fastColoredTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox.ServiceColors")));
            this.fastColoredTextBox.Zoom = 100;
            // 
            // buttonSend
            // 
            resources.ApplyResources(this.buttonSend, "buttonSend");
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // checkedListBox
            // 
            resources.ApplyResources(this.checkedListBox, "checkedListBox");
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            resources.GetString("checkedListBox.Items"),
            resources.GetString("checkedListBox.Items1"),
            resources.GetString("checkedListBox.Items2"),
            resources.GetString("checkedListBox.Items3"),
            resources.GetString("checkedListBox.Items4"),
            resources.GetString("checkedListBox.Items5"),
            resources.GetString("checkedListBox.Items6"),
            resources.GetString("checkedListBox.Items7"),
            resources.GetString("checkedListBox.Items8"),
            resources.GetString("checkedListBox.Items9"),
            resources.GetString("checkedListBox.Items10"),
            resources.GetString("checkedListBox.Items11"),
            resources.GetString("checkedListBox.Items12"),
            resources.GetString("checkedListBox.Items13"),
            resources.GetString("checkedListBox.Items14"),
            resources.GetString("checkedListBox.Items15"),
            resources.GetString("checkedListBox.Items16"),
            resources.GetString("checkedListBox.Items17"),
            resources.GetString("checkedListBox.Items18"),
            resources.GetString("checkedListBox.Items19"),
            resources.GetString("checkedListBox.Items20"),
            resources.GetString("checkedListBox.Items21"),
            resources.GetString("checkedListBox.Items22"),
            resources.GetString("checkedListBox.Items23"),
            resources.GetString("checkedListBox.Items24"),
            resources.GetString("checkedListBox.Items25"),
            resources.GetString("checkedListBox.Items26"),
            resources.GetString("checkedListBox.Items27"),
            resources.GetString("checkedListBox.Items28"),
            resources.GetString("checkedListBox.Items29"),
            resources.GetString("checkedListBox.Items30"),
            resources.GetString("checkedListBox.Items31"),
            resources.GetString("checkedListBox.Items32"),
            resources.GetString("checkedListBox.Items33"),
            resources.GetString("checkedListBox.Items34"),
            resources.GetString("checkedListBox.Items35"),
            resources.GetString("checkedListBox.Items36"),
            resources.GetString("checkedListBox.Items37"),
            resources.GetString("checkedListBox.Items38"),
            resources.GetString("checkedListBox.Items39"),
            resources.GetString("checkedListBox.Items40"),
            resources.GetString("checkedListBox.Items41"),
            resources.GetString("checkedListBox.Items42"),
            resources.GetString("checkedListBox.Items43"),
            resources.GetString("checkedListBox.Items44"),
            resources.GetString("checkedListBox.Items45"),
            resources.GetString("checkedListBox.Items46"),
            resources.GetString("checkedListBox.Items47"),
            resources.GetString("checkedListBox.Items48"),
            resources.GetString("checkedListBox.Items49"),
            resources.GetString("checkedListBox.Items50"),
            resources.GetString("checkedListBox.Items51"),
            resources.GetString("checkedListBox.Items52"),
            resources.GetString("checkedListBox.Items53"),
            resources.GetString("checkedListBox.Items54"),
            resources.GetString("checkedListBox.Items55"),
            resources.GetString("checkedListBox.Items56"),
            resources.GetString("checkedListBox.Items57"),
            resources.GetString("checkedListBox.Items58"),
            resources.GetString("checkedListBox.Items59"),
            resources.GetString("checkedListBox.Items60"),
            resources.GetString("checkedListBox.Items61"),
            resources.GetString("checkedListBox.Items62"),
            resources.GetString("checkedListBox.Items63"),
            resources.GetString("checkedListBox.Items64"),
            resources.GetString("checkedListBox.Items65"),
            resources.GetString("checkedListBox.Items66"),
            resources.GetString("checkedListBox.Items67"),
            resources.GetString("checkedListBox.Items68"),
            resources.GetString("checkedListBox.Items69"),
            resources.GetString("checkedListBox.Items70"),
            resources.GetString("checkedListBox.Items71"),
            resources.GetString("checkedListBox.Items72"),
            resources.GetString("checkedListBox.Items73"),
            resources.GetString("checkedListBox.Items74"),
            resources.GetString("checkedListBox.Items75"),
            resources.GetString("checkedListBox.Items76"),
            resources.GetString("checkedListBox.Items77"),
            resources.GetString("checkedListBox.Items78"),
            resources.GetString("checkedListBox.Items79"),
            resources.GetString("checkedListBox.Items80"),
            resources.GetString("checkedListBox.Items81"),
            resources.GetString("checkedListBox.Items82"),
            resources.GetString("checkedListBox.Items83"),
            resources.GetString("checkedListBox.Items84"),
            resources.GetString("checkedListBox.Items85"),
            resources.GetString("checkedListBox.Items86"),
            resources.GetString("checkedListBox.Items87"),
            resources.GetString("checkedListBox.Items88"),
            resources.GetString("checkedListBox.Items89"),
            resources.GetString("checkedListBox.Items90"),
            resources.GetString("checkedListBox.Items91"),
            resources.GetString("checkedListBox.Items92"),
            resources.GetString("checkedListBox.Items93"),
            resources.GetString("checkedListBox.Items94"),
            resources.GetString("checkedListBox.Items95"),
            resources.GetString("checkedListBox.Items96"),
            resources.GetString("checkedListBox.Items97"),
            resources.GetString("checkedListBox.Items98"),
            resources.GetString("checkedListBox.Items99"),
            resources.GetString("checkedListBox.Items100"),
            resources.GetString("checkedListBox.Items101"),
            resources.GetString("checkedListBox.Items102"),
            resources.GetString("checkedListBox.Items103"),
            resources.GetString("checkedListBox.Items104"),
            resources.GetString("checkedListBox.Items105"),
            resources.GetString("checkedListBox.Items106"),
            resources.GetString("checkedListBox.Items107"),
            resources.GetString("checkedListBox.Items108"),
            resources.GetString("checkedListBox.Items109"),
            resources.GetString("checkedListBox.Items110"),
            resources.GetString("checkedListBox.Items111"),
            resources.GetString("checkedListBox.Items112"),
            resources.GetString("checkedListBox.Items113"),
            resources.GetString("checkedListBox.Items114"),
            resources.GetString("checkedListBox.Items115"),
            resources.GetString("checkedListBox.Items116"),
            resources.GetString("checkedListBox.Items117")});
            this.checkedListBox.Name = "checkedListBox";
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.SystemColors.Control;
            this.paneltop.Controls.Add(this.labelDcRat);
            this.paneltop.Controls.Add(this.buttonmin);
            this.paneltop.Controls.Add(this.buttonmax);
            this.paneltop.Controls.Add(this.buttonclose);
            resources.ApplyResources(this.paneltop, "paneltop");
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
            // buttonmin
            // 
            resources.ApplyResources(this.buttonmin, "buttonmin");
            this.buttonmin.BackColor = System.Drawing.SystemColors.Control;
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
            this.buttonmax.BackColor = System.Drawing.SystemColors.Control;
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
            // panel
            // 
            this.panel.Controls.Add(this.splitContainer);
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            // 
            // singleFormCodeDom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singleFormCodeDom";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer;
        private FastColoredTextBox fastColoredTextBox;
        private Button buttonSend;
        private CheckedListBox checkedListBox;
        private Label label;
        private Panel paneltop;
        private Label labelDcRat;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonclose;
        private Panel panel;
    }
}