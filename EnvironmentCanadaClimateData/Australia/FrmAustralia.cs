using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAWKLORRY.Australia
{
    public partial class FrmAustralia : Form
    {
        public FrmAustralia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StationAustralia s = new StationAustralia("");
            this.richTextBox1.Text = s.retrieveDailyOneTypeClimateData(ClimateDataType.PRECIPITATION);
        }
    }
}
