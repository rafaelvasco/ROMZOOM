using System.Windows.Forms;

namespace ROMZOOM.Components
{
    public sealed class RomContextMenu : ContextMenuStrip
    {
        public RomContextMenu(ZoomContextMenuHandler item_select_handler)
        {
            var assign_rom_image_menu_item = new ZoomContextMenuItem("Assign Rom Image...", ZoomContextMenuItem.Type.AssignRomImage);

            assign_rom_image_menu_item.Click += (sender, args) =>
            {
                item_select_handler.Invoke((ZoomContextMenuItem)sender);
            };

            this.Items.Add(assign_rom_image_menu_item);
        }
    }
}
