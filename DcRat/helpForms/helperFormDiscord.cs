using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;
using Microsoft.VisualBasic;

namespace DcRat.helpForms
{
    public partial class helperFormDiscord : Form
    {
        public helperFormDiscord()
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
                if (string.IsNullOrEmpty(textBox1.Text) )
                {
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "Notify";
                    pack.ForcePathObject("Message").AsString = "Discord0";
                    MsgPack msgpack = new MsgPack();
                    msgpack.ForcePathObject("Type").AsString = "Controler";
                    msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                    msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                    msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                    ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                }
                int random = new Random().Next(1000, 9999);
                Discord(random.ToString());
                string Msgbox = Interaction.InputBox("Type in the code you receive", "Code", "Code");
                if (Msgbox == random.ToString())
                {
                    MsgPack pack = new MsgPack();
                    pack.ForcePathObject("Packet").AsString = "Notify";
                    pack.ForcePathObject("Message").AsString = "Discord";
                    pack.ForcePathObject("WebHook").AsString = textBox1.Text;
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

        public void Discord(string content)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content",content},
                        { "username", "DcRat" }
                    };

            client.PostAsync(textBox1.Text, new FormUrlEncodedContent(contents));
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
