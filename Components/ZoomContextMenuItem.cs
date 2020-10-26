
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ROMZOOM.Components
{
    public delegate void ZoomContextMenuHandler(ZoomContextMenuItem item);

    

    public sealed class ZoomContextMenuItem : ToolStripMenuItem
    {
        public enum Type
        {
            AssignEmu,
            AssignRomImage,
            SetPlatform,
            DeletePlatform,
            DeleteRom,
            ClearImage
        }

        public Type ActionType { get; set; }

        public object Tag1 { get; set; }

        public object Tag2 { get; set; }

        public ZoomContextMenuItem(string label, Type type, object tag1=null, object tag2=null) : base(label)
        {
            TextAlign = ContentAlignment.TopLeft;
            AutoSize = false;
            Width = 350;
            ActionType = type;
            Tag1 = tag1;
            Tag2 = tag2;
        }
    }
}
