namespace ReadExcelApp.Forms
{
    partial class ShowCaseProjectDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowCaseProjectDetailsForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbGeneralPolice = new System.Windows.Forms.GroupBox();
            this.btnSaveGP = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.labelDetails = new System.Windows.Forms.Label();
            this.labelDistrict = new System.Windows.Forms.Label();
            this.labelPoliceStation = new System.Windows.Forms.Label();
            this.labelUnderSection = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.lbFirNo = new System.Windows.Forms.Label();
            this.txtFirNo = new System.Windows.Forms.TextBox();
            this.cmbBoxDistict = new System.Windows.Forms.ComboBox();
            this.cmbBoxPs = new System.Windows.Forms.ComboBox();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtUnderSection = new System.Windows.Forms.TextBox();
            this.gbPrject = new System.Windows.Forms.GroupBox();
            this.cmbBoxProject = new System.Windows.Forms.ComboBox();
            this.btnSaveProjectCase = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.viewCasesProjects = new System.Windows.Forms.GroupBox();
            this.gvShowCaseProject = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.panelRadioButtons = new System.Windows.Forms.Panel();
            this.rbGeneralPolice = new System.Windows.Forms.RadioButton();
            this.rbProjects = new System.Windows.Forms.RadioButton();
            this.bunifuShadowPanel1 = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.gbGeneralPolice.SuspendLayout();
            this.gbPrject.SuspendLayout();
            this.viewCasesProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowCaseProject)).BeginInit();
            this.panelRadioButtons.SuspendLayout();
            this.bunifuShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneralPolice
            // 
            this.gbGeneralPolice.BackColor = System.Drawing.Color.White;
            this.gbGeneralPolice.Controls.Add(this.btnSaveGP);
            this.gbGeneralPolice.Controls.Add(this.labelDetails);
            this.gbGeneralPolice.Controls.Add(this.labelDistrict);
            this.gbGeneralPolice.Controls.Add(this.labelPoliceStation);
            this.gbGeneralPolice.Controls.Add(this.labelUnderSection);
            this.gbGeneralPolice.Controls.Add(this.labelDate);
            this.gbGeneralPolice.Controls.Add(this.lbFirNo);
            this.gbGeneralPolice.Controls.Add(this.txtFirNo);
            this.gbGeneralPolice.Controls.Add(this.cmbBoxDistict);
            this.gbGeneralPolice.Controls.Add(this.cmbBoxPs);
            this.gbGeneralPolice.Controls.Add(this.txtDetail);
            this.gbGeneralPolice.Controls.Add(this.dateTimePicker);
            this.gbGeneralPolice.Controls.Add(this.txtUnderSection);
            this.gbGeneralPolice.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGeneralPolice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.gbGeneralPolice.Location = new System.Drawing.Point(38, 232);
            this.gbGeneralPolice.Name = "gbGeneralPolice";
            this.gbGeneralPolice.Size = new System.Drawing.Size(510, 540);
            this.gbGeneralPolice.TabIndex = 30;
            this.gbGeneralPolice.TabStop = false;
            this.gbGeneralPolice.Text = "General Police";
            // 
            // btnSaveGP
            // 
            this.btnSaveGP.AllowAnimations = true;
            this.btnSaveGP.AllowMouseEffects = true;
            this.btnSaveGP.AllowToggling = true;
            this.btnSaveGP.AnimationSpeed = 200;
            this.btnSaveGP.AutoGenerateColors = false;
            this.btnSaveGP.AutoRoundBorders = true;
            this.btnSaveGP.AutoSizeLeftIcon = true;
            this.btnSaveGP.AutoSizeRightIcon = true;
            this.btnSaveGP.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveGP.BackColor1 = System.Drawing.Color.White;
            this.btnSaveGP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveGP.BackgroundImage")));
            this.btnSaveGP.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveGP.ButtonText = "Save";
            this.btnSaveGP.ButtonTextMarginLeft = 0;
            this.btnSaveGP.ColorContrastOnClick = 45;
            this.btnSaveGP.ColorContrastOnHover = 45;
            this.btnSaveGP.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSaveGP.CustomizableEdges = borderEdges1;
            this.btnSaveGP.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveGP.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSaveGP.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSaveGP.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSaveGP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveGP.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSaveGP.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveGP.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveGP.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSaveGP.IconMarginLeft = 11;
            this.btnSaveGP.IconPadding = 10;
            this.btnSaveGP.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveGP.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveGP.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSaveGP.IconSize = 25;
            this.btnSaveGP.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.IdleBorderRadius = 48;
            this.btnSaveGP.IdleBorderThickness = 1;
            this.btnSaveGP.IdleFillColor = System.Drawing.Color.White;
            this.btnSaveGP.IdleIconLeftImage = null;
            this.btnSaveGP.IdleIconRightImage = null;
            this.btnSaveGP.IndicateFocus = true;
            this.btnSaveGP.Location = new System.Drawing.Point(3, 487);
            this.btnSaveGP.Name = "btnSaveGP";
            this.btnSaveGP.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSaveGP.OnDisabledState.BorderRadius = 1;
            this.btnSaveGP.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveGP.OnDisabledState.BorderThickness = 1;
            this.btnSaveGP.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSaveGP.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSaveGP.OnDisabledState.IconLeftImage = null;
            this.btnSaveGP.OnDisabledState.IconRightImage = null;
            this.btnSaveGP.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.onHoverState.BorderRadius = 1;
            this.btnSaveGP.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveGP.onHoverState.BorderThickness = 1;
            this.btnSaveGP.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveGP.onHoverState.IconLeftImage = null;
            this.btnSaveGP.onHoverState.IconRightImage = null;
            this.btnSaveGP.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.OnIdleState.BorderRadius = 1;
            this.btnSaveGP.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveGP.OnIdleState.BorderThickness = 1;
            this.btnSaveGP.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnSaveGP.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.OnIdleState.IconLeftImage = null;
            this.btnSaveGP.OnIdleState.IconRightImage = null;
            this.btnSaveGP.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.OnPressedState.BorderRadius = 1;
            this.btnSaveGP.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveGP.OnPressedState.BorderThickness = 1;
            this.btnSaveGP.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveGP.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSaveGP.OnPressedState.IconLeftImage = null;
            this.btnSaveGP.OnPressedState.IconRightImage = null;
            this.btnSaveGP.Size = new System.Drawing.Size(504, 50);
            this.btnSaveGP.TabIndex = 43;
            this.btnSaveGP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveGP.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSaveGP.TextMarginLeft = 0;
            this.btnSaveGP.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSaveGP.UseDefaultRadiusAndThickness = true;
            this.btnSaveGP.Click += new System.EventHandler(this.btnSaveGP_Click);
            // 
            // labelDetails
            // 
            this.labelDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.labelDetails.Image = global::ReadExcelApp.Properties.Resources.details;
            this.labelDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDetails.Location = new System.Drawing.Point(43, 334);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(114, 41);
            this.labelDetails.TabIndex = 42;
            this.labelDetails.Text = "Details";
            this.labelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDistrict
            // 
            this.labelDistrict.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDistrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.labelDistrict.Image = global::ReadExcelApp.Properties.Resources.bo_kaap;
            this.labelDistrict.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDistrict.Location = new System.Drawing.Point(43, 276);
            this.labelDistrict.Name = "labelDistrict";
            this.labelDistrict.Size = new System.Drawing.Size(114, 41);
            this.labelDistrict.TabIndex = 41;
            this.labelDistrict.Text = "District";
            this.labelDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPoliceStation
            // 
            this.labelPoliceStation.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoliceStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.labelPoliceStation.Image = global::ReadExcelApp.Properties.Resources.police_cap;
            this.labelPoliceStation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPoliceStation.Location = new System.Drawing.Point(43, 218);
            this.labelPoliceStation.Name = "labelPoliceStation";
            this.labelPoliceStation.Size = new System.Drawing.Size(114, 41);
            this.labelPoliceStation.TabIndex = 40;
            this.labelPoliceStation.Text = "PS";
            this.labelPoliceStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUnderSection
            // 
            this.labelUnderSection.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnderSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.labelUnderSection.Image = global::ReadExcelApp.Properties.Resources.sections;
            this.labelUnderSection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelUnderSection.Location = new System.Drawing.Point(43, 160);
            this.labelUnderSection.Name = "labelUnderSection";
            this.labelUnderSection.Size = new System.Drawing.Size(114, 41);
            this.labelUnderSection.TabIndex = 39;
            this.labelUnderSection.Text = "U/S";
            this.labelUnderSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.labelDate.Image = global::ReadExcelApp.Properties.Resources.calendar;
            this.labelDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDate.Location = new System.Drawing.Point(43, 102);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(114, 41);
            this.labelDate.TabIndex = 38;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFirNo
            // 
            this.lbFirNo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.lbFirNo.Image = global::ReadExcelApp.Properties.Resources.information_button;
            this.lbFirNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbFirNo.Location = new System.Drawing.Point(43, 44);
            this.lbFirNo.Name = "lbFirNo";
            this.lbFirNo.Size = new System.Drawing.Size(114, 41);
            this.lbFirNo.TabIndex = 15;
            this.lbFirNo.Text = "Fir No";
            this.lbFirNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirNo
            // 
            this.txtFirNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.txtFirNo.Location = new System.Drawing.Point(208, 44);
            this.txtFirNo.Name = "txtFirNo";
            this.txtFirNo.Size = new System.Drawing.Size(157, 38);
            this.txtFirNo.TabIndex = 1;
            // 
            // cmbBoxDistict
            // 
            this.cmbBoxDistict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBoxDistict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBoxDistict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.cmbBoxDistict.FormattingEnabled = true;
            this.cmbBoxDistict.Items.AddRange(new object[] {
            "Chakwal",
            "Rawalpindi",
            "Attock",
            "Jhelum",
            "Swat"});
            this.cmbBoxDistict.Location = new System.Drawing.Point(208, 276);
            this.cmbBoxDistict.Name = "cmbBoxDistict";
            this.cmbBoxDistict.Size = new System.Drawing.Size(157, 39);
            this.cmbBoxDistict.TabIndex = 4;
            // 
            // cmbBoxPs
            // 
            this.cmbBoxPs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBoxPs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBoxPs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.cmbBoxPs.FormattingEnabled = true;
            this.cmbBoxPs.Items.AddRange(new object[] {
            "City",
            "Saddar",
            "Dudial",
            "Neela",
            "Kallar Kahar",
            "Tamman",
            "Lawa",
            "Saddar Talagang",
            "City Talagang",
            "Choa Saidan Shah",
            "Doman",
            "Saidu Sharif",
            "Mingora",
            "Rahimabad ",
            "Banr ",
            "Ghalegay ",
            "Shamozai ",
            "Kabal ",
            "Shah Dehrai",
            "Kanju ",
            "Matta ",
            "Shahedano Wenai (Chuprial)",
            "KKS ",
            "Manglor ",
            "Charbagh ",
            "Fatehpur",
            "Kalakot",
            "Madyan",
            "Bahrain ",
            "Kalam ",
            "Utrorr",
            "Kokarai ",
            "Women Police Station Swat"});
            this.cmbBoxPs.Location = new System.Drawing.Point(208, 218);
            this.cmbBoxPs.Name = "cmbBoxPs";
            this.cmbBoxPs.Size = new System.Drawing.Size(157, 39);
            this.cmbBoxPs.TabIndex = 3;
            // 
            // txtDetail
            // 
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.txtDetail.Location = new System.Drawing.Point(208, 334);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(296, 118);
            this.txtDetail.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(208, 102);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(157, 38);
            this.dateTimePicker.TabIndex = 1;
            this.dateTimePicker.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // txtUnderSection
            // 
            this.txtUnderSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnderSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.txtUnderSection.Location = new System.Drawing.Point(208, 160);
            this.txtUnderSection.Name = "txtUnderSection";
            this.txtUnderSection.Size = new System.Drawing.Size(157, 38);
            this.txtUnderSection.TabIndex = 2;
            // 
            // gbPrject
            // 
            this.gbPrject.BackColor = System.Drawing.Color.White;
            this.gbPrject.Controls.Add(this.cmbBoxProject);
            this.gbPrject.Controls.Add(this.btnSaveProjectCase);
            this.gbPrject.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPrject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.gbPrject.Location = new System.Drawing.Point(38, 82);
            this.gbPrject.Name = "gbPrject";
            this.gbPrject.Padding = new System.Windows.Forms.Padding(8);
            this.gbPrject.Size = new System.Drawing.Size(510, 152);
            this.gbPrject.TabIndex = 35;
            this.gbPrject.TabStop = false;
            this.gbPrject.Text = "Project";
            // 
            // cmbBoxProject
            // 
            this.cmbBoxProject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBoxProject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBoxProject.BackColor = System.Drawing.Color.White;
            this.cmbBoxProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBoxProject.FormattingEnabled = true;
            this.cmbBoxProject.Items.AddRange(new object[] {
            "Hamlet",
            "Venom",
            "ThunderBird",
            "Safari",
            "Morgan",
            "Mike",
            "Bravo",
            "Gama",
            "Beta",
            "Colombus",
            "Saidu Sharif",
            "Mingora",
            "Rahimabad ",
            "Banr ",
            "Ghalegay ",
            "Shamozai ",
            "Kabal ",
            "Shah Dehrai",
            "Kanju ",
            "Matta ",
            "Shahedano Wenai (Chuprial)",
            "KKS ",
            "Manglor ",
            "Charbagh ",
            "Fatehpur",
            "Kalakot",
            "Madyan",
            "Bahrain ",
            "Kalam ",
            "Utrorr",
            "Kokarai ",
            "Women Police Station Swat"});
            this.cmbBoxProject.Location = new System.Drawing.Point(8, 39);
            this.cmbBoxProject.Name = "cmbBoxProject";
            this.cmbBoxProject.Size = new System.Drawing.Size(494, 39);
            this.cmbBoxProject.TabIndex = 0;
            this.cmbBoxProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBoxProject_KeyDown);
            // 
            // btnSaveProjectCase
            // 
            this.btnSaveProjectCase.AllowAnimations = true;
            this.btnSaveProjectCase.AllowMouseEffects = true;
            this.btnSaveProjectCase.AllowToggling = true;
            this.btnSaveProjectCase.AnimationSpeed = 200;
            this.btnSaveProjectCase.AutoGenerateColors = false;
            this.btnSaveProjectCase.AutoRoundBorders = true;
            this.btnSaveProjectCase.AutoSizeLeftIcon = true;
            this.btnSaveProjectCase.AutoSizeRightIcon = true;
            this.btnSaveProjectCase.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveProjectCase.BackColor1 = System.Drawing.Color.White;
            this.btnSaveProjectCase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveProjectCase.BackgroundImage")));
            this.btnSaveProjectCase.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveProjectCase.ButtonText = "Save";
            this.btnSaveProjectCase.ButtonTextMarginLeft = 0;
            this.btnSaveProjectCase.ColorContrastOnClick = 45;
            this.btnSaveProjectCase.ColorContrastOnHover = 45;
            this.btnSaveProjectCase.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnSaveProjectCase.CustomizableEdges = borderEdges2;
            this.btnSaveProjectCase.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveProjectCase.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSaveProjectCase.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSaveProjectCase.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSaveProjectCase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveProjectCase.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSaveProjectCase.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProjectCase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveProjectCase.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveProjectCase.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSaveProjectCase.IconMarginLeft = 11;
            this.btnSaveProjectCase.IconPadding = 10;
            this.btnSaveProjectCase.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveProjectCase.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveProjectCase.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSaveProjectCase.IconSize = 25;
            this.btnSaveProjectCase.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.IdleBorderRadius = 49;
            this.btnSaveProjectCase.IdleBorderThickness = 1;
            this.btnSaveProjectCase.IdleFillColor = System.Drawing.Color.White;
            this.btnSaveProjectCase.IdleIconLeftImage = null;
            this.btnSaveProjectCase.IdleIconRightImage = null;
            this.btnSaveProjectCase.IndicateFocus = true;
            this.btnSaveProjectCase.Location = new System.Drawing.Point(8, 93);
            this.btnSaveProjectCase.Name = "btnSaveProjectCase";
            this.btnSaveProjectCase.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSaveProjectCase.OnDisabledState.BorderRadius = 1;
            this.btnSaveProjectCase.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveProjectCase.OnDisabledState.BorderThickness = 1;
            this.btnSaveProjectCase.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSaveProjectCase.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSaveProjectCase.OnDisabledState.IconLeftImage = null;
            this.btnSaveProjectCase.OnDisabledState.IconRightImage = null;
            this.btnSaveProjectCase.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.onHoverState.BorderRadius = 1;
            this.btnSaveProjectCase.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveProjectCase.onHoverState.BorderThickness = 1;
            this.btnSaveProjectCase.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveProjectCase.onHoverState.IconLeftImage = null;
            this.btnSaveProjectCase.onHoverState.IconRightImage = null;
            this.btnSaveProjectCase.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.OnIdleState.BorderRadius = 1;
            this.btnSaveProjectCase.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveProjectCase.OnIdleState.BorderThickness = 1;
            this.btnSaveProjectCase.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnSaveProjectCase.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.OnIdleState.IconLeftImage = null;
            this.btnSaveProjectCase.OnIdleState.IconRightImage = null;
            this.btnSaveProjectCase.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.OnPressedState.BorderRadius = 1;
            this.btnSaveProjectCase.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveProjectCase.OnPressedState.BorderThickness = 1;
            this.btnSaveProjectCase.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSaveProjectCase.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSaveProjectCase.OnPressedState.IconLeftImage = null;
            this.btnSaveProjectCase.OnPressedState.IconRightImage = null;
            this.btnSaveProjectCase.Size = new System.Drawing.Size(494, 51);
            this.btnSaveProjectCase.TabIndex = 1;
            this.btnSaveProjectCase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveProjectCase.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSaveProjectCase.TextMarginLeft = 0;
            this.btnSaveProjectCase.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSaveProjectCase.UseDefaultRadiusAndThickness = true;
            this.btnSaveProjectCase.Click += new System.EventHandler(this.btnSaveProjectCase_Click);
            // 
            // viewCasesProjects
            // 
            this.viewCasesProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.viewCasesProjects.Controls.Add(this.gvShowCaseProject);
            this.viewCasesProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewCasesProjects.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewCasesProjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.viewCasesProjects.Location = new System.Drawing.Point(593, 10);
            this.viewCasesProjects.Margin = new System.Windows.Forms.Padding(2);
            this.viewCasesProjects.Name = "viewCasesProjects";
            this.viewCasesProjects.Padding = new System.Windows.Forms.Padding(8);
            this.viewCasesProjects.Size = new System.Drawing.Size(824, 789);
            this.viewCasesProjects.TabIndex = 36;
            this.viewCasesProjects.TabStop = false;
            this.viewCasesProjects.Text = "Cases / Projects";
            // 
            // gvShowCaseProject
            // 
            this.gvShowCaseProject.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gvShowCaseProject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvShowCaseProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvShowCaseProject.BackgroundColor = System.Drawing.Color.White;
            this.gvShowCaseProject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvShowCaseProject.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gvShowCaseProject.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvShowCaseProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvShowCaseProject.ColumnHeadersHeight = 40;
            this.gvShowCaseProject.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            this.gvShowCaseProject.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvShowCaseProject.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvShowCaseProject.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            this.gvShowCaseProject.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvShowCaseProject.CurrentTheme.BackColor = System.Drawing.Color.Orange;
            this.gvShowCaseProject.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.gvShowCaseProject.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Orange;
            this.gvShowCaseProject.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvShowCaseProject.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvShowCaseProject.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.gvShowCaseProject.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvShowCaseProject.CurrentTheme.Name = null;
            this.gvShowCaseProject.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            this.gvShowCaseProject.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvShowCaseProject.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvShowCaseProject.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            this.gvShowCaseProject.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvShowCaseProject.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvShowCaseProject.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvShowCaseProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvShowCaseProject.EnableHeadersVisualStyles = false;
            this.gvShowCaseProject.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.gvShowCaseProject.HeaderBackColor = System.Drawing.Color.Orange;
            this.gvShowCaseProject.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvShowCaseProject.HeaderForeColor = System.Drawing.Color.White;
            this.gvShowCaseProject.Location = new System.Drawing.Point(8, 39);
            this.gvShowCaseProject.Name = "gvShowCaseProject";
            this.gvShowCaseProject.RowHeadersVisible = false;
            this.gvShowCaseProject.RowTemplate.Height = 40;
            this.gvShowCaseProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvShowCaseProject.Size = new System.Drawing.Size(808, 742);
            this.gvShowCaseProject.TabIndex = 0;
            this.gvShowCaseProject.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            // 
            // panelRadioButtons
            // 
            this.panelRadioButtons.BackColor = System.Drawing.Color.White;
            this.panelRadioButtons.Controls.Add(this.rbGeneralPolice);
            this.panelRadioButtons.Controls.Add(this.rbProjects);
            this.panelRadioButtons.Location = new System.Drawing.Point(38, 15);
            this.panelRadioButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelRadioButtons.Name = "panelRadioButtons";
            this.panelRadioButtons.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panelRadioButtons.Size = new System.Drawing.Size(510, 62);
            this.panelRadioButtons.TabIndex = 36;
            // 
            // rbGeneralPolice
            // 
            this.rbGeneralPolice.AutoSize = true;
            this.rbGeneralPolice.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbGeneralPolice.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGeneralPolice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.rbGeneralPolice.Location = new System.Drawing.Point(344, 16);
            this.rbGeneralPolice.Margin = new System.Windows.Forms.Padding(2);
            this.rbGeneralPolice.Name = "rbGeneralPolice";
            this.rbGeneralPolice.Size = new System.Drawing.Size(151, 30);
            this.rbGeneralPolice.TabIndex = 1;
            this.rbGeneralPolice.TabStop = true;
            this.rbGeneralPolice.Text = "General Police";
            this.rbGeneralPolice.UseVisualStyleBackColor = true;
            this.rbGeneralPolice.Click += new System.EventHandler(this.rbGeneralPolice_Click);
            // 
            // rbProjects
            // 
            this.rbProjects.AutoSize = true;
            this.rbProjects.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbProjects.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.rbProjects.Location = new System.Drawing.Point(15, 16);
            this.rbProjects.Margin = new System.Windows.Forms.Padding(2);
            this.rbProjects.Name = "rbProjects";
            this.rbProjects.Size = new System.Drawing.Size(98, 30);
            this.rbProjects.TabIndex = 0;
            this.rbProjects.TabStop = true;
            this.rbProjects.Text = "Projects";
            this.rbProjects.UseVisualStyleBackColor = true;
            this.rbProjects.Click += new System.EventHandler(this.rbProjects_Click);
            // 
            // bunifuShadowPanel1
            // 
            this.bunifuShadowPanel1.AutoScroll = true;
            this.bunifuShadowPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.bunifuShadowPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.bunifuShadowPanel1.BorderRadius = 20;
            this.bunifuShadowPanel1.BorderThickness = 0;
            this.bunifuShadowPanel1.Controls.Add(this.gbPrject);
            this.bunifuShadowPanel1.Controls.Add(this.panelRadioButtons);
            this.bunifuShadowPanel1.Controls.Add(this.gbGeneralPolice);
            this.bunifuShadowPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuShadowPanel1.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.bunifuShadowPanel1.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.ForwardDiagonal;
            this.bunifuShadowPanel1.Location = new System.Drawing.Point(10, 10);
            this.bunifuShadowPanel1.Name = "bunifuShadowPanel1";
            this.bunifuShadowPanel1.PanelColor = System.Drawing.Color.White;
            this.bunifuShadowPanel1.PanelColor2 = System.Drawing.Color.White;
            this.bunifuShadowPanel1.ShadowColor = System.Drawing.Color.DarkGray;
            this.bunifuShadowPanel1.ShadowDept = 2;
            this.bunifuShadowPanel1.ShadowDepth = 7;
            this.bunifuShadowPanel1.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
            this.bunifuShadowPanel1.ShadowTopLeftVisible = false;
            this.bunifuShadowPanel1.Size = new System.Drawing.Size(583, 789);
            this.bunifuShadowPanel1.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
            this.bunifuShadowPanel1.TabIndex = 38;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.gvShowCaseProject;
            // 
            // ShowCaseProjectDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1427, 809);
            this.Controls.Add(this.viewCasesProjects);
            this.Controls.Add(this.bunifuShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShowCaseProjectDetailsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ADD CASE";
            this.Load += new System.EventHandler(this.ShowCaseProjectDetailsForm_Load);
            this.gbGeneralPolice.ResumeLayout(false);
            this.gbGeneralPolice.PerformLayout();
            this.gbPrject.ResumeLayout(false);
            this.viewCasesProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvShowCaseProject)).EndInit();
            this.panelRadioButtons.ResumeLayout(false);
            this.panelRadioButtons.PerformLayout();
            this.bunifuShadowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeneralPolice;
        private System.Windows.Forms.ComboBox cmbBoxDistict;
        private System.Windows.Forms.ComboBox cmbBoxPs;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lbFirNo;
        private System.Windows.Forms.TextBox txtUnderSection;
        private System.Windows.Forms.TextBox txtFirNo;
        private System.Windows.Forms.GroupBox gbPrject;
        private System.Windows.Forms.ComboBox cmbBoxProject;
        private System.Windows.Forms.GroupBox viewCasesProjects;
        private System.Windows.Forms.Panel panelRadioButtons;
        private System.Windows.Forms.RadioButton rbGeneralPolice;
        private System.Windows.Forms.RadioButton rbProjects;
        private Bunifu.UI.WinForms.BunifuShadowPanel bunifuShadowPanel1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelUnderSection;
        private System.Windows.Forms.Label labelPoliceStation;
        private System.Windows.Forms.Label labelDistrict;
        private System.Windows.Forms.Label labelDetails;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSaveProjectCase;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSaveGP;
        private Bunifu.UI.WinForms.BunifuDataGridView gvShowCaseProject;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}