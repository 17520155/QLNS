namespace QLNS
{
    partial class FormInHD
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.LietKeCTHDTheoSoHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLNSDataSet3 = new QLNS.QLNSDataSet3();
            this.reportViewerinHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LietKeCTHDTheoSoHDTableAdapter = new QLNS.QLNSDataSet3TableAdapters.LietKeCTHDTheoSoHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LietKeCTHDTheoSoHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // LietKeCTHDTheoSoHDBindingSource
            // 
            this.LietKeCTHDTheoSoHDBindingSource.DataMember = "LietKeCTHDTheoSoHD";
            this.LietKeCTHDTheoSoHDBindingSource.DataSource = this.QLNSDataSet3;
            // 
            // QLNSDataSet3
            // 
            this.QLNSDataSet3.DataSetName = "QLNSDataSet3";
            this.QLNSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewerinHD
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LietKeCTHDTheoSoHDBindingSource;
            this.reportViewerinHD.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerinHD.LocalReport.ReportEmbeddedResource = "QLNS.ReportInHD.rdlc";
            this.reportViewerinHD.Location = new System.Drawing.Point(3, 4);
            this.reportViewerinHD.Name = "reportViewerinHD";
            this.reportViewerinHD.ServerReport.BearerToken = null;
            this.reportViewerinHD.Size = new System.Drawing.Size(740, 436);
            this.reportViewerinHD.TabIndex = 0;
            // 
            // LietKeCTHDTheoSoHDTableAdapter
            // 
            this.LietKeCTHDTheoSoHDTableAdapter.ClearBeforeFill = true;
            // 
            // FormInHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 440);
            this.Controls.Add(this.reportViewerinHD);
            this.Name = "FormInHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormInHD";
            this.Load += new System.EventHandler(this.FormInHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LietKeCTHDTheoSoHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerinHD;
        private System.Windows.Forms.BindingSource LietKeCTHDTheoSoHDBindingSource;
        private QLNSDataSet3 QLNSDataSet3;
        private QLNSDataSet3TableAdapters.LietKeCTHDTheoSoHDTableAdapter LietKeCTHDTheoSoHDTableAdapter;
    }
}