namespace ROMZOOM.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.platformsPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.platformsListMain = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.scanRomsButton = new System.Windows.Forms.Button();
            this.romsListMain = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.emulatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanRomsImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.romImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.comboViewStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.platformsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platformsListMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.romsListMain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // platformsPanel
            // 
            this.platformsPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.platformsPanel.Controls.Add(this.groupBox1);
            this.platformsPanel.Controls.Add(this.scanRomsButton);
            this.platformsPanel.Location = new System.Drawing.Point(13, 47);
            this.platformsPanel.Name = "platformsPanel";
            this.platformsPanel.Size = new System.Drawing.Size(200, 672);
            this.platformsPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.platformsListMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 646);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Platforms";
            // 
            // platformsListMain
            // 
            this.platformsListMain.AllColumns.Add(this.olvColumn3);
            this.platformsListMain.AllColumns.Add(this.olvColumn4);
            this.platformsListMain.BackColor = System.Drawing.SystemColors.HotTrack;
            this.platformsListMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.platformsListMain.CellEditUseWholeCell = false;
            this.platformsListMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3,
            this.olvColumn4});
            this.platformsListMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.platformsListMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.platformsListMain.ForeColor = System.Drawing.Color.White;
            this.platformsListMain.FullRowSelect = true;
            this.platformsListMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.platformsListMain.HideSelection = false;
            this.platformsListMain.Location = new System.Drawing.Point(3, 19);
            this.platformsListMain.MultiSelect = false;
            this.platformsListMain.Name = "platformsListMain";
            this.platformsListMain.RowHeight = 30;
            this.platformsListMain.SelectedBackColor = System.Drawing.Color.Violet;
            this.platformsListMain.SelectedForeColor = System.Drawing.Color.Black;
            this.platformsListMain.ShowGroups = false;
            this.platformsListMain.Size = new System.Drawing.Size(194, 624);
            this.platformsListMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.platformsListMain.TabIndex = 0;
            this.platformsListMain.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.platformsListMain.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.platformsListMain.UseCompatibleStateImageBehavior = false;
            this.platformsListMain.UseHotItem = true;
            this.platformsListMain.View = System.Windows.Forms.View.Details;
            this.platformsListMain.SelectionChanged += new System.EventHandler(this.PlatformsListMain_SelectionChanged);
            this.platformsListMain.DoubleClick += new System.EventHandler(this.PlatformsListMain_DoubleClick);
            this.platformsListMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlatformsListMain_MouseClick);
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Name";
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.Width = 109;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Emu";
            this.olvColumn4.IsButton = true;
            // 
            // scanRomsButton
            // 
            this.scanRomsButton.BackColor = System.Drawing.Color.SlateBlue;
            this.scanRomsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scanRomsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.scanRomsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.scanRomsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scanRomsButton.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanRomsButton.ForeColor = System.Drawing.Color.White;
            this.scanRomsButton.Location = new System.Drawing.Point(0, 646);
            this.scanRomsButton.Name = "scanRomsButton";
            this.scanRomsButton.Size = new System.Drawing.Size(200, 26);
            this.scanRomsButton.TabIndex = 0;
            this.scanRomsButton.Text = "SCAN ROMS";
            this.scanRomsButton.UseVisualStyleBackColor = false;
            this.scanRomsButton.Click += new System.EventHandler(this.ScanRomsButton_Click);
            // 
            // romsListMain
            // 
            this.romsListMain.AllColumns.Add(this.olvColumn1);
            this.romsListMain.AllColumns.Add(this.olvColumn5);
            this.romsListMain.AllColumns.Add(this.olvColumn2);
            this.romsListMain.BackColor = System.Drawing.SystemColors.HotTrack;
            this.romsListMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.romsListMain.CellEditUseWholeCell = false;
            this.romsListMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn5,
            this.olvColumn2});
            this.romsListMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.romsListMain.EmptyListMsg = "";
            this.romsListMain.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.romsListMain.ForeColor = System.Drawing.Color.White;
            this.romsListMain.FullRowSelect = true;
            this.romsListMain.HideSelection = false;
            this.romsListMain.Location = new System.Drawing.Point(219, 95);
            this.romsListMain.MultiSelect = false;
            this.romsListMain.Name = "romsListMain";
            this.romsListMain.RowHeight = 30;
            this.romsListMain.SelectedBackColor = System.Drawing.Color.Violet;
            this.romsListMain.SelectedForeColor = System.Drawing.Color.Black;
            this.romsListMain.ShowFilterMenuOnRightClick = false;
            this.romsListMain.ShowGroups = false;
            this.romsListMain.Size = new System.Drawing.Size(776, 624);
            this.romsListMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.romsListMain.TabIndex = 2;
            this.romsListMain.UnfocusedSelectedBackColor = System.Drawing.Color.Violet;
            this.romsListMain.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.romsListMain.UseCompatibleStateImageBehavior = false;
            this.romsListMain.UseFiltering = true;
            this.romsListMain.UseHotItem = true;
            this.romsListMain.View = System.Windows.Forms.View.Details;
            this.romsListMain.DoubleClick += new System.EventHandler(this.RomsListMain_DoubleClick);
            this.romsListMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RomsListMain_MouseClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.FillsFreeSpace = true;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 582;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "PlatformId";
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Text = "Platform";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 94;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "TimesPlayed";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Searchable = false;
            this.olvColumn2.Text = "Times Played";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.ToolTipText = "How many times this rom was launched";
            this.olvColumn2.Width = 100;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.GhostWhite;
            this.menuStrip1.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulatorsToolStripMenuItem,
            this.libraryToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(10, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(988, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // emulatorsToolStripMenuItem
            // 
            this.emulatorsToolStripMenuItem.Name = "emulatorsToolStripMenuItem";
            this.emulatorsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.emulatorsToolStripMenuItem.Text = "Emulators";
            this.emulatorsToolStripMenuItem.Click += new System.EventHandler(this.EmulatorsToolStripMenuItem_Click);
            // 
            // libraryToolStripMenuItem
            // 
            this.libraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanRomsImagesToolStripMenuItem,
            this.eraseEverythingToolStripMenuItem});
            this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
            this.libraryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.libraryToolStripMenuItem.Text = "Library";
            // 
            // scanRomsImagesToolStripMenuItem
            // 
            this.scanRomsImagesToolStripMenuItem.Name = "scanRomsImagesToolStripMenuItem";
            this.scanRomsImagesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.scanRomsImagesToolStripMenuItem.Text = "Scan Roms Images";
            // 
            // eraseEverythingToolStripMenuItem
            // 
            this.eraseEverythingToolStripMenuItem.Name = "eraseEverythingToolStripMenuItem";
            this.eraseEverythingToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.eraseEverythingToolStripMenuItem.Text = "Erase Everything";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.GhostWhite;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtSearch.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(282, 63);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(366, 23);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(219, 66);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(57, 16);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Search:";
            // 
            // romImageFileDialog
            // 
            this.romImageFileDialog.FileName = "openFileDialog1";
            // 
            // comboViewStyle
            // 
            this.comboViewStyle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.comboViewStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboViewStyle.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboViewStyle.ForeColor = System.Drawing.Color.White;
            this.comboViewStyle.FormattingEnabled = true;
            this.comboViewStyle.Location = new System.Drawing.Point(874, 63);
            this.comboViewStyle.Name = "comboViewStyle";
            this.comboViewStyle.Size = new System.Drawing.Size(121, 24);
            this.comboViewStyle.TabIndex = 6;
            this.comboViewStyle.SelectedValueChanged += new System.EventHandler(this.ComboViewStyle_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(783, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "View Style:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboViewStyle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.romsListMain);
            this.Controls.Add(this.platformsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROMZOOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.platformsPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.platformsListMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.romsListMain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel platformsPanel;
        private System.Windows.Forms.Button scanRomsButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private BrightIdeasSoftware.ObjectListView romsListMain;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.ObjectListView platformsListMain;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem emulatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanRomsImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eraseEverythingToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog romImageFileDialog;
        private System.Windows.Forms.ComboBox comboViewStyle;
        private System.Windows.Forms.Label label1;
    }
}

