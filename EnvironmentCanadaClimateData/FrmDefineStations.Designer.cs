namespace HAWKLORRY
{
    partial class FrmDefineStations
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbByName = new System.Windows.Forms.TabPage();
            this.bSearch = new System.Windows.Forms.Button();
            this.nudEndYear = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudStartYear = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bAddAll = new System.Windows.Forms.Button();
            this.lsvResultByName = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProvince = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.tbBrowse = new System.Windows.Forms.TabPage();
            this.tbFromMap = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bMoveDown = new System.Windows.Forms.Button();
            this.bMoveUp = new System.Windows.Forms.Button();
            this.bRemoveAllSelected = new System.Windows.Forms.Button();
            this.lstSelectedStations = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.bSaveSelectedStations = new System.Windows.Forms.Button();
            this.lblStationName = new System.Windows.Forms.Label();
            this.lblMonthlyDataAvailability = new System.Windows.Forms.Label();
            this.lblDailyDataAvailability = new System.Windows.Forms.Label();
            this.lblHourlyDataAvailability = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.dlgSaveSelectedStations = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tbByName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbByName);
            this.tabControl1.Controls.Add(this.tbBrowse);
            this.tabControl1.Controls.Add(this.tbFromMap);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 521);
            this.tabControl1.TabIndex = 0;
            // 
            // tbByName
            // 
            this.tbByName.Controls.Add(this.bSearch);
            this.tbByName.Controls.Add(this.nudEndYear);
            this.tbByName.Controls.Add(this.label5);
            this.tbByName.Controls.Add(this.nudStartYear);
            this.tbByName.Controls.Add(this.label4);
            this.tbByName.Controls.Add(this.cmbDataType);
            this.tbByName.Controls.Add(this.label3);
            this.tbByName.Controls.Add(this.cmbProvince);
            this.tbByName.Controls.Add(this.label2);
            this.tbByName.Controls.Add(this.bAddAll);
            this.tbByName.Controls.Add(this.lsvResultByName);
            this.tbByName.Controls.Add(this.label1);
            this.tbByName.Controls.Add(this.txtStationName);
            this.tbByName.Location = new System.Drawing.Point(4, 22);
            this.tbByName.Name = "tbByName";
            this.tbByName.Padding = new System.Windows.Forms.Padding(3);
            this.tbByName.Size = new System.Drawing.Size(488, 495);
            this.tbByName.TabIndex = 0;
            this.tbByName.Text = "By Name";
            this.tbByName.UseVisualStyleBackColor = true;
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(406, 40);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(62, 23);
            this.bSearch.TabIndex = 11;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            // 
            // nudEndYear
            // 
            this.nudEndYear.Location = new System.Drawing.Point(336, 41);
            this.nudEndYear.Maximum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.nudEndYear.Name = "nudEndYear";
            this.nudEndYear.Size = new System.Drawing.Size(64, 20);
            this.nudEndYear.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "To";
            // 
            // nudStartYear
            // 
            this.nudStartYear.Location = new System.Drawing.Point(240, 41);
            this.nudStartYear.Maximum = new decimal(new int[] {
            1840,
            0,
            0,
            0});
            this.nudStartYear.Minimum = new decimal(new int[] {
            1840,
            0,
            0,
            0});
            this.nudStartYear.Name = "nudStartYear";
            this.nudStartYear.Size = new System.Drawing.Size(64, 20);
            this.nudStartYear.TabIndex = 10;
            this.nudStartYear.Value = new decimal(new int[] {
            1840,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "From";
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Items.AddRange(new object[] {
            "Not Specified",
            "Hourly",
            "Daily",
            "Monthly"});
            this.cmbDataType.Location = new System.Drawing.Point(111, 40);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(88, 21);
            this.cmbDataType.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Availability";
            // 
            // cmbProvince
            // 
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Items.AddRange(new object[] {
            "ALL",
            "ALTA",
            "BC",
            "MAN",
            "NB",
            "NFLD",
            "NS",
            "NU",
            "NWT",
            "ONT",
            "PEI",
            "QUE",
            "SASK",
            "SD",
            "YT"});
            this.cmbProvince.Location = new System.Drawing.Point(343, 11);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(125, 21);
            this.cmbProvince.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Province";
            // 
            // bAddAll
            // 
            this.bAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddAll.Location = new System.Drawing.Point(23, 466);
            this.bAddAll.Name = "bAddAll";
            this.bAddAll.Size = new System.Drawing.Size(131, 23);
            this.bAddAll.TabIndex = 4;
            this.bAddAll.Text = "Use All";
            this.bAddAll.UseVisualStyleBackColor = true;
            // 
            // lsvResultByName
            // 
            this.lsvResultByName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvResultByName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colProvince});
            this.lsvResultByName.FullRowSelect = true;
            this.lsvResultByName.Location = new System.Drawing.Point(23, 69);
            this.lsvResultByName.MultiSelect = false;
            this.lsvResultByName.Name = "lsvResultByName";
            this.lsvResultByName.Size = new System.Drawing.Size(445, 391);
            this.lsvResultByName.TabIndex = 3;
            this.lsvResultByName.UseCompatibleStateImageBehavior = false;
            this.lsvResultByName.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 245;
            // 
            // colProvince
            // 
            this.colProvince.Text = "Province";
            this.colProvince.Width = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Station Name";
            // 
            // txtStationName
            // 
            this.txtStationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStationName.Location = new System.Drawing.Point(97, 11);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(185, 20);
            this.txtStationName.TabIndex = 0;
            this.txtStationName.TextChanged += new System.EventHandler(this.txtStationName_TextChanged);
            // 
            // tbBrowse
            // 
            this.tbBrowse.Location = new System.Drawing.Point(4, 22);
            this.tbBrowse.Name = "tbBrowse";
            this.tbBrowse.Size = new System.Drawing.Size(488, 495);
            this.tbBrowse.TabIndex = 2;
            this.tbBrowse.Text = "Browse";
            this.tbBrowse.UseVisualStyleBackColor = true;
            // 
            // tbFromMap
            // 
            this.tbFromMap.Location = new System.Drawing.Point(4, 22);
            this.tbFromMap.Name = "tbFromMap";
            this.tbFromMap.Padding = new System.Windows.Forms.Padding(3);
            this.tbFromMap.Size = new System.Drawing.Size(488, 495);
            this.tbFromMap.TabIndex = 1;
            this.tbFromMap.Text = "From Map";
            this.tbFromMap.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(772, 521);
            this.splitContainer1.SplitterDistance = 496;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bMoveDown);
            this.groupBox1.Controls.Add(this.bMoveUp);
            this.groupBox1.Controls.Add(this.bRemoveAllSelected);
            this.groupBox1.Controls.Add(this.lstSelectedStations);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 521);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Stations";
            // 
            // bMoveDown
            // 
            this.bMoveDown.Location = new System.Drawing.Point(185, 493);
            this.bMoveDown.Name = "bMoveDown";
            this.bMoveDown.Size = new System.Drawing.Size(79, 23);
            this.bMoveDown.TabIndex = 3;
            this.bMoveDown.Text = "Move Down";
            this.bMoveDown.UseVisualStyleBackColor = true;
            // 
            // bMoveUp
            // 
            this.bMoveUp.Location = new System.Drawing.Point(93, 493);
            this.bMoveUp.Name = "bMoveUp";
            this.bMoveUp.Size = new System.Drawing.Size(79, 23);
            this.bMoveUp.TabIndex = 2;
            this.bMoveUp.Text = "Move Up";
            this.bMoveUp.UseVisualStyleBackColor = true;
            // 
            // bRemoveAllSelected
            // 
            this.bRemoveAllSelected.Location = new System.Drawing.Point(6, 493);
            this.bRemoveAllSelected.Name = "bRemoveAllSelected";
            this.bRemoveAllSelected.Size = new System.Drawing.Size(79, 23);
            this.bRemoveAllSelected.TabIndex = 1;
            this.bRemoveAllSelected.Text = "Remove All";
            this.bRemoveAllSelected.UseVisualStyleBackColor = true;
            // 
            // lstSelectedStations
            // 
            this.lstSelectedStations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstSelectedStations.FormattingEnabled = true;
            this.lstSelectedStations.Location = new System.Drawing.Point(3, 16);
            this.lstSelectedStations.Name = "lstSelectedStations";
            this.lstSelectedStations.Size = new System.Drawing.Size(266, 472);
            this.lstSelectedStations.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.bSaveSelectedStations);
            this.splitContainer2.Panel2.Controls.Add(this.lblStationName);
            this.splitContainer2.Panel2.Controls.Add(this.lblMonthlyDataAvailability);
            this.splitContainer2.Panel2.Controls.Add(this.lblDailyDataAvailability);
            this.splitContainer2.Panel2.Controls.Add(this.lblHourlyDataAvailability);
            this.splitContainer2.Panel2.Controls.Add(this.bCancel);
            this.splitContainer2.Panel2.Controls.Add(this.bOK);
            this.splitContainer2.Size = new System.Drawing.Size(772, 622);
            this.splitContainer2.SplitterDistance = 521;
            this.splitContainer2.TabIndex = 2;
            // 
            // bSaveSelectedStations
            // 
            this.bSaveSelectedStations.Location = new System.Drawing.Point(178, 62);
            this.bSaveSelectedStations.Name = "bSaveSelectedStations";
            this.bSaveSelectedStations.Size = new System.Drawing.Size(108, 25);
            this.bSaveSelectedStations.TabIndex = 4;
            this.bSaveSelectedStations.Text = "Save As...";
            this.bSaveSelectedStations.UseVisualStyleBackColor = true;
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.Location = new System.Drawing.Point(24, 17);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(78, 13);
            this.lblStationName.TabIndex = 3;
            this.lblStationName.Text = "lblStationName";
            // 
            // lblMonthlyDataAvailability
            // 
            this.lblMonthlyDataAvailability.AutoSize = true;
            this.lblMonthlyDataAvailability.Location = new System.Drawing.Point(316, 42);
            this.lblMonthlyDataAvailability.Name = "lblMonthlyDataAvailability";
            this.lblMonthlyDataAvailability.Size = new System.Drawing.Size(126, 13);
            this.lblMonthlyDataAvailability.TabIndex = 2;
            this.lblMonthlyDataAvailability.Text = "lblMonthlyDataAvailability";
            // 
            // lblDailyDataAvailability
            // 
            this.lblDailyDataAvailability.AutoSize = true;
            this.lblDailyDataAvailability.Location = new System.Drawing.Point(24, 42);
            this.lblDailyDataAvailability.Name = "lblDailyDataAvailability";
            this.lblDailyDataAvailability.Size = new System.Drawing.Size(112, 13);
            this.lblDailyDataAvailability.TabIndex = 2;
            this.lblDailyDataAvailability.Text = "lblDailyDataAvailability";
            // 
            // lblHourlyDataAvailability
            // 
            this.lblHourlyDataAvailability.AutoSize = true;
            this.lblHourlyDataAvailability.Location = new System.Drawing.Point(316, 17);
            this.lblHourlyDataAvailability.Name = "lblHourlyDataAvailability";
            this.lblHourlyDataAvailability.Size = new System.Drawing.Size(119, 13);
            this.lblHourlyDataAvailability.TabIndex = 2;
            this.lblHourlyDataAvailability.Text = "lblHourlyDataAvailability";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(685, 61);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bOK
            // 
            this.bOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bOK.Location = new System.Drawing.Point(26, 62);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(145, 23);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "Use Selected Stations";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // dlgSaveSelectedStations
            // 
            this.dlgSaveSelectedStations.DefaultExt = "csv";
            this.dlgSaveSelectedStations.Filter = "Station Information CSV files|*.csv";
            // 
            // FrmDefineStations
            // 
            this.AcceptButton = this.bSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(772, 622);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDefineStations";
            this.Text = "Define Stations";
            this.Load += new System.EventHandler(this.FrmDefineStations_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbByName.ResumeLayout(false);
            this.tbByName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartYear)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbByName;
        private System.Windows.Forms.TabPage tbFromMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstSelectedStations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.TabPage tbBrowse;
        private System.Windows.Forms.Button bAddAll;
        private System.Windows.Forms.ListView lsvResultByName;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colProvince;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRemoveAllSelected;
        private System.Windows.Forms.Label lblMonthlyDataAvailability;
        private System.Windows.Forms.Label lblDailyDataAvailability;
        private System.Windows.Forms.Label lblHourlyDataAvailability;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudEndYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudStartYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bSaveSelectedStations;
        private System.Windows.Forms.SaveFileDialog dlgSaveSelectedStations;
        private System.Windows.Forms.Button bMoveDown;
        private System.Windows.Forms.Button bMoveUp;
    }
}