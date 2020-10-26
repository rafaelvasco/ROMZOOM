using System.Windows.Forms;

namespace ROMZOOM.Components
{
    public sealed class RomContextMenu : ContextMenuStrip
    {
        public RomContextMenu(ZoomContextMenuHandler item_select_handler, bool show_assign_image_item = true, bool show_delete_item = true, bool show_clear_image = true)
        {
            if (show_assign_image_item)
            {
                var assign_rom_image_menu_item = new ZoomContextMenuItem("Assign Rom Image...", ZoomContextMenuItem.Type.AssignRomImage);

                assign_rom_image_menu_item.Click += (sender, args) => item_select_handler.Invoke((ZoomContextMenuItem)sender);

                this.Items.Add(assign_rom_image_menu_item);
            }

            if (show_delete_item)
            {
                var delete_menu_item = new ZoomContextMenuItem("Delete", ZoomContextMenuItem.Type.DeleteRom);

                delete_menu_item.Click += (sender, args) => item_select_handler.Invoke((ZoomContextMenuItem) sender);
            
                this.Items.Add(delete_menu_item);
            }

            if (show_clear_image)
            {
                var clear_image_menu_item = new ZoomContextMenuItem("Clear Image", ZoomContextMenuItem.Type.ClearImage);

                clear_image_menu_item.Click += (sender, args) => item_select_handler.Invoke((ZoomContextMenuItem) sender);
            
                this.Items.Add(clear_image_menu_item);
            }
        }
    }
}
