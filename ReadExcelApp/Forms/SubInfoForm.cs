using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class SubInfoForm : Form
    {
        public SubInfoForm()
        {
            InitializeComponent();
        }

        private void Search_Click(string searchQry)
        {
            GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(searchQry);
            SqlDataReader dr = getSqlDRAndConn.sqlDR;
            if (dr.HasRows)
            {
                // Create list with non-unique values
                List<SubInfo> subinfo = new List<SubInfo>();

                while (dr.Read())
                {
                    string Mobile = dr["Mobile"].ToString();
                    string Name = dr["Name"].ToString();
                    string CNIC = dr["CNIC"].ToString();
                    string Address = dr["Address"].ToString();

                    SubInfo sub = new SubInfo(Mobile, Name, CNIC, Address);
                    subinfo.Add(sub);
                }

                gvSearchResult.DataSource = subinfo;
                txtAParty.Text = "";
                txtBParty.Text = "";
            }

            dr.Close();
            getSqlDRAndConn.sqlConn.Close();


        }

        private void SubInfoForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cDRAnalyzerDataSet.Subs' table. You can move, or remove it, as needed.
            //this.subsTableAdapter.Fill(this.cDRAnalyzerDataSet.Subs);

        }

        private void tbMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchdata = txtAParty.Text.Trim().ToString();
                if (searchdata.Length > 10)
                    searchdata = searchdata.Substring(searchdata.Length - 10);

                string searchQry = "select * from Ufone where Mobile = '" + searchdata + "'";
                Search_Click(searchQry);

            }
        }

        private void tbCnicNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchdata = txtBParty.Text.Trim().ToString();
                string searchQry = "select * from Ufone where CNIC = '" + searchdata + "'";
                Search_Click(searchQry);
            }
        }

        private async void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSearchResult.DataSource = null;
            gvSearchResult.Rows.Clear();
            gvSearchResult.Columns.Clear();
            gvSearchResult.Refresh();
            try
            {
                switch (cbSearch.SelectedItem.ToString())
                {
                    case Common.A_Party:
                        if (txtAParty.Text != "")
                        {
                            string sp = "exec dbo.CDR_Contact_Num '" + txtAParty.Text.Trim().ToString() + "'";
                            DataTable dt = await CommonMethods.getRecords(sp);
                            gvSearchResult.DataSource = CommonMethods.uniqueDataTable(dt, Common.A_Num);
                            txtAParty.Clear();
                        }
                        break;
                    case Common.B_Party:
                        if (txtBParty.Text != "")
                        {

                            string sp = "exec dbo.CDR_Contact_Num '" + txtBParty.Text.Trim().ToString() + "'";
                            DataTable dt = await CommonMethods.getRecords(sp);
                            gvSearchResult.DataSource = CommonMethods.uniqueDataTable(dt, Common.B_Num); ;
                            txtBParty.Clear();
                        }
                        break;
                    case Common.IMEI:
                        if (txtIMEI.Text != "")
                        {
                            string sp = "exec dbo.CDR_IMEI '" + txtIMEI.Text.Trim().ToString() + "'";
                            DataTable dt = await CommonMethods.getRecords(sp);
                            gvSearchResult.DataSource = CommonMethods.uniqueDataTable(dt, Common.IMEI);
                            txtIMEI.Clear();
                        }
                        break;
                    case Common.LAC_CELLID:
                        if (txtLac.Text != "" && txtCellID.Text != "")
                        {
                            string sp = "exec dbo.CDR_LAC_CellID '" + txtLac.Text.Trim().ToString() + "', '" + txtCellID.Text.Trim().ToString() + "'";
                            DataTable dt = await CommonMethods.getRecords(sp);
                            gvSearchResult.DataSource = dt;
                            txtLac.Clear();
                            txtCellID.Clear();
                        }
                        break;

                    case Common.LAT_LNG:
                        if (txtLat.Text != "" && txtLng.Text != "")
                        {
                            string sp = "exec dbo.CDR_LAT_LNG '" + txtLat.Text.Trim().ToString() + "', '" + txtLng.Text.Trim().ToString() + "'";
                            DataTable dt = await CommonMethods.getRecords(sp);
                            gvSearchResult.DataSource = dt;
                            txtLat.Clear();
                            txtLng.Clear();
                        }
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



                switch (dt.Columns[0].ColumnName)
                {
                    case Common.Cont_Num:
                        try
                        {
                            List<string> uniqueNumList = dt.AsEnumerable().Select(x => x[0].ToString()).Distinct().ToList();
                            foreach (var num in uniqueNumList)
                            {
                                string sp = "exec dbo.CDR_Contact_Num '" + num + "'";
                                DataTable dtRecordFound = await CommonMethods.getRecords(sp);
                                dtRecords.Merge(dtRecordFound);

                            }

                            /*
                             * This code make the datatable unique *
                             */

                            //dtRecords = CommonMethods.uniqueDataTable(dtRecords, Common.B_Num);
                            dtRecords = dtRecords.AsEnumerable()
                             .GroupBy(x => new
                             {
                                 Lat = x.Field<string>(Common.A_Num),
                                 Lng = x.Field<string>(Common.B_Num)
                             })
                             .Select(x => x.First()).CopyToDataTable();
                            gvSearchResult.DataSource = dtRecords;

                        }
                        catch (Exception ex)
                        {
                            CommonMethods.messageDialog(ex.Message);
                        }

                        break;
                    case Common.IMEI:
                        try
                        {
                            List<string> uniqueIMEIList = dt.AsEnumerable().Select(x => x[0].ToString()).Distinct().ToList();
                            foreach (var imei in uniqueIMEIList)
                            {
                                string sp = "exec dbo.CDR_IMEI '" + imei + "'";
                                DataTable dtRecordFound = await CommonMethods.getRecords(sp);
                                dtRecords.Merge(dtRecordFound);
                            }

                            /*
                             * This code make the datatable unique *
                             */

                            dtRecords = CommonMethods.uniqueDataTable(dtRecords, Common.IMEI);
                            gvSearchResult.DataSource = dtRecords;
                        }
                        catch (Exception ex)
                        {
                            CommonMethods.messageDialog(ex.Message);
                        }
                        break;
                    case Common.LAC:
                        try
                        {
                            /*
                            * This code make the List unique on the basis of Lac_No and Cell_ID *
                            */

                            var uniqueLacCellIDList = dt.AsEnumerable().GroupBy(x => new
                            {
                                Lac = Convert.ToString(x[0]),
                                CellID = Convert.ToString(x[1])
                            }).Select(x => x.First()).ToList();

                            foreach (var LacCellID in uniqueLacCellIDList)
                            {
                                string sp = "exec dbo.CDR_LAC_CellID '" + LacCellID.Field<Double>(Common.LAC) + "', '" + LacCellID.Field<Double>(Common.CELLID) + "'";
                                DataTable dtRecordFound = await CommonMethods.getRecords(sp);
                                dtRecords.Merge(dtRecordFound);
                            }


                            /*
                            * This code make the List unique on the basis of Lac_No and Cell_ID *
                            */

                            dtRecords = dtRecords.AsEnumerable()
                             .GroupBy(x => new
                             {
                                 Lac = x.Field<string>(Common.LAC),
                                 CellID = x.Field<string>(Common.CELLID)
                             })
                             .Select(x => x.First()).CopyToDataTable();
                            gvSearchResult.DataSource = dtRecords;

                        }
                        catch (Exception ex)
                        {
                            CommonMethods.messageDialog(ex.Message);
                        }
                        break;

                    case Common.LAT:
                        try
                        {
                            /*
                            * This code make the List unique on the basis of LAT and LNG *
                            */

                            var uniqueLatLngList = dt.AsEnumerable().GroupBy(x => new
                            {
                                Lat = x.Field<Double>(Common.LAT),
                                Lng = x.Field<Double>(Common.LNG)
                            }).Select(x => x.First()).ToList();



                            foreach (var LatLng in uniqueLatLngList)
                            {
                                string sp = "exec dbo.CDR_LAT_LNG '" + Convert.ToString(LatLng.Field<Double>(Common.LAT)) + "', '" + Convert.ToString(LatLng.Field<Double>(Common.LNG)) + "'";
                                DataTable dtRecordFound = await CommonMethods.getRecords(sp);
                                dtRecords.Merge(dtRecordFound);
                            }


                            /*
                            * This code make the List unique on the basis of LAT and LNG *
                            */

                            dtRecords = dtRecords.AsEnumerable()
                             .GroupBy(x => new
                             {
                                 Lat = x.Field<string>(Common.LAT),
                                 Lng = x.Field<string>(Common.LNG)
                             })
                             .Select(x => x.First()).CopyToDataTable();
                            gvSearchResult.DataSource = dtRecords;
                        }
                        catch (Exception ex)
                        {
                            CommonMethods.messageDialog(ex.Message);
                        }
                        break;
                    default:
                        CommonMethods.messageDialog("Please select valid sheet or check sheet columns");
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }
    }
}
