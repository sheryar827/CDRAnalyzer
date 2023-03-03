using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class TimeLineForm : Form
    {
        List<TimeLine> timeLineList = new List<TimeLine>();
        string b_party_type;
        string b_party_country;
        public TimeLineForm()
        {
            InitializeComponent();
            panel3.Visible = false;
        }

        private void TimeLineForm_Load(object sender, EventArgs e)
        {

            List<TimeLine> set = new List<TimeLine>();
            if (Common.allRecordA_Nums.Count > 0)
            {
                foreach (AllRecordA_Num allRecordA_Num in Common.allRecordA_Nums)
                {
                    int year = Convert.ToDateTime(allRecordA_Num.Date).Year;
                    int month = Convert.ToDateTime(allRecordA_Num.Date).Month;
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
                    timeLineList.Add(new TimeLine(year.ToString()
                        , Convert.ToDateTime(allRecordA_Num.Date).ToString("MMM")
                        , day.ToString(), hour, minute, b_party, call_type,
                        duration, location, cell_id, imei, lat, lng, a_aprty, date_time, lac, b_party_type,
                        b_party_country, dur));

                }

                //timeLineList = timeLineList.OrderBy(dt => dt.year).ToList();

                foreach (TimeLine timeLine in timeLineList)
                {
                    /*int index = set.FindIndex(y => y.year == timeLine.year &&
                   y.month == timeLine.month && y.day == timeLine.day);
                    if(index != -1)*/
                    if (set.FindIndex(y => y.year == timeLine.year &&
                     y.month == timeLine.month && y.day == timeLine.day) !=  -1)
                    {
                        timeLine.year = "";
                        timeLine.month = "";
                        timeLine.day = "";  

                        set.Add(timeLine);
                    }
                    else
                    {
                        set.Add(timeLine);
                    }
                }

                gvTimeLine.DataSource = set;
                gvTimeLine.Columns[0].HeaderText = "Yr";
                gvTimeLine.Columns[1].HeaderText = "Mth";
                gvTimeLine.Columns[2].HeaderText = "Date";
                gvTimeLine.Columns[3].HeaderText = "Hr";
                gvTimeLine.Columns[4].HeaderText = "Min";
                gvTimeLine.Columns[5].HeaderText = "B Party";
                gvTimeLine.Columns[6].HeaderText = "Call Type";
                gvTimeLine.Columns[7].HeaderText = "Duration";
                gvTimeLine.Columns[8].HeaderText = "Location";
                gvTimeLine.Columns[9].HeaderText = "Cell";
                gvTimeLine.Columns[10].HeaderText = "IMEI";
                gvTimeLine.Columns[11].HeaderText = "LAT";
                gvTimeLine.Columns[12].HeaderText = "LNG";
                gvTimeLine.Columns[13].HeaderText = "A Party";
                gvTimeLine.Columns[14].HeaderText = "Date & Time";
                gvTimeLine.Columns[15].HeaderText = "LAC";
                gvTimeLine.Columns[16].HeaderText = "B Pty Type";
                gvTimeLine.Columns[17].HeaderText = "B Pty Country";
                gvTimeLine.Columns[18].HeaderText = "Dur";

            }
        }

        /*
         * Domestic, International, other
         * Domestic, Afghanistan, India, KSA, Qatar, Oman, UAE
        */
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
    }
}
