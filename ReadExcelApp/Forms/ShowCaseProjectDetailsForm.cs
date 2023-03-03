using System;
using System.Data;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class ShowCaseProjectDetailsForm : Form
    {
        public ShowCaseProjectDetailsForm()
        {
            InitializeComponent();
        }

        private async void getProjectCases()
        {
            string proc = "exec dbo.Projects_View";
            DataTable dt = await CommonMethods.getRecords(proc);
            gvShowCaseProject.DataSource = dt;
            /*gvShowCaseProject.Columns[0].HeaderText = "Project ID";*/
            gvShowCaseProject.Columns[0].Visible = false;
            gvShowCaseProject.Columns[1].HeaderText = "Project Name";
            gvShowCaseProject.Columns[2].HeaderText = "Created By";
        }

        private async void btnSaveGP_Click(object sender, EventArgs e)
        {
            if (IsCaseFormValid())
            {
                DateTime date = dateTimePicker.Value;
                string searchRecordProc = "exec cdrsp_GeneralPoliceTable_SearchRecord '" + txtFirNo.Text.Trim() + "', '" + date + "','" + txtUnderSection.Text.Trim() + "', '" + cmbBoxPs.Text.Trim() + "','" + cmbBoxDistict.Text.Trim() + "','" + txtDetail.Text.Trim() + "', '" + Common.userName + "'";
                var dt = await CommonMethods.getRecords(searchRecordProc);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Police Case already added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string proc = "exec SP_Case_Insert '" + txtFirNo.Text + "', '" + date + "', '" + txtUnderSection.Text + "', '" + cmbBoxPs.Text + "', '" + cmbBoxDistict.Text + "', '" + txtDetail.Text + "', '" + Common.userName + "'";
                    CommonMethods.insertRecords(proc);
                    //CommonMethods.messageDialog("New Case Added to Genernal Police Successfully!");
                    MessageBox.Show("New Case Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getCasesGeneralPolice();
                }

            }

        }

        private bool IsCaseFormValid()
        {
            var Valid = true;
            if (txtFirNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("FIR Name is Required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirNo.Focus();
                Valid = false;
            }
            if (txtFirNo.Text.Trim().Length >= 50)
            {
                MessageBox.Show("FIR Name should be less than 50!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirNo.Focus();
                Valid = false;
            }

            if (txtUnderSection.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Under Section is Required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnderSection.Focus();
                Valid = false;
            }
            if (txtUnderSection.Text.Trim().Length >= 200)
            {
                MessageBox.Show("Under Section should be less than 200!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnderSection.Focus();
                Valid = false;
            }

            if (cmbBoxPs.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Police Station name is Required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxPs.Focus();
                Valid = false;
            }
            if (cmbBoxPs.Text.Trim().Length >= 50)
            {
                MessageBox.Show("Police Station name should be less than 50!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxPs.Focus();
                Valid = false;
            }

            if (cmbBoxDistict.Text.Trim() == string.Empty)
            {
                MessageBox.Show("District name is Required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxDistict.Focus();
                Valid = false;
            }
            if (cmbBoxDistict.Text.Trim().Length >= 50)
            {
                MessageBox.Show("District name should be less than 50!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxDistict.Focus();
                Valid = false;
            }

            if (txtDetail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Details are Required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDetail.Focus();
                Valid = false;
            }
            if (txtDetail.Text.Trim().Length >= 200)
            {
                MessageBox.Show("Details should be less than 200!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDetail.Focus();
                Valid = false;
            }


            return Valid;
        }

        private async void btnSaveProjectCase_Click(object sender, EventArgs e)
        {
            string procSearch = "exec SP_Project_Search '" + cmbBoxProject.Text + "'";
            DataTable dt = await CommonMethods.getRecords(procSearch);
            if (dt.Rows.Count > 0)
            {

                //CommonMethods.messageDialog("Project already added!");
                MessageBox.Show("Project already added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IsProjectFormValid())
            {
                string proc = "exec SP_Project_Insert '" + cmbBoxProject.Text + "', '" + Common.userName + "'";
                CommonMethods.insertRecords(proc);
                //CommonMethods.messageDialog("New Project Added Successfully!");
                MessageBox.Show("New Project Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getProjectCases();
            }
        }

        private bool IsProjectFormValid()
        {
            var Valid = true;
            if (cmbBoxProject.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Project Name is Required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxProject.Focus();
                Valid = false;
            }
            if (cmbBoxProject.Text.Trim().Length >= 50)
            {
                MessageBox.Show("Project Name should be less than 50!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBoxProject.Focus();
                Valid = false;
            }
            return Valid;
        }

        private async void getCasesGeneralPolice()
        {
            string proc = "exec dbo.GeneralPoliceTable_View '"+Common.userName+"'";
            DataTable dt = await CommonMethods.getRecords(proc);
            gvShowCaseProject.DataSource = dt;
            gvShowCaseProject.Columns[0].Visible = false;
            gvShowCaseProject.Columns[1].HeaderText = "Fir No";
            txtFirNo.Clear(); txtFirNo.Focus();
            txtUnderSection.Clear();
            txtDetail.Clear();
        }

        private void ShowCaseProjectDetailsForm_Load(object sender, EventArgs e)
        {
            rbProjects.Checked = true;
            gbGeneralPolice.Enabled = false;
            cmbBoxProject.Focus();
            getProjectCases();
        }

        private void rbProjects_Click(object sender, EventArgs e)
        {
            getProjectCases();
            gbPrject.Enabled = true;
            gbGeneralPolice.Enabled = false;
        }

        private void rbGeneralPolice_Click(object sender, EventArgs e)
        {
            getCasesGeneralPolice();
            gbPrject.Enabled = false;
            gbGeneralPolice.Enabled = true;
        }

        private void cmbBoxProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //when enter is press button login is click
                btnSaveProjectCase.PerformClick();
            }
        }
    }
}
