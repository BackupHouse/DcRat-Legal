using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DcRat.Controls;
using DcRat.helpForms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;

namespace DcRat.ChildForms
{
    public partial class childFormTasks : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public childFormTasks()
        {
            InitializeComponent();
            SetTheme();
            CheckForIllegalCrossThreadCalls = false;

            MsgPack pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "Tasks";
            pack.ForcePathObject("Message").AsString = "Get";

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
        }

        private void listViewtasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewtasks.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewtasks.Items)
                {
                    item.ForeColor = Settings.Default.darkTheme
                        ? Settings.Default.colorlistviewtextdark
                        : Settings.Default.colorlistviewtext;
                    item.BackColor = Settings.Default.darkTheme
                        ? Settings.Default.colorlistviewdark
                        : Settings.Default.colorlistview;
                }

                foreach (ListViewItem item in listViewtasks.SelectedItems)
                {
                    //item.ForeColor = Settings.Default.darkTheme ? Settings.Default.colorlistviewdark : Settings.Default.colorlistview;
                    item.ForeColor = Color.White;
                    item.BackColor = Settings.Default.darkTheme
                        ? ColorTranslator.FromHtml("#5D4529")
                        : ColorTranslator.FromHtml("#758B98");
                }

                listViewtasks.Tag = listViewtasks.FocusedItem;
                listViewtasks.FocusedItem.Selected = false;
            }
        }

        private ListViewItem lvHoveredItem;

        private void listViewtasks_MouseMove(object sender, MouseEventArgs e)
        {
            var oItemColor = Settings.Default.darkTheme ? ColorTranslator.FromHtml("#2D333B") : Color.Lavender;
            var oOriginalColor = Settings.Default.darkTheme
                ? Settings.Default.colorlistviewdark
                : Settings.Default.colorlistview;

            var lvCurrentItem = listViewtasks.GetItemAt(e.X, e.Y);


            if (lvCurrentItem != null && lvCurrentItem != lvHoveredItem)
            {
                if (lvCurrentItem != listViewtasks.Tag)
                {
                    lvCurrentItem.BackColor = oItemColor;

                    if (lvHoveredItem != null && lvHoveredItem != listViewtasks.Tag)
                        lvHoveredItem.BackColor = oOriginalColor;

                    lvHoveredItem = lvCurrentItem;
                    return;
                }

                if (lvHoveredItem != null && lvHoveredItem != listViewtasks.Tag)
                    lvHoveredItem.BackColor = oOriginalColor;

                lvHoveredItem = lvCurrentItem;
                return;
            }


            if (lvCurrentItem == null)
                if (lvHoveredItem != null && lvHoveredItem != listViewtasks.Tag)
                {
                    lvHoveredItem.BackColor = oOriginalColor;
                    lvHoveredItem = null;
                }
        }

        private void listViewtasks_MouseLeave(object sender, EventArgs e)
        {
            if (lvHoveredItem != null && lvHoveredItem != listViewtasks.Tag)
                lvHoveredItem.BackColor = Settings.Default.darkTheme
                    ? Settings.Default.colorlistviewdark
                    : Settings.Default.colorlistview;
            lvHoveredItem = null;
        }

        private void listViewtasks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (listViewtasks.SelectedIndices.Count == 0)
            {
                foreach (ListViewItem item in listViewtasks.Items)
                {
                    item.ForeColor = Settings.Default.darkTheme
                        ? Settings.Default.colorlistviewtextdark
                        : Settings.Default.colorlistviewtext;
                    item.BackColor = Settings.Default.darkTheme
                        ? Settings.Default.colorlistviewdark
                        : Settings.Default.colorlistview;
                }

                listViewtasks.Tag = null;
            }
        }

        private void listViewtasks_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
            if (listViewtasks.Columns.Count == 0) return;

            tColumnCount = listViewtasks.Columns.Count;
            tRect.Y = 0;
            tRect.Height = e.Bounds.Height - 1;
            tPoint.Y = 3;
            for (var i = 0; i < tColumnCount; i++)
            {
                if (i == 0)
                {
                    tRect.X = 0;
                    tRect.Width = listViewtasks.Columns[i].Width;
                }
                else
                {
                    tRect.X += tRect.Width;
                    tRect.X += 1;
                    tRect.Width = listViewtasks.Columns[i].Width - 1;
                }

                e.Graphics.FillRectangle(tBackBrush, tRect);
                tPoint.X = tRect.X + 3;
                e.Graphics.DrawString(listViewtasks.Columns[i].Text, tFont, tFtontBrush, tPoint);
            }
        }

        private void listViewtasks_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private bool previoustheme;

        private void updateUI_Tick(object sender, EventArgs e)
        {
            if (previoustheme != Settings.Default.darkTheme)
            {
                previoustheme = Settings.Default.darkTheme;
                SetTheme();
            }
        }

        private void SetTheme()
        {
            var darkTheme = Settings.Default.darkTheme;

            var colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            var colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

            BackColor = colorSide;
            ForeColor = colorText;

            listViewtasks.BackColor = darkTheme ? Settings.Default.colorlistviewdark : Settings.Default.colorlistview;
            listViewtasks.ForeColor =
                darkTheme ? Settings.Default.colorlistviewtextdark : Settings.Default.colorlistviewtext;
            foreach (ListViewItem item in listViewtasks.Items)
                if (listViewtasks.Tag != item)
                {
                    item.ForeColor = Settings.Default.darkTheme
                        ? Settings.Default.colorlistviewtextdark
                        : Settings.Default.colorlistviewtext;
                    item.BackColor = Settings.Default.darkTheme
                        ? Settings.Default.colorlistviewdark
                        : Settings.Default.colorlistview;
                }

            //contextMenuStripTasks.BackColor = colorSide;
            //contextMenuStripTasks.ForeColor = colorText;

            //newToolStripMenuItem.Image= darkTheme ? Resources.add : Resources.add_dark;
            //refreshToolStripMenuItem.Image= darkTheme ? Resources.refreshprocess : Resources.refreshprocess_dark;
            //changeStatusToolStripMenuItem.Image = darkTheme ? Resources._switch : Resources.switch_dark;
            //deleteToolStripMenuItem.Image=(darkTheme) ? Resources.delete : Resources.delete_dark;
        }

        private void listViewtasks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            try
            {
                listViewtasks.Sort();
            }
            catch
            {
            }
        }

        private void childFormTasks_Load(object sender, EventArgs e)
        {
            Optimization.EnableListviewDoubleBuffer(listViewtasks);
            lvwColumnSorter = new ListViewColumnSorter();
            listViewtasks.ListViewItemSorter = lvwColumnSorter;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helperFormTask helperFormTask = new helperFormTask();
            helperFormTask.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listViewItem = (ListViewItem)listViewtasks.Tag;
            MsgPack pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "Tasks";
            pack.ForcePathObject("Message").AsString = "Delete";
            pack.ForcePathObject("Name").AsString = listViewItem.Text;

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
        }

        private void changeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listViewItem = (ListViewItem)listViewtasks.Tag;
            MsgPack pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "Tasks";
            pack.ForcePathObject("Message").AsString = "Change";
            pack.ForcePathObject("Name").AsString = listViewItem.Text;

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "Tasks";
            pack.ForcePathObject("Message").AsString = "Get";

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
        }
    }
}