using System.Reflection;
using System.Windows.Forms;

namespace DcRat.Controls
{
    class Optimization
    {
        public static void EnableListviewDoubleBuffer(ListView listView)
        {
            PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp.SetValue(listView, true, null);
        }
    }
}
