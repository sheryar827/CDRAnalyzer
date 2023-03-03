namespace ReadExcelApp.Forms
{
    partial class BTSAnalyzer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTSAnalyzer));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gvBTSData = new Zuby.ADGV.AdvancedDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelDateTime = new System.Windows.Forms.Panel();
            this.btnBrowseBtsFile = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.gbCDRSummary = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.aNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusLabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bpStatusLableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inSMSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outSMSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMEIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callDurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callDirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lacNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.networkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btsStandCDRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBTSData)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelDateTime.SuspendLayout();
            this.gbCDRSummary.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btsStandCDRBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Image = global::ReadExcelApp.Properties.Resources.exportEXCEL;
            this.btnExportExcel.Location = new System.Drawing.Point(1145, 0);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 159);
            this.btnExportExcel.TabIndex = 22;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ReadExcelApp.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(287, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 54);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(75, 14);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 22);
            this.dtpDateFrom.TabIndex = 29;
            this.dtpDateFrom.Value = new System.DateTime(2021, 6, 22, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "From:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd";
            this.dtpDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(75, 42);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(100, 22);
            this.dtpDateTo.TabIndex = 31;
            this.dtpDateTo.Value = new System.DateTime(2021, 6, 22, 16, 6, 42, 0);
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.CustomFormat = "dd-MM-yyyy";
            this.dtpTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeTo.Location = new System.Drawing.Point(181, 42);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.Size = new System.Drawing.Size(100, 22);
            this.dtpTimeTo.TabIndex = 34;
            this.dtpTimeTo.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "To:";
            // 
            // dtpTimeFrom
            // 
            this.dtpTimeFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpTimeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeFrom.Location = new System.Drawing.Point(181, 14);
            this.dtpTimeFrom.Name = "dtpTimeFrom";
            this.dtpTimeFrom.Size = new System.Drawing.Size(100, 22);
            this.dtpTimeFrom.TabIndex = 33;
            this.dtpTimeFrom.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gvBTSData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 182);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(1220, 489);
            this.panel4.TabIndex = 16;
            // 
            // gvBTSData
            // 
            this.gvBTSData.AllowUserToAddRows = false;
            this.gvBTSData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(217)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gvBTSData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvBTSData.AutoGenerateColumns = false;
            this.gvBTSData.BackgroundColor = System.Drawing.Color.White;
            this.gvBTSData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvBTSData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(84)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvBTSData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvBTSData.ColumnHeadersHeight = 41;
            this.gvBTSData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aNumDataGridViewTextBoxColumn,
            this.statusLabelDataGridViewTextBoxColumn,
            this.bNumDataGridViewTextBoxColumn,
            this.bpStatusLableDataGridViewTextBoxColumn,
            this.inDataGridViewTextBoxColumn,
            this.outDataGridViewTextBoxColumn,
            this.inSMSDataGridViewTextBoxColumn,
            this.outSMSDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.iMEIDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.callDurDataGridViewTextBoxColumn,
            this.callDirDataGridViewTextBoxColumn,
            this.callTypeDataGridViewTextBoxColumn,
            this.lacNoDataGridViewTextBoxColumn,
            this.cellIDDataGridViewTextBoxColumn,
            this.networkDataGridViewTextBoxColumn});
            this.gvBTSData.DataSource = this.btsStandCDRBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(225)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(165)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvBTSData.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvBTSData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvBTSData.EnableHeadersVisualStyles = false;
            this.gvBTSData.FilterAndSortEnabled = true;
            this.gvBTSData.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.gvBTSData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(210)))), ((int)(((byte)(187)))));
            this.gvBTSData.Location = new System.Drawing.Point(10, 10);
            this.gvBTSData.Name = "gvBTSData";
            this.gvBTSData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvBTSData.RowHeadersVisible = false;
            this.gvBTSData.Size = new System.Drawing.Size(1200, 469);
            this.gvBTSData.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.gvBTSData.TabIndex = 1;
            this.gvBTSData.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.gvBTSData_SortStringChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btnBrowseBtsFile);
            this.panel3.Controls.Add(this.btnExportExcel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1220, 159);
            this.panel3.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelDateTime);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(438, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 132);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incident Time";
            // 
            // panelDateTime
            // 
            this.panelDateTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDateTime.Controls.Add(this.btnSearch);
            this.panelDateTime.Controls.Add(this.dtpDateFrom);
            this.panelDateTime.Controls.Add(this.label1);
            this.panelDateTime.Controls.Add(this.dtpDateTo);
            this.panelDateTime.Controls.Add(this.dtpTimeTo);
            this.panelDateTime.Controls.Add(this.label2);
            this.panelDateTime.Controls.Add(this.dtpTimeFrom);
            this.panelDateTime.Location = new System.Drawing.Point(24, 29);
            this.panelDateTime.Name = "panelDateTime";
            this.panelDateTime.Size = new System.Drawing.Size(372, 78);
            this.panelDateTime.TabIndex = 37;
            // 
            // btnBrowseBtsFile
            // 
            this.btnBrowseBtsFile.AllowAnimations = true;
            this.btnBrowseBtsFile.AllowMouseEffects = true;
            this.btnBrowseBtsFile.AllowToggling = false;
            this.btnBrowseBtsFile.AnimationSpeed = 200;
            this.btnBrowseBtsFile.AutoGenerateColors = false;
            this.btnBrowseBtsFile.AutoRoundBorders = true;
            this.btnBrowseBtsFile.AutoSizeLeftIcon = true;
            this.btnBrowseBtsFile.AutoSizeRightIcon = true;
            this.btnBrowseBtsFile.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseBtsFile.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnBrowseBtsFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseBtsFile.BackgroundImage")));
            this.btnBrowseBtsFile.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseBtsFile.ButtonText = "Browse File";
            this.btnBrowseBtsFile.ButtonTextMarginLeft = 0;
            this.btnBrowseBtsFile.ColorContrastOnClick = 45;
            this.btnBrowseBtsFile.ColorContrastOnHover = 45;
            this.btnBrowseBtsFile.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnBrowseBtsFile.CustomizableEdges = borderEdges1;
            this.btnBrowseBtsFile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBrowseBtsFile.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBrowseBtsFile.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBrowseBtsFile.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBrowseBtsFile.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnBrowseBtsFile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseBtsFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseBtsFile.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseBtsFile.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnBrowseBtsFile.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnBrowseBtsFile.IconMarginLeft = 11;
            this.btnBrowseBtsFile.IconPadding = 10;
            this.btnBrowseBtsFile.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseBtsFile.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnBrowseBtsFile.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnBrowseBtsFile.IconSize = 25;
            this.btnBrowseBtsFile.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseBtsFile.IdleBorderRadius = 37;
            this.btnBrowseBtsFile.IdleBorderThickness = 1;
            this.btnBrowseBtsFile.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnBrowseBtsFile.IdleIconLeftImage = null;
            this.btnBrowseBtsFile.IdleIconRightImage = null;
            this.btnBrowseBtsFile.IndicateFocus = false;
            this.btnBrowseBtsFile.Location = new System.Drawing.Point(10, 8);
            this.btnBrowseBtsFile.Name = "btnBrowseBtsFile";
            this.btnBrowseBtsFile.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBrowseBtsFile.OnDisabledState.BorderRadius = 1;
            this.btnBrowseBtsFile.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseBtsFile.OnDisabledState.BorderThickness = 1;
            this.btnBrowseBtsFile.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBrowseBtsFile.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBrowseBtsFile.OnDisabledState.IconLeftImage = null;
            this.btnBrowseBtsFile.OnDisabledState.IconRightImage = null;
            this.btnBrowseBtsFile.onHoverState.BorderColor = System.Drawing.Color.White;
            this.btnBrowseBtsFile.onHoverState.BorderRadius = 1;
            this.btnBrowseBtsFile.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseBtsFile.onHoverState.BorderThickness = 1;
            this.btnBrowseBtsFile.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseBtsFile.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnBrowseBtsFile.onHoverState.IconLeftImage = null;
            this.btnBrowseBtsFile.onHoverState.IconRightImage = null;
            this.btnBrowseBtsFile.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseBtsFile.OnIdleState.BorderRadius = 1;
            this.btnBrowseBtsFile.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseBtsFile.OnIdleState.BorderThickness = 1;
            this.btnBrowseBtsFile.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnBrowseBtsFile.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseBtsFile.OnIdleState.IconLeftImage = null;
            this.btnBrowseBtsFile.OnIdleState.IconRightImage = null;
            this.btnBrowseBtsFile.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.btnBrowseBtsFile.OnPressedState.BorderRadius = 1;
            this.btnBrowseBtsFile.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseBtsFile.OnPressedState.BorderThickness = 1;
            this.btnBrowseBtsFile.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseBtsFile.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnBrowseBtsFile.OnPressedState.IconLeftImage = null;
            this.btnBrowseBtsFile.OnPressedState.IconRightImage = null;
            this.btnBrowseBtsFile.Size = new System.Drawing.Size(150, 39);
            this.btnBrowseBtsFile.TabIndex = 16;
            this.btnBrowseBtsFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowseBtsFile.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBrowseBtsFile.TextMarginLeft = 0;
            this.btnBrowseBtsFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnBrowseBtsFile.UseDefaultRadiusAndThickness = true;
            this.btnBrowseBtsFile.Click += new System.EventHandler(this.btnBrowseBtsFile_Click);
            // 
            // gbCDRSummary
            // 
            this.gbCDRSummary.Controls.Add(this.panel4);
            this.gbCDRSummary.Controls.Add(this.panel3);
            this.gbCDRSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCDRSummary.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCDRSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.gbCDRSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gbCDRSummary.Location = new System.Drawing.Point(10, 10);
            this.gbCDRSummary.Name = "gbCDRSummary";
            this.gbCDRSummary.Size = new System.Drawing.Size(1226, 674);
            this.gbCDRSummary.TabIndex = 28;
            this.gbCDRSummary.TabStop = false;
            this.gbCDRSummary.Text = "Processing...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCDRSummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1246, 694);
            this.panel1.TabIndex = 2;
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.panel3;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.gvBTSData;
            // 
            // aNumDataGridViewTextBoxColumn
            // 
            this.aNumDataGridViewTextBoxColumn.DataPropertyName = "A_Num";
            this.aNumDataGridViewTextBoxColumn.HeaderText = "A_Num";
            this.aNumDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.aNumDataGridViewTextBoxColumn.Name = "aNumDataGridViewTextBoxColumn";
            this.aNumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // statusLabelDataGridViewTextBoxColumn
            // 
            this.statusLabelDataGridViewTextBoxColumn.DataPropertyName = "statusLabel";
            this.statusLabelDataGridViewTextBoxColumn.HeaderText = "statusLabel";
            this.statusLabelDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.statusLabelDataGridViewTextBoxColumn.Name = "statusLabelDataGridViewTextBoxColumn";
            this.statusLabelDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // bNumDataGridViewTextBoxColumn
            // 
            this.bNumDataGridViewTextBoxColumn.DataPropertyName = "B_Num";
            this.bNumDataGridViewTextBoxColumn.HeaderText = "B_Num";
            this.bNumDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.bNumDataGridViewTextBoxColumn.Name = "bNumDataGridViewTextBoxColumn";
            this.bNumDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // bpStatusLableDataGridViewTextBoxColumn
            // 
            this.bpStatusLableDataGridViewTextBoxColumn.DataPropertyName = "bpStatusLable";
            this.bpStatusLableDataGridViewTextBoxColumn.HeaderText = "bpStatusLable";
            this.bpStatusLableDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.bpStatusLableDataGridViewTextBoxColumn.Name = "bpStatusLableDataGridViewTextBoxColumn";
            this.bpStatusLableDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // inDataGridViewTextBoxColumn
            // 
            this.inDataGridViewTextBoxColumn.DataPropertyName = "In";
            this.inDataGridViewTextBoxColumn.HeaderText = "In";
            this.inDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.inDataGridViewTextBoxColumn.Name = "inDataGridViewTextBoxColumn";
            this.inDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // outDataGridViewTextBoxColumn
            // 
            this.outDataGridViewTextBoxColumn.DataPropertyName = "Out";
            this.outDataGridViewTextBoxColumn.HeaderText = "Out";
            this.outDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.outDataGridViewTextBoxColumn.Name = "outDataGridViewTextBoxColumn";
            this.outDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // inSMSDataGridViewTextBoxColumn
            // 
            this.inSMSDataGridViewTextBoxColumn.DataPropertyName = "inSMS";
            this.inSMSDataGridViewTextBoxColumn.HeaderText = "inSMS";
            this.inSMSDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.inSMSDataGridViewTextBoxColumn.Name = "inSMSDataGridViewTextBoxColumn";
            this.inSMSDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // outSMSDataGridViewTextBoxColumn
            // 
            this.outSMSDataGridViewTextBoxColumn.DataPropertyName = "outSMS";
            this.outSMSDataGridViewTextBoxColumn.HeaderText = "outSMS";
            this.outSMSDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.outSMSDataGridViewTextBoxColumn.Name = "outSMSDataGridViewTextBoxColumn";
            this.outSMSDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // iMEIDataGridViewTextBoxColumn
            // 
            this.iMEIDataGridViewTextBoxColumn.DataPropertyName = "IMEI";
            this.iMEIDataGridViewTextBoxColumn.HeaderText = "IMEI";
            this.iMEIDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.iMEIDataGridViewTextBoxColumn.Name = "iMEIDataGridViewTextBoxColumn";
            this.iMEIDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // callDurDataGridViewTextBoxColumn
            // 
            this.callDurDataGridViewTextBoxColumn.DataPropertyName = "Call_Dur";
            this.callDurDataGridViewTextBoxColumn.HeaderText = "Call_Dur";
            this.callDurDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.callDurDataGridViewTextBoxColumn.Name = "callDurDataGridViewTextBoxColumn";
            this.callDurDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // callDirDataGridViewTextBoxColumn
            // 
            this.callDirDataGridViewTextBoxColumn.DataPropertyName = "Call_Dir";
            this.callDirDataGridViewTextBoxColumn.HeaderText = "Call_Dir";
            this.callDirDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.callDirDataGridViewTextBoxColumn.Name = "callDirDataGridViewTextBoxColumn";
            this.callDirDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // callTypeDataGridViewTextBoxColumn
            // 
            this.callTypeDataGridViewTextBoxColumn.DataPropertyName = "Call_Type";
            this.callTypeDataGridViewTextBoxColumn.HeaderText = "Call_Type";
            this.callTypeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.callTypeDataGridViewTextBoxColumn.Name = "callTypeDataGridViewTextBoxColumn";
            this.callTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lacNoDataGridViewTextBoxColumn
            // 
            this.lacNoDataGridViewTextBoxColumn.DataPropertyName = "Lac_No";
            this.lacNoDataGridViewTextBoxColumn.HeaderText = "Lac_No";
            this.lacNoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lacNoDataGridViewTextBoxColumn.Name = "lacNoDataGridViewTextBoxColumn";
            this.lacNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cellIDDataGridViewTextBoxColumn
            // 
            this.cellIDDataGridViewTextBoxColumn.DataPropertyName = "Cell_ID";
            this.cellIDDataGridViewTextBoxColumn.HeaderText = "Cell_ID";
            this.cellIDDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.cellIDDataGridViewTextBoxColumn.Name = "cellIDDataGridViewTextBoxColumn";
            this.cellIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // networkDataGridViewTextBoxColumn
            // 
            this.networkDataGridViewTextBoxColumn.DataPropertyName = "Network";
            this.networkDataGridViewTextBoxColumn.HeaderText = "Network";
            this.networkDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.networkDataGridViewTextBoxColumn.Name = "networkDataGridViewTextBoxColumn";
            this.networkDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // btsStandCDRBindingSource
            // 
            this.btsStandCDRBindingSource.DataSource = typeof(ReadExcelApp.Classes.BtsStandCDR);
            // 
            // BTSAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 694);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BTSAnalyzer";
            this.Text = "BTSAnalyzer";
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBTSData)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelDateTime.ResumeLayout(false);
            this.panelDateTime.PerformLayout();
            this.gbCDRSummary.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btsStandCDRBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpTimeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTimeFrom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelDateTime;
        private System.Windows.Forms.GroupBox gbCDRSummary;
        private System.Windows.Forms.Panel panel1;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnBrowseBtsFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource btsStandCDRBindingSource;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Zuby.ADGV.AdvancedDataGridView gvBTSData;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusLabelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bpStatusLableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inSMSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outSMSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMEIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn callDurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn callDirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn callTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lacNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn networkDataGridViewTextBoxColumn;
    }
}