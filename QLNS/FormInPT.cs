using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormInPT : Form
    {
        public FormInPT()
        {
            InitializeComponent();
        }
        private string str;

        public string Message
        {
            get { return str; }
            set { str = value; }
        }

        private void FormInPT_Load(object sender, EventArgs e)
        {
            string[] arrListStr = str.Split('+');

            MessageBox.Show("Vui lòng đợi! ", "Thông báo");
            this.reportViewerPT.RefreshReport();
            ReportParameter rpt1 = new ReportParameter("hoten", arrListStr[0]);
            this.reportViewerPT.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

            rpt1 = new ReportParameter("diachi", arrListStr[1]);
            this.reportViewerPT.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

            rpt1 = new ReportParameter("sdt", arrListStr[2]);
            this.reportViewerPT.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

            rpt1 = new ReportParameter("email", arrListStr[3]);
            this.reportViewerPT.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
            rpt1 = new ReportParameter("sotienthu", arrListStr[4]);
            this.reportViewerPT.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

            this.reportViewerPT.RefreshReport();
        }
    }
}
