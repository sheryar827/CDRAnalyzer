using ReadExcelApp.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class NewNumbersForm : Form
    {
        List<YearMonthNewBNum> yearMonthNewBNums;
        string b_party_type;
        string b_party_country;
        DataTable dt = null;
        CDRSummary cs = null;
        public NewNumbersForm()
        {
            InitializeComponent();
        }

        private async void NewNumbersForm_Load(object sender, EventArgs e)
        {
            newNumFunc();
            
            string sd = Common.allRecordA_Nums.First().Date.ToString();
            string st = Common.allRecordA_Nums.First().Time.ToString();

            //getting end date from datatable
            string ed = Common.allRecordA_Nums.Last().Date.ToString();
            string et = Common.allRecordA_Nums.Last().Time.ToString();

            dtpDateFrom.Value = Convert.ToDateTime(sd);
            dtpDateTo.Value = Convert.ToDateTime(ed);
            dtpTimeFrom.Value = Convert.ToDateTime(st);
            dtpTimeTo.Value = Convert.ToDateTime(et);
            
        }

        private void newNumFunc()
        {
            IDictionary<YearMonths, string> ymBNum = new Dictionary<YearMonths, string>();
            IDictionary<YearMonths, List<string>> kymBNum = new Dictionary<YearMonths, List<string>>();
            List<YearMonths> yearMonthsList = new List<YearMonths>();

            if (Common.allRecordA_Nums.Count > 0)
            {
                foreach (AllRecordA_Num allRecordA_Num in Common.allRecordA_Nums)
                {
                    int yr = Convert.ToDateTime(allRecordA_Num.Date).Year;
                    int mth = Convert.ToDateTime(allRecordA_Num.Date).Month;
                    int day = Convert.ToDateTime(allRecordA_Num.Date).Day;
                    string b_party = allRecordA_Num.B_Num;
                    checkNumType(allRecordA_Num.B_Num);
                    string dur = allRecordA_Num.Call_Dur;
                    yearMonthsList.Add(new YearMonths(yr, mth));
                    ymBNum.Add(new YearMonths(yr, mth), b_party);
                }

                

                List<YearMonths> uniqueYearMonthList = RemoveDuplicateValues(yearMonthsList);

                yearMonthNewBNums = new List<YearMonthNewBNum>();

                List<YearMonthNewBNum> set = new List<YearMonthNewBNum>();

                var lookup = Common.allRecordA_Nums.ToLookup(i => i.B_Num, j => new { j.Call_Dir, j.Call_Type });

                foreach (YearMonths item in uniqueYearMonthList)
                {
                    
                    List<string> bnumToCheck = new List<string>();
                    List<string> bnumInCheck = new List<string>();
                    
                    for (int i = 0; i < ymBNum.Count(); i++)
                    {
                        if (ymBNum.ElementAt(i).Key.year.Equals(item.year)
                            && ymBNum.ElementAt(i).Key.month.Equals(item.month))
                        {
                            bnumToCheck.Add(ymBNum.ElementAt(i).Value);
                        }
                        else
                        {
                            bnumInCheck.Add(ymBNum.ElementAt(i).Value);
                        }
                    }

                    foreach (var bnumDiff in bnumToCheck.Except(bnumInCheck).Distinct().ToList())
                    {
                        checkNumType(bnumDiff);

                        int inCmCalls = 0;
                        int outGngCalls = 0;
                        int inCmSms = 0;
                        int outGngSms = 0;
                        foreach (var itm in lookup)
                        {

                            if (itm.Key.Equals(bnumDiff))
                            {
                                inCmCalls = itm.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.voice)).Count();

                                outGngCalls = itm.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.voice)).Count();


                                inCmSms = itm.Where(x => x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.sms)).Count();

                                outGngSms = itm.Where(x => x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.sms)).Count();
                            }
                        }

                        yearMonthNewBNums.Add(new YearMonthNewBNum(item.year.ToString()
                           , new DateTime(item.year, item.month, 1).ToString("MMM")
                           , bnumToCheck.Except(bnumInCheck).Distinct().ToList().Count.ToString()
                           , ""
                           , ""
                           , bnumDiff
                           , inCmCalls
                           , outGngCalls
                           , inCmSms
                           , outGngSms
                           , inCmCalls + outGngCalls + inCmSms + outGngSms, "", b_party_type, b_party_country));

                    }
                        
                    
                    //Console.WriteLine("Year: {0}    Month: {1}  Diff: {2}", item.year, item.month, bnumToCheck.Except(bnumInCheck).Count());
                }

                foreach (YearMonthNewBNum yearMonthNewBNum in yearMonthNewBNums)
                {
                    if (set.FindIndex(y => y.year == yearMonthNewBNum.year &&
                     y.month == yearMonthNewBNum.month && y.count == yearMonthNewBNum.count) != -1)
                    {
                        yearMonthNewBNum.year = "";
                        yearMonthNewBNum.month = "";
                        yearMonthNewBNum.count = "";

                        set.Add(yearMonthNewBNum);
                    }
                    else
                    {
                        set.Add(yearMonthNewBNum);

                    }
                }
                CDRSummaryGridView.DataSource = yearMonthNewBNums;
                setGridViewHeaders();
            }
        }

        private void setGridViewHeaders()
        {
            CDRSummaryGridView.Columns[0].HeaderText = "Year";
            CDRSummaryGridView.Columns[1].HeaderText = "Month";
            CDRSummaryGridView.Columns[2].HeaderText = "Count";
            CDRSummaryGridView.Columns[3].HeaderText = "Name";
            CDRSummaryGridView.Columns[4].HeaderText = "CNIC";
            CDRSummaryGridView.Columns[5].HeaderText = "B_Party";
            CDRSummaryGridView.Columns[6].HeaderText = "In";
            CDRSummaryGridView.Columns[7].HeaderText = "Out";
            CDRSummaryGridView.Columns[8].HeaderText = "inSMS";
            CDRSummaryGridView.Columns[9].HeaderText = "outSMS";
            CDRSummaryGridView.Columns[10].HeaderText = "Total";
            CDRSummaryGridView.Columns[11].HeaderText = "Address";
            CDRSummaryGridView.Columns[12].HeaderText = "Type";
            CDRSummaryGridView.Columns[13].HeaderText = "Country";
        }

        private List<YearMonths> RemoveDuplicateValues(List<YearMonths> list)
        {
            /*Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (var item in list)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.*/
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (Common.allRecordA_Nums.Count() > 0)
            {
                //List<string> uniqueList = Common.allRecordA_Nums.AsEnumerable().Select(x => x.B_Num.ToString()).Distinct().ToList();

                // Sql Query to get every row from CDRTable
                DateTime startDate = Convert.ToDateTime(dtpDateFrom.Value.ToString("yyyy/MM/dd"));
                DateTime endDate = Convert.ToDateTime(dtpDateTo.Value.ToString("yyyy/MM/dd"));
                // Converting time to 24H format and removing PM, AM from it e.g 16:00:00 AM getting only first 8 char like 16:00:00
                TimeSpan startTime = Convert.ToDateTime(dtpTimeFrom.Value.ToString("HH:mm:ss tt").Substring(0, 8)).TimeOfDay;
                TimeSpan endTime = Convert.ToDateTime(dtpTimeTo.Value.ToString("HH:mm:ss tt").Substring(0, 8)).TimeOfDay;

                /*string spCDRDateTime = "exec dbo.CDR_A_Num_Date_Time '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "' , '" + startDate + "', '" + endDate + "', '" + startTime + "', '" + endTime + "'";
                DataTable dtCDRDateTime = await CommonMethods.getRecords(spCDRDateTime);*/

                List<AllRecordA_Num> selectedRecordsA_Num = new List<AllRecordA_Num>();
                List<AllRecordA_Num> completeListA_Num = new List<AllRecordA_Num>();

                // Assign Common.allRecordA_Nums list to completeListA_Num List
                completeListA_Num = Common.allRecordA_Nums.ToList();

                selectedRecordsA_Num = completeListA_Num.Where(t => Convert.ToDateTime(t.Date) >= startDate && Convert.ToDateTime(t.Date) <= endDate
                && Convert.ToDateTime(t.Time).TimeOfDay >= startTime && Convert.ToDateTime(t.Time).TimeOfDay <= endTime).ToList();

                try
                {
                    if (selectedRecordsA_Num.Count > 0)
                    {
                        foreach (var srA_Num in selectedRecordsA_Num)
                        {
                            completeListA_Num.Remove(srA_Num);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonMethods.messageDialog(ex.Message);
                }
                /*remainingRecordsA_Num = Common.allRecordA_Nums.Where(t => Convert.ToDateTime(t.Date) < startDate && Convert.ToDateTime(t.Date) > endDate
                && Convert.ToDateTime(t.Time).TimeOfDay < startTime && Convert.ToDateTime(t.Time).TimeOfDay > endTime).ToList();*/



                Console.WriteLine("{0}  {1}     {2}", selectedRecordsA_Num.Count, completeListA_Num.Count, Common.allRecordA_Nums.Count());
                // this removes dtCDRDateTime datatable from dt datatable which contains complete CDR
                /*foreach (DataRow rowToDelete in dtCDRDateTime.Rows)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var rowToDeleteArray = rowToDelete.ItemArray;
                        var rowArray = row.ItemArray;
                        bool equalRows = true;
                        for (int i = 0; i < rowArray.Length; i++)
                        {
                            if (!rowArray[i].Equals(rowToDeleteArray[i]))
                            {
                                equalRows = false;
                            }
                        }
                        if (equalRows)
                        {
                            dt.Rows.Remove(row);
                            break;
                        }
                    }
                }*/

                List<string> uniqueRemainingList = new List<string>();
                List<string> uniqueSelectedList = new List<string>();


                if (completeListA_Num.Count > 0)
                {
                    // this will get unique b-party from both datatable
                    uniqueRemainingList = completeListA_Num.AsEnumerable().Select(x => x.B_Num.ToString()).Distinct().ToList();
                }
                if (selectedRecordsA_Num.Count > 0)
                {
                    uniqueSelectedList = selectedRecordsA_Num.AsEnumerable().Select(x => x.B_Num.ToString()).Distinct().ToList();
                }

                //Getting only thoise bnum which are in uniqueSelectedList but not in uniqueRemainingList
                var differences = uniqueSelectedList.Where(x => uniqueRemainingList.All(x1 => x1 != x));
                int inCmCalls = 0;
                int outGngCalls = 0;
                int inCmSms = 0;
                int outGngSms = 0;
                List<CDRSummary> cdrsum = new List<CDRSummary>();
                foreach (var difference in differences)
                {
                    inCmCalls = selectedRecordsA_Num.Where(x => x.B_Num.Equals(difference)
                    && x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.voice)).Count();
                    outGngCalls = selectedRecordsA_Num.Where(x => x.B_Num.Equals(difference)
                    && x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.voice)).Count();
                    inCmSms = selectedRecordsA_Num.Where(x => x.B_Num.Equals(difference)
                    && x.Call_Dir.Equals(Common.incoming) && x.Call_Type.Equals(Common.sms)).Count();
                    outGngSms = selectedRecordsA_Num.Where(x => x.B_Num.Equals(difference)
                    && x.Call_Dir.Equals(Common.outgoing) && x.Call_Type.Equals(Common.sms)).Count();
                    cs = new CDRSummary("", "", difference, inCmCalls, inCmSms, outGngCalls, outGngSms,
                    inCmCalls + inCmSms + outGngCalls + outGngSms, "");
                    cdrsum.Add(cs);
                }

                /*Aranging the list in decending order on the basis of total in our calls and sms*/
                List<CDRSummary> csByTotalInOut = cdrsum.OrderByDescending(cs => cs.Total).ToList();
                CDRSummaryGridView.DataSource = csByTotalInOut;
            }
        }

        private List<YearMonthNewBNum> getSubDataList(List<YearMonthNewBNum> bnumList)
        {

            try
            {
                List<string> uniqueNumList = bnumList.AsEnumerable().Select(x => x.bnum.ToString()).Where(l => l.Length.Equals(12)).Distinct().ToList();
                string numParameters = AddArrayParameters(uniqueNumList.ToArray());
                DataTable allRecordsDt = new DataTable();
                try
                {

                    string getRecordQuery = string.Format("SELECT Mobile, FirstName as Name, CAST(CNIC AS NVARCHAR) AS CNIC, 'DLMS' as DB, [DLMS_FamzSolutions].[dbo].[License_Person_Address].[Block] AS ADDR, [DLMS_FamzSolutions].[dbo].[License_Person_Images].[imgObject] AS imgObject FROM [DLMS_FamzSolutions].[dbo].[License_Person] INNER JOIN [DLMS_FamzSolutions].[dbo].[License_Person_Address] ON [DLMS_FamzSolutions].[dbo].[License_Person_Address].[PersonID] = [DLMS_FamzSolutions].[dbo].[License_Person].[PersonID] INNER JOIN [DLMS_FamzSolutions].[dbo].[License_Person_Images] ON [DLMS_FamzSolutions].[dbo].[License_Person_Images].[PersonID] = [DLMS_FamzSolutions].[dbo].[License_Person].[PersonID] WHERE Mobile IN({0})" +
                                "UNION ALL " +
                                "SELECT MSISDN as Mobile, Name, CNIC, '2021' as DB, ADDRESS AS ADDR, NULL AS imgObject from Masterdb2021 where MSISDN IN ({0}) " +
                                "UNION ALL " +
                                "SELECT MSISDN as Mobile, SubscriberName as Name, CNIC, '2020' as DB, 'N/A' AS ADDR, NULL AS imgObject from Masterdb where MSISDN IN ({0})" +
                                "UNION ALL " +
                                "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[Central_Zone_Part_1] WHERE MOBILE_NO IN ({0})" +
                                "UNION ALL " +
                                "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[Central_Zone_Part_2] WHERE MOBILE_NO IN ({0})" +
                                "UNION ALL " +
                                "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[North_Zone_Overall] WHERE MOBILE_NO IN ({0})" +
                                "UNION ALL " +
                                "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[South_Zone_Overall] WHERE MOBILE_NO IN ({0})", numParameters);

                    using (SqlConnection con = new SqlConnection(AppConnection.GetSubConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(getRecordQuery, con))
                        {
                            cmd.CommandType = CommandType.Text;

                            if (con.State != ConnectionState.Open)
                                con.Open();

                            SqlDataReader sdr = cmd.ExecuteReader();

                            allRecordsDt.Load(sdr);

                            //gvLocationDetails.DataSource = allRecordsDt;

                            for (int i = 0; i < bnumList.Count(); i++)
                            {
                                DataRow firstDataRow = allRecordsDt.Select("Mobile = '" + bnumList[i].bnum + "'").Count() > 0 ? allRecordsDt.Select("Mobile = '" + bnumList[i].bnum + "'").First() : null;
                                Console.WriteLine(bnumList[i].bnum);
                                if (firstDataRow != null)
                                {
                                    bnumList[i].name = firstDataRow["Name"].ToString();
                                    bnumList[i].cnic = firstDataRow["CNIC"].ToString();
                                    bnumList[i].address = firstDataRow["ADDR"].ToString();
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                //gvLocationDetails.DataSource = bnumList;
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }

            return bnumList;
        }

        public static string AddArrayParameters(string[] array)
        {
            /* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
             * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
             * IN statement in the CommandText.
             */
            var parameters = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                parameters[i] = string.Format("'{0}'", array[i]);
            }

            return string.Join(", ", parameters);
        }

        private void CDRSummaryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bParty = CDRSummaryGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            string columnType = CDRSummaryGridView.Columns[e.ColumnIndex].HeaderText;

            getDetailedRecords(bParty, columnType, Common.allRecordA_Nums);
        }

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

        private void btnSubInfo_Click(object sender, EventArgs e)
        {
            CommonMethods.messageDialog("Please Wait...");
            try
            {
                clearGridView();
                CDRSummaryGridView.DataSource = getSubDataList(yearMonthNewBNums);
                setGridViewHeaders();

            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        public void clearGridView()
        {
            CDRSummaryGridView.DataSource = null;
            CDRSummaryGridView.Rows.Clear();
            CDRSummaryGridView.Columns.Clear();
            CDRSummaryGridView.Refresh();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(CDRSummaryGridView);
        }
    }
}
