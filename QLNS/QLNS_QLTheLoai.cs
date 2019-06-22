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
         private void buttonQLK_ThemTheLoai_Click(object sender, EventArgs e)
         {
            kiemtraluu = 1;
            buttonQLK_XoaTheLoai.Enabled = false;
            buttonQLK_CapNhatTheLoai.Enabled = false;
            buttonQLK_QLTL_Luu.Visible = true;
            dataGridViewQLK_QLTL.Enabled = false;
            comboBoxQLK__MaTheLoai.Text = "";
            comboBoxQLK__MaTheLoai.Enabled = false;
            textBoxQLK__TenTheLoai.Text = "";
            buttonQLK_ThemTheLoai.Text = "Hủy";
         }

        private void buttonQLK_QLTL_Luu_Click(object sender, EventArgs e)
        {
            buttonQLK_XoaTheLoai.Enabled = true;
            buttonQLK_CapNhatTheLoai.Enabled = true;
            buttonQLK_QLTL_Luu.Visible = false;
            dataGridViewQLK_QLTL.Enabled = true;
            comboBoxQLK__MaTheLoai.Enabled = true;
            buttonQLK_ThemTheLoai.Text = "Thêm";
            if (textBoxQLK__TenTheLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tác giả");
                kiemtraluu = 0;
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemTheLoai", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p;
            p = new SqlParameter("@TenTheLoai", textBoxQLK__TenTheLoai.Text);
            command.Parameters.Add(p);

            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Thành công !");
                kiemtraluu = 0;
                textBoxQLK__TenTheLoai.Text = "";
                QLTL_LoadData();

            }
            connection.Close();
        }

        private void dataGridViewQLK_QLTL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                comboBoxLPTT_MaKH.Text = Convert.ToString(dataGridViewQLK_QLTL.CurrentRow.Cells[1].Value);
                textBoxQLK__TenTheLoai.Text = Convert.ToString(dataGridViewQLK_QLTL.CurrentRow.Cells[2].Value);
            }

        }

        public void QLTL_LoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTheLoai", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewQLK_QLTL.DataSource = dt;


            SqlCommand Command = new SqlCommand("LietKeTheLoai", connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            comboBoxQLK__MaTheLoai.DataSource = dt;
            comboBoxQLK__MaTheLoai.DisplayMember = "MaTheLoai";
            connection.Close();
        }

        private void buttonQLK_CapNhatTheLoai_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();

                SqlCommand command = new SqlCommand("SuaTheLoai", connection);

                command.CommandType = CommandType.StoredProcedure;

                int id = (int)dataGridViewQLK_QLTL.CurrentRow.Cells[1].Value;

                SqlParameter p = new SqlParameter("@MaTheLoai", id);
                command.Parameters.Add(p);

                p = new SqlParameter("@TenTheLoai", textBoxQLK__TenTheLoai.Text);
                command.Parameters.Add(p);

                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Cập Nhật Thành Công !");
                    QLTL_LoadData();

                }
                connection.Close();

            }
            else return;

            

        }

        private void buttonQLK_XoaTheLoai_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaTheLoaiTheoMa", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewQLK_QLTL.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("MaTheLoai", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa Thành Công !");
                        QLTL_LoadData();

                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi ! Vui lòng kiểm tra lại");
                }
            }
            else return;
        }

        private void groupBoxQLK_QLTL_Enter(object sender, EventArgs e)
        {
            dataGridViewQLK_QLTL.AutoGenerateColumns = false;
            dataGridViewQLK_QLTL.Columns[0].DataPropertyName = "STT";
            dataGridViewQLK_QLTL.Columns[1].DataPropertyName = "MaTheLoai";
            dataGridViewQLK_QLTL.Columns[2].DataPropertyName = "TenTheLoai";
            QLTL_LoadData();
        }
    }
}
