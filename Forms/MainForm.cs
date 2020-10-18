﻿using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using ROMZOOM.Components;
using ROMZOOM.Logic;
using ROMZOOM.Model;

namespace ROMZOOM.Forms
{
    public partial class MainForm : Form
    {
        private PlatformContextMenu _platform_item_context_menu;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Messager.On((int) MessageCodes.LibraryModified, OnLibraryModified);

            Library.Load();

            InitPlatformContextMenu();

            UpdateControls();

        }

        private void InitPlatformContextMenu()
        {
            _platform_item_context_menu = new PlatformContextMenu(Library.Emulators, OnPlatformContextMenuItemTriggered);
        }


        private void OnPlatformContextMenuItemTriggered(ZoomContextMenuItem item)
        {
            var selected_platform = (Platform)platformsListMain.SelectedObject;

            switch (item.ActionType)
            {
                case ZoomContextMenuItem.Type.AssignEmu:

                    Library.Platforms[selected_platform.PlatformId].EmulatorId = (int) item.Tag1;
                    Library.Platforms[selected_platform.PlatformId].LaunchArgId = (int) item.Tag2;
                    Library.MarkDirty();

                    break;
            }
        }


        private void UpdateControls()
        {
            platformsListMain.ClearObjects();

            platformsListMain.AddObject(Platform.All);
            platformsListMain.AddObjects(Library.Platforms.Values);

            platformsListMain.SelectedIndex = 1;

            UpdateRomsList();
        }

        private void UpdateRomsList()
        {
            if (platformsListMain.SelectedObject != null)
            {
                var selected_platform = (Platform) platformsListMain.SelectedObject;

                if (selected_platform.PlatformId != PlatformId.ALL)
                {
                    var roms_list = Library.Roms[((Platform) platformsListMain.SelectedObject).PlatformId];
                    romsListMain.SetObjects(roms_list);
                }
                else
                {
                    romsListMain.ClearObjects();

                    foreach (var rom in Library.Roms)
                    {
                        romsListMain.AddObjects(rom.Value);
                    }

                }
                
            }
        }

        private void OnLibraryModified()
        {
            UpdateControls();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.Save();
        }

        private void ScanRomsButton_Click(object sender, System.EventArgs e)
        {
            var rom_scan_form = new RomScanForm();

            rom_scan_form.Show();
        }

        private void EmulatorsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var emu_form = new EmulatorsForm();

            emu_form.Show();
        }

        private void PlatformsListMain_SelectionChanged(object sender, System.EventArgs e)
        {
            romsListMain.Focus();
            UpdateRomsList();
        }

        private void PlatformsListMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _platform_item_context_menu.Show(platformsListMain, new Point(e.X, e.Y));
            }
        }

        private void PlatformsListMain_DoubleClick(object sender, System.EventArgs e)
        {
            ShowPlatformDialog();
        }

        private void ShowPlatformDialog()
        {
            var selected_platform = (Platform)platformsListMain.SelectedObject;

            var platform_properties_dialog = new PlatformPropertiesDialog();

            platform_properties_dialog.Closed += (o, args) => platformsListMain.RefreshSelectedObjects();

            platform_properties_dialog.Show(selected_platform.PlatformId);
        }

        private void RomsListMain_DoubleClick(object sender, System.EventArgs e)
        {
            var selected_rom = (Rom) romsListMain.SelectedObject;

            selected_rom.TimesPlayed += 1;

            Library.MarkDirty();

            if (Library.Platforms[selected_rom.PlatformId].EmulatorId == 0)
            {
                ShowPlatformDialog();
                return;
            }

            var emulator_assigned = Library.Emulators[Library.Platforms[selected_rom.PlatformId].EmulatorId];

            var launch_arg_assigned = emulator_assigned.LaunchArgs[Library.Platforms[selected_rom.PlatformId].LaunchArgId];

            var process_start_info = new ProcessStartInfo(emulator_assigned.Path, launch_arg_assigned.Arg.Replace("%rom%", "\"" + selected_rom.Path + "\""))
            {
                UseShellExecute = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Path.GetDirectoryName(emulator_assigned.Path)
            };


            using (var process = Process.Start(process_start_info))
            {
                process?.WaitForExit();    
            }
        }

        private void TxtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                romsListMain.ModelFilter = TextMatchFilter.Contains(romsListMain, txtSearch.Text);
            }
            else
            {
                romsListMain.ModelFilter = null;
            }
            
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.ActiveControl = null;
                e.Handled = true;
            }

            
        }

        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var about_form = new AboutForm();

            about_form.Show();

        }
    }
}