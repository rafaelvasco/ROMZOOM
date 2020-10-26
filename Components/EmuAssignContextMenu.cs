using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ROMZOOM.Model;

namespace ROMZOOM.Components
{
    public sealed class EmuAssignContextMenu : ToolStripDropDown
    {
        public EmuAssignContextMenu(Dictionary<int, Emulator> emulators, ZoomContextMenuHandler select_handler)
        {

            foreach (var emulator in emulators)
            {
                if (emulator.Value.LaunchArgs.Count == 1)
                {
                    string label = emulator.Value.Name;
                    var item = new ZoomContextMenuItem(label, ZoomContextMenuItem.Type.AssignEmu, emulator.Key,  emulator.Value.LaunchArgs.First().Key);

                    item.Click += (sender, args) => select_handler.Invoke((ZoomContextMenuItem) sender);

                    this.Items.Add(item);

                }
                else
                {
                    foreach (var value_launch_arg in emulator.Value.LaunchArgs)
                    {
                        string label = $"{emulator.Value.Name} ({value_launch_arg.Value.Name})";
                        var item_with_arg = new ZoomContextMenuItem(label, ZoomContextMenuItem.Type.AssignEmu, emulator.Key, value_launch_arg.Key);

                        item_with_arg.Click += (sender, args) => select_handler.Invoke((ZoomContextMenuItem) sender);

                        this.Items.Add(item_with_arg);
                    }

                }
            }
        }
    }
}
