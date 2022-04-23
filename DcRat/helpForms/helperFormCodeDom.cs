using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;

namespace DcRat.helpForms
{
    public partial class helperFormCodeDom : Form
    {
        public  string taskName { get; set; }
        public string Trigger { get; set; }
        public helperFormCodeDom()
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

            label.ForeColor = colorText;
            label.BackColor = colorSide;
            checkedListBox.ForeColor = colorText;
            checkedListBox.BackColor = colorSide;
            buttonSend.ForeColor = colorText;
            buttonSend.BackColor = colorSide;
            fastColoredTextBox.ForeColor = colorText;
            fastColoredTextBox.BackColor = colorSide;
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

        private MouseDirection direction;
        private Point rectangle;

        private void InitBorder()
        {
            MouseDown += BorderMouseDown;

            MouseMove += BorderMouseMove;

            MouseLeave += BorderMouseLeave;
        }

        private void BorderMouseMove(object sender, MouseEventArgs e)
        {
            var tempEndPoint = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                if (direction == MouseDirection.None)
                {
                }
                else if (direction == MouseDirection.East)
                {
                    if (tempEndPoint.X <= 1000)
                        Width = 1000;
                    else
                        Width = tempEndPoint.X;
                }
                else if (direction == MouseDirection.South)
                {
                    if (tempEndPoint.Y <= 500)
                        Height = 500;
                    else
                        Height = tempEndPoint.Y;
                }
                else if (direction == MouseDirection.West)
                {
                    var x = tempEndPoint.X - rectangle.X;
                    if (Width - x <= 1000)
                    {
                        Width = 1000;
                    }
                    else
                    {
                        Width = Width - x;
                        Location = new Point(Location.X + x, Location.Y);
                    }
                }
                else if (direction == MouseDirection.North)
                {
                    var y = tempEndPoint.Y - rectangle.Y;
                    if (Height - y <= 500)
                    {
                        Height = 500;
                    }
                    else
                    {
                        Height = Height - y;
                        Location = new Point(Location.X, Location.Y + y);
                    }
                }
                else if (direction == MouseDirection.Southeast)
                {
                    if (tempEndPoint.X <= 1000)
                        Width = 1000;
                    else
                        Width = tempEndPoint.X;
                    if (tempEndPoint.Y <= 500)
                        Height = 500;
                    else
                        Height = tempEndPoint.Y;
                }
                else if (direction == MouseDirection.Northeast)
                {
                    var y = tempEndPoint.Y - rectangle.Y;
                    if (Height - y <= 500)
                    {
                        Height = 500;
                    }
                    else
                    {
                        Height = Height - y;
                        Location = new Point(Location.X, Location.Y + y);
                    }

                    if (tempEndPoint.X <= 1000)
                        Width = 1000;
                    else
                        Width = tempEndPoint.X;
                }
                else if (direction == MouseDirection.Southwest)
                {
                    var x = tempEndPoint.X - rectangle.X;
                    if (Width - x <= 1000)
                    {
                        Width = 1000;
                    }
                    else
                    {
                        Width = Width - x;
                        Location = new Point(Location.X + x, Location.Y);
                    }

                    if (tempEndPoint.Y <= 500)
                        Height = 500;
                    else
                        Height = tempEndPoint.Y;
                }
                else if (direction == MouseDirection.Northwest)
                {
                    var x = tempEndPoint.X - rectangle.X;
                    if (Width - x <= 1000)
                    {
                        Width = 1000;
                    }
                    else
                    {
                        Width = Width - x;
                        Location = new Point(Location.X + x, Location.Y);
                    }

                    var y = tempEndPoint.Y - rectangle.Y;
                    if (Height - y <= 500)
                    {
                        Height = 500;
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var References = "";
            foreach (var item in checkedListBox.CheckedItems) References = References + item + "-=>";
            if (References != null) References = References.Remove(References.Length - 3, 3);

            var pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "codedom";
            pack.ForcePathObject("Source").AsString = fastColoredTextBox.Text;
            pack.ForcePathObject("References").AsString = References;

            MsgPack mypack = new MsgPack();
            mypack.ForcePathObject("Packet").AsString = "Tasks";
            mypack.ForcePathObject("Message").AsString = "Add";
            mypack.ForcePathObject("Name").AsString = taskName;
            mypack.ForcePathObject("Trigger").AsString = Trigger;
            mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            this.Close();
        }
    }
}