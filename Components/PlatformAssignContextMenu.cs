using System.Collections.Generic;
using System.Windows.Forms;
using ROMZOOM.Model;

namespace ROMZOOM.Components
{
    public class PlatformAssignContextMenu : ToolStripDropDown
    {
       public PlatformAssignContextMenu(List<PlatformId> available_platform_ids, ZoomContextMenuHandler item_select_handler)
        {
            var create_platform_menu_item = new ToolStripMenuItem("Set Platform...");

            foreach (var avail_platform_id in available_platform_ids)
            {
                var item = new ZoomContextMenuItem(avail_platform_id.ToString(), ZoomContextMenuItem.Type.SetPlatform, avail_platform_id);

                item.Click += (sender, args) => item_select_handler.Invoke((ZoomContextMenuItem) sender);

                create_platform_menu_item.DropDownItems.Add(item);
            }

            this.Items.Add(create_platform_menu_item);
        }
    }
}
