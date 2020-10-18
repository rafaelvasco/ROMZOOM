
using System.Windows.Forms;

namespace ROMZOOM.Components
{
    public delegate void ZoomContextMenuHandler(ZoomContextMenuItem item);

    

    public class ZoomContextMenuItem : ToolStripMenuItem
    {
        public enum Type
        {
            Rename,
            AssignEmu
        }

        public Type ActionType { get; set; }

        public object Tag1 { get; set; }

        public object Tag2 { get; set; }

        public ZoomContextMenuItem(string label, Type type, object tag1=null, object tag2=null) : base(label)
        {
            ActionType = type;
            Tag1 = tag1;
            Tag2 = tag2;
        }
    }
}
