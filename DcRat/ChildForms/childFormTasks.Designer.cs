
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.ChildForms
{
    partial class childFormTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(childFormTasks));
            this.listViewtasks = new System.Windows.Forms.ListView();
            this.columnHeadertaskname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderstatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadertrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListblank = new System.Windows.Forms.ImageList(this.components);
            this.updateUI = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewtasks
            // 
            resources.ApplyResources(this.listViewtasks, "listViewtasks");
            this.listViewtasks.BackColor = System.Drawing.SystemColors.Window;
            this.listViewtasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeadertaskname,
            this.columnHeaderstatus,
            this.columnHeadertrigger});
            this.listViewtasks.ContextMenuStrip = this.contextMenuStripTasks;
            this.listViewtasks.FullRowSelect = true;
            this.listViewtasks.HideSelection = false;
            this.listViewtasks.MultiSelect = false;
            this.listViewtasks.Name = "listViewtasks";
            this.listViewtasks.OwnerDraw = true;
            this.listViewtasks.SmallImageList = this.imageListblank;
            this.listViewtasks.UseCompatibleStateImageBehavior = false;
            this.listViewtasks.View = System.Windows.Forms.View.Details;
            this.listViewtasks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewtasks_ColumnClick);
            this.listViewtasks.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewtasks_DrawColumnHeader);
            this.listViewtasks.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewtasks_DrawItem);
            this.listViewtasks.SelectedIndexChanged += new System.EventHandler(this.listViewtasks_SelectedIndexChanged);
            this.listViewtasks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewtasks_MouseDown);
            this.listViewtasks.MouseLeave += new System.EventHandler(this.listViewtasks_MouseLeave);
            this.listViewtasks.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewtasks_MouseMove);
            // 
            // columnHeadertaskname
            // 
            resources.ApplyResources(this.columnHeadertaskname, "columnHeadertaskname");
            // 
            // columnHeaderstatus
            // 
            resources.ApplyResources(this.columnHeaderstatus, "columnHeaderstatus");
            // 
            // columnHeadertrigger
            // 
            resources.ApplyResources(this.columnHeadertrigger, "columnHeadertrigger");
            // 
            // contextMenuStripTasks
            // 
            resources.ApplyResources(this.contextMenuStripTasks, "contextMenuStripTasks");
            this.contextMenuStripTasks.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.changeStatusToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStripTasks.Name = "contextMenuStripTasks";
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Image = global::DcRat.Properties.Resources.add_dark;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Image = global::DcRat.Properties.Resources.refresh_dark;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // changeStatusToolStripMenuItem
            // 
            resources.ApplyResources(this.changeStatusToolStripMenuItem, "changeStatusToolStripMenuItem");
            this.changeStatusToolStripMenuItem.Image = global::DcRat.Properties.Resources.change_dark;
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Image = global::DcRat.Properties.Resources.delete_dark;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // imageListblank
            // 
            this.imageListblank.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageListblank, "imageListblank");
            this.imageListblank.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // updateUI
            // 
            this.updateUI.Enabled = true;
            this.updateUI.Interval = 1000;
            this.updateUI.Tick += new System.EventHandler(this.updateUI_Tick);
            // 
            // childFormTasks
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewtasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "childFormTasks";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.childFormTasks_Load);
            this.contextMenuStripTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ColumnHeader columnHeadertaskname;
        private ColumnHeader columnHeaderstatus;
        private ColumnHeader columnHeadertrigger;
        private ImageList imageListblank;
        private ContextMenuStrip contextMenuStripTasks;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Timer updateUI;
        private ToolStripMenuItem changeStatusToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        public ListView listViewtasks;
    }
}