namespace HAWKLORRY
{
    partial class FrmDownloadEnvrionmentCanadaClimateData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDownloadEnvrionmentCanadaClimateData));
            this.bDownload = new System.Windows.Forms.Button();
            this.txtStationID = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listFields = new System.Windows.Forms.CheckedListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.bBrowseOutput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartYear = new System.Windows.Forms.TextBox();
            this.txtEndYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bStationInfo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bBrowseStationCSV = new System.Windows.Forms.Button();
            this.rdbMultipleStation = new System.Windows.Forms.RadioButton();
            this.rdbOneStation = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bSelectAll = new System.Windows.Forms.Button();
            this.rdbFormatSWATInput = new System.Windows.Forms.RadioButton();
            this.rdbFormatFreeCSV = new System.Windows.Forms.RadioButton();
            this.rdbFormatFreeText = new System.Windows.Forms.RadioButton();
            this.rdbFormatArcSWATTxt = new System.Windows.Forms.RadioButton();
            this.rdbFormatArcSWATDbf = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStationIDHelp = new System.Windows.Forms.LinkLabel();
            this.lblLatestVersion = new System.Windows.Forms.LinkLabel();
            this.lblFeedback = new System.Windows.Forms.LinkLabel();
            this.lblStationLocation = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(6, 193);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(159, 21);
            this.bDownload.TabIndex = 0;
            this.bDownload.Text = "Download";
            this.bDownload.UseVisualStyleBackColor = true;
            // 
            // txtStationID
            // 
            this.txtStationID.Location = new System.Drawing.Point(131, 18);
            this.txtStationID.Name = "txtStationID";
            this.txtStationID.Size = new System.Drawing.Size(84, 21);
            this.txtStationID.TabIndex = 1;
            this.txtStationID.Text = "29886";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 308);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(690, 242);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // listFields
            // 
            this.listFields.FormattingEnabled = true;
            this.listFields.Items.AddRange(new object[] {
            "Max Temp (°C)",
            "Min Temp (°C)",
            "Mean Temp (°C)",
            "Heat Deg Days (°C)",
            "Cool Deg Days (°C)",
            "Total Rain (mm)",
            "Total Snow (cm)",
            "Total Precip (mm)",
            "Snow on Grnd (cm)",
            "Dir of Max Gust (10s deg)",
            "Spd of Max Gust (km/h)"});
            this.listFields.Location = new System.Drawing.Point(199, 18);
            this.listFields.Name = "listFields";
            this.listFields.Size = new System.Drawing.Size(191, 164);
            this.listFields.TabIndex = 3;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(22, 18);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(251, 21);
            this.txtPath.TabIndex = 5;
            // 
            // bBrowseOutput
            // 
            this.bBrowseOutput.Location = new System.Drawing.Point(179, 42);
            this.bBrowseOutput.Name = "bBrowseOutput";
            this.bBrowseOutput.Size = new System.Drawing.Size(94, 21);
            this.bBrowseOutput.TabIndex = 6;
            this.bBrowseOutput.Text = "Change ...";
            this.bBrowseOutput.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Year";
            // 
            // txtStartYear
            // 
            this.txtStartYear.Location = new System.Drawing.Point(116, 21);
            this.txtStartYear.Name = "txtStartYear";
            this.txtStartYear.Size = new System.Drawing.Size(157, 21);
            this.txtStartYear.TabIndex = 1;
            this.txtStartYear.Text = "2000";
            // 
            // txtEndYear
            // 
            this.txtEndYear.Location = new System.Drawing.Point(116, 45);
            this.txtEndYear.Name = "txtEndYear";
            this.txtEndYear.Size = new System.Drawing.Size(157, 21);
            this.txtEndYear.TabIndex = 1;
            this.txtEndYear.Text = "2010";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "End Year";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bStationInfo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bBrowseStationCSV);
            this.groupBox1.Controls.Add(this.rdbMultipleStation);
            this.groupBox1.Controls.Add(this.rdbOneStation);
            this.groupBox1.Controls.Add(this.txtStationID);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 107);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stations";
            // 
            // bStationInfo
            // 
            this.bStationInfo.Location = new System.Drawing.Point(221, 18);
            this.bStationInfo.Name = "bStationInfo";
            this.bStationInfo.Size = new System.Drawing.Size(61, 21);
            this.bStationInfo.TabIndex = 9;
            this.bStationInfo.Text = "info";
            this.bStationInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "the second column is station id.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Assume the first column is station name and ";
            // 
            // bBrowseStationCSV
            // 
            this.bBrowseStationCSV.Location = new System.Drawing.Point(131, 42);
            this.bBrowseStationCSV.Name = "bBrowseStationCSV";
            this.bBrowseStationCSV.Size = new System.Drawing.Size(151, 21);
            this.bBrowseStationCSV.TabIndex = 6;
            this.bBrowseStationCSV.Text = "Find Station CSV...";
            this.bBrowseStationCSV.UseVisualStyleBackColor = true;
            // 
            // rdbMultipleStation
            // 
            this.rdbMultipleStation.AutoSize = true;
            this.rdbMultipleStation.Location = new System.Drawing.Point(6, 42);
            this.rdbMultipleStation.Name = "rdbMultipleStation";
            this.rdbMultipleStation.Size = new System.Drawing.Size(119, 16);
            this.rdbMultipleStation.TabIndex = 5;
            this.rdbMultipleStation.TabStop = true;
            this.rdbMultipleStation.Text = "Multiple Station";
            this.rdbMultipleStation.UseVisualStyleBackColor = true;
            // 
            // rdbOneStation
            // 
            this.rdbOneStation.AutoSize = true;
            this.rdbOneStation.Location = new System.Drawing.Point(6, 20);
            this.rdbOneStation.Name = "rdbOneStation";
            this.rdbOneStation.Size = new System.Drawing.Size(89, 16);
            this.rdbOneStation.TabIndex = 5;
            this.rdbOneStation.TabStop = true;
            this.rdbOneStation.Text = "One Station";
            this.rdbOneStation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtStartYear);
            this.groupBox2.Controls.Add(this.txtEndYear);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 75);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bOpen);
            this.groupBox3.Controls.Add(this.bBrowseOutput);
            this.groupBox3.Controls.Add(this.txtPath);
            this.groupBox3.Location = new System.Drawing.Point(12, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 72);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Folder";
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(22, 42);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(92, 21);
            this.bOpen.TabIndex = 4;
            this.bOpen.Text = "Open Folder";
            this.bOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bSelectAll);
            this.groupBox4.Controls.Add(this.rdbFormatSWATInput);
            this.groupBox4.Controls.Add(this.rdbFormatFreeCSV);
            this.groupBox4.Controls.Add(this.rdbFormatFreeText);
            this.groupBox4.Controls.Add(this.rdbFormatArcSWATTxt);
            this.groupBox4.Controls.Add(this.rdbFormatArcSWATDbf);
            this.groupBox4.Controls.Add(this.bDownload);
            this.groupBox4.Controls.Add(this.listFields);
            this.groupBox4.Location = new System.Drawing.Point(306, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 220);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Format";
            // 
            // bSelectAll
            // 
            this.bSelectAll.Location = new System.Drawing.Point(199, 193);
            this.bSelectAll.Name = "bSelectAll";
            this.bSelectAll.Size = new System.Drawing.Size(191, 21);
            this.bSelectAll.TabIndex = 4;
            this.bSelectAll.Text = "Select All";
            this.bSelectAll.UseVisualStyleBackColor = true;
            // 
            // rdbFormatSWATInput
            // 
            this.rdbFormatSWATInput.AutoSize = true;
            this.rdbFormatSWATInput.Location = new System.Drawing.Point(7, 103);
            this.rdbFormatSWATInput.Name = "rdbFormatSWATInput";
            this.rdbFormatSWATInput.Size = new System.Drawing.Size(161, 16);
            this.rdbFormatSWATInput.TabIndex = 0;
            this.rdbFormatSWATInput.TabStop = true;
            this.rdbFormatSWATInput.Text = "SWAT Input (.pcp, .tmp)";
            this.rdbFormatSWATInput.UseVisualStyleBackColor = true;
            // 
            // rdbFormatFreeCSV
            // 
            this.rdbFormatFreeCSV.AutoSize = true;
            this.rdbFormatFreeCSV.Location = new System.Drawing.Point(6, 82);
            this.rdbFormatFreeCSV.Name = "rdbFormatFreeCSV";
            this.rdbFormatFreeCSV.Size = new System.Drawing.Size(167, 16);
            this.rdbFormatFreeCSV.TabIndex = 0;
            this.rdbFormatFreeCSV.TabStop = true;
            this.rdbFormatFreeCSV.Text = "Free Format CSV (.csv)  ";
            this.rdbFormatFreeCSV.UseVisualStyleBackColor = true;
            // 
            // rdbFormatFreeText
            // 
            this.rdbFormatFreeText.AutoSize = true;
            this.rdbFormatFreeText.Location = new System.Drawing.Point(6, 61);
            this.rdbFormatFreeText.Name = "rdbFormatFreeText";
            this.rdbFormatFreeText.Size = new System.Drawing.Size(173, 16);
            this.rdbFormatFreeText.TabIndex = 0;
            this.rdbFormatFreeText.TabStop = true;
            this.rdbFormatFreeText.Text = "Free Format Text (.txt)  ";
            this.rdbFormatFreeText.UseVisualStyleBackColor = true;
            // 
            // rdbFormatArcSWATTxt
            // 
            this.rdbFormatArcSWATTxt.AutoSize = true;
            this.rdbFormatArcSWATTxt.Location = new System.Drawing.Point(7, 40);
            this.rdbFormatArcSWATTxt.Name = "rdbFormatArcSWATTxt";
            this.rdbFormatArcSWATTxt.Size = new System.Drawing.Size(191, 16);
            this.rdbFormatArcSWATTxt.TabIndex = 0;
            this.rdbFormatArcSWATTxt.TabStop = true;
            this.rdbFormatArcSWATTxt.Text = "ArcSWAT Daily ASCII (.txt)  ";
            this.rdbFormatArcSWATTxt.UseVisualStyleBackColor = true;
            // 
            // rdbFormatArcSWATDbf
            // 
            this.rdbFormatArcSWATDbf.AutoSize = true;
            this.rdbFormatArcSWATDbf.Location = new System.Drawing.Point(7, 18);
            this.rdbFormatArcSWATDbf.Name = "rdbFormatArcSWATDbf";
            this.rdbFormatArcSWATDbf.Size = new System.Drawing.Size(191, 16);
            this.rdbFormatArcSWATDbf.TabIndex = 0;
            this.rdbFormatArcSWATDbf.TabStop = true;
            this.rdbFormatArcSWATDbf.Text = "ArcSWAT Daily dBase (.dbf)  ";
            this.rdbFormatArcSWATDbf.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Station Information CSV files|*.csv";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 282);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(690, 21);
            this.progressBar1.TabIndex = 12;
            // 
            // lblStationIDHelp
            // 
            this.lblStationIDHelp.AutoSize = true;
            this.lblStationIDHelp.Location = new System.Drawing.Point(306, 264);
            this.lblStationIDHelp.Name = "lblStationIDHelp";
            this.lblStationIDHelp.Size = new System.Drawing.Size(353, 12);
            this.lblStationIDHelp.TabIndex = 10;
            this.lblStationIDHelp.TabStop = true;
            this.lblStationIDHelp.Text = "How to Get Environment Canada Climate Station ID From Name";
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Location = new System.Drawing.Point(306, 246);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(167, 12);
            this.lblLatestVersion.TabIndex = 13;
            this.lblLatestVersion.TabStop = true;
            this.lblLatestVersion.Text = "Get Lastest Porgram Package";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(480, 246);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(83, 12);
            this.lblFeedback.TabIndex = 14;
            this.lblFeedback.TabStop = true;
            this.lblFeedback.Text = "Send Feedback";
            // 
            // lblStationLocation
            // 
            this.lblStationLocation.AutoSize = true;
            this.lblStationLocation.Location = new System.Drawing.Point(571, 246);
            this.lblStationLocation.Name = "lblStationLocation";
            this.lblStationLocation.Size = new System.Drawing.Size(71, 12);
            this.lblStationLocation.TabIndex = 15;
            this.lblStationLocation.TabStop = true;
            this.lblStationLocation.Text = "EC Stations";
            // 
            // FrmDownloadEnvrionmentCanadaClimateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 558);
            this.Controls.Add(this.lblStationLocation);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblLatestVersion);
            this.Controls.Add(this.lblStationIDHelp);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDownloadEnvrionmentCanadaClimateData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download Envrionment Canada Climate Data - Daily";
            this.Load += new System.EventHandler(this.FrmDownloadEnvrionmentCanadaClimateData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.TextBox txtStationID;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckedListBox listFields;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button bBrowseOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartYear;
        private System.Windows.Forms.TextBox txtEndYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbMultipleStation;
        private System.Windows.Forms.RadioButton rdbOneStation;
        private System.Windows.Forms.Button bBrowseStationCSV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbFormatArcSWATTxt;
        private System.Windows.Forms.RadioButton rdbFormatArcSWATDbf;
        private System.Windows.Forms.RadioButton rdbFormatFreeText;
        private System.Windows.Forms.RadioButton rdbFormatSWATInput;
        private System.Windows.Forms.RadioButton rdbFormatFreeCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bStationInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.LinkLabel lblStationIDHelp;
        private System.Windows.Forms.Button bSelectAll;
        private System.Windows.Forms.LinkLabel lblLatestVersion;
        private System.Windows.Forms.LinkLabel lblFeedback;
        private System.Windows.Forms.LinkLabel lblStationLocation;
    }
}