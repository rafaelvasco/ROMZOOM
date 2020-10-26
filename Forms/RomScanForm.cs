using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMZOOM.Components;
using ROMZOOM.Logic;
using ROMZOOM.Model;

namespace ROMZOOM.Forms
{
    public partial class RomScanForm : Form
    {
        private PlatformScanResult _scan_platforms;
        private Dictionary<PlatformId, List<Rom>> _scan_roms;

        private PlatformAssignContextMenu _platform_assign_context_menu;

        private RomContextMenu _rom_context_menu;

        public RomScanForm()
        {
            InitializeComponent();

            InitRomContextMenu();
        }

        private void InitRomContextMenu()
        {
            _rom_context_menu = new RomContextMenu(OnRomContextMenuItemTriggered, show_assign_image_item: false, show_clear_image: false);
        }

        private void OnRomContextMenuItemTriggered(ZoomContextMenuItem item)
        {
            switch (item.ActionType)
            {
                case ZoomContextMenuItem.Type.DeleteRom:

                    DeleteRomScanResult( (Rom) detectedRoms.SelectedObject);

                    break;
            }
        }

        private void DeleteRomScanResult(Rom rom)
        {
            _scan_roms[rom.PlatformId].Remove(rom);

            detectedRoms.RemoveObject(rom);
        }

        private void InitCreatePlatformContextMenu()
        {
            var available_platforms_list_for_manual_assign = PlatformIdMethods.GetAllValid();

            foreach (var platform in _scan_platforms.Platforms)
            {
                if (available_platforms_list_for_manual_assign.Contains(platform.PlatformId))
                {
                    available_platforms_list_for_manual_assign.Remove(platform.PlatformId);
                }
            }

            _platform_assign_context_menu = new PlatformAssignContextMenu(available_platforms_list_for_manual_assign, OnCreatePlatformContextMenuItemSelected);
        }

        private void OnCreatePlatformContextMenuItemSelected(ZoomContextMenuItem item)
        {
            switch (item.ActionType)
            {
                case ZoomContextMenuItem.Type.SetPlatform:

                    var selected_unrecognized_directory =  (DirectoryInfo) listUnrecognized.SelectedObject;

                    var selected_platform_id = (PlatformId) item.Tag1;

                    AddNewAssignedPlatform(selected_unrecognized_directory, selected_platform_id);

                    break;
            }
        }

        private void AddNewAssignedPlatform(DirectoryInfo directory, PlatformId platform_id)
        {
            var platform = new Platform(platform_id, PlatformIdMethods.GetDisplayName(platform_id), directory.FullName);

            int last_selected_platform_index = detectedPlatforms.SelectedIndex;

            _scan_platforms.Platforms.Add(platform);

            _scan_platforms.UnrecognizedDirectories.Remove(directory);

            detectedPlatforms.SetObjects(_scan_platforms.Platforms);

            listUnrecognized.SetObjects(_scan_platforms.UnrecognizedDirectories);

            detectedPlatforms.SelectedIndex = last_selected_platform_index;

            ScanRoms(platform);

            UpdateRomsPanel();
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            UpdateChooseScanFolderLabel();
        }

        private void ChooseScanFolderBtn_Click(object sender, EventArgs e)
        {
            if (libFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Library.RootPath = libFolderBrowserDialog.SelectedPath;
                UpdateChooseScanFolderLabel();
            }
        }


        private async void ScanBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Library.RootPath))
            {
                return;
            }

            _scan_platforms = new PlatformScanResult();
            _scan_roms = new Dictionary<PlatformId, List<Rom>>();

            scanProgressBar.Style = ProgressBarStyle.Marquee;
            scanProgressBar.MarqueeAnimationSpeed = 30;

            await Task.Run(DoScan);

            scanProgressBar.Style = ProgressBarStyle.Continuous;
            scanProgressBar.Value = 0;

            PopulatePanels();

            InitCreatePlatformContextMenu();

        }

        private void PopulatePanels()
        {
            if (_scan_platforms.Platforms.Count > 0)
            {
                detectedPlatforms.SetObjects(_scan_platforms.Platforms);
                UpdateRomsPanel();
                detectedPlatforms.SelectedIndex = 0;
            }

            if (_scan_platforms.UnrecognizedDirectories.Count > 0)
            {
                listUnrecognized.SetObjects(_scan_platforms.UnrecognizedDirectories);
            }
        }


        private void UpdateRomsPanel()
        {
            if (detectedPlatforms.SelectedItem == null)
            {
                return;
            }

            var selected_platform_id = ((Platform) detectedPlatforms.SelectedObject).PlatformId;

            if (_scan_roms.ContainsKey(selected_platform_id))
            {
                detectedRoms.SetObjects(_scan_roms[selected_platform_id]);
            }
            else
            {
                detectedRoms.ClearObjects();
            }
        }


        private void UpdateChooseScanFolderLabel()
        {
            chooseScanFolderBtn.Text = string.IsNullOrEmpty(Library.RootPath) ? "Select Root Folder" : Library.RootPath;
        }

        private void DoScan()
        {
            _scan_platforms = Scanner.ScanPlatforms(Library.RootPath);
            _scan_roms = new Dictionary<PlatformId, List<Rom>>();

            foreach (var scan_platform in _scan_platforms.Platforms)
            {
                ScanRoms(scan_platform);
            }
        }

        private void ScanRoms(Platform platform)
        {
            if (!_scan_roms.ContainsKey(platform.PlatformId))
            {
                _scan_roms.Add(platform.PlatformId, new List<Rom>());
            }

            var roms = Scanner.ScanRoms(platform);

            foreach (var rom in roms)
            {
                _scan_roms[platform.PlatformId].Add(rom);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if ((_scan_platforms == null || _scan_platforms.Platforms.Count == 0 && (_scan_roms == null || _scan_roms.Count == 0)))
            {
                Close();
                return;
            }

            foreach (var platform in _scan_platforms.Platforms)
            {
                if (!Library.ContainsPlatform(platform.PlatformId))
                {
                    Library.AddPlatform(platform);    
                }
            }

            foreach (var rom_key_pair in _scan_roms)
            {
                foreach (var rom in rom_key_pair.Value)
                {
                    Library.AddRom(rom);
                }
            }

            Library.Save();
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetectedPlatforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRomsPanel();
        }

        private void ListUnrecognized_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _platform_assign_context_menu.Show(listUnrecognized, e.X, e.Y);
            }
        }

        private void DetectedRoms_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _rom_context_menu.Show(detectedRoms, e.X, e.Y);    
            }
        }

        private void DetectedRoms_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                var selected_rom = (Rom) detectedRoms.SelectedObject;
                DeleteRomScanResult(selected_rom);
            }
        }
    }
}
