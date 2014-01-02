using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using SocialExplorer.IO.FastDBF;

namespace HAWKLORRY
{
    public partial class FrmDownloadEnvrionmentCanadaClimateData : Form
    {
        private int[] _fields = null;
        private string _path = "";
        private int _startYear = 1882;
        private int _endYear = 1966;
        private static int[] FIELD_INDEX = { 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };

        private List<ECStationInfo> _stations = null;
        private bool _isDownloadAllStations = false;

        public FrmDownloadEnvrionmentCanadaClimateData()
        {
            InitializeComponent();

            //time
            txtStartYear.TextChanged += (s, ee) => { int.TryParse(txtStartYear.Text, out _startYear); };
            txtEndYear.TextChanged += (s, ee) => { int.TryParse(txtEndYear.Text, out _endYear); };

            //stations
            bDefineStations.Click += (s, ee) => 
            {
                FrmDefineStations frm = new FrmDefineStations();

                //remove handler
                if (_stations != null && _stations.Count > 0)
                {
                    foreach (ECStationInfo info in _stations)
                        info.ProgressChanged -= onStaionClimateDataDownloadingProgressChanged;
                }

                //set to frm
                frm.SelectedStations = _stations;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _stations = frm.SelectedStations;

                    //add handler
                    foreach (ECStationInfo info in _stations)
                        info.ProgressChanged += onStaionClimateDataDownloadingProgressChanged;
                
                    if(_stations.Count == 0)
                        lblSelectedStations.Text = "No station is seleted.";
                    else
                        lblSelectedStations.Text = _stations.Count.ToString() + " stations are seleted.";
                }
            };

            lblLatestVersion.LinkClicked += (s, ee) => { System.Diagnostics.Process.Start("http://wp.me/s2CzBq-325"); };
            lblStationLocation.LinkClicked += (s, ee) => { System.Diagnostics.Process.Start("http://wp.me/p2CzBq-68"); };
            lblFeedback.LinkClicked += (s, ee) => 
            {
                try
                {
                    System.Diagnostics.Process.Start("mailto:hawklorry@gmail.com");
                }
                catch
                {
                    System.Windows.Forms.Clipboard.SetText("hawklorry@gmail.com");
                    showInformationWindow("My email address has been copyied to clipboard.");
                }                
            };
            
            //the output format
            this.rdbFormatArcSWATDbf.CheckedChanged += (s, ee) => { updateFormatSelectionControl(); };
            this.rdbFormatArcSWATTxt.CheckedChanged += (s, ee) => { updateFormatSelectionControl(); };
            this.rdbFormatFreeCSV.CheckedChanged += (s, ee) => { updateFormatSelectionControl(); };
            this.rdbFormatFreeText.CheckedChanged += (s, ee) => { updateFormatSelectionControl(); };
            this.rdbFormatSWATInput.CheckedChanged += (s, ee) => { updateFormatSelectionControl(); };
            
            //select output fields
            listFields.ItemCheck += (s, ee) =>                
                {
                    List<int> f = new List<int>();

                    foreach(int index in listFields.CheckedIndices)
                    {
                        if (index != ee.Index) 
                            f.Add(FIELD_INDEX[index]);
                    }
                    if (ee.NewValue == CheckState.Checked) f.Add(FIELD_INDEX[ee.Index]);

                    _fields = null;

                    if(f.Count > 0)
                        _fields = f.ToArray();
                };
            bSelectAll.Click += (s, ee) => 
            {
                for (int i = 0; i < listFields.Items.Count; i++)
                    listFields.SetItemCheckState(i, CheckState.Checked);
            };

            //select output folder
            bBrowseOutput.Click +=
                (s, ee) =>
                {
                    FolderBrowserDialog dlg = new FolderBrowserDialog();
                    dlg.SelectedPath = _path;
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        txtPath.Text = dlg.SelectedPath;
                        _path = dlg.SelectedPath;
                    }
                };
            txtPath.TextChanged += (s, ee) => { if (System.IO.Directory.Exists(txtPath.Text)) _path = txtPath.Text; else txtPath.Text = _path; };


            //download button
            bDownload.Click += (s, ee) =>
                {
                    if (backgroundWorker1.IsBusy)
                    {
                        showInformationWindow("Please wait current process to finish.");
                        return;
                    }

                    //check stations
                    if(_stations == null || _stations.Count == 0)
                    {
                        showInformationWindow("Please define stations first.");
                        return;
                    }

                    //check field list
                    if (listFields.Enabled && _fields == null)
                    {
                        showInformationWindow("Please select output fields.");
                        return;
                    }

                    if (Format == FormatType.SWAT_TEXT)
                    {
                        showInformationWindow("Coming soon. Stay tuned:)");
                        return;
                    }

                    if (_endYear < _startYear)
                    {
                        showInformationWindow("The end year couldn't be earlier than start year.");
                        return;
                    }

                    progressBar1.Maximum = (_endYear - _startYear + 1) * 2;
                    _maxValueofProgressBar = progressBar1.Maximum;

                    backgroundWorker1.RunWorkerAsync();
                };

            //worker
            backgroundWorker1.ProgressChanged += (s, ee) => 
            {
                if (richTextBox1.Text.Length > 0)
                    richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText(ee.UserState.ToString());
                richTextBox1.SelectionStart = richTextBox1.Text.Length; 
                richTextBox1.ScrollToCaret();

                progressBar1.Value =
                    ee.ProgressPercentage > progressBar1.Maximum ? progressBar1.Maximum : ee.ProgressPercentage;
            };
            backgroundWorker1.RunWorkerCompleted += (s, ee) => 
            {
                //this.progressBar1.Value = this.progressBar1.Maximum;
                //this.richTextBox1.Text += "finished";                                   
            };
            backgroundWorker1.DoWork +=
                (s, ee) =>
                {
                    backgroundWorker1.ReportProgress(0, "--------------------------------------------");

                    if (_isDownloadAllStations) //download all stations, update ecstations.csv
                    {
                        backgroundWorker1.ReportProgress(0, "Downloading all EC stations.");
                        EC.RetrieveAndSaveAllStations(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ecstations.csv",
                            backgroundWorker1);
                        backgroundWorker1.ReportProgress(100,
                            "Downloading all EC stations finished. Location: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ecstations.csv");
                    }
                    else//download daily, hourly data
                    {
                        string msg = "";
                        if (_stations.Count == 1)        //one station 
                        {
                            ECStationInfo station = _stations[0];                            
                            downloadOneStation(station, out msg);
                            backgroundWorker1.ReportProgress(_maxValueofProgressBar, msg);
                            showInformationWindow(msg);
                         }
                        else                    //multiple stations
	                    {
                            bool totalStatus = false;
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("------------ Summary ------------");
                            foreach (ECStationInfo onestation in _stations)
                            {
                                bool status = downloadOneStation(onestation, out msg);
                                totalStatus |= status;

                                if (msg.Length > 0)
                                    sb.AppendLine(msg);
                            }

                            showInformationWindow("Finished." + (totalStatus ? "" : "Please check messages in the message window."));
                            backgroundWorker1.ReportProgress(_maxValueofProgressBar, sb.ToString());                            
	                    }
                    }

                };

            //open the output folder
            bOpen.Click += (s, ee) => { if (System.IO.Directory.Exists(_path)) System.Diagnostics.Process.Start(_path); };
        }

        private bool downloadOneStation(ECStationInfo station, out string message)
        {
            message = "";
            try
            {
                bool status = station.save(_fields, _startYear, _endYear, _path, Format);
                if (!status)
                    message = station.Name + ": There is no data between "
                        + _startYear.ToString() + " and " + _endYear.ToString() + ". Please check output messages.";
                else
                {
                    message = station.WarningMessage;
                    if (message.Length == 0)
                        message = station.Name + ": Finished.";
                }
                return status;
            }
            catch (System.Exception e)
            {
                message = station.Name + ": " + e.Message;
                return false;
            }
        }

        private void onStaionClimateDataDownloadingProgressChanged(object sender, EventArgs e)
        {
            BaseWithProcess p = sender as BaseWithProcess;
            backgroundWorker1.ReportProgress(p.ProcessPercentage, p.ProcessMessage);
        }

        private int _maxValueofProgressBar = 100;

        private void FrmDownloadEnvrionmentCanadaClimateData_Load(object sender, EventArgs e)
        {
            rdbFormatArcSWATDbf.Checked = true;

            updateFormatSelectionControl();

            _path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            txtPath.Text = _path;

            txtStartYear.Text = _startYear.ToString();
            txtEndYear.Text = _endYear.ToString();

            lblSelectedStations.Text = "No station is seleted.";

            //_id = txtStationID.Text;
            //_startYear = Convert.ToInt32(txtStartYear.Text);
            //_endYear = Convert.ToInt32(txtEndYear.Text);
         }

        private void updateFormatSelectionControl()
        {
            listFields.Enabled =
                rdbFormatFreeCSV.Checked || rdbFormatFreeText.Checked;
            bSelectAll.Enabled = listFields.Enabled;
        }

        private FormatType Format
        {
            get
            {
                if (rdbFormatArcSWATDbf.Checked) return FormatType.ARCSWAT_DBF;
                if (rdbFormatArcSWATTxt.Checked) return FormatType.ARCSWAT_TEXT;
                if (rdbFormatFreeCSV.Checked) return FormatType.SIMPLE_CSV;
                if (rdbFormatFreeText.Checked) return FormatType.SIMPLE_TEXT;
                if (rdbFormatSWATInput.Checked) return FormatType.SWAT_TEXT;
                return FormatType.SIMPLE_TEXT;
            }
        }

        private void showInformationWindow(string msg)
        {
            MessageBox.Show(msg, "Environment Canada Climte Data");
        }
    }
}
