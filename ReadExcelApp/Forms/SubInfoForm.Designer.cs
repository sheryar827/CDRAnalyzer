namespace ReadExcelApp.Forms
{
    partial class SubInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubInfoForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAParty = new System.Windows.Forms.TextBox();
            this.txtBParty = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBrowseSearchFile = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.lbCellID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLac = new System.Windows.Forms.TextBox();
            this.txtCellID = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvSearchResult = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAParty
            // 
            this.txtAParty.Location = new System.Drawing.Point(221, 12);
            this.txtAParty.Name = "txtAParty";
            this.txtAParty.Size = new System.Drawing.Size(149, 20);
            this.txtAParty.TabIndex = 0;
            this.txtAParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMobileNo_KeyDown);
            // 
            // txtBParty
            // 
            this.txtBParty.Location = new System.Drawing.Point(221, 38);
            this.txtBParty.Name = "txtBParty";
            this.txtBParty.Size = new System.Drawing.Size(149, 20);
            this.txtBParty.TabIndex = 1;
            this.txtBParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCnicNo_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.btnBrowseSearchFile);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtIMEI);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtLat);
            this.panel1.Controls.Add(this.txtLng);
            this.panel1.Controls.Add(this.lbCellID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtLac);
            this.panel1.Controls.Add(this.txtCellID);
            this.panel1.Controls.Add(this.cbSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAParty);
            this.panel1.Controls.Add(this.txtBParty);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 97);
            this.panel1.TabIndex = 2;
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
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnBrowseSearchFile.CustomizableEdges = borderEdges1;
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
            this.btnBrowseSearchFile.Location = new System.Drawing.Point(855, 47);
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
            this.btnBrowseSearchFile.TabIndex = 15;
            this.btnBrowseSearchFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowseSearchFile.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBrowseSearchFile.TextMarginLeft = 0;
            this.btnBrowseSearchFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnBrowseSearchFile.UseDefaultRadiusAndThickness = true;
            this.btnBrowseSearchFile.Click += new System.EventHandler(this.btnBrowseSearchFile_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(806, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "IMEI";
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(855, 20);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.Size = new System.Drawing.Size(149, 20);
            this.txtIMEI.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(582, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "LNG";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(580, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "LAT";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(629, 12);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(149, 20);
            this.txtLat.TabIndex = 9;
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(629, 38);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(149, 20);
            this.txtLng.TabIndex = 10;
            // 
            // lbCellID
            // 
            this.lbCellID.AutoSize = true;
            this.lbCellID.ForeColor = System.Drawing.Color.Black;
            this.lbCellID.Location = new System.Drawing.Point(378, 41);
            this.lbCellID.Name = "lbCellID";
            this.lbCellID.Size = new System.Drawing.Size(38, 13);
            this.lbCellID.TabIndex = 8;
            this.lbCellID.Text = "Cell-ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(376, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LAC";
            // 
            // txtLac
            // 
            this.txtLac.Location = new System.Drawing.Point(425, 12);
            this.txtLac.Name = "txtLac";
            this.txtLac.Size = new System.Drawing.Size(149, 20);
            this.txtLac.TabIndex = 5;
            // 
            // txtCellID
            // 
            this.txtCellID.Location = new System.Drawing.Point(425, 38);
            this.txtCellID.Name = "txtCellID";
            this.txtCellID.Size = new System.Drawing.Size(149, 20);
            this.txtCellID.TabIndex = 6;
            // 
            // cbSearch
            // 
            this.cbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "A-Party",
            "B-Party",
            "IMEI",
            "LAC/Cell-ID",
            "LAT/LNG"});
            this.cbSearch.Location = new System.Drawing.Point(30, 15);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(121, 21);
            this.cbSearch.TabIndex = 4;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(174, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "B-Party";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(172, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "A-Party";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvSearchResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1098, 550);
            this.panel2.TabIndex = 3;
            // 
            // gvSearchResult
            // 
            this.gvSearchResult.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSearchResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.gvSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvSearchResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvSearchResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(143)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSearchResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvSearchResult.ColumnHeadersHeight = 40;
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(219)))));
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(209)))), ((int)(((byte)(169)))));
            this.gvSearchResult.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.CurrentTheme.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.gvSearchResult.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(232)))), ((int)(((byte)(212)))));
            this.gvSearchResult.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.gvSearchResult.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvSearchResult.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvSearchResult.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(143)))), ((int)(((byte)(90)))));
            this.gvSearchResult.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvSearchResult.CurrentTheme.Name = null;
            this.gvSearchResult.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.gvSearchResult.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSearchResult.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvSearchResult.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(209)))), ((int)(((byte)(169)))));
            this.gvSearchResult.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(209)))), ((int)(((byte)(169)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSearchResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSearchResult.EnableHeadersVisualStyles = false;
            this.gvSearchResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(232)))), ((int)(((byte)(212)))));
            this.gvSearchResult.HeaderBackColor = System.Drawing.Color.MediumSeaGreen;
            this.gvSearchResult.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvSearchResult.HeaderForeColor = System.Drawing.Color.White;
            this.gvSearchResult.Location = new System.Drawing.Point(0, 0);
            this.gvSearchResult.Name = "gvSearchResult";
            this.gvSearchResult.RowHeadersVisible = false;
            this.gvSearchResult.RowTemplate.Height = 40;
            this.gvSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSearchResult.Size = new System.Drawing.Size(1098, 550);
            this.gvSearchResult.TabIndex = 0;
            this.gvSearchResult.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.MediumSeaGreen;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this.panel1;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.gvSearchResult;
            // 
            // SubInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1098, 647);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubInfoForm";
            this.Text = "SEARCH";
            this.Load += new System.EventHandler(this.SubInfoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtAParty;
        private System.Windows.Forms.TextBox txtBParty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.UI.WinForms.BunifuDataGridView gvSearchResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label lbCellID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLac;
        private System.Windows.Forms.TextBox txtCellID;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnBrowseSearchFile;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
    }
}