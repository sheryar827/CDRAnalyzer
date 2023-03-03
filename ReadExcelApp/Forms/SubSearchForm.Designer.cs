
namespace ReadExcelApp.Forms
{
    partial class SubSearchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubSearchForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.gvSearchResult = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.MSISDN = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpTime = new System.Windows.Forms.FlowLayoutPanel();
            this.txtMSISDN = new System.Windows.Forms.TextBox();
            this.btnSearch = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnBrowseSearchFile = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvSearchResult
            // 
            this.gvSearchResult.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSearchResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.gvSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvSearchResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvSearchResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSearchResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvSearchResult.ColumnHeadersHeight = 40;
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvSearchResult.CurrentTheme.BackColor = System.Drawing.Color.Teal;
            this.gvSearchResult.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gvSearchResult.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.gvSearchResult.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvSearchResult.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvSearchResult.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.gvSearchResult.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvSearchResult.CurrentTheme.Name = null;
            this.gvSearchResult.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.gvSearchResult.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSearchResult.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.gvSearchResult.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSearchResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSearchResult.EnableHeadersVisualStyles = false;
            this.gvSearchResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gvSearchResult.HeaderBackColor = System.Drawing.Color.Teal;
            this.gvSearchResult.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvSearchResult.HeaderForeColor = System.Drawing.Color.White;
            this.gvSearchResult.Location = new System.Drawing.Point(0, 0);
            this.gvSearchResult.Name = "gvSearchResult";
            this.gvSearchResult.RowHeadersVisible = false;
            this.gvSearchResult.RowTemplate.Height = 40;
            this.gvSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSearchResult.Size = new System.Drawing.Size(1137, 639);
            this.gvSearchResult.TabIndex = 0;
            this.gvSearchResult.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Teal;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvSearchResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1137, 639);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(262, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "CNIC";
            // 
            // MSISDN
            // 
            this.MSISDN.AutoSize = true;
            this.MSISDN.ForeColor = System.Drawing.Color.Black;
            this.MSISDN.Location = new System.Drawing.Point(18, 15);
            this.MSISDN.Name = "MSISDN";
            this.MSISDN.Size = new System.Drawing.Size(71, 21);
            this.MSISDN.TabIndex = 2;
            this.MSISDN.Text = "MSISDN";
            // 
            // txtCNIC
            // 
            this.txtCNIC.Location = new System.Drawing.Point(315, 18);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(174, 29);
            this.txtCNIC.TabIndex = 1;
            this.txtCNIC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCNIC_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.flpTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 74);
            this.panel1.TabIndex = 4;
            // 
            // flpTime
            // 
            this.flpTime.Controls.Add(this.MSISDN);
            this.flpTime.Controls.Add(this.txtMSISDN);
            this.flpTime.Controls.Add(this.label2);
            this.flpTime.Controls.Add(this.txtCNIC);
            this.flpTime.Controls.Add(this.btnSearch);
            this.flpTime.Controls.Add(this.btnBrowseSearchFile);
            this.flpTime.Controls.Add(this.btnExportExcel);
            this.flpTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpTime.Location = new System.Drawing.Point(0, 0);
            this.flpTime.Name = "flpTime";
            this.flpTime.Padding = new System.Windows.Forms.Padding(15);
            this.flpTime.Size = new System.Drawing.Size(1137, 74);
            this.flpTime.TabIndex = 43;
            // 
            // txtMSISDN
            // 
            this.txtMSISDN.Location = new System.Drawing.Point(95, 18);
            this.txtMSISDN.Name = "txtMSISDN";
            this.txtMSISDN.Size = new System.Drawing.Size(161, 29);
            this.txtMSISDN.TabIndex = 0;
            this.txtMSISDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMSISDN_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.AllowAnimations = true;
            this.btnSearch.AllowMouseEffects = true;
            this.btnSearch.AllowToggling = false;
            this.btnSearch.AnimationSpeed = 200;
            this.btnSearch.AutoGenerateColors = false;
            this.btnSearch.AutoRoundBorders = true;
            this.btnSearch.AutoSizeLeftIcon = true;
            this.btnSearch.AutoSizeRightIcon = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSearch.ButtonText = "Search";
            this.btnSearch.ButtonTextMarginLeft = 0;
            this.btnSearch.ColorContrastOnClick = 45;
            this.btnSearch.ColorContrastOnHover = 45;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSearch.CustomizableEdges = borderEdges1;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearch.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSearch.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSearch.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSearch.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSearch.IconMarginLeft = 11;
            this.btnSearch.IconPadding = 10;
            this.btnSearch.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSearch.IconSize = 25;
            this.btnSearch.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSearch.IdleBorderRadius = 37;
            this.btnSearch.IdleBorderThickness = 1;
            this.btnSearch.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnSearch.IdleIconLeftImage = null;
            this.btnSearch.IdleIconRightImage = null;
            this.btnSearch.IndicateFocus = false;
            this.btnSearch.Location = new System.Drawing.Point(495, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearch.OnDisabledState.BorderRadius = 1;
            this.btnSearch.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSearch.OnDisabledState.BorderThickness = 1;
            this.btnSearch.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSearch.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSearch.OnDisabledState.IconLeftImage = null;
            this.btnSearch.OnDisabledState.IconRightImage = null;
            this.btnSearch.onHoverState.BorderColor = System.Drawing.Color.White;
            this.btnSearch.onHoverState.BorderRadius = 1;
            this.btnSearch.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSearch.onHoverState.BorderThickness = 1;
            this.btnSearch.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSearch.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSearch.onHoverState.IconLeftImage = null;
            this.btnSearch.onHoverState.IconRightImage = null;
            this.btnSearch.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSearch.OnIdleState.BorderRadius = 1;
            this.btnSearch.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSearch.OnIdleState.BorderThickness = 1;
            this.btnSearch.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnSearch.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSearch.OnIdleState.IconLeftImage = null;
            this.btnSearch.OnIdleState.IconRightImage = null;
            this.btnSearch.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.btnSearch.OnPressedState.BorderRadius = 1;
            this.btnSearch.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSearch.OnPressedState.BorderThickness = 1;
            this.btnSearch.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnSearch.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSearch.OnPressedState.IconLeftImage = null;
            this.btnSearch.OnPressedState.IconRightImage = null;
            this.btnSearch.Size = new System.Drawing.Size(150, 39);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSearch.TextMarginLeft = 0;
            this.btnSearch.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSearch.UseDefaultRadiusAndThickness = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBrowseSearchFile
            // 
            this.btnBrowseSearchFile.AllowAnimations = true;
            this.btnBrowseSearchFile.AllowMouseEffects = true;
            this.btnBrowseSearchFile.AllowToggling = false;
            this.btnBrowseSearchFile.AnimationSpeed = 200;
            this.btnBrowseSearchFile.AutoGenerateColors = false;
            this.btnBrowseSearchFile.AutoRoundBorders = true;
            this.btnBrowseSearchFile.AutoSizeLeftIcon = true;
            this.btnBrowseSearchFile.AutoSizeRightIcon = true;
            this.btnBrowseSearchFile.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseSearchFile.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnBrowseSearchFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseSearchFile.BackgroundImage")));
            this.btnBrowseSearchFile.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseSearchFile.ButtonText = "Bulk Search";
            this.btnBrowseSearchFile.ButtonTextMarginLeft = 0;
            this.btnBrowseSearchFile.ColorContrastOnClick = 45;
            this.btnBrowseSearchFile.ColorContrastOnHover = 45;
            this.btnBrowseSearchFile.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnBrowseSearchFile.CustomizableEdges = borderEdges2;
            this.btnBrowseSearchFile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBrowseSearchFile.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBrowseSearchFile.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBrowseSearchFile.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBrowseSearchFile.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnBrowseSearchFile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSearchFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseSearchFile.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseSearchFile.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnBrowseSearchFile.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnBrowseSearchFile.IconMarginLeft = 11;
            this.btnBrowseSearchFile.IconPadding = 10;
            this.btnBrowseSearchFile.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseSearchFile.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnBrowseSearchFile.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnBrowseSearchFile.IconSize = 25;
            this.btnBrowseSearchFile.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseSearchFile.IdleBorderRadius = 37;
            this.btnBrowseSearchFile.IdleBorderThickness = 1;
            this.btnBrowseSearchFile.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnBrowseSearchFile.IdleIconLeftImage = null;
            this.btnBrowseSearchFile.IdleIconRightImage = null;
            this.btnBrowseSearchFile.IndicateFocus = false;
            this.btnBrowseSearchFile.Location = new System.Drawing.Point(651, 18);
            this.btnBrowseSearchFile.Name = "btnBrowseSearchFile";
            this.btnBrowseSearchFile.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBrowseSearchFile.OnDisabledState.BorderRadius = 1;
            this.btnBrowseSearchFile.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseSearchFile.OnDisabledState.BorderThickness = 1;
            this.btnBrowseSearchFile.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBrowseSearchFile.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBrowseSearchFile.OnDisabledState.IconLeftImage = null;
            this.btnBrowseSearchFile.OnDisabledState.IconRightImage = null;
            this.btnBrowseSearchFile.onHoverState.BorderColor = System.Drawing.Color.White;
            this.btnBrowseSearchFile.onHoverState.BorderRadius = 1;
            this.btnBrowseSearchFile.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseSearchFile.onHoverState.BorderThickness = 1;
            this.btnBrowseSearchFile.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseSearchFile.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnBrowseSearchFile.onHoverState.IconLeftImage = null;
            this.btnBrowseSearchFile.onHoverState.IconRightImage = null;
            this.btnBrowseSearchFile.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseSearchFile.OnIdleState.BorderRadius = 1;
            this.btnBrowseSearchFile.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseSearchFile.OnIdleState.BorderThickness = 1;
            this.btnBrowseSearchFile.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.btnBrowseSearchFile.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseSearchFile.OnIdleState.IconLeftImage = null;
            this.btnBrowseSearchFile.OnIdleState.IconRightImage = null;
            this.btnBrowseSearchFile.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.btnBrowseSearchFile.OnPressedState.BorderRadius = 1;
            this.btnBrowseSearchFile.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBrowseSearchFile.OnPressedState.BorderThickness = 1;
            this.btnBrowseSearchFile.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBrowseSearchFile.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnBrowseSearchFile.OnPressedState.IconLeftImage = null;
            this.btnBrowseSearchFile.OnPressedState.IconRightImage = null;
            this.btnBrowseSearchFile.Size = new System.Drawing.Size(150, 39);
            this.btnBrowseSearchFile.TabIndex = 17;
            this.btnBrowseSearchFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowseSearchFile.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBrowseSearchFile.TextMarginLeft = 0;
            this.btnBrowseSearchFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnBrowseSearchFile.UseDefaultRadiusAndThickness = true;
            this.btnBrowseSearchFile.Click += new System.EventHandler(this.btnBrowseSearchFile_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Image = global::ReadExcelApp.Properties.Resources.exportEXCEL;
            this.btnExportExcel.Location = new System.Drawing.Point(807, 18);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 39);
            this.btnExportExcel.TabIndex = 23;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // SubSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 713);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SubSearchForm";
            this.Text = "SubSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flpTime.ResumeLayout(false);
            this.flpTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView gvSearchResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MSISDN;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMSISDN;
        private System.Windows.Forms.FlowLayoutPanel flpTime;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSearch;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnBrowseSearchFile;
        private System.Windows.Forms.Button btnExportExcel;
    }
}