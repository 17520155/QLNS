using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormInHD : Form
    {
        public FormInHD()
        {
            InitializeComponent();
        }
        private string str;
        
        public string Message
        {
            get { return str; }
            set { str = value; }
        }
        

        private void FormInHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLNSDataSet3.LietKeCTHDTheoSoHD' table. You can move, or remove it, as needed.
            //this.LietKeCTHDTheoSoHDTableAdapter.Fill(this.QLNSDataSet3.LietKeCTHDTheoSoHD);
            //_message
            string[] arrListStr = str.Split('.');

            MessageBox.Show("Vui lòng đợi! ", "Thông báo! ");
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeCTHDTheoSoHD", connection);
            SqlParameter p = new SqlParameter("@SoHD", Convert.ToInt32(arrListStr[0]));

            command.Parameters.Add(p);            
            command.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            reportViewerinHD.ProcessingMode = ProcessingMode.Local;
            reportViewerinHD.LocalReport.ReportPath = "ReportInHD.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                //
                ReportParameter rpt1 = new ReportParameter("tenkh", arrListStr[1]);
                this.reportViewerinHD.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

                rpt1 = new ReportParameter("tongtien", arrListStr[2]);
                this.reportViewerinHD.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

                rpt1 = new ReportParameter("sotientra", arrListStr[3]);
                this.reportViewerinHD.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

                rpt1 = new ReportParameter("conlai", arrListStr[4]);
                this.reportViewerinHD.LocalReport.SetParameters(new ReportParameter[] { rpt1 });


                this.reportViewerinHD.RefreshReport();
                //

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSetInHD";
                rds.Value = ds.Tables[0];
                reportViewerinHD.LocalReport.DataSources.Clear();
                reportViewerinHD.LocalReport.DataSources.Add(rds);
                reportViewerinHD.RefreshReport();
                this.reportViewerinHD.RefreshReport();
            }
        }


    }
}
