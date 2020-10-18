using System;
using System.Windows.Forms;
using ROMZOOM.Components;
using ROMZOOM.Model;

namespace ROMZOOM.Forms
{
    public partial class PlatformPropertiesDialog : Form
    {
        private PlatformId _platform_id;
        private string _name;
        private string _path;
        private int _assigned_emu_id;
        private int _assigned_launch_arg_id;

        private readonly EmuAssignContextMenu _emu_assign_context_menu;

        public PlatformPropertiesDialog()
        {

            InitializeComponent();

            _emu_assign_context_menu = new EmuAssignContextMenu(Library.Emulators, OnEmuContextMenuItemSelected);
        }

        private void OnEmuContextMenuItemSelected(ZoomContextMenuItem item)
        {
            _assigned_emu_id = (int) item.Tag1;
            _assigned_launch_arg_id = (int) item.Tag2;

            UpdateEmuBtnLabel();
        }

        public void Show(PlatformId platform_id)
        {
            _platform_id = platform_id;

            var platform = Library.Platforms[platform_id];

            _name = platform.Name;
            _path = platform.Path;
            _assigned_emu_id = platform.EmulatorId;
            _assigned_launch_arg_id = platform.LaunchArgId;
            base.Show();
        }

        private void PlatformPropertiesDialog_Load(object sender, EventArgs e)
        {
            btnEmulator.Click += BtnEmulatorOnClick;

            txtName.Text = _name;
            txtPath.Text = _path;

            UpdateEmuBtnLabel();
        }

        private void UpdateEmuBtnLabel()
        {
            if (_assigned_emu_id != 0)
            {
                var emu = Library.Emulators[_assigned_emu_id];

                btnEmulator.Text = $"{ emu.Name} ({ emu.LaunchArgs[_assigned_launch_arg_id].Name })";
            }
            else
            {
                btnEmulator.Text = "Assign...";
            }
        }

        private void BtnEmulatorOnClick(object sender, EventArgs e)
        {
            _emu_assign_context_menu.Show(btnEmulator, 0, 0);
        }

        private void PlatformPropertiesDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdatePlatformName();

            Library.Platforms[_platform_id].Name = _name;
            Library.Platforms[_platform_id].EmulatorId = _assigned_emu_id;
            Library.Platforms[_platform_id].LaunchArgId = _assigned_launch_arg_id;

            Library.MarkDirty();

        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            UpdatePlatformName();
        }

        private void UpdatePlatformName()
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _name = txtName.Text;
            }
        }
    }
}
