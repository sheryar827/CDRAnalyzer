using LiveCharts;
using LiveCharts.Wpf;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class CallSecCountForm : Form
    {
        List<TopB_NumCallSec> top5B_Num = null;
        List<AllRecordA_Num> selectedRecordsA_Num, morningRecordsA_Num, dayRecordsA_Num, eveningRecordsA_Num;

        public CallSecCountForm()
        {
            InitializeComponent();
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);


        private void CallSecCountForm_Load(object sender, EventArgs e)
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
            //callsSecsCount();
            callsSecsCountList(Common.allRecordA_Nums);
            pcCallsSecCount.LegendLocation = LegendLocation.Top;
        }


        private void callsSecsCountList(List<AllRecordA_Num> callsSecList)
        {
            try
            {
                SeriesCollection series = new SeriesCollection();

                if (callsSecList.Count > 0)
                {
                    // Create list with unique values
                    var uniqueB_NumCallSec = callsSecList
                        .Where(x => x.Call_Type.Equals("voice")).Select(c => new { c.B_Num, c.Call_Dur }).ToList();

                    // Adding Call seconds of same number togather
                    var result = uniqueB_NumCallSec.GroupBy(b_num => b_num.B_Num)
                        .Select(gr => new TopB_NumCallSec(gr.Key
                        , TimeSpan.FromSeconds(gr.Sum(x => Convert.ToInt32(x.Call_Dur))).ToString()
                        , gr.Sum(x => Convert.ToInt32(x.Call_Dur))));


                    /* Aranging the list in decending order on the basis of B_NumCallSec*/
                    top5B_Num = result.OrderByDescending(t1 => t1.B_NumCallSec).ToList();

                    gvCallsSecCount.DataSource = top5B_Num;

                    gvCallsSecCount.Columns[0].HeaderText = "B Party";
                    gvCallsSecCount.Columns[1].HeaderText = "Duration";

                    gvCallsSecCount.Columns[2].Visible = false;

                    lbListSize.Text = top5B_Num.Count.ToString();
                    if (top5B_Num.Count > 5)
                    {
                        foreach (var b_num in top5B_Num.GetRange(0, 5))
                        {

                            series.Add(item: new PieSeries() { Title = b_num.B_Num, Values = new ChartValues<int> { b_num.B_NumCallSec }, DataLabels = true, LabelPoint = labelPoint });
                            pcCallsSecCount.Series = series;
                        }
                    }
                    else
                    {
                        foreach (var b_num in top5B_Num)
                        {

                            series.Add(item: new PieSeries() { Title = b_num.B_Num, Values = new ChartValues<int> { b_num.B_NumCallSec }, DataLabels = true, LabelPoint = labelPoint });
                            pcCallsSecCount.Series = series;
                        }
                    }
                }
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

                        new Forms.MsgBox("Please, Enter Range Less Than Or Equal To " + maxRange.ToString()).ShowDialog();
                    }
                    else
                    {
                        gvCallsSecCount.DataSource = top5B_Num.Take(getRange).ToList();
                        SeriesCollection series = new SeriesCollection();

                        foreach (var bc in top5B_Num.Take(getRange).ToList())
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.B_Num/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> {bc.B_NumCallSec},
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcCallsSecCount.Series = series;
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
            string fileName = "Calls Duration";
            CommonMethods.exportPDF(gvCallsSecCount, fileName);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvCallsSecCount);
        }

        private void rbMorning_Click(object sender, EventArgs e)
        {
            morningRecordsA_Num = new List<AllRecordA_Num>();
            try
            {
                morningRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.mStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.mEnd).ToList();
                callsSecsCountList(morningRecordsA_Num);
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
                callsSecsCountList(eveningRecordsA_Num);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
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
                    callsSecsCountList(selectedRecordsA_Num);
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

        private void rbDay_Click(object sender, EventArgs e)
        {
            dayRecordsA_Num = new List<AllRecordA_Num>();

            try
            {
                dayRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Time).TimeOfDay >= Common.dStart
            && Convert.ToDateTime(t.Time).TimeOfDay <= Common.dEnd).ToList();
                callsSecsCountList(dayRecordsA_Num);
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
            // get all call records
            callsSecsCountList(Common.allRecordA_Nums);
        }
    }
}
