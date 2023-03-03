using ReadExcelApp.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ReadExcelApp.Forms
{
    public partial class SubscriberSearchForm : Form
    {
        DataTable allRecordsdt = new DataTable();
        public SubscriberSearchForm()
        {
            InitializeComponent();
            //btnBrowseSearchFile.Visible = false;
        }

        private void txtMSISDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (isMSISDNValid(txtMSISDN.Text.ToString().Trim()))
                {
                    gvSearchResult.DataSource = null;
                    btnSearch.PerformClick();
                }
        }

        private bool isMSISDNValid(string msisdn)
        {
            bool valid = true;
            if (msisdn == "")
            {
                MessageBox.Show("MSISDN Should not be empty!");
                valid = false;
            }
            if (msisdn.Length < 12 || msisdn.Length > 12)
            {
                MessageBox.Show("Enter a valid number!");
                valid = false;
            }
            if (!msisdn.StartsWith("92"))
            {
                MessageBox.Show("Enter mobile number with 92");
                valid = false;
            }

            return valid;
        }

        private void txtCNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (isCNICValid(txtCNIC.Text.ToString().Trim()))
                {
                    gvSearchResult.DataSource = null;
                    btnSearch.PerformClick();
                }
        }

        private bool isCNICValid(string cnic)
        {
            bool valid = true;
            if (cnic == "")
            {
                MessageBox.Show("CNIC Should not be empty!");
                valid = false;
            }
            if (cnic.Length > 15)
            {
                MessageBox.Show("Enter a valid CNIC number!");
                valid = false;
            }

            return valid;
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            DataTable subInfodt = new DataTable();
            perChart.Series[0].XValueMember = "2020";
            perChart.Series[0].YValueMembers = "2020";

            perChart.Series[1].XValueMember = "2021";
            perChart.Series[1].YValueMembers = "2021";

            perChart.Series[2].XValueMember = "PTCL";
            perChart.Series[2].YValueMembers = "PTCL";

            perChart.Series[3].XValueMember = "DLMS";
            perChart.Series[3].YValueMembers = "DLMS";

            DataTable perdt = new DataTable();

            perdt.Columns.Add("2020", typeof(string));
            perdt.Columns.Add("2021", typeof(string));
            perdt.Columns.Add("PTCL", typeof(string));
            perdt.Columns.Add("DLMS", typeof(string));

            if (allRecordsdt.Rows.Count > 0)
            {
                string subInfo2020 = allRecordsdt.Select("DB = '2020'").Count().ToString();
                string subInfo2021 = allRecordsdt.Select("DB = '2021'").Count().ToString();
                string subPTCL = allRecordsdt.Select("DB = 'PTCL'").Count().ToString();
                string subDLMS = allRecordsdt.Select("DB = 'DLMS'").Count().ToString();

                perdt.Rows.Add(subInfo2020, subInfo2021, subPTCL, subDLMS);
                perChart.DataSource = perdt;
                perChart.DataBind();

                String fileName = "SubInfo ALL";
                using (MemoryStream chartimage = new MemoryStream())
                {
                    perChart.SaveImage(chartimage, ChartImageFormat.Png);
                    iTextSharp.text.Image chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
                    chart_image.ScalePercent(75f);

                    CommonMethods.exportAllImagePDF(allRecordsdt, fileName, chart_image);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.Equals(txtMSISDN.Text.ToString().Trim(), ""))
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(AppConnection.GetSubConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("spmss_getsinglesubinfoall", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@msisdn", txtMSISDN.Text.ToString().Trim());
                            if (con.State != ConnectionState.Open)
                                con.Open();

                            DataTable allRecords = new DataTable();

                            SqlDataReader sdr = cmd.ExecuteReader();

                            allRecords.Load(sdr);

                            if (allRecords.Rows.Count > 0)
                            {
                                DataRow firstRow = allRecords.Rows[0];
                                string cnic = firstRow["CNIC"].ToString();
                                using (SqlCommand cmdd = new SqlCommand("spmss_getsinglesubinfoallcnic", con))
                                {
                                    cmdd.CommandType = CommandType.StoredProcedure;
                                    cmdd.Parameters.AddWithValue("@cnic", cnic);
                                    if (con.State != ConnectionState.Open)
                                        con.Open();

                                    allRecordsdt = new DataTable();

                                    SqlDataReader sdrr = cmdd.ExecuteReader();

                                    allRecordsdt.Load(sdrr);

                                    gvSearchResult.DataSource = allRecordsdt;
                                }
                            }
                            updatesub_search_tm_tbl(txtMSISDN.Text.ToString().Trim());
                            clearTxtBoxes();
                            txtMSISDN.Focus();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (!String.Equals(txtCNIC.Text.ToString().Trim(),""))
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(AppConnection.GetSubConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("spmss_getsinglesubinfoallcnic", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@cnic", txtCNIC.Text.ToString().Trim());
                            if (con.State != ConnectionState.Open)
                                con.Open();

                            allRecordsdt = new DataTable();

                            SqlDataReader sdr = cmd.ExecuteReader();

                            allRecordsdt.Load(sdr);

                            gvSearchResult.DataSource = allRecordsdt;
                            updatesub_search_tm_tbl(txtCNIC.Text.ToString().Trim());
                            clearTxtBoxes();
                            txtCNIC.Focus();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected string AddArrayParameters(string[] array)
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

        private async void btnBrowseSearchFile_Click(object sender, EventArgs e)
        {
            try
            {
                gvSearchResult.DataSource = null;
                gvSearchResult.Rows.Clear();
                gvSearchResult.Columns.Clear();
                gvSearchResult.Refresh();



                DataTable dt = CommonMethods.browseFile();
                List<string> uniqueNumList = dt.AsEnumerable().Select(x => x[0].ToString()).Distinct().ToList();

                
                //subTable.Rows.Add("923026021312");
                //subTable.Rows.Add("923066013004");
                //subTable = dt.Clone();
                //subTable.Rows.Add(uniqueNumList);


                DataTable dtRecords = new DataTable();
                DataTable subdt = new DataTable();
                /*DataColumn dcMSISDN = new DataColumn("MSISDN", typeof(string));
                DataColumn dcNAME = new DataColumn("NAME", typeof(string));
                DataColumn dcCNIC = new DataColumn("CNIC", typeof(string));
                DataColumn dcADDRESS = new DataColumn("ADDRESS", typeof(string));
                DataColumn dcDB = new DataColumn("DB", typeof(string));
                DataColumn dcImage = new DataColumn("imgObject", typeof(byte[]));

                subdt.Columns.Add(dcMSISDN);
                subdt.Columns.Add(dcNAME);
                subdt.Columns.Add(dcCNIC);
                subdt.Columns.Add(dcADDRESS);
                subdt.Columns.Add(dcDB);
                subdt.Columns.Add(dcImage);*/



                //SqlConnection conn = new SqlConnection(AppConnection.GetSubConnectionString());
                //SqlConnection conn2021 = new SqlConnection(Common.sub2021ConnectionString);

                // Open the connection to sql server
                //conn.Open();


                try
                {
                    DataTable subTable = new DataTable();
                    subTable.Columns.Add("MSISDN", typeof(string));
                    foreach (var num in uniqueNumList) {
                        if (num.StartsWith("92"))
                            subTable.Rows.Add(num);
                    }
                    //List<string> uniqueNumList = dt.AsEnumerable().Select(x => x[0].ToString()).Distinct().ToList();

                    //string numParameters = AddArrayParameters(uniqueNumList.ToArray());

                    /* var sql = string.Format(
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' AS [DB] FROM [SubInfo2022].[dbo].[Mob1] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' AS [DB] FROM [SubInfo2022].[dbo].[Mob2] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[TEL_Data_1] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[TEL_Data_2] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[TEL_Data_3] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[TEL_Data_4] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[TEL_Data_5] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[Ufo01] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[Ufo02] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[Ufo03] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, 'N/A' AS [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[Zon01] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "SELECT MSISDN, NAME, CNIC, 'N/A' AS [ADDRESS], '2022' as [DB] FROM [SubInfo2022].[dbo].[Zon02] WHERE MSISDN IN ({0}) " +
                         "UNION ALL " +
                         ""
                         "UNION ALL " +
                         "select MSISDN, NAME, CNIC, [ADDRESS], '2021' as DB from Masterdb2021 where MSISDN IN ({0}) " +
                         "UNION ALL " +
                         "select MSISDN, SubscriberName as [NAME], CNIC, 'N/A' AS [ADDRESS], '2020' as [DB] from Masterdb where MSISDN IN ({0})", numParameters);*/


                    //SqlCommand cmd = new SqlCommand(sql, conn);

                    //cmd.CommandTimeout = 0;
                    /*DataTable dtImage= new DataTable();
                    DataColumn dc = new DataColumn("Image", typeof(byte[]));
                    dtImage.Columns.Add(dc);*/
                    using (SqlConnection con = new SqlConnection(AppConnection.GetSubConnectionString()))
                    {
                        using(SqlCommand cmd  = new SqlCommand("get_subinfo", con))
                        {
                            
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MSISDN", subTable);
                            cmd.CommandTimeout = 0;

                            if (con.State != ConnectionState.Open)
                                con.Open();

                            //cmd.ExecuteNonQuery();
                            SqlDataReader sdr = cmd.ExecuteReader();
                            subdt.Load(sdr);
                            /*foreach (DataColumn col in subdt.Columns) col.ReadOnly = false;
                            foreach (DataRow dr in subdt.Rows)
                            {
                                
                                    
                                    byte[] imageBytes = Encoding.Unicode.GetBytes(dr["imgObject"]);
                                    dr["imgObject"] = imageBytes;
                                if(imageBytes.Length != 6)
                                    dtImage.Rows.Add(imageBytes);
                                    Console.WriteLine(imageBytes.Length);
                                
                            }*/

                        }
                    }


                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(subdt);
                    //DataGridViewImageColumn ic = new DataGridViewImageColumn();
                    //gvSearchResult.Columns.Insert(5, ic);

                    //DataTable distinctTable = subdt.DefaultView.ToTable( /*distinct*/ true);
                    gvSearchResult.DataSource = subdt;
                    /*foreach (var num in uniqueNumList)
                    {
                        string sp = "exec dbo.CDR_Contact_Num '" + num + "'";
                        DataTable dtRecordFound = await CommonMethods.getRecords(sp);
                        dtRecords.Merge(dtRecordFound);

                    }

                    *//*
                     * This code make the datatable unique *
                     *//*

                    //dtRecords = CommonMethods.uniqueDataTable(dtRecords, Common.B_Num);
                    dtRecords = dtRecords.AsEnumerable()
                     .GroupBy(x => new
                     {
                         Lat = x.Field<string>(Common.A_Num),
                         Lng = x.Field<string>(Common.B_Num)
                     })
                     .Select(x => x.First()).CopyToDataTable();
                    gvSearchResult.DataSource = dtRecords;*/

                }
                catch (Exception ex)
                {
                    CommonMethods.messageDialog(ex.Message);
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        private void clearTxtBoxes()
        {
            txtMSISDN.Clear();
            txtCNIC.Clear();

        }

        private void updatesub_search_tm_tbl(string searched_value)
        {
            string proc = "exec dbo.[proc_sub_search_tm_tbl] '" + Common.userName + "','" + searched_value + "'";
            CommonMethods.insertRecords(proc);
        }
    }
}
