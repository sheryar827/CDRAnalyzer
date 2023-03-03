namespace ReadExcelApp.Forms
{
    partial class GMapForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtA_Num = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.gvCaseProjectA_Num = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btnLocDetails = new System.Windows.Forms.Button();
            this.lbDistance = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEndPoint = new System.Windows.Forms.Button();
            this.btnStartPoint = new System.Windows.Forms.Button();
            this.btnGetRoute = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnDistance = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbGeneralPolice = new System.Windows.Forms.RadioButton();
            this.rbProject = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse5 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse6 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse7 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse8 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse9 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseProjectA_Num)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
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
            this.panelMenu.Location = new System.Drawing.Point(948, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panelMenu.Size = new System.Drawing.Size(298, 694);
            this.panelMenu.TabIndex = 1;
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // gvCaseProjectA_Num
            // 
            this.gvCaseProjectA_Num.AllowCustomTheming = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvCaseProjectA_Num.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCaseProjectA_Num.BackgroundColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCaseProjectA_Num.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gvCaseProjectA_Num.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCaseProjectA_Num.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCaseProjectA_Num.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvCaseProjectA_Num.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvCaseProjectA_Num.EnableHeadersVisualStyles = false;
            this.gvCaseProjectA_Num.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.gvCaseProjectA_Num.HeaderBackColor = System.Drawing.Color.Orange;
            this.gvCaseProjectA_Num.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvCaseProjectA_Num.HeaderForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.Location = new System.Drawing.Point(15, 305);
            this.gvCaseProjectA_Num.Name = "gvCaseProjectA_Num";
            this.gvCaseProjectA_Num.RowHeadersVisible = false;
            this.gvCaseProjectA_Num.RowTemplate.Height = 40;
            this.gvCaseProjectA_Num.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCaseProjectA_Num.Size = new System.Drawing.Size(268, 150);
            this.gvCaseProjectA_Num.TabIndex = 1;
            this.gvCaseProjectA_Num.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            this.gvCaseProjectA_Num.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCaseProjectA_Num_CellClick);
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
            // lbDistance
            // 
            this.lbDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDistance.AutoSize = true;
            this.lbDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDistance.ForeColor = System.Drawing.Color.Black;
            this.lbDistance.Location = new System.Drawing.Point(82, 652);
            this.lbDistance.Name = "lbDistance";
            this.lbDistance.Size = new System.Drawing.Size(123, 33);
            this.lbDistance.TabIndex = 13;
            this.lbDistance.Text = "Distance";
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
            this.btnEndPoint.Click += new System.EventHandler(this.btnEndPoint_Click);
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
            this.btnStartPoint.Click += new System.EventHandler(this.btnStartPoint_Click);
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
            this.btnGetRoute.Click += new System.EventHandler(this.btnGetRoute_Click);
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
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
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
            this.rbGeneralPolice.Click += new System.EventHandler(this.rbGeneralPolice_Click);
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
            this.rbProject.Click += new System.EventHandler(this.rbProject_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gMap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 694);
            this.panel1.TabIndex = 2;
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
            this.gMap.Size = new System.Drawing.Size(948, 694);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMap_OnMarkerClick);
            this.gMap.OnMarkerDoubleClick += new GMap.NET.WindowsForms.MarkerDoubleClick(this.gMap_OnMarkerDoubleClick);
            this.gMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseClick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.gvCaseProjectA_Num;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.btnZoomIn;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 15;
            this.bunifuElipse3.TargetControl = this.btnDistance;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 15;
            this.bunifuElipse4.TargetControl = this.panel4;
            // 
            // bunifuElipse5
            // 
            this.bunifuElipse5.ElipseRadius = 15;
            this.bunifuElipse5.TargetControl = this.btnLocDetails;
            // 
            // bunifuElipse6
            // 
            this.bunifuElipse6.ElipseRadius = 15;
            this.bunifuElipse6.TargetControl = this.btnGetRoute;
            // 
            // bunifuElipse7
            // 
            this.bunifuElipse7.ElipseRadius = 15;
            this.bunifuElipse7.TargetControl = this.btnStartPoint;
            // 
            // bunifuElipse8
            // 
            this.bunifuElipse8.ElipseRadius = 15;
            this.bunifuElipse8.TargetControl = this.btnEndPoint;
            // 
            // bunifuElipse9
            // 
            this.bunifuElipse9.ElipseRadius = 15;
            this.bunifuElipse9.TargetControl = this.panel1;
            // 
            // GMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1246, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GMapForm";
            this.Text = "GMAP";
            this.Load += new System.EventHandler(this.GMapForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseProjectA_Num)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panel1;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.RadioButton rbProject;
        private System.Windows.Forms.RadioButton rbGeneralPolice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnDistance;
        private System.Windows.Forms.Button btnGetRoute;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEndPoint;
        private System.Windows.Forms.Button btnStartPoint;
        private System.Windows.Forms.Label lbDistance;
        private System.Windows.Forms.Button btnLocDetails;
        private Bunifu.UI.WinForms.BunifuDataGridView gvCaseProjectA_Num;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtA_Num;
        private System.Windows.Forms.TextBox txtID;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse5;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse6;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse7;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse8;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse9;
    }
}