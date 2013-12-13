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
    partial class FrmStationInformation : Form
    {        
        public FrmStationInformation()
        {
            InitializeComponent();
        }

        private void FrmStationInformation_Load(object sender, EventArgs e)
        {

        }

        public Station Station
        {
            set
            {
                lblName.Text = value.Name;
                lblProvince.Text  = value.Province;
                lblLatitude.Text = value.Latitude;
                lblLongtitude.Text = value.Longtitude;
                lblElevation.Text = value.Elevation;
                this.Text = "Station Information - " + value.ID;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
