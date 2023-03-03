using DGVPrinterHelper;
using LiveCharts;
using LiveCharts.Wpf;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class SilentOrPurgedForm : Form
    {
        List<APartySilentPurged> d;
        List<SilentPurgedLocationDate> silentPurgedLocationDates;
        List<TimeLine> timeLineList = new List<TimeLine>();
        List<YearMonthDay> yearsMonthsDaysList = new List<YearMonthDay>();
        IDictionary<YearMonthDay, int> ymdCovCount = new Dictionary<YearMonthDay, int>();
        IDictionary<YearMonthDay, string> ymdBNum = new Dictionary<YearMonthDay, string>();
        List<YearMonths> yearMonthsList = new List<YearMonths>();
        List<YearMonthDay> uniqueYearMonthList;
        List<YearMonths> uniqueYearMonths;
        List<DateTime> dateTimeList = new List<DateTime>();
        string b_party_type;
        string b_party_country;
        public SilentOrPurgedForm()
        {
            InitializeComponent();
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void SilentOrPurgedForm_Load(object sender, EventArgs e)
        {
            labelA_Num.Text = Common.a_numForAnalysis;
            checkSilentOrPurged();
            pcSilentPurged.LegendLocation = LegendLocation.Top;
        }

        private List<SPDateLoc> getSilentPurgedDateLoc() {

            List<SPDateLoc> spLocDate = new List<SPDateLoc>();
            foreach (AllRecordA_Num allRecordA_Num in Common.allRecordA_Nums)
            {
                int yr = Convert.ToDateTime(allRecordA_Num.Date).Year;
                int mth = Convert.ToDateTime(allRecordA_Num.Date).Month;
                int day = Convert.ToDateTime(allRecordA_Num.Date).Day;
                string hour = Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Hours.ToString();
                string minute = Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Minutes.ToString();
                string b_party = allRecordA_Num.B_Num;
                string call_type = allRecordA_Num.Call_Dir.ToUpper() + " " + allRecordA_Num.Call_Type.ToUpper();
                string duration = TimeSpan.FromSeconds(Double.Parse(allRecordA_Num.Call_Dur)).ToString();
                string location = allRecordA_Num.Loc;
                string cell_id = allRecordA_Num.Cell_ID;
                string imei = allRecordA_Num.IMEI;
                string lat = allRecordA_Num.Lat;
                string lng = allRecordA_Num.Lng;
                string a_aprty = allRecordA_Num.A_Num;
                string date_time = allRecordA_Num.Date + " " + DateTime.Parse(allRecordA_Num.Time).ToString(@"hh\:mm\:ss tt");
                string lac = allRecordA_Num.Lac_No;
                checkNumType(allRecordA_Num.B_Num);
                string dur = allRecordA_Num.Call_Dur;

                timeLineList.Add(new TimeLine(yr.ToString(), mth.ToString(), day.ToString(), hour, minute, b_party, call_type,
                    duration, location, cell_id, imei, lat, lng, a_aprty, date_time, lac, b_party_type,
                    b_party_country, dur));


                yearsMonthsDaysList.Add(new YearMonthDay(yr, mth, day));
                ymdBNum.Add(new YearMonthDay(yr, mth, day), b_party);
                yearMonthsList.Add(new YearMonths(yr, mth));

                //Adding time to date
                spLocDate.Add(new SPDateLoc(new DateTime(yr, mth, day).Add(new TimeSpan(
                    Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Hours
                    , Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Minutes
                    , Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Seconds))
                    , location, call_type, b_party));

                //Adding time to date
                dateTimeList.Add(new DateTime(yr, mth, day).Add(new TimeSpan(
                    Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Hours,
                    Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Minutes,
                    Convert.ToDateTime(allRecordA_Num.Time).TimeOfDay.Seconds)));

            }

            return spLocDate;
        }

        private void checkNumType(string b_num)
        {

            //Given string is numeric
            if (Regex.IsMatch(b_num, @"^\d+$") && b_num.Length > 8)
            {
                if (String.Equals(b_num.Substring(0, 2), "91") && b_num.Length == 12)
                {
                    b_party_type = "International";
                    b_party_country = "India";
                }
                else if (String.Equals(b_num.Substring(0, 2), "92") && b_num.Length == 12)
                {
                    b_party_type = "Domestic";
                    b_party_country = "Pakistan";
                }
                else if (String.Equals(b_num.Substring(0, 2), "93"))
                {
                    b_party_type = "International";
                    b_party_country = "Afghanistan";
                }
                else if (String.Equals(b_num.Substring(0, 2), "98"))
                {
                    b_party_type = "International";
                    b_party_country = "Iran";
                }
                else if (String.Equals(b_num.Substring(0, 3), "971"))
                {
                    b_party_type = "International";
                    b_party_country = "UAE";
                }
                else if (String.Equals(b_num.Substring(0, 3), "966"))
                {
                    b_party_type = "International";
                    b_party_country = "Saudi Arabia";
                }
                else if (String.Equals(b_num.Substring(0, 3), "974"))
                {
                    b_party_type = "International";
                    b_party_country = "Qatar";
                }
                else if (String.Equals(b_num.Substring(0, 3), "968"))
                {
                    b_party_type = "International";
                    b_party_country = "Oman";
                }
            }
            else
            {
                b_party_type = "Other";
                b_party_country = "Pakistan";
            }
        }

        private void checkSilentOrPurged()
        {
            try
            {
               /* string datetimeQry = "SELECT CONVERT(DATETIME, CONVERT(CHAR(8), Date, 112) + ' ' + CONVERT(CHAR(8), Time, 108)), Loc FROM CDR_DB_Tbl where A_Num = '" + Common.a_numForAnalysis + "' and project = '" + Common.project_Name + "'";
                GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(datetimeQry);
                SqlDataReader drDateTime = getSqlDRAndConn.sqlDR;*/
                List<SPDateLoc> spLocDate = getSilentPurgedDateLoc();
                
                /*if (drDateTime.HasRows)
                {
                    Common.dateTimeList = new List<DateTime>();


                    while (drDateTime.Read())
                    {
                        DateTime dateTime = Convert.ToDateTime(drDateTime.GetValue(0).ToString());
                        SPDateLoc spdl = new SPDateLoc(dateTime, drDateTime.GetValue(1).ToString());
                        //string datet = drDateTime["Date"].ToString() + " " + drDateTime["Time"].ToString();
                        Common.dateTimeList.Add(dateTime);
                        spLocDate.Add(spdl);

                        //listBox1.Items.Add(nine);
                    }
                }

                drDateTime.Close();
                getSqlDRAndConn.sqlConn.Close();*/

                dateTimeList = dateTimeList.OrderBy(dtl => dtl).ToList();
                spLocDate = spLocDate.OrderBy(dtl => dtl.dateTime).ToList();

                d = new List<APartySilentPurged>();
                silentPurgedLocationDates = new List<SilentPurgedLocationDate>();

                for (int i = 0; i < dateTimeList.Count - 1; i++)
                {

                    // As datetime contain list which is descending order of StanderizedCDR on the
                    // basis of date that's why end date is present at first position and first
                    // date is present at the end position.
                    /*DateTime startTime = Common.dateTimeList.ElementAt(i);
                    DateTime endTime = Common.dateTimeList.ElementAt(i + 1);*/

                    DateTime startTime = spLocDate.ElementAt(i).dateTime;
                    DateTime endTime = spLocDate.ElementAt(i + 1).dateTime;
                    string startLoc = spLocDate.ElementAt(i).location;
                    string endLoc = spLocDate.ElementAt(i + 1).location;

                    /*string startCallType = spLocDate.ElementAt(i).callType;
                    string startBParty = spLocDate.ElementAt(i).bparty;*/
                    /*string endCallType = spLocDate.ElementAt(i + 1).callType;
                    string endBParty = spLocDate.ElementAt(i + 1).bparty;*/

                    TimeSpan span = endTime - startTime;
                    double daysDiff = span.TotalDays * 24;
                    String silentPurged = null;
                    daysDiff = Math.Round(daysDiff, 0);
                    if (daysDiff >= 12 && daysDiff < 24)
                    {
                        silentPurged = "Silent";
                        APartySilentPurged dtimediff = new APartySilentPurged(startTime.ToString(), endTime.ToString(), daysDiff.ToString(), silentPurged);
                        SilentPurgedLocationDate silentPurgedLocationDate = new SilentPurgedLocationDate(startLoc, startTime.ToString(), endLoc, endTime.ToString(), daysDiff.ToString(), silentPurged,"","","","");
                        silentPurgedLocationDates.Add(silentPurgedLocationDate);
                        d.Add(dtimediff);

                    }
                    else if (daysDiff >= 24)
                    {
                        silentPurged = "Purged";
                        APartySilentPurged dtimediff = new APartySilentPurged(startTime.ToString(), endTime.ToString(), daysDiff.ToString(), silentPurged);

                        // get rage of 0 to i elements
                        string bIn = spLocDate.GetRange(0, i).Where(ct => ct.callType.Equals("INCOMING VOICE")).Select(bp => bp.bparty).Last();
                        string bOut = spLocDate.GetRange(0, i).Where(ct => ct.callType.Equals("OUTGOING VOICE")).Select(bp => bp.bparty).Last();
                        
                        // get range of i to last elements
                        string aIn = spLocDate.GetRange(i, spLocDate.Count - i).Where(ct => ct.callType.Equals("INCOMING VOICE")).Select(bp => bp.bparty).First();
                        string aOut = spLocDate.GetRange(i, spLocDate.Count - i).Where(ct => ct.callType.Equals("OUTGOING VOICE")).Select(bp => bp.bparty).First();
                        /*bparty = spLocDate.GetRange(0, i).Where(ct => ct.callType.Equals("INCOMING VOICE")).Select(bp => bp.bparty).Last();
                    callType = "INCOMING VOICE";*/
                        /*for (int j = i; j < spLocDate.Count; j++)
                            if (spLocDate.ElementAt(j).bparty.Substring(0, 2).Equals("92")
                                && spLocDate.ElementAt(j).bparty.Length == 12
                                && spLocDate.ElementAt(j).callType.Equals("INCOMING VOICE"))
                            {
                                
                                aIn = spLocDate.ElementAt(j).bparty;
                                break;
                            }

                        for (int j = i; j < spLocDate.Count; j++)
                            if (spLocDate.ElementAt(j).bparty.Substring(0, 2).Equals("92")
                                && spLocDate.ElementAt(j).bparty.Length == 12
                                && spLocDate.ElementAt(j).callType.Equals("OUTGOING VOICE"))
                            {

                                aOut = spLocDate.ElementAt(j).bparty;
                                break;
                            }*/

                        SilentPurgedLocationDate silentPurgedLocationDate = new SilentPurgedLocationDate(startLoc
                            , startTime.ToString()
                            , endLoc, endTime.ToString()
                            , daysDiff.ToString()
                            , silentPurged
                            , bIn
                            , bOut
                            , aIn
                            , aOut);
                        silentPurgedLocationDates.Add(silentPurgedLocationDate);
                        d.Add(dtimediff);
                        
                    }

                }

                /*List<APartySilentPurged> orderAParySP = d.OrderBy(dec => dec.StartDate).ToList();*/
                //gvSilentPurged.DataSource = d;
                gvSilentPurged.DataSource = silentPurgedLocationDates;

                lbListSize.Text = silentPurgedLocationDates.Count.ToString();

                SeriesCollection series = new SeriesCollection();
                if (silentPurgedLocationDates.Count > 0)
                {
                    if (silentPurgedLocationDates.Count > 5)
                    {
                        foreach (var bc in silentPurgedLocationDates.GetRange(0, 5))
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.startdate + ":" + bc.duration + " h"/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { Convert.ToInt32(bc.duration) },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcSilentPurged.Series = series;
                        }
                    }
                    else
                    {
                        foreach (var bc in silentPurgedLocationDates)
                        {
                            series.Add(item: new PieSeries()
                            {
                                Title = bc.startdate + ":" + bc.duration + " h"/*BasicConversation contain B-Party Contact Number*/
                                ,
                                Values = new ChartValues<int> { Convert.ToInt32(bc.duration) },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            });
                            pcSilentPurged.Series = series;
                        }
                    }
                }
                else
                {

                    CommonMethods.messageDialog("Please Upload CDR To Analyze or No Silent/Purged Found!");
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            gvSilentPurged.Refresh();
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
                    gvSilentPurged.DataSource = silentPurgedLocationDates.Take(getRange).ToList();
                    SeriesCollection series = new SeriesCollection();

                    foreach (var bc in silentPurgedLocationDates.Take(getRange).ToList())
                    {
                        series.Add(item: new PieSeries()
                        {
                            Title = bc.startdate + ":" + bc.duration + " h"/*BasicConversation contain B-Party Contact Number*/
                            ,
                            Values = new ChartValues<int> { Convert.ToInt32(bc.duration) },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                        pcSilentPurged.Series = series;
                    }
                }
            }
            else
            {

                CommonMethods.messageDialog("Please, Enter Range In The Text Box");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Silent / Purged Report"; //Header
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
            printer.PrintDataGridView(gvSilentPurged);

        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            string fileName = "Silent Purged";
            CommonMethods.exportPDF(gvSilentPurged, fileName);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvSilentPurged);
        }

        private void txtGetRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo.PerformClick();
            }
        }
    }
}
