using System;
using System.Diagnostics;
using System.Windows.Forms;
using DcRat.helpForms;
using DcRat.Properties;

namespace DcRat.ChildForms
{
    public partial class childFormSettings : Form
    {
        public childFormSettings()
        {
            InitializeComponent();
        }

        private void childFormSettings_Load(object sender, EventArgs e)
        {
            radioButtonlight.Checked = !Settings.Default.darkTheme;
            radioButtondark.Checked = Settings.Default.darkTheme;
            trackBaropacity.Value = (int) Settings.Default.opacity;
            SetTheme();
        }

        private void SetTheme()
        {
            var darkTheme = Settings.Default.darkTheme;

            var colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            var colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

            BackColor = colorSide;
            ForeColor = colorText;

            groupBoxnotify.ForeColor = colorText;
            groupBoxtheme.ForeColor = colorText;
            buttonmailbind.ForeColor = colorText;
        }

        private void radioButtonlight_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.darkTheme = !radioButtonlight.Checked;
            Settings.Default.Save();
            SetTheme();
        }

        private void trackBaropacity_Scroll(object sender, EventArgs e)
        {
            Settings.Default.opacity = trackBaropacity.Value;
            Settings.Default.Save();
        }

        private void buttondingdingbind_Click(object sender, EventArgs e)
        {
            var dingTalk = new helperFormDingTalk();
            dingTalk.Show();
        }

        private void buttonmailbind_Click(object sender, EventArgs e)
        {
            var mail = new helperFormMail();
            mail.Show();
        }

        private void buttontelegrambind_Click(object sender, EventArgs e)
        {
            var telegram = new helperFormTelegram();
            telegram.Show();
        }

        private void buttondiscordbind_Click(object sender, EventArgs e)
        {
            var discord = new helperFormDiscord();
            discord.Show();
        }

        private void comboBoxlanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.Chinese = (comboBoxlanguage.Text == "Chinese");
            Settings.Default.Save();
            MessageBox.Show(Settings.Default.Chinese ? "将立刻重启以应用更改" : "Will restart to apply change.");
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Environment.Exit(0);
        }
    }
}