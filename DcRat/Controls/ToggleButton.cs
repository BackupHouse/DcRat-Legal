using System;
using System.Drawing;
using System.Windows.Forms;
using DcRat.Properties;

namespace DcRat.Controls
{
    public partial class ToggleButton : UserControl
    {
        public ToggleButton()
        {
            InitializeComponent();
            //设置Style支持透明背景色并且双缓冲
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(50, 50);
        }
        bool isCheck;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked
        {
            set { isCheck = value; Invalidate(); }
            get => isCheck;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitMapOn = null;
            Bitmap bitMapOff = null;

            bitMapOn = Resources.Toggle_On;
            bitMapOff = Resources.Toggle_Off;

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, Size.Width, Size.Height);

            if (isCheck)
            {
                g.DrawImage(bitMapOn, rec);
            }
            else
            {
                g.DrawImage(bitMapOff, rec);
            }
        }

        private void OnOffButton_Click(object sender, EventArgs e)
        {
            isCheck = !isCheck;
            Invalidate();
        }
    }
}

