using System.Drawing;
using System.Windows.Forms;

namespace ROMZOOM.ControlLib
{
    public static class Extensions
    {
        public static Point AbsoluteLocation(this Control control)
        {
            Point p;
            for (p = control.Location; control.Parent != null; control = control.Parent)
            {
                p.Offset(control.Parent.Location);
            }

            return p;
        }
    }
}
