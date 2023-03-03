using System;
using System.Data;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class CDRSummaryDetailsForm : Form
    {
        public CDRSummaryDetailsForm(DataTable dt)
        {
            InitializeComponent();
            gvCDRSummaryDetails.DataSource = dt;
            Console.WriteLine(dt.Rows.Count);
            gvCDRSummaryDetails.Columns[0].HeaderText = "B-Party";
            gvCDRSummaryDetails.Columns[1].HeaderText = "Duration";
            gvCDRSummaryDetails.Columns[2].HeaderText = "Direction";
            gvCDRSummaryDetails.Columns[3].HeaderText = "Type";
            gvCDRSummaryDetails.Columns[4].HeaderText = "Date";
            gvCDRSummaryDetails.Columns[5].HeaderText = "Time";
            gvCDRSummaryDetails.Columns[6].HeaderText = "Location";
        }
    }
}
