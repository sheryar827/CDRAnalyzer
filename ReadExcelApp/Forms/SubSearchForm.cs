using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;    
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class SubSearchForm : Form
    {
        DataTable dlmsdt;
        public SubSearchForm()
        {
            InitializeComponent();
            btnBrowseSearchFile.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtMSISDN.Text != "" && txtMSISDN.Text.Trim().Length == 12)
            {
                if (txtMSISDN.Text.Trim().StartsWith("92"))
                {
                    //getSubDataListOnMSISDN(txtMSISDN.Text.Trim());
                    getSubDataList(txtMSISDN.Text.Trim(), "");
                    txtMSISDN.Text = "";
                }
                else
                {
                    CommonMethods.messageDialog("Please, enter mobile number with 92");
                }
            }
            else if (txtCNIC.Text != "")
            {
                Regex rgx = new Regex("[^A-Za-z0-9]");
                bool hasSpecialChars = rgx.IsMatch(txtCNIC.Text.Trim().ToString());
                if (!hasSpecialChars)
                {
                    getSubDataList("", txtCNIC.Text.Trim());
                    txtCNIC.Text = "";
                }
                else
                {
                    CommonMethods.messageDialog("Please, remove special character or enter valid CNIC");
                }
            }
            else
            {
                CommonMethods.messageDialog("Please Enter Correct Value");
            }
        }

        private void getSubDataList(string msisdn, string cnic)
        {
            string subQry = null;
            string sub2021Qry = null;
            string searched_value = null;
            DataTable subdt = new DataTable();
            /*DataTable subdt2021 = new DataTable();*/
            try
            {


                SqlConnection conn = new SqlConnection(AppConnection.GetSubConnectionString());
                //SqlConnection conn2021 = new SqlConnection(Common.sub2021ConnectionString);

                // Open the connection to sql server
                conn.Open();
                //conn2021.Open();

                if (msisdn.Equals(""))
                {
                    subQry = "exec [dbo].[spmss_getsinglesubinfo] '" + txtCNIC.Text.Trim() + "'";
                    //subQry = "select MSISDN, CNIC, NAME, ADDRESS from Masterdb2021 where CNIC = '" + cnic + "'";
                    //sub2021Qry = "select number, cnic, name from Customer_Data_July2021 where CNIC = '" + cnic + "'";
                    searched_value = cnic;
                }
                else
                {
                    subQry = "exec [dbo].[spmss_getsinglesubinfoagainstmsisdn] '" + txtMSISDN.Text.Trim() + "'";
                    //subQry = "select MSISDN, CNIC, NAME, ADDRESS from Masterdb2021 where MSISDN = '" + msisdn + "'";
                    //sub2021Qry = "select number, cnic, name from Customer_Data_July2021 where number = '" + msisdn + "'";
                    searched_value = msisdn;
                }

                // executing the command
                SqlCommand Comm = new SqlCommand(subQry, conn);
                Comm.CommandTimeout = 0;


                SqlDataAdapter da = new SqlDataAdapter(Comm);
                da.Fill(subdt);
                // executing the command
                /*SqlCommand Comm2021 = new SqlCommand(sub2021Qry, conn2021);
                Comm2021.CommandTimeout = 0;


                SqlDataAdapter da2021 = new SqlDataAdapter(Comm2021);
                da2021.Fill(subdt2021);
                conn.Close();
                conn2021.Close();

                subdt.Merge(subdt2021);*/

                //gvSearchResult.DataSource = getDLMSdata(txtCNIC.Text.Trim(), txtMSISDN.Text.Trim());
                //dlmsdt = getDLMSdata(txtCNIC.Text.Trim(), txtMSISDN.Text.Trim());

                if(subdt.Rows.Count > 0 && !msisdn.Equals(""))
                {
                    DataRow row = subdt.Rows[0];
                    dlmsdt = getDLMSdata(row["CNIC"].ToString(), txtMSISDN.Text.Trim());
                    
                    subQry = "exec [dbo].[spmss_getsinglesubinfo] '" + row["CNIC"] + "'";
                    // executing the command
                    Comm = new SqlCommand(subQry, conn);
                    Comm.CommandTimeout = 0;


                    da = new SqlDataAdapter(Comm);
                    subdt = new DataTable();
                    da.Fill(subdt);

                    if (dlmsdt != null)
                    {
                        //row = dlmsdt.Rows[0];
                        //var dlimage = ConvertToImage((byte[])row["imgObject"]);
                        //personImg.Image = dlimage;
                        foreach (DataRow dr in subdt.Rows)
                        {
                            dlmsdt.Rows.Add(dr.Field<string>("MSISDN")
                                , dr.Field<string>("SubscriberName")
                                , dr.Field<string>("CNIC")
                                , dr.Field<string>("DB")
                                , dr.Field<string>("ADDR"));
                        }
                        gvSearchResult.DataSource = dlmsdt;
                    }
                    else
                    {
                        gvSearchResult.DataSource = subdt;
                    }
                    updatesub_search_tm_tbl(searched_value);
                }
                else if (subdt.Rows.Count > 0)
                {
                    DataRow row = subdt.Rows[0];
                    dlmsdt = getDLMSdata(row["CNIC"].ToString(), txtMSISDN.Text.Trim());
                    if (dlmsdt != null)
                    {
                        //DataRow row = dlmsdt.Rows[0];
                        //var dlimage = ConvertToImage((byte[])row["imgObject"]);
                        //personImg.Image = dlimage;
                        foreach (DataRow dr in subdt.Rows)
                        {
                            dlmsdt.Rows.Add(dr.Field<string>("MSISDN")
                                , dr.Field<string>("SubscriberName")
                                , dr.Field<string>("CNIC")
                                , dr.Field<string>("DB")
                                , dr.Field<string>("ADDR"));
                        }
                        gvSearchResult.DataSource = dlmsdt;
                    }
                    else
                    {
                        gvSearchResult.DataSource = subdt;
                    }
                    
                    updatesub_search_tm_tbl(searched_value);
                }
                else
                {
                    CommonMethods.messageDialog("No Record Found");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void updatesub_search_tm_tbl(string searched_value)
        {
            string proc = "exec dbo.[proc_sub_search_tm_tbl] '" + Common.userName + "','" + searched_value + "'";
            CommonMethods.insertRecords(proc);

        }

        private void txtMSISDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //when enter is press button search is click
                btnSearch.PerformClick();
            }
        }

        private void txtCNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //when enter is press button search is click
                btnSearch.PerformClick();
            }
        }

        /// <summary>
        /// This will add an array of parameters to a SqlCommand. This is used for an IN statement.
        /// Use the returned value for the IN part of your SQL call. (i.e. SELECT * FROM table WHERE field IN (returnValue))
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand object to add parameters to.</param>
        /// <param name="array">The array of strings that need to be added as parameters.</param>
        /// <param name="paramName">What the parameter should be named.</param>
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
                DataTable dtRecords = new DataTable();
                DataTable subdt = new DataTable();


                SqlConnection conn = new SqlConnection(AppConnection.GetSubConnectionString());
                //SqlConnection conn2021 = new SqlConnection(Common.sub2021ConnectionString);

                // Open the connection to sql server
                conn.Open();


                try
                {
                    List<string> uniqueNumList = dt.AsEnumerable().Select(x => x[0].ToString()).Distinct().ToList();

                    string numParameters = AddArrayParameters(uniqueNumList.ToArray());
                        var sql = string.Format("select MSISDN, Name, CNIC, '2021' as DB from Masterdb2021 where MSISDN IN ({0}) " +
                            "UNION ALL " +
                            "select MSISDN, SubscriberName, CNIC, '2020' as DB from Masterdb where MSISDN IN ({0})", numParameters);


                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandTimeout = 0;


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(subdt);
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //CommonMethods.exportExcel(gvSearchResult);
            string fileName = "Sub info";
            if (dlmsdt != null)
            {
                DataRow row = dlmsdt.Rows[0];
                CommonMethods.exportImagePDF(gvSearchResult, fileName, ConvertToImage((byte[])row["imgObject"]));
            }
            else
            {
                CommonMethods.exportPDF(gvSearchResult, fileName);
            }
        }

        private DataTable getDLMSdata(string cnic, string msisdn)
        {
            string dlmsQry = null;
            DataTable dlmsdt = new DataTable();

            try
            {
                SqlConnection conn = new SqlConnection(AppConnection.GetDLMSConnectionString());
                //SqlConnection conn2021 = new SqlConnection(Common.sub2021ConnectionString);

                // Open the connection to sql server
                conn.Open();
                //conn2021.Open();

                dlmsQry = "exec [dbo].[dlms_sp_personsearch] '" + cnic + "', '" + msisdn + "'";
                //subQry = "select MSISDN, CNIC, NAME, ADDRESS from Masterdb2021 where MSISDN = '" + msisdn + "'";
                //sub2021Qry = "select number, cnic, name from Customer_Data_July2021 where number = '" + msisdn + "'";
                //searched_value = msisdn;

                // executing the command
                SqlCommand Comm = new SqlCommand(dlmsQry, conn);
                Comm.CommandTimeout = 0;


                SqlDataAdapter da = new SqlDataAdapter(Comm);
                da.Fill(dlmsdt);

                // executing the command
                /*SqlCommand Comm2021 = new SqlCommand(sub2021Qry, conn2021);
                Comm2021.CommandTimeout = 0;


                SqlDataAdapter da2021 = new SqlDataAdapter(Comm2021);
                da2021.Fill(subdt2021);
                conn.Close();
                conn2021.Close();

                subdt.Merge(subdt2021);*/

                if (dlmsdt.Rows.Count > 0)
                {
                    return dlmsdt;
                    //gvSearchResult.DataSource = dlmsdt;
                    //updatesub_search_tm_tbl(searched_value);
                    //subdt.Rows.Add(dlmsdt.Rows[0][0], dlmsdt.Rows[0][1], dlmsdt.Rows[0][2], dlmsdt.Rows[0][3]);

                }
                else
                {
                    CommonMethods.messageDialog("No Record Found");
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }

            return null;
        }

        // converting varbinary image to itextsharp image to display in pdf
        private iTextSharp.text.Image ConvertToImage(byte[] iBinary)
        {
            /*var arrayBinary = iBinary.ToArray();
            Image rImage = null;

            using (MemoryStream ms = new MemoryStream(arrayBinary))
            {
                rImage = Image.FromStream(ms);
            }*/
            return iTextSharp.text.Image.GetInstance(iBinary, false);
        }
    }


}
