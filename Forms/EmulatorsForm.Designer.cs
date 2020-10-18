namespace ROMZOOM.Forms
{
    partial class EmulatorsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.emulatorsGb = new System.Windows.Forms.GroupBox();
            this.emulatorsList = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnAddEmu = new System.Windows.Forms.Button();
            this.emuPropsGb = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblExe = new System.Windows.Forms.Label();
            this.lblLaunchArgs = new System.Windows.Forms.Label();
            this.txtEmuName = new System.Windows.Forms.TextBox();
            this.txtEmuPath = new System.Windows.Forms.TextBox();
            this.btnEmuPathChoose = new System.Windows.Forms.Button();
            this.argsListBox = new BrightIdeasSoftware.ObjectListView();
            this.nameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.argCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.chooseEmuExeDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.emulatorsGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emulatorsList)).BeginInit();
            this.emuPropsGb.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.argsListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.emulatorsGb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.emuPropsGb);
            this.splitContainer1.Size = new System.Drawing.Size(764, 500);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 0;
            // 
            // emulatorsGb
            // 
            this.emulatorsGb.Controls.Add(this.emulatorsList);
            this.emulatorsGb.Controls.Add(this.btnAddEmu);
            this.emulatorsGb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emulatorsGb.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emulatorsGb.ForeColor = System.Drawing.Color.White;
            this.emulatorsGb.Location = new System.Drawing.Point(0, 0);
            this.emulatorsGb.Name = "emulatorsGb";
            this.emulatorsGb.Size = new System.Drawing.Size(231, 500);
            this.emulatorsGb.TabIndex = 0;
            this.emulatorsGb.TabStop = false;
            this.emulatorsGb.Text = "Emulators";
            // 
            // emulatorsList
            // 
            this.emulatorsList.AllColumns.Add(this.olvColumn1);
            this.emulatorsList.BackColor = System.Drawing.SystemColors.HotTrack;
            this.emulatorsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emulatorsList.CellEditUseWholeCell = false;
            this.emulatorsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.emulatorsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.emulatorsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emulatorsList.ForeColor = System.Drawing.Color.White;
            this.emulatorsList.FullRowSelect = true;
            this.emulatorsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.emulatorsList.HideSelection = false;
            this.emulatorsList.Location = new System.Drawing.Point(3, 19);
            this.emulatorsList.MultiSelect = false;
            this.emulatorsList.Name = "emulatorsList";
            this.emulatorsList.SelectedBackColor = System.Drawing.Color.Violet;
            this.emulatorsList.SelectedForeColor = System.Drawing.Color.White;
            this.emulatorsList.ShowGroups = false;
            this.emulatorsList.Size = new System.Drawing.Size(225, 451);
            this.emulatorsList.TabIndex = 1;
            this.emulatorsList.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.emulatorsList.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.emulatorsList.UseCompatibleStateImageBehavior = false;
            this.emulatorsList.View = System.Windows.Forms.View.Details;
            this.emulatorsList.SelectionChanged += new System.EventHandler(this.EmulatorsList_SelectionChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.FillsFreeSpace = true;
            // 
            // btnAddEmu
            // 
            this.btnAddEmu.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAddEmu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddEmu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnAddEmu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnAddEmu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmu.Location = new System.Drawing.Point(3, 470);
            this.btnAddEmu.Name = "btnAddEmu";
            this.btnAddEmu.Size = new System.Drawing.Size(225, 27);
            this.btnAddEmu.TabIndex = 0;
            this.btnAddEmu.Text = "ADD EMULATOR";
            this.btnAddEmu.UseVisualStyleBackColor = false;
            this.btnAddEmu.Click += new System.EventHandler(this.BtnAddEmu_Click);
            // 
            // emuPropsGb
            // 
            this.emuPropsGb.Controls.Add(this.tableLayoutPanel1);
            this.emuPropsGb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emuPropsGb.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emuPropsGb.ForeColor = System.Drawing.Color.White;
            this.emuPropsGb.Location = new System.Drawing.Point(0, 0);
            this.emuPropsGb.Name = "emuPropsGb";
            this.emuPropsGb.Size = new System.Drawing.Size(529, 500);
            this.emuPropsGb.TabIndex = 0;
            this.emuPropsGb.TabStop = false;
            this.emuPropsGb.Text = "Properties";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.32961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.67039F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblExe, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLaunchArgs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEmuName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEmuPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEmuPathChoose, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.argsListBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 478);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblExe
            // 
            this.lblExe.AutoSize = true;
            this.lblExe.Location = new System.Drawing.Point(3, 30);
            this.lblExe.Name = "lblExe";
            this.lblExe.Size = new System.Drawing.Size(71, 16);
            this.lblExe.TabIndex = 1;
            this.lblExe.Text = "EXE Path:";
            // 
            // lblLaunchArgs
            // 
            this.lblLaunchArgs.AutoSize = true;
            this.lblLaunchArgs.Location = new System.Drawing.Point(3, 60);
            this.lblLaunchArgs.Name = "lblLaunchArgs";
            this.lblLaunchArgs.Size = new System.Drawing.Size(92, 16);
            this.lblLaunchArgs.TabIndex = 2;
            this.lblLaunchArgs.Text = "Launch Args:";
            // 
            // txtEmuName
            // 
            this.txtEmuName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtEmuName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmuName.ForeColor = System.Drawing.Color.White;
            this.txtEmuName.Location = new System.Drawing.Point(137, 3);
            this.txtEmuName.Name = "txtEmuName";
            this.txtEmuName.Size = new System.Drawing.Size(317, 23);
            this.txtEmuName.TabIndex = 3;
            this.txtEmuName.TextChanged += new System.EventHandler(this.TxtEmuName_TextChanged);
            // 
            // txtEmuPath
            // 
            this.txtEmuPath.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtEmuPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmuPath.ForeColor = System.Drawing.Color.White;
            this.txtEmuPath.Location = new System.Drawing.Point(137, 33);
            this.txtEmuPath.Name = "txtEmuPath";
            this.txtEmuPath.Size = new System.Drawing.Size(317, 23);
            this.txtEmuPath.TabIndex = 4;
            // 
            // btnEmuPathChoose
            // 
            this.btnEmuPathChoose.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnEmuPathChoose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnEmuPathChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnEmuPathChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmuPathChoose.Location = new System.Drawing.Point(460, 33);
            this.btnEmuPathChoose.Name = "btnEmuPathChoose";
            this.btnEmuPathChoose.Size = new System.Drawing.Size(39, 23);
            this.btnEmuPathChoose.TabIndex = 5;
            this.btnEmuPathChoose.Text = "...";
            this.btnEmuPathChoose.UseVisualStyleBackColor = false;
            this.btnEmuPathChoose.Click += new System.EventHandler(this.BtnEmuPathChoose_Click);
            // 
            // argsListBox
            // 
            this.argsListBox.AllColumns.Add(this.nameCol);
            this.argsListBox.AllColumns.Add(this.argCol);
            this.argsListBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.argsListBox.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.argsListBox.CellEditEnterChangesRows = true;
            this.argsListBox.CellEditTabChangesRows = true;
            this.argsListBox.CellEditUseWholeCell = false;
            this.argsListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.argCol});
            this.tableLayoutPanel1.SetColumnSpan(this.argsListBox, 3);
            this.argsListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.argsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.argsListBox.ForeColor = System.Drawing.Color.White;
            this.argsListBox.FullRowSelect = true;
            this.argsListBox.HideSelection = false;
            this.argsListBox.Location = new System.Drawing.Point(3, 93);
            this.argsListBox.MultiSelect = false;
            this.argsListBox.Name = "argsListBox";
            this.argsListBox.RowHeight = 20;
            this.argsListBox.SelectedBackColor = System.Drawing.Color.Violet;
            this.argsListBox.SelectedForeColor = System.Drawing.Color.Black;
            this.argsListBox.ShowGroups = false;
            this.argsListBox.Size = new System.Drawing.Size(517, 382);
            this.argsListBox.TabIndex = 6;
            this.argsListBox.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.argsListBox.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.argsListBox.UseCompatibleStateImageBehavior = false;
            this.argsListBox.View = System.Windows.Forms.View.Details;
            this.argsListBox.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.ArgsListBox_CellEditFinished);
            // 
            // nameCol
            // 
            this.nameCol.AspectName = "Value.Name";
            this.nameCol.Text = "Name";
            this.nameCol.Width = 95;
            // 
            // argCol
            // 
            this.argCol.AspectName = "Value.Arg";
            this.argCol.Text = "Args";
            this.argCol.Width = 271;
            // 
            // chooseEmuExeDialog
            // 
            this.chooseEmuExeDialog.Filter = "Applications|*.exe; *.cmd; *.bat";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(652, 516);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(564, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // EmulatorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "EmulatorsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Emulators";
            this.Load += new System.EventHandler(this.EmulatorsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.emulatorsGb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emulatorsList)).EndInit();
            this.emuPropsGb.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.argsListBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox emulatorsGb;
        private System.Windows.Forms.GroupBox emuPropsGb;
        private System.Windows.Forms.Button btnAddEmu;
        private BrightIdeasSoftware.ObjectListView emulatorsList;
        private System.Windows.Forms.OpenFileDialog chooseEmuExeDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblExe;
        private System.Windows.Forms.Label lblLaunchArgs;
        private System.Windows.Forms.TextBox txtEmuName;
        private System.Windows.Forms.TextBox txtEmuPath;
        private System.Windows.Forms.Button btnEmuPathChoose;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.ObjectListView argsListBox;
        private BrightIdeasSoftware.OLVColumn argCol;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private BrightIdeasSoftware.OLVColumn nameCol;
    }
}