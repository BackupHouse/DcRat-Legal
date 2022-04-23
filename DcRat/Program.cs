using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DcRat.Properties;

namespace DcRat
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (Settings.Default.Chinese)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-cn");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}