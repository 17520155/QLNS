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
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewBCST.DataSource = dt;
            connection.Close();

        }
        private void buttonBCST_XemBaoCao_Click(object sender, EventArgs e)
        {
            /*SqlConnection connections = new SqlConnection();
            connections.ConnectionString = Global.ConnectionStr;
            connections.Open();
            SqlCommand Command = new SqlCommand("KhoiTaoBaoCaoTon", connections);
            SqlParameter p = new SqlParameter("@Thang", 5);
            Command.Parameters.Add(p);
            p = new SqlParameter("@Nam", 2019);
            Command.Parameters.Add(p);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            connections.Close();
            */
            if(comboBoxBCST_Thang.Text.Trim()=="" || textBoxBCST_Nam.Text.Trim()=="")
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
                    dataGridViewBCST.AutoGenerateColumns = false;
                    dataGridViewBCST.Columns[0].DataPropertyName = "STT";
                    dataGridViewBCST.Columns[1].DataPropertyName = "MaSach";
                    dataGridViewBCST.Columns[2].DataPropertyName = "TenDauSach";
                    dataGridViewBCST.Columns[3].DataPropertyName = "TenTheLoai";
                    dataGridViewBCST.Columns[4].DataPropertyName = "TonDau";
                    dataGridViewBCST.Columns[5].DataPropertyName = "PhatSinh";
                    dataGridViewBCST.Columns[6].DataPropertyName = "TonCuoi";
                    BCST_LoadData();




            }
            catch
            {
                dataGridViewBCST.AutoGenerateColumns = false;
                dataGridViewBCST.Columns[0].DataPropertyName = "STT";
                dataGridViewBCST.Columns[1].DataPropertyName = "MaSach";
                dataGridViewBCST.Columns[2].DataPropertyName = "TenDauSach";
                dataGridViewBCST.Columns[3].DataPropertyName = "TenTheLoai";
                dataGridViewBCST.Columns[4].DataPropertyName = "TonDau";
                dataGridViewBCST.Columns[5].DataPropertyName = "PhatSinh";
                dataGridViewBCST.Columns[6].DataPropertyName = "TonCuoi";
                BCST_LoadData();
            }
           

        }
        
        public int thang=0;
        private void panelBaoCaoSachTon_Paint(object sender, PaintEventArgs e)
        {
            if (thang < 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    comboBoxBCST_Thang.Items.Add((i+1).ToString());                    
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
