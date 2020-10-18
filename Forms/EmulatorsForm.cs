using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ROMZOOM.Model;

namespace ROMZOOM.Forms
{
    public partial class EmulatorsForm : Form
    {
        private readonly List<Emulator> emulators;

        public EmulatorsForm()
        {
            InitializeComponent();
            emulators = new List<Emulator>();
        }

        private void BtnAddEmu_Click(object sender, EventArgs e)
        {
            if (chooseEmuExeDialog.ShowDialog() == DialogResult.OK)
            {
                AddEmulator(chooseEmuExeDialog.FileName);
            }
        }

        private void AddEmulator(string path)
        {
            var emulator = new Emulator();

            FillEmuData(emulator, path);

            emulators.Add(emulator);

            UpdateEmuListView();

            emulatorsList.SelectedObject = emulator;
        }

        private void UpdateEmuPath(Emulator emulator, string path)
        {
            FillEmuData(emulator, path);

            UpdateEmuListView();

            emulatorsList.SelectedObject = emulator;
        }

       

        private void UpdateEmuListView()
        {
            emulatorsList.SetObjects(emulators);
        }

        private void UpdateEmuPropertiesView()
        {
            if (emulators.Count > 0)
            {
                if (emulatorsList.SelectedObject != null)
                {
                    var selected_emu = (Emulator) emulatorsList.SelectedObject;

                    txtEmuName.Text = selected_emu.Name;
                    txtEmuPath.Text = selected_emu.Path;
                    argsListBox.SetObjects(selected_emu.LaunchArgs);
                }
               
            }
            else
            {
                emulatorsList.ClearObjects();
                txtEmuName.Text = string.Empty;
                txtEmuPath.Text = string.Empty;
                argsListBox.ClearObjects();
            }
            
        }

        private static void FillEmuData(Emulator emulator, string path)
        {
            if (path.ToLower().Contains("retroarch.exe"))
            {
                FillRetroArch(emulator, path);
            }
            else
            {
                FillMisc(emulator, path);
            }
            
        }

        private static void FillRetroArch(Emulator emu, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return ;
            }

            var folder_path = Path.GetDirectoryName(path);

            emu.Name = "RetroArch";
            emu.Path = path;


            var cores_dir = new DirectoryInfo(Path.Combine(folder_path, "cores"));

            emu.LaunchArgs.Clear();

            foreach (var core_file in cores_dir.EnumerateFiles())
            {
                var launch_arg = new LaunchArg(Path.GetFileNameWithoutExtension(core_file.Name),$"-L cores\\{core_file.Name} %rom%");

                emu.LaunchArgs.Add(launch_arg.Uid, launch_arg);
            }
        }

        private static void FillMisc(Emulator emu, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            emu.Name = Path.GetFileNameWithoutExtension(path);
            emu.Path = path;

            emu.LaunchArgs.Clear();

            var launch_arg = new LaunchArg("LaunchArg",$"%rom%");

            emu.LaunchArgs.Add(launch_arg.Uid, launch_arg);
        }

        private void BtnEmuPathChoose_Click(object sender, EventArgs e)
        {
            if (chooseEmuExeDialog.ShowDialog() == DialogResult.OK)
            {
                var selected_emu = (Emulator) emulatorsList.SelectedItem.RowObject;

                UpdateEmuPath(selected_emu, chooseEmuExeDialog.FileName);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (var emulator in emulators)
            {
                if (!Library.Emulators.ContainsKey(emulator.Uid))
                {
                    Library.AddEmulator(emulator);
                }
                else
                {
                    Library.Emulators[emulator.Uid].Name = emulator.Name;
                    Library.Emulators[emulator.Uid].Path = emulator.Path;
                    Library.Emulators[emulator.Uid].LaunchArgs = emulator.LaunchArgs;

                }
            }

            Library.MarkDirty();

            Library.Save();

            Close();
        }

        private void EmulatorsForm_Load(object sender, EventArgs e)
        {

            foreach (var emulator in Library.Emulators)
            {
                emulators.Add(new Emulator(emulator.Value));
            }

            UpdateEmuListView();

            emulatorsList.SelectedIndex = 0;

        }

        private void EmulatorsList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateEmuPropertiesView();
        }

        private void ArgsListBox_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            var selected_emu = (Emulator)emulatorsList.SelectedObject;
            var launch_arg_id = ((KeyValuePair<int, LaunchArg>) (e.RowObject)).Key;
            selected_emu.LaunchArgs[launch_arg_id].Arg = (string) e.NewValue;

            
        }

        private void TxtEmuName_TextChanged(object sender, EventArgs e)
        {
            var selected_emu = (Emulator)emulatorsList.SelectedObject;

            if (!string.IsNullOrEmpty(txtEmuName.Text))
            {
                selected_emu.Name = txtEmuName.Text;    
                emulatorsList.RefreshSelectedObjects();
            }
        }
    }
}
