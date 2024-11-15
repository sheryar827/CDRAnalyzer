﻿using Dapper;
using ExcelDataReader;
using LumenWorks.Framework.IO.Csv;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ReadExcelApp
{
    public partial class Form1 : Form
    {

        public int projectId = 0;
        private DataTable dataTable = null;
        public DataTable dt = null;
        public string A_Num = null;
        public string project = null;
        public List<DateTime> datetime = null;
        List<StanderizedCDR> standCDR = null;
        bool cell_clicked = false;
        DataTableCollection tableCollection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                using (FileDialog openFileDialog = new OpenFileDialog() { Filter = "All Worksheets|*.xls;*.xlsx;*.csv;|Ms 97-2003|*.xls;|Ms Office 2007|*.xlsx;|CSV file|*.csv;|All Files|*.*" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        string extension = Path.GetExtension(openFileDialog.FileName);
                        if (extension == ".csv")
                        {

                            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(openFileDialog.FileName)), true))
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
                                    }
                                }

                            }
                            catch (IOException excep)
                            {
                                Console.WriteLine("EXCEPTION: " + excep.Message);
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

        private string standerize_B_Party(string b_num)
        {
            // to check all char are digits then add 92 at end
            if (b_num.Length >= 10 && b_num.Length <= 12 && b_num.All(char.IsDigit))
            {
                b_num = b_num
                    .Substring(b_num.Length - 10);
                Common.b_num.Add(b_num);
                b_num = $"92{b_num}";
            }


            // removing 64 from start and 7 from end b-party
            if (b_num.Length == 14 && b_num.StartsWith("64") && b_num.EndsWith("7"))
            {
                b_num = b_num.Substring(b_num.Length - 11);

                // removing 7 from end b-party
                b_num = b_num.Substring(0, 10);
                Common.b_num.Add(b_num);
                b_num = $"92{b_num}";
            }

            // removing 64 from start b-party
            /*if (b_num.Length == 13 && b_num.StartsWith("64"))
            {
                b_num = b_num.Substring(b_num.Length - 10);
                Common.b_num.Add(b_num);
                b_num = $"92{b_num}";
            }*/

            return b_num;
        }

        // Method to sort a list of StanderizedCDR objects by Date
        void SortCDRListByDate(List<StanderizedCDR> cdrList)
        {
            // Use the Sort method with a custom comparison function
            cdrList.Sort((x, y) =>
            {
                // Parse the Date string into a DateTime object for accurate comparison
                DateTime dateX = DateTime.ParseExact(x.Date, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                DateTime dateY = DateTime.ParseExact(y.Date, "MM-dd-yyyy", CultureInfo.InvariantCulture);

                // Compare the DateTime objects
                return dateX.CompareTo(dateY);
            });
        }

        // function to standarized Jazz CDR
        private void standJazzCDR()
        {
            try
            {
                if (dt != null)
                {

                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        StanderizedCDR standerizedCDR = new StanderizedCDR();


                        standerizedCDR.A_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.jazz_A_Num]?.ToString()) ? "0" : dt.Rows[i][Common.jazz_A_Num].ToString();


                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        /*Removing 0 from all contacts in B-Party*/
                        //string value = dt.Rows[i][Common.jazz_B_Num].ToString().TrimStart(new Char[] { '0' });

                        standerizedCDR.B_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.jazz_B_Num]?.ToString()) ? "0" : dt.Rows[i][Common.jazz_B_Num].ToString().Trim();


                        standerizedCDR.B_Num = standerize_B_Party(standerizedCDR.B_Num);
                        
                        /*Adding 92 to contact number whose length is 10*/
                        /*if (standerizedCDR.B_Num.Length >= 10 && standerizedCDR.B_Num.Length <= 12)
                        {
                            standerizedCDR.B_Num = standerizedCDR.B_Num
                                .Substring(standerizedCDR.B_Num.Length - 10);
                            Common.b_num.Add(standerizedCDR.B_Num);
                            standerizedCDR.B_Num = $"92{standerizedCDR.B_Num}";
                        }*/

                        //if (dt.Rows[i][Common.imei].ToString().Length > 14)
                        //  standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString().Substring(0, 14);
                        //else
                        string tempIMEI = dt.Rows[i][Common.imei].ToString();

                        standerizedCDR.IMEI = "0";
                        standerizedCDR.IMEI = !String.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length >= 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;

                        string dtime = dt.Rows[i][Common.datetime].ToString();



                        DateTime dtValue = string.IsNullOrWhiteSpace(dt.Rows[i][Common.datetime]?.ToString()) ? DateTime.MinValue : DateTime.Parse(dt.Rows[i][Common.datetime].ToString());
                        datetime.Add(dtValue);


                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        standerizedCDR.Call_Dur = string.IsNullOrWhiteSpace(dt.Rows[i][Common.duration]?.ToString()) ? "0" : dt.Rows[i][Common.duration].ToString();


                        standerizedCDR.Call_Dir = dt.Rows[i][Common.jazz_Call_Type].ToString().Substring(0, 8).ToLower();


                        standerizedCDR.Cell_ID = dt.Rows[i][Common.jazz_Cell_ID].ToString();

                        // Get first 4 characters substring from a string
                        var revLacID = string.IsNullOrWhiteSpace(standerizedCDR.Cell_ID) ? "0" : string.Join("", standerizedCDR.Cell_ID.Substring(0, 4).Reverse().ToArray());


                        /* Converting lacId from hex to decimal*/
                        standerizedCDR.Lac_No = Convert.ToInt32(revLacID.ToString(), 16).ToString();
                        // Get everything else after 4th position
                        var revCellID = string.IsNullOrWhiteSpace(standerizedCDR.Cell_ID) ? "0" : string.Join("", standerizedCDR.Cell_ID.Substring(4).Reverse().ToArray());

                        /* Converting cellId from hex to decimal*/
                        standerizedCDR.Cell_ID = Convert.ToInt32(revCellID.ToString(), 16).ToString();

                        //Getting location
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(dt.Rows[i][Common.jazz_Location]?.ToString()) ? "Nil" : dt.Rows[i][Common.jazz_Location].ToString();


                        /*first getting string after first '|' then splitting that string on the basis of '|' 
                        to get latitude and longitude in string array*/
                        var matches = ExtractCoordinates(standerizedCDR.Loc);
                        //string[] latlng = standerizedCDR.Loc.Substring(standerizedCDR.Loc.IndexOf('|') + 1).Split('|');

                        standerizedCDR.Lat = matches.Count >= 2 ? matches[0] : "0";
                        standerizedCDR.Lng = matches.Count >= 2 ? matches[1] : "0";
                        //getting first element of latlng string array
                        //standerizedCDR.Lat = latlng.First();

                        //getting last element of latlng string array and removing
                        //last double quotes from it
                        //standerizedCDR.Lng = latlng.Last().Remove(latlng.Last().Length - 1, 1);

                        standerizedCDR.Network = Common.jazz_Network;


                        // if column call direction cell contains sms then call type is sms else Voice
                        standerizedCDR.Call_Type = dt.Rows[i][Common.jazz_Call_Type].ToString().ToLower().Contains(Common.sms) ? Common.sms : Common.voice;



                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    // Display the sorted list
                    /*foreach (var cdr in standCDR)
                    {
                        Console.WriteLine(cdr.Date);
                    }*/

                    cDRDBTblBindingSource.DataSource = standCDR;

                    UniqID();

                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void standJazzCDR1()
        {
            if (dt != null)
            {
                try
                {
                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    foreach (DataRow row in dt.Rows)
                    {
                        StanderizedCDR standerizedCDR = new StanderizedCDR();
                        standerizedCDR.A_Num = string.IsNullOrWhiteSpace(row[Common.jazzCDR1[1]].ToString()) ? "0" : row[Common.jazzCDR1[1]].ToString();
                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        /*Removing 0 from all contacts in B-Party*/
                        standerizedCDR.B_Num = string.IsNullOrWhiteSpace(row[Common.jazzCDR1[2]].ToString()) ? "0" : row[Common.jazzCDR1[2]].ToString().TrimStart('0');

                        //standerizedCDR.B_Num = dt.Rows[i][Common.jazz_B_Num].ToString().Trim();

                        standerizedCDR.B_Num = standerize_B_Party(standerizedCDR.B_Num);

                        string tempIMEI = row[Common.jazzCDR1[6]].ToString();

                        standerizedCDR.IMEI = "0";
                        standerizedCDR.IMEI = !String.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length >= 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;

                        //string dtime = row[Common.jazzCDR1[3]].ToString();


                        DateTime dtValue = string.IsNullOrWhiteSpace(row[Common.jazzCDR1[3]].ToString()) ? DateTime.MinValue : DateTime.Parse(row[Common.jazzCDR1[3]].ToString());


                        datetime.Add(dtValue);


                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        standerizedCDR.Call_Dur = string.IsNullOrWhiteSpace(row[Common.jazzCDR1[4]].ToString()) ? "0" : row[Common.jazzCDR1[4]].ToString();


                        standerizedCDR.Call_Dir = row[Common.jazzCDR1[0]].ToString().Substring(0, 8).ToLower();


                        standerizedCDR.Cell_ID = row[Common.jazzCDR1[5]].ToString();

                        // Get first 4 characters substring from a string
                        var revLacID = string.IsNullOrWhiteSpace(standerizedCDR.Cell_ID) ? "0" : string.Join("", standerizedCDR.Cell_ID.Substring(0, 4).Reverse().ToArray());


                        /* Converting lacId from hex to decimal*/
                        standerizedCDR.Lac_No = Convert.ToInt32(revLacID.ToString(), 16).ToString();

                        // Get everything else after 4th position
                        var revCellID = string.IsNullOrWhiteSpace(standerizedCDR.Cell_ID) ? "0" : string.Join("", standerizedCDR.Cell_ID.Substring(4).Reverse().ToArray());


                        /* Converting cellId from hex to decimal*/
                        standerizedCDR.Cell_ID = Convert.ToInt32(revCellID.ToString(), 16).ToString();

                        //Getting location
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(row[Common.jazzCDR1[8]].ToString()) ? "Nil" : row[Common.jazzCDR1[8]].ToString();


                        /*first getting string after first '|' then splitting that string on the basis of '|' 
                        to get latitude and longitude in string array*/
                        var matches = ExtractCoordinates(standerizedCDR.Loc);
                        //string[] latlng = standerizedCDR.Loc.Substring(standerizedCDR.Loc.IndexOf('|') + 1).Split('|');

                        standerizedCDR.Lat = matches.Count >= 2 ? matches[0] : "0";
                        standerizedCDR.Lng = matches.Count >= 2 ? matches[1] : "0";

                        //getting first element of latlng string array
                        //standerizedCDR.Lat = latlng.First();

                        //getting last element of latlng string array and removing
                        //last double quotes from it
                        //standerizedCDR.Lng = latlng.Last().Remove(latlng.Last().Length - 1, 1);

                        standerizedCDR.Network = Common.jazz_Network;


                        // if column call direction cell contains sms then call type is sms else Voice
                        standerizedCDR.Call_Type = row[Common.jazzCDR1[0]].ToString().ToLower().Contains(Common.sms) ? Common.sms : Common.voice;


                        //Console.WriteLine(A_Num + " " + standerizedCDR.B_Num + " " + standerizedCDR.Date + " " + standerizedCDR.Call_Dur);
                        //bftbErrorHandling.Text = A_Num + " " + standerizedCDR.B_Num + " " + standerizedCDR.Date + " " + standerizedCDR.Call_Dur;
                        standCDR.Add(standerizedCDR);
                    }


                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    /*// Display the sorted list
                    foreach (var cdr in standCDR)
                    {
                        Console.WriteLine(cdr.Date);
                    }*/

                    cDRDBTblBindingSource.DataSource = standCDR;

                    //UniqID();
                }
                catch (Exception ex)
                {
                    CommonMethods.messageDialog(ex.Message);

                    UpdateErrorHandlingText(standCDR);
                }

            }
        }

        public void UpdateErrorHandlingText(List<StanderizedCDR> standCDR)
        {
            //Here we plus 2 because 1 line is header
            bflbErrorExcelSheet.Text = $"{standCDR.Count + 2}";

            if (standCDR.Count >= 2)
            {
                var secondLastItem = standCDR[standCDR.Count - 2];
                var lastItem = standCDR.Last();

                tbErrorHandling.Text = $"--Second Last Line--" +
                                       $"{Environment.NewLine}A_Num: {secondLastItem.A_Num}" +
                                       $"{Environment.NewLine}B_Num: {secondLastItem.B_Num}" +
                                       $"{Environment.NewLine}Date: {secondLastItem.Date}" +
                                       $"{Environment.NewLine}Call_Dur: {secondLastItem.Call_Dur}" +
                                       $"{Environment.NewLine}{Environment.NewLine}--Last Line--" +
                                       $"{Environment.NewLine}A_Num: {lastItem.A_Num}" +
                                       $"{Environment.NewLine}B_Num: {lastItem.B_Num}" +
                                       $"{Environment.NewLine}Date: {lastItem.Date}" +
                                       $"{Environment.NewLine}Call_Dur: {lastItem.Call_Dur}";
            }
            else
            {
                tbErrorHandling.Multiline = true; // Ensure this property is set
                var lastItem = standCDR.LastOrDefault();

                tbErrorHandling.Text = $"--Last Line--" +
                                       $"{Environment.NewLine}A_Num: {lastItem?.A_Num}" +
                                       $"{Environment.NewLine}B_Num: {lastItem?.B_Num}" +
                                       $"{Environment.NewLine}Date: {lastItem?.Date}" +
                                       $"{Environment.NewLine}Call_Dur: {lastItem?.Call_Dur}";
            }
        }

        private List<string> ExtractCoordinates(string text)
        {
            var pattern = @"\b\d{2}\.\d+\b";
            var matches = Regex.Matches(text, pattern);
            var result = new List<string>();

            foreach (Match match in matches)
            {
                result.Add(match.Value);
            }

            return result;
        }

        // function to standarized Telenor CDR
        private void standTelenorCDR()
        {
            var regexItem = new Regex("[a-zA-Z ]*$");
            //string dateFormat = "dd-MM-yyyy H:mm"; // Updated date format to match "22-11-2023 23:57"
            try
            {
                if (dt != null)
                {
                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StanderizedCDR standerizedCDR = new StanderizedCDR();

                        string tempA_Num = dt.Rows[i][Common.telenor_A_Num].ToString().Trim();
                        standerizedCDR.A_Num = !string.IsNullOrWhiteSpace(tempA_Num) ? tempA_Num : "";
                        //standerizedCDR.A_Num = dt.Rows[i][Common.telenor_A_Num].ToString();

                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        /*There are two columns in Telenor CDR, here trying to make one
                         column for B-Party*/
                        var CALL_ORIG_NUM = dt.Rows[i][1].ToString();
                        var CALL_DIALED_NUM = dt.Rows[i][2].ToString();
                        string tempB_Num = "";

                        tempB_Num = standerizedCDR.A_Num.Equals(CALL_ORIG_NUM) ? CALL_DIALED_NUM : CALL_ORIG_NUM;



                        //Get last 10 digits of B-Party
                        standerizedCDR.B_Num = !string.IsNullOrWhiteSpace(tempB_Num)
                                && tempB_Num.Length >= 10 && !regexItem.IsMatch(tempB_Num)
                                ? $"92{tempB_Num.Substring(tempB_Num.Length - 10)}" : tempB_Num;
                        Common.b_num.Add(standerizedCDR.B_Num);
                        //Adding 92 to the starting of B-Party
                        /*standerizedCDR.B_Num = $"92{standerizedCDR.B_Num}";*/


                        /*if (dt.Rows[i][Common.imei].ToString().Length > 14)
                                standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString().Substring(0, 14);
                            else
                                standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString();*/
                        string tempIMEI = dt.Rows[i][Common.imei].ToString();

                        // if null
                        standerizedCDR.IMEI = "0";
                        // if not null
                        standerizedCDR.IMEI = !string.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length > 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;

                        DateTime dtValue = !string.IsNullOrWhiteSpace(dt.Rows[i][Common.telenor_date_time]?.ToString()) ? Convert.ToDateTime(dt.Rows[i][Common.telenor_date_time].ToString()) : DateTime.MinValue;
                        //DateTime dtValue = DateTime.ParseExact(TryParseDateTime(dt.Rows[i][Common.telenor_date_time]?.ToString()), dateFormat, CultureInfo.InvariantCulture);
                        datetime.Add(dtValue);

                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        // Removing Zeros after '.' in Call Duration
                        standerizedCDR.Call_Dur = dt.Rows[i][Common.telenor_Call_Dur].ToString();//.Substring(0, dt.Rows[i][Common.telenor_Call_Dur].ToString().LastIndexOf('.'));

                        standerizedCDR.Call_Dir = dt.Rows[i][Common.telenor_Call_Dir].ToString().ToLower();


                        // to get cell id
                        standerizedCDR.Cell_ID = string.IsNullOrWhiteSpace(dt.Rows[i][10]?.ToString()) ? "0" : dt.Rows[i][10].ToString();



                        // to get lac id
                        standerizedCDR.Lac_No = string.IsNullOrWhiteSpace(dt.Rows[i][9]?.ToString()) ? "0" : dt.Rows[i][9].ToString();


                        //Getting location
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(dt.Rows[i][Common.loc]?.ToString()) ? "Nil" : dt.Rows[i][Common.loc].ToString();


                        //getting latitude
                        string tempLat = dt.Rows[i][Common.telenor_Lat].ToString().Trim();

                        standerizedCDR.Lat = !string.IsNullOrWhiteSpace(tempLat) ? tempLat : "0";

                        //getting longitude
                        string tempLng = dt.Rows[i][Common.telenor_Lng].ToString();

                        standerizedCDR.Lng = !string.IsNullOrWhiteSpace(tempLng) ? tempLng : "0";

                        standerizedCDR.Network = Common.telenor_Network;

                        standerizedCDR.Call_Type = Common.callTypes.Contains(dt.Rows[i][Common.call_Type].ToString().ToUpper()) ? Common.voice : Common.sms;



                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    cDRDBTblBindingSource.DataSource = standCDR;
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                //var st = new StackTrace(ex, true);
                // Get the top stack frame
                //var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                CommonMethods.messageDialog(ex.Message);
                //CommonMethods.messageDialog(ex.Message);
                UpdateErrorHandlingText(standCDR);
            }
        }


        // function to standarized Ufone CDR
        private void standUfoneCDR()
        {
            try
            {
                if (dt != null)
                {
                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    //string dateFormat = "dd-MM-yyyy H:mm"; // Updated date format to match "22-11-2023 23:57"
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StanderizedCDR standerizedCDR = new StanderizedCDR();
                        standerizedCDR.A_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_A_Num]?.ToString()) ? "0" : dt.Rows[i][Common.ufone_A_Num].ToString();

                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        /*Removing 0 from all contacts in B-Party*/
                        standerizedCDR.B_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_B_Num]?.ToString()) ? "0" : dt.Rows[i][Common.ufone_B_Num].ToString().Trim();


                        /*Adding 92 to contact number whose length is 10*/
                        if (standerizedCDR.B_Num.Length >= 10 && standerizedCDR.B_Num.Length <= 12)
                        {
                            standerizedCDR.B_Num = standerizedCDR.B_Num
                                .Substring(standerizedCDR.B_Num.Length - 10);
                            standerizedCDR.B_Num = $"92{standerizedCDR.B_Num}";
                        }

                        string tempIMEI = dt.Rows[i][Common.imei].ToString();

                        // if null
                        standerizedCDR.IMEI = "0";
                        // if not null
                        standerizedCDR.IMEI = !string.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length > 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;

                        //standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString().Length > 14 ? dt.Rows[i][Common.imei].ToString().Substring(0, 14) : dt.Rows[i][Common.imei].ToString();



                        DateTime dtValue = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_Start_Time]?.ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i][Common.ufone_Start_Time].ToString());
                        //DateTime dtValue = DateTime.ParseExact(TryParseDateTime(dt.Rows[i][Common.ufone_Start_Time]?.ToString()), dateFormat, CultureInfo.InvariantCulture);

                        datetime.Add(dtValue);

                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        standerizedCDR.Call_Dur = string.IsNullOrWhiteSpace(dt.Rows[i][Common.duration]?.ToString()) ? "0" : dt.Rows[i][Common.duration].ToString();


                        standerizedCDR.Call_Dir = dt.Rows[i][Common.ufone_Call_Dir].ToString().ToLower();

                        /*Getting first 5 digits from cdr for LacID*/
                        // Check if the cellid is null, empty, or consists solely of white-space characters
                        standerizedCDR.Lac_No = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_Cell_ID].ToString()) ? "0" : dt.Rows[i][Common.ufone_Cell_ID].ToString().Substring(0, 5);


                        standerizedCDR.Cell_ID = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_Cell_ID].ToString()) ? "0" : dt.Rows[i][Common.ufone_Cell_ID].ToString().Substring(5);


                        // Check if the loc is null, empty, or consists solely of white-space characters
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(dt.Rows[i][Common.loc].ToString()) ? "Nil" : dt.Rows[i][Common.loc].ToString();


                        // Check if the latitude is null, empty, or consists solely of white-space characters
                        standerizedCDR.Lat = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_Lat].ToString()) ? "0" : dt.Rows[i][Common.ufone_Lat].ToString();


                        // Check if the longitude is null, empty, or consists solely of white-space characters
                        standerizedCDR.Lng = string.IsNullOrWhiteSpace(dt.Rows[i][Common.ufone_Lng].ToString()) ? "0" : dt.Rows[i][Common.ufone_Lng].ToString();


                        standerizedCDR.Network = Common.ufone_Network;

                        standerizedCDR.Call_Type = Common.callTypes.Contains(dt.Rows[i][Common.ufone_Call_Type].ToString().ToUpper()) ? Common.voice : Common.sms;

                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    cDRDBTblBindingSource.DataSource = standCDR;
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
                UpdateErrorHandlingText(standCDR);
            }
        }


        // function to standarized Zong CDR
        private void standZongCDR()
        {
            try
            {
                if (dt != null)
                {
                    // Removing first 4 rows in Zong CDR
                    /*for (int i = 0; i < 5; i++)
                    {
                        dt.Rows[i].Delete();
                    }
                    dt.AcceptChanges();*/

                    
                    //string[] columnsToInclude = { "CALL_TYPE", "MSISDN_ID", "STRT_TM", "BNUMBER", "MINS", "SECS", "LAC_ID", "CELL_ID", "IMEI", "SITE_ADDRESS", "LNG", "LAT" };


                    // Find the index of the header row containing the specified columns
                    int headerRowIndex = -1;
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        if (row[0].Equals(Common.call_Type))
                        {
                            headerRowIndex = i;
                            break;
                        }
                        
                    }


                    // Removing first rows in Zong CDR
                    for (int j = 0; j < headerRowIndex+1; j++)
                    {
                        dt.Rows[j].Delete();
                    }
                    dt.AcceptChanges();

                    /*Renaming the columns in Zong CDR datatable after removing first 4 rows*/
                    dt.Columns[0].ColumnName = Common.call_Type;
                    dt.Columns[1].ColumnName = Common.zong_A_Num;
                    dt.Columns[2].ColumnName = Common.zong_date_time;
                    dt.Columns[3].ColumnName = Common.zong_B_Num;
                    dt.Columns[4].ColumnName = Common.zong_mins;
                    dt.Columns[5].ColumnName = Common.zong_secs;
                    dt.Columns[6].ColumnName = Common.zong_lac_no;
                    dt.Columns[7].ColumnName = Common.zong_cell_id;
                    dt.Columns[8].ColumnName = Common.imei;
                    dt.Columns[9].ColumnName = Common.zong_loc;
                    dt.Columns[10].ColumnName = Common.zong_lng;
                    dt.Columns[11].ColumnName = Common.zong_lat;

                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StanderizedCDR standerizedCDR = new StanderizedCDR();

                        standerizedCDR.A_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_A_Num]?.ToString()) ? "0" : dt.Rows[i][Common.zong_A_Num].ToString();


                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        /*Getting B - Party*/
                        standerizedCDR.B_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_B_Num]?.ToString()) ? "0" : dt.Rows[i][Common.zong_B_Num].ToString().Trim();


                        /*Adding 92 to contact number whose length is 10*/
                        if (standerizedCDR.B_Num.Length >= 10 && standerizedCDR.B_Num.Length <= 12)
                        {
                            standerizedCDR.B_Num = standerizedCDR.B_Num
                                .Substring(standerizedCDR.B_Num.Length - 10);
                            standerizedCDR.B_Num = $"92{standerizedCDR.B_Num}";
                        }

                        string tempIMEI = dt.Rows[i][Common.imei].ToString();

                        // if null
                        standerizedCDR.IMEI = "0";
                        // if not null
                        standerizedCDR.IMEI = !string.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length > 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;
                        //standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString().Length > 14 ? dt.Rows[i][Common.imei].ToString().Substring(0, 14) : dt.Rows[i][Common.imei].ToString();


                        DateTime dtValue = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_date_time]?.ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i][Common.zong_date_time].ToString());

                        datetime.Add(dtValue);

                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        /*Converting minutes to seconds and adding seconds to it in the next column of zong cdr*/
                        var callDur = (Convert.ToUInt16(dt.Rows[i][Common.zong_mins]) * 60) + Convert.ToUInt16(dt.Rows[i]["SECS"]);

                        standerizedCDR.Call_Dur = callDur.ToString();

                        standerizedCDR.Call_Dir = dt.Rows[i][Common.call_Type].ToString().Split('-').Last().ToLower().Trim();

                        /*Getting LacID*/
                        standerizedCDR.Lac_No = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_lac_no]?.ToString()) ? "0" : dt.Rows[i][Common.zong_lac_no].ToString();


                        /*Getting CellID*/
                        standerizedCDR.Cell_ID = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_cell_id]?.ToString()) ? "0" : dt.Rows[i][Common.zong_cell_id].ToString();


                        //Getting location
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_loc]?.ToString()) ? "Nil" : dt.Rows[i][Common.zong_loc].ToString();


                        //Getting latitude
                        standerizedCDR.Lat = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_lat]?.ToString()) ? "0" : dt.Rows[i][Common.zong_lat].ToString();


                        //Getting longitude
                        standerizedCDR.Lng = string.IsNullOrWhiteSpace(dt.Rows[i][Common.zong_lng]?.ToString()) ? "0" : dt.Rows[i][Common.zong_lng].ToString();


                        standerizedCDR.Network = Common.zong_network;

                        /*Splitting call type and getting first part of Call_Type like SMS or Call*/
                        string Call_Type = dt.Rows[i][Common.call_Type].ToString().Split('-').First().ToUpper().Trim();

                        // if column call direction cell contains call then call type is voice else sms
                        standerizedCDR.Call_Type = Common.callTypes.Contains(Call_Type) ? Common.voice : Common.sms;


                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    cDRDBTblBindingSource.DataSource = standCDR;
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                //var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                //CommonMethods.messageDialog(ex.Message + " " + line);
                CommonMethods.messageDialog(ex.Message);
                //CommonMethods.messageDialog(ex.Message);
                UpdateErrorHandlingText(standCDR);
            }
        }

        private void standWaridCDR()
        {
            try
            {
                if (dt != null)
                {

                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        StanderizedCDR standerizedCDR = new StanderizedCDR();


                        standerizedCDR.A_Num = string.IsNullOrWhiteSpace(dt.Rows[i][Common.jazz_A_Num]?.ToString()) ? "0" : dt.Rows[i][Common.jazz_A_Num].ToString();


                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        /*Removing 0 from all contacts in B-Party*/
                        //standerizedCDR.B_Num = dt.Rows[i][Common.jazz_B_Num].ToString().TrimStart(new Char[] { '0' });

                        string value = string.IsNullOrWhiteSpace(dt.Rows[i][Common.jazz_B_Num]?.ToString()) ? "0" : dt.Rows[i][Common.jazz_B_Num].ToString().Trim();


                        standerizedCDR.B_Num = standerize_B_Party(value);
                        /*Adding 92 to contact number whose length is 10*/
                        /*if (standerizedCDR.B_Num.Length >= 10 && standerizedCDR.B_Num.Length <= 12)
                        {
                            standerizedCDR.B_Num = standerizedCDR.B_Num
                                .Substring(standerizedCDR.B_Num.Length - 10);
                            Common.b_num.Add(standerizedCDR.B_Num);
                            standerizedCDR.B_Num = $"92{standerizedCDR.B_Num}";
                        }*/

                        //if (dt.Rows[i][Common.imei].ToString().Length > 14)
                        //  standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString().Substring(0, 14);
                        //else
                        string tempIMEI = dt.Rows[i][Common.imei].ToString();

                        standerizedCDR.IMEI = "0";
                        standerizedCDR.IMEI = !String.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length >= 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;

                        string dtime = dt.Rows[i][Common.datetime].ToString();



                        DateTime dtValue = string.IsNullOrWhiteSpace(dt.Rows[i][Common.datetime]?.ToString()) ? DateTime.MinValue : DateTime.Parse(dt.Rows[i][Common.datetime].ToString());
                        datetime.Add(dtValue);


                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        standerizedCDR.Call_Dur = string.IsNullOrWhiteSpace(dt.Rows[i][Common.duration]?.ToString()) ? "0" : dt.Rows[i][Common.duration].ToString();


                        standerizedCDR.Call_Dir = dt.Rows[i][Common.jazz_Call_Type].ToString().Substring(0, 8).ToLower();


                        standerizedCDR.Cell_ID = dt.Rows[i][Common.jazz_Cell_ID].ToString();

                        // Get first 4 characters substring from a string
                        var revLacID = string.IsNullOrWhiteSpace(standerizedCDR.Cell_ID) ? "0" : string.Join("", standerizedCDR.Cell_ID.Substring(0, 4).Reverse().ToArray());


                        /* Converting lacId from hex to decimal*/
                        standerizedCDR.Lac_No = Convert.ToInt32(revLacID.ToString(), 16).ToString();
                        // Get everything else after 4th position
                        var revCellID = string.IsNullOrWhiteSpace(standerizedCDR.Cell_ID) ? "0" : string.Join("", standerizedCDR.Cell_ID.Substring(4).Reverse().ToArray());

                        /* Converting cellId from hex to decimal*/
                        standerizedCDR.Cell_ID = Convert.ToInt32(revCellID.ToString(), 16).ToString();

                        //Getting location
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(dt.Rows[i][Common.jazz_Location]?.ToString()) ? "Nil" : dt.Rows[i][Common.jazz_Location].ToString();


                        /*first getting string after first '|' then splitting that string on the basis of '|' 
                        to get latitude and longitude in string array*/
                        var matches = ExtractCoordinates(standerizedCDR.Loc);
                        //string[] latlng = standerizedCDR.Loc.Substring(standerizedCDR.Loc.IndexOf('|') + 1).Split('|');

                        standerizedCDR.Lat = matches.Count >= 2 ? matches[0] : "0";
                        standerizedCDR.Lng = matches.Count >= 2 ? matches[1] : "0";
                        //getting first element of latlng string array
                        //standerizedCDR.Lat = latlng.First();

                        //getting last element of latlng string array and removing
                        //last double quotes from it
                        //standerizedCDR.Lng = latlng.Last().Remove(latlng.Last().Length - 1, 1);

                        standerizedCDR.Network = Common.jazz_Network;


                        // if column call direction cell contains sms then call type is sms else Voice
                        standerizedCDR.Call_Type = dt.Rows[i][Common.jazz_Call_Type].ToString().ToLower().Contains(Common.sms) ? Common.sms : Common.voice;



                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    // Display the sorted list
                    /*foreach (var cdr in standCDR)
                    {
                        Console.WriteLine(cdr.Date);
                    }*/

                    cDRDBTblBindingSource.DataSource = standCDR;

                    //UniqID();

                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
                UpdateErrorHandlingText(standCDR);
            }
        }


        // function to standarized Warid CDR
        /*private void standWaridCDR()
        {
            try
            {
                if (dt != null)
                {
                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        StanderizedCDR standerizedCDR = new StanderizedCDR();


                        standerizedCDR.A_Num = dt.Rows[i][Common.jazz_A_Num].ToString();

                        *//*getting a-party in string A_Num for later use*//*
                        A_Num = standerizedCDR.A_Num;

                        *//*Removing 0 from all contacts in B-Party*//*
                        standerizedCDR.B_Num = dt.Rows[i][Common.jazz_B_Num].ToString().Trim();

                        *//*Adding 92 to contact number whose length is 10*//*
                        if (standerizedCDR.B_Num.Length >= 10 && standerizedCDR.B_Num.Length <= 12)
                        {
                            standerizedCDR.B_Num = standerizedCDR.B_Num
                                .Substring(standerizedCDR.B_Num.Length - 10);
                            standerizedCDR.B_Num = $"92{standerizedCDR.B_Num}";
                        }

                        if (dt.Rows[i][Common.imei].ToString().Length > 14)
                            standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString().Substring(0, 14);
                        else
                            standerizedCDR.IMEI = dt.Rows[i][Common.imei].ToString();

                        DateTime dtValue = (DateTime)dt.Rows[i][Common.datetime];
                        datetime.Add(dtValue);

                        *//*Separating date from dtValue and adding it to Date*//*
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        *//*Converting Date into Weekdays like sunday, monday etc*//*
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        *//*Separating time from dtValue and adding it to Time*//*
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        standerizedCDR.Call_Dur = dt.Rows[i][Common.duration].ToString();

                        standerizedCDR.Call_Dir = dt.Rows[i][Common.jazz_Call_Type].ToString().Substring(0, 8).ToLower();


                        standerizedCDR.Cell_ID = dt.Rows[i][Common.jazz_Cell_ID].ToString();

                        // Get first 4 characters substring from a string
                        var revLacID = string.Join("", standerizedCDR.Cell_ID.Substring(0, 4).Reverse().ToArray());

                        *//* Converting lacId from hex to decimal*//*
                        standerizedCDR.Lac_No = Convert.ToInt32(revLacID.ToString(), 16).ToString();
                        // Get everything else after 4th position
                        var revCellID = string.Join("", standerizedCDR.Cell_ID.Substring(4).Reverse().ToArray());

                        *//* Converting cellId from hex to decimal*//*
                        standerizedCDR.Cell_ID = Convert.ToInt32(revCellID.ToString(), 16).ToString();

                        //Getting location
                        standerizedCDR.Loc = dt.Rows[i][Common.jazz_Location].ToString();

                        *//*first getting string after first '|' then splitting that string on the basis of '|' 
                        to get latitude and longitude in string array*//*
                        //string[] latlng = standerizedCDR.Loc.Substring(standerizedCDR.Loc.IndexOf("|") + 1).Split('|');

                        //getting first element of latlng string array
                        //standerizedCDR.Lat = latlng.First();

                        //getting last element of latlng string array
                        //standerizedCDR.Lng = latlng.Last();

                        var matches = ExtractCoordinates(standerizedCDR.Loc);
                        //string[] latlng = standerizedCDR.Loc.Substring(standerizedCDR.Loc.IndexOf('|') + 1).Split('|');

                        if (matches.Count >= 2)
                        {
                            standerizedCDR.Lat = matches[0]; // Latitude
                            standerizedCDR.Lng = matches[1]; // Longitude
                        }

                        standerizedCDR.Network = Common.warid_network;

                        // if column call direction cell contains sms then call type is sms else Voice
                        if (dt.Rows[i][Common.jazz_Call_Type].ToString().ToLower().Contains(Common.sms))
                        {
                            standerizedCDR.Call_Type = Common.sms;
                        }
                        else
                        {
                            standerizedCDR.Call_Type = Common.voice;
                        }


                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    cDRDBTblBindingSource.DataSource = standCDR;
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
                UpdateErrorHandlingText(standCDR);
            }
        }*/


        private void standCustomCDR()
        {
            try
            {
                if (dt != null)
                {

                    standCDR = new List<StanderizedCDR>();
                    datetime = new List<DateTime>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        StanderizedCDR standerizedCDR = new StanderizedCDR();


                        standerizedCDR.A_Num = string.IsNullOrWhiteSpace(dt.Rows[i]["A_Num"]?.ToString()) ? "0" : dt.Rows[i]["A_Num"].ToString();


                        /*getting a-party in string A_Num for later use*/
                        A_Num = standerizedCDR.A_Num;

                        standerizedCDR.B_Num = string.IsNullOrWhiteSpace(dt.Rows[i]["B_Num"]?.ToString()) ? "0" : dt.Rows[i]["B_Num"].ToString().Trim();


                        standerizedCDR.B_Num = standerize_B_Party(standerizedCDR.B_Num);

                        string tempIMEI = dt.Rows[i]["IMEI"].ToString();

                        standerizedCDR.IMEI = "0";
                        standerizedCDR.IMEI = !String.IsNullOrWhiteSpace(tempIMEI) && tempIMEI.Length >= 14
                            ? tempIMEI.Substring(0, 14)
                            : tempIMEI;

                        string dtime = string.IsNullOrWhiteSpace(dt.Rows[i][Common.datetime]?.ToString()) ? DateTime.MinValue.ToString() : dt.Rows[i][Common.datetime].ToString();



                        DateTime dtValue = string.IsNullOrWhiteSpace(dt.Rows[i]["Date & Time"]?.ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["Date & Time"]);

                        datetime.Add(dtValue);


                        /*Separating date from dtValue and adding it to Date*/
                        standerizedCDR.Date = dtValue.ToString(Common.datef);

                        /*Converting Date into Weekdays like sunday, monday etc*/
                        standerizedCDR.Weekday = Convert.ToDateTime(standerizedCDR.Date).DayOfWeek.ToString();

                        /*Separating time from dtValue and adding it to Time*/
                        standerizedCDR.Time = dtValue.ToString(Common.timef);

                        standerizedCDR.Call_Dur = string.IsNullOrWhiteSpace(dt.Rows[i]["Call_Dur"]?.ToString()) ? "0" : dt.Rows[i]["Call_Dur"].ToString();


                        standerizedCDR.Call_Dir = string.IsNullOrWhiteSpace(dt.Rows[i]["Call_Dir"]?.ToString()) ? "Nil" : dt.Rows[i]["Call_Dir"].ToString();

                        standerizedCDR.Call_Type = string.IsNullOrWhiteSpace(dt.Rows[i]["Call_Type"]?.ToString()) ? "Nil" : dt.Rows[i]["Call_Type"].ToString();


                        /* Converting lacId from hex to decimal*/
                        standerizedCDR.Lac_No = string.IsNullOrWhiteSpace(dt.Rows[i]["Lac_No"]?.ToString()) ? "0" : dt.Rows[i]["Lac_No"].ToString();


                        /* Converting cellId from hex to decimal*/
                        standerizedCDR.Cell_ID = string.IsNullOrWhiteSpace(dt.Rows[i]["Cell_ID"]?.ToString()) ? "0" : dt.Rows[i]["Cell_ID"].ToString();


                        //Getting location
                        standerizedCDR.Loc = string.IsNullOrWhiteSpace(dt.Rows[i]["Loc"]?.ToString()) ? "Nil" : dt.Rows[i]["Loc"].ToString();



                        //getting first element of latlng string array
                        standerizedCDR.Lat = string.IsNullOrWhiteSpace(dt.Rows[i]["Lat"]?.ToString()) ? "0" : dt.Rows[i]["Lat"].ToString();


                        //getting last element of latlng string array
                        standerizedCDR.Lng = string.IsNullOrWhiteSpace(dt.Rows[i]["Lng"]?.ToString()) ? "0" : dt.Rows[i]["Lng"].ToString();


                        standerizedCDR.Network = dt.Rows[i]["Network"].ToString(); ;

                        standCDR.Add(standerizedCDR);
                    }

                    // order cdr in ascending order on the basis of date
                    //standCDR = standCDR.OrderBy(d => d.Date).ToList();

                    // Call the method to sort the list by the Date property
                    SortCDRListByDate(standCDR);

                    cDRDBTblBindingSource.DataSource = standCDR;

                    UniqID();

                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                //var st = new StackTrace(ex, true);
                // Get the top stack frame
                //var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                //CommonMethods.messageDialog(ex.Message + " " + line);
                CommonMethods.messageDialog(ex.Message);
                UpdateErrorHandlingText(standCDR);
            }
        }

        //function to standerize CDRs
        private void standCDRs()
        {
            bool isTelenor = false;

            if (dt.Columns.Count > 0)
            {
                //getting a party number from the dt
                string aparty = dt.Rows[0][0].ToString();

                List<string> cdrCol = new List<string>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    DataColumn dataColumn = dt.Columns[i];
                    // Condition of remove blank column for jazz and other CDRs
                    if (!dataColumn.ColumnName.ToLower().Contains("column"))
                    {
                        cdrCol.Add(dataColumn.ColumnName.Trim());
                        
                    }

                }

                if (Common.jazzCDR.SequenceEqual(cdrCol) || Common.jazzCDR2.SequenceEqual(cdrCol))
                {
                    DataRow row = dt.Rows[0];
                    string r = row["A-Party"].ToString();

                    if (r.Substring(r.Length - 10).StartsWith("32"))
                    {
                        CommonMethods.messageDialog("Warid CDR");
                        standWaridCDR();
                    }
                    else
                    {

                        CommonMethods.messageDialog("Jazz CDR");
                        standJazzCDR();
                    }
                }
                else if (Common.jazzCDR1.SequenceEqual(cdrCol))
                {
                    CommonMethods.messageDialog("Jazz CDR");
                    standJazzCDR1();
                }
                else if (Common.ufoneCDR.SequenceEqual(cdrCol))
                {
                    CommonMethods.messageDialog("Ufone CDR");
                    standUfoneCDR();
                }
                else if (Common.telenorCDR.SequenceEqual(cdrCol) || Common.telenorCDR1.SequenceEqual(cdrCol))
                {
                    CommonMethods.messageDialog("Telenor CDR");
                    standTelenorCDR();
                }
                else if (cdrCol.Count == 2)
                {
                    CommonMethods.messageDialog("Zong CDR");
                    standZongCDR();
                }
                else if (Common.customCDR.SequenceEqual(cdrCol))
                {
                    CommonMethods.messageDialog("Custom CDR");
                    standCustomCDR();
                }
                else
                {
                    CommonMethods.messageDialog("Format Mismatch");
                }


            }

            try
            {
                // this is very important sorting the datetime in ascending order
                //datetime = datetime.OrderBy(d => d).ToList();
                datetime.Sort();
                //Console.WriteLine($"{datetime.First().ToString()} {datetime.Last().ToString()}");
                Common.startDate = datetime.First().ToString();
                Common.endDate = datetime.Last().ToString();
                Common.AParty = A_Num;
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
                //Console.WriteLine(ex.Message);
                //CommonMethods.messageDialog(ex.Message);
            }
        }



        private async void saveToDataBank()
        {
            if (cell_clicked)
            {


                if (rbGeneralPolice.Checked == true)
                {

                    try
                    {
                        SqlConnection con = new SqlConnection(AppConnection.GetConnectionString());

                        // stored procedure to check CDR already exist in the database or not
                        string spCheck_CDR_Exist = "exec dbo.Check_CDR_Exist '" + standCDR.Last().A_Num + "', '" + standCDR.Last().Date + "', '" + projectId + "', '" + project + "', '" + Common.userName + "'";
                        DataTable dt = new DataTable();
                        dt = await CommonMethods.getRecords(spCheck_CDR_Exist);

                        if (dt.Rows.Count >= 1)
                        {

                            CommonMethods.messageDialog("CDR Already Exist");
                        }
                        else
                        {
                            saveToCDRDataBank();
                        }
                    }
                    catch (Exception ex)
                    {

                        CommonMethods.messageDialog("Please First Upload CDR!!! " + ex.Message);
                    }
                }
                else if (rbProject.Checked == true)
                {

                    try
                    {

                        // stored procedure to check CDR already exist in the database or not
                        string spCheck_CDR_Exist = "exec dbo.Check_CDR_Exist '" + standCDR.Last().A_Num + "', '" + standCDR.Last().Date + "', '" + projectId + "', '" + project + "', '" + Common.userName + "'";
                        DataTable dt = new DataTable();
                        dt = await CommonMethods.getRecords(spCheck_CDR_Exist);

                        if (dt.Rows.Count >= 1)
                        {

                            CommonMethods.messageDialog("CDR Already Exist");
                        }
                        else
                        {
                            saveToCDRDataBank();
                        }
                    }
                    catch (Exception ex)
                    {

                        CommonMethods.messageDialog("Please First Upload CDR!! " + ex.Message);
                    }
                }
                else
                {

                    CommonMethods.messageDialog("Please Select Radio Button Where You Want to Save Data!!");
                }
            }
            else
            {

                CommonMethods.messageDialog("Please Select Project With Double Click!!");
            }
        }


        private void saveToCDRDataBank()
        {

            DataTable dtBulkInsert = new DataTable();

            // function to sort gridview on the basis of Date
            //gvStandCDR.Sort(gvStandCDR.Columns[3], ListSortDirection.Ascending);

            // Adding the Columns.
            foreach (DataGridViewColumn column in gvStandCDR.Columns)
            {
                dtBulkInsert.Columns.Add(column.HeaderText, column.ValueType);
            }

            dtBulkInsert.Columns.Add("ProjectId", typeof(int));
            dtBulkInsert.Columns.Add("project", typeof(string));
            dtBulkInsert.Columns.Add("username", typeof(string));

            //Adding the Rows.
            foreach (DataGridViewRow row in gvStandCDR.Rows)
            {
                dtBulkInsert.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                        dtBulkInsert.Rows[dtBulkInsert.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
                dtBulkInsert.Rows[dtBulkInsert.Rows.Count - 1]["ProjectId"] = projectId;
                dtBulkInsert.Rows[dtBulkInsert.Rows.Count - 1]["project"] = project;
                dtBulkInsert.Rows[dtBulkInsert.Rows.Count - 1]["username"] = Common.userName;

            }

            var stopWatch = new Stopwatch();
            progressBar.Maximum = gvStandCDR.Rows.Count;
            stopWatch.Start();
            try
            {
                SqlConnection sqlcon = new SqlConnection(AppConnection.GetConnectionString());

                using (SqlBulkCopy objBulk = new SqlBulkCopy(sqlcon))
                {
                    // number of rows copy of table in one go
                    objBulk.BatchSize = gvStandCDR.Rows.Count / 100;
                    objBulk.NotifyAfter = gvStandCDR.Rows.Count / 100;
                    objBulk.SqlRowsCopied += (sender, eventArgs) =>
                    {
                        if ((progressBar.Maximum - progressBar.Value) < objBulk.NotifyAfter)
                        {
                            progressBar.Value = progressBar.Maximum;
                        }
                        else
                        {
                            progressBar.Value = Convert.ToInt32(eventArgs.RowsCopied);
                        }
                    };
                    objBulk.DestinationTableName = Common.cdrDBTable;
                    objBulk.BulkCopyTimeout = 120;
                    objBulk.ColumnMappings.Add("A_Num", "A_Num");
                    objBulk.ColumnMappings.Add("B_Num", "B_Num");
                    objBulk.ColumnMappings.Add("IMEI", "IMEI");
                    objBulk.ColumnMappings.Add("Date", "Date");
                    objBulk.ColumnMappings.Add("Time", "Time");
                    objBulk.ColumnMappings.Add("Call_Dur", "Call_Dur");
                    objBulk.ColumnMappings.Add("Call_Dir", "Call_Dir");
                    objBulk.ColumnMappings.Add("Call_Type", "Call_Type");
                    objBulk.ColumnMappings.Add("Lac_No", "Lac_No");
                    objBulk.ColumnMappings.Add("Cell_ID", "Cell_ID");
                    objBulk.ColumnMappings.Add("Loc", "Loc");
                    objBulk.ColumnMappings.Add("Lat", "Lat");
                    objBulk.ColumnMappings.Add("Lng", "Lng");
                    objBulk.ColumnMappings.Add("Network", "Network");
                    objBulk.ColumnMappings.Add("Weekday", "Weekday");
                    objBulk.ColumnMappings.Add("UserName", "UserName");
                    objBulk.ColumnMappings.Add("ProjectId", "ProjectId");
                    objBulk.ColumnMappings.Add("Project", "Project");
                    sqlcon.Open();
                    try
                    {
                        objBulk.WriteToServer(dtBulkInsert);
                    }
                    catch (Exception ex)
                    {
                        CommonMethods.messageDialog(ex.Message);
                    }
                    finally
                    {
                        sqlcon.Close();
                        stopWatch.Stop();

                        saveToProjectTable();
                    }
                }



            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private async void saveToProjectTable()
        {

            string spCheckNum = "exec dbo.Check_Mobile_Number_Exist '" + standCDR.First().A_Num + "', '" + projectId + "', '" + project + "', '" + Common.userName + "'";
            DataTable dt = new DataTable();
            dt = await CommonMethods.getRecords(spCheckNum);
            if (dt.Rows.Count >= 1)
            {

                CommonMethods.messageDialog("Mobile Number Already Exist");
            }
            else
            {

                // sql query to add data to (GeneralPoliceTable)
                string qry = "insert into " + Common.projectTableA_Num + "(ProjectId, project, A_Num, username) " +
                    "values ('" + projectId + "', '" + project + "','" + A_Num + "', '" + Common.userName + "')";
                using (SqlConnection db = new SqlConnection(AppConnection.GetConnectionString()))
                {

                    db.Execute(qry);
                }

                CommonMethods.messageDialog("Finish !!!");

                //clear the progress bar
                progressBar.Value = 0;

                getProjectA_Num();

            }
        }

        private async void getProjectA_Num()
        {
            try
            {
                clearGridView();
                DataTable allRecord = new DataTable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // Stored Procedure only getting project table records not general police table records
                    string proc = "exec dbo.ProjectsTableA_Num_View_PID '" + Common.userName + "', '" + dataTable.Rows[i].Field<int>("ProjectId") + "', '" + dataTable.Rows[i].Field<string>("project") + "'";
                    allRecord.Merge(await CommonMethods.getRecords(proc));
                }

                /*DataView dv = allRecord.DefaultView;
                dv.Sort = "ProjectId DESC";*/
                gvCDRA_Num.DataSource = allRecord;
                if (rbGeneralPolice.Checked)
                {
                    gvCDRA_Num.Columns[0].HeaderText = "Case ID";
                    gvCDRA_Num.Columns[1].HeaderText = "FIR No";
                }
                else
                {
                    gvCDRA_Num.Columns[0].HeaderText = "Project ID";
                    gvCDRA_Num.Columns[1].HeaderText = "Project";
                }

                gvCDRA_Num.Columns[2].HeaderText = "A Party";

                /**
                 * Hiding id column only using for arranging CDRs in 
                 * descending order
                 */
                gvCDRA_Num.Columns[3].Visible = false;

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.FlatStyle = FlatStyle.Popup;
                deleteButton.HeaderText = "Delete";
                deleteButton.Name = "delBtn";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.Text = "Delete";
                deleteButton.Width = 60;
                if (gvCDRA_Num.Columns.Contains(deleteButton.Name = "delBtn"))
                {

                }
                else
                {
                    gvCDRA_Num.Columns.Add(deleteButton);
                }

                // Arranging CDRs A_Num in descending order on the basis
                // of id
                gvCDRA_Num.Sort(this.gvCDRA_Num.Columns["Id"], ListSortDirection.Descending);

            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void gvShowCaseProject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cell_clicked = true;
            if (rbProject.Checked == true && e.RowIndex >= 0)
            {
                projectId = (int)gvShowCaseProject.Rows[e.RowIndex].Cells[0].Value;
                project = gvShowCaseProject.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

            }

            else if (rbGeneralPolice.Checked == true && e.RowIndex >= 0)
            {
                projectId = (int)gvShowCaseProject.Rows[e.RowIndex].Cells[0].Value;
                project = gvShowCaseProject.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            }

            else
            {
                MessageBox.Show("Please select radio button");
            }

            //if cdr is standerize then it save to databank otherwise not
            if (gvStandCDR.Rows.Count > 1)
                saveToDataBank();
        }

        private async void gvCDRA_Num_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.ColumnIndex);
            if (e.RowIndex >= 0 && e.ColumnIndex < 4)
            {
                Common.a_numForAnalysis = gvCDRA_Num.Rows[e.RowIndex].Cells[2].Value.ToString();
                Common.project_Name = gvCDRA_Num.Rows[e.RowIndex].Cells[1].Value.ToString();

                string spGetAllRecords = "exec dbo.GET_ALL_RECORD_A_NUM '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
                DataTable dt = new DataTable();
                dt = await CommonMethods.getRecords(spGetAllRecords);

                Common.allRecordA_Nums = new List<AllRecordA_Num>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AllRecordA_Num allRecordA_Num = new AllRecordA_Num();
                    allRecordA_Num.A_Num = dt.Rows[i][Common.A_Num].ToString();
                    allRecordA_Num.B_Num = dt.Rows[i][Common.B_Num].ToString();
                    allRecordA_Num.IMEI = dt.Rows[i][Common.IMEI].ToString();
                    allRecordA_Num.Date = Convert.ToDateTime(dt.Rows[i][Common.Date]).ToString(Common.datef);
                    allRecordA_Num.Time = dt.Rows[i][Common.Time].ToString();
                    allRecordA_Num.Call_Dur = dt.Rows[i][Common.Call_Dur].ToString();
                    allRecordA_Num.Call_Dir = dt.Rows[i][Common.Call_Dir].ToString();
                    allRecordA_Num.Call_Type = dt.Rows[i][Common.call_Type].ToString();
                    allRecordA_Num.Lac_No = dt.Rows[i][Common.LAC].ToString();
                    allRecordA_Num.Cell_ID = dt.Rows[i][Common.CELLID].ToString();
                    allRecordA_Num.Loc = dt.Rows[i][Common.Loc].ToString();
                    allRecordA_Num.Lat = dt.Rows[i][Common.LAT].ToString();
                    allRecordA_Num.Lng = dt.Rows[i][Common.LNG].ToString();
                    allRecordA_Num.Network = dt.Rows[i][Common.Network].ToString();
                    allRecordA_Num.Weekday = dt.Rows[i][Common.Weekday].ToString();
                    Common.allRecordA_Nums.Add(allRecordA_Num);
                }
                //Common.allRecordA_Nums = Common.allRecordA_Nums.OrderBy(x => x.Date).ToList();
                CommonMethods.messageDialog(Common.a_numForAnalysis + " With " + Common.allRecordA_Nums.Count() + " Records Is Selected For Analysis");
            }
            // columnindex is 3 because column 0 is id which is hidden
            else if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                Common.a_numForAnalysis = gvCDRA_Num.Rows[e.RowIndex].Cells[2].Value.ToString();
                Common.project_Name = gvCDRA_Num.Rows[e.RowIndex].Cells[1].Value.ToString();
                projectId = (int)gvCDRA_Num.Rows[e.RowIndex].Cells[0].Value;
                DialogResult result = MessageBox.Show("Are you confirm to Delete?", "Warning", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bunifuLoader.Visible = true;
                    bool deletionSuccess = await deleteRecordA_Num(Common.a_numForAnalysis, Common.project_Name, projectId);
                    // Create progress reporter
                    this.Invoke(new Action(() =>
                    {
                        // Hide progress bar when records are deleted successfully
                        bunifuLoader.Visible = false;

                        if (deletionSuccess)
                        {
                            MessageBox.Show("Records deleted successfully");
                            getProjectA_Num();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete records");
                        }
                    }));

                    // Call the asynchronous method

                    /*if (deleteNumberRecords(Common.numForAnalysis, Common.project_Name, projectId))
                    {
                        //deleteRecordA_Num(Common.numForAnalysis, Common.project_Name);
                        MessageBox.Show("Record Deleted Successfull.");
                        getProjectNumber();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Delete Records");
                    }*/
                }
                else if (result == DialogResult.No)
                {
                    bunifuLoader.Visible = false;
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rbGeneralPolice.Enabled = false;
            rbProject.Checked = true;

            //this is to load mobile numbers related to projects
            rbProject.PerformClick();
            bunifuElipse.ApplyElipse(btnBrowse, 25);
        }



        private async void rbProject_Click(object sender, EventArgs e)
        {

            string proc = "exec dbo.Projects_View_Filter_UserName '" + Common.userName + "'";
            dataTable = await CommonMethods.getRecords(proc);

            if (dataTable.Rows.Count > 0)
            {
                gvShowCaseProject.DataSource = dataTable;
                gvShowCaseProject.Columns[0].HeaderText = "Project ID";
                /*gvShowCaseProject.Columns[0].Visible = false;*/
                gvShowCaseProject.Columns[1].HeaderText = "Project";

                getProjectA_Num();
            }
            else
            {
                CommonMethods.messageDialog("Please first create project!!");
            }
        }

        private async void rbGeneralPolice_Click(object sender, EventArgs e)
        {

            string proc = "exec dbo.GeneralPoliceTable_View '" + Common.userName + "'";
            dataTable = await CommonMethods.getRecords(proc);

            if (dataTable.Rows.Count > 0)
            {
                gvShowCaseProject.DataSource = dataTable;
                gvShowCaseProject.Columns[0].HeaderText = "Case ID";
                /*gvShowCaseProject.Columns[0].Visible = false;*/
                gvShowCaseProject.Columns[1].HeaderText = "FIR No";

                /*gvShowCaseProject.Columns[2].HeaderText = "Created By";*/
                getProjectA_Num();
            }
            else
            {
                CommonMethods.messageDialog("Please first create case!!");
            }
        }

        private async Task<bool> deleteRecordA_Num(string numToDel, string proName, int proId)
        {
            bool success = false;
            await Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("delete_Selected_Number_Records", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Number", numToDel);
                        cmd.Parameters.AddWithValue("@ProjectId", proId);
                        cmd.Parameters.AddWithValue("@Project", proName);

                        try
                        {
                            if (con.State != ConnectionState.Open)
                                con.Open();

                            int rowsAffected = cmd.ExecuteNonQuery();

                            // If the command executed successfully and rows were affected
                            if (rowsAffected > 0)
                            {
                                success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exception, log error, or throw further if necessary
                            Console.WriteLine("Error executing command: " + ex.Message);
                        }
                    }
                }
            });
            // Report progress
            //progress.Report(success);

            return success;
        }

        public void clearGridView()
        {
            gvCDRA_Num.DataSource = null;
            gvCDRA_Num.Rows.Clear();
            gvCDRA_Num.Columns.Clear();
            gvCDRA_Num.Refresh();
        }


        private void UniqID()
        {
            ////////////////CpuID
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }

            ////////////////HDD ID
            string drive = "C";
            ManagementObject dsk = new ManagementObject(
                @"win32_logicaldisk.deviceid=""" + drive + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();

            Console.WriteLine(volumeSerial + cpuInfo);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CommonMethods.exportExcel(gvStandCDR);
        }

        private string TryParseDateTime(string dateTimeStr)
        {
            var formats = new string[] {
        // 24-hour formats
        "dd-MM-yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss",
        "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy/MM/dd HH:mm:ss",
        "dd.MM.yyyy HH:mm:ss", "MM.dd.yyyy HH:mm:ss", "yyyy.MM.dd HH:mm:ss",
        // 12-hour formats with AM/PM
        "dd-MM-yyyy hh:mm:ss tt", "MM-dd-yyyy hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt",
        "dd/MM/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt", "yyyy/MM/dd hh:mm:ss tt",
        "dd.MM.yyyy hh:mm:ss tt", "MM.dd.yyyy hh:mm:ss tt", "yyyy.MM.dd hh:mm:ss tt",
        "MM/dd/yyyy H:mm", "dd-MM-yyyy H:mm","MM/dd/yyyy HH:mm",
        // Variations with different separators
        "MM-dd-yyyy H:mm",
        "MM-dd-yyyy HH:mm",
        "MM.dd.yyyy H:mm",
        "MM.dd.yyyy HH:mm",
        "MM/dd/yyyy H:mm:ss",
        "MM/dd/yyyy HH:mm:ss",
        "MM-dd-yyyy H:mm:ss",
        "MM-dd-yyyy HH:mm:ss",
        "MM.dd.yyyy H:mm:ss",
        "MM.dd.yyyy HH:mm:ss",
        
        // 12-hour formats with AM/PM
        "MM/dd/yyyy h:mm tt",
        "MM/dd/yyyy hh:mm tt",
        "MM-dd-yyyy h:mm tt",
        "MM-dd-yyyy hh:mm tt",
        "MM.dd.yyyy h:mm tt",
        "MM.dd.yyyy hh:mm tt",

        // Other common formats can be added here
    };

            if (DateTime.TryParseExact(dateTimeStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate.ToString("dd-MM-yyyy h:mm", CultureInfo.InvariantCulture);
            }

            // If parsing fails, return the original string
            return dateTimeStr;
        }


    }
}
