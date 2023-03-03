using GMap.NET;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class LocationDetailsForm : Form
    {
        ToolTip ttBtn;
        string locLat, locLng;
        //string aParty = null;
        string a_num = null;
        string project_name = null;
        //string projectName = null;
        List<AllRecordA_Num> list;
        List<CDRSummary> cdrsumm;

        public LocationDetailsForm(PointLatLng pointLatLng, string A_Num, string project_Name
            , List<AllRecordA_Num> list)
        {
            InitializeComponent();

            /*string proc = "exec dbo.SP_Location_Details '"+A_Num+"', '" + pointLatLng.Lat.ToString()+"' , '"+pointLatLng.Lng.ToString()+"'";
            SqlDataAdapter da = CommonMethods.getRecords(proc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                *//*DataRow row = dt.Rows[1];*//*
                int count = dt.Rows.Count;
                
                //lbLocation.Text = row[0].ToString();
            }

            gvLocationDetails.DataSource = dt;*/
            this.list = list;
            locLat = pointLatLng.Lat.ToString();
            locLng = pointLatLng.Lng.ToString();
            a_num = A_Num;
            project_name = project_Name;

            //aParty = A_Num.Substring(0, A_Num.IndexOf(" "));
            //projectName = project_Name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void LocationDetailsForm_Load(object sender, EventArgs e)
        {
            ttBtn = new ToolTip();
            cdrsumm = await CommonMethods.cdrSummary(a_num, project_name, locLat, locLng);
            gvLocationDetails.DataSource = cdrsumm;
        }

        private async void gvLocationDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string bParty = gvLocationDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
            string columnType = gvLocationDetails.Columns[e.ColumnIndex].HeaderText;
            getDetailedRecords(bParty, locLat, locLng, columnType);
            
            //Console.WriteLine(aParty);
            //Console.WriteLine(projectName);

           /* switch (columnType)
            {
                case Common.callIn:
                    string inCallProc = "exec dbo.Loc_Calls_Details '" + aParty + "', '" + projectName + "', '" + bParty + "', '" + locLat + "', '" + locLng + "', 'incoming', 'voice'";
                    new Forms.CDRSummaryDetailsForm(await CommonMethods.getRecords(inCallProc)).ShowDialog();
                    break;
                case Common.callOut:
                    string outCallProc = "exec dbo.Loc_Calls_Details '" + aParty + "', '" + projectName + "', '" + bParty + "', '" + locLat + "', '" + locLng + "', 'outgoing', 'voice'";
                    new Forms.CDRSummaryDetailsForm(await CommonMethods.getRecords(outCallProc)).ShowDialog();
                    break;
                case Common.inSMS:
                    string inSMSProc = "exec dbo.Loc_Calls_Details '" + aParty + "', '" + projectName + "', '" + bParty + "', '" + locLat + "', '" + locLng + "', 'incoming', 'sms'";
                    break;
                case Common.outSMS:
                    string outSMSProc = "exec dbo.Loc_Calls_Details '" + aParty + "', '" + projectName + "', '" + bParty + "', '" + locLat + "', '" + locLng + "', 'outgoing', 'sms'";
                    new Forms.CDRSummaryDetailsForm(await CommonMethods.getRecords(outSMSProc)).ShowDialog();
                    break;
                case Common.Total:
                    string total = "exec dbo.Loc_Total_CDR_Summary_Details '" + aParty + "', '" + projectName + "', '" + bParty + "', '" + locLat + "', '" + locLng + "'";
                    new Forms.CDRSummaryDetailsForm(await CommonMethods.getRecords(total)).ShowDialog();
                    break;
                default:
                    break;

            }*/
        }

        private void btnSubInfo_Click(object sender, EventArgs e)
        {
            clearGridView();
            gvLocationDetails.DataSource = CommonMethods.getSubDataList(cdrsumm);
        }

        public void clearGridView()
        {
            gvLocationDetails.DataSource = null;
            gvLocationDetails.Rows.Clear();
            gvLocationDetails.Columns.Clear();
            gvLocationDetails.Refresh();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvLocationDetails);
        }

        private void btnSubInfo_MouseHover(object sender, EventArgs e)
        {
            
            ttBtn.SetToolTip(this.btnSubInfo, "Click To Attach SubInfo!");
        }

        private void btnExportExcel_MouseHover(object sender, EventArgs e)
        {
            ttBtn.SetToolTip(this.btnExportExcel, "Click To Export In Excel!");
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            ttBtn.SetToolTip(this.btnClose, "Click To Close!");
        }

        private void getDetailedRecords(string bParty, string lat, string lng, string columnType)
        {
            try
            {
                var lookup = list.ToLookup(i => i.B_Num, j => new { j.Call_Dur, j.Call_Dir, j.Call_Type, j.Date, j.Time, j.Loc, j.Lat, j.Lng });

                switch (columnType)
                {

                    case Common.callIn:
                        List<CDRSummaryDetail> summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(bParty))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming) 
                                && i.Lat.Equals(lat) && i.Lng.Equals(lng) 
                                && i.Call_Type.Equals(Common.voice));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = DateTime.Parse(i.Time).ToString(@"hh\:mm\:ss tt");
                                    summaryDetail.Location = i.Loc;
                                    summaryDetails.Add(summaryDetail);
                                }
                            }
                        }
                        ListtoDataTable ltdt = new ListtoDataTable();
                        DataTable dataTable = ltdt.ToDataTable(summaryDetails);

                        new CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    case Common.callOut:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(bParty))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.outgoing)
                                && i.Lat.Equals(lat) && i.Lng.Equals(lng)
                                && i.Call_Type.Equals(Common.voice));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = DateTime.Parse(i.Time).ToString(@"hh\:mm\:ss tt");
                                    summaryDetail.Location = i.Loc;
                                    summaryDetails.Add(summaryDetail);
                                }
                            }
                        }
                        ltdt = new ListtoDataTable();
                        dataTable = ltdt.ToDataTable(summaryDetails);

                        new Forms.CDRSummaryDetailsForm(dataTable).ShowDialog();

                        break;
                    case Common.inSMS:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(bParty))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming)
                                && i.Lat.Equals(lat) && i.Lng.Equals(lng)
                                && i.Call_Type.Equals(Common.sms));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = DateTime.Parse(i.Time).ToString(@"hh\:mm\:ss tt");
                                    summaryDetail.Location = i.Loc;
                                    summaryDetails.Add(summaryDetail);
                                }
                            }
                        }
                        ltdt = new ListtoDataTable();
                        dataTable = ltdt.ToDataTable(summaryDetails);

                        new Forms.CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    case Common.outSMS:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(bParty))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.outgoing)
                                && i.Lat.Equals(lat) && i.Lng.Equals(lng)
                                && i.Call_Type.Equals(Common.sms));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = DateTime.Parse(i.Time).ToString(@"hh\:mm\:ss tt");
                                    summaryDetail.Location = i.Loc;
                                    summaryDetails.Add(summaryDetail);
                                }
                            }
                        }
                        ltdt = new ListtoDataTable();
                        dataTable = ltdt.ToDataTable(summaryDetails);

                        new Forms.CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    case Common.Total:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(bParty))
                            {
                                var sd = item.Where(i=> i.Lat.Equals(lat) && i.Lng.Equals(lng));
                                
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = DateTime.Parse(i.Time).ToString(@"hh\:mm\:ss tt");
                                    summaryDetail.Location = i.Loc;
                                    summaryDetails.Add(summaryDetail);
                                }
                            }
                        }
                        ltdt = new ListtoDataTable();
                        dataTable = ltdt.ToDataTable(summaryDetails);

                        new Forms.CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                CommonMethods.messageDialog(ex.Message + " " + line);
            }
        }
    }
}
