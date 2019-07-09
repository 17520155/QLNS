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
        private void buttonQLK_QLNXB_Luu_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            buttonQLK_XoaNhaXuatBan.Enabled = true;
            buttonQLK_CapNhatNhaXuatBan.Enabled = true;
            buttonQLK_QLNXB_Luu.Visible = false;
            dataGridViewQLK_QLNXB.Enabled = true;
            
            comboBoxQLK_MaNhaXuatBan.Enabled = true;
            
            buttonQLK_ThemNhaXuatBan.Visible = true;
            buttonQLK_QLTL_huynxb.Visible = false;
            //
            if (textBoxQLK_TenNhaXuatBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhà xuất bản");
                kiemtraluu = 0;
                comboBoxQLK_MaNhaXuatBan.Text = "";
                textBoxQLK_TenNhaXuatBan.Text = "";
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemNXB", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p;
            p = new SqlParameter("@TenNXB", textBoxQLK_TenNhaXuatBan.Text);
            command.Parameters.Add(p);

            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Thành công !");
                kiemtraluu = 0;
                textBoxQLK_TenNhaXuatBan.Text = "";
                QLNXB_LoadData();
                comboBoxQLK_MaNhaXuatBan.Text = "";
                textBoxQLK_TenNhaXuatBan.Text = "";

            }

            connection.Close();


        }

        private void buttonQLK_ThemNhaXuatBan_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            buttonQLK_XoaNhaXuatBan.Enabled = false;
            buttonQLK_CapNhatNhaXuatBan.Enabled = false;
            buttonQLK_QLNXB_Luu.Visible = true;
            dataGridViewQLK_QLNXB.Enabled = false;
            comboBoxQLK_MaNhaXuatBan.Text = "";
            comboBoxQLK_MaNhaXuatBan.Enabled = false;
            textBoxQLK_TenNhaXuatBan.Text = "";
            buttonQLK_ThemNhaXuatBan.Visible =false;
            buttonQLK_QLTL_huynxb.Visible = true;

        }

        private void dataGridViewQLK_QLNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                comboBoxQLK_MaNhaXuatBan.Text = Convert.ToString(dataGridViewQLK_QLNXB.CurrentRow.Cells[1].Value);
                textBoxQLK_TenNhaXuatBan.Text = Convert.ToString(dataGridViewQLK_QLNXB.CurrentRow.Cells[2].Value);
            }

        }

        public void QLNXB_LoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeNXB", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewQLK_QLNXB.DataSource = dt;


            SqlCommand Command = new SqlCommand("LietKeNXB", connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            comboBoxQLK_MaNhaXuatBan.DataSource = dt;
            comboBoxQLK_MaNhaXuatBan.DisplayMember = "MaNXB";
            connection.Close();
        }

        private void buttonQLK_XoaNhaXuatBan_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaNXBTheoMa", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewQLK_QLNXB.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("MaNXB", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa Thành Công !");
                        QLNXB_LoadData();

                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
                }
            }
            else return;

        }

        private void buttonQLK_CapNhatNhaXuatBan_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();

                SqlCommand command = new SqlCommand("SuaNXB", connection);

                command.CommandType = CommandType.StoredProcedure;

                int id = (int)dataGridViewQLK_QLNXB.CurrentRow.Cells[1].Value;

                SqlParameter p = new SqlParameter("@MaNXB", id);
                command.Parameters.Add(p);

                p = new SqlParameter("@TenNXB", textBoxQLK_TenNhaXuatBan.Text);
                command.Parameters.Add(p);

                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Cập Nhật Thành Công !");
                    QLNXB_LoadData();

                }
                connection.Close();

            }
            else return;
            

        }

        private void groupBoxQLK_QLNXB_Enter(object sender, EventArgs e)
        {
            dataGridViewQLK_QLNXB.AutoGenerateColumns = false;
            dataGridViewQLK_QLNXB.Columns[0].DataPropertyName = "STT";
            dataGridViewQLK_QLNXB.Columns[1].DataPropertyName = "MaNXB";
            dataGridViewQLK_QLNXB.Columns[2].DataPropertyName = "TenNXB";
            QLNXB_LoadData();

        }
        private void buttonQLK_QLTL_huynxb_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            buttonQLK_XoaNhaXuatBan.Enabled = true;
            buttonQLK_CapNhatNhaXuatBan.Enabled = true;
            buttonQLK_QLNXB_Luu.Visible = false;
            dataGridViewQLK_QLNXB.Enabled = true;
            comboBoxQLK_MaNhaXuatBan.Text = "";
            comboBoxQLK_MaNhaXuatBan.Enabled = true;
            textBoxQLK_TenNhaXuatBan.Text = "";
            buttonQLK_ThemNhaXuatBan.Visible = true;
            buttonQLK_QLTL_huynxb.Visible = false;
        }
    }
}