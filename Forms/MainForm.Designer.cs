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
            this.platformsPanel = new System.Windows.Forms.Panel();
            this.gbPlatforms = new System.Windows.Forms.GroupBox();
            this.platformsListMain = new BrightIdeasSoftware.ObjectListView();
            this.platNameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.scanRomsButton = new System.Windows.Forms.Button();
            this.romsListMain = new BrightIdeasSoftware.ObjectListView();
            this.nameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.platformCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timesPlayedCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.emulatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanRomsImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.romImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.comboViewStyle = new System.Windows.Forms.ComboBox();
            this.lblViewStyle = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.topPanelRight = new System.Windows.Forms.Panel();
            this.topPanelLeft = new System.Windows.Forms.Panel();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.platformsPanel.SuspendLayout();
            this.gbPlatforms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platformsListMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.romsListMain)).BeginInit();
            this.topMenu.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.topPanelRight.SuspendLayout();
            this.topPanelLeft.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // platformsPanel
            // 
            this.platformsPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.platformsPanel.Controls.Add(this.gbPlatforms);
            this.platformsPanel.Controls.Add(this.scanRomsButton);
            this.platformsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.platformsPanel.Location = new System.Drawing.Point(10, 34);
            this.platformsPanel.Name = "platformsPanel";
            this.platformsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.platformsPanel.Size = new System.Drawing.Size(200, 685);
            this.platformsPanel.TabIndex = 0;
            // 
            // gbPlatforms
            // 
            this.gbPlatforms.Controls.Add(this.platformsListMain);
            this.gbPlatforms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPlatforms.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPlatforms.ForeColor = System.Drawing.Color.White;
            this.gbPlatforms.Location = new System.Drawing.Point(5, 5);
            this.gbPlatforms.Name = "gbPlatforms";
            this.gbPlatforms.Size = new System.Drawing.Size(190, 649);
            this.gbPlatforms.TabIndex = 3;
            this.gbPlatforms.TabStop = false;
            this.gbPlatforms.Text = "Platforms";
            // 
            // platformsListMain
            // 
            this.platformsListMain.AllColumns.Add(this.platNameCol);
            this.platformsListMain.BackColor = System.Drawing.SystemColors.HotTrack;
            this.platformsListMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.platformsListMain.CellEditUseWholeCell = false;
            this.platformsListMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.platNameCol});
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
            this.platformsListMain.Size = new System.Drawing.Size(184, 627);
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
            // platNameCol
            // 
            this.platNameCol.AspectName = "Name";
            this.platNameCol.FillsFreeSpace = true;
            this.platNameCol.Width = 109;
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
            this.scanRomsButton.Location = new System.Drawing.Point(5, 654);
            this.scanRomsButton.Name = "scanRomsButton";
            this.scanRomsButton.Size = new System.Drawing.Size(190, 26);
            this.scanRomsButton.TabIndex = 0;
            this.scanRomsButton.Text = "SCAN ROMS";
            this.scanRomsButton.UseVisualStyleBackColor = false;
            this.scanRomsButton.Click += new System.EventHandler(this.ScanRomsButton_Click);
            // 
            // romsListMain
            // 
            this.romsListMain.AllColumns.Add(this.nameCol);
            this.romsListMain.AllColumns.Add(this.platformCol);
            this.romsListMain.AllColumns.Add(this.timesPlayedCol);
            this.romsListMain.BackColor = System.Drawing.SystemColors.HotTrack;
            this.romsListMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.romsListMain.CellEditUseWholeCell = false;
            this.romsListMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.platformCol,
            this.timesPlayedCol});
            this.romsListMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.romsListMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.romsListMain.EmptyListMsg = "";
            this.romsListMain.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.romsListMain.ForeColor = System.Drawing.Color.White;
            this.romsListMain.FullRowSelect = true;
            this.romsListMain.HideSelection = false;
            this.romsListMain.Location = new System.Drawing.Point(5, 5);
            this.romsListMain.MultiSelect = false;
            this.romsListMain.Name = "romsListMain";
            this.romsListMain.RowHeight = 30;
            this.romsListMain.SelectedBackColor = System.Drawing.Color.Violet;
            this.romsListMain.SelectedForeColor = System.Drawing.Color.Black;
            this.romsListMain.ShowFilterMenuOnRightClick = false;
            this.romsListMain.ShowGroups = false;
            this.romsListMain.Size = new System.Drawing.Size(778, 621);
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
            // nameCol
            // 
            this.nameCol.AspectName = "Name";
            this.nameCol.FillsFreeSpace = true;
            this.nameCol.Text = "Name";
            this.nameCol.Width = 579;
            // 
            // platformCol
            // 
            this.platformCol.AspectName = "PlatformId";
            this.platformCol.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.platformCol.Text = "Platform";
            this.platformCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.platformCol.Width = 86;
            // 
            // timesPlayedCol
            // 
            this.timesPlayedCol.AspectName = "TimesPlayed";
            this.timesPlayedCol.IsEditable = false;
            this.timesPlayedCol.Searchable = false;
            this.timesPlayedCol.Text = "Times Played";
            this.timesPlayedCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timesPlayedCol.ToolTipText = "How many times this rom was launched";
            this.timesPlayedCol.Width = 100;
            // 
            // topMenu
            // 
            this.topMenu.BackColor = System.Drawing.Color.GhostWhite;
            this.topMenu.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulatorsToolStripMenuItem,
            this.libraryToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(10, 10);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(988, 24);
            this.topMenu.TabIndex = 3;
            this.topMenu.Text = "menuStrip1";
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
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtSearch.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(69, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(487, 23);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(6, 20);
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
            this.comboViewStyle.Location = new System.Drawing.Point(102, 17);
            this.comboViewStyle.Name = "comboViewStyle";
            this.comboViewStyle.Size = new System.Drawing.Size(121, 24);
            this.comboViewStyle.TabIndex = 6;
            this.comboViewStyle.SelectedValueChanged += new System.EventHandler(this.ComboViewStyle_SelectedValueChanged);
            // 
            // lblViewStyle
            // 
            this.lblViewStyle.AutoSize = true;
            this.lblViewStyle.Font = new System.Drawing.Font("Input", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewStyle.ForeColor = System.Drawing.Color.White;
            this.lblViewStyle.Location = new System.Drawing.Point(11, 20);
            this.lblViewStyle.Name = "lblViewStyle";
            this.lblViewStyle.Size = new System.Drawing.Size(85, 16);
            this.lblViewStyle.TabIndex = 7;
            this.lblViewStyle.Text = "View Style:";
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.topPanelLeft);
            this.topPanel.Controls.Add(this.topPanelRight);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(210, 34);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(788, 54);
            this.topPanel.TabIndex = 8;
            // 
            // topPanelRight
            // 
            this.topPanelRight.Controls.Add(this.lblViewStyle);
            this.topPanelRight.Controls.Add(this.comboViewStyle);
            this.topPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.topPanelRight.Location = new System.Drawing.Point(562, 0);
            this.topPanelRight.Name = "topPanelRight";
            this.topPanelRight.Size = new System.Drawing.Size(226, 54);
            this.topPanelRight.TabIndex = 6;
            // 
            // topPanelLeft
            // 
            this.topPanelLeft.Controls.Add(this.lblSearch);
            this.topPanelLeft.Controls.Add(this.txtSearch);
            this.topPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.topPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.topPanelLeft.Name = "topPanelLeft";
            this.topPanelLeft.Size = new System.Drawing.Size(562, 54);
            this.topPanelLeft.TabIndex = 7;
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.romsListMain);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(210, 88);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new System.Windows.Forms.Padding(5);
            this.centerPanel.Size = new System.Drawing.Size(788, 631);
            this.centerPanel.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.platformsPanel);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROMZOOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.platformsPanel.ResumeLayout(false);
            this.gbPlatforms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.platformsListMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.romsListMain)).EndInit();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanelRight.ResumeLayout(false);
            this.topPanelRight.PerformLayout();
            this.topPanelLeft.ResumeLayout(false);
            this.topPanelLeft.PerformLayout();
            this.centerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel platformsPanel;
        private System.Windows.Forms.Button scanRomsButton;
        private System.Windows.Forms.GroupBox gbPlatforms;
        private BrightIdeasSoftware.ObjectListView romsListMain;
        private BrightIdeasSoftware.OLVColumn nameCol;
        private BrightIdeasSoftware.OLVColumn timesPlayedCol;
        private BrightIdeasSoftware.ObjectListView platformsListMain;
        private BrightIdeasSoftware.OLVColumn platNameCol;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem emulatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private BrightIdeasSoftware.OLVColumn platformCol;
        private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanRomsImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eraseEverythingToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog romImageFileDialog;
        private System.Windows.Forms.ComboBox comboViewStyle;
        private System.Windows.Forms.Label lblViewStyle;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel topPanelLeft;
        private System.Windows.Forms.Panel topPanelRight;
        private System.Windows.Forms.Panel centerPanel;
    }
}

