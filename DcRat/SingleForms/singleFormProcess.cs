using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DcRat.Controls;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;

namespace DcRat.singleForms
{
    public partial class singleFormProcess : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public string HWID { get; set; }

        public singleFormProcess()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InitBorder();
            SetTheme();
        }

        #region Theme

        private void SetTheme()
        {
            var darkTheme = Settings.Default.darkTheme;

            var colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            var colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

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


            listViewprocess.BackColor = darkTheme ? Settings.Default.colorlistviewdark : Settings.Default.colorlistview;
            listViewprocess.ForeColor =
                darkTheme ? Settings.Default.colorlistviewtextdark : Settings.Default.colorlistviewtext;
            foreach (ListViewItem item in listViewprocess.Items)
            {
                item.ForeColor = Settings.Default.darkTheme
                    ? Settings.Default.colorlistviewtextdark
                    : Settings.Default.colorlistviewtext;
                item.BackColor = Settings.Default.darkTheme
                    ? Settings.Default.colorlistviewdark
                    : Settings.Default.colorlistview;
            }
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
            int maxwidth = 700;
            int maxheight = 450;

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
            Close();
        }

        private void listViewprocess_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
            if (listViewprocess.Columns.Count == 0) return;

            tColumnCount = listViewprocess.Columns.Count;
            tRect.Y = 0;
            tRect.Height = e.Bounds.Height - 1;
            tPoint.Y = 3;
            for (var i = 0; i < tColumnCount; i++)
            {
                if (i == 0)
                {
                    tRect.X = 0;
                    tRect.Width = listViewprocess.Columns[i].Width;
                }
                else
                {
                    tRect.X += tRect.Width;
                    tRect.X += 1;
                    tRect.Width = listViewprocess.Columns[i].Width - 1;
                }

                e.Graphics.FillRectangle(tBackBrush, tRect);
                tPoint.X = tRect.X + 3;
                e.Graphics.DrawString(listViewprocess.Columns[i].Text, tFont, tFtontBrush, tPoint);
            }
        }

        private void listViewprocess_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listViewprocess_ColumnClick(object sender, ColumnClickEventArgs e)
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
                listViewprocess.Sort();
            }
            catch
            {
            }
        }

        private void singleFormProcess_Load(object sender, EventArgs e)
        {
            Optimization.EnableListviewDoubleBuffer(listViewprocess);
            lvwColumnSorter = new ListViewColumnSorter();
            listViewprocess.ListViewItemSorter = lvwColumnSorter;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "process";
            pack.ForcePathObject("TargetClient").AsString = HWID;

            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
        }

        private async void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewprocess.SelectedItems.Count > 0)
                foreach (ListViewItem P in listViewprocess.SelectedItems)
                    await Task.Run(() =>
                    {
                        var pack = new MsgPack();
                        pack.ForcePathObject("Packet").AsString = "processKill";
                        pack.ForcePathObject("TargetClient").AsString = HWID;
                        pack.ForcePathObject("ID").AsString = P.SubItems[columnHeaderid.Index].Text;

                        var msgpack = new MsgPack();
                        msgpack.ForcePathObject("Type").AsString = "Controler";
                        msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                        msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                        ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    });
        }

        private async void createDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewprocess.SelectedItems.Count > 0)
                foreach (ListViewItem P in listViewprocess.SelectedItems)
                    await Task.Run(() =>
                    {
                        var pack = new MsgPack();
                        pack.ForcePathObject("Packet").AsString = "processDump";
                        pack.ForcePathObject("TargetClient").AsString = HWID;
                        pack.ForcePathObject("ID").AsString = P.SubItems[columnHeaderid.Index].Text;

                        var msgpack = new MsgPack();
                        msgpack.ForcePathObject("Type").AsString = "Controler";
                        msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                        msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                        ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    });
        }
    }
}