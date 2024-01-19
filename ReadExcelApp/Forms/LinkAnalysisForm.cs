using Microsoft.Msagl.Drawing;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class LinkAnalysisForm : Form
    {
        List<AllRecordA_Num> allRecordsA_Num = new List<AllRecordA_Num>();
        public LinkAnalysisForm()
        {
            InitializeComponent();
        }

        private async void getProjectA_Num()
        {

            string proc = "exec dbo.Projects_View";
            DataTable dataTable = await CommonMethods.getRecords(proc);

            try
            {
                DataTable allRecord = new DataTable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // Stored Procedure only getting project table records not general police table records
                    string proce = "exec dbo.ProjectsTableA_Num_View '" + Common.userName + "', '" + dataTable.Rows[i].Field<int>("projectId") + "', '" + dataTable.Rows[i].Field<string>("project") + "'";
                    allRecord.Merge(await CommonMethods.getRecords(proce));
                }


                gvCaseProjectA_Num.DataSource = allRecord;
                gvCaseProjectA_Num.Columns[0].HeaderText = "Project";
                gvCaseProjectA_Num.Columns[1].HeaderText = "A Party";

                // Hiding id column only using for arranging CDRs in
                // descending order
                gvCaseProjectA_Num.Columns[2].Visible = false;

                // Arranging CDRs A_Num in descending order on the basis
                // of id
                gvCaseProjectA_Num.Sort(this.gvCaseProjectA_Num.Columns["Id"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
            /*string getGeneralPoliceQry = "select * from ProjectsTableA_Num";
            GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(getGeneralPoliceQry);
            SqlDataReader drGeneralPolice = getSqlDRAndConn.sqlDR;
            List<GetA_Num> gplst = new List<GetA_Num>();
            if (drGeneralPolice.HasRows)
            {

                while (drGeneralPolice.Read())
                {
                    GetA_Num gp = new GetA_Num(Convert.ToInt32(drGeneralPolice["project_ID"]), drGeneralPolice["A_Num"].ToString());
                    gplst.Add(gp);
                }

                drGeneralPolice.Close();
                getSqlDRAndConn.sqlConn.Close();*/
            // }

            //gvCaseProjectA_Num.DataSource = gplst;
        }

        private async void getGeneralPoliceA_Num()
        {
            string proc = "exec dbo.GeneralPoliceTable_View '"+Common.userName+"'";
            DataTable dataTable = await CommonMethods.getRecords(proc);

            try
            {
                DataTable allRecord = new DataTable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // Stored Procedure only getting project table records not general police table records
                    string proce = "exec dbo.ProjectsTableA_Num_View '" + Common.userName + "', '" + dataTable.Rows[i].Field<int>("projectId") + "', '" + dataTable.Rows[i].Field<string>("project") + "'";
                    allRecord.Merge(await CommonMethods.getRecords(proce));
                }


                gvCaseProjectA_Num.DataSource = allRecord;
                gvCaseProjectA_Num.Columns[0].HeaderText = "Project";
                gvCaseProjectA_Num.Columns[1].HeaderText = "A Party";
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
            /*string getGeneralPoliceQry = "select * from GeneralPoliceTableA_Num";
            GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(getGeneralPoliceQry);
            SqlDataReader drGeneralPolice = getSqlDRAndConn.sqlDR;
            List<GetA_Num> gplst = new List<GetA_Num>();
            if (drGeneralPolice.HasRows)
            {

                while (drGeneralPolice.Read())
                {
                    GetA_Num gp = new GetA_Num(Convert.ToInt32(drGeneralPolice["Case_ID"]), drGeneralPolice["A_Num"].ToString());
                    gplst.Add(gp);
                }
            }

            drGeneralPolice.Close();
            getSqlDRAndConn.sqlConn.Close();

            gvCaseProjectA_Num.DataSource = gplst;*/
        }

        private async void gvCaseProjectA_Num_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int found = lbCaseProjectA_Num.FindStringExact(gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString());
            if (found < 0)
            {
                lbCaseProjectA_Num.Items.Add(gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString());
                string a_numForAnalysis = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString();
                string project_Name = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[0].Value.ToString();
                string spGetAllRecords = "exec dbo.GET_ALL_RECORD_A_NUM '" + a_numForAnalysis + "', '" + project_Name + "'";
                DataTable dt = new DataTable();
                dt = await CommonMethods.getRecords(spGetAllRecords);

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

                    allRecordsA_Num.Add(allRecordA_Num);
                }
            }

            //Console.WriteLine($"{allRecordsA_Num.Count}");
        }

        /*private void commonB_Num()
        {
            gvCDRA_Num.DataSource = null;
            gvCDRA_Num.Rows.Clear();
            gvCDRA_Num.Columns.Clear();
            gvCDRA_Num.Refresh();
            List<string> compB_Numlst = new List<string>();
            List<string> b_numC = new List<string>();
            //gvCDRA_Num.Columns.Add("B_Num", "B_Num");
            foreach (var item in lbCaseProjectA_Num.Items)
            {

                string getB_NumQry = "select B_Num from CDR_DB_Tbl where A_Num = '" + item + "'";
                GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(getB_NumQry);
                SqlDataReader drB_Num = getSqlDRAndConn.sqlDR;

                List<string> b_numlst = new List<string>();

                if (drB_Num.HasRows)
                {

                    while (drB_Num.Read())
                    {
                        string b_num = drB_Num["B_Num"].ToString();
                        b_numlst.Add(b_num);
                    }

                    List<string> uniqueB_Numlst = b_numlst.Distinct().ToList();
                    compB_Numlst.AddRange(uniqueB_Numlst);
                }

                drB_Num.Close();
                getSqlDRAndConn.sqlConn.Close();

                //gvCDRA_Num.Columns.Add(item.ToString(), item.ToString());
            }

            //Getting common numbers from b parties of A_Num selected
            IEnumerable<String> duplicates = compB_Numlst.GroupBy(x => x)
                                        .SelectMany(g => g.Skip(1));

            *//*List<B_NumCount> b_numCount = new List<B_NumCount>();*/
            /*foreach (string b_num in duplicates.Distinct().ToList())
            {
                gvCDRA_Num.Rows.Add("");
            }*//*

            int count = 0;
            foreach (string b_num in duplicates.Distinct().ToList())
            {

                //gvCDRA_Num.Rows[count].Cells[0].Value = b_num;

                foreach (var item in lbCaseProjectA_Num.Items)
                {
                    string getB_NumQry = "select Count(*) from CDR_DB_Tbl where A_Num = '" + item.ToString() + "' and B_Num = '" + b_num + "'";
                    string bnc = CommonMethods.getCount(getB_NumQry).ToString();
                    if (CommonMethods.getCount(getB_NumQry) > 0)
                    {
                        *//*if(gvCDRA_Num.Columns.Count == 0){
                            //gvCDRA_Num.Columns.Add("B_Num", "B_Num");
                            //gvCDRA_Num.Rows.Add("");
                        }
                        else
                        {
                            //gvCDRA_Num.Columns.Add(item.ToString(), item.ToString());
                            //gvCDRA_Num.Rows.Add("");
                            //int colIndex = gvCDRA_Num.Columns[item.ToString()].Index;
                            //gvCDRA_Num.Rows[count].Cells[0].Value = b_num;
                            //gvCDRA_Num.Rows[count].Cells[colIndex].Value = bnc;
                        }*//*
                        //gvCDRA_Num.Rows[count].Cells[i].Value = bnc;
                    }

                    *//*else
                        gvCDRA_Num.Columns.RemoveAt(i);*//*
                }
                count += 1;

            }

        }*/

        private void btnCommonB_Num_Click(object sender, EventArgs e)
        {
            gvCDRA_Num.DataSource = null;
            gvCDRA_Num.Rows.Clear();
            gvCDRA_Num.Columns.Clear();
            gvCDRA_Num.Refresh();
            List<String> compB_Numlst = new List<string>();
            List<String> b_numC = new List<string>();
            gvCDRA_Num.Columns.Add("B_Num", "B_Num");

            Dictionary<string, HashSet<string>> dictionaryA_Num = new Dictionary<string, HashSet<string>>();

            foreach (var item in lbCaseProjectA_Num.Items)
            {
                /*string getB_NumQry = "select B_Num from CDR_DB_Tbl where A_Num = '" + item + "'";
                GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(getB_NumQry);
                SqlDataReader drB_Num = getSqlDRAndConn.sqlDR;

                List<String> b_numlst = new List<String>();

                if (drB_Num.HasRows)
                {

                    while (drB_Num.Read())
                    {
                        String b_num = drB_Num["B_Num"].ToString();
                        b_numlst.Add(b_num);
                    }

                    List<string> uniqueB_Numlst = b_numlst.Distinct().ToList();
                    compB_Numlst.AddRange(uniqueB_Numlst);
                }

                drB_Num.Close();
                getSqlDRAndConn.sqlConn.Close();*/

                /*List<string> b_numlst = new List<string>();
                b_numlst = allRecordsA_Num
                    .AsEnumerable()
                    .Where(a=>a.A_Num.Equals(item))
                    .Select(x => x.B_Num)
                    //.Where(bp => bp.Substring(0, 2).Equals("92") && bp.Length == 12)
                    .ToList();*/

                List<string> b_numlst = allRecordsA_Num
                                        .Where(a => a.A_Num.Equals(item) && a.B_Num.StartsWith("92"))
                                        .Select(x => x.B_Num)
                                        .ToList();

                List<string> uniqueB_Numlst = b_numlst
                    .Distinct()
                    //.Where(bp => bp.Substring(0, 2).Equals("92") && bp.Length == 12)
                    .ToList();


                compB_Numlst.AddRange(uniqueB_Numlst);

                //A_Num as key and B_Num list as values
                dictionaryA_Num.Add(item.ToString(), b_numlst.ToHashSet());

                //A_Num as key and B_Num list as values
                //dictionaryA_Num.Add(item.ToString(), b_numlst.ToHashSet());

                //gvCDRA_Num.Columns.Add(item.ToString(), item.ToString());
            }

            var result = new Dictionary<string, List<string>>();
            foreach (var kvp in dictionaryA_Num)
            {
                // kvp.Key is the key ("a", "b", etc)
                // kvp.Value is the list of values ("Red", "Yellow", etc)

                // Loop through each of the values
                foreach (var value in kvp.Value)
                {
                    // See if our results dictionary already has an entry for this
                    // value. If so, grab the corresponding list of keys. If not,
                    // create a new list of keys and insert it.
                    if (!result.TryGetValue(value, out var list))
                    {
                        list = new List<string>();
                        result.Add(value, list);
                    }

                    // Add our key to this list of keys
                    list.Add(kvp.Key);
                }
            }

            result = result.Where(x => x.Value.Count > 1).ToDictionary(x => x.Key, x => x.Value);


            HashSet<string> commonA_Num = new HashSet<string>();

            foreach (var kvp in result)
            {
                foreach (var value in kvp.Value)
                {
                    if (!commonA_Num.TryGetValue(value, out var list))
                        commonA_Num.Add(value);
                }
            }

            foreach (var canum in commonA_Num)
            {
                gvCDRA_Num.Columns.Add(canum, canum);
            }


            //Getting common numbers from b parties of A_Num selected
            IEnumerable<String> duplicates = compB_Numlst.GroupBy(x => x)
                                        .SelectMany(g => g.Skip(1));


            int count = 0;
            Graph graph = new Graph("graph");
            foreach (string b_num in duplicates.Distinct().ToList())
            {
                gvCDRA_Num.Rows.Add("");
                gvCDRA_Num.Rows[count].Cells[0].Value = b_num;

                for (int i = 1; i < gvCDRA_Num.ColumnCount; i++)
                {
                    //string getB_NumQry = "select Count(*) from CDR_DB_Tbl where A_Num = '" + gvCDRA_Num.Columns[i].HeaderText.ToString() + "' and B_Num = '" + b_num + "'";
                    //string bnc = CommonMethods.getCount(getB_NumQry).ToString();
                    string bnc = CountMatchingRecords(allRecordsA_Num, gvCDRA_Num.Columns[i].HeaderText, b_num).ToString();
                    gvCDRA_Num.Rows[count].Cells[i].Value = bnc;
                    Edge edge = graph.AddEdge(b_num, gvCDRA_Num.Columns[i].HeaderText.ToString());
                    edge.LabelText = bnc;
                    //edge.Label.FontColor = Color.Green;
                    graph.FindNode(gvCDRA_Num.Columns[i].HeaderText.ToString()).Attr.FillColor = Color.PaleGreen;
                }
                count += 1;
            }

            graph.LayoutAlgorithmSettings = new Microsoft.Msagl.Layout.MDS.MdsLayoutSettings();
            gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;

            gViewer.Graph = graph;
            //SuspendLayout();
            //ResumeLayout();


            /*lbCaseProjectA_Num.DataSource = duplicates.Distinct().ToList();*/

        }

        private static int CountMatchingRecords(List<AllRecordA_Num> records, string aNum, string bNum)
        {
            return records.Count(record => record.A_Num == aNum && record.B_Num == bNum);
        }

        private void btnComIMEI_Click(object sender, EventArgs e)
        {
            gvCDRA_Num.DataSource = null;
            gvCDRA_Num.Rows.Clear();
            gvCDRA_Num.Columns.Clear();
            gvCDRA_Num.Refresh();
            List<String> compIMEIlst = new List<string>();
            DataTable dt = new DataTable();
            List<String> b_numC = new List<string>();
            Dictionary<string, HashSet<string>> dictionaryIMEI = new Dictionary<string, HashSet<string>>();
            gvCDRA_Num.Columns.Add("IMEI", "IMEI");
            /*foreach (var item in lbCaseProjectA_Num.Items)
            {
                string getIMEIQry = "select IMEI from CDR_DB_Tbl where A_Num = '" + item + "'";
                GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(getIMEIQry);
                SqlDataReader drB_Num = getSqlDRAndConn.sqlDR;

                List<String> imeilst = new List<String>();

                if (drB_Num.HasRows)
                {

                    while (drB_Num.Read())
                    {
                        String b_num = drB_Num["IMEI"].ToString();
                        imeilst.Add(b_num);
                    }

                    List<string> uniqueIMEIlst = imeilst.Distinct().ToList();
                    compIMEIlst.AddRange(uniqueIMEIlst);
                }

                drB_Num.Close();
                getSqlDRAndConn.sqlConn.Close();
                dictionaryIMEI.Add(item.ToString(), imeilst.ToHashSet());
                //gvCDRA_Num.Columns.Add(item.ToString(), item.ToString());
            }*/



            foreach (var item in lbCaseProjectA_Num.Items)
            {
                // Extract IMEI values for the specific A_Num
                List<string> imeiList = allRecordsA_Num
                .Where(record => record.A_Num == item.ToString())
                .Select(record => record.IMEI)
                .ToList();

                List<string> uniqueIMEIlst = imeiList.Distinct().ToList();
                dictionaryIMEI.Add(item.ToString(), uniqueIMEIlst.ToHashSet());
                compIMEIlst.AddRange(uniqueIMEIlst);
                //gvCDRA_Num.Columns.Add(item.ToString(), item.ToString());
            }

            // Print the contents of the dictionary
            /*foreach (var kvp in dictionaryIMEI)
            {
                Console.WriteLine($"Key: {kvp.Key}, IMEIs: [{string.Join(", ", kvp.Value)}]");
            }*/

            var result = new Dictionary<string, List<string>>();

            foreach (var kvp in dictionaryIMEI)
            {
                // kvp.Key is the key ("a", "b", etc)
                // kvp.Value is the list of values ("Red", "Yellow", etc)

                // Loop through each of the values
                foreach (var value in kvp.Value)
                {
                    // See if our results dictionary already has an entry for this
                    // value. If so, grab the corresponding list of keys. If not,
                    // create a new list of keys and insert it.
                    if (!result.TryGetValue(value, out var list))
                    {
                        list = new List<string>();
                        result.Add(value, list);
                    }

                    // Add our key to this list of keys
                    list.Add(kvp.Key);
                }
            }

            result = result.Where(x => x.Value.Count > 1).ToDictionary(x => x.Key, x => x.Value);

            HashSet<string> commonIMEI = new HashSet<string>();

            foreach (var kvp in result)
            {
                foreach (var value in kvp.Value)
                {
                    if (!commonIMEI.TryGetValue(value, out var list))
                        commonIMEI.Add(value);
                }
            }


            foreach (var cimei in commonIMEI)
            {
                gvCDRA_Num.Columns.Add(cimei, cimei);
            }

            //Getting common numbers from b parties of A_Num selected
            IEnumerable<String> duplicates = compIMEIlst.GroupBy(x => x)
                                        .SelectMany(g => g.Skip(1));

            // Print duplicates
            /*foreach (var imei in duplicates)
            {
                Console.WriteLine(imei);
            }*/

            /*List<B_NumCount> imeiCount = new List<B_NumCount>();*/
            /*for (int i = 0; i < duplicates.Distinct().ToList().Count; i++)
            {
                gvCDRA_Num.Rows.Add("");
            }*/

            int count = 0;
            Graph graph = new Graph("graph");
            foreach (string imei in duplicates.Distinct().ToList())
            {

                gvCDRA_Num.Rows.Add("");
                gvCDRA_Num.Rows[count].Cells[0].Value = imei;

                for (int i = 1; i < gvCDRA_Num.ColumnCount; i++)
                {
                    //string getIMEIQry = "select Count(*) from CDR_DB_Tbl where A_Num = '" + gvCDRA_Num.Columns[i].HeaderText.ToString() + "' and IMEI = '" + imei + "'";
                    //string bnc = CommonMethods.getCount(getIMEIQry).ToString();
                    string bnc = CountMatchingIMEIRecords(allRecordsA_Num, gvCDRA_Num.Columns[i].HeaderText, imei).ToString();
                    gvCDRA_Num.Rows[count].Cells[i].Value = bnc;
                    Edge edge = graph.AddEdge(imei, gvCDRA_Num.Columns[i].HeaderText.ToString());
                    edge.LabelText = bnc;
                    //edge.Label.FontColor = Color.Green;
                    graph.FindNode(gvCDRA_Num.Columns[i].HeaderText.ToString()).Attr.FillColor = Color.PaleGreen;
                    //graph.FindNode(b_num).Attr.FillColor = Color.Red;
                }
                count += 1;

            }

            gViewer.Graph = graph;

        }

        private static int CountMatchingIMEIRecords(List<AllRecordA_Num> records, string aNum, string imei)
        {
            return records.Count(record => record.A_Num == aNum && record.IMEI == imei);
        }

        /* private void btnCommon_Click(object sender, EventArgs e)
         {
             commonB_Num();
         }*/

        private void LinkAnalysisForm_Load(object sender, EventArgs e)
        {
            txtID.Text = "Enter ID";
            txtA_Num.Text = "Enter number";

            txtID.GotFocus += new EventHandler(RemoveText);
            txtID.LostFocus += new EventHandler(AddText);

            txtA_Num.GotFocus += new EventHandler(RemoveText);
            txtA_Num.LostFocus += new EventHandler(AddText);
            rbProject.PerformClick();


        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (txtID.Text == "Enter ID")
            {
                txtID.Text = "";
            }
            if (txtA_Num.Text == "Enter number")
            {
                txtA_Num.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
                txtID.Text = "Enter ID";
            if (string.IsNullOrWhiteSpace(txtA_Num.Text))
                txtA_Num.Text = "Enter number";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtID.Text != "" && txtID.Text != "Enter ID") && (txtA_Num.Text != "" && txtA_Num.Text != "Enter number"))
                {
                    if (rbProject.Checked == true)
                    {

                        string procA_Num = "exec dbo.Projects_A_Num_Filter_A_Party_ID '" + Convert.ToInt32(txtID.Text.Trim().ToString()) + "', '" + txtA_Num.Text.Trim().ToString() + "', '" + Common.userName + "'";
                        DataTable dtA_Num = await CommonMethods.getRecords(procA_Num);

                        gvCaseProjectA_Num.DataSource = dtA_Num;
                        gvCaseProjectA_Num.Columns[0].HeaderText = "Project";
                        gvCaseProjectA_Num.Columns[1].HeaderText = "A-Party";

                        txtA_Num.Clear();
                        txtID.Clear();
                    }
                    else if (rbGeneralPolice.Checked == true)
                    {

                        string procA_Num = "exec dbo.Projects_A_Num_Filter_A_Party_ID '" + Convert.ToInt32(txtID.Text.Trim().ToString()) + "', '" + txtA_Num.Text.Trim().ToString() + "', '" + Common.userName + "'";
                        DataTable dtA_Num = await CommonMethods.getRecords(procA_Num);

                        gvCaseProjectA_Num.DataSource = dtA_Num;
                        gvCaseProjectA_Num.Columns[0].HeaderText = "Case";
                        gvCaseProjectA_Num.Columns[1].HeaderText = "A-Party";

                        txtA_Num.Clear();
                        txtID.Clear();
                    }


                }
                else if (txtID.Text != "" && txtID.Text != "Enter ID")
                {
                    if (rbProject.Checked == true)
                    {

                        string procA_Num = "exec dbo.Projects_A_Num_Filter '" + Convert.ToInt32(txtID.Text.Trim().ToString()) + "', '" + Common.userName + "'";
                        DataTable dtA_Num = await CommonMethods.getRecords(procA_Num);

                        gvCaseProjectA_Num.DataSource = dtA_Num;
                        /*gvCDRA_Num.Columns[0].HeaderText = "Project ID";*/
                        gvCaseProjectA_Num.Columns[0].HeaderText = "Project";
                        gvCaseProjectA_Num.Columns[1].HeaderText = "A-Party";
                        txtID.Clear();
                    }
                    else if (rbGeneralPolice.Checked == true)
                    {

                        string procA_Num = "exec dbo.Projects_A_Num_Filter '" + Convert.ToInt32(txtID.Text.Trim().ToString()) + "', '" + Common.userName + "'";
                        DataTable dtA_Num = await CommonMethods.getRecords(procA_Num);

                        gvCaseProjectA_Num.DataSource = dtA_Num;
                        /*gvCDRA_Num.Columns[0].HeaderText = "Project ID";*/
                        gvCaseProjectA_Num.Columns[0].HeaderText = "Project";
                        gvCaseProjectA_Num.Columns[1].HeaderText = "A-Party";
                        txtID.Clear();
                    }

                }
                else if (txtA_Num.Text != "" && txtA_Num.Text != "Enter number")
                {

                    string procA_Num = "exec dbo.Projects_A_Num_Filter_A_Party '" + txtA_Num.Text.Trim().ToString() + "', '" + Common.userName + "'";
                    DataTable dtA_Num = await CommonMethods.getRecords(procA_Num);

                    gvCaseProjectA_Num.DataSource = dtA_Num;
                    /* gvCDRA_Num.Columns[0].HeaderText = "Project ID";*/
                    gvCaseProjectA_Num.Columns[0].HeaderText = "Project";
                    gvCaseProjectA_Num.Columns[1].HeaderText = "A-Party";
                    txtA_Num.Clear();

                }
                else
                {
                    CommonMethods.messageDialog("Please fill the required fields");
                }
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void rbGeneralPolice_Click(object sender, EventArgs e)
        {
            clearGridView();
            getGeneralPoliceA_Num();
        }

        private void rbProject_Click(object sender, EventArgs e)
        {
            clearGridView();
            getProjectA_Num();
        }

        public void clearGridView()
        {
            gvCDRA_Num.DataSource = null;
            gvCDRA_Num.Rows.Clear();
            gvCDRA_Num.Columns.Clear();
            gvCDRA_Num.Refresh();
        }

        private void getDetailedRecords(string bParty, string columnType, List<AllRecordA_Num> list)
        {
            try
            {
                var lookup = list.ToLookup(i =>new {i.A_Num, i.B_Num}, j => new { j.Call_Dur, j.Call_Dir, j.Call_Type, j.Date, j.Time, j.Loc });

                List<CDRSummaryDetail> summaryDetails = new List<CDRSummaryDetail>();
                foreach (var item in lookup)
                {
                    if (item.Key.B_Num.Equals(bParty) && item.Key.A_Num.Equals(columnType))
                    {
                        //var sd = item.Where(i => i.Call_Dir.Equals(Common.incoming) && i.Call_Type.Equals(Common.voice));
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
                ListtoDataTable ltdt = new ListtoDataTable();
                DataTable dataTable = ltdt.ToDataTable(summaryDetails);

                new CDRSummaryDetailsForm(dataTable).ShowDialog();
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
        }

        private void gvCDRA_Num_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bParty = gvCDRA_Num.Rows[e.RowIndex].Cells[0].Value.ToString();
            string columnType = gvCDRA_Num.Columns[e.ColumnIndex].HeaderText;
            getDetailedRecords(bParty, columnType, allRecordsA_Num);
        }

        private void btnRemoveBnum_Click(object sender, EventArgs e)
        {
            if (lbCaseProjectA_Num.SelectedIndex > -1)
            {
                lbCaseProjectA_Num.Items.Remove(lbCaseProjectA_Num.SelectedItem);

                // Remove all records with the specific A_Num
                allRecordsA_Num.RemoveAll(record => record.A_Num == lbCaseProjectA_Num.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select A-Party to remove");
            }
        }
    }
}
