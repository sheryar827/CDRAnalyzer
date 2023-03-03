using ReadExcelApp.Classes;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class BtsIncidentForm : Form
    {
        public BtsIncidentForm(BTSIncidentDetails btsIncidentDetails)
        {
            InitializeComponent();
            lbSTI.Text = lbSTI.Text + " " + btsIncidentDetails.selectedTimeInterval;
            lbTEUI.Text = lbTEUI.Text + " " + btsIncidentDetails.totalEnteriesUnderInvestigation;
            lbTAPF.Text = lbTAPF.Text + " " + btsIncidentDetails.totalAPartiesFound;
            lbTSRF.Text = lbTSRF.Text + " " + btsIncidentDetails.totalSeemsResidentFound;
            lbTSRDCS.Text = lbTSRDCS.Text + " " + btsIncidentDetails.totalSeemsResidentCrimeScene;
            lbTUDCS.Text = lbTUDCS.Text + " " + btsIncidentDetails.totalUniqueDuringCrimeScene;
            lbTNFWLACS.Text = lbTNFWLACS.Text + " " + btsIncidentDetails.totalNumberLeftAfterCrimeScene;
            lbTNWAACS.Text = lbTNWAACS.Text + " " + btsIncidentDetails.totalNumberAppearedAfterCrimeScene;
        }
    }
}
