﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
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
        private RomContextMenu _rom_item_context_menu;

        public MainForm()
        {
            InitializeComponent();

            ConfigureItemLists();

            comboViewStyle.DataSource = Enum.GetValues(typeof(RomsListViewMode));

            comboViewStyle.SelectedItem = RomsListViewMode.List;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Messager.On((int) MessageCodes.LibraryModified, OnLibraryModified);

            Library.Load();

            InitPlatformContextMenu();

            InitRomContextMenu();

            UpdateControls();

        }

        private void ConfigureItemLists()
        {
            romsListMain.ItemRenderer = new RomListTileRenderer(new RomListTileRendererColors()
            {
                BgColor = Color.FromKnownColor(KnownColor.MidnightBlue),
                SelectedColor = Color.FromKnownColor(KnownColor.Violet),
                SelectedTextColor = Color.Black,
                TextBgColor = Color.Black,
                TextColor = Color.White
            });

            romsListMain.TileSize = new Size(128,128);

            romsListMain.HotItemStyle = new HotItemStyle
            {
                BackColor = Color.FromKnownColor(KnownColor.Purple)
            };

            platformsListMain.HotItemStyle = new HotItemStyle()
            {
                BackColor = Color.FromKnownColor(KnownColor.Purple)
            };

        }

        private void InitPlatformContextMenu()
        {
            _platform_item_context_menu = new PlatformContextMenu(Library.Emulators, OnPlatformContextMenuItemTriggered);
        }

        private void InitRomContextMenu()
        {
            _rom_item_context_menu = new RomContextMenu(OnRomContextMenuItemTriggered);
        }
        
        private void UpdateControls()
        {
            platformsListMain.ClearObjects();

            platformsListMain.AddObject(Platform.All);

            if (Library.Platforms.Count > 0)
            {
                platformsListMain.AddObjects(Library.Platforms.Values);    
                platformsListMain.SelectedIndex = 1;
            }
            else
            {
                platformsListMain.SelectedIndex = 0;
            }

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
            else
            {
                romsListMain.ClearObjects();
            }
        }

        private void ShowPlatformDialog()
        {
            var selected_platform = (Platform)platformsListMain.SelectedObject;

            var platform_properties_dialog = new PlatformPropertiesDialog();

            platform_properties_dialog.Closed += (o, args) => platformsListMain.RefreshSelectedObjects();

            platform_properties_dialog.Show(selected_platform.PlatformId);
        }

        private void OnRomContextMenuItemTriggered(ZoomContextMenuItem item)
        {
            var selected_rom = (Rom)romsListMain.SelectedObject;

            switch (item.ActionType)
            {
                case ZoomContextMenuItem.Type.AssignRomImage:

                    if (romImageFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            
                            Library.SetRomImage(selected_rom, romImageFileDialog.FileName);

                            romsListMain.RefreshSelectedObjects();

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Error while trying to assign image rom: {e.Message}", "Error",
                                MessageBoxButtons.OK);
                        }
                    }

                    break;

                case ZoomContextMenuItem.Type.ClearImage:

                    Library.ClearRomImage(selected_rom);

                    romsListMain.RefreshSelectedObjects();

                    break;

                case ZoomContextMenuItem.Type.DeleteRom:

                    if (MessageBox.Show("Are you sure ? Every trace of this rom will be erased.", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Library.RemoveRom(selected_rom);

                        romsListMain.RemoveObject(selected_rom);
                    }

                    break;
            }
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

                case ZoomContextMenuItem.Type.DeletePlatform:

                    if (MessageBox.Show("Are you sure ? Every trace of this Platform and all its roms and their images, if any, will be erased.", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Library.RemovePlatform(selected_platform);

                        platformsListMain.RemoveObject(selected_platform);

                        UpdateRomsList();
                    }

                    break;
            }
        }

        private void OnLibraryModified()
        {
            UpdateControls();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.Save();
            Library.ReleaseRomImages();
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
                var selected_platform = (Platform)platformsListMain.SelectedObject;

                if (selected_platform.PlatformId != PlatformId.ALL)
                {
                    _platform_item_context_menu.Show(platformsListMain, new Point(e.X, e.Y));
                }
            }
        }

        private void PlatformsListMain_DoubleClick(object sender, System.EventArgs e)
        {
            var selected_platform = (Platform)platformsListMain.SelectedObject;

            if (selected_platform.PlatformId != PlatformId.ALL)
            {
                ShowPlatformDialog();
            }
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

        private void RomsListMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _rom_item_context_menu.Show(romsListMain, new Point(e.X, e.Y));
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

        private void ComboViewStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            var selected_mode = (RomsListViewMode)comboViewStyle.SelectedItem;

            switch (selected_mode)
            {
                case RomsListViewMode.List:
                    romsListMain.View = View.Details;
                    break;
                case RomsListViewMode.Tiles128:
                    romsListMain.View = View.Tile;
                    romsListMain.TileSize = new Size(128,128);
                    break;
                case RomsListViewMode.Tiles256:
                    romsListMain.View = View.Tile;
                    romsListMain.TileSize = new Size(256,256);
                    break;
            }
        }

        private void ClearLibraryMenuItem_Click(object sender, EventArgs e)
        {
            Library.Clear();
            UpdateControls();

        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent(DataFormats.Html))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private async Task HandleFileDrop(DragEventArgs e)
        {
            if (romsListMain.SelectedIndex > -1 && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file_paths = (string[]) (e.Data.GetData(DataFormats.FileDrop));

                var file = file_paths[0];

                if (ImageFileValidator.IsValid(file))
                {
                    var selected_rom = (Rom) romsListMain.SelectedObject;

                    Library.SetRomImage(selected_rom, file);

                    romsListMain.RefreshSelectedObjects();
                }
            }
            else if (romsListMain.SelectedIndex > -1 && e.Data.GetDataPresent(DataFormats.Html))
            {
                var selected_rom = (Rom) romsListMain.SelectedObject;

                string data = (string) e.Data.GetData(DataFormats.Html);

                string image_path = HtmlCodeImageUrlExtractor.Extract(data);

                Bitmap image = await ImageDownloader.Download(image_path);

                if (image != null)
                {
                    Library.SetRomImage(selected_rom, image);

                    romsListMain.RefreshSelectedObjects();
                }
            }
        }

        private async void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            await HandleFileDrop(e);
        }

        private void ClearRomImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Library.ClearImages();

            UpdateRomsList();
        }
    }
}

