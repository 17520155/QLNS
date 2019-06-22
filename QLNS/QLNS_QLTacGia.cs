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
        private void buttonQLK_ThemTacGia_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            buttonQLK_XoaTacGia.Enabled = false;
            buttonQLK_CapNhatTacGia.Enabled = false;
            buttonQLK_QLTG_Luu.Visible = true;
            dataGridViewQLK_QLTG.Enabled = false;
            comboBoxQLK_MaTacGia.Text = "";
            comboBoxQLK_MaTacGia.Enabled = false;
            textBoxQLK_TenTacGia.Text = "";
            buttonQLK_ThemTacGia.Text = "Hủy";
        }
        private void buttonQLK_QLTG_Luu_Click(object sender, EventArgs e)
        {
            buttonQLK_XoaTacGia.Enabled = true;
            buttonQLK_CapNhatTacGia.Enabled = true;
            buttonQLK_QLTG_Luu.Visible = false;
            dataGridViewQLK_QLTG.Enabled = true;
            comboBoxQLK_MaTacGia.Enabled = true;
            buttonQLK_ThemTacGia.Text = "Thêm";
            //
            if (textBoxQLK_TenTacGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tác giả");
                kiemtraluu = 0;
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemTacGia", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p;
            p = new SqlParameter("@TenTacGia", textBoxQLK_TenTacGia.Text);
            command.Parameters.Add(p);

            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Thành công !");
                kiemtraluu = 0;
                textBoxQLK_TenTacGia.Text = "";
                QLTG_LoadData();

            }

            connection.Close();

        }
        public void QLTG_LoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTacGia", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewQLK_QLTG.DataSource = dt;


            SqlCommand Command = new SqlCommand("LietKeTacGia", connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            comboBoxQLK_MaTacGia.DataSource = dt;
            comboBoxQLK_MaTacGia.DisplayMember = "MaTacGia";
            connection.Close();
        }

        private void groupBoxQLK_QLTG_Enter(object sender, EventArgs e)
        {
            dataGridViewQLK_QLTG.AutoGenerateColumns = false;
            dataGridViewQLK_QLTG.Columns[0].DataPropertyName = "STT";
            dataGridViewQLK_QLTG.Columns[1].DataPropertyName = "MaTacGia";
            dataGridViewQLK_QLTG.Columns[2].DataPropertyName = "TenTacGia";
            QLTG_LoadData();
        }
        private void dataGridViewQLK_QLTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                comboBoxQLK_MaTacGia.Text = Convert.ToString(dataGridViewQLK_QLTG.CurrentRow.Cells[1].Value);
                textBoxQLK_TenTacGia.Text = Convert.ToString(dataGridViewQLK_QLTG.CurrentRow.Cells[2].Value);
            }

        }
        private void buttonQLK_XoaTacGia_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaTheoMaTacGia", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewQLK_QLTG.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("MaTacGia", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa Thành Công !");
                        QLTG_LoadData();

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
        private void buttonQLK_CapNhatTacGia_Click(object sender, EventArgs e)
        {

            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();

                SqlCommand command = new SqlCommand("SuaTacGia", connection);

                command.CommandType = CommandType.StoredProcedure;

                int id = (int)dataGridViewQLK_QLTG.CurrentRow.Cells[1].Value;

                SqlParameter p = new SqlParameter("@MaTacGia", id);
                command.Parameters.Add(p);

                p = new SqlParameter("@TenTacGia", textBoxQLK_TenTacGia.Text);
                command.Parameters.Add(p);

                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Cập Nhật Thành Công !");
                    QLTG_LoadData();

                }
                connection.Close();

            }
            else return;

           
        }
    }
}

