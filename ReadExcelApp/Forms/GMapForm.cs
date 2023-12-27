using ExcelDataReader.Log;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{


    public partial class GMapForm : Form
    {
        /*private List<PointLatLng> _points;*/
        /*private List<GMapMarker> lMarks;*/
        /*private string A_Num;*/
        private DataTable dataTable = null;
        int isSetPoint;  //Set the start and end points, 1 is the start point, 2 is the end point
        GMapOverlay markers;
        GMapOverlay markerStart;
        GMapOverlay markerEnd;
        PointLatLng startPoint;
        PointLatLng endPoint;
        List<AllRecordA_Num> allLocRecordA_Num = new List<AllRecordA_Num>();
        List<AllRecordA_Num> commonLatLngList = new List<AllRecordA_Num>();
        /*DialogResult locDetDialog = new DialogResult();*/
        /*private bool MarkerWasClicked = false;*/
        GMapOverlay routes;

        /*List<PointLatLng> rp;*/
        /*List<PointLatLng> _points;*/

        //Forms.LocationDetailsForm = new Forms.LocationDetailsForm();

        bool zoom = false;
        /*bool distance = false;*/
        bool route = false;
        bool locDetails = false;


        //private List<GetLatLngForMap> _points;
        public GMapForm()
        {
            InitializeComponent();
            /*_points = new List<PointLatLng>();*/
            /*lMarks = new List<GMapMarker>();*/
            //markers = new GMapOverlay("markers");
            markerStart = new GMapOverlay("Marker_Start");
            markerEnd = new GMapOverlay("Marker_End");
            routes = new GMapOverlay("routes");


            /*rp = new List<PointLatLng>();*/
            /*_points = new List<PointLatLng>();*/


            /*A_Num = null;*/
        }

        private void plotMarkers(string A_Num
            , string project_Name
            , List<PointLatLng> _points
            , Color selectedColor)
        {
            gMap.DragButton = MouseButtons.Left;
            markers = new GMapOverlay("markers");
            /*gMap.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble("32.71086");
            double lng = Convert.ToDouble("73.93865");
            gMap.Position = new PointLatLng(lat, lng);*/
            /*gMap.MinZoom = 5;
            gMap.MaxZoom = 100;
            gMap.Zoom = 5;*/

            //1. Create a Overlay
            //GMapOverlay markers = new GMapOverlay("markers");
            //markers.Markers.Clear();
            foreach (PointLatLng point in _points)
            {
                //PointLatLng point = new PointLatLng(lat, lng);

                //Bitmap bmpMarker = (Bitmap)Image.FromFile("img/location.png");

                /*GMapMarker marker = new GMarkerGoogle(point, bmpMarker);*/

                //GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_big_stop);
                //marker.IsVisible = true;

                Bitmap markerBitmap = CreateCustomMarkerBitmap(selectedColor, new Size(40, 40)); // Customize size as needed

                GMapMarker marker = new GMarkerGoogle(point, markerBitmap);

                marker.ToolTipMode = MarkerTooltipMode.Always;
                /* marker.Tag = point.Lat.ToString() + " " + point.Lng.ToString();
                 marker.ToolTipText = point.Lat.ToString() + " " + point.Lng.ToString();*/

                marker.Tag = project_Name;
                marker.ToolTipText = A_Num + " " + project_Name;

                /*marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;*/

                //2. Add all available markers to that Overlay
                markers.Markers.Add(marker);
                //3. Cover map with Overlay

            }


            gMap.Overlays.Add(markers);
        }


        private Bitmap CreateCustomMarkerBitmap(Color color, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Antialiasing to smooth the shape
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Define the size of the circle
                int circleDiameter = size.Height / 2;
                Rectangle circleRect = new Rectangle(size.Width / 2 - circleDiameter / 2, 0, circleDiameter, circleDiameter);

                // Draw the circle (head of the marker)
                g.FillEllipse(new SolidBrush(color), circleRect);

                // Define the points for the triangle (tail of the marker)
                PointF topPoint = new PointF(size.Width / 2, circleDiameter);
                PointF leftPoint = new PointF(size.Width / 2 - circleDiameter / 2, size.Height);
                PointF rightPoint = new PointF(size.Width / 2 + circleDiameter / 2, size.Height);

                PointF[] trianglePoints = { topPoint, leftPoint, rightPoint };

                // Draw the triangle
                g.FillPolygon(new SolidBrush(color), trianglePoints);
            }
            return bmp;
        }

        private void GMapForm_Load(object sender, EventArgs e)
        {
            txtID.Text = "Enter ID";
            txtA_Num.Text = "Enter number";

            txtID.GotFocus += new EventHandler(RemoveText);
            txtID.LostFocus += new EventHandler(AddText);

            txtA_Num.GotFocus += new EventHandler(RemoveText);
            txtA_Num.LostFocus += new EventHandler(AddText);

            rbProject.Checked = true;
            GMapProviders.GoogleMap.ApiKey = AppConfig.key;
            //gMap.CacheLocation = Application.StartupPath + @"\MAP\"; //Reset the default cache location (the default cache problem of Grandpa and Dog Thief, a waste of labor and youth for a day)
            gMap.CacheLocation = @"cache";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            //String mapPath = Application.StartupPath + @"\MAP\TileDBv5\en\Data.gmdb";//This is the 2G package, let the young man make it all night! ! ! !
            //GMaps.Instance.ImportFromGMDB(mapPath);

            gMap.ShowCenter = false;
            gMap.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble("32.71086");
            double lng = Convert.ToDouble("73.93865");
            gMap.Position = new PointLatLng(lat, lng);
            gMap.MinZoom = 5;
            gMap.MaxZoom = 100;
            gMap.Zoom = 5;
            //getLatLngList();

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

        /*private void getLatLngList()
        {
            List<GetLatLngForMap> getLatLng = new List<GetLatLngForMap>();
            string Qry = "select Lat,Lng from CDRTable";
            SqlDataReader DR1 = CommonMethods.getvalues(Qry);
            if (DR1.HasRows)
            {
                List<PointLatLng> _points = new List<PointLatLng>();
                while (DR1.Read())
                {

                    double lng = 0.0;
                    double lat = 0.0;
                    Double.TryParse(DR1["Lng"].ToString(), out lng);
                    Double.TryParse(DR1["Lat"].ToString(), out lat);
                    //GetLatLngForMap getLatLngForMap = new GetLatLngForMap(lat, lng);
                    //getLatLng.Add(getLatLngForMap);
                    PointLatLng getLatLngForMap = new PointLatLng(lat, lng);
                    _points.Add(getLatLngForMap);
                    GMapMarker marker = new GMarkerGoogle(getLatLngForMap, GMarkerGoogleType.blue_pushpin);
                    *//*lMarks.Add(marker);*//*
                    //listBox1.Items.Add(nine);
                }
            }
        }*/


        private void rbGeneralPolice_CheckedChanged(object sender, EventArgs e)
        {

            getGeneralPoliceA_Num();
        }

        private void rbProject_CheckedChanged(object sender, EventArgs e)
        {
            getProjectA_Num();
        }

        private async void getProjectA_Num()
        {

            try
            {
                string proc = "exec dbo.Projects_View";
                DataTable dataTable = await CommonMethods.getRecords(proc);

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
                getSqlDRAndConn.sqlConn.Close();
            }

            gvCaseProjectA_Num.DataSource = gplst;*/
        }

        private async void getGeneralPoliceA_Num()
        {
            string proc = "exec dbo.GeneralPoliceTable_View '" + Common.userName + "'";
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
                gvCaseProjectA_Num.Columns[2].Visible = false;
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
            /* List<GetLatLngForMap> getLatLng = new List<GetLatLngForMap>();
             string A_Num = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString();
             string project_Name = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[0].Value.ToString();
             string qry = "select * from CDR_DB_Tbl where A_Num = '" + A_Num + "'";
             GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(qry);
             SqlDataReader dr = getSqlDRAndConn.sqlDR;
             if (dr.HasRows)
             {
                 List<PointLatLng> _points = new List<PointLatLng>();
                 while (dr.Read())
                 {

                     double lng = 0.0;
                     double lat = 0.0;
                     Double.TryParse(dr["Lng"].ToString(), out lng);
                     Double.TryParse(dr["Lat"].ToString(), out lat);

                     //GetLatLngForMap getLatLngForMap = new GetLatLngForMap(lat, lng);
                     //getLatLng.Add(getLatLngForMap);
                     PointLatLng getLatLngForMap = new PointLatLng(lat, lng);
                     _points.Add(getLatLngForMap);
                     *//*GMapMarker marker = new GMarkerGoogle(getLatLngForMap, GMarkerGoogleType.blue_pushpin);*/
            /*lMarks.Add(marker);*//*
            //listBox1.Items.Add(nine);
        }
        List<PointLatLng> uniquePointLst = _points.Distinct().ToList();

        plotMarkers(A_Num, project_Name, uniquePointLst);
    }

    dr.Close();
    getSqlDRAndConn.sqlConn.Close();*/

            //string a_numForAnalysis = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString();
            //string project_Name = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[0].Value.ToString();
            
            if (e.RowIndex >= 0)
            {
                List<PointLatLng> _points = new List<PointLatLng>();
                string a_numForAnalysis = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString();
                string project_Name = gvCaseProjectA_Num.Rows[e.RowIndex].Cells[0].Value.ToString();
                Color selectColor = Color.Red;
                using(ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectColor = colorDialog.Color;
                    }
                }

                //lbCommonLatLng.Items.Add(gvCaseProjectA_Num.Rows[e.RowIndex].Cells[1].Value.ToString());
                /* ColorPickerDialog colorPicker = new ColorPickerDialog();
                 colorPicker.ShowDialog();
                 Color selectedColor = colorPicker.SelectedColor;*/

                /** 
                 * To Make the row invisible on click
                 * User is unable to click it again
                */
                CurrencyManager cm = (CurrencyManager)BindingContext[gvCaseProjectA_Num.DataSource];
                cm.SuspendBinding();
                gvCaseProjectA_Num.Rows[e.RowIndex].Visible = false;
                cm.ResumeBinding();

                string spGetAllRecords = "exec dbo.GET_ALL_RECORD_A_NUM '" + a_numForAnalysis + "', '" + project_Name + "'";
                DataTable dt = new DataTable();
                dt = await CommonMethods.getRecords(spGetAllRecords);

                //Common.allRecordA_Nums = new List<AllRecordA_Num>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double lng = 0.0;
                    double lat = 0.0;
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
                   
                    allLocRecordA_Num.Add(allRecordA_Num);

                    Double.TryParse(allRecordA_Num.Lng, out lng);
                    Double.TryParse(allRecordA_Num.Lat, out lat);

                    PointLatLng getLatLngForMap = new PointLatLng(lat, lng);
                    _points.Add(getLatLngForMap);
                    //Console.WriteLine(getLatLngForMap.Lat + " " + getLatLngForMap.Lng);
                }

                List<PointLatLng> uniquePointLst = _points.Distinct().ToList();
                
                // Filter out invalid points. Define your own criteria for invalidity
                uniquePointLst = uniquePointLst.Where(p => IsValidPoint(p)).ToList();

                plotMarkers(a_numForAnalysis, project_Name, uniquePointLst, selectColor);

                allLocRecordA_Num = allLocRecordA_Num.OrderBy(x => x.Date).Distinct().ToList();

                /*Console.WriteLine("{0}, {1}", _points.Count, allLocRecordA_Num.Count);*/

                //CommonMethods.messageDialog(Common.a_numForAnalysis + " With " + Common.allRecordA_Nums.Count() + " Records Is Selected For Analysis");
            }
        }

        private static bool IsValidPoint(PointLatLng point)
        {
            // Example criteria: point is invalid if both latitude and longitude are 0
            return !(point.Lat == 0 && point.Lng == 0);
        }

        private void gMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (zoom == true)
            {

                PointLatLng pt = gMap.FromLocalToLatLng(e.X, e.Y);

                gMap.Position = pt;

                if (e.Button.Equals(MouseButtons.Left))
                {
                    // Zoom in with left mouse button
                    gMap.Zoom += 1;
                }
                else if (e.Button.Equals(MouseButtons.Right))
                {
                    // Zoom out with right mouse button
                    gMap.Zoom -= 1;
                }
            }

        }

        private void gMap_OnMarkerDoubleClick(GMapMarker item, MouseEventArgs e)
        {
            Console.WriteLine(String.Format("Marker {0} was clicked.", item.Position));
            /*MessageBox.Show(item.Position.ToString());*/

            /*if (startingPoint.IsEmpty)
                startingPoint = item.Position;
            else
                endingPoint = item.Position;    */
            switch (isSetPoint)
            {
                case 1:
                    //starting point
                    startPoint = item.Position;
                    GMapMarker marker1 = new GMarkerGoogle(startPoint, GMarkerGoogleType.red_pushpin);
                    //Clear the starting point of the last addition
                    markerStart.Markers.Clear();
                    markerStart.Markers.Add(marker1);
                    break;
                case 2:
                    //end
                    endPoint = item.Position;
                    GMapMarker marker2 = new GMarkerGoogle(endPoint, GMarkerGoogleType.blue_pushpin);
                    markerEnd.Markers.Clear();
                    markerEnd.Markers.Add(marker2);
                    break;
                default:
                    break;
            }

            gMap.Overlays.Add(markerStart);
            gMap.Overlays.Add(markerEnd);
        }



        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom == false)
            {
                zoom = true;
                locDetails = false;
                route = false;
                btnZoomIn.FlatAppearance.BorderSize = 1;
                btnLocDetails.FlatAppearance.BorderSize = 0;
                btnGetRoute.FlatAppearance.BorderSize = 0;
            }
            else
            {
                zoom = false;
                btnZoomIn.FlatAppearance.BorderSize = 0;
            }

        }

        private void btnGetRoute_Click(object sender, EventArgs e)
        {
            if (route == false)
            {
                route = true;
                zoom = false;
                locDetails = false;
                btnZoomIn.FlatAppearance.BorderSize = 0;
                btnLocDetails.FlatAppearance.BorderSize = 0;
                btnGetRoute.FlatAppearance.BorderSize = 1;
                //After clicking the search path, no more points are added
                isSetPoint = 0;
                RoutingProvider rp = this.gMap.MapProvider as RoutingProvider;
                //Get the path
                MapRoute routing = rp.GetRoute(startPoint, endPoint, false, false, (int)this.gMap.Zoom);
                if (routing != null)
                {
                    //Add routes layer

                    GMapRoute r = new GMapRoute(routing.Points, routing.Name);
                    r.Stroke = new Pen(Color.Red, 3);

                    routes.Routes.Clear();
                    routes.Routes.Add(r);

                    //Add to map
                    gMap.Overlays.Add(routes);
                    gMap.ZoomAndCenterRoute(r);
                    lbDistance.Text = routing.Distance + " Km";
                }
                else
                {
                    MessageBox.Show("Failed to find route");
                }
            }
            else
            {
                route = false;
                btnGetRoute.FlatAppearance.BorderSize = 0;
            }
        }



        private void btnStartPoint_Click(object sender, EventArgs e)
        {
            isSetPoint = 1;
            zoom = false;
            route = false;
            locDetails = false;
            btnZoomIn.FlatAppearance.BorderSize = 0;
            btnLocDetails.FlatAppearance.BorderSize = 0;
            btnGetRoute.FlatAppearance.BorderSize = 0;

        }

        private void btnEndPoint_Click(object sender, EventArgs e)
        {
            isSetPoint = 2;
            zoom = false;
            route = false;
            locDetails = false;
            btnZoomIn.FlatAppearance.BorderSize = 0;
            btnLocDetails.FlatAppearance.BorderSize = 0;
            btnGetRoute.FlatAppearance.BorderSize = 0;
        }

        /*private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {

            if (locDetails)
            {
                locDetDialog = new Forms.LocationDetailsForm(item.Position, item.ToolTipText).ShowDialog();
                
            }
            
        }*/

        private void btnLocDetails_Click(object sender, EventArgs e)
        {
            if (locDetails == false)
            {
                locDetails = true;
                zoom = false;
                route = false;
                btnLocDetails.FlatAppearance.BorderSize = 1;
                btnZoomIn.FlatAppearance.BorderSize = 0;
                btnGetRoute.FlatAppearance.BorderSize = 0;
            }

            else
            {
                locDetails = false;
                btnLocDetails.FlatAppearance.BorderSize = 0;
            }

        }

        /*private void gMap_OnMarkerEnter(GMapMarker item)
        {

            //new Forms.LocationDetailsForm(item.Position, item.ToolTipText).ShowDialog();
        }*/

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

        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (locDetails)
            {
                //Console.WriteLine($"{item.Position.Lat} {item.Position.Lng}");
                /*var latlngRecord = FilterBySpecificCoordinates(commonLatLngList
                    , item.Position.Lat.ToString()
                    , item.Position.Lng.ToString());*/

                //var matchingRecords = commonLatLngList.Where(r => double.Parse(r.Lat) == item.Position.Lat && double.Parse(r.Lng) == item.Position.Lng).ToList();

                //var specificLatLngDT = new ListtoDataTable().ToDataTable(matchingRecords);
                //Console.WriteLine(latlngRecord.Count);
                new Forms.LocationDetailsForm(item.Position, item.ToolTipText, item.Tag.ToString(), allLocRecordA_Num).Show();
                //new Forms.CommonLocDetailsForm(specificLatLngDT).Show();
            }
        }

        public List<AllRecordA_Num> FilterBySpecificCoordinates(List<AllRecordA_Num> records, string specificLat, string specificLng)
        {
            return records
                .Where(r => r.Lat == specificLat && r.Lng == specificLng)
                .ToList();
        }

        private async void rbGeneralPolice_Click(object sender, EventArgs e)
        {
            string proc = "exec dbo.GeneralPoliceTable_View '" + Common.userName + "'";
            dataTable = await CommonMethods.getRecords(proc);

            if (dataTable.Rows.Count > 0)
            {
                gvCaseProjectA_Num.DataSource = dataTable;
                gvCaseProjectA_Num.Columns[0].HeaderText = "Case ID";
                /*gvShowCaseProject.Columns[0].Visible = false;*/
                gvCaseProjectA_Num.Columns[1].HeaderText = "FIR No";

                /*gvShowCaseProject.Columns[2].HeaderText = "Created By";*/
                getGeneralPoliceA_Num();
            }
            else
            {
                CommonMethods.messageDialog("Please first create case!!");
            }
        }

        private async void rbProject_Click(object sender, EventArgs e)
        {
            string proc = "exec dbo.Projects_View_Filter_UserName '" + Common.userName + "'";
            dataTable = await CommonMethods.getRecords(proc);

            if (dataTable.Rows.Count > 0)
            {
                gvCaseProjectA_Num.DataSource = dataTable;
                gvCaseProjectA_Num.Columns[0].HeaderText = "Project ID";
                /*gvShowCaseProject.Columns[0].Visible = false;*/
                gvCaseProjectA_Num.Columns[1].HeaderText = "Project";

                getProjectA_Num();
            }
            else
            {
                CommonMethods.messageDialog("Please first create project!!");
            }
        }

        private void btnPlotCommonLatLng_Click(object sender, EventArgs e)
        {
            commonLatLngList = FindMatchingRecords(allLocRecordA_Num);
            var points = new List<PointLatLng>();
            foreach (var record in commonLatLngList)
            {
                if (double.TryParse(record.Lat, out double lat) && double.TryParse(record.Lng, out double lng))
                {
                    points.Add(new PointLatLng(lat, lng));
                }

                /*Console.WriteLine($"A_Num: {record.A_Num}, B_Num: {record.B_Num}, IMEI: {record.IMEI}, " +
                         $"Date: {record.Date}, Time: {record.Time}, Call_Dur: {record.Call_Dur}, " +
                         $"Call_Dir: {record.Call_Dir}, Call_Type: {record.Call_Type}, Lac_No: {record.Lac_No}, " +
                         $"Cell_ID: {record.Cell_ID}, Loc: {record.Loc}, Lat: {record.Lat}, Lng: {record.Lng}, " +
                         $"Network: {record.Network}, Weekday: {record.Weekday}");*/
            }

           

            List<PointLatLng> uniquePointLst = points.Distinct().ToList();

            plotMarkers("", "common lat lng", uniquePointLst, Color.Red);
        }

        public List<AllRecordA_Num> FindMatchingRecords(List<AllRecordA_Num> records)
        {
            var filteredRecords = records
                .GroupBy(r => new { r.Date, r.Lat, r.Lng })
                .Where(g => g.Select(r => r.A_Num).Distinct().Count() > 1)
                .SelectMany(g => g)
                // Filter out records with invalid or empty Lat and Lng
                .Where(r => !string.IsNullOrWhiteSpace(r.Lat) && !string.IsNullOrWhiteSpace(r.Lng) &&
                    double.TryParse(r.Lat, out double _) && double.TryParse(r.Lng, out double _))
                .ToList();



                /*var groupedRecords = filteredRecords
                                    .GroupBy(r => new { r.Lat, r.Lng, r.Date })
                                    .ToList();

                // Iterating over each group
                foreach (var group in groupedRecords)
                {
                    Console.WriteLine($"Lat: {group.Key.Lat}, Lng: {group.Key.Lng}, Date: {group.Key.Date}");

                    // Iterating over records within each group
                    foreach (var record in group)
                    {
                        Console.WriteLine($" - A_Num: {record.A_Num}");
                    }
                }*/

            return filteredRecords;
        }
    }
}
