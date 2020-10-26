namespace ROMZOOM.Forms
{
    partial class RomScanForm
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
            this.chooseScanFolderBtn = new System.Windows.Forms.Button();
            this.scanBtn = new System.Windows.Forms.Button();
            this.libFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.scanProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.detectedPlatforms = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.detectedRoms = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.baseRenderer1 = new BrightIdeasSoftware.BaseRenderer();
            this.gbUnrecognized = new System.Windows.Forms.GroupBox();
            this.listUnrecognized = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detectedPlatforms)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detectedRoms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbUnrecognized.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listUnrecognized)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseScanFolderBtn
            // 
            this.chooseScanFolderBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.chooseScanFolderBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.chooseScanFolderBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.chooseScanFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseScanFolderBtn.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseScanFolderBtn.ForeColor = System.Drawing.Color.White;
            this.chooseScanFolderBtn.Location = new System.Drawing.Point(12, 12);
            this.chooseScanFolderBtn.Name = "chooseScanFolderBtn";
            this.chooseScanFolderBtn.Size = new System.Drawing.Size(635, 23);
            this.chooseScanFolderBtn.TabIndex = 0;
            this.chooseScanFolderBtn.Text = "...";
            this.chooseScanFolderBtn.UseVisualStyleBackColor = false;
            this.chooseScanFolderBtn.Click += new System.EventHandler(this.ChooseScanFolderBtn_Click);
            // 
            // scanBtn
            // 
            this.scanBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.scanBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.scanBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.scanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scanBtn.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.ForeColor = System.Drawing.Color.White;
            this.scanBtn.Location = new System.Drawing.Point(653, 12);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(119, 23);
            this.scanBtn.TabIndex = 1;
            this.scanBtn.Text = "SCAN";
            this.scanBtn.UseVisualStyleBackColor = false;
            this.scanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // scanProgressBar
            // 
            this.scanProgressBar.Location = new System.Drawing.Point(12, 41);
            this.scanProgressBar.Name = "scanProgressBar";
            this.scanProgressBar.Size = new System.Drawing.Size(760, 10);
            this.scanProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.scanProgressBar.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.detectedPlatforms);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 317);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detected Platforms";
            // 
            // detectedPlatforms
            // 
            this.detectedPlatforms.AllColumns.Add(this.olvColumn1);
            this.detectedPlatforms.BackColor = System.Drawing.SystemColors.HotTrack;
            this.detectedPlatforms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detectedPlatforms.CellEditUseWholeCell = false;
            this.detectedPlatforms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.detectedPlatforms.Cursor = System.Windows.Forms.Cursors.Default;
            this.detectedPlatforms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectedPlatforms.ForeColor = System.Drawing.Color.White;
            this.detectedPlatforms.FullRowSelect = true;
            this.detectedPlatforms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.detectedPlatforms.HideSelection = false;
            this.detectedPlatforms.Location = new System.Drawing.Point(3, 19);
            this.detectedPlatforms.Name = "detectedPlatforms";
            this.detectedPlatforms.RowHeight = 30;
            this.detectedPlatforms.SelectedBackColor = System.Drawing.Color.Violet;
            this.detectedPlatforms.SelectedForeColor = System.Drawing.Color.Black;
            this.detectedPlatforms.ShowGroups = false;
            this.detectedPlatforms.Size = new System.Drawing.Size(267, 295);
            this.detectedPlatforms.TabIndex = 0;
            this.detectedPlatforms.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.detectedPlatforms.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.detectedPlatforms.UseCompatibleStateImageBehavior = false;
            this.detectedPlatforms.View = System.Windows.Forms.View.Details;
            this.detectedPlatforms.SelectedIndexChanged += new System.EventHandler(this.DetectedPlatforms_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.FillsFreeSpace = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.detectedRoms);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 317);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Roms";
            // 
            // detectedRoms
            // 
            this.detectedRoms.AllColumns.Add(this.olvColumn2);
            this.detectedRoms.BackColor = System.Drawing.SystemColors.HotTrack;
            this.detectedRoms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detectedRoms.CellEditUseWholeCell = false;
            this.detectedRoms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2});
            this.detectedRoms.Cursor = System.Windows.Forms.Cursors.Default;
            this.detectedRoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectedRoms.ForeColor = System.Drawing.Color.White;
            this.detectedRoms.FullRowSelect = true;
            this.detectedRoms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.detectedRoms.HideSelection = false;
            this.detectedRoms.Location = new System.Drawing.Point(3, 19);
            this.detectedRoms.Name = "detectedRoms";
            this.detectedRoms.RowHeight = 30;
            this.detectedRoms.SelectedBackColor = System.Drawing.Color.Violet;
            this.detectedRoms.SelectedForeColor = System.Drawing.Color.Black;
            this.detectedRoms.ShowGroups = false;
            this.detectedRoms.Size = new System.Drawing.Size(477, 295);
            this.detectedRoms.TabIndex = 0;
            this.detectedRoms.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.detectedRoms.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.detectedRoms.UseCompatibleStateImageBehavior = false;
            this.detectedRoms.View = System.Windows.Forms.View.Details;
            this.detectedRoms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetectedRoms_KeyDown);
            this.detectedRoms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DetectedRoms_MouseClick);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.FillsFreeSpace = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(653, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(760, 317);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Input", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(572, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "CANCEL";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gbUnrecognized
            // 
            this.gbUnrecognized.Controls.Add(this.listUnrecognized);
            this.gbUnrecognized.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUnrecognized.ForeColor = System.Drawing.SystemColors.Control;
            this.gbUnrecognized.Location = new System.Drawing.Point(12, 380);
            this.gbUnrecognized.Name = "gbUnrecognized";
            this.gbUnrecognized.Size = new System.Drawing.Size(760, 135);
            this.gbUnrecognized.TabIndex = 11;
            this.gbUnrecognized.TabStop = false;
            this.gbUnrecognized.Text = "Unrecognized";
            // 
            // listUnrecognized
            // 
            this.listUnrecognized.AllColumns.Add(this.olvColumn3);
            this.listUnrecognized.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listUnrecognized.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listUnrecognized.CellEditUseWholeCell = false;
            this.listUnrecognized.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3});
            this.listUnrecognized.Cursor = System.Windows.Forms.Cursors.Default;
            this.listUnrecognized.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUnrecognized.ForeColor = System.Drawing.Color.White;
            this.listUnrecognized.FullRowSelect = true;
            this.listUnrecognized.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listUnrecognized.HideSelection = false;
            this.listUnrecognized.Location = new System.Drawing.Point(3, 19);
            this.listUnrecognized.MultiSelect = false;
            this.listUnrecognized.Name = "listUnrecognized";
            this.listUnrecognized.SelectedBackColor = System.Drawing.Color.Violet;
            this.listUnrecognized.SelectedForeColor = System.Drawing.Color.Black;
            this.listUnrecognized.ShowGroups = false;
            this.listUnrecognized.Size = new System.Drawing.Size(754, 113);
            this.listUnrecognized.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listUnrecognized.TabIndex = 0;
            this.listUnrecognized.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.listUnrecognized.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.listUnrecognized.UseCompatibleStateImageBehavior = false;
            this.listUnrecognized.View = System.Windows.Forms.View.Details;
            this.listUnrecognized.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListUnrecognized_MouseClick);
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "FullName";
            this.olvColumn3.FillsFreeSpace = true;
            // 
            // RomScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gbUnrecognized);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.scanProgressBar);
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.chooseScanFolderBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "RomScanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rom Scan";
            this.Load += new System.EventHandler(this.LibraryForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detectedPlatforms)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detectedRoms)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbUnrecognized.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listUnrecognized)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chooseScanFolderBtn;
        private System.Windows.Forms.Button scanBtn;
        private System.Windows.Forms.FolderBrowserDialog libFolderBrowserDialog;
        private System.Windows.Forms.ProgressBar scanProgressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.ObjectListView detectedPlatforms;
        private BrightIdeasSoftware.ObjectListView detectedRoms;
        private System.Windows.Forms.Button btnClose;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.BaseRenderer baseRenderer1;
        private System.Windows.Forms.GroupBox gbUnrecognized;
        private BrightIdeasSoftware.ObjectListView listUnrecognized;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
    }
}