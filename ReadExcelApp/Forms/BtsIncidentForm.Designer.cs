
namespace ReadExcelApp.Forms
{
    partial class BtsIncidentForm
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
            this.lbSTI = new System.Windows.Forms.Label();
            this.lbTEUI = new System.Windows.Forms.Label();
            this.lbTAPF = new System.Windows.Forms.Label();
            this.lbTSRF = new System.Windows.Forms.Label();
            this.lbTSRDCS = new System.Windows.Forms.Label();
            this.lbTUDCS = new System.Windows.Forms.Label();
            this.lbTNFWLACS = new System.Windows.Forms.Label();
            this.lbTNWAACS = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSTI
            // 
            this.lbSTI.AutoSize = true;
            this.lbSTI.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSTI.Location = new System.Drawing.Point(53, 60);
            this.lbSTI.Name = "lbSTI";
            this.lbSTI.Size = new System.Drawing.Size(197, 25);
            this.lbSTI.TabIndex = 0;
            this.lbSTI.Text = "Selected Time Interval";
            // 
            // lbTEUI
            // 
            this.lbTEUI.AutoSize = true;
            this.lbTEUI.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTEUI.Location = new System.Drawing.Point(53, 93);
            this.lbTEUI.Name = "lbTEUI";
            this.lbTEUI.Size = new System.Drawing.Size(294, 25);
            this.lbTEUI.TabIndex = 1;
            this.lbTEUI.Text = "Total Enteries Under Investigation";
            // 
            // lbTAPF
            // 
            this.lbTAPF.AutoSize = true;
            this.lbTAPF.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTAPF.Location = new System.Drawing.Point(53, 126);
            this.lbTAPF.Name = "lbTAPF";
            this.lbTAPF.Size = new System.Drawing.Size(188, 25);
            this.lbTAPF.TabIndex = 2;
            this.lbTAPF.Text = "Total A Parties Found";
            // 
            // lbTSRF
            // 
            this.lbTSRF.AutoSize = true;
            this.lbTSRF.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTSRF.Location = new System.Drawing.Point(53, 159);
            this.lbTSRF.Name = "lbTSRF";
            this.lbTSRF.Size = new System.Drawing.Size(245, 25);
            this.lbTSRF.TabIndex = 3;
            this.lbTSRF.Text = "Total Seems Resident Found";
            // 
            // lbTSRDCS
            // 
            this.lbTSRDCS.AutoSize = true;
            this.lbTSRDCS.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTSRDCS.Location = new System.Drawing.Point(53, 192);
            this.lbTSRDCS.Name = "lbTSRDCS";
            this.lbTSRDCS.Size = new System.Drawing.Size(360, 25);
            this.lbTSRDCS.TabIndex = 4;
            this.lbTSRDCS.Text = "Total Seems Resident During Crime Scene";
            // 
            // lbTUDCS
            // 
            this.lbTUDCS.AutoSize = true;
            this.lbTUDCS.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTUDCS.Location = new System.Drawing.Point(53, 225);
            this.lbTUDCS.Name = "lbTUDCS";
            this.lbTUDCS.Size = new System.Drawing.Size(291, 25);
            this.lbTUDCS.TabIndex = 5;
            this.lbTUDCS.Text = "Total Unique During Crime Scene";
            // 
            // lbTNFWLACS
            // 
            this.lbTNFWLACS.AutoSize = true;
            this.lbTNFWLACS.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTNFWLACS.Location = new System.Drawing.Point(53, 258);
            this.lbTNFWLACS.Name = "lbTNFWLACS";
            this.lbTNFWLACS.Size = new System.Drawing.Size(435, 25);
            this.lbTNFWLACS.TabIndex = 6;
            this.lbTNFWLACS.Text = "Total Number Found Which Left After Crime Scene";
            // 
            // lbTNWAACS
            // 
            this.lbTNWAACS.AutoSize = true;
            this.lbTNWAACS.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTNWAACS.Location = new System.Drawing.Point(53, 291);
            this.lbTNWAACS.Name = "lbTNWAACS";
            this.lbTNWAACS.Size = new System.Drawing.Size(428, 25);
            this.lbTNWAACS.TabIndex = 7;
            this.lbTNWAACS.Text = "Total Number Which Appeared After Crime Scene";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbSTI);
            this.panel1.Controls.Add(this.lbTNWAACS);
            this.panel1.Controls.Add(this.lbTEUI);
            this.panel1.Controls.Add(this.lbTNFWLACS);
            this.panel1.Controls.Add(this.lbTAPF);
            this.panel1.Controls.Add(this.lbTUDCS);
            this.panel1.Controls.Add(this.lbTSRF);
            this.panel1.Controls.Add(this.lbTSRDCS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(50);
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 8;
            // 
            // BtsIncidentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "BtsIncidentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BtsIncidentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSTI;
        private System.Windows.Forms.Label lbTEUI;
        private System.Windows.Forms.Label lbTAPF;
        private System.Windows.Forms.Label lbTSRF;
        private System.Windows.Forms.Label lbTSRDCS;
        private System.Windows.Forms.Label lbTUDCS;
        private System.Windows.Forms.Label lbTNFWLACS;
        private System.Windows.Forms.Label lbTNWAACS;
        private System.Windows.Forms.Panel panel1;
    }
}