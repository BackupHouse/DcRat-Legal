
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.singleForms
{
    partial class singleFormProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormProcess));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.listViewprocess = new System.Windows.Forms.ListView();
            this.columnHeadername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderparentprocessid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderimagetype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderifclr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderowner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderpagefileusage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadervirtualsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderworkingsetsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadersessionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderpriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadercompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripprocess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.paneltop.SuspendLayout();
            this.contextMenuStripprocess.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.Controls.Add(this.labelDcRat);
            this.paneltop.Controls.Add(this.buttonmin);
            this.paneltop.Controls.Add(this.buttonmax);
            this.paneltop.Controls.Add(this.buttonclose);
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.ForeColor = System.Drawing.SystemColors.Desktop;
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
            // listViewprocess
            // 
            this.listViewprocess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeadername,
            this.columnHeaderid,
            this.columnHeaderparentprocessid,
            this.columnHeaderimagetype,
            this.columnHeaderifclr,
            this.columnHeaderowner,
            this.columnHeaderpagefileusage,
            this.columnHeadervirtualsize,
            this.columnHeaderworkingsetsize,
            this.columnHeadersessionId,
            this.columnHeaderpriority,
            this.columnHeaderdescription,
            this.columnHeadercompany});
            this.listViewprocess.ContextMenuStrip = this.contextMenuStripprocess;
            resources.ApplyResources(this.listViewprocess, "listViewprocess");
            this.listViewprocess.FullRowSelect = true;
            this.listViewprocess.HideSelection = false;
            this.listViewprocess.Name = "listViewprocess";
            this.listViewprocess.OwnerDraw = true;
            this.listViewprocess.ShowItemToolTips = true;
            this.listViewprocess.SmallImageList = this.imageList;
            this.listViewprocess.UseCompatibleStateImageBehavior = false;
            this.listViewprocess.View = System.Windows.Forms.View.Details;
            this.listViewprocess.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewprocess_ColumnClick);
            this.listViewprocess.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewprocess_DrawColumnHeader);
            this.listViewprocess.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewprocess_DrawItem);
            // 
            // columnHeadername
            // 
            resources.ApplyResources(this.columnHeadername, "columnHeadername");
            // 
            // columnHeaderid
            // 
            resources.ApplyResources(this.columnHeaderid, "columnHeaderid");
            // 
            // columnHeaderparentprocessid
            // 
            resources.ApplyResources(this.columnHeaderparentprocessid, "columnHeaderparentprocessid");
            // 
            // columnHeaderimagetype
            // 
            resources.ApplyResources(this.columnHeaderimagetype, "columnHeaderimagetype");
            // 
            // columnHeaderifclr
            // 
            resources.ApplyResources(this.columnHeaderifclr, "columnHeaderifclr");
            // 
            // columnHeaderowner
            // 
            resources.ApplyResources(this.columnHeaderowner, "columnHeaderowner");
            // 
            // columnHeaderpagefileusage
            // 
            resources.ApplyResources(this.columnHeaderpagefileusage, "columnHeaderpagefileusage");
            // 
            // columnHeadervirtualsize
            // 
            resources.ApplyResources(this.columnHeadervirtualsize, "columnHeadervirtualsize");
            // 
            // columnHeaderworkingsetsize
            // 
            resources.ApplyResources(this.columnHeaderworkingsetsize, "columnHeaderworkingsetsize");
            // 
            // columnHeadersessionId
            // 
            resources.ApplyResources(this.columnHeadersessionId, "columnHeadersessionId");
            // 
            // columnHeaderpriority
            // 
            resources.ApplyResources(this.columnHeaderpriority, "columnHeaderpriority");
            // 
            // columnHeaderdescription
            // 
            resources.ApplyResources(this.columnHeaderdescription, "columnHeaderdescription");
            // 
            // columnHeadercompany
            // 
            resources.ApplyResources(this.columnHeadercompany, "columnHeadercompany");
            // 
            // contextMenuStripprocess
            // 
            resources.ApplyResources(this.contextMenuStripprocess, "contextMenuStripprocess");
            this.contextMenuStripprocess.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripprocess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.createDumpToolStripMenuItem});
            this.contextMenuStripprocess.Name = "contextMenuStrip1";
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
            // createDumpToolStripMenuItem
            // 
            resources.ApplyResources(this.createDumpToolStripMenuItem, "createDumpToolStripMenuItem");
            this.createDumpToolStripMenuItem.Name = "createDumpToolStripMenuItem";
            this.createDumpToolStripMenuItem.Click += new System.EventHandler(this.createDumpToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList, "imageList");
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // singleFormProcess
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewprocess);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singleFormProcess";
            this.Load += new System.EventHandler(this.singleFormProcess_Load);
            this.paneltop.ResumeLayout(false);
            this.contextMenuStripprocess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel paneltop;
        private Label labelDcRat;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonclose;
        private ColumnHeader columnHeadername;
        private ColumnHeader columnHeaderid;
        private ColumnHeader columnHeaderparentprocessid;
        private ColumnHeader columnHeaderpagefileusage;
        private ColumnHeader columnHeaderdescription;
        private ColumnHeader columnHeadercompany;
        private ContextMenuStrip contextMenuStripprocess;
        private ToolStripMenuItem killToolStripMenuItem;
        private ToolStripMenuItem createDumpToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        public ListView listViewprocess;
        public ImageList imageList;
        private ColumnHeader columnHeadervirtualsize;
        private ColumnHeader columnHeaderworkingsetsize;
        private ColumnHeader columnHeadersessionId;
        private ColumnHeader columnHeaderpriority;
        private ColumnHeader columnHeaderimagetype;
        private ColumnHeader columnHeaderifclr;
        private ColumnHeader columnHeaderowner;
    }
}