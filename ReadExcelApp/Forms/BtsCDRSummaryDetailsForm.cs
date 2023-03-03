using ReadExcelApp.Classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class BtsCDRSummaryDetailsForm : Form
    {
        public BtsCDRSummaryDetailsForm(List<BtsStandCDR> dt)
        {
            InitializeComponent();
            gvCDRSummaryDetails.DataSource = dt;
        }
    }
}
