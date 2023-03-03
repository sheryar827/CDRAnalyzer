namespace ReadExcelApp.Forms
{
    partial class IMEIForm
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
            this.gvImeiUsedDate = new System.Windows.Forms.DataGridView();
            this.pcIMEIUsed = new LiveCharts.WinForms.PieChart();
            this.labelA_Num = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvImeiUsedDate)).BeginInit();
            this.SuspendLayout();
            // 
            // gvImeiUsedDate
            // 
            this.gvImeiUsedDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvImeiUsedDate.BackgroundColor = System.Drawing.Color.White;
            this.gvImeiUsedDate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvImeiUsedDate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvImeiUsedDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvImeiUsedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvImeiUsedDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.gvImeiUsedDate.EnableHeadersVisualStyles = false;
            this.gvImeiUsedDate.GridColor = System.Drawing.Color.Black;
            this.gvImeiUsedDate.Location = new System.Drawing.Point(0, 0);
            this.gvImeiUsedDate.Name = "gvImeiUsedDate";
            this.gvImeiUsedDate.RowHeadersVisible = false;
            this.gvImeiUsedDate.Size = new System.Drawing.Size(239, 647);
            this.gvImeiUsedDate.TabIndex = 0;
            // 
            // pcIMEIUsed
            // 
            this.pcIMEIUsed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcIMEIUsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcIMEIUsed.Location = new System.Drawing.Point(239, 0);
            this.pcIMEIUsed.Name = "pcIMEIUsed";
            this.pcIMEIUsed.Size = new System.Drawing.Size(859, 647);
            this.pcIMEIUsed.TabIndex = 30;
            this.pcIMEIUsed.Text = "pieChart1";
            // 
            // labelA_Num
            // 
            this.labelA_Num.AutoSize = true;
            this.labelA_Num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelA_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelA_Num.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA_Num.ForeColor = System.Drawing.Color.White;
            this.labelA_Num.Location = new System.Drawing.Point(239, 0);
            this.labelA_Num.Name = "labelA_Num";
            this.labelA_Num.Padding = new System.Windows.Forms.Padding(5);
            this.labelA_Num.Size = new System.Drawing.Size(10, 41);
            this.labelA_Num.TabIndex = 40;
            // 
            // IMEIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1098, 647);
            this.Controls.Add(this.labelA_Num);
            this.Controls.Add(this.pcIMEIUsed);
            this.Controls.Add(this.gvImeiUsedDate);
            this.Name = "IMEIForm";
            this.Text = "IMEI";
            this.Load += new System.EventHandler(this.IMEIForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvImeiUsedDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gvImeiUsedDate;
        private LiveCharts.WinForms.PieChart pcIMEIUsed;
        private System.Windows.Forms.Label labelA_Num;
    }
}