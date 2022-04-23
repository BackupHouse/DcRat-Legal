
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.singleForms
{
    partial class singleFormNetwork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormNetwork));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.listViewnetwork = new System.Windows.Forms.ListView();
            this.columnHeaderprotocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderpid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderlocaladdress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderremoteaddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderstate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paneltop.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
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
            // listViewnetwork
            // 
            this.listViewnetwork.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderprotocol,
            this.columnHeaderpid,
            this.columnHeadername,
            this.columnHeaderlocaladdress,
            this.columnHeaderremoteaddress,
            this.columnHeaderstate});
            this.listViewnetwork.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.listViewnetwork, "listViewnetwork");
            this.listViewnetwork.FullRowSelect = true;
            this.listViewnetwork.HideSelection = false;
            this.listViewnetwork.Name = "listViewnetwork";
            this.listViewnetwork.OwnerDraw = true;
            this.listViewnetwork.UseCompatibleStateImageBehavior = false;
            this.listViewnetwork.View = System.Windows.Forms.View.Details;
            this.listViewnetwork.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewnetwork_ColumnClick);
            this.listViewnetwork.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewnetwork_DrawColumnHeader);
            this.listViewnetwork.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewnetwork_DrawItem);
            // 
            // columnHeaderprotocol
            // 
            resources.ApplyResources(this.columnHeaderprotocol, "columnHeaderprotocol");
            // 
            // columnHeaderpid
            // 
            resources.ApplyResources(this.columnHeaderpid, "columnHeaderpid");
            // 
            // columnHeadername
            // 
            resources.ApplyResources(this.columnHeadername, "columnHeadername");
            // 
            // columnHeaderlocaladdress
            // 
            resources.ApplyResources(this.columnHeaderlocaladdress, "columnHeaderlocaladdress");
            // 
            // columnHeaderremoteaddress
            // 
            resources.ApplyResources(this.columnHeaderremoteaddress, "columnHeaderremoteaddress");
            // 
            // columnHeaderstate
            // 
            resources.ApplyResources(this.columnHeaderstate, "columnHeaderstate");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Image = global::DcRat.Properties.Resources.kill_dark;
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            resources.ApplyResources(this.killToolStripMenuItem, "killToolStripMenuItem");
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::DcRat.Properties.Resources.refreshprocess_dark;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // singleFormNetwork
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewnetwork);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singleFormNetwork";
            this.Load += new System.EventHandler(this.singleFormNetwork_Load);
            this.paneltop.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel paneltop;
        private Label labelDcRat;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonclose;
        private ColumnHeader columnHeaderpid;
        private ColumnHeader columnHeadername;
        private ColumnHeader columnHeaderlocaladdress;
        private ColumnHeader columnHeaderremoteaddress;
        private ColumnHeader columnHeaderstate;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem killToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        public ListView listViewnetwork;
        private ColumnHeader columnHeaderprotocol;
    }
}