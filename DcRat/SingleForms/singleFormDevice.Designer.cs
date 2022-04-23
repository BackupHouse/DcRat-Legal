
using System.ComponentModel;
using System.Windows.Forms;

namespace DcRat.singleForms
{
    partial class singleFormDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleFormDevice));
            this.paneltop = new System.Windows.Forms.Panel();
            this.labelDcRat = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.buttonmax = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listViewDevice = new System.Windows.Forms.ListView();
            this.columnHeadername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdeviceid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadermanufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderstatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderhardwareId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdrivername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdriverdescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdriverversion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdriverprovidername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdriverbuilddate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdriversigner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderdriverinfname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // DeviceName
            // 
            this.DeviceName.Name = "DeviceName";
            // 
            // listViewDevice
            // 
            this.listViewDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeadername,
            this.columnHeaderdeviceid,
            this.columnHeaderdescription,
            this.columnHeadermanufacturer,
            this.columnHeaderstatus,
            this.columnHeaderhardwareId,
            this.columnHeaderdrivername,
            this.columnHeaderdriverdescription,
            this.columnHeaderdriverversion,
            this.columnHeaderdriverprovidername,
            this.columnHeaderdriverbuilddate,
            this.columnHeaderdriversigner,
            this.columnHeaderdriverinfname});
            this.listViewDevice.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.listViewDevice, "listViewDevice");
            this.listViewDevice.FullRowSelect = true;
            this.listViewDevice.HideSelection = false;
            this.listViewDevice.Name = "listViewDevice";
            this.listViewDevice.OwnerDraw = true;
            this.listViewDevice.UseCompatibleStateImageBehavior = false;
            this.listViewDevice.View = System.Windows.Forms.View.Details;
            this.listViewDevice.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewDevice_DrawColumnHeader);
            this.listViewDevice.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewDevice_DrawItem);
            // 
            // columnHeadername
            // 
            resources.ApplyResources(this.columnHeadername, "columnHeadername");
            // 
            // columnHeaderdeviceid
            // 
            resources.ApplyResources(this.columnHeaderdeviceid, "columnHeaderdeviceid");
            // 
            // columnHeaderdescription
            // 
            resources.ApplyResources(this.columnHeaderdescription, "columnHeaderdescription");
            // 
            // columnHeadermanufacturer
            // 
            resources.ApplyResources(this.columnHeadermanufacturer, "columnHeadermanufacturer");
            // 
            // columnHeaderstatus
            // 
            resources.ApplyResources(this.columnHeaderstatus, "columnHeaderstatus");
            // 
            // columnHeaderhardwareId
            // 
            resources.ApplyResources(this.columnHeaderhardwareId, "columnHeaderhardwareId");
            // 
            // columnHeaderdrivername
            // 
            resources.ApplyResources(this.columnHeaderdrivername, "columnHeaderdrivername");
            // 
            // columnHeaderdriverdescription
            // 
            resources.ApplyResources(this.columnHeaderdriverdescription, "columnHeaderdriverdescription");
            // 
            // columnHeaderdriverversion
            // 
            resources.ApplyResources(this.columnHeaderdriverversion, "columnHeaderdriverversion");
            // 
            // columnHeaderdriverprovidername
            // 
            resources.ApplyResources(this.columnHeaderdriverprovidername, "columnHeaderdriverprovidername");
            // 
            // columnHeaderdriverbuilddate
            // 
            resources.ApplyResources(this.columnHeaderdriverbuilddate, "columnHeaderdriverbuilddate");
            // 
            // columnHeaderdriversigner
            // 
            resources.ApplyResources(this.columnHeaderdriversigner, "columnHeaderdriversigner");
            // 
            // columnHeaderdriverinfname
            // 
            resources.ApplyResources(this.columnHeaderdriverinfname, "columnHeaderdriverinfname");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Image = global::DcRat.Properties.Resources.about_dark;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            resources.ApplyResources(this.enableToolStripMenuItem, "enableToolStripMenuItem");
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Image = global::DcRat.Properties.Resources.about_dark;
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            resources.ApplyResources(this.disableToolStripMenuItem, "disableToolStripMenuItem");
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // singleFormDevice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewDevice);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singleFormDevice";
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
        private DataGridViewTextBoxColumn DeviceName;
        public ListView listViewDevice;
        private ColumnHeader columnHeadername;
        private ColumnHeader columnHeaderdeviceid;
        private ColumnHeader columnHeaderdescription;
        private ColumnHeader columnHeadermanufacturer;
        private ColumnHeader columnHeaderstatus;
        private ColumnHeader columnHeaderhardwareId;
        private ColumnHeader columnHeaderdrivername;
        private ColumnHeader columnHeaderdriverbuilddate;
        private ColumnHeader columnHeaderdriverdescription;
        private ColumnHeader columnHeaderdriverversion;
        private ColumnHeader columnHeaderdriverprovidername;
        private ColumnHeader columnHeaderdriversigner;
        private ColumnHeader columnHeaderdriverinfname;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
    }
}