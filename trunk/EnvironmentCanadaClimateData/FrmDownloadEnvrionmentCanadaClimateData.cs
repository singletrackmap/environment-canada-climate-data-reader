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
        private string _id = "4922";
        private string _path = "";
        private int _startYear = 1882;
        private int _endYear = 1966;
        private static int[] FIELD_INDEX = { 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
        private bool _isMultiple = false;

        private Station _station = null;            //for one station scenario
        private List<Station> _multiple_stations = null;     //for multiple station scenario

        public FrmDownloadEnvrionmentCanadaClimateData()
        {
            InitializeComponent();


            //time
            txtStartYear.TextChanged += (s, ee) => { int.TryParse(txtStartYear.Text, out _startYear); };
            txtEndYear.TextChanged += (s, ee) => { int.TryParse(txtEndYear.Text, out _endYear); };

            //the station select method
            rdbOneStation.CheckedChanged += (s, ee) => { updateStationSelectionControl(); };
            bStationInfo.Click += (s, ee) => 
            {
                //check station id
                if (rdbOneStation.Checked && _id.Length == 0)
                {
                    showInformationWindow("Please intput station id");
                    return;
                }

                if (_station == null || _station.ID != _id)
                {
                    _station = new Station(_id);
                    _station.ProgressChanged += (ss, eee) => 
                    {
                        BaseWithProcess p = ss as BaseWithProcess;
                        backgroundWorker1.ReportProgress(p.ProcessPercentage, p.ProcessMessage); 
                    };
                }
                if (!_station.Exist)
                    showInformationWindow("Couldn't find station " + _id);
                else
                {
                    FrmStationInformation info = new FrmStationInformation();
                    info.Station = _station;
                    info.ShowDialog();
                }
            };
            rdbMultipleStation.CheckedChanged += (s, ee) => { updateStationSelectionControl(); };
            txtStationID.TextChanged += (s, ee) => { _id = txtStationID.Text; };
            bBrowseStationCSV.Click += (s, ee) => 
                {
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //read the station csv file
                        using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                        {
                            using (CachedCsvReader csv = new CachedCsvReader(reader, true))
                            {
                                if (csv.FieldCount < 2)
                                {
                                    showInformationWindow("Less than two columns. Please check your file.");
                                    return;
                                }

                                if(_multiple_stations == null)
                                    _multiple_stations = new List<Station>();
                                _multiple_stations.Clear();

                                while (csv.ReadNextRecord())
                                {
                                    string id = csv[1];
                                    if (id.Length > 0)
                                    {
                                        Station onestation = new Station(id);
                                        _multiple_stations.Add(onestation);

                                        onestation.ProgressChanged += (ss, eee) =>
                                        {
                                            BaseWithProcess p = ss as BaseWithProcess;
                                            backgroundWorker1.ReportProgress(p.ProcessPercentage, p.ProcessMessage);
                                        };
                                    }
                                        
                                }

                                if(_multiple_stations.Count == 0)
                                    showInformationWindow("No station is found in " + openFileDialog1.FileName);
                                else
                                    showInformationWindow(_multiple_stations.Count.ToString() + " stations are found in " + openFileDialog1.FileName);
                            }
                        }                        
                    }
                };
            lblStationIDHelp.LinkClicked += (s, ee) => { System.Diagnostics.Process.Start("http://wp.me/p2CzBq-5x"); };
            //bHelpStationID.Click += (s, ee) => { FrmHelp frm = new FrmHelp(); frm.ShowDialog(); };

            
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

                    //check station id
                    if (rdbOneStation.Checked && _id.Length == 0)
                    {
                        showInformationWindow("Please intput station id");
                        return;
                    }

                    //check multiple stations
                    if(rdbMultipleStation.Checked && (_multiple_stations == null || _multiple_stations.Count == 0))
                    {
                        showInformationWindow("Please load stations first.");
                        return;
                    }

                    //check field list
                    if (listFields.Enabled && _fields == null)
                    {
                        showInformationWindow("Please select output fields.");
                        return;
                    }

                    //intialize single station if necessary
                    if (rdbOneStation.Checked && (_station == null || _station.ID != _id))
                    {
                        _station = new Station(_id);
                        _station.ProgressChanged += (ss, eee) =>
                        {
                            BaseWithProcess p = ss as BaseWithProcess;
                            backgroundWorker1.ReportProgress(p.ProcessPercentage, p.ProcessMessage);
                        };
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

                    if(!_isMultiple)        //one station 
                    {
                        string msg = "";
                        try
                        {                            
                            bool status = _station.save(_fields, _startYear, _endYear, _path, Format);
                            if (!status)
                            {
                                if (!_station.Exist)
                                    msg = "Station " + _station.ID + " doesn't exist!";
                                else
                                    msg = "There is no data between "
                                        + _startYear.ToString() + " and " + _endYear.ToString() + ". Please check output messages.";
                            }
                            else
                            {
                                int[] nodataYears = _station.NoDataYears;
                                if (nodataYears.Length > 0)
                                    msg = "Finished. Not all years has data. Please check output messages.";
                                else
                                    msg = "Finished.";
                            }
                        }
                        catch (System.Exception e)
                        {
                            msg = e.Message;
                        }
                        backgroundWorker1.ReportProgress(_maxValueofProgressBar, msg);
                        showInformationWindow(msg);
                     }
                    else                    //multiple stations
	                {
                        foreach(Station onestation in _multiple_stations)
                        {                           
                            onestation.save(_fields, _startYear, _endYear, _path, Format);
                        }
	                }
                };

            //open the output folder
            bOpen.Click += (s, ee) => { if (System.IO.Directory.Exists(_path)) System.Diagnostics.Process.Start(_path); };
        }

        private int _maxValueofProgressBar = 100;

        private void FrmDownloadEnvrionmentCanadaClimateData_Load(object sender, EventArgs e)
        {
            rdbOneStation.Checked = true;
            rdbFormatArcSWATDbf.Checked = true;

            updateFormatSelectionControl();
            updateStationSelectionControl();

            _path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            txtPath.Text = _path;

            txtStationID.Text = _id;
            txtStartYear.Text = _startYear.ToString();
            txtEndYear.Text = _endYear.ToString();

            //_id = txtStationID.Text;
            //_startYear = Convert.ToInt32(txtStartYear.Text);
            //_endYear = Convert.ToInt32(txtEndYear.Text);
         }

        private void updateStationSelectionControl()
        {
            txtStationID.Enabled = rdbOneStation.Checked;
            bStationInfo.Enabled = rdbOneStation.Checked;
            bBrowseStationCSV.Enabled = rdbMultipleStation.Checked;

            _isMultiple = rdbMultipleStation.Checked;
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
