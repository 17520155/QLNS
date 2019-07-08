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
        public void BCST_LoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeBaoCaoTon", connection);

            SqlParameter p = new SqlParameter("@Thang", Convert.ToInt32(comboBoxBCST_Thang.Text));
            command.Parameters.Add(p);
            p = new SqlParameter("@Nam", Convert.ToInt32(textBoxBCST_Nam.Text));
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            reportViewerBCST.ProcessingMode = ProcessingMode.Local;
            reportViewerBCST.LocalReport.ReportPath = "ReportBCST.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                //
                ReportParameter rpt1 = new ReportParameter("Thang", comboBoxBCST_Thang.Text);
                this.reportViewerBCST.LocalReport.SetParameters(new ReportParameter[] { rpt1 });

                rpt1 = new ReportParameter("Nam", textBoxBCST_Nam.Text);
                this.reportViewerBCST.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
                this.reportViewerBCST.RefreshReport();
                //
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSetBCST";
                rds.Value = ds.Tables[0];
                reportViewerBCST.LocalReport.DataSources.Clear();
                reportViewerBCST.LocalReport.DataSources.Add(rds);
                reportViewerBCST.RefreshReport();
                return;
            }
            else
            {
                MessageBox.Show("Chưa tạo báo cáo ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                reportViewerBCST.Clear();
                return;
            }
            connection.Close();


        }

        public void BCTS_Datagrid()
        {
            

        }

        private void buttonBCST_XemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connectionss = new SqlConnection();
                connectionss.ConnectionString = Global.ConnectionStr;
                connectionss.Open();
                SqlCommand Commands = new SqlCommand("KhoiTaoBaoCaoTon", connectionss);              
                Commands.CommandType = CommandType.StoredProcedure;
                Commands.ExecuteNonQuery();
                connectionss.Close();
            }
            catch
            {



                if (comboBoxBCST_Thang.Text.Trim() == "" || textBoxBCST_Nam.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("TaoBaoCaoTon", connection);
                    SqlParameter p = new SqlParameter("@Thang", Convert.ToInt32(comboBoxBCST_Thang.Text));
                    command.Parameters.Add(p);
                    p = new SqlParameter("@Nam", Convert.ToInt32(textBoxBCST_Nam.Text));
                    command.Parameters.Add(p);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    connection.Close();
                    BCST_LoadData();

                }
                catch
                {
                                  
                    BCST_LoadData();
                }
            }
        }
        public int thang = 0;
        private void panelBaoCaoSachTon_Paint(object sender, PaintEventArgs e)
        {
            if (thang < 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    comboBoxBCST_Thang.Items.Add((i + 1).ToString());
                    comboBoxBCST_Thang.DisplayMember = (i + 1).ToString();
                    thang++;
                }
                comboBoxBCST_Thang.SelectedIndex = 0;
            }
            else return;
        }
        private void buttonBaoCaoSachTon_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelBaoCaoSachTon.BringToFront();

                }
                else return;
            }
            else panelBaoCaoSachTon.BringToFront();
        }



    }
}
