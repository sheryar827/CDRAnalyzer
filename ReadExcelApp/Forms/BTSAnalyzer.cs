using ExcelDataReader;
using LumenWorks.Framework.IO.Csv;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class BTSAnalyzer : Form
    {
        public DataTable dt = null;
        DataTableCollection tableCollection;
        List<DateTime> dateTime;
        string startTime = null, endTime = null;
        List<BtsStandCDR> standCDR = null, labStandCDR = null, labAllRecord = null;
        HashSet<String> seemsResident
            , presentBeforeIncident
            , presentAfterIncident
            , presentDuringIncident
            , nibAfterIncident
            , nibbeforeIncident
            , nibduringIncident;
        int totalEnteriesUI = 0;




        public BTSAnalyzer()
        {
            InitializeComponent();
        }

        private void btnBrowseBtsFile_Click(object sender, System.EventArgs e)
        {
            try
            {

                using (FileDialog openFileDialog = new OpenFileDialog() { Filter = "All Worksheets|*.xls;*.xlsx;*.csv;|Ms 97-2003|*.xls;|Ms Office 2007|*.xlsx;|CSV file|*.csv;|All Files|*.*" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //txtFileName.Text = openFileDialog.FileName;
                        string extension = Path.GetExtension(openFileDialog.FileName);
                        if (extension == ".csv")
                        {

                            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(openFileDialog.FileName)), true))
                            {
                                dt = new DataTable();
                                dt.Load(csvReader);
                                standCDRs();
                            }
                        }
                        else
                        {
                            try
                            {
                                using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                                {
                                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                    {
                                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                        {
                                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                        });

                                        tableCollection = result.Tables;

                                        /*Getting first sheet from the excel file no need to select
                                         sheet from the combobox*/
                                        dt = tableCollection[0];
                                        standCDRs();
                                        /*cboSheet.Items.Clear();
                                        foreach (DataTable table in tableCollection)
                                            cboSheet.Items.Add(table.TableName);*/ //add sheet to combobox
                                    }
                                }

                            }
                            catch (IOException excep)
                            {

                                CommonMethods.messageDialog(excep.Message);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void standCDRs()
        {

            /*try
            {
                SqlConnection sqlcon = new SqlConnection(Common.connectionString);

                using (SqlBulkCopy objBulk = new SqlBulkCopy(sqlcon))
                {
                    // number of rows copy of table in one go
                    objBulk.BatchSize = 5000;
                    objBulk.DestinationTableName = Common.BTSTABLE;
                    objBulk.BulkCopyTimeout = 120;
                    objBulk.ColumnMappings.Add("A_Num","A_Num");
                    objBulk.ColumnMappings.Add("B_Num","B_Num");
                    objBulk.ColumnMappings.Add("IMEI", "IMEI");
                    objBulk.ColumnMappings.Add("Date", "Date");
                    objBulk.ColumnMappings.Add("Time","Time");
                    objBulk.ColumnMappings.Add("Call_Dur","Call_Dur");
                    objBulk.ColumnMappings.Add("Call_Dir","Call_Dir");
                    objBulk.ColumnMappings.Add("Call_Type","Call_Type");
                    objBulk.ColumnMappings.Add("Lac_No","Lac_No");
                    objBulk.ColumnMappings.Add("Cell_ID","Cell_ID");
                    objBulk.ColumnMappings.Add("Network","Network");
                    
                    sqlcon.Open();
                    try
                    {
                        objBulk.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        CommonMethods.messageDialog(ex.Message);
                    }
                    finally
                    {
                        sqlcon.Close();
                        CommonMethods.messageDialog("Finish!!!");
                    }
                }



            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }*/

            //getting start date from datatable
            /*string sd = dt.Rows[0]["Date"].ToString();
            string st = dt.Rows[0]["time"].ToString();

            //getting end date from datatable
            string ed = dt.Rows[dt.Rows.Count - 1]["Date"].ToString();
            string et = dt.Rows[dt.Rows.Count - 1]["time"].ToString();

            //skipping 
            string endDate = ed.Substring(0, ed.IndexOf(" "));
            string startDate = sd.Substring(0, sd.IndexOf(" "));

            dtpDateFrom.Value = Convert.ToDateTime(startDate);
            dtpDateTo.Value = Convert.ToDateTime(endDate);
            dtpTimeFrom.Value = Convert.ToDateTime(st);
            dtpTimeTo.Value = Convert.ToDateTime(et);
            DataTable tdt = dt.DefaultView.ToTable(false, dt.Columns["time"].ColumnName);
            DataTable ddt = dt.DefaultView.ToTable(false, dt.Columns["Date"].ColumnName);

            
            var tl = tdt.AsEnumerable().ToList();
            var dl = ddt.AsEnumerable().ToList();
            var conl = dl.Concat(tl).ToList();
            //Console.WriteLine(conl[0]);
            var dtdt = new DataTable();
            dtdt.Columns.Add("item");
            conl.ForEach((item) => dtdt.Rows.Add(item));*/


            /*dt.Columns["time"].DataType.ToString();*/
            /*DataColumn dc = new DataColumn("test");
            dc.DataType = typeof(string);
            dc.DefaultValue = dt.Columns["Date"].DefaultValue + " " + dt.Columns["time"].DefaultValue;

            dt.Columns.Remove("time");
            dt.Columns.Add(dc);
*/

            //getting start date from datatable
            string sd = dt.Rows[0]["Date"].ToString();
            string st = dt.Rows[0]["time"].ToString();

            //getting end date from datatable
            string ed = dt.Rows[dt.Rows.Count - 1]["Date"].ToString();
            string et = dt.Rows[dt.Rows.Count - 1]["time"].ToString();

            //skipping 
            string endDate = ed.Substring(0, ed.IndexOf(" "));
            string startDate = sd.Substring(0, sd.IndexOf(" "));

            dtpDateFrom.Value = Convert.ToDateTime(startDate);
            dtpDateTo.Value = Convert.ToDateTime(endDate);
            dtpTimeFrom.Value = Convert.ToDateTime(st);
            dtpTimeTo.Value = Convert.ToDateTime(et);

            totalEnteriesUI = dt.Rows.Count;
            CommonMethods.messageDialog(totalEnteriesUI + " Records Imported Successfully!!");

            standCDR = new List<BtsStandCDR>();
            dateTime = new List<DateTime>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BtsStandCDR btsStandCDR = new BtsStandCDR();
                btsStandCDR.A_Num = $"92{dt.Rows[i][Common.A_Num]}";
                btsStandCDR.B_Num = dt.Rows[i][Common.B_Num].ToString().TrimStart(new Char[] { '0' });

                /*Adding 92 to contact number whose length is 10*/
                btsStandCDR.B_Num = $"92{btsStandCDR.B_Num}";

                btsStandCDR.IMEI = dt.Rows[i][Common.imei].ToString();

                /*string dtime = dt.Rows[i][Common.datetime].ToString();

                DateTime dtValue = (DateTime)dt.Rows[i][Common.datetime];
                dateTime.Add(dtValue);*/


                /*Separating date from dtValue and adding it to Date*/
                btsStandCDR.Date = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[i][Common.Date]).ToString(Common.datef));

                btsStandCDR.Time = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[i][Common.Time]).ToString(Common.timef)).TimeOfDay;

                btsStandCDR.Call_Dur = dt.Rows[i][Common.Call_Dur].ToString();

                btsStandCDR.Call_Dir = dt.Rows[i][Common.Call_Dir].ToString().ToUpper();

                btsStandCDR.Call_Type = dt.Rows[i][Common.call_Type].ToString().ToUpper();

                btsStandCDR.Lac_No = dt.Rows[i][Common.LAC].ToString();

                btsStandCDR.Cell_ID = dt.Rows[i][Common.CELLID].ToString();

                btsStandCDR.Network = dt.Rows[i][Common.Network].ToString();

                standCDR.Add(btsStandCDR);

            }



            /*dt = new DataTable();
            //Adding the Columns.
            foreach (DataGridViewColumn column in gvBTSAnalyzer.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            standCDR.ForEach((item) => dt.Rows.Add(item));*/

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            startTime = dtpTimeFrom.Value.ToString("HH:mm:ss tt").Substring(0, 8);
            endTime = dtpTimeTo.Value.ToString("HH:mm:ss tt").Substring(0, 8);
            if (!(Convert.ToDateTime(startTime).TimeOfDay < Convert.ToDateTime(endTime).TimeOfDay))
            {
                CommonMethods.messageDialog("Please Select Correct Date Time!!!");
            }
            btsSelectedSummary();
        }

        private void btsSelectedSummary()
        {
            //string Qry = "select * from CDRTable WHERE Call_Type = 'Voice'";

            // Sql Query to get every row from CDRTable

            // Converting time to 24H format and removing PM, AM from it e.g 16:00:00 AM getting only first 8 char like 16:00:00
            startTime = dtpTimeFrom.Value.ToString("HH:mm:ss tt").Substring(0, 8);
            endTime = dtpTimeTo.Value.ToString("HH:mm:ss tt").Substring(0, 8);
            DateTime startDate = Convert.ToDateTime(dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            DateTime endDate = Convert.ToDateTime(dtpDateTo.Value.ToString("yyy/MM/dd"));

            //Console.WriteLine(startTime);
            //Console.WriteLine(dt.Rows[0]["Date"].ToString());

            DateTime startDateTime = Convert.ToDateTime(dtpDateFrom.Value.ToString("yyyy/MM/dd") + " " + startTime);
            DateTime endDateTime = Convert.ToDateTime(dtpDateTo.Value.ToString("yyyy/MM/dd") + " " + endTime);

            /*dt.Select(dt.Columns["Date"].ToString());*/
            /*int count = dt.Select("Date >= '" + startDate + "' and Date <= '"+endDate+"' and Time >= '" + startTime + "' and Time <= '"+ endTime +"'").Count();*/
            List<BtsStandCDR> selectedCDR = standCDR.Where(t => t.Date >= startDate && t.Date <= endDate && t.Time >= Convert.ToDateTime(startTime).TimeOfDay
            && t.Time <= Convert.ToDateTime(endTime).TimeOfDay).ToList();


            // get unique list
            var uniqueList = standCDR
                .AsEnumerable()
                .Select(x => x.B_Num).Distinct().ToList();

            // B-Party present in A-Party
            var bnumInBts = standCDR
                .AsEnumerable()
                .Select(x => x.A_Num)
                .Intersect(uniqueList).Distinct().ToHashSet();

            foreach (var scdr in selectedCDR)
            {
                if (bnumInBts.Contains(scdr.B_Num))
                {
                    scdr.bpStatusLable = "In BTS";
                }
                /*else
                {
                    scdr.bpStatusLable = "Not In BTS";
                }*/
            }

            //lookup selected cdr
            var selectedLookUp = selectedCDR.ToLookup(i => i.A_Num, ctd => new
            {
                ctd.statusLabel,
                ctd.B_Num,
                ctd.bpStatusLable,
                ctd.IMEI,
                ctd.Date,
                ctd.Time,
                ctd.Call_Dur,
                ctd.Call_Dir,
                ctd.Call_Type,
                ctd.Lac_No,
                ctd.Cell_ID,
                ctd.Network
            });

            List<BtsStandCDR> preSelectedCDR = standCDR.Where(t => t.Date <= startDate && t.Time < Convert.ToDateTime(startTime).TimeOfDay).ToList();

            //lookup pre selected cdr
            var preSelectedLookUp = preSelectedCDR.ToLookup(i => i.A_Num, j => new { j.Call_Type, j.Call_Dir });

            List<BtsStandCDR> postSelectedCDR = standCDR.Where(t => t.Date >= endDate && t.Time > Convert.ToDateTime(endTime).TimeOfDay).ToList();

            //lookup post selected cdr
            var postSelectedLookUp = postSelectedCDR.ToLookup(i => i.A_Num, j => new { j.Call_Type, j.Call_Dir });

            // during incident unique A-Party list
            var selectedUniqueAList = selectedCDR
                .AsEnumerable()
                .Select(x => x.A_Num).Distinct().ToHashSet();

            // unique A-Party list before incident
            var preUniqueAList = preSelectedCDR
                .AsEnumerable()
                .Select(x => x.A_Num).Distinct().ToHashSet();

            // unique A-Party list after incident
            var postUniqueAList = postSelectedCDR
                .AsEnumerable()
                .Select(x => x.A_Num).Distinct().ToHashSet();

            // A-Party present in BTS pre, during and after incident
            seemsResident = selectedUniqueAList.Intersect(preUniqueAList).Intersect(postUniqueAList).ToHashSet();

            // A-Party present in BTS before incident
            presentBeforeIncident = preUniqueAList.Except(selectedUniqueAList).Except(postUniqueAList).ToHashSet();


            // A-Party present in BTS after incident
            presentAfterIncident = postUniqueAList.Except(preUniqueAList).Except(selectedUniqueAList).ToHashSet();

            var standlookup = standCDR.ToLookup(anum => anum.A_Num, ctd => new
            {
                ctd.statusLabel,
                ctd.B_Num,
                ctd.bpStatusLable,
                ctd.IMEI,
                ctd.Date,
                ctd.Time,
                ctd.Call_Dur,
                ctd.Call_Dir,
                ctd.Call_Type,
                ctd.Lac_No,
                ctd.Cell_ID,
                ctd.Network
            });

            // A-Party present during incident but not before and after incident
            presentDuringIncident = selectedUniqueAList.Except(preUniqueAList).Except(postUniqueAList).ToHashSet();

            // combing pre incident and during incident
            //var aPartyPreDuring = preUniqueAList.Concat(selectedUniqueAList);

            // A-Party not in bts after incident
            nibAfterIncident = preUniqueAList.Intersect(selectedUniqueAList).Except(postUniqueAList).ToHashSet();

            // combing post incident and during incident
            //var aPartyDuringPost = postUniqueAList.Concat(selectedUniqueAList);

            // A-Party not in bts before incident
            nibbeforeIncident = selectedUniqueAList.Intersect(postUniqueAList).Except(preUniqueAList).ToHashSet();

            // combing post incident and pre incident
            //var aPartyPrePost = postUniqueAList.Concat(preUniqueAList);

            // A-Party not in bts during incident
            nibduringIncident = preUniqueAList.Intersect(postUniqueAList).Except(selectedUniqueAList).ToHashSet();


            Console.WriteLine("{0}"
                , seemsResident.Count()
                + presentDuringIncident.Count()
                + presentBeforeIncident.Count()
                + presentAfterIncident.Count()
                + nibAfterIncident.Count()
                + nibbeforeIncident.Count()
                + nibduringIncident.Count());

            //labelizeAllRecords();

            labStandCDR = new List<BtsStandCDR>();
            List<BTSSummary> btssum = new List<BTSSummary>();
            int inCmCalls = 0; // in calls count
            int outGngCalls = 0; // out calls count
            int inCmSms = 0; // in sms count
            int outGngSms = 0; // out sms count
            var selectedUniqueBList = selectedCDR
               .AsEnumerable()
               .Select(x => x.B_Num).Distinct().ToHashSet();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var item in selectedLookUp)
            {
                if (seemsResident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "seems resident";
                        labStandCDR.Add(bsc);
                    }
                }
                else if (presentDuringIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "present at incident";
                        labStandCDR.Add(bsc);
                    }
                }
                else if (nibAfterIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "not after incident";
                        labStandCDR.Add(bsc);
                    }
                }
                else if (presentBeforeIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "present before incident";
                        labStandCDR.Add(bsc);
                    }
                }
                else if (presentAfterIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "present after incident";
                        labStandCDR.Add(bsc);
                    }
                }
                else if (nibbeforeIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {

                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "not before incident";
                        labStandCDR.Add(bsc);
                    }
                }
                else if (nibduringIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "not during incident";
                        labStandCDR.Add(bsc);
                    }
                }
            }

            var lscLookup = labStandCDR.ToLookup(i => new { i.A_Num, i.B_Num }, ctd => new
            {
                ctd.statusLabel,
                ctd.bpStatusLable,
                ctd.Call_Dir,
                ctd.Call_Type
            });

            foreach (var item in lscLookup)
            {
                if (selectedUniqueBList.Contains(item.Key.B_Num))
                {
                    inCmCalls = item.Where(x => x.Call_Type.Equals("GSM")
                        && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngCalls = item.Where(x => x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    inCmSms = item.Where(x => x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngSms = item.Where(x => x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    int total = inCmCalls + inCmSms + outGngCalls + outGngSms;
                    if (total == 0 || total == 1)
                    {
                        BTSSummary cs = new BTSSummary(item.Key.A_Num, item.Select(x => x.statusLabel).First() + " " + "Unique", item.Key.B_Num, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }
                    else
                    {
                        BTSSummary cs = new BTSSummary(item.Key.A_Num, item.Select(x => x.statusLabel).First(), item.Key.B_Num, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }
                }
            }


            Console.WriteLine($"Total time:{TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).Seconds}");

            Console.WriteLine(labStandCDR.Count());
            List<BTSSummary> csByTotalInOut = btssum.OrderByDescending(cs => cs.Total).ToList();
            var csByTotalInOutLookup = csByTotalInOut.ToLookup(i => i.AParty, j => new { j.BParty, j.In, j.Out, j.inSMS, j.outSMS, j.Total, j.AStatus });

            foreach (var lsc in labStandCDR)
            {
                foreach (var item in csByTotalInOutLookup)
                {
                    if (lsc.A_Num.Equals(item.Key))
                    {
                        foreach (var i in item)
                        {
                            if (i.BParty.Equals(lsc.B_Num))
                            {
                                lsc.statusLabel = i.AStatus;
                                lsc.In = i.In;
                                lsc.Out = i.Out;
                                lsc.inSMS = i.inSMS;
                                lsc.outSMS = i.outSMS;
                                lsc.Total = i.Total;
                            }
                        }
                    }
                }
            }

            var orderLabStandCDR = labStandCDR.OrderByDescending(i => i.Total).ToList();

            /*ListtoDataTable lsttodt = new ListtoDataTable();
            DataTable dt = lsttodt.ToDataTable(orderLabStandCDR);*/

            gvBTSData.DataSource = new ListtoDataTable().ToDataTable(orderLabStandCDR);

            BTSIncidentDetails btsIncidentDetails = new BTSIncidentDetails();

            /*btsIncidentDetails.selectedTimeInterval = startDateTime + " " + endDateTime;
            btsIncidentDetails.totalEnteriesUnderInvestigation = totalEnteriesUI.ToString();
            btsIncidentDetails.totalAPartiesFound = labAllRecord.Select(i => i.A_Num).Distinct().Count().ToString();
            btsIncidentDetails.totalSeemsResidentFound = seemsResident.Count().ToString();
            btsIncidentDetails.totalSeemsResidentCrimeScene = labStandCDR.Select(i => i.A_Num).Intersect(seemsResident).Distinct().Count().ToString();
            btsIncidentDetails.totalUniqueDuringCrimeScene = labStandCDR.Where(i => i.Total <= 1).Select(i => i.A_Num).Distinct().Count().ToString();
            btsIncidentDetails.totalNumberLeftAfterCrimeScene = nibAfterIncident.Count().ToString();
            btsIncidentDetails.totalNumberAppearedAfterCrimeScene = presentAfterIncident.Count().ToString();
            Console.WriteLine("{0}   {1}   {2}   {3}    {4}     {5}     {6}", btsIncidentDetails.selectedTimeInterval
                , btsIncidentDetails.totalEnteriesUnderInvestigation
                , btsIncidentDetails.totalAPartiesFound
                , btsIncidentDetails.totalSeemsResidentFound
                , btsIncidentDetails.totalSeemsResidentCrimeScene
                , btsIncidentDetails.totalUniqueDuringCrimeScene
                , btsIncidentDetails.totalNumberLeftAfterCrimeScene);

            new Forms.BtsIncidentForm(btsIncidentDetails).ShowDialog();*/

            /*List<BTSSummary> btssum = new List<BTSSummary>();
            int inCmCalls = 0; // in calls count
            int outGngCalls = 0; // out calls count
            int inCmSms = 0; // in sms count
            int outGngSms = 0; // out sms count
            var selectedUniqueBList = labStandCDR
               .AsEnumerable()
               .Select(x => x.B_Num).Where(i => i.Length >= 12).Distinct().ToHashSet();
            foreach (var bnum in selectedUniqueBList)
            {

                foreach (var item in selectedLookUp)
                {

                    inCmCalls = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngCalls = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    inCmSms = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngSms = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    int total = inCmCalls + inCmSms + outGngCalls + outGngSms;
                    if (total == 0 || total == 1)
                    {
                        BTSSummary cs = new BTSSummary(item.Key, item.Select(x => x.statusLabel).First() + " " + "Unique", bnum, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }
                    else
                    {
                        BTSSummary cs = new BTSSummary(item.Key, item.Select(x => x.statusLabel).First(), bnum, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }

                }
            }


            List<BTSSummary> csByTotalInOut = btssum.OrderByDescending(cs => cs.Total).ToList();
            gvBTSAnalyzer.DataSource = csByTotalInOut;*/

            /*var labstandlookup = labStandCDR.ToLookup(anum => anum.A_Num, ctd => new
            {
                ctd.statusLabel,
                ctd.B_Num,
                ctd.bpStatusLable,
                ctd.IMEI,
                ctd.Date,
                ctd.Time,
                ctd.Call_Dur,
                ctd.Call_Dir,
                ctd.Call_Type,
                ctd.Lac_No,
                ctd.Cell_ID,
                ctd.Network
            });

            var selectedBListInBTS = standCDR
               .AsEnumerable()
               .Select(x => x.A_Num).Distinct().ToList();

            Console.WriteLine(selectedBListInBTS);



            labbStandCDR = new List<BtsStandCDR>();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();


            foreach (var item in labstandlookup)
            {

                foreach (var i in item)
                {
                    BtsStandCDR bsc = new BtsStandCDR();
                    bsc.A_Num = item.Key;
                    bsc.B_Num = i.B_Num;
                    bsc.IMEI = i.IMEI;
                    bsc.Date = i.Date;
                    bsc.Time = i.Time;
                    bsc.Call_Dur = i.Call_Dur;
                    bsc.Call_Dir = i.Call_Dir;
                    bsc.Call_Type = i.Call_Type;
                    bsc.Lac_No = i.Lac_No;
                    bsc.Cell_ID = i.Cell_ID;
                    bsc.Network = i.Network;
                    bsc.statusLabel = i.statusLabel;
                    if (selectedBListInBTS.Contains(i.B_Num))
                    {
                        bsc.bpStatusLable = "in bts";
                    }
                    labbStandCDR.Add(bsc);
                }

            }


            Console.WriteLine($"Total time:{TimeSpan.FromMilliseconds(stopwatch1.ElapsedMilliseconds).Seconds}");
            Console.WriteLine(labbStandCDR.Count());

            var selectedUniqueBList = labbStandCDR
               .AsEnumerable()
               .Select(x => x.B_Num).Where(i=>i.Length >= 12 ).Distinct().ToList();

            *//*List<BtsStandCDR> selectBtsCDR = labbStandCDR.Where(t => t.Date >= startDate && t.Date <= endDate && t.Time >= Convert.ToDateTime(startTime).TimeOfDay
            && t.Time <= Convert.ToDateTime(endTime).TimeOfDay).ToList();

            gvBTSAnalyzer.DataSource = selectBtsCDR;*//*


            var lookup = labbStandCDR.ToLookup(r => r.A_Num, r => new { r.B_Num, r.Call_Type, r.Call_Dir, r.statusLabel, r.bpStatusLable });

            List<BTSSummary> btssum = new List<BTSSummary>();
            int inCmCalls = 0; // in calls count
            int outGngCalls = 0; // out calls count
            int inCmSms = 0; // in sms count
            int outGngSms = 0; // out sms count
            foreach (var bnum in selectedUniqueBList)
            {
                
                foreach (var item in lookup)
                {

                    inCmCalls = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngCalls = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    inCmSms = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngSms = item.Where(x => x.B_Num.Equals(bnum) && x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    int total = inCmCalls + inCmSms + outGngCalls + outGngSms;
                    if (total == 0 || total == 1)
                    {
                        BTSSummary cs = new BTSSummary(item.Key, item.Select(x => x.statusLabel).First() + " " + "Unique", bnum, item.Select(x=>x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }
                    else
                    {
                        BTSSummary cs = new BTSSummary(item.Key, item.Select(x => x.statusLabel).First(), bnum, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }

                }
            }


            List<BTSSummary> csByTotalInOut = btssum.OrderByDescending(cs => cs.Total).ToList();
            gvBTSAnalyzer.DataSource = csByTotalInOut;*/


            // A-Party present during incident but not before and after incident
            /*var uniqDurIncident = selectedUniqueAList.Except(preUniqueAList).Except(postUniqueAList);
            foreach (var idi in uniqDurIncident)
                Console.WriteLine(idi);

            Console.WriteLine(uniqDurIncident.Count());

            // combing pre incident and during incident
            var aPartyPreDuring = preUniqueAList.Concat(selectedUniqueAList);

            // A-Party not in bts after incident
            var uniq = aPartyPreDuring.Except(postUniqueAList);

            //foreach (var un in uniq)
            //Console.WriteLine(un.ToString());

            Console.WriteLine("{0}  {1}     {2}", selectedUniqueAList.Count()+preUniqueAList.Count(),uniq.Count(), seemsResident.Count());

            clearGridView();

            gvBTSAnalyzer.DataSource = postSelectedCDR;

            // get unique list
            //List<string> uniqueList = selectedCDR.AsEnumerable().Select(x => x.B_Num.ToString()).Distinct().ToList();

            // B-Party present in A-Party
            //var bnumInBts = selectedCDR.AsEnumerable().Select(x => x.A_Num.ToString()).Intersect(uniqueList);

            var lookup = selectedCDR.ToLookup(i => i.A_Num, j => new {j.Call_Dir, j.Call_Type});
            
            List<CDRSummary> cdrsum = new List<CDRSummary>();
            int inCmCalls = 0; // in calls count
            int outGngCalls = 0; // out calls count
            int inCmSms = 0; // in sms count
            int outGngSms = 0; // out sms count
            foreach (var item in lookup)
            {
                inCmCalls = item.Where(x => x.Call_Type.Equals("GSM")
                && x.Call_Dir.Equals("INCOMING")).Count();
                outGngCalls = item.Where(x => x.Call_Type.Equals("GSM")
                && x.Call_Dir.Equals("OUTGOING")).Count();
                inCmSms = item.Where(x => x.Call_Type.Equals("SMS")
                && x.Call_Dir.Equals("INCOMING")).Count();
                outGngSms = item.Where(x => x.Call_Type.Equals("SMS")
                && x.Call_Dir.Equals("OUTGOING")).Count();

                CDRSummary cs = new CDRSummary("", "", item.Key, inCmCalls, inCmSms, outGngCalls, outGngSms,
                        inCmCalls + inCmSms + outGngCalls + outGngSms);
                cdrsum.Add(cs);
            }

            List<CDRSummary> csByTotalInOut = cdrsum.OrderByDescending(cs => cs.Total).ToList();

            gvBTSAnalyzer.DataSource = csByTotalInOut;*/
            /*MessageBox.Show(endTime.ToString(), "info");*/


        }

        public void clearGridView()
        {
            gvBTSData.DataSource = null;
            gvBTSData.Rows.Clear();
            gvBTSData.Columns.Clear();
            gvBTSData.Refresh();
        }

        // Group communcation in BTS (Summary in which Both A-Party and B-Party in BTS)
        /*private void btnAllCDR_Click(object sender, EventArgs e)
        {

            // get unique list
            var uniqueList = standCDR
                .AsEnumerable()
                .Select(x => x.B_Num).Distinct().ToHashSet();

            // B-Party present in A-Party
            var bnumInBts = standCDR
                .AsEnumerable()
                .Select(x => x.A_Num)
                .Intersect(uniqueList).Distinct().ToHashSet();

            var lookup = standCDR.ToLookup(r => r.A_Num, r => new { r.Call_Type, r.Call_Dir });

            List<CDRSummary> cdrsum = new List<CDRSummary>();
            int inCmCalls = 0; // in calls count
            int outGngCalls = 0; // out calls count
            int inCmSms = 0; // in sms count
            int outGngSms = 0; // out sms count

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var item in lookup)
            {
                if (bnumInBts.Contains(item.Key))
                {
                    inCmCalls = item.Where(x => x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("INCOMING")).Count();
                    outGngCalls = item.Where(x => x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("OUTGOING")).Count();
                    inCmSms = item.Where(x => x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("INCOMING")).Count();
                    outGngSms = item.Where(x => x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    CDRSummary cs = new CDRSummary("", "", item.Key, inCmCalls, inCmSms, outGngCalls, outGngSms,
                            inCmCalls + inCmSms + outGngCalls + outGngSms);
                    cdrsum.Add(cs);
                }
            }


            Console.WriteLine($"Total time:{TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).Seconds}");
            List<CDRSummary> csByTotalInOut = cdrsum.OrderByDescending(cs => cs.Total).ToList();

            gvBTSData.DataSource = csByTotalInOut;

        }*/


        /*private void gvBTSAnalyzer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bnum = gvBTSData.Rows[e.RowIndex].Cells[2].Value.ToString();
            string anum = gvBTSData.Rows[e.RowIndex].Cells[0].Value.ToString();
            string columnType = gvBTSData.Columns[e.ColumnIndex].HeaderText;

            switch (columnType)
            {

                case Common.callIn:
                    fetchdata("GSM", "INCOMING", anum, bnum);
                    break;
                case Common.callOut:
                    fetchdata("GSM", "OUTGOING", anum, bnum);
                    break;
                case Common.inSMS:
                    fetchdata("SMS", "INCOMING", anum, bnum);
                    break;
                case Common.outSMS:
                    fetchdata("SMS", "OUTGOING", anum, bnum);
                    break;
                case Common.Total:
                    fetchdata("Total", "", anum, bnum);
                    break;
                default:
                    break;

            }
        }*/

        private void fetchdata(string call_type, string call_dir, string aparty, string bparty)
        {
            List<BtsStandCDR> btsDetailCDR = new List<BtsStandCDR>();
            var standlookup = labStandCDR.ToLookup(anum => new { anum.A_Num, anum.B_Num }, ctd => new
            {
                ctd.B_Num,
                ctd.IMEI,
                ctd.Date,
                ctd.Time,
                ctd.Call_Dur,
                ctd.Call_Dir,
                ctd.Call_Type,
                ctd.Lac_No,
                ctd.Cell_ID,
                ctd.Network,
                ctd.statusLabel,
                ctd.bpStatusLable
            });

            foreach (var item in standlookup)
            {
                if (item.Key.A_Num.Equals(aparty) && item.Key.B_Num.Equals(bparty))
                {
                    foreach (var i in item)
                    {
                        if (i.Call_Type.Equals(call_type) && i.Call_Dir.Equals(call_dir))
                        {
                            BtsStandCDR bsc = new BtsStandCDR();
                            bsc.A_Num = item.Key.A_Num;
                            bsc.B_Num = i.B_Num;
                            bsc.IMEI = i.IMEI;
                            bsc.Date = i.Date;
                            bsc.Time = i.Time;
                            bsc.Call_Dur = i.Call_Dur;
                            bsc.Call_Dir = i.Call_Dir;
                            bsc.Call_Type = i.Call_Type;
                            bsc.Lac_No = i.Lac_No;
                            bsc.Cell_ID = i.Cell_ID;
                            bsc.Network = i.Network;
                            bsc.statusLabel = i.statusLabel;
                            bsc.bpStatusLable = i.bpStatusLable;
                            btsDetailCDR.Add(bsc);
                        }
                    }
                }
            }


            foreach (var item in standlookup)
            {
                if (item.Key.A_Num.Equals(aparty) && item.Key.B_Num.Equals(bparty))
                {
                    if (call_type.Equals("Total"))
                    {
                        foreach (var i in item)
                        {

                            BtsStandCDR bsc = new BtsStandCDR();
                            bsc.A_Num = item.Key.A_Num;
                            bsc.B_Num = i.B_Num;
                            bsc.IMEI = i.IMEI;
                            bsc.Date = i.Date;
                            bsc.Time = i.Time;
                            bsc.Call_Dur = i.Call_Dur;
                            bsc.Call_Dir = i.Call_Dir;
                            bsc.Call_Type = i.Call_Type;
                            bsc.Lac_No = i.Lac_No;
                            bsc.Cell_ID = i.Cell_ID;
                            bsc.Network = i.Network;
                            bsc.statusLabel = i.statusLabel;
                            bsc.bpStatusLable = i.bpStatusLable;
                            btsDetailCDR.Add(bsc);
                        }
                    }
                }
            }

            new Forms.BtsCDRSummaryDetailsForm(btsDetailCDR).ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvBTSData);
        }

        /*private void gvBTSData_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            btsStandCDRBindingSource.Filter = gvBTSData.FilterString;
        }*/

        private void gvBTSData_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            btsStandCDRBindingSource.Sort = gvBTSData.SortString;
        }

        /*private void labelizeAllRecords()
        {
            labAllRecord = new List<BtsStandCDR>();

            // get unique list
            var uniqueList = standCDR
                .AsEnumerable()
                .Select(x => x.B_Num).Distinct().ToList();

            // B-Party present in A-Party
            var bnumInBts = standCDR
                .AsEnumerable()
                .Select(x => x.A_Num)
                .Intersect(uniqueList).Distinct().ToHashSet();

            foreach (var scdr in standCDR)
            {
                if (bnumInBts.Contains(scdr.B_Num))
                {
                    scdr.bpStatusLable = "In BTS";
                }
                else
                {
                    scdr.bpStatusLable = "Not In BTS";
                }
            }

            var standlookup = standCDR.ToLookup(anum => anum.A_Num, ctd => new
            {
                ctd.B_Num,
                ctd.IMEI,
                ctd.Date,
                ctd.Time,
                ctd.Call_Dur,
                ctd.Call_Dir,
                ctd.Call_Type,
                ctd.Lac_No,
                ctd.Cell_ID,
                ctd.Network,
                ctd.statusLabel,
                ctd.bpStatusLable
            });

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var item in standlookup)
            {
                if (seemsResident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "seems resident";
                        labAllRecord.Add(bsc);
                    }
                }
                else if (presentDuringIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "present at incident";
                        labAllRecord.Add(bsc);
                    }
                }
                else if (nibAfterIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "not after incident";
                        labAllRecord.Add(bsc);
                    }
                }
                else if (presentBeforeIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "present before incident";
                        labAllRecord.Add(bsc);
                    }
                }
                else if (presentAfterIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "present after incident";
                        labAllRecord.Add(bsc);
                    }
                }
                else if (nibbeforeIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {

                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "not before incident";
                        labAllRecord.Add(bsc);
                    }
                }
                else if (nibduringIncident.Contains(item.Key))
                {
                    foreach (var i in item)
                    {
                        BtsStandCDR bsc = new BtsStandCDR();
                        bsc.A_Num = item.Key;
                        bsc.B_Num = i.B_Num;
                        bsc.IMEI = i.IMEI;
                        bsc.Date = i.Date;
                        bsc.Time = i.Time;
                        bsc.Call_Dur = i.Call_Dur;
                        bsc.Call_Dir = i.Call_Dir;
                        bsc.Call_Type = i.Call_Type;
                        bsc.Lac_No = i.Lac_No;
                        bsc.Cell_ID = i.Cell_ID;
                        bsc.Network = i.Network;
                        bsc.bpStatusLable = i.bpStatusLable;
                        bsc.statusLabel = "not during incident";
                        labAllRecord.Add(bsc);
                    }
                }
            }

            Console.WriteLine($"Total time:{TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).Seconds}");

            labStandCDR = new List<BtsStandCDR>();
            List<BTSSummary> btssum = new List<BTSSummary>();
            int inCmCalls = 0; // in calls count
            int outGngCalls = 0; // out calls count
            int inCmSms = 0; // in sms count
            int outGngSms = 0; // out sms count

            var lscLookup = labAllRecord.ToLookup(i => new { i.A_Num, i.B_Num }, ctd => new
            {
                ctd.statusLabel,
                ctd.bpStatusLable,
                ctd.Call_Dir,
                ctd.Call_Type
            });

            foreach (var item in lscLookup)
            {
                if (uniqueList.Contains(item.Key.B_Num))
                {
                    inCmCalls = item.Where(x => x.Call_Type.Equals("GSM")
                        && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngCalls = item.Where(x => x.Call_Type.Equals("GSM")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    inCmSms = item.Where(x => x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("INCOMING")).Count();

                    outGngSms = item.Where(x => x.Call_Type.Equals("SMS")
                    && x.Call_Dir.Equals("OUTGOING")).Count();

                    int total = inCmCalls + inCmSms + outGngCalls + outGngSms;
                    if (total == 0 || total == 1)
                    {
                        BTSSummary cs = new BTSSummary(item.Key.A_Num, item.Select(x => x.statusLabel).First() + " " + "Unique", item.Key.B_Num, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }
                    else
                    {
                        BTSSummary cs = new BTSSummary(item.Key.A_Num, item.Select(x => x.statusLabel).First(), item.Key.B_Num, item.Select(x => x.bpStatusLable).First(), inCmCalls, inCmSms, outGngCalls, outGngSms,
                                total);
                        btssum.Add(cs);
                    }
                }
            }


            Console.WriteLine($"Total time:{TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).Seconds}");

            Console.WriteLine(labAllRecord.Count());
            List<BTSSummary> csByTotalInOut = btssum.OrderByDescending(cs => cs.Total).ToList();
            var csByTotalInOutLookup = csByTotalInOut.ToLookup(i => i.AParty, j => new { j.BParty, j.In, j.Out, j.inSMS, j.outSMS, j.Total, j.AStatus });

            foreach (var lsc in labStandCDR)
            {
                foreach (var item in csByTotalInOutLookup)
                {
                    if (lsc.A_Num.Equals(item.Key))
                    {
                        foreach (var i in item)
                        {
                            if (i.BParty.Equals(lsc.B_Num))
                            {
                                lsc.statusLabel = i.AStatus;
                                lsc.In = i.In;
                                lsc.Out = i.Out;
                                lsc.inSMS = i.inSMS;
                                lsc.outSMS = i.outSMS;
                                lsc.Total = i.Total;
                            }
                        }
                    }
                }
            }

            var orderLabStandCDR = labStandCDR.OrderByDescending(i => i.Total).ToList();

            ListtoDataTable lsttodt = new ListtoDataTable();
            DataTable dt = lsttodt.ToDataTable(orderLabStandCDR);

            gvBTSData.DataSource = dt;
        }*/


    }


}
