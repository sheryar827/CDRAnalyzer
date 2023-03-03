using DGVPrinterHelper;
using LiveCharts;
using LiveCharts.Wpf;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class LocationSummary : Form
    {
        List<TopLocations> top5Loc;
        List<AllRecordA_Num> selectedRecordsA_Num, morningRecordsA_Num, dayRecordsA_Num, eveningRecordsA_Num;

        public LocationSummary()
        {
            InitializeComponent();
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void topFiveLocations(List<AllRecordA_Num> recordA_Nums)
        {


            if (recordA_Nums.Count > 0)
            {

                // Make new unique list of locations
                //HashSet<string> uniqueLoc = recordA_Nums.AsEnumerable().Select(x => x.Loc.ToString()).Distinct().ToHashSet();
                var lookup = recordA_Nums.ToLookup(i => i.Loc.ToString(), j => new { j.Call_Dir, j.Call_Type });
                
                int locCount = 0;
                int inCmCalls = 0;
                int outGngCalls = 0;
                int inCmSms = 0;
                int outGngSms = 0;
                
                List<TopLocations> topFiveLoc = new List<TopLocations>();
                
                foreach(var item in lookup)
                {
                    inCmCalls = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.voice)).Count();
                    
                    outGngCalls = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.voice)).Count();

                    inCmSms = item.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.sms)).Count();

                    outGngSms = item.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.sms)).Count();

                    TopLocations topLoc = new TopLocations(item.Key, inCmCalls, outGngCalls, inCmSms, outGngSms,
                    inCmCalls + inCmSms + outGngCalls + outGngSms);
                    
                    topFiveLoc.Add(topLoc);
                }
                /*foreach (string Loc in uniqueLoc)
                {
                    locCount = recordA_Nums.Where(loc => loc.Loc.Equals(Loc)).Count();

                    TopLocations topLoc = new TopLocations(Loc, locCount);
                    topFiveLoc.Add(topLoc);
                }*/

                /*Aranging the list in decending order on the basis of Locations Count and getting only top 5 locations*/
                top5Loc = topFiveLoc.OrderByDescending(tl => tl.Total).ToList();
                gvTopFiveLoc.DataSource = top5Loc;
                lbListSize.Text = top5Loc.Count.ToString();

                SeriesCollection series = new SeriesCollection();

                if (top5Loc.Count >= 5)
                {
                    foreach (var bc in top5Loc.GetRange(0, 5))
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.Loc/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.Total },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcLocSummary.Series = series;
                    }
                }
                else
                {
                    foreach (var bc in top5Loc)
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.Loc/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { bc.Total },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcLocSummary.Series = series;
                    }
                }



            }

        }

        private void LocationSummary_Load(object sender, EventArgs e)
        {
            panelDT.Enabled = false;

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
            topFiveLocations(Common.allRecordA_Nums);
            pcLocSummary.LegendLocation = LegendLocation.Top;
        }



        private void btnPrintLoc_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Location Summary Report"; //Header
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "CDR Analyzer"; //Footer
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            //CDRSummaryGridView.DefaultCellStyle.Font = new Font("Tahoma", 8);
            printer.PrintDataGridView(gvTopFiveLoc);
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
                        gvTopFiveLoc.DataSource = top5Loc.Take(getRange).ToList();
                        SeriesCollection series = new SeriesCollection();

                        foreach (var bc in top5Loc.Take(getRange).ToList())
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.Loc/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { bc.Total },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcLocSummary.Series = series;
                        }
                    }
                }
                else
                {

                    CommonMethods.messageDialog("Please, Enter Range In The TextBox");
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            string fileName = "Location Summary";
            CommonMethods.exportPDF(gvTopFiveLoc, fileName);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvTopFiveLoc);
        }

        private void gvTopFiveLoc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            progressBar.Visible = false;
            gbLocationSummary.Text = "Location Summary";
        }

        private void rbAllData_Click(object sender, EventArgs e)
        {
            try
            {
                panelDT.Enabled = false;
                flpTime.Enabled = true;
                rbDay.Checked = false; rbMorning.Checked = false; rbEvening.Checked = false;
                topFiveLocations(Common.allRecordA_Nums);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Sql Query to get every row from CDRTable
                DateTime startDate = Convert.ToDateTime(dtpDateFrom.Value.ToString("yyyy/MM/dd"));
                DateTime endDate = Convert.ToDateTime(dtpDateTo.Value.ToString("yyyy/MM/dd"));
                // Converting time to 24H format and removing PM, AM from it e.g 16:00:00 AM getting only first 8 char like 16:00:00
                TimeSpan startTime = Convert.ToDateTime(dtpTimeFrom.Value.ToString("HH:mm:ss tt").Substring(0, 8)).TimeOfDay;
                TimeSpan endTime = Convert.ToDateTime(dtpTimeTo.Value.ToString("HH:mm:ss tt").Substring(0, 8)).TimeOfDay;

                selectedRecordsA_Num = new List<AllRecordA_Num>();
                selectedRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Date) >= startDate && Convert.ToDateTime(t.Date) <= endDate
                && Convert.ToDateTime(t.Time).TimeOfDay >= startTime && Convert.ToDateTime(t.Time).TimeOfDay <= endTime).ToList();

                if (selectedRecordsA_Num.Count > 0)
                {
                    topFiveLocations(selectedRecordsA_Num);
                }
                else
                {
                    CommonMethods.messageDialog(Common.NoRecord);
                }

            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void gvTopFiveLoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string location = gvTopFiveLoc.Rows[e.RowIndex].Cells[0].Value.ToString();
            string columnType = gvTopFiveLoc.Columns[e.ColumnIndex].HeaderText;
            if (!rbSelected.Checked)
            {
                if (rbMorning.Checked)
                {
                    getDetailedRecords(location, columnType, morningRecordsA_Num);
                }
                else if (rbDay.Checked)
                {
                    getDetailedRecords(location, columnType, dayRecordsA_Num);
                }
                else if (rbEvening.Checked)
                {
                    getDetailedRecords(location, columnType, eveningRecordsA_Num);
                }
                else
                {
                    getDetailedRecords(location, columnType, Common.allRecordA_Nums);
                }
            }
            else
            {
                getDetailedRecords(location, columnType, selectedRecordsA_Num);
            }
        }

        //function to get records when cell clicked for detailed records
        private void getDetailedRecords(string loc, string columnType, List<AllRecordA_Num> list)
        {
            try
            {
                var lookup = list.ToLookup(i => i.Loc, j => new { j.B_Num, j.Call_Dur, j.Call_Dir, j.Call_Type, j.Date, j.Time, j.Loc });
                switch (columnType)
                {
                    case Common.callIn:
                        List<CDRSummaryDetail> summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(loc))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming) && i.Call_Type.Equals(Common.voice));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = i.B_Num;
                                    summaryDetail.Duration = i.Call_Dur;
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
                            if (item.Key.Equals(loc))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.outgoing) && i.Call_Type.Equals(Common.voice));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = i.B_Num;
                                    summaryDetail.Duration = i.Call_Dur;
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

                        new CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    case Common.inSMS:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(loc))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming) && i.Call_Type.Equals(Common.sms));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = i.B_Num;
                                    summaryDetail.Duration = i.Call_Dur;
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

                        new CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;

                    case Common.outSMS:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(loc))
                            {
                                var sd = item.Where(i => i.Call_Dir.Equals(Common.outgoing) && i.Call_Type.Equals(Common.sms));
                                foreach (var i in sd)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = i.B_Num;
                                    summaryDetail.Duration = i.Call_Dur;
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

                        new CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    case Common.Total:
                        summaryDetails = new List<CDRSummaryDetail>();
                        foreach (var item in lookup)
                        {
                            if (item.Key.Equals(loc))
                            {

                                foreach (var i in item)
                                {
                                    CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                                    summaryDetail.B_Num = i.B_Num;
                                    summaryDetail.Duration = i.Call_Dur;
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

                        new CDRSummaryDetailsForm(dataTable).ShowDialog();
                        break;
                    default:
                        break;
                }
                /*List<CDRSummaryDetail> summaryDetails = new List<CDRSummaryDetail>();
                foreach (var item in lookup)
                {
                    if (item.Key.Equals(loc))
                    {

                        foreach (var i in item)
                        {
                            CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                            summaryDetail.B_Num = i.B_Num;
                            summaryDetail.Duration = i.Call_Dur;
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

                new CDRSummaryDetailsForm(dataTable).ShowDialog();*/

            
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbMorning_Click(object sender, EventArgs e)
        {
            try
            {
                morningRecordsA_Num = new List<AllRecordA_Num>();
                morningRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.mStart
                && Convert.ToDateTime(t.Time).TimeOfDay <= Common.mEnd).ToList();
                topFiveLocations(morningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbDay_Click(object sender, EventArgs e)
        {
            try
            {
                dayRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.dStart
                && Convert.ToDateTime(t.Time).TimeOfDay <= Common.dEnd).ToList();
                topFiveLocations(dayRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbEvening_Click(object sender, EventArgs e)
        {
            try
            {
                eveningRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.eStart
                && Convert.ToDateTime(t.Time).TimeOfDay <= Common.eEnd).ToList();
                topFiveLocations(eveningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }
    }
}
