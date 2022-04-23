
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.ChildForms
{
    partial class childFormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(childFormHome));
            this.splitContainerHome = new System.Windows.Forms.SplitContainer();
            this.listViewHome = new System.Windows.Forms.ListView();
            this.columnHeaderip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderaddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadergroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderhwid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderuser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadercamera = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderinstall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderav = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderactive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codedomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netstatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListicon = new System.Windows.Forms.ImageList(this.components);
            this.imageListblank = new System.Windows.Forms.ImageList(this.components);
            this.richTextBoxlog = new System.Windows.Forms.RichTextBox();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtoncmd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonpowershell = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonscreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtoncamera = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonfile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonprocess = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonnetwork = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonicon = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtondetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonregedit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonkeylogger = new System.Windows.Forms.ToolStripButton();
            this.updateUI = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHome)).BeginInit();
            this.splitContainerHome.Panel1.SuspendLayout();
            this.splitContainerHome.Panel2.SuspendLayout();
            this.splitContainerHome.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHome
            // 
            resources.ApplyResources(this.splitContainerHome, "splitContainerHome");
            this.splitContainerHome.Name = "splitContainerHome";
            // 
            // splitContainerHome.Panel1
            // 
            this.splitContainerHome.Panel1.Controls.Add(this.listViewHome);
            // 
            // splitContainerHome.Panel2
            // 
            this.splitContainerHome.Panel2.Controls.Add(this.richTextBoxlog);
            // 
            // listViewHome
            // 
            this.listViewHome.BackColor = System.Drawing.SystemColors.Window;
            this.listViewHome.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderip,
            this.columnHeaderaddress,
            this.columnHeadergroup,
            this.columnHeaderhwid,
            this.columnHeaderuser,
            this.columnHeaderos,
            this.columnHeadercamera,
            this.columnHeaderinstall,
            this.columnHeaderav,
            this.columnHeaderactive});
            this.listViewHome.ContextMenuStrip = this.contextMenuStripMain;
            resources.ApplyResources(this.listViewHome, "listViewHome");
            this.listViewHome.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewHome.FullRowSelect = true;
            this.listViewHome.HideSelection = false;
            this.listViewHome.LargeImageList = this.imageListicon;
            this.listViewHome.MultiSelect = false;
            this.listViewHome.Name = "listViewHome";
            this.listViewHome.OwnerDraw = true;
            this.listViewHome.SmallImageList = this.imageListblank;
            this.listViewHome.UseCompatibleStateImageBehavior = false;
            this.listViewHome.View = System.Windows.Forms.View.Details;
            this.listViewHome.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewHome_ColumnClick);
            this.listViewHome.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewHome_DrawColumnHeader);
            this.listViewHome.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewHome_DrawItem);
            this.listViewHome.SelectedIndexChanged += new System.EventHandler(this.listViewHome_SelectedIndexChanged);
            this.listViewHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewHome_MouseDown);
            this.listViewHome.MouseLeave += new System.EventHandler(this.listViewHome_MouseLeave);
            this.listViewHome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewHome_MouseMove);
            // 
            // columnHeaderip
            // 
            resources.ApplyResources(this.columnHeaderip, "columnHeaderip");
            // 
            // columnHeaderaddress
            // 
            resources.ApplyResources(this.columnHeaderaddress, "columnHeaderaddress");
            // 
            // columnHeadergroup
            // 
            resources.ApplyResources(this.columnHeadergroup, "columnHeadergroup");
            // 
            // columnHeaderhwid
            // 
            resources.ApplyResources(this.columnHeaderhwid, "columnHeaderhwid");
            // 
            // columnHeaderuser
            // 
            resources.ApplyResources(this.columnHeaderuser, "columnHeaderuser");
            // 
            // columnHeaderos
            // 
            resources.ApplyResources(this.columnHeaderos, "columnHeaderos");
            // 
            // columnHeadercamera
            // 
            resources.ApplyResources(this.columnHeadercamera, "columnHeadercamera");
            // 
            // columnHeaderinstall
            // 
            resources.ApplyResources(this.columnHeaderinstall, "columnHeaderinstall");
            // 
            // columnHeaderav
            // 
            resources.ApplyResources(this.columnHeaderav, "columnHeaderav");
            // 
            // columnHeaderactive
            // 
            resources.ApplyResources(this.columnHeaderactive, "columnHeaderactive");
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.functionToolStripMenuItem,
            this.installOptionToolStripMenuItem,
            this.clientOptionToolStripMenuItem,
            this.systemOptionToolStripMenuItem,
            this.informationCollectionToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            resources.ApplyResources(this.contextMenuStripMain, "contextMenuStripMain");
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendFileToolStripMenuItem,
            this.lockScreenToolStripMenuItem,
            this.codedomToolStripMenuItem,
            this.messageBoxToolStripMenuItem,
            this.visitWebsiteToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            resources.ApplyResources(this.actionToolStripMenuItem, "actionToolStripMenuItem");
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromURLToolStripMenuItem,
            this.fromDiskToolStripMenuItem});
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            resources.ApplyResources(this.sendFileToolStripMenuItem, "sendFileToolStripMenuItem");
            // 
            // fromURLToolStripMenuItem
            // 
            this.fromURLToolStripMenuItem.Name = "fromURLToolStripMenuItem";
            resources.ApplyResources(this.fromURLToolStripMenuItem, "fromURLToolStripMenuItem");
            this.fromURLToolStripMenuItem.Click += new System.EventHandler(this.fromURLToolStripMenuItem_Click);
            // 
            // fromDiskToolStripMenuItem
            // 
            this.fromDiskToolStripMenuItem.Name = "fromDiskToolStripMenuItem";
            resources.ApplyResources(this.fromDiskToolStripMenuItem, "fromDiskToolStripMenuItem");
            this.fromDiskToolStripMenuItem.Click += new System.EventHandler(this.fromDiskToolStripMenuItem_Click);
            // 
            // lockScreenToolStripMenuItem
            // 
            this.lockScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockToolStripMenuItem,
            this.unlockToolStripMenuItem});
            this.lockScreenToolStripMenuItem.Name = "lockScreenToolStripMenuItem";
            resources.ApplyResources(this.lockScreenToolStripMenuItem, "lockScreenToolStripMenuItem");
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            resources.ApplyResources(this.lockToolStripMenuItem, "lockToolStripMenuItem");
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            resources.ApplyResources(this.unlockToolStripMenuItem, "unlockToolStripMenuItem");
            this.unlockToolStripMenuItem.Click += new System.EventHandler(this.unlockToolStripMenuItem_Click);
            // 
            // codedomToolStripMenuItem
            // 
            this.codedomToolStripMenuItem.Name = "codedomToolStripMenuItem";
            resources.ApplyResources(this.codedomToolStripMenuItem, "codedomToolStripMenuItem");
            this.codedomToolStripMenuItem.Click += new System.EventHandler(this.codedomToolStripMenuItem_Click);
            // 
            // messageBoxToolStripMenuItem
            // 
            this.messageBoxToolStripMenuItem.Name = "messageBoxToolStripMenuItem";
            resources.ApplyResources(this.messageBoxToolStripMenuItem, "messageBoxToolStripMenuItem");
            this.messageBoxToolStripMenuItem.Click += new System.EventHandler(this.messageBoxToolStripMenuItem_Click);
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visitWebsiteToolStripMenuItem, "visitWebsiteToolStripMenuItem");
            this.visitWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebsiteToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMDToolStripMenuItem,
            this.powershellToolStripMenuItem,
            this.desktopToolStripMenuItem,
            this.webcamToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem,
            this.netstatToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.registryToolStripMenuItem,
            this.voiceToolStripMenuItem,
            this.keyloggerToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            resources.ApplyResources(this.functionToolStripMenuItem, "functionToolStripMenuItem");
            // 
            // cMDToolStripMenuItem
            // 
            this.cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
            resources.ApplyResources(this.cMDToolStripMenuItem, "cMDToolStripMenuItem");
            this.cMDToolStripMenuItem.Click += new System.EventHandler(this.cMDToolStripMenuItem_Click);
            // 
            // powershellToolStripMenuItem
            // 
            this.powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
            resources.ApplyResources(this.powershellToolStripMenuItem, "powershellToolStripMenuItem");
            this.powershellToolStripMenuItem.Click += new System.EventHandler(this.powershellToolStripMenuItem_Click);
            // 
            // desktopToolStripMenuItem
            // 
            this.desktopToolStripMenuItem.Name = "desktopToolStripMenuItem";
            resources.ApplyResources(this.desktopToolStripMenuItem, "desktopToolStripMenuItem");
            this.desktopToolStripMenuItem.Click += new System.EventHandler(this.desktopToolStripMenuItem_Click);
            // 
            // webcamToolStripMenuItem
            // 
            this.webcamToolStripMenuItem.Name = "webcamToolStripMenuItem";
            resources.ApplyResources(this.webcamToolStripMenuItem, "webcamToolStripMenuItem");
            this.webcamToolStripMenuItem.Click += new System.EventHandler(this.webcamToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            resources.ApplyResources(this.processToolStripMenuItem, "processToolStripMenuItem");
            this.processToolStripMenuItem.Click += new System.EventHandler(this.processToolStripMenuItem_Click);
            // 
            // netstatToolStripMenuItem
            // 
            this.netstatToolStripMenuItem.Name = "netstatToolStripMenuItem";
            resources.ApplyResources(this.netstatToolStripMenuItem, "netstatToolStripMenuItem");
            this.netstatToolStripMenuItem.Click += new System.EventHandler(this.netstatToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            resources.ApplyResources(this.deviceToolStripMenuItem, "deviceToolStripMenuItem");
            this.deviceToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // registryToolStripMenuItem
            // 
            this.registryToolStripMenuItem.Name = "registryToolStripMenuItem";
            resources.ApplyResources(this.registryToolStripMenuItem, "registryToolStripMenuItem");
            this.registryToolStripMenuItem.Click += new System.EventHandler(this.registryToolStripMenuItem_Click);
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            resources.ApplyResources(this.voiceToolStripMenuItem, "voiceToolStripMenuItem");
            this.voiceToolStripMenuItem.Click += new System.EventHandler(this.voiceToolStripMenuItem_Click);
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            resources.ApplyResources(this.keyloggerToolStripMenuItem, "keyloggerToolStripMenuItem");
            this.keyloggerToolStripMenuItem.Click += new System.EventHandler(this.keyloggerToolStripMenuItem_Click);
            // 
            // installOptionToolStripMenuItem
            // 
            this.installOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.uninstallToolStripMenuItem});
            this.installOptionToolStripMenuItem.Name = "installOptionToolStripMenuItem";
            resources.ApplyResources(this.installOptionToolStripMenuItem, "installOptionToolStripMenuItem");
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            resources.ApplyResources(this.installToolStripMenuItem, "installToolStripMenuItem");
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            resources.ApplyResources(this.uninstallToolStripMenuItem, "uninstallToolStripMenuItem");
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // clientOptionToolStripMenuItem
            // 
            this.clientOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.disconnnectToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteSelfToolStripMenuItem});
            this.clientOptionToolStripMenuItem.Name = "clientOptionToolStripMenuItem";
            resources.ApplyResources(this.clientOptionToolStripMenuItem, "clientOptionToolStripMenuItem");
            // 
            // noteToolStripMenuItem
            // 
            this.noteToolStripMenuItem.Name = "noteToolStripMenuItem";
            resources.ApplyResources(this.noteToolStripMenuItem, "noteToolStripMenuItem");
            this.noteToolStripMenuItem.Click += new System.EventHandler(this.noteToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            resources.ApplyResources(this.stopToolStripMenuItem, "stopToolStripMenuItem");
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // disconnnectToolStripMenuItem
            // 
            this.disconnnectToolStripMenuItem.Name = "disconnnectToolStripMenuItem";
            resources.ApplyResources(this.disconnnectToolStripMenuItem, "disconnnectToolStripMenuItem");
            this.disconnnectToolStripMenuItem.Click += new System.EventHandler(this.disconnnectToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            resources.ApplyResources(this.restartToolStripMenuItem, "restartToolStripMenuItem");
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            resources.ApplyResources(this.updateToolStripMenuItem, "updateToolStripMenuItem");
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteSelfToolStripMenuItem
            // 
            this.deleteSelfToolStripMenuItem.Name = "deleteSelfToolStripMenuItem";
            resources.ApplyResources(this.deleteSelfToolStripMenuItem, "deleteSelfToolStripMenuItem");
            this.deleteSelfToolStripMenuItem.Click += new System.EventHandler(this.deleteSelfToolStripMenuItem_Click);
            // 
            // systemOptionToolStripMenuItem
            // 
            this.systemOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reBootToolStripMenuItem,
            this.powerOffToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.systemOptionToolStripMenuItem.Name = "systemOptionToolStripMenuItem";
            resources.ApplyResources(this.systemOptionToolStripMenuItem, "systemOptionToolStripMenuItem");
            // 
            // reBootToolStripMenuItem
            // 
            this.reBootToolStripMenuItem.Name = "reBootToolStripMenuItem";
            resources.ApplyResources(this.reBootToolStripMenuItem, "reBootToolStripMenuItem");
            this.reBootToolStripMenuItem.Click += new System.EventHandler(this.reBootToolStripMenuItem_Click);
            // 
            // powerOffToolStripMenuItem
            // 
            this.powerOffToolStripMenuItem.Name = "powerOffToolStripMenuItem";
            resources.ApplyResources(this.powerOffToolStripMenuItem, "powerOffToolStripMenuItem");
            this.powerOffToolStripMenuItem.Click += new System.EventHandler(this.powerOffToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            resources.ApplyResources(this.logOutToolStripMenuItem, "logOutToolStripMenuItem");
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // informationCollectionToolStripMenuItem
            // 
            this.informationCollectionToolStripMenuItem.Name = "informationCollectionToolStripMenuItem";
            resources.ApplyResources(this.informationCollectionToolStripMenuItem, "informationCollectionToolStripMenuItem");
            this.informationCollectionToolStripMenuItem.Click += new System.EventHandler(this.informationCollectionToolStripMenuItem_Click);
            // 
            // imageListicon
            // 
            this.imageListicon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListicon.ImageStream")));
            this.imageListicon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListicon.Images.SetKeyName(0, "sandgalss (1).png");
            // 
            // imageListblank
            // 
            this.imageListblank.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageListblank, "imageListblank");
            this.imageListblank.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // richTextBoxlog
            // 
            this.richTextBoxlog.BackColor = System.Drawing.SystemColors.Desktop;
            resources.ApplyResources(this.richTextBoxlog, "richTextBoxlog");
            this.richTextBoxlog.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxlog.Name = "richTextBoxlog";
            this.richTextBoxlog.TextChanged += new System.EventHandler(this.richTextBoxlog_TextChanged);
            // 
            // toolStripMain
            // 
            resources.ApplyResources(this.toolStripMain, "toolStripMain");
            this.toolStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtoncmd,
            this.toolStripButtonpowershell,
            this.toolStripButtonscreen,
            this.toolStripButtoncamera,
            this.toolStripButtonfile,
            this.toolStripButtonprocess,
            this.toolStripButtonnetwork,
            this.toolStripButtondevice,
            this.toolStripButtonicon,
            this.toolStripButtondetails,
            this.toolStripButtonregedit,
            this.toolStripButtonvoice,
            this.toolStripButtonkeylogger});
            this.toolStripMain.Name = "toolStripMain";
            // 
            // toolStripButtoncmd
            // 
            this.toolStripButtoncmd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtoncmd, "toolStripButtoncmd");
            this.toolStripButtoncmd.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtoncmd.Name = "toolStripButtoncmd";
            this.toolStripButtoncmd.Click += new System.EventHandler(this.toolStripButtoncmd_Click);
            // 
            // toolStripButtonpowershell
            // 
            this.toolStripButtonpowershell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonpowershell, "toolStripButtonpowershell");
            this.toolStripButtonpowershell.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtonpowershell.Name = "toolStripButtonpowershell";
            this.toolStripButtonpowershell.Click += new System.EventHandler(this.toolStripButtonpowershell_Click);
            // 
            // toolStripButtonscreen
            // 
            this.toolStripButtonscreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonscreen, "toolStripButtonscreen");
            this.toolStripButtonscreen.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtonscreen.Name = "toolStripButtonscreen";
            this.toolStripButtonscreen.Click += new System.EventHandler(this.toolStripButtonscreen_Click);
            // 
            // toolStripButtoncamera
            // 
            this.toolStripButtoncamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtoncamera, "toolStripButtoncamera");
            this.toolStripButtoncamera.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtoncamera.Name = "toolStripButtoncamera";
            this.toolStripButtoncamera.Click += new System.EventHandler(this.toolStripButtoncamera_Click);
            // 
            // toolStripButtonfile
            // 
            this.toolStripButtonfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonfile, "toolStripButtonfile");
            this.toolStripButtonfile.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtonfile.Name = "toolStripButtonfile";
            this.toolStripButtonfile.Click += new System.EventHandler(this.toolStripButtonfile_Click);
            // 
            // toolStripButtonprocess
            // 
            this.toolStripButtonprocess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonprocess, "toolStripButtonprocess");
            this.toolStripButtonprocess.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtonprocess.Name = "toolStripButtonprocess";
            this.toolStripButtonprocess.Click += new System.EventHandler(this.toolStripButtonprocess_Click);
            // 
            // toolStripButtonnetwork
            // 
            this.toolStripButtonnetwork.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonnetwork, "toolStripButtonnetwork");
            this.toolStripButtonnetwork.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtonnetwork.Name = "toolStripButtonnetwork";
            this.toolStripButtonnetwork.Click += new System.EventHandler(this.toolStripButtonnetwork_Click);
            // 
            // toolStripButtondevice
            // 
            this.toolStripButtondevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtondevice, "toolStripButtondevice");
            this.toolStripButtondevice.Image = global::DcRat.Properties.Resources.device_dark;
            this.toolStripButtondevice.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.toolStripButtondevice.Name = "toolStripButtondevice";
            this.toolStripButtondevice.Click += new System.EventHandler(this.toolStripButtondevice_Click);
            // 
            // toolStripButtonicon
            // 
            this.toolStripButtonicon.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonicon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonicon.Image = global::DcRat.Properties.Resources.iconlist_dark;
            resources.ApplyResources(this.toolStripButtonicon, "toolStripButtonicon");
            this.toolStripButtonicon.Name = "toolStripButtonicon";
            this.toolStripButtonicon.Click += new System.EventHandler(this.toolStripButtonicon_Click);
            // 
            // toolStripButtondetails
            // 
            this.toolStripButtondetails.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtondetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtondetails, "toolStripButtondetails");
            this.toolStripButtondetails.Image = global::DcRat.Properties.Resources.detaillist_dark;
            this.toolStripButtondetails.Name = "toolStripButtondetails";
            this.toolStripButtondetails.Click += new System.EventHandler(this.toolStripButtondetails_Click);
            // 
            // toolStripButtonregedit
            // 
            this.toolStripButtonregedit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonregedit.Image = global::DcRat.Properties.Resources.registry_dark;
            resources.ApplyResources(this.toolStripButtonregedit, "toolStripButtonregedit");
            this.toolStripButtonregedit.Name = "toolStripButtonregedit";
            this.toolStripButtonregedit.Click += new System.EventHandler(this.toolStripButtonregedit_Click);
            // 
            // toolStripButtonvoice
            // 
            this.toolStripButtonvoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonvoice, "toolStripButtonvoice");
            this.toolStripButtonvoice.Name = "toolStripButtonvoice";
            this.toolStripButtonvoice.Click += new System.EventHandler(this.toolStripButtonvoice_Click);
            // 
            // toolStripButtonkeylogger
            // 
            this.toolStripButtonkeylogger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonkeylogger, "toolStripButtonkeylogger");
            this.toolStripButtonkeylogger.Name = "toolStripButtonkeylogger";
            this.toolStripButtonkeylogger.Click += new System.EventHandler(this.toolStripButtonkeylogger_Click);
            // 
            // updateUI
            // 
            this.updateUI.Enabled = true;
            this.updateUI.Interval = 1000;
            this.updateUI.Tick += new System.EventHandler(this.updateUI_Tick);
            // 
            // childFormHome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHome);
            this.Controls.Add(this.toolStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "childFormHome";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.childFormHome_Load);
            this.splitContainerHome.Panel1.ResumeLayout(false);
            this.splitContainerHome.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHome)).EndInit();
            this.splitContainerHome.ResumeLayout(false);
            this.contextMenuStripMain.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStrip toolStripMain;
        private ToolStripButton toolStripButtoncmd;
        private ToolStripButton toolStripButtonpowershell;
        private ToolStripButton toolStripButtonscreen;
        private ToolStripButton toolStripButtoncamera;
        private ToolStripButton toolStripButtonfile;
        private ToolStripButton toolStripButtonprocess;
        private SplitContainer splitContainerHome;
        public ListView listViewHome;
        private ColumnHeader columnHeaderip;
        private ToolStripButton toolStripButtonnetwork;
        private ToolStripButton toolStripButtondevice;
        private ContextMenuStrip contextMenuStripMain;
        private Timer updateUI;
        private ImageList imageListblank;
        private ColumnHeader columnHeaderaddress;
        private ColumnHeader columnHeadergroup;
        private ColumnHeader columnHeaderhwid;
        private ColumnHeader columnHeaderuser;
        private ColumnHeader columnHeaderos;
        private ColumnHeader columnHeadercamera;
        private ColumnHeader columnHeaderinstall;
        private ColumnHeader columnHeaderav;
        public ColumnHeader columnHeaderactive;
        private ToolStripButton toolStripButtonicon;
        private ToolStripButton toolStripButtondetails;
        private ToolStripButton toolStripButtonregedit;
        private ToolStripButton toolStripButtonvoice;
        private ToolStripButton toolStripButtonkeylogger;
        public ImageList imageListicon;
        private ToolStripMenuItem actionToolStripMenuItem;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem clientOptionToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem systemOptionToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem disconnnectToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteSelfToolStripMenuItem;
        private ToolStripMenuItem reBootToolStripMenuItem;
        private ToolStripMenuItem powerOffToolStripMenuItem;
        private ToolStripMenuItem codedomToolStripMenuItem;
        private ToolStripMenuItem functionToolStripMenuItem;
        private ToolStripMenuItem cMDToolStripMenuItem;
        private ToolStripMenuItem powershellToolStripMenuItem;
        private ToolStripMenuItem desktopToolStripMenuItem;
        private ToolStripMenuItem webcamToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem processToolStripMenuItem;
        private ToolStripMenuItem netstatToolStripMenuItem;
        private ToolStripMenuItem deviceToolStripMenuItem;
        private ToolStripMenuItem registryToolStripMenuItem;
        private ToolStripMenuItem voiceToolStripMenuItem;
        private ToolStripMenuItem keyloggerToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem informationCollectionToolStripMenuItem;
        private ToolStripMenuItem fromURLToolStripMenuItem;
        private ToolStripMenuItem fromDiskToolStripMenuItem;
        private ToolStripMenuItem messageBoxToolStripMenuItem;
        private ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private ToolStripMenuItem installOptionToolStripMenuItem;
        private ToolStripMenuItem installToolStripMenuItem;
        private ToolStripMenuItem uninstallToolStripMenuItem;
        public RichTextBox richTextBoxlog;
        private ToolStripMenuItem noteToolStripMenuItem;
        private ToolStripMenuItem lockScreenToolStripMenuItem;
        private ToolStripMenuItem lockToolStripMenuItem;
        private ToolStripMenuItem unlockToolStripMenuItem;
    }
}