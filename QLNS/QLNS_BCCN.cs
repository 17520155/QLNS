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
    public partial class FormQLNS : Form
    {
        public void BCCN_LoadData()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeBaoCaoCongNo", connection);

            SqlParameter p = new SqlParameter("@Thang", Convert.ToInt32(comboBoxBCCN_Thang.Text));
            command.Parameters.Add(p);
            p = new SqlParameter("@Nam", Convert.ToInt32(textBoxBCCN_Nam.Text));
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            reportViewerBCCN.ProcessingMode = ProcessingMode.Local;
            reportViewerBCCN.LocalReport.ReportPath = "ReportBCCN.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                //
                ReportParameter rpt1 = new ReportParameter("Thang", comboBoxBCCN_Thang.Text);
                this.reportViewerBCCN.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

                rpt1 = new ReportParameter("Nam", textBoxBCCN_Nam.Text);
                this.reportViewerBCCN.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
                this.reportViewerBCCN.RefreshReport();
                //

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSetBCCN";
                rds.Value = ds.Tables[0];
                reportViewerBCCN.LocalReport.DataSources.Clear();
                reportViewerBCCN.LocalReport.DataSources.Add(rds);
                reportViewerBCCN.RefreshReport();
                return;
            }
            else
            {
                MessageBox.Show("Chưa tạo báo cáo!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                reportViewerBCCN.Clear();
                return;
            }
            connection.Close();




        }

        private void buttonBCCN_XemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connectionss = new SqlConnection();
                connectionss.ConnectionString = Global.ConnectionStr;
                connectionss.Open();
                SqlCommand Commands = new SqlCommand("KhoiTaoBaoCaoCongNo", connectionss);
                Commands.CommandType = CommandType.StoredProcedure;
                Commands.ExecuteNonQuery();
                connectionss.Close();
            }
            catch
            {



                if (comboBoxBCCN_Thang.Text.Trim() == "" || textBoxBCCN_Nam.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {


                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("TaoBaoCaoCongNo", connection);
                    SqlParameter p = new SqlParameter("@Thang", Convert.ToInt32(comboBoxBCCN_Thang.Text));
                    command.Parameters.Add(p);
                    p = new SqlParameter("@Nam", Convert.ToInt32(textBoxBCCN_Nam.Text));
                    command.Parameters.Add(p);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    connection.Close();
                    BCCN_LoadData();

                }
                catch
                {
                    //int thang = BCTS_LietKeThang(Convert.ToInt32(comboBoxBCST_Thang.Text));
                    //int nam = BCTS_LietKeNam(Convert.ToInt32(textBoxBCST_Nam.Text));                    
                    BCCN_LoadData();
                }
            }

        }
        public int thangs = 0;
        private void panelBaoCaoCongNo_Paint(object sender, PaintEventArgs e)
        {
            if (thangs < 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    comboBoxBCCN_Thang.Items.Add((i + 1).ToString());
                    comboBoxBCCN_Thang.DisplayMember = (i + 1).ToString();
                    thangs++;
                }
                comboBoxBCCN_Thang.SelectedIndex = 0;
            }
            else return;
        }
    }
}
