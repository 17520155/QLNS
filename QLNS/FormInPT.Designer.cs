namespace QLNS
{
    partial class FormInPT
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
            this.reportViewerPT = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPT
            // 
            this.reportViewerPT.LocalReport.ReportEmbeddedResource = "QLNS.ReportPhieuThu.rdlc";
            this.reportViewerPT.Location = new System.Drawing.Point(3, 4);
            this.reportViewerPT.Name = "reportViewerPT";
            this.reportViewerPT.ServerReport.BearerToken = null;
            this.reportViewerPT.Size = new System.Drawing.Size(798, 447);
            this.reportViewerPT.TabIndex = 0;
            // 
            // FormInPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerPT);
            this.Name = "FormInPT";
            this.Text = "FormInPT";
            this.Load += new System.EventHandler(this.FormInPT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPT;
    }
}