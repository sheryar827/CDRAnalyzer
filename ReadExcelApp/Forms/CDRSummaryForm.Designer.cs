namespace ReadExcelApp.Forms
{
    partial class CDRSummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDRSummaryForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbCDRSummary = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CDRSummaryGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flpTime = new System.Windows.Forms.FlowLayoutPanel();
            this.rbMorning = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.rbEvening = new System.Windows.Forms.RadioButton();
            this.labelA_Num = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSubInfo = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelDateTime = new System.Windows.Forms.Panel();
            this.panelDT = new System.Windows.Forms.Panel();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbAllData = new System.Windows.Forms.RadioButton();
            this.rbSelected = new System.Windows.Forms.RadioButton();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.lbListSize = new System.Windows.Forms.Label();
            this.txtGetRange = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcCDRSummary = new LiveCharts.WinForms.PieChart();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.gbCDRSummary.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CDRSummaryGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.flpTime.SuspendLayout();
            this.panelDateTime.SuspendLayout();
            this.panelDT.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCDRSummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(986, 694);
            this.panel1.TabIndex = 0;
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
            this.gbCDRSummary.Size = new System.Drawing.Size(966, 674);
            this.gbCDRSummary.TabIndex = 28;
            this.gbCDRSummary.TabStop = false;
            this.gbCDRSummary.Text = "Processing...";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CDRSummaryGridView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 182);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(960, 489);
            this.panel4.TabIndex = 16;
            // 
            // CDRSummaryGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(217)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.CDRSummaryGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CDRSummaryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CDRSummaryGridView.BackgroundColor = System.Drawing.Color.White;
            this.CDRSummaryGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(84)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CDRSummaryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CDRSummaryGridView.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(225)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(165)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CDRSummaryGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.CDRSummaryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CDRSummaryGridView.EnableHeadersVisualStyles = false;
            this.CDRSummaryGridView.FilterAndSortEnabled = true;
            this.CDRSummaryGridView.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.CDRSummaryGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(210)))), ((int)(((byte)(187)))));
            this.CDRSummaryGridView.Location = new System.Drawing.Point(10, 10);
            this.CDRSummaryGridView.Name = "CDRSummaryGridView";
            this.CDRSummaryGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CDRSummaryGridView.RowHeadersVisible = false;
            this.CDRSummaryGridView.RowTemplate.Height = 40;
            this.CDRSummaryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CDRSummaryGridView.Size = new System.Drawing.Size(940, 469);
            this.CDRSummaryGridView.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.CDRSummaryGridView.TabIndex = 0;
            this.CDRSummaryGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CDRSummaryGridView_CellClick);
            this.CDRSummaryGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CDRSummaryGridView_RowsAdded);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.panel3.Controls.Add(this.flpTime);
            this.panel3.Controls.Add(this.labelA_Num);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.btnSubInfo);
            this.panel3.Controls.Add(this.progressBar);
            this.panel3.Controls.Add(this.panelDateTime);
            this.panel3.Controls.Add(this.btnExportExcel);
            this.panel3.Controls.Add(this.btnExportPDF);
            this.panel3.Controls.Add(this.lbListSize);
            this.panel3.Controls.Add(this.txtGetRange);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 159);
            this.panel3.TabIndex = 15;
            // 
            // flpTime
            // 
            this.flpTime.Controls.Add(this.rbMorning);
            this.flpTime.Controls.Add(this.rbDay);
            this.flpTime.Controls.Add(this.rbEvening);
            this.flpTime.Location = new System.Drawing.Point(126, 120);
            this.flpTime.Name = "flpTime";
            this.flpTime.Size = new System.Drawing.Size(598, 33);
            this.flpTime.TabIndex = 42;
            // 
            // rbMorning
            // 
            this.rbMorning.AutoSize = true;
            this.rbMorning.ForeColor = System.Drawing.Color.White;
            this.rbMorning.Location = new System.Drawing.Point(3, 3);
            this.rbMorning.Name = "rbMorning";
            this.rbMorning.Size = new System.Drawing.Size(193, 26);
            this.rbMorning.TabIndex = 39;
            this.rbMorning.TabStop = true;
            this.rbMorning.Text = "08:00:00 to 15:59:59";
            this.rbMorning.UseVisualStyleBackColor = true;
            this.rbMorning.Click += new System.EventHandler(this.rbMorning_Click);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.ForeColor = System.Drawing.Color.White;
            this.rbDay.Location = new System.Drawing.Point(202, 3);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(189, 26);
            this.rbDay.TabIndex = 40;
            this.rbDay.TabStop = true;
            this.rbDay.Text = "16:00:00 to 23:59:59";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.Click += new System.EventHandler(this.rbDay_Click);
            // 
            // rbEvening
            // 
            this.rbEvening.AutoSize = true;
            this.rbEvening.ForeColor = System.Drawing.Color.White;
            this.rbEvening.Location = new System.Drawing.Point(397, 3);
            this.rbEvening.Name = "rbEvening";
            this.rbEvening.Size = new System.Drawing.Size(198, 26);
            this.rbEvening.TabIndex = 41;
            this.rbEvening.TabStop = true;
            this.rbEvening.Text = "00:00:00 to 07:59:59";
            this.rbEvening.UseVisualStyleBackColor = true;
            this.rbEvening.Click += new System.EventHandler(this.rbEvening_Click);
            // 
            // labelA_Num
            // 
            this.labelA_Num.AutoSize = true;
            this.labelA_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelA_Num.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA_Num.ForeColor = System.Drawing.Color.White;
            this.labelA_Num.Location = new System.Drawing.Point(0, 0);
            this.labelA_Num.Name = "labelA_Num";
            this.labelA_Num.Padding = new System.Windows.Forms.Padding(5);
            this.labelA_Num.Size = new System.Drawing.Size(10, 41);
            this.labelA_Num.TabIndex = 38;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(77, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(16, 22);
            this.label20.TabIndex = 17;
            this.label20.Text = "/";
            // 
            // btnSubInfo
            // 
            this.btnSubInfo.AllowAnimations = true;
            this.btnSubInfo.AllowMouseEffects = true;
            this.btnSubInfo.AllowToggling = false;
            this.btnSubInfo.AnimationSpeed = 200;
            this.btnSubInfo.AutoGenerateColors = false;
            this.btnSubInfo.AutoRoundBorders = true;
            this.btnSubInfo.AutoSizeLeftIcon = true;
            this.btnSubInfo.AutoSizeRightIcon = true;
            this.btnSubInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnSubInfo.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnSubInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubInfo.BackgroundImage")));
            this.btnSubInfo.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSubInfo.ButtonText = "Sub Info";
            this.btnSubInfo.ButtonTextMarginLeft = 0;
            this.btnSubInfo.ColorContrastOnClick = 45;
            this.btnSubInfo.ColorContrastOnHover = 45;
            this.btnSubInfo.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSubInfo.CustomizableEdges = borderEdges1;
            this.btnSubInfo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSubInfo.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSubInfo.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSubInfo.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSubInfo.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSubInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSubInfo.IconLeft = null;
            this.btnSubInfo.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubInfo.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSubInfo.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSubInfo.IconMarginLeft = 11;
            this.btnSubInfo.IconPadding = 10;
            this.btnSubInfo.IconRight = null;
            this.btnSubInfo.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubInfo.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSubInfo.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSubInfo.IconSize = 25;
            this.btnSubInfo.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSubInfo.IdleBorderRadius = 37;
            this.btnSubInfo.IdleBorderThickness = 1;
            this.btnSubInfo.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnSubInfo.IdleIconLeftImage = null;
            this.btnSubInfo.IdleIconRightImage = null;
            this.btnSubInfo.IndicateFocus = false;
            this.btnSubInfo.Location = new System.Drawing.Point(10, 44);
            this.btnSubInfo.Name = "btnSubInfo";
            this.btnSubInfo.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSubInfo.OnDisabledState.BorderRadius = 1;
            this.btnSubInfo.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSubInfo.OnDisabledState.BorderThickness = 1;
            this.btnSubInfo.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSubInfo.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSubInfo.OnDisabledState.IconLeftImage = null;
            this.btnSubInfo.OnDisabledState.IconRightImage = null;
            this.btnSubInfo.onHoverState.BorderColor = System.Drawing.Color.White;
            this.btnSubInfo.onHoverState.BorderRadius = 1;
            this.btnSubInfo.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSubInfo.onHoverState.BorderThickness = 1;
            this.btnSubInfo.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSubInfo.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSubInfo.onHoverState.IconLeftImage = null;
            this.btnSubInfo.onHoverState.IconRightImage = null;
            this.btnSubInfo.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSubInfo.OnIdleState.BorderRadius = 1;
            this.btnSubInfo.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSubInfo.OnIdleState.BorderThickness = 1;
            this.btnSubInfo.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnSubInfo.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSubInfo.OnIdleState.IconLeftImage = null;
            this.btnSubInfo.OnIdleState.IconRightImage = null;
            this.btnSubInfo.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.btnSubInfo.OnPressedState.BorderRadius = 1;
            this.btnSubInfo.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSubInfo.OnPressedState.BorderThickness = 1;
            this.btnSubInfo.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSubInfo.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSubInfo.OnPressedState.IconLeftImage = null;
            this.btnSubInfo.OnPressedState.IconRightImage = null;
            this.btnSubInfo.Size = new System.Drawing.Size(150, 39);
            this.btnSubInfo.TabIndex = 42;
            this.btnSubInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSubInfo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSubInfo.TextMarginLeft = 0;
            this.btnSubInfo.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSubInfo.UseDefaultRadiusAndThickness = true;
            this.btnSubInfo.Click += new System.EventHandler(this.btnSubInfo_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(246, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(714, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 17;
            // 
            // panelDateTime
            // 
            this.panelDateTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDateTime.Controls.Add(this.panelDT);
            this.panelDateTime.Controls.Add(this.btnSearch);
            this.panelDateTime.Controls.Add(this.rbAllData);
            this.panelDateTime.Controls.Add(this.rbSelected);
            this.panelDateTime.Location = new System.Drawing.Point(289, 18);
            this.panelDateTime.Name = "panelDateTime";
            this.panelDateTime.Size = new System.Drawing.Size(435, 82);
            this.panelDateTime.TabIndex = 37;
            // 
            // panelDT
            // 
            this.panelDT.Controls.Add(this.dtpTimeTo);
            this.panelDT.Controls.Add(this.dtpDateFrom);
            this.panelDT.Controls.Add(this.dtpTimeFrom);
            this.panelDT.Controls.Add(this.dtpDateTo);
            this.panelDT.Location = new System.Drawing.Point(117, 3);
            this.panelDT.Name = "panelDT";
            this.panelDT.Size = new System.Drawing.Size(237, 76);
            this.panelDT.TabIndex = 37;
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.CustomFormat = "dd-MM-yyyy";
            this.dtpTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeTo.Location = new System.Drawing.Point(118, 40);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.Size = new System.Drawing.Size(100, 22);
            this.dtpTimeTo.TabIndex = 34;
            this.dtpTimeTo.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(12, 12);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 22);
            this.dtpDateFrom.TabIndex = 29;
            this.dtpDateFrom.Value = new System.DateTime(2021, 6, 22, 0, 0, 0, 0);
            // 
            // dtpTimeFrom
            // 
            this.dtpTimeFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpTimeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeFrom.Location = new System.Drawing.Point(118, 12);
            this.dtpTimeFrom.Name = "dtpTimeFrom";
            this.dtpTimeFrom.Size = new System.Drawing.Size(100, 22);
            this.dtpTimeFrom.TabIndex = 33;
            this.dtpTimeFrom.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd";
            this.dtpDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(12, 40);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(100, 22);
            this.dtpDateTo.TabIndex = 31;
            this.dtpDateTo.Value = new System.DateTime(2021, 6, 22, 16, 6, 42, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ReadExcelApp.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(360, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 82);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbAllData
            // 
            this.rbAllData.AutoSize = true;
            this.rbAllData.Checked = true;
            this.rbAllData.ForeColor = System.Drawing.Color.White;
            this.rbAllData.Location = new System.Drawing.Point(11, 12);
            this.rbAllData.Name = "rbAllData";
            this.rbAllData.Size = new System.Drawing.Size(95, 26);
            this.rbAllData.TabIndex = 35;
            this.rbAllData.TabStop = true;
            this.rbAllData.Text = "All Data";
            this.rbAllData.UseVisualStyleBackColor = true;
            this.rbAllData.Click += new System.EventHandler(this.rbAllData_Click);
            // 
            // rbSelected
            // 
            this.rbSelected.AutoSize = true;
            this.rbSelected.ForeColor = System.Drawing.Color.White;
            this.rbSelected.Location = new System.Drawing.Point(11, 40);
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.Size = new System.Drawing.Size(100, 26);
            this.rbSelected.TabIndex = 36;
            this.rbSelected.Text = "Selected";
            this.rbSelected.UseVisualStyleBackColor = true;
            this.rbSelected.Click += new System.EventHandler(this.rbSelected_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Image = global::ReadExcelApp.Properties.Resources.exportEXCEL;
            this.btnExportExcel.Location = new System.Drawing.Point(810, 0);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 159);
            this.btnExportExcel.TabIndex = 22;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Image = global::ReadExcelApp.Properties.Resources.exportPDF;
            this.btnExportPDF.Location = new System.Drawing.Point(885, 0);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(75, 159);
            this.btnExportPDF.TabIndex = 21;
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // lbListSize
            // 
            this.lbListSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbListSize.AutoSize = true;
            this.lbListSize.ForeColor = System.Drawing.Color.White;
            this.lbListSize.Location = new System.Drawing.Point(99, 92);
            this.lbListSize.Name = "lbListSize";
            this.lbListSize.Size = new System.Drawing.Size(37, 22);
            this.lbListSize.TabIndex = 18;
            this.lbListSize.Text = "???";
            // 
            // txtGetRange
            // 
            this.txtGetRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGetRange.Location = new System.Drawing.Point(10, 89);
            this.txtGetRange.Name = "txtGetRange";
            this.txtGetRange.Size = new System.Drawing.Size(61, 27);
            this.txtGetRange.TabIndex = 16;
            this.txtGetRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGetRange_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pcCDRSummary);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(986, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(260, 694);
            this.panel2.TabIndex = 1;
            // 
            // pcCDRSummary
            // 
            this.pcCDRSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(217)))), ((int)(((byte)(198)))));
            this.pcCDRSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcCDRSummary.Location = new System.Drawing.Point(10, 10);
            this.pcCDRSummary.Name = "pcCDRSummary";
            this.pcCDRSummary.Size = new System.Drawing.Size(240, 674);
            this.pcCDRSummary.TabIndex = 0;
            this.pcCDRSummary.Text = "pieChart1";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.panel3;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 15;
            this.bunifuElipse3.TargetControl = this.pcCDRSummary;
            // 
            // CDRSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1246, 694);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CDRSummaryForm";
            this.Text = "CDR SUMMARY";
            this.Load += new System.EventHandler(this.CDRSummaryForm_Load);
            this.panel1.ResumeLayout(false);
            this.gbCDRSummary.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CDRSummaryGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flpTime.ResumeLayout(false);
            this.flpTime.PerformLayout();
            this.panelDateTime.ResumeLayout(false);
            this.panelDateTime.PerformLayout();
            this.panelDT.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private LiveCharts.WinForms.PieChart pcCDRSummary;
        private System.Windows.Forms.GroupBox gbCDRSummary;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbListSize;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtGetRange;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpTimeFrom;
        private System.Windows.Forms.DateTimePicker dtpTimeTo;
        private System.Windows.Forms.RadioButton rbSelected;
        private System.Windows.Forms.RadioButton rbAllData;
        private System.Windows.Forms.Panel panelDateTime;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label labelA_Num;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RadioButton rbMorning;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.RadioButton rbEvening;
        private System.Windows.Forms.Panel panelDT;
        private System.Windows.Forms.FlowLayoutPanel flpTime;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSubInfo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Zuby.ADGV.AdvancedDataGridView CDRSummaryGridView;
    }
}