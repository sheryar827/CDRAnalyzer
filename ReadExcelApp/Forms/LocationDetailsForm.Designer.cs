namespace ReadExcelApp.Forms
{
    partial class LocationDetailsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLocation = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvLocationDetails = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnSubInfo = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.panelLocation.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLocationDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLocation
            // 
            this.panelLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.panelLocation.Controls.Add(this.btnExportExcel);
            this.panelLocation.Controls.Add(this.btnSubInfo);
            this.panelLocation.Controls.Add(this.btnClose);
            this.panelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLocation.ForeColor = System.Drawing.Color.White;
            this.panelLocation.Location = new System.Drawing.Point(0, 0);
            this.panelLocation.Name = "panelLocation";
            this.panelLocation.Padding = new System.Windows.Forms.Padding(10);
            this.panelLocation.Size = new System.Drawing.Size(606, 56);
            this.panelLocation.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(521, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gvLocationDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(606, 199);
            this.panel1.TabIndex = 3;
            // 
            // gvLocationDetails
            // 
            this.gvLocationDetails.AllowCustomTheming = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.gvLocationDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gvLocationDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLocationDetails.BackgroundColor = System.Drawing.Color.White;
            this.gvLocationDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvLocationDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvLocationDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLocationDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gvLocationDetails.ColumnHeadersHeight = 40;
            this.gvLocationDetails.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.gvLocationDetails.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvLocationDetails.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvLocationDetails.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.gvLocationDetails.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvLocationDetails.CurrentTheme.BackColor = System.Drawing.Color.Teal;
            this.gvLocationDetails.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gvLocationDetails.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.gvLocationDetails.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gvLocationDetails.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvLocationDetails.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.gvLocationDetails.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvLocationDetails.CurrentTheme.Name = null;
            this.gvLocationDetails.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.gvLocationDetails.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvLocationDetails.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvLocationDetails.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.gvLocationDetails.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLocationDetails.DefaultCellStyle = dataGridViewCellStyle15;
            this.gvLocationDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLocationDetails.EnableHeadersVisualStyles = false;
            this.gvLocationDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.gvLocationDetails.HeaderBackColor = System.Drawing.Color.Teal;
            this.gvLocationDetails.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvLocationDetails.HeaderForeColor = System.Drawing.Color.White;
            this.gvLocationDetails.Location = new System.Drawing.Point(10, 10);
            this.gvLocationDetails.Name = "gvLocationDetails";
            this.gvLocationDetails.RowHeadersVisible = false;
            this.gvLocationDetails.RowTemplate.Height = 40;
            this.gvLocationDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLocationDetails.Size = new System.Drawing.Size(586, 179);
            this.gvLocationDetails.TabIndex = 0;
            this.gvLocationDetails.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Teal;
            this.gvLocationDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLocationDetails_CellClick);
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 15;
            this.bunifuElipse.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelLocation;
            this.bunifuDragControl1.Vertical = true;
            // 
            // btnSubInfo
            // 
            this.btnSubInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubInfo.FlatAppearance.BorderSize = 0;
            this.btnSubInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubInfo.Image = global::ReadExcelApp.Properties.Resources.user;
            this.btnSubInfo.Location = new System.Drawing.Point(13, 12);
            this.btnSubInfo.Name = "btnSubInfo";
            this.btnSubInfo.Size = new System.Drawing.Size(75, 30);
            this.btnSubInfo.TabIndex = 3;
            this.btnSubInfo.Tag = "Subscriber Info";
            this.btnSubInfo.UseVisualStyleBackColor = true;
            this.btnSubInfo.Click += new System.EventHandler(this.btnSubInfo_Click);
            this.btnSubInfo.MouseHover += new System.EventHandler(this.btnSubInfo_MouseHover);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::ReadExcelApp.Properties.Resources.exportEXCEL;
            this.btnExportExcel.Location = new System.Drawing.Point(94, 13);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 30);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnExportExcel.MouseHover += new System.EventHandler(this.btnExportExcel_MouseHover);
            // 
            // LocationDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(606, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLocation);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocationDetailsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocationDetailsForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LocationDetailsForm_Load);
            this.panelLocation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLocationDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLocation;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Button btnClose;
        private Bunifu.UI.WinForms.BunifuDataGridView gvLocationDetails;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnSubInfo;
    }
}