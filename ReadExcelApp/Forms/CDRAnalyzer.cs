using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ReadExcelApp
{
    public partial class CDRAnalyzer : Form
    {
        private Button currentButton;
        private Form activeForm;

        public CDRAnalyzer()
        {
            InitializeComponent();
            shadowPanelMenu.VerticalScroll.Visible = true;
            
            /*btnCloseChildForm.Visible = false;*/
            /* this.Text = string.Empty;
             this.ControlBox = false;
             this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
             Ping ping = new Ping();
             try
             {
                 PingReply reply = ping.Send(Common.serverIP, 100);
                 string pingStatus = reply.Status.ToString();

                 if (pingStatus.ToLower() != "success")
                 {
                     DialogResult dresult = new Forms.MsgBox("Unable to connect please check your internet connection and try again").ShowDialog();
                     if (dresult == DialogResult.OK)
                     {
                         this.Close();
                     }

                 }
                 *//*else
                 {
                     //MessageBox.Show("Server Ping Successfully");


                     *//*CommonMethods.messageDialog("Server Ping Successfully!!");*//*


                 }*//*
             }
             catch (Exception ex)
             {

                 CommonMethods.messageDialog(ex.Message);
             }*/
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    /*btnCloseChildForm.Visible = true;*/
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /*private void openChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.btnCDRSummary.Controls.Add(childForm);
            this.btnCDRSummary.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;
        }*/

        private void openChildFormPage(Form childForm, object btnSender, TabPage tabPage)
        {

            if (activeForm != null)
            {
                activeForm.Close();

            }
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tabPage.Controls.Add(childForm);

            //this.btnCDRSummary.Controls.Add(childForm);
            //this.btnCDRSummary.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;
        }



        /*private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }*/

        private void Reset()
        {
            DisableButton();
            lbTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            //panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            /*btnCloseChildForm.Visible = false;*/
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /*
                private void btnAddCaseProject_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.ShowCaseProjectDetailsForm(), sender);
                }

                *//*private void btnBasicConversationInfo_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.BasicConversationInfoForm(), sender);
                }*//*

                private void btnActiveQtr_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.GMapForm(), sender);
                }

                private void btnConverPattern_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.LinkAnalysisForm(), sender);
                }

                private void btnCDRSum_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.CDRSummaryForm(), sender);
                }

                private void btnLocSummary_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.LocationSummary(), sender);
                }

                private void btnGIS_Click(object sender, EventArgs e)
                {
                    *//*openChildForm(new Forms.GISForm(), sender);*//*
                }

                private void btnSubsInfo_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.BasicConversationInfoForm(), sender);
                }

                private void btnSilentPurged_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.SilentOrPurgedForm(), sender);
                }


                private void btnImei_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.IMEIForm(), sender);
                }

                private void btnCallsCount_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.CallsCountForm(), sender);
                }

                private void btnCallsCountSec_Click(object sender, EventArgs e)
                {
                    openChildForm(new Forms.CallSecCountForm(), sender);
                }*/

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //openChildForm(new Forms.About(), sender);
            BunifuPages.SetPage("About");
            openChildFormPage(new Forms.About(), sender, tabAbout);
        }

        /*private void btnAddCDR_Click(object sender, EventArgs e)
        {
            openChildForm(new Form1(), sender);
        }*/

        private void CDRAnalyzer_Load(object sender, EventArgs e)
        {
            btnMaimize.PerformClick();
            BunifuPages.SetPage("Add Case");
            openChildFormPage(new Forms.ShowCaseProjectDetailsForm(), sender, tabAddCase);
        }



        private void btnAddCaseProject_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("Add Case");
            openChildFormPage(new Forms.ShowCaseProjectDetailsForm(), sender, tabAddCase);
        }


        private void btnAddCDR_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("Add CDR");
            openChildFormPage(new Form1(), sender, tabAddCDR);

        }

        private void btnGMap_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("GMap");
            openChildFormPage(new Forms.GMapForm(), sender, tabGMap);
        }

        private void btnLinkAnaly_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("Link Analysis");
            openChildFormPage(new Forms.LinkAnalysisForm(), sender, tabLinkAnalysis);
        }

        private void btnCDRSum_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("CDR Summary");
                openChildFormPage(new Forms.CDRSummaryForm(), sender, tabCDRSummary);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        // button to get location summary
        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("Loc Summary");
                openChildFormPage(new Forms.LocationSummary(), sender, tabLocSummary);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnBasicConver_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("Basic Conver");
                openChildFormPage(new Forms.BasicConversationInfoForm(), sender, tabBasicConver);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnSilentPurged_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("Silent Purged");
                openChildFormPage(new Forms.SilentOrPurgedForm(), sender, tabSilentPurged);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnImeiUsed_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("IMEI Used");
                openChildFormPage(new Forms.IMEIForm(), sender, tabIMEIUsed);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnCallsCount_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("Calls Count");
                openChildFormPage(new Forms.CallsCountForm(), sender, tabCallsCount);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnCallsCountSec_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("Calls Sec");
                openChildFormPage(new Forms.CallSecCountForm(), sender, tabCallsSec);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnFormatCDR_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("Format CDR");
            openChildFormPage(new Forms.CDRFormatForm(), sender, tabFormatCDR);
        }

        private void btnNewNum_Click(object sender, EventArgs e)
        {
            /*if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("New Num");
                openChildFormPage(new Forms.NewNumbersForm(), sender, tabNewNum);
            }*/
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("New Num");
                openChildFormPage(new Forms.NewNumbersForm(), sender, tabNewNum);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("Search");
            openChildFormPage(new Forms.SubInfoForm(), sender, tabSearch);
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("Relation");
                openChildFormPage(new Forms.RelationGraphForm(), sender, tabRelation);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void btnBTS_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("BTS");
            openChildFormPage(new Forms.BTSAnalyzer(), sender, tabBTS);
        }

        private void btnSubSearch_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            BunifuPages.SetPage("Sub Search");
            openChildFormPage(new Forms.SubscriberSearchForm(), sender, tabsubSearch);
        }

        private void btnTimeLine_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("CDR Summary");
                openChildFormPage(new Forms.TimeLineForm(), sender, tabCDRSummary);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }

        private void CDRAnalyzer_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnMissingDates_Click(object sender, EventArgs e)
        {
            if (Common.a_numForAnalysis != null)
            {
                indicator.Top = ((Control)sender).Top;
                BunifuPages.SetPage("New Num");
                openChildFormPage(new Forms.MissingDatesForm(), sender, tabNewNum);
            }
            else
            {
                CommonMethods.messageDialog(Common.select_num);
            }
        }
    }
}
