namespace ReadExcelApp.Forms
{
    partial class LinkAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkAnalysisForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbCaseProjectA_Num = new System.Windows.Forms.ListBox();
            this.rbGeneralPolice = new System.Windows.Forms.RadioButton();
            this.rbProject = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnComIMEI = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnCommonB_Num = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveBnum = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtA_Num = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.gvCaseProjectA_Num = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.gvCDRA_Num = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseProjectA_Num)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCDRA_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCaseProjectA_Num
            // 
            this.lbCaseProjectA_Num.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCaseProjectA_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaseProjectA_Num.FormattingEnabled = true;
            this.lbCaseProjectA_Num.ItemHeight = 29;
            this.lbCaseProjectA_Num.Location = new System.Drawing.Point(11, 10);
            this.lbCaseProjectA_Num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbCaseProjectA_Num.Name = "lbCaseProjectA_Num";
            this.lbCaseProjectA_Num.Size = new System.Drawing.Size(433, 294);
            this.lbCaseProjectA_Num.TabIndex = 1;
            // 
            // rbGeneralPolice
            // 
            this.rbGeneralPolice.AutoSize = true;
            this.rbGeneralPolice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.rbGeneralPolice.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbGeneralPolice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGeneralPolice.ForeColor = System.Drawing.Color.White;
            this.rbGeneralPolice.Location = new System.Drawing.Point(11, 10);
            this.rbGeneralPolice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbGeneralPolice.Name = "rbGeneralPolice";
            this.rbGeneralPolice.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.rbGeneralPolice.Size = new System.Drawing.Size(234, 80);
            this.rbGeneralPolice.TabIndex = 2;
            this.rbGeneralPolice.TabStop = true;
            this.rbGeneralPolice.Text = "General Police";
            this.rbGeneralPolice.UseVisualStyleBackColor = false;
            this.rbGeneralPolice.Click += new System.EventHandler(this.rbGeneralPolice_Click);
            // 
            // rbProject
            // 
            this.rbProject.AutoSize = true;
            this.rbProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.rbProject.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProject.ForeColor = System.Drawing.Color.White;
            this.rbProject.Location = new System.Drawing.Point(294, 10);
            this.rbProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbProject.Name = "rbProject";
            this.rbProject.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.rbProject.Size = new System.Drawing.Size(150, 80);
            this.rbProject.TabIndex = 3;
            this.rbProject.TabStop = true;
            this.rbProject.Text = "Project";
            this.rbProject.UseVisualStyleBackColor = false;
            this.rbProject.Click += new System.EventHandler(this.rbProject_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(987, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panel1.Size = new System.Drawing.Size(477, 796);
            this.panel1.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnComIMEI);
            this.panel5.Controls.Add(this.btnCommonB_Num);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(11, 718);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(455, 69);
            this.panel5.TabIndex = 5;
            // 
            // btnComIMEI
            // 
            this.btnComIMEI.AllowAnimations = true;
            this.btnComIMEI.AllowMouseEffects = true;
            this.btnComIMEI.AllowToggling = false;
            this.btnComIMEI.AnimationSpeed = 200;
            this.btnComIMEI.AutoGenerateColors = false;
            this.btnComIMEI.AutoRoundBorders = true;
            this.btnComIMEI.AutoSizeLeftIcon = true;
            this.btnComIMEI.AutoSizeRightIcon = true;
            this.btnComIMEI.BackColor = System.Drawing.Color.Transparent;
            this.btnComIMEI.BackColor1 = System.Drawing.Color.White;
            this.btnComIMEI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnComIMEI.BackgroundImage")));
            this.btnComIMEI.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnComIMEI.ButtonText = "Common IMEI";
            this.btnComIMEI.ButtonTextMarginLeft = 0;
            this.btnComIMEI.ColorContrastOnClick = 45;
            this.btnComIMEI.ColorContrastOnHover = 45;
            this.btnComIMEI.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnComIMEI.CustomizableEdges = borderEdges1;
            this.btnComIMEI.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnComIMEI.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnComIMEI.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnComIMEI.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnComIMEI.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnComIMEI.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnComIMEI.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComIMEI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.IconLeft = null;
            this.btnComIMEI.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComIMEI.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnComIMEI.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnComIMEI.IconMarginLeft = 11;
            this.btnComIMEI.IconPadding = 10;
            this.btnComIMEI.IconRight = null;
            this.btnComIMEI.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComIMEI.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnComIMEI.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnComIMEI.IconSize = 25;
            this.btnComIMEI.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.IdleBorderRadius = 54;
            this.btnComIMEI.IdleBorderThickness = 1;
            this.btnComIMEI.IdleFillColor = System.Drawing.Color.White;
            this.btnComIMEI.IdleIconLeftImage = null;
            this.btnComIMEI.IdleIconRightImage = null;
            this.btnComIMEI.IndicateFocus = false;
            this.btnComIMEI.Location = new System.Drawing.Point(242, 0);
            this.btnComIMEI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComIMEI.Name = "btnComIMEI";
            this.btnComIMEI.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnComIMEI.OnDisabledState.BorderRadius = 69;
            this.btnComIMEI.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnComIMEI.OnDisabledState.BorderThickness = 1;
            this.btnComIMEI.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnComIMEI.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnComIMEI.OnDisabledState.IconLeftImage = null;
            this.btnComIMEI.OnDisabledState.IconRightImage = null;
            this.btnComIMEI.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.onHoverState.BorderRadius = 69;
            this.btnComIMEI.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnComIMEI.onHoverState.BorderThickness = 1;
            this.btnComIMEI.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnComIMEI.onHoverState.IconLeftImage = null;
            this.btnComIMEI.onHoverState.IconRightImage = null;
            this.btnComIMEI.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.OnIdleState.BorderRadius = 69;
            this.btnComIMEI.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnComIMEI.OnIdleState.BorderThickness = 1;
            this.btnComIMEI.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnComIMEI.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.OnIdleState.IconLeftImage = null;
            this.btnComIMEI.OnIdleState.IconRightImage = null;
            this.btnComIMEI.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.OnPressedState.BorderRadius = 69;
            this.btnComIMEI.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnComIMEI.OnPressedState.BorderThickness = 1;
            this.btnComIMEI.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnComIMEI.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnComIMEI.OnPressedState.IconLeftImage = null;
            this.btnComIMEI.OnPressedState.IconRightImage = null;
            this.btnComIMEI.Size = new System.Drawing.Size(213, 69);
            this.btnComIMEI.TabIndex = 7;
            this.btnComIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnComIMEI.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnComIMEI.TextMarginLeft = 0;
            this.btnComIMEI.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnComIMEI.UseDefaultRadiusAndThickness = true;
            this.btnComIMEI.Click += new System.EventHandler(this.btnComIMEI_Click);
            // 
            // btnCommonB_Num
            // 
            this.btnCommonB_Num.AllowAnimations = true;
            this.btnCommonB_Num.AllowMouseEffects = true;
            this.btnCommonB_Num.AllowToggling = false;
            this.btnCommonB_Num.AnimationSpeed = 200;
            this.btnCommonB_Num.AutoGenerateColors = false;
            this.btnCommonB_Num.AutoRoundBorders = true;
            this.btnCommonB_Num.AutoSizeLeftIcon = true;
            this.btnCommonB_Num.AutoSizeRightIcon = true;
            this.btnCommonB_Num.BackColor = System.Drawing.Color.Transparent;
            this.btnCommonB_Num.BackColor1 = System.Drawing.Color.White;
            this.btnCommonB_Num.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCommonB_Num.BackgroundImage")));
            this.btnCommonB_Num.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCommonB_Num.ButtonText = "Common No";
            this.btnCommonB_Num.ButtonTextMarginLeft = 0;
            this.btnCommonB_Num.ColorContrastOnClick = 45;
            this.btnCommonB_Num.ColorContrastOnHover = 45;
            this.btnCommonB_Num.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnCommonB_Num.CustomizableEdges = borderEdges2;
            this.btnCommonB_Num.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCommonB_Num.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCommonB_Num.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCommonB_Num.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCommonB_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCommonB_Num.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnCommonB_Num.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommonB_Num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.IconLeft = null;
            this.btnCommonB_Num.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommonB_Num.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCommonB_Num.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCommonB_Num.IconMarginLeft = 11;
            this.btnCommonB_Num.IconPadding = 10;
            this.btnCommonB_Num.IconRight = null;
            this.btnCommonB_Num.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCommonB_Num.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCommonB_Num.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCommonB_Num.IconSize = 25;
            this.btnCommonB_Num.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.IdleBorderRadius = 54;
            this.btnCommonB_Num.IdleBorderThickness = 1;
            this.btnCommonB_Num.IdleFillColor = System.Drawing.Color.White;
            this.btnCommonB_Num.IdleIconLeftImage = null;
            this.btnCommonB_Num.IdleIconRightImage = null;
            this.btnCommonB_Num.IndicateFocus = false;
            this.btnCommonB_Num.Location = new System.Drawing.Point(0, 0);
            this.btnCommonB_Num.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCommonB_Num.Name = "btnCommonB_Num";
            this.btnCommonB_Num.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCommonB_Num.OnDisabledState.BorderRadius = 69;
            this.btnCommonB_Num.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCommonB_Num.OnDisabledState.BorderThickness = 1;
            this.btnCommonB_Num.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCommonB_Num.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCommonB_Num.OnDisabledState.IconLeftImage = null;
            this.btnCommonB_Num.OnDisabledState.IconRightImage = null;
            this.btnCommonB_Num.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.onHoverState.BorderRadius = 69;
            this.btnCommonB_Num.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCommonB_Num.onHoverState.BorderThickness = 1;
            this.btnCommonB_Num.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnCommonB_Num.onHoverState.IconLeftImage = null;
            this.btnCommonB_Num.onHoverState.IconRightImage = null;
            this.btnCommonB_Num.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.OnIdleState.BorderRadius = 69;
            this.btnCommonB_Num.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCommonB_Num.OnIdleState.BorderThickness = 1;
            this.btnCommonB_Num.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnCommonB_Num.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.OnIdleState.IconLeftImage = null;
            this.btnCommonB_Num.OnIdleState.IconRightImage = null;
            this.btnCommonB_Num.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.OnPressedState.BorderRadius = 69;
            this.btnCommonB_Num.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCommonB_Num.OnPressedState.BorderThickness = 1;
            this.btnCommonB_Num.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnCommonB_Num.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCommonB_Num.OnPressedState.IconLeftImage = null;
            this.btnCommonB_Num.OnPressedState.IconRightImage = null;
            this.btnCommonB_Num.Size = new System.Drawing.Size(200, 69);
            this.btnCommonB_Num.TabIndex = 6;
            this.btnCommonB_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCommonB_Num.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCommonB_Num.TextMarginLeft = 0;
            this.btnCommonB_Num.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCommonB_Num.UseDefaultRadiusAndThickness = true;
            this.btnCommonB_Num.Click += new System.EventHandler(this.btnCommonB_Num_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbGeneralPolice);
            this.panel4.Controls.Add(this.rbProject);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(11, 618);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panel4.Size = new System.Drawing.Size(455, 100);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRemoveBnum);
            this.panel3.Controls.Add(this.lbCaseProjectA_Num);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(11, 249);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panel3.Size = new System.Drawing.Size(455, 369);
            this.panel3.TabIndex = 3;
            // 
            // btnRemoveBnum
            // 
            this.btnRemoveBnum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemoveBnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveBnum.Location = new System.Drawing.Point(11, 322);
            this.btnRemoveBnum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveBnum.Name = "btnRemoveBnum";
            this.btnRemoveBnum.Size = new System.Drawing.Size(433, 37);
            this.btnRemoveBnum.TabIndex = 2;
            this.btnRemoveBnum.Text = "Remove";
            this.btnRemoveBnum.UseVisualStyleBackColor = true;
            this.btnRemoveBnum.Click += new System.EventHandler(this.btnRemoveBnum_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtA_Num);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.gvCaseProjectA_Num);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(11, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panel2.Size = new System.Drawing.Size(455, 239);
            this.panel2.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ReadExcelApp.Properties.Resources.analytics1;
            this.btnSearch.Location = new System.Drawing.Point(367, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 49);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtA_Num
            // 
            this.txtA_Num.Location = new System.Drawing.Point(156, 14);
            this.txtA_Num.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA_Num.Name = "txtA_Num";
            this.txtA_Num.Size = new System.Drawing.Size(132, 22);
            this.txtA_Num.TabIndex = 19;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(15, 14);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(132, 22);
            this.txtID.TabIndex = 18;
            // 
            // gvCaseProjectA_Num
            // 
            this.gvCaseProjectA_Num.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCaseProjectA_Num.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCaseProjectA_Num.BackgroundColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCaseProjectA_Num.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvCaseProjectA_Num.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(143)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCaseProjectA_Num.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvCaseProjectA_Num.ColumnHeadersHeight = 40;
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(219)))));
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(209)))), ((int)(((byte)(169)))));
            this.gvCaseProjectA_Num.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.CurrentTheme.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.gvCaseProjectA_Num.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(232)))), ((int)(((byte)(212)))));
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(143)))), ((int)(((byte)(90)))));
            this.gvCaseProjectA_Num.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.CurrentTheme.Name = null;
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(209)))), ((int)(((byte)(169)))));
            this.gvCaseProjectA_Num.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(209)))), ((int)(((byte)(169)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCaseProjectA_Num.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvCaseProjectA_Num.EnableHeadersVisualStyles = false;
            this.gvCaseProjectA_Num.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(232)))), ((int)(((byte)(212)))));
            this.gvCaseProjectA_Num.HeaderBackColor = System.Drawing.Color.MediumSeaGreen;
            this.gvCaseProjectA_Num.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvCaseProjectA_Num.HeaderForeColor = System.Drawing.Color.White;
            this.gvCaseProjectA_Num.Location = new System.Drawing.Point(11, 57);
            this.gvCaseProjectA_Num.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gvCaseProjectA_Num.Name = "gvCaseProjectA_Num";
            this.gvCaseProjectA_Num.RowHeadersVisible = false;
            this.gvCaseProjectA_Num.RowHeadersWidth = 51;
            this.gvCaseProjectA_Num.RowTemplate.Height = 40;
            this.gvCaseProjectA_Num.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCaseProjectA_Num.Size = new System.Drawing.Size(435, 169);
            this.gvCaseProjectA_Num.TabIndex = 0;
            this.gvCaseProjectA_Num.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.MediumSeaGreen;
            this.gvCaseProjectA_Num.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCaseProjectA_Num_CellClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gViewer);
            this.panel6.Controls.Add(this.gvCDRA_Num);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panel6.Size = new System.Drawing.Size(987, 796);
            this.panel6.TabIndex = 8;
            // 
            // gViewer
            // 
            this.gViewer.ArrowheadLength = 10D;
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackwardEnabled = false;
            this.gViewer.BuildHitTree = true;
            this.gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewer.EdgeInsertButtonVisible = true;
            this.gViewer.FileName = "";
            this.gViewer.ForwardEnabled = false;
            this.gViewer.Graph = null;
            this.gViewer.InsertingEdge = false;
            this.gViewer.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer.LayoutEditingEnabled = true;
            this.gViewer.Location = new System.Drawing.Point(20, 371);
            this.gViewer.LooseOffsetForRouting = 0.25D;
            this.gViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = true;
            this.gViewer.NeedToCalculateLayout = true;
            this.gViewer.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer.PaddingForEdgeRouting = 8D;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveAsImageEnabled = true;
            this.gViewer.SaveAsMsaglEnabled = true;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.SaveGraphButtonVisible = true;
            this.gViewer.SaveInVectorFormatEnabled = true;
            this.gViewer.Size = new System.Drawing.Size(947, 405);
            this.gViewer.TabIndex = 6;
            this.gViewer.TightOffsetForRouting = 0.125D;
            this.gViewer.ToolBarIsVisible = true;
            this.gViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer.Transform")));
            this.gViewer.UndoRedoButtonsVisible = true;
            this.gViewer.WindowZoomButtonPressed = false;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            // 
            // gvCDRA_Num
            // 
            this.gvCDRA_Num.AllowCustomTheming = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.gvCDRA_Num.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvCDRA_Num.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCDRA_Num.BackgroundColor = System.Drawing.Color.White;
            this.gvCDRA_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCDRA_Num.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvCDRA_Num.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCDRA_Num.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvCDRA_Num.ColumnHeadersHeight = 40;
            this.gvCDRA_Num.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.gvCDRA_Num.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvCDRA_Num.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvCDRA_Num.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.gvCDRA_Num.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvCDRA_Num.CurrentTheme.BackColor = System.Drawing.Color.Teal;
            this.gvCDRA_Num.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gvCDRA_Num.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.gvCDRA_Num.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvCDRA_Num.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvCDRA_Num.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.gvCDRA_Num.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvCDRA_Num.CurrentTheme.Name = null;
            this.gvCDRA_Num.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.gvCDRA_Num.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvCDRA_Num.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvCDRA_Num.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.gvCDRA_Num.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCDRA_Num.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvCDRA_Num.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvCDRA_Num.EnableHeadersVisualStyles = false;
            this.gvCDRA_Num.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gvCDRA_Num.HeaderBackColor = System.Drawing.Color.Teal;
            this.gvCDRA_Num.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvCDRA_Num.HeaderForeColor = System.Drawing.Color.White;
            this.gvCDRA_Num.Location = new System.Drawing.Point(20, 20);
            this.gvCDRA_Num.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gvCDRA_Num.Name = "gvCDRA_Num";
            this.gvCDRA_Num.RowHeadersVisible = false;
            this.gvCDRA_Num.RowHeadersWidth = 51;
            this.gvCDRA_Num.RowTemplate.Height = 40;
            this.gvCDRA_Num.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCDRA_Num.Size = new System.Drawing.Size(947, 351);
            this.gvCDRA_Num.TabIndex = 5;
            this.gvCDRA_Num.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Teal;
            this.gvCDRA_Num.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCDRA_Num_CellClick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.gvCDRA_Num;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.gvCaseProjectA_Num;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 15;
            this.bunifuElipse3.TargetControl = this.rbGeneralPolice;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 15;
            this.bunifuElipse4.TargetControl = this.rbProject;
            // 
            // LinkAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1464, 796);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LinkAnalysisForm";
            this.Text = "LINK ANALYSIS";
            this.Load += new System.EventHandler(this.LinkAnalysisForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseProjectA_Num)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCDRA_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbCaseProjectA_Num;
        private System.Windows.Forms.RadioButton rbGeneralPolice;
        private System.Windows.Forms.RadioButton rbProject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.UI.WinForms.BunifuDataGridView gvCaseProjectA_Num;
        private Bunifu.UI.WinForms.BunifuDataGridView gvCDRA_Num;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnComIMEI;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCommonB_Num;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtA_Num;
        private System.Windows.Forms.TextBox txtID;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private System.Windows.Forms.Button btnRemoveBnum;
    }
}