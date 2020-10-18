using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMZOOM.Logic;
using ROMZOOM.Model;

namespace ROMZOOM.Forms
{
    public partial class RomScanForm : Form
    {
        private PlatformScanResult _scan_platforms;
        private Dictionary<PlatformId, List<Rom>> _scan_roms;

        public RomScanForm()
        {
            InitializeComponent();
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

        }

        private void PopulatePanels()
        {
            if (_scan_platforms.Platforms.Count > 0)
            {
                detectedPlatforms.SetObjects(_scan_platforms.Platforms);
                UpdateRomsPanel();
                detectedPlatforms.SelectedIndex = 0;
            }
        }

        private void UpdateRomsPanel()
        {
            if (detectedPlatforms.SelectedItem == null)
            {
                return;
            }

            detectedRoms.SetObjects(_scan_roms[((Platform)detectedPlatforms.SelectedItem.RowObject).PlatformId]);
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
                _scan_roms.Add(scan_platform.PlatformId, new List<Rom>());

                var roms = Scanner.ScanRoms(scan_platform);

                foreach (var rom in roms)
                {
                    _scan_roms[scan_platform.PlatformId].Add(rom);
                }
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
                Library.AddPlatform(platform);
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
    }
}
