using System;
using System.Windows.Forms;
using DcRat.Properties;

namespace DcRat.ChildForms
{
    public partial class childFormAbout : Form
    {
        public childFormAbout()
        {
            InitializeComponent();
            SetTheme();
        }

        private bool previoustheme;

        private void updateUI_Tick(object sender, EventArgs e)
        {
            if (previoustheme != Settings.Default.darkTheme)
            {
                previoustheme = Settings.Default.darkTheme;
                SetTheme();
            }
        }

        private void SetTheme()
        {
            var darkTheme = Settings.Default.darkTheme;

            var colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            var colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

            BackColor = colorSide;
            ForeColor = colorText;
            pictureBox.Image = darkTheme ? Resources.DcRat : Resources.DcRat_dark;
        }
    }
}