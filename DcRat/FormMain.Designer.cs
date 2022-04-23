
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DcRat.Properties;

namespace DcRat
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.paneltop = new System.Windows.Forms.Panel();
            this.buttonside = new System.Windows.Forms.Button();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.panelleft = new System.Windows.Forms.Panel();
            this.panelside = new System.Windows.Forms.Panel();
            this.buttonsettings = new System.Windows.Forms.Button();
            this.buttonabout = new System.Windows.Forms.Button();
            this.buttontasks = new System.Windows.Forms.Button();
            this.buttonbuilder = new System.Windows.Forms.Button();
            this.buttonhome = new System.Windows.Forms.Button();
            this.panelchild = new System.Windows.Forms.Panel();
            this.updateUI = new System.Windows.Forms.Timer(this.components);
            this.paneltop.SuspendLayout();
            this.panelleft.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.SystemColors.Control;
            this.paneltop.Controls.Add(this.buttonside);
            this.paneltop.Controls.Add(this.labelDcRat);
            this.paneltop.Controls.Add(this.buttonmin);
            this.paneltop.Controls.Add(this.buttonmax);
            this.paneltop.Controls.Add(this.buttonclose);
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.Name = "paneltop";
            this.paneltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltop_MouseDown);
            // 
            // buttonside
            // 
            this.buttonside.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.buttonside, "buttonside");
            this.buttonside.FlatAppearance.BorderSize = 0;
            this.buttonside.Image = global::DcRat.Properties.Resources.side_dark;
            this.buttonside.Name = "buttonside";
            this.buttonside.UseVisualStyleBackColor = false;
            this.buttonside.Click += new System.EventHandler(this.buttonside_Click);
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
            this.buttonmin.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonmin.FlatAppearance.BorderSize = 0;
            this.buttonmin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonmin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
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
            this.buttonmax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
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
            this.buttonclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.buttonclose.Image = global::DcRat.Properties.Resources.close_dark;
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // panelleft
            // 
            this.panelleft.BackColor = System.Drawing.SystemColors.Control;
            this.panelleft.Controls.Add(this.panelside);
            this.panelleft.Controls.Add(this.buttonsettings);
            this.panelleft.Controls.Add(this.buttonabout);
            this.panelleft.Controls.Add(this.buttontasks);
            this.panelleft.Controls.Add(this.buttonbuilder);
            this.panelleft.Controls.Add(this.buttonhome);
            resources.ApplyResources(this.panelleft, "panelleft");
            this.panelleft.Name = "panelleft";
            // 
            // panelside
            // 
            this.panelside.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.panelside, "panelside");
            this.panelside.Name = "panelside";
            // 
            // buttonsettings
            // 
            resources.ApplyResources(this.buttonsettings, "buttonsettings");
            this.buttonsettings.BackColor = System.Drawing.SystemColors.Control;
            this.buttonsettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonsettings.FlatAppearance.BorderSize = 0;
            this.buttonsettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonsettings.Image = global::DcRat.Properties.Resources.setting_dark;
            this.buttonsettings.Name = "buttonsettings";
            this.buttonsettings.UseVisualStyleBackColor = false;
            this.buttonsettings.Click += new System.EventHandler(this.buttonsettings_Click);
            // 
            // buttonabout
            // 
            resources.ApplyResources(this.buttonabout, "buttonabout");
            this.buttonabout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonabout.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonabout.FlatAppearance.BorderSize = 0;
            this.buttonabout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonabout.Image = global::DcRat.Properties.Resources.about_dark;
            this.buttonabout.Name = "buttonabout";
            this.buttonabout.UseVisualStyleBackColor = false;
            this.buttonabout.Click += new System.EventHandler(this.buttonabout_Click);
            // 
            // buttontasks
            // 
            resources.ApplyResources(this.buttontasks, "buttontasks");
            this.buttontasks.BackColor = System.Drawing.SystemColors.Control;
            this.buttontasks.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttontasks.FlatAppearance.BorderSize = 0;
            this.buttontasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttontasks.Image = global::DcRat.Properties.Resources.task_dark;
            this.buttontasks.Name = "buttontasks";
            this.buttontasks.UseVisualStyleBackColor = false;
            this.buttontasks.Click += new System.EventHandler(this.buttontasks_Click);
            // 
            // buttonbuilder
            // 
            resources.ApplyResources(this.buttonbuilder, "buttonbuilder");
            this.buttonbuilder.BackColor = System.Drawing.SystemColors.Control;
            this.buttonbuilder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonbuilder.FlatAppearance.BorderSize = 0;
            this.buttonbuilder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonbuilder.Image = global::DcRat.Properties.Resources.builder_dark;
            this.buttonbuilder.Name = "buttonbuilder";
            this.buttonbuilder.UseVisualStyleBackColor = false;
            this.buttonbuilder.Click += new System.EventHandler(this.buttonbuilder_Click);
            // 
            // buttonhome
            // 
            resources.ApplyResources(this.buttonhome, "buttonhome");
            this.buttonhome.BackColor = System.Drawing.SystemColors.Control;
            this.buttonhome.FlatAppearance.BorderSize = 0;
            this.buttonhome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.buttonhome.Image = global::DcRat.Properties.Resources.home_dark;
            this.buttonhome.Name = "buttonhome";
            this.buttonhome.UseVisualStyleBackColor = false;
            this.buttonhome.Click += new System.EventHandler(this.buttonhome_Click);
            // 
            // panelchild
            // 
            resources.ApplyResources(this.panelchild, "panelchild");
            this.panelchild.Name = "panelchild";
            // 
            // updateUI
            // 
            this.updateUI.Enabled = true;
            this.updateUI.Interval = 500;
            this.updateUI.Tick += new System.EventHandler(this.updateUI_Tick);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelchild);
            this.Controls.Add(this.panelleft);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Opacity = 0.97D;
            this.paneltop.ResumeLayout(false);
            this.panelleft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel paneltop;
        private Button buttonclose;
        private Panel panelleft;
        private Panel panelchild;
        private Button buttonhome;
        private Button buttonsettings;
        private Button buttonabout;
        private Button buttontasks;
        private Button buttonbuilder;
        private Panel panelside;
        private Label labelDcRat;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonside;
        private Timer updateUI;
    }
}

