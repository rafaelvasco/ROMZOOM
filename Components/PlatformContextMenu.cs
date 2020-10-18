using System.Collections.Generic;
using System.Windows.Forms;
using ROMZOOM.Model;

namespace ROMZOOM.Components
{

    public sealed class PlatformContextMenu : ContextMenuStrip
    {
        public PlatformContextMenu(Dictionary<int, Emulator> emulators, ZoomContextMenuHandler item_select_handler)
        {
            var emus_sub_menu = new ToolStripMenuItem("Assign Emulator");

            var emu_assign_context_menu = new EmuAssignContextMenu(emulators, item_select_handler);

            emus_sub_menu.DropDown = emu_assign_context_menu;

            this.Items.Add(emus_sub_menu);

        }

    }
}
