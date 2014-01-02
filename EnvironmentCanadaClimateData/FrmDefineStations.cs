using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAWKLORRY
{
    partial class FrmDefineStations : Form
    {
        public FrmDefineStations()
        {
            InitializeComponent();
        }

        private void txtStationName_TextChanged(object sender, EventArgs e)
        {            
        }

        private void FrmDefineStations_Load(object sender, EventArgs e)
        {
            lsvResultByName.SelectedIndexChanged += (s, ee) =>
                {
                    if (lsvResultByName.SelectedItems.Count == 0) return;
                    ECStationInfo info = lsvResultByName.SelectedItems[0].Tag as ECStationInfo;
                    updateDataAvailability(info);
                };
            lsvResultByName.MouseDoubleClick += (s, ee) => 
                {
                    if (lsvResultByName.SelectedItems.Count == 0) return;
                    ECStationInfo info = lsvResultByName.SelectedItems[0].Tag as ECStationInfo;
                    if(!isSelected(info))
                        lstSelectedStations.Items.Add(info);
                    bRemoveAllSelected.Enabled = lstSelectedStations.Items.Count > 0;
                };

            lstSelectedStations.SelectedIndexChanged += (s, ee) =>
                {
                    if (lstSelectedStations.SelectedItem == null) return;
                    updateDataAvailability(lstSelectedStations.SelectedItem as ECStationInfo);
                };
            lstSelectedStations.MouseDoubleClick += (s, ee) =>
                {
                    if (lstSelectedStations.SelectedItem == null) return;
                    lstSelectedStations.Items.RemoveAt(lstSelectedStations.SelectedIndex);
                    bRemoveAllSelected.Enabled = lstSelectedStations.Items.Count > 0;
                };
            bAddAll.Click += (s, ee) => 
                {
                    if (lsvResultByName.Items.Count == 0) return;
                    foreach (ListViewItem item in lsvResultByName.Items)
                    {
                        ECStationInfo info = item.Tag as ECStationInfo;
                        if (!isSelected(info))
                            lstSelectedStations.Items.Add(info);
                    }
                    bRemoveAllSelected.Enabled = lstSelectedStations.Items.Count > 0;
                };
            bRemoveAllSelected.Click += (s, ee) => { lstSelectedStations.Items.Clear(); };
            bSearch.Click += (s, ee) => 
                {
                    lsvResultByName.Items.Clear();

                    string sql = SearchSQL;
                    if (sql.Length == 0)
                    {
                        bAddAll.Text = "Use All";
                        bAddAll.Enabled = false;
                        return;
                    }

                    List<ECStationInfo> stations = EC.Search(sql);
                    foreach (ECStationInfo info in stations)
                    {
                        ListViewItem item = lsvResultByName.Items.Add(info.Name);
                        item.SubItems.Add(info.Province);
                        item.Tag = info;
                    }

                    bAddAll.Enabled = stations.Count > 0;
                    bAddAll.Text = "Use All" + (stations.Count > 0 ? " " + stations.Count.ToString() + " stations" : "");

                };

            updateDataAvailability(null);

            cmbDataType.SelectedIndex = 0;
            cmbProvince.SelectedIndex = 0;
            nudEndYear.Minimum = 1840;
            nudEndYear.Maximum = DateTime.Now.Year;
            nudEndYear.Value = nudEndYear.Maximum;
            nudStartYear.Minimum = 1840;
            nudStartYear.Maximum = DateTime.Now.Year;
            nudStartYear.Value = 1840;
        }

        private string SearchSQL
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (txtStationName.Text.Trim().Length > 0)
                    sb.Append("NAME like '*" + txtStationName.Text.Trim() + "*'");
                if (cmbProvince.SelectedIndex > 0)
                {
                    if (sb.Length > 0) sb.Append(" and ");
                    sb.Append("PROVINCE = '" + cmbProvince.SelectedItem.ToString() + "'");
                }
                if(cmbDataType.SelectedIndex > 0)
                {
                    if (sb.Length > 0) sb.Append(" and ");

                    string dataType = ((ECDataIntervalType)cmbDataType.SelectedIndex).ToString();
                    sb.Append(string.Format("{0}_FIRST_DAY <= '{1}-12-31' and {0}_LAST_DAY >= '{2}-01-01'",
                        dataType, nudEndYear.Value,nudStartYear.Value));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// check if one station is already selected
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private bool isSelected(ECStationInfo info)
        {
            foreach (object b in lstSelectedStations.Items)
            {
                ECStationInfo selected = b as ECStationInfo;
                if (info.Equals(selected)) return true;
            }
            return false;
        }

        /// <summary>
        /// Selected stations
        /// </summary>
        public List<ECStationInfo> SelectedStations
        {
            get 
            {          
                List<ECStationInfo> stations = new List<ECStationInfo>();

                if (lstSelectedStations.Items.Count == 0) return stations;

                foreach (object b in lstSelectedStations.Items)
                {
                    ECStationInfo selected = b as ECStationInfo;
                    stations.Add(selected);
                }
                return stations;
            }
            set
            {
                if (value == null || value.Count == 0) return;

                foreach (ECStationInfo info in value)
                {
                    lstSelectedStations.Items.Add(info);
                }
            }
            
        }

        /// <summary>
        /// used to limit the number of stations
        /// </summary>
        private ECDataIntervalType _dataType = ECDataIntervalType.DAILY;

        public ECDataIntervalType DataType
        {
            set { _dataType = value; }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void updateDataAvailability(ECStationInfo info)
        {
            if (info != null)
                lblStationName.Text = info.ToString();
            else
                lblStationName.Text = "No station is selected.";

            if (info != null && info.HourlyAvailability.IsAvailable)
                lblHourlyDataAvailability.Text = info.HourlyAvailability.ToTimeRangeString();
            else
                lblHourlyDataAvailability.Text = "HOURLY: Not Available.";

            if (info != null && info.DailyAvailability.IsAvailable)
                this.lblDailyDataAvailability.Text = info.DailyAvailability.ToTimeRangeString();
            else
                lblDailyDataAvailability.Text = "DAILY: Not Available.";

            if (info != null && info.MonthlyAvailability.IsAvailable)
                lblMonthlyDataAvailability.Text = info.MonthlyAvailability.ToTimeRangeString();
            else
                lblMonthlyDataAvailability.Text = "MONTHLY: Not Available.";
        }
    }
}
