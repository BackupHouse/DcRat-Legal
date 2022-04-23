
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.singleForms
{
    partial class singleFormFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormFile));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.toolStripfile = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonback = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxaddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtongoto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonrefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonjump = new System.Windows.Forms.ToolStripDropDownButton();
            this.appdataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.system32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonnew = new System.Windows.Forms.ToolStripDropDownButton();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonupload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripButton();
            this.listViewfile = new System.Windows.Forms.ListView();
            this.columnHeadername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadertime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadertype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadersize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zip7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unzipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListlarge = new System.Windows.Forms.ImageList(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelcount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelalert = new System.Windows.Forms.ToolStripLabel();
            this.paneltop.SuspendLayout();
            this.toolStripfile.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
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
            // toolStripfile
            // 
            resources.ApplyResources(this.toolStripfile, "toolStripfile");
            this.toolStripfile.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripfile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonback,
            this.toolStripTextBoxaddress,
            this.toolStripButtongoto,
            this.toolStripSeparator1,
            this.toolStripButtonrefresh,
            this.toolStripSeparator2,
            this.toolStripDropDownButtonjump,
            this.toolStripButtonnew,
            this.toolStripSeparator3,
            this.toolStripButtonupload,
            this.toolStripButtondownload,
            this.toolStripSplitButton1});
            this.toolStripfile.Name = "toolStripfile";
            // 
            // toolStripButtonback
            // 
            this.toolStripButtonback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonback.Image = global::DcRat.Properties.Resources.back_dark;
            resources.ApplyResources(this.toolStripButtonback, "toolStripButtonback");
            this.toolStripButtonback.Name = "toolStripButtonback";
            this.toolStripButtonback.Click += new System.EventHandler(this.toolStripButtonback_Click);
            // 
            // toolStripTextBoxaddress
            // 
            resources.ApplyResources(this.toolStripTextBoxaddress, "toolStripTextBoxaddress");
            this.toolStripTextBoxaddress.Name = "toolStripTextBoxaddress";
            // 
            // toolStripButtongoto
            // 
            this.toolStripButtongoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtongoto.Image = global::DcRat.Properties.Resources.goto_dark;
            resources.ApplyResources(this.toolStripButtongoto, "toolStripButtongoto");
            this.toolStripButtongoto.Name = "toolStripButtongoto";
            this.toolStripButtongoto.Click += new System.EventHandler(this.toolStripButtongoto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButtonrefresh
            // 
            this.toolStripButtonrefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonrefresh, "toolStripButtonrefresh");
            this.toolStripButtonrefresh.Name = "toolStripButtonrefresh";
            this.toolStripButtonrefresh.Click += new System.EventHandler(this.toolStripButtonrefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripDropDownButtonjump
            // 
            this.toolStripDropDownButtonjump.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appdataToolStripMenuItem,
            this.desktopToolStripMenuItem,
            this.system32ToolStripMenuItem,
            this.tempToolStripMenuItem,
            this.userToolStripMenuItem});
            this.toolStripDropDownButtonjump.Image = global::DcRat.Properties.Resources.jump_dark;
            resources.ApplyResources(this.toolStripDropDownButtonjump, "toolStripDropDownButtonjump");
            this.toolStripDropDownButtonjump.Name = "toolStripDropDownButtonjump";
            // 
            // appdataToolStripMenuItem
            // 
            resources.ApplyResources(this.appdataToolStripMenuItem, "appdataToolStripMenuItem");
            this.appdataToolStripMenuItem.Name = "appdataToolStripMenuItem";
            this.appdataToolStripMenuItem.Click += new System.EventHandler(this.appdataToolStripMenuItem_Click);
            // 
            // desktopToolStripMenuItem
            // 
            resources.ApplyResources(this.desktopToolStripMenuItem, "desktopToolStripMenuItem");
            this.desktopToolStripMenuItem.Name = "desktopToolStripMenuItem";
            this.desktopToolStripMenuItem.Click += new System.EventHandler(this.desktopToolStripMenuItem_Click);
            // 
            // system32ToolStripMenuItem
            // 
            resources.ApplyResources(this.system32ToolStripMenuItem, "system32ToolStripMenuItem");
            this.system32ToolStripMenuItem.Name = "system32ToolStripMenuItem";
            this.system32ToolStripMenuItem.Click += new System.EventHandler(this.system32ToolStripMenuItem_Click);
            // 
            // tempToolStripMenuItem
            // 
            resources.ApplyResources(this.tempToolStripMenuItem, "tempToolStripMenuItem");
            this.tempToolStripMenuItem.Name = "tempToolStripMenuItem";
            this.tempToolStripMenuItem.Click += new System.EventHandler(this.tempToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            resources.ApplyResources(this.userToolStripMenuItem, "userToolStripMenuItem");
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // toolStripButtonnew
            // 
            this.toolStripButtonnew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.textToolStripMenuItem});
            this.toolStripButtonnew.Image = global::DcRat.Properties.Resources.newfolder_dark;
            resources.ApplyResources(this.toolStripButtonnew, "toolStripButtonnew");
            this.toolStripButtonnew.Name = "toolStripButtonnew";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Image = global::DcRat.Properties.Resources.newfolder_dark;
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            resources.ApplyResources(this.folderToolStripMenuItem, "folderToolStripMenuItem");
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Image = global::DcRat.Properties.Resources.newfile_dark;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtonupload
            // 
            resources.ApplyResources(this.toolStripButtonupload, "toolStripButtonupload");
            this.toolStripButtonupload.Name = "toolStripButtonupload";
            this.toolStripButtonupload.Click += new System.EventHandler(this.toolStripButtonupload_Click);
            // 
            // toolStripButtondownload
            // 
            resources.ApplyResources(this.toolStripButtondownload, "toolStripButtondownload");
            this.toolStripButtondownload.Name = "toolStripButtondownload";
            this.toolStripButtondownload.Click += new System.EventHandler(this.toolStripButtondownload_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = global::DcRat.Properties.Resources.switch_dark;
            resources.ApplyResources(this.toolStripSplitButton1, "toolStripSplitButton1");
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Click += new System.EventHandler(this.toolStripSplitButton1_Click);
            // 
            // listViewfile
            // 
            this.listViewfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeadername,
            this.columnHeadertime,
            this.columnHeadertype,
            this.columnHeadersize});
            this.listViewfile.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.listViewfile, "listViewfile");
            this.listViewfile.FullRowSelect = true;
            this.listViewfile.HideSelection = false;
            this.listViewfile.LargeImageList = this.imageListlarge;
            this.listViewfile.Name = "listViewfile";
            this.listViewfile.OwnerDraw = true;
            this.listViewfile.ShowItemToolTips = true;
            this.listViewfile.SmallImageList = this.imageList;
            this.listViewfile.UseCompatibleStateImageBehavior = false;
            this.listViewfile.View = System.Windows.Forms.View.Details;
            this.listViewfile.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewfile_DrawColumnHeader);
            this.listViewfile.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewfile_DrawItem);
            this.listViewfile.DoubleClick += new System.EventHandler(this.listViewfile_DoubleClick);
            // 
            // columnHeadername
            // 
            resources.ApplyResources(this.columnHeadername, "columnHeadername");
            // 
            // columnHeadertime
            // 
            resources.ApplyResources(this.columnHeadertime, "columnHeadertime");
            // 
            // columnHeadertype
            // 
            resources.ApplyResources(this.columnHeadertype, "columnHeadertype");
            // 
            // columnHeadersize
            // 
            resources.ApplyResources(this.columnHeadersize, "columnHeadersize");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openWithToolStripMenuItem,
            this.zip7ToolStripMenuItem,
            this.toolStripSeparator4,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::DcRat.Properties.Resources.open_dark;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openWithToolStripMenuItem
            // 
            this.openWithToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiddenToolStripMenuItem,
            this.createNewDesktopToolStripMenuItem});
            this.openWithToolStripMenuItem.Image = global::DcRat.Properties.Resources.open_dark;
            this.openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            resources.ApplyResources(this.openWithToolStripMenuItem, "openWithToolStripMenuItem");
            // 
            // hiddenToolStripMenuItem
            // 
            this.hiddenToolStripMenuItem.Image = global::DcRat.Properties.Resources.open_dark;
            this.hiddenToolStripMenuItem.Name = "hiddenToolStripMenuItem";
            resources.ApplyResources(this.hiddenToolStripMenuItem, "hiddenToolStripMenuItem");
            this.hiddenToolStripMenuItem.Click += new System.EventHandler(this.hiddenToolStripMenuItem_Click);
            // 
            // createNewDesktopToolStripMenuItem
            // 
            this.createNewDesktopToolStripMenuItem.Image = global::DcRat.Properties.Resources.open_dark;
            this.createNewDesktopToolStripMenuItem.Name = "createNewDesktopToolStripMenuItem";
            resources.ApplyResources(this.createNewDesktopToolStripMenuItem, "createNewDesktopToolStripMenuItem");
            this.createNewDesktopToolStripMenuItem.Click += new System.EventHandler(this.createNewDesktopToolStripMenuItem_Click);
            // 
            // zip7ToolStripMenuItem
            // 
            this.zip7ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.zipToolStripMenuItem,
            this.unzipToolStripMenuItem});
            resources.ApplyResources(this.zip7ToolStripMenuItem, "zip7ToolStripMenuItem");
            this.zip7ToolStripMenuItem.Name = "zip7ToolStripMenuItem";
            // 
            // installToolStripMenuItem
            // 
            resources.ApplyResources(this.installToolStripMenuItem, "installToolStripMenuItem");
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // zipToolStripMenuItem
            // 
            resources.ApplyResources(this.zipToolStripMenuItem, "zipToolStripMenuItem");
            this.zipToolStripMenuItem.Name = "zipToolStripMenuItem";
            this.zipToolStripMenuItem.Click += new System.EventHandler(this.zipToolStripMenuItem_Click);
            // 
            // unzipToolStripMenuItem
            // 
            resources.ApplyResources(this.unzipToolStripMenuItem, "unzipToolStripMenuItem");
            this.unzipToolStripMenuItem.Name = "unzipToolStripMenuItem";
            this.unzipToolStripMenuItem.Click += new System.EventHandler(this.unzipToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // copyToolStripMenuItem
            // 
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DcRat.Properties.Resources.paste_dark;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DcRat.Properties.Resources.delete_dark;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::DcRat.Properties.Resources.rename_dark;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            resources.ApplyResources(this.renameToolStripMenuItem, "renameToolStripMenuItem");
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // imageListlarge
            // 
            this.imageListlarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageListlarge, "imageListlarge");
            this.imageListlarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "HDD.png");
            this.imageList.Images.SetKeyName(2, "USB.png");
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelcount,
            this.toolStripLabelalert});
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripLabelcount
            // 
            this.toolStripLabelcount.Name = "toolStripLabelcount";
            resources.ApplyResources(this.toolStripLabelcount, "toolStripLabelcount");
            // 
            // toolStripLabelalert
            // 
            this.toolStripLabelalert.Name = "toolStripLabelalert";
            resources.ApplyResources(this.toolStripLabelalert, "toolStripLabelalert");
            // 
            // singleFormFile
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.listViewfile);
            this.Controls.Add(this.toolStripfile);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singleFormFile";
            this.paneltop.ResumeLayout(false);
            this.toolStripfile.ResumeLayout(false);
            this.toolStripfile.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel paneltop;
        private Label labelDcRat;
        private Button buttonmin;
        private Button buttonmax;
        private Button buttonclose;
        private ToolStrip toolStripfile;
        private ToolStripButton toolStripButtonback;
        private ToolStripButton toolStripButtongoto;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonrefresh;
        private ToolStripDropDownButton toolStripButtonnew;
        private ToolStripMenuItem folderToolStripMenuItem;
        private ToolStripMenuItem textToolStripMenuItem;
        private ToolStripButton toolStripButtonupload;
        private ToolStripButton toolStripButtondownload;
        private ToolStripDropDownButton toolStripDropDownButtonjump;
        private ToolStripMenuItem appdataToolStripMenuItem;
        private ToolStripMenuItem desktopToolStripMenuItem;
        private ToolStripMenuItem system32ToolStripMenuItem;
        private ToolStripMenuItem tempToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ColumnHeader columnHeadername;
        private ColumnHeader columnHeadertime;
        private ColumnHeader columnHeadertype;
        private ColumnHeader columnHeadersize;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openWithToolStripMenuItem;
        private ToolStripMenuItem hiddenToolStripMenuItem;
        private ToolStripMenuItem createNewDesktopToolStripMenuItem;
        private ToolStripMenuItem zip7ToolStripMenuItem;
        private ToolStripMenuItem zipToolStripMenuItem;
        private ToolStripMenuItem unzipToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStrip toolStrip;
        private ToolStripMenuItem installToolStripMenuItem;
        public ToolStripTextBox toolStripTextBoxaddress;
        public ListView listViewfile;
        public ImageList imageList;
        public ToolStripLabel toolStripLabelalert;
        public ToolStripLabel toolStripLabelcount;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripButton toolStripSplitButton1;
        public ImageList imageListlarge;
    }
}