using Bunifu.Charts.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;

namespace ReadExcelApp.Forms
{
    public partial class CallsCountForm : Form
    {
        List<TopB_NumCount> callsInOutlst = null;
        List<AllRecordA_Num> selectedRecordsA_Num, morningRecordsA_Num, dayRecordsA_Num, eveningRecordsA_Num;

        public CallsCountForm()
        {
            InitializeComponent();
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void CallsCountForm_Load(object sender, EventArgs e)
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

            panelDT.Enabled = false;

            labelA_Num.Text = Common.a_numForAnalysis;

            callsInOutList(Common.allRecordA_Nums);

            pcCallsInOut.LegendLocation = LegendLocation.Top;
        }


        private void callsInOutList(List<AllRecordA_Num> inoutList)
        {

            try
            {
                if (inoutList.Count > 0)
                {


                    // Make new unique list
                    HashSet<string> uniqueB_Num = inoutList.AsEnumerable()
                        .Where(x => x.Call_Type.Equals("voice")).Select(b => b.B_Num).Distinct().ToHashSet();
                    int B_NumCount = 0;
                    List<TopB_NumCount> lstCallInOut = new List<TopB_NumCount>();
                    foreach (string b_num in uniqueB_Num)
                    {

                        // counting Call_Type = 'voice'
                        /*string B_NumCountQry = "exec dbo.SP_COUNT_B_Num_Voice '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "' , '" + b_num + "'";
                        B_NumCount = CommonMethods.getTotalCount(B_NumCountQry);*/
                        B_NumCount = inoutList.AsEnumerable()
                            .Where(x => x.Call_Type.Equals("voice") && x.B_Num.Equals(b_num)).Count();

                        TopB_NumCount topB_Num = new TopB_NumCount(b_num, B_NumCount);
                        lstCallInOut.Add(topB_Num);
                    }

                    /*Aranging the list in decending order on the basis of B_NumCount and getting only top 5 B_Num*/
                    callsInOutlst = lstCallInOut.OrderByDescending(tl => tl.B_NumCount).ToList();
                    gvCallsInOut.DataSource = callsInOutlst;

                    gvCallsInOut.Columns[0].HeaderText = "B Party";
                    gvCallsInOut.Columns[1].HeaderText = "Calls Count";

                    lbListSize.Text = callsInOutlst.Count.ToString();

                    SeriesCollection series = new SeriesCollection();

                    //List<double> data = new List<double>();

                    if (callsInOutlst.Count > 5)
                    {
                        foreach (var bc in callsInOutlst.GetRange(0, 5))
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.B_Num/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { bc.B_NumCount },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcCallsInOut.Series = series;

                            /*data.Add(bc.B_NumCount);

                            bunifuPolarAreaChart.Data = data;

                            bunifuPolarAreaChart.TargetCanvas = bunifuChartCanvas;

                            *//*
                            * Hide grid lines
                            *//*
                            bunifuChartCanvas.XAxesGridLines = false;
                            bunifuChartCanvas.YAxesGridLines = false;

                            *//*
                            * For this example we will use random numbers
                            *//*
                            var r = new Random();

                            *//*
                            * Beautify the chart by sepcifying the colors
                            * Color count should correspond to data count
                            *//*
                            List<Color> bgColors = new List<Color>();
                            for (int i = 0; i < data.Count; i++)
                            {
                                bgColors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));

                            }

                            bunifuPolarAreaChart.BackgroundColor = bgColors;*/

                        }
                        
                    }
                    else
                    {
                        foreach (var bc in callsInOutlst)
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.B_Num/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { bc.B_NumCount },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcCallsInOut.Series = series;
                        }
                    }
                }
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
                callsInOutList(morningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbEvening_Click(object sender, EventArgs e)
        {
            eveningRecordsA_Num = new List<AllRecordA_Num>();

            try
            {
                eveningRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.eStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.eEnd).ToList();
                callsInOutList(eveningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbDay_Click(object sender, EventArgs e)
        {
            dayRecordsA_Num = new List<AllRecordA_Num>();

            try
            {
                dayRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.dStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.dEnd).ToList();
                callsInOutList(dayRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbAllData_Click(object sender, EventArgs e)
        {
            panelDT.Enabled = false;
            flpTime.Enabled = true;

            rbDay.Checked = false; rbMorning.Checked = false; rbEvening.Checked = false;
            // get all call records
            callsInOutList(Common.allRecordA_Nums);
        }

        private void rbSelected_Click(object sender, EventArgs e)
        {
            panelDT.Enabled = true;
            flpTime.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            try
            {
                if (selectedRecordsA_Num.Count > 0)
                {
                    callsInOutList(selectedRecordsA_Num);
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

        private void gvCallsInOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string b_num = gvCallsInOut.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (!rbSelected.Checked)
            {
                if (rbMorning.Checked)
                {
                    getDetailedRecords(b_num, morningRecordsA_Num);
                }
                else if (rbDay.Checked)
                {
                    getDetailedRecords(b_num, dayRecordsA_Num);
                }
                else if (rbEvening.Checked)
                {
                    getDetailedRecords(b_num, eveningRecordsA_Num);
                }
                else
                {
                    getDetailedRecords(b_num, Common.allRecordA_Nums);
                }
            }
            else
            {
                getDetailedRecords(b_num, selectedRecordsA_Num);
            }
        }

        //function to get records when cell clicked for detailed records
        private void getDetailedRecords(string b_num, List<AllRecordA_Num> list)
        {
            try
            {
                // to get only list with voice records
                var voiceList = list.Where(x => x.Call_Type.Equals("voice"));

                var lookup = voiceList.ToLookup(i => i.B_Num, j => new { j.Call_Dur, j.Call_Dir, j.Call_Type, j.Date, j.Time, j.Loc });

                List<CDRSummaryDetail> summaryDetails = new List<CDRSummaryDetail>();
                foreach (var item in lookup)
                {
                    if (item.Key.Equals(b_num))
                    {

                        foreach (var i in item)
                        {
                            CDRSummaryDetail summaryDetail = new CDRSummaryDetail();
                            summaryDetail.B_Num = b_num;
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
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
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
                        /*MessageBox.Show();*/
                        new Forms.MsgBox("Please, Enter Range Less Than Or Equal To " + maxRange.ToString()).ShowDialog();
                    }
                    else
                    {
                        gvCallsInOut.DataSource = callsInOutlst.Take(getRange).ToList();
                        SeriesCollection series = new SeriesCollection();

                        foreach (var bc in callsInOutlst.Take(getRange).ToList())
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.B_Num/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { bc.B_NumCount },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcCallsInOut.Series = series;
                        }
                    }
                }
                else
                {

                    new Forms.MsgBox("Please, Enter Range In The TextBox").ShowDialog();
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            string fileName = "Calls Count";
            CommonMethods.exportPDF(gvCallsInOut, fileName);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvCallsInOut);
        }
    }
}
