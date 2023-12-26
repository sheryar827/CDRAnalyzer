namespace ReadExcelApp.Forms
{
    partial class CGMapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CGMapForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuElipse9 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.bunifuElipse7 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnStartPoint = new System.Windows.Forms.Button();
            this.bunifuElipse6 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnGetRoute = new System.Windows.Forms.Button();
            this.bunifuElipse5 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnLocDetails = new System.Windows.Forms.Button();
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEndPoint = new System.Windows.Forms.Button();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnDistance = new System.Windows.Forms.Button();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.gvCaseProjectA_Num = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.rbGeneralPolice = new System.Windows.Forms.RadioButton();
            this.rbProject = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuElipse8 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lbCommonLatLng = new System.Windows.Forms.ListBox();
            this.txtA_Num = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbDistance = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnPlotCommonLatLng = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseProjectA_Num)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse9
            // 
            this.bunifuElipse9.ElipseRadius = 15;
            this.bunifuElipse9.TargetControl = this.panel1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gMap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 894);
            this.panel1.TabIndex = 4;
            // 
            // gMap
            // 
            this.gMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(1013, 894);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMap_OnMarkerClick);
            this.gMap.OnMarkerDoubleClick += new GMap.NET.WindowsForms.MarkerDoubleClick(this.gMap_OnMarkerDoubleClick);
            this.gMap.Load += new System.EventHandler(this.GMapForm_Load);
            // 
            // bunifuElipse7
            // 
            this.bunifuElipse7.ElipseRadius = 15;
            this.bunifuElipse7.TargetControl = this.btnStartPoint;
            // 
            // btnStartPoint
            // 
            this.btnStartPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnStartPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartPoint.FlatAppearance.BorderSize = 0;
            this.btnStartPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPoint.ForeColor = System.Drawing.Color.White;
            this.btnStartPoint.Location = new System.Drawing.Point(113, 10);
            this.btnStartPoint.Name = "btnStartPoint";
            this.btnStartPoint.Size = new System.Drawing.Size(145, 44);
            this.btnStartPoint.TabIndex = 11;
            this.btnStartPoint.Text = "Start Point";
            this.btnStartPoint.UseVisualStyleBackColor = false;
            // 
            // bunifuElipse6
            // 
            this.bunifuElipse6.ElipseRadius = 15;
            this.bunifuElipse6.TargetControl = this.btnGetRoute;
            // 
            // btnGetRoute
            // 
            this.btnGetRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnGetRoute.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGetRoute.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetRoute.FlatAppearance.BorderSize = 0;
            this.btnGetRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetRoute.Image = global::ReadExcelApp.Properties.Resources.placeholde;
            this.btnGetRoute.Location = new System.Drawing.Point(10, 10);
            this.btnGetRoute.Name = "btnGetRoute";
            this.btnGetRoute.Size = new System.Drawing.Size(103, 88);
            this.btnGetRoute.TabIndex = 10;
            this.btnGetRoute.UseVisualStyleBackColor = false;
            // 
            // bunifuElipse5
            // 
            this.bunifuElipse5.ElipseRadius = 15;
            this.bunifuElipse5.TargetControl = this.btnLocDetails;
            // 
            // btnLocDetails
            // 
            this.btnLocDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnLocDetails.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLocDetails.FlatAppearance.BorderSize = 0;
            this.btnLocDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocDetails.ForeColor = System.Drawing.Color.White;
            this.btnLocDetails.Location = new System.Drawing.Point(18, 517);
            this.btnLocDetails.Name = "btnLocDetails";
            this.btnLocDetails.Size = new System.Drawing.Size(265, 43);
            this.btnLocDetails.TabIndex = 14;
            this.btnLocDetails.Text = "Location Details";
            this.btnLocDetails.UseVisualStyleBackColor = false;
            this.btnLocDetails.Click += new System.EventHandler(this.btnLocDetails_Click);
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 15;
            this.bunifuElipse4.TargetControl = this.panel4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnEndPoint);
            this.panel4.Controls.Add(this.btnStartPoint);
            this.panel4.Controls.Add(this.btnGetRoute);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(15, 197);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(268, 108);
            this.panel4.TabIndex = 12;
            // 
            // btnEndPoint
            // 
            this.btnEndPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnEndPoint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEndPoint.FlatAppearance.BorderSize = 0;
            this.btnEndPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndPoint.ForeColor = System.Drawing.Color.White;
            this.btnEndPoint.Location = new System.Drawing.Point(113, 54);
            this.btnEndPoint.Name = "btnEndPoint";
            this.btnEndPoint.Size = new System.Drawing.Size(145, 44);
            this.btnEndPoint.TabIndex = 12;
            this.btnEndPoint.Text = "End Point";
            this.btnEndPoint.UseVisualStyleBackColor = false;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 15;
            this.bunifuElipse3.TargetControl = this.btnDistance;
            // 
            // btnDistance
            // 
            this.btnDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnDistance.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDistance.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDistance.FlatAppearance.BorderSize = 0;
            this.btnDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDistance.Image = global::ReadExcelApp.Properties.Resources.distance;
            this.btnDistance.Location = new System.Drawing.Point(183, 10);
            this.btnDistance.Name = "btnDistance";
            this.btnDistance.Size = new System.Drawing.Size(75, 80);
            this.btnDistance.TabIndex = 9;
            this.btnDistance.UseVisualStyleBackColor = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.btnZoomIn;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnZoomIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Image = global::ReadExcelApp.Properties.Resources.zoom;
            this.btnZoomIn.Location = new System.Drawing.Point(10, 10);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(75, 80);
            this.btnZoomIn.TabIndex = 8;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.gvCaseProjectA_Num;
            // 
            // gvCaseProjectA_Num
            // 
            this.gvCaseProjectA_Num.AllowCustomTheming = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gvCaseProjectA_Num.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCaseProjectA_Num.BackgroundColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCaseProjectA_Num.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gvCaseProjectA_Num.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCaseProjectA_Num.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gvCaseProjectA_Num.ColumnHeadersHeight = 40;
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.CurrentTheme.BackColor = System.Drawing.Color.Orange;
            this.gvCaseProjectA_Num.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Orange;
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.CurrentTheme.Name = null;
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCaseProjectA_Num.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvCaseProjectA_Num.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvCaseProjectA_Num.EnableHeadersVisualStyles = false;
            this.gvCaseProjectA_Num.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.gvCaseProjectA_Num.HeaderBackColor = System.Drawing.Color.Orange;
            this.gvCaseProjectA_Num.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvCaseProjectA_Num.HeaderForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.Location = new System.Drawing.Point(15, 305);
            this.gvCaseProjectA_Num.Name = "gvCaseProjectA_Num";
            this.gvCaseProjectA_Num.RowHeadersVisible = false;
            this.gvCaseProjectA_Num.RowHeadersWidth = 51;
            this.gvCaseProjectA_Num.RowTemplate.Height = 40;
            this.gvCaseProjectA_Num.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCaseProjectA_Num.Size = new System.Drawing.Size(268, 150);
            this.gvCaseProjectA_Num.TabIndex = 1;
            this.gvCaseProjectA_Num.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            this.gvCaseProjectA_Num.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCaseProjectA_Num_CellClick);
            // 
            // rbGeneralPolice
            // 
            this.rbGeneralPolice.AutoSize = true;
            this.rbGeneralPolice.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbGeneralPolice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.rbGeneralPolice.FlatAppearance.BorderSize = 0;
            this.rbGeneralPolice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGeneralPolice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.rbGeneralPolice.Location = new System.Drawing.Point(15, 16);
            this.rbGeneralPolice.Margin = new System.Windows.Forms.Padding(2);
            this.rbGeneralPolice.Name = "rbGeneralPolice";
            this.rbGeneralPolice.Size = new System.Drawing.Size(131, 49);
            this.rbGeneralPolice.TabIndex = 4;
            this.rbGeneralPolice.TabStop = true;
            this.rbGeneralPolice.Text = "General Police";
            this.rbGeneralPolice.UseVisualStyleBackColor = true;
            // 
            // rbProject
            // 
            this.rbProject.AutoSize = true;
            this.rbProject.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbProject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.rbProject.FlatAppearance.BorderSize = 0;
            this.rbProject.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.rbProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.rbProject.Location = new System.Drawing.Point(173, 16);
            this.rbProject.Margin = new System.Windows.Forms.Padding(2);
            this.rbProject.Name = "rbProject";
            this.rbProject.Size = new System.Drawing.Size(80, 49);
            this.rbProject.TabIndex = 5;
            this.rbProject.TabStop = true;
            this.rbProject.Text = "Project";
            this.rbProject.UseVisualStyleBackColor = true;
            this.rbProject.CheckedChanged += new System.EventHandler(this.rbProject_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbGeneralPolice);
            this.panel2.Controls.Add(this.rbProject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(15, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panel2.Size = new System.Drawing.Size(268, 81);
            this.panel2.TabIndex = 6;
            // 
            // bunifuElipse8
            // 
            this.bunifuElipse8.ElipseRadius = 15;
            this.bunifuElipse8.TargetControl = this.btnEndPoint;
            // 
            // lbCommonLatLng
            // 
            this.lbCommonLatLng.FormattingEnabled = true;
            this.lbCommonLatLng.Location = new System.Drawing.Point(18, 574);
            this.lbCommonLatLng.Margin = new System.Windows.Forms.Padding(2);
            this.lbCommonLatLng.Name = "lbCommonLatLng";
            this.lbCommonLatLng.Size = new System.Drawing.Size(263, 160);
            this.lbCommonLatLng.TabIndex = 18;
            // 
            // txtA_Num
            // 
            this.txtA_Num.Location = new System.Drawing.Point(124, 472);
            this.txtA_Num.Name = "txtA_Num";
            this.txtA_Num.Size = new System.Drawing.Size(100, 20);
            this.txtA_Num.TabIndex = 16;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(18, 472);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 15;
            // 
            // lbDistance
            // 
            this.lbDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDistance.AutoSize = true;
            this.lbDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDistance.ForeColor = System.Drawing.Color.Black;
            this.lbDistance.Location = new System.Drawing.Point(81, 841);
            this.lbDistance.Name = "lbDistance";
            this.lbDistance.Size = new System.Drawing.Size(123, 33);
            this.lbDistance.TabIndex = 13;
            this.lbDistance.Text = "Distance";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnZoomIn);
            this.panel3.Controls.Add(this.btnDistance);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(15, 97);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(268, 100);
            this.panel3.TabIndex = 11;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.panelMenu.Controls.Add(this.btnPlotCommonLatLng);
            this.panelMenu.Controls.Add(this.lbCommonLatLng);
            this.panelMenu.Controls.Add(this.btnSearch);
            this.panelMenu.Controls.Add(this.txtA_Num);
            this.panelMenu.Controls.Add(this.txtID);
            this.panelMenu.Controls.Add(this.gvCaseProjectA_Num);
            this.panelMenu.Controls.Add(this.btnLocDetails);
            this.panelMenu.Controls.Add(this.lbDistance);
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.Location = new System.Drawing.Point(1013, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panelMenu.Size = new System.Drawing.Size(298, 894);
            this.panelMenu.TabIndex = 3;
            // 
            // btnPlotCommonLatLng
            // 
            this.btnPlotCommonLatLng.AllowAnimations = true;
            this.btnPlotCommonLatLng.AllowMouseEffects = true;
            this.btnPlotCommonLatLng.AllowToggling = false;
            this.btnPlotCommonLatLng.AnimationSpeed = 200;
            this.btnPlotCommonLatLng.AutoGenerateColors = false;
            this.btnPlotCommonLatLng.AutoRoundBorders = false;
            this.btnPlotCommonLatLng.AutoSizeLeftIcon = true;
            this.btnPlotCommonLatLng.AutoSizeRightIcon = true;
            this.btnPlotCommonLatLng.BackColor = System.Drawing.Color.Transparent;
            this.btnPlotCommonLatLng.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnPlotCommonLatLng.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlotCommonLatLng.BackgroundImage")));
            this.btnPlotCommonLatLng.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnPlotCommonLatLng.ButtonText = "Plot Common LAT LNG";
            this.btnPlotCommonLatLng.ButtonTextMarginLeft = 0;
            this.btnPlotCommonLatLng.ColorContrastOnClick = 45;
            this.btnPlotCommonLatLng.ColorContrastOnHover = 45;
            this.btnPlotCommonLatLng.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnPlotCommonLatLng.CustomizableEdges = borderEdges3;
            this.btnPlotCommonLatLng.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPlotCommonLatLng.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnPlotCommonLatLng.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnPlotCommonLatLng.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnPlotCommonLatLng.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnPlotCommonLatLng.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlotCommonLatLng.ForeColor = System.Drawing.Color.White;
            this.btnPlotCommonLatLng.IconLeft = null;
            this.btnPlotCommonLatLng.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlotCommonLatLng.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnPlotCommonLatLng.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnPlotCommonLatLng.IconMarginLeft = 11;
            this.btnPlotCommonLatLng.IconPadding = 10;
            this.btnPlotCommonLatLng.IconRight = null;
            this.btnPlotCommonLatLng.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlotCommonLatLng.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnPlotCommonLatLng.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnPlotCommonLatLng.IconSize = 25;
            this.btnPlotCommonLatLng.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnPlotCommonLatLng.IdleBorderRadius = 0;
            this.btnPlotCommonLatLng.IdleBorderThickness = 0;
            this.btnPlotCommonLatLng.IdleFillColor = System.Drawing.Color.Empty;
            this.btnPlotCommonLatLng.IdleIconLeftImage = null;
            this.btnPlotCommonLatLng.IdleIconRightImage = null;
            this.btnPlotCommonLatLng.IndicateFocus = false;
            this.btnPlotCommonLatLng.Location = new System.Drawing.Point(18, 748);
            this.btnPlotCommonLatLng.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlotCommonLatLng.Name = "btnPlotCommonLatLng";
            this.btnPlotCommonLatLng.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnPlotCommonLatLng.OnDisabledState.BorderRadius = 1;
            this.btnPlotCommonLatLng.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnPlotCommonLatLng.OnDisabledState.BorderThickness = 1;
            this.btnPlotCommonLatLng.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPlotCommonLatLng.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnPlotCommonLatLng.OnDisabledState.IconLeftImage = null;
            this.btnPlotCommonLatLng.OnDisabledState.IconRightImage = null;
            this.btnPlotCommonLatLng.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnPlotCommonLatLng.onHoverState.BorderRadius = 1;
            this.btnPlotCommonLatLng.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnPlotCommonLatLng.onHoverState.BorderThickness = 1;
            this.btnPlotCommonLatLng.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnPlotCommonLatLng.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnPlotCommonLatLng.onHoverState.IconLeftImage = null;
            this.btnPlotCommonLatLng.onHoverState.IconRightImage = null;
            this.btnPlotCommonLatLng.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnPlotCommonLatLng.OnIdleState.BorderRadius = 1;
            this.btnPlotCommonLatLng.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnPlotCommonLatLng.OnIdleState.BorderThickness = 1;
            this.btnPlotCommonLatLng.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnPlotCommonLatLng.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnPlotCommonLatLng.OnIdleState.IconLeftImage = null;
            this.btnPlotCommonLatLng.OnIdleState.IconRightImage = null;
            this.btnPlotCommonLatLng.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnPlotCommonLatLng.OnPressedState.BorderRadius = 1;
            this.btnPlotCommonLatLng.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnPlotCommonLatLng.OnPressedState.BorderThickness = 1;
            this.btnPlotCommonLatLng.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnPlotCommonLatLng.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnPlotCommonLatLng.OnPressedState.IconLeftImage = null;
            this.btnPlotCommonLatLng.OnPressedState.IconRightImage = null;
            this.btnPlotCommonLatLng.Size = new System.Drawing.Size(263, 46);
            this.btnPlotCommonLatLng.TabIndex = 19;
            this.btnPlotCommonLatLng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlotCommonLatLng.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnPlotCommonLatLng.TextMarginLeft = 0;
            this.btnPlotCommonLatLng.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnPlotCommonLatLng.UseDefaultRadiusAndThickness = true;
            this.btnPlotCommonLatLng.Click += new System.EventHandler(this.btnPlotCommonLatLng_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ReadExcelApp.Properties.Resources.analytics1;
            this.btnSearch.Location = new System.Drawing.Point(230, 461);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 40);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // CGMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 894);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CGMapForm";
            this.Text = "CGMap";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseProjectA_Num)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse9;
        private System.Windows.Forms.Panel panel1;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse7;
        private System.Windows.Forms.Button btnStartPoint;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse6;
        private System.Windows.Forms.Button btnGetRoute;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse5;
        private System.Windows.Forms.Button btnLocDetails;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEndPoint;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Button btnDistance;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Button btnZoomIn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuDataGridView gvCaseProjectA_Num;
        private System.Windows.Forms.RadioButton rbGeneralPolice;
        private System.Windows.Forms.RadioButton rbProject;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse8;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnPlotCommonLatLng;
        private System.Windows.Forms.ListBox lbCommonLatLng;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtA_Num;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lbDistance;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelMenu;
    }
}