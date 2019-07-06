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
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewBCCN.DataSource = dt;
            if (dataGridViewBCCN.Rows.Count == 1)
            {
                string str = "Chưa tạo báo cáo tháng " + comboBoxBCCN_Thang.Text + " năm " + textBoxBCCN_Nam.Text;
                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            connection.Close();

        }
        public void BCCN_Datagridview()
        {
            dataGridViewBCCN.AutoGenerateColumns = false;
            dataGridViewBCCN.Columns[0].DataPropertyName = "STT";
            dataGridViewBCCN.Columns[1].DataPropertyName = "MaKH";
            dataGridViewBCCN.Columns[2].DataPropertyName = "HoTenKH";
            dataGridViewBCCN.Columns[3].DataPropertyName = "DienThoai";
            dataGridViewBCCN.Columns[4].DataPropertyName = "NoDau";
            dataGridViewBCCN.Columns[5].DataPropertyName = "PhatSinh";
            dataGridViewBCCN.Columns[6].DataPropertyName = "NoCuoi";
            BCCN_LoadData();

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
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    /*SqlConnection connections = new SqlConnection();
                    connections.ConnectionString = Global.ConnectionStr;
                    connections.Open();
                    SqlCommand Command = new SqlCommand("XoaBaoCaoTon", connections);
                    SqlParameter p = new SqlParameter("@Thang", Convert.ToInt32(comboBoxBCST_Thang.Text));
                    Command.Parameters.Add(p);
                    p = new SqlParameter("@Nam", Convert.ToInt32(textBoxBCST_Nam.Text));
                    Command.Parameters.Add(p);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.ExecuteNonQuery();
                    connections.Close();*/

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
                    BCCN_Datagridview();

                }
                catch
                {
                    //int thang = BCTS_LietKeThang(Convert.ToInt32(comboBoxBCST_Thang.Text));
                    //int nam = BCTS_LietKeNam(Convert.ToInt32(textBoxBCST_Nam.Text));                    
                    BCCN_Datagridview();
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
