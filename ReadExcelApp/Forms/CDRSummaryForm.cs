using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class CDRSummaryForm : Form
    {
        
        /*string searchQry = null;*/
        CDRSummary cs = null;
        DataTable cdrSum = null;
        DataTable cdrDetail = null;
        /*SubscriberInfo subinfo = null;*/

        //To check sub button is clikced or not
        bool subBtnClick = false;

        //List which have CDR Summary
        //on the basis of morning, daytime, evening
        List<CDRSummary> csByTotalInOut;

        //List which have overall CDR Summary
        List<CDRSummary> cdrCompSumm;

        List<AllRecordA_Num> selectedRecordsA_Num, morningRecordsA_Num, dayRecordsA_Num, eveningRecordsA_Num;




        public CDRSummaryForm()
        {
            InitializeComponent();

        }


        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);


        private void CDRSummaryForm_Load(object sender, EventArgs e)
        {
            try
            {
                //getting start date from datatable
                string sd = Common.allRecordA_Nums.First().Date.ToString();
                string st = Common.allRecordA_Nums.First().Time.ToString();

                //getting end date from datatable
                string ed = Common.allRecordA_Nums.Last().Date.ToString();
                string et = Common.allRecordA_Nums.Last().Time.ToString();

                dtpDateFrom.Value = Convert.ToDateTime(sd);
                dtpDateTo.Value = Convert.ToDateTime(ed);
                dtpTimeFrom.Value = Convert.ToDateTime(st);
                dtpTimeTo.Value = Convert.ToDateTime(et);



                labelA_Num.Text = Common.a_numForAnalysis;

                clearGridView();

                /*CommonMethods.messageDialog("Please Wait...");*/

                dtpTimeFrom.Format = DateTimePickerFormat.Time;
                /*dtpTimeFrom.Format = DateTimePickerFormat.Custom;
                dtpTimeFrom.CustomFormat = "HH:mm:ss tt";*/
                dtpTimeFrom.ShowUpDown = true;

                dtpTimeTo.Format = DateTimePickerFormat.Time;
                /*dtpTimeTo.Format = DateTimePickerFormat.Custom;
                dtpTimeTo.CustomFormat = "HH:mm:ss tt";*/
                dtpTimeTo.ShowUpDown = true;

                /*rbAllData.Checked = true;*/
                panelDT.Enabled = false;

                // Declare Datatable
                cdrSum = new DataTable();
                cdrSum.Columns.Add("Name", typeof(string));
                cdrSum.Columns.Add("CNIC", typeof(string));
                cdrSum.Columns.Add("BParty", typeof(string));
                cdrSum.Columns.Add("In", typeof(string));
                cdrSum.Columns.Add("Out", typeof(string));
                cdrSum.Columns.Add("inSMS", typeof(string));
                cdrSum.Columns.Add("outSMS", typeof(string));
                cdrSum.Columns.Add("Total", typeof(string));

                cdrDetail = new DataTable();
                cdrDetail.Columns.Add("Record From:", typeof(string));
                cdrDetail.Columns.Add("To:", typeof(string));
                cdrDetail.Columns.Add("CDR-AParty:", typeof(string));
                cdrDetail.Columns.Add("Subscriber's Name:", typeof(string));
                cdrDetail.Columns.Add("Subscriber's CNIC:", typeof(string));
                cdrDetail.Columns.Add("Subscriber's Address:", typeof(string));
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }

            getAllSummary(Common.allRecordA_Nums);
        }

        private void cdrSummaryReport()
        {

            foreach (DataGridViewRow dgv in CDRSummaryGridView.Rows)
            {
                cdrSum.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value,
                    dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value,
                    dgv.Cells[6].Value, dgv.Cells[7].Value);
            }

        }



        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            string fileName = "CDR Summary";
            CommonMethods.exportPDF(CDRSummaryGridView, fileName);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            CommonMethods.exportExcel(CDRSummaryGridView);

        }

        private void txtGetRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtGetRange.Text != "")
                {
                    int getRange = Convert.ToInt32(txtGetRange.Text.ToString());
                    int maxRange = Convert.ToInt32(lbListSize.Text.ToString());
                    if (getRange > maxRange)
                    {
                        CommonMethods.messageDialog("Please, Enter Range Less Than Or Equal To " + maxRange.ToString());
                    }
                    else
                    {
                        CDRSummaryGridView.DataSource = csByTotalInOut.Take(getRange).ToList();
                        SeriesCollection series = new SeriesCollection();

                        foreach (var bc in csByTotalInOut.Take(getRange).ToList())
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.BParty/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { bc.Total },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcCDRSummary.Series = series;
                        }
                    }
                }
                else
                {
                    CommonMethods.messageDialog("Please, Enter Range In The TextBox");
                }
            }
        }

        /*private void btnPrintSum_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "CDR Summary Report"; //Header
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "CDR Analyzer"; //Footer
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            CDRSummaryGridView.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8);
            printer.PrintDataGridView(CDRSummaryGridView);
        }*/

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // function to get cdr summary based on selected date and time
            cdrSelectedSummary();
        }

        private void cdrSelectedSummary()
        {
            //string Qry = "select * from CDRTable WHERE Call_Type = 'Voice'";

            // Sql Query to get every row from CDRTable
            DateTime startDate = Convert.ToDateTime(dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            DateTime endDate = Convert.ToDateTime(dtpDateTo.Value.ToString("yyyy/MM/dd"));
            // Converting time to 24H format and removing PM, AM from it e.g 16:00:00 AM getting only first 8 char like 16:00:00
            TimeSpan startTime = Convert.ToDateTime(dtpTimeFrom.Value.ToString("HH:mm:ss tt").Substring(0, 8)).TimeOfDay;
            TimeSpan endTime = Convert.ToDateTime(dtpTimeTo.Value.ToString("HH:mm:ss tt").Substring(0, 8)).TimeOfDay;

            selectedRecordsA_Num = new List<AllRecordA_Num>();
            selectedRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Date) >= startDate && Convert.ToDateTime(t.Date) <= endDate
            && Convert.ToDateTime(t.Time).TimeOfDay >= startTime && Convert.ToDateTime(t.Time).TimeOfDay <= endTime).ToList();

            if (selectedRecordsA_Num.Count() > 0)
            {
                var lookup = selectedRecordsA_Num.ToLookup(i => i.B_Num, j => new { j.Call_Dir, j.Call_Type });

                // List to show in PiChart
                List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();


                List<CDRSummary> cdrsum = new List<CDRSummary>();
                int inCmCalls = 0;
                int outGngCalls = 0;
                int inCmSms = 0;
                int outGngSms = 0;
                foreach (var item in lookup)
                {


                    inCmCalls = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.voice)).Count();

                    outGngCalls = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.voice)).Count();


                    inCmSms = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.sms)).Count();

                    outGngSms = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.sms)).Count();


                    cs = new CDRSummary("", "", item.Key, inCmCalls, inCmSms, outGngCalls, outGngSms,
                    inCmCalls + inCmSms + outGngCalls + outGngSms, "");

                    cdrsum.Add(cs);
                    getBasicConversations.Add(new GetBasicConversation(item.Key, inCmCalls + inCmSms + outGngCalls + outGngSms));

                }

                /*Aranging the list in decending order on the basis of total in our calls and sms*/
                csByTotalInOut = cdrsum.OrderByDescending(cs => cs.Total).ToList();

                
                CDRSummaryGridView.DataSource = new ListtoDataTable().ToDataTable(csByTotalInOut);


                //CDRSummaryGridView.Invoke(new Action(() => { CDRSummaryGridView.DataSource = csByTotalInOut; }));
                cdrSummaryReport();

                /*btnPrev.Enabled = false;*/
                /*lbPage.Text = string.Format("{0}/{1}", pageNumber, csByTotalInOut.Count() / pageSize);*/
                lbListSize.Text = csByTotalInOut.Count().ToString();

                /*Aranging the list in decending order on the basis of total in our calls and sms to display in pichart*/
                List<GetBasicConversation> gbc = getBasicConversations.OrderByDescending(cs => cs.BasicConversationCount).ToList();


                SeriesCollection series = new SeriesCollection();
                if (gbc.Count >= 5)
                {
                    foreach (var bc in gbc.GetRange(0, 5))
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.BasicConversation/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.BasicConversationCount },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcCDRSummary.Series = series;
                    }
                }
                else
                {
                    foreach (var bc in gbc)
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.BasicConversation/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.BasicConversationCount },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcCDRSummary.Series = series;
                    }
                }
            }
            else
            {
                CommonMethods.messageDialog(Common.NoRecord);
            }



        }

        private void CDRSummaryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bParty = CDRSummaryGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            string columnType = CDRSummaryGridView.Columns[e.ColumnIndex].HeaderText;

            if (!rbSelected.Checked)
            {
                if (rbMorning.Checked)
                {
                    getDetailedRecords(bParty, columnType, morningRecordsA_Num);
                }
                else if (rbDay.Checked)
                {
                    getDetailedRecords(bParty, columnType, dayRecordsA_Num);
                }
                else if (rbEvening.Checked)
                {
                    getDetailedRecords(bParty, columnType, eveningRecordsA_Num);
                }
                else
                {
                    getDetailedRecords(bParty, columnType, Common.allRecordA_Nums);
                }
            }
            else
            {
                getDetailedRecords(bParty, columnType, selectedRecordsA_Num);
            }


        }

        //function to get records when cell clicked for detailed records
        private void getDetailedRecords(string bParty, string columnType, List<AllRecordA_Num> list)
        {
            try
            {
                var lookup = list.ToLookup(i => i.B_Num, j => new { j.Call_Dur, j.Call_Dir, j.Call_Type, j.Date, j.Time, j.Loc });

                switch (columnType)
                {

                    case Common.callIn:
                        List<CDRSummaryDetail> summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(bParty))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming) && i.Call_Type.Equals(Common.voice));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = i.Time;
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
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.outgoing) && i.Call_Type.Equals(Common.voice));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = i.Time;
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
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming) && i.Call_Type.Equals(Common.sms));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = i.Time;
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
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.outgoing) && i.Call_Type.Equals(Common.sms));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = i.Time;
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

                                foreach (var i in item)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = bParty;
                                    summaryDetail.Duration = TimeSpan.FromSeconds(Double.Parse(i.Call_Dur)).ToString();
                                    summaryDetail.Diration = i.Call_Dir;
                                    summaryDetail.Type = i.Call_Type;
                                    summaryDetail.Date = i.Date;
                                    summaryDetail.Time = i.Time;
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
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void CDRSummaryGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            progressBar.Visible = false;
            gbCDRSummary.Text = "CDR Summary";
        }

        private void rbEvening_Click(object sender, EventArgs e)
        {
            eveningRecordsA_Num = new List<AllRecordA_Num>();


            try
            {
                eveningRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.eStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.eEnd).ToList();
                getSummary(eveningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }


        }

        private void rbSelected_Click(object sender, EventArgs e)
        {
            panelDT.Enabled = true;
            flpTime.Enabled = false;
        }

        private void rbAllData_Click(object sender, EventArgs e)
        {
            panelDT.Enabled = false;
            flpTime.Enabled = true;

            rbDay.Checked = false; rbMorning.Checked = false; rbEvening.Checked = false;

            // function to get complete cdr summary
            //getAllSummary(Common.allRecordA_Nums);

            CDRSummaryGridView.DataSource = new ListtoDataTable()
                    .ToDataTable(cdrCompSumm);

        }

        private void btnSubInfo_Click(object sender, EventArgs e)
        {
            subBtnClick = true;

            CommonMethods.messageDialog("Please Wait...this will get subinfo of all records!");
            try
            {
                clearGridView();
                CDRSummaryGridView.DataSource = new ListtoDataTable()
                    .ToDataTable(CommonMethods.getSubDataList(cdrCompSumm));
                updatebulk_sub_search_tm_tbl();

            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void updatebulk_sub_search_tm_tbl()
        {
            string proc = "exec dbo.[proc_bulk_sub_search_tm_tbl] '" + Common.userName + "','" + Common.a_numForAnalysis + "'";
            CommonMethods.insertRecords(proc);
        }

        private void rbDay_Click(object sender, EventArgs e)
        {
            dayRecordsA_Num = new List<AllRecordA_Num>();


            try
            {
                dayRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.dStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.dEnd).ToList();
                getSummary(dayRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }


        }

        private void rbMorning_Click(object sender, EventArgs e)
        {
            morningRecordsA_Num = new List<AllRecordA_Num>();

            try
            {
                morningRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.mStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.mEnd).ToList();
                getSummary(morningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }


        }

        private void getAllSummary(List<AllRecordA_Num> list)
        {
            if (list.Count() > 0)
            {
                var lookup = list.ToLookup(i => i.B_Num, j => new { j.Call_Dir, j.Call_Type });

                // List to show in PiChart
                List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();


                List<CDRSummary> cdrsum = new List<CDRSummary>();
                int inCmCalls = 0;
                int outGngCalls = 0;
                int inCmSms = 0;
                int outGngSms = 0;
                foreach (var item in lookup)
                {


                    inCmCalls = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.voice)).Count();

                    outGngCalls = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.voice)).Count();

                    inCmSms = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.sms)).Count();

                    outGngSms = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.sms)).Count();

                    cs = new CDRSummary("", "", CommonMethods.ConvertHex(item.Key).Trim(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                    inCmCalls + inCmSms + outGngCalls + outGngSms, "");

                    cdrsum.Add(cs);

                    getBasicConversations.Add(new GetBasicConversation(item.Key, inCmCalls + inCmSms + outGngCalls + outGngSms));

                }

                /*Aranging the list in decending order on the basis of total in our calls and sms*/
                cdrCompSumm = cdrsum.OrderByDescending(cs => cs.Total).ToList();

                CDRSummaryGridView.DataSource = new ListtoDataTable()
                    .ToDataTable(cdrCompSumm);


                //CDRSummaryGridView.Invoke(new Action(() => { CDRSummaryGridView.DataSource = csByTotalInOut; }));
                cdrSummaryReport();

                /*btnPrev.Enabled = false;*/
                /*lbPage.Text = string.Format("{ 0}/{1}", pageNumber, csByTotalInOut.Count() / pageSize);*/
                lbListSize.Text = cdrCompSumm.Count().ToString();

                /*Aranging the list in decending order on the basis of total in our calls and sms to display in pichart*/
                List<GetBasicConversation> gbc = getBasicConversations.OrderByDescending(cs => cs.BasicConversationCount).ToList();


                SeriesCollection series = new SeriesCollection();
                if (gbc.Count >= 5)
                {
                    foreach (var bc in gbc.GetRange(0, 5))
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.BasicConversation/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.BasicConversationCount },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcCDRSummary.Series = series;
                    }
                }
                else
                {
                    foreach (var bc in gbc)
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.BasicConversation/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.BasicConversationCount },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcCDRSummary.Series = series;
                    }
                }
            }
        }

        private void getSummary(List<AllRecordA_Num> list)
        {
            if (list.Count() > 0)
            {
                var lookup = list.ToLookup(i => i.B_Num, j => new { j.Call_Dir, j.Call_Type });

                // List to show in PiChart
                List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();


                List<CDRSummary> cdrsum = new List<CDRSummary>();
                int inCmCalls = 0;
                int outGngCalls = 0;
                int inCmSms = 0;
                int outGngSms = 0;
                foreach (var item in lookup)
                {


                    inCmCalls = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.voice)).Count();

                    outGngCalls = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.voice)).Count();

                    inCmSms = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.sms)).Count();

                    outGngSms = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.sms)).Count();

                    cs = new CDRSummary("", "", CommonMethods.ConvertHex(item.Key).Trim(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                    inCmCalls + inCmSms + outGngCalls + outGngSms, "");

                    cdrsum.Add(cs);

                    getBasicConversations.Add(new GetBasicConversation(item.Key, inCmCalls + inCmSms + outGngCalls + outGngSms));

                }

                /*Aranging the list in decending order on the basis of total in our calls and sms*/
                csByTotalInOut = cdrsum.OrderByDescending(cs => cs.Total).ToList();

                // if sub button is clicked then get
                // sub info from list otherwise not
                if (subBtnClick)
                {
                    var cdrCompSummlookUp = cdrCompSumm.ToLookup(bp => bp.BParty, subs => new
                    {
                        subs.Name
                          ,
                        subs.CNIC
                          ,
                        subs.Address
                    });



                    foreach (var item in cdrCompSummlookUp)
                    {
                        foreach (var itm in csByTotalInOut)
                        {
                            if (itm.BParty.Equals(item.Key))
                            {
                                itm.Name = item.Select(k => k.Name).First();
                                itm.CNIC = item.Select(k => k.CNIC).First();
                                itm.Address = item.Select(k => k.Address).First();
                            }
                        }
                    }
                }

                

                CDRSummaryGridView.DataSource = new ListtoDataTable()
                    .ToDataTable(csByTotalInOut);


                //CDRSummaryGridView.Invoke(new Action(() => { CDRSummaryGridView.DataSource = csByTotalInOut; }));
                cdrSummaryReport();

                /*btnPrev.Enabled = false;*/
                /*lbPage.Text = string.Format("{ 0}/{1}", pageNumber, csByTotalInOut.Count() / pageSize);*/
                lbListSize.Text = csByTotalInOut.Count().ToString();

                /*Aranging the list in decending order on the basis of total in our calls and sms to display in pichart*/
                List<GetBasicConversation> gbc = getBasicConversations.OrderByDescending(cs => cs.BasicConversationCount).ToList();


                SeriesCollection series = new SeriesCollection();
                if (gbc.Count >= 5)
                {
                    foreach (var bc in gbc.GetRange(0, 5))
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.BasicConversation/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.BasicConversationCount },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcCDRSummary.Series = series;
                    }
                }
                else
                {
                    foreach (var bc in gbc)
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.BasicConversation/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.BasicConversationCount },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcCDRSummary.Series = series;
                    }
                }
            }
        }

        public void clearGridView()
        {
            CDRSummaryGridView.DataSource = null;
            CDRSummaryGridView.Rows.Clear();
            CDRSummaryGridView.Columns.Clear();
            CDRSummaryGridView.Refresh();
        }
    }
}
