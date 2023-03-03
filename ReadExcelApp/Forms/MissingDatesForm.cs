using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class MissingDatesForm : Form
    {
        List<TimeLine> timeLineList = new List<TimeLine>();
        List<YearMonthDay> yearsMonthsDaysList = new List<YearMonthDay>();
        IDictionary<YearMonthDay, int> ymdCovCount = new Dictionary<YearMonthDay, int>();
        IDictionary<YearMonthDay, string> ymdBNum = new Dictionary<YearMonthDay, string>();
        List<YearMonths> yearMonthsList = new List<YearMonths>();
        List<YearMonthDay> uniqueYearMonthList;
        List<YearMonths> uniqueYearMonths;
        List<DateTime> missingDatesList = new List<DateTime>();
        string b_party_type;
        string b_party_country;
        public MissingDatesForm()
        {
            InitializeComponent();
        }

        private void MissingDatesForm_Load(object sender, EventArgs e)
        {

            if (Common.allRecordA_Nums.Count > 0)
            {
                foreach (AllRecordA_Num allRecordA_Num in Common.allRecordA_Nums)
                {
                    int yr = Convert.ToDateTime(allRecordA_Num.Date).Year;
                    int mth = Convert.ToDateTime(allRecordA_Num.Date).Month;
                    int day = Convert.ToDateTime(allRecordA_Num.Date).Day;
                    /*string year = Convert.ToDateTime(allRecordA_Num.Date).ToString("yyyy");
                    string month = Convert.ToDateTime(allRecordA_Num.Date).ToString("MMM");
                    string day = Convert.ToDateTime(allRecordA_Num.Date).ToString("dd");*/
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

                }

                uniqueYearMonthList = RemoveDuplicateValues(yearsMonthsDaysList);
                uniqueYearMonths = RemoveDuplicateValuesYM(yearMonthsList);
                DataTable ymdCovCountDT = new DataTable();
                DataColumn dc;
                DataRow dr;
                dc = new DataColumn();
                dc.DataType = typeof(string);
                dc.ColumnName = "yr";
                ymdCovCountDT.Columns.Add(dc);

                dc = new DataColumn();
                dc.DataType = typeof(string);
                dc.ColumnName = "mth";
                ymdCovCountDT.Columns.Add(dc);

                for (int i = 1; i <= 31; i++)
                {
                    dc = new DataColumn();
                    dc.DataType = typeof(string);
                    dc.ColumnName = i.ToString();
                    ymdCovCountDT.Columns.Add(dc);
                }

                foreach (var itm in uniqueYearMonths)
                {
                    dr = ymdCovCountDT.NewRow();
                    dr["yr"] = itm.year;
                    
                    //Converting month to from int to name like 9 to sep
                    dr["mth"] = new DateTime(itm.year,itm.month,1).ToString("MMM");

                    for (int i = 1; i <= DateTime.DaysInMonth(itm.year, itm.month); i++)
                    {
                        dr[i.ToString()] = 0;
                        foreach (var item in uniqueYearMonthList)
                        {
                            int covCountPerDay = ymdBNum.Where(k => k.Key.year.Equals(item.year)
                            && k.Key.month.Equals(item.month)
                            && k.Key.day.Equals(item.day)).Select(v => v.Value).Count();

                            if (item.year.Equals(itm.year)
                            && item.month.Equals(itm.month)
                            && item.day.Equals(i))
                            {
                                dr[i.ToString()] = covCountPerDay;
                            }
                        }
                    }

                    ymdCovCountDT.Rows.Add(dr);
                }

                //Replace first row extra dates from 0 to ""
                // 0 represent missing dates
                // "" represent extra dates which are not in CDR
                for (int i = 2; i < ymdCovCountDT.Columns.Count; i++)
                {
                    if (ymdCovCountDT.Columns[i].ColumnName.Equals(uniqueYearMonthList.ElementAt(0).day.ToString()))
                    {
                        break;
                    }
                    else
                    {
                        ymdCovCountDT.Rows[0][i] = "";
                    }

                }

                //Replace last row extra dates from 0 to ""
                // 0 represent missing dates
                // "" represent extra dates which are not in CDR
                for (int i = uniqueYearMonthList.ElementAt(uniqueYearMonthList.Count - 1).day + 2; i < ymdCovCountDT.Columns.Count; i++)
                {

                    ymdCovCountDT.Rows[ymdCovCountDT.Rows.Count - 1][i] = "";
                }

                gvMissingDates.DataSource = ymdCovCountDT;

                /*foreach(var item in missingDatesList)
                Console.WriteLine("Missing Dates: {0} {1} {2}", item.Year, item.Month, item.Day);*/

                /*foreach (DataGridViewRow row in gvMissingDates.Rows)
                {
                    foreach (DataGridViewColumn clm in gvMissingDates.Columns)
                    {
                        if (gvMissingDates.Rows[row.Index].Cells[clm.Index].Value != null)
                            if (gvMissingDates.Rows[row.Index].Cells[clm.Index].Value.ToString().Equals("0"))
                            {
                                gvMissingDates.Rows[row.Index].Cells[clm.Index].Selected = true;
                            }
                    }
                }*/


                /*foreach (var item in uniqueYearMonthList)
                {
                    *//*dr = ymdCovCountDT.NewRow();
                    dr["year"] = item.year;
                    dr["month"] = item.month;

                    for (int i = 1; i <= DateTime.DaysInMonth(item.year, item.month); i++)
                    {

                        dr[i.ToString()] = 0;
                    }

                    ymdCovCountDT.Rows.Add(dr);*//*

                    int covCountPerDay = ymdBNum.Where(k => k.Key.year.Equals(item.year)
                    && k.Key.month.Equals(item.month)
                    && k.Key.day.Equals(item.day)).Select(v => v.Value).Count();
                    ymdCovCount.Add(item, covCountPerDay);
                    Console.WriteLine("yr: {0}, mth: {1}, day: {2}, Count: {3}"
                        , item.year
                        , item.month
                        , item.day, covCountPerDay);
                }*/
            }
        }

        


        private List<YearMonths> RemoveDuplicateValuesYM(List<YearMonths> list)
        {

            List<YearMonths> set = new List<YearMonths>();
            foreach (var item in list)
            {
                /*int index = set.FindIndex(y => y.year == timeLine.year &&
               y.month == timeLine.month && y.day == timeLine.day);
                if(index != -1)*/
                if (set.FindIndex(y => y.year == item.year &&
                 y.month == item.month) != -1)
                {
                    //set.Add(timeLine);
                }
                else
                {
                    set.Add(item);
                }
            }
            return set;
        }
        private List<YearMonthDay> RemoveDuplicateValues(List<YearMonthDay> list)
        {

            List<YearMonthDay> set = new List<YearMonthDay>();
            foreach (var item in list)
            {
                /*int index = set.FindIndex(y => y.year == timeLine.year &&
               y.month == timeLine.month && y.day == timeLine.day);
                if(index != -1)*/
                if (set.FindIndex(y => y.year == item.year
                && y.month == item.month
                && y.day == item.day) != -1)
                {
                    //set.Add(timeLine);
                }
                else
                {
                    set.Add(item);
                }
            }
            return set;
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

        private void gvMissingDates_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle myColor = gvMissingDates.DefaultCellStyle.Clone();
            int missingDatesCount = 0;
            
            foreach (DataGridViewRow row in gvMissingDates.Rows)
            {
                if (!row.IsNewRow)
                {
                    int year = int.Parse(gvMissingDates.Rows[row.Index].Cells[0].Value.ToString());

                    // Converting month from name to int like sep to 9
                    int month = DateTime.ParseExact(gvMissingDates.Rows[row.Index].Cells[1].Value.ToString(), "MMM", CultureInfo.CurrentCulture).Month;
                    

                    gvMissingDates.Rows[row.Index].Cells[0].Selected = true;
                    gvMissingDates.Rows[row.Index].Cells[1].Selected = true;

                    
                    
                    foreach (DataGridViewColumn clm in gvMissingDates.Columns)
                    {
                        
                            if (gvMissingDates.Rows[row.Index].Cells[clm.Index].Value.ToString().Equals("0"))
                            {
                                gvMissingDates.Rows[row.Index].Cells[clm.Index].Style.BackColor = Color.Red;
                                gvMissingDates.Rows[row.Index].Cells[clm.Index].Style.ForeColor = Color.Red;
                                int day = int.Parse(clm.HeaderText);
                                missingDatesList.Add(new DateTime(year, month, day));
                                missingDatesCount += 1;
                            }
                    }
                }
            }

            lbMissingDates.Text = missingDatesCount.ToString() + " x Missing Dates shown in RED color";
        }
    }
}
