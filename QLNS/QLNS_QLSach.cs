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

        private void buttonQLS_Luu_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            comboBoxQLS_MaSach.Enabled = true;            
            buttonQLS_Luu.Visible = false;
            buttonQLS_Xoa.Enabled = true;
            buttonQLS_CapNhat.Enabled = true;
            buttonQLS_huy.Visible = false;
            buttonQLS_Them.Visible = true;
            dataGridViewQLS_DanhSachSach.Enabled = true;
            if (textBoxQLS_NamXuatBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm xuất bản");
                comboBoxQLS_MaSach.Text = "";
                comboBoxQLS_MaDauSach.Text = "";
                textBoxQLS_TenDauSach.Text = "";
                textBoxQLS_TacGia.Text = "";
                textBoxQLS_TheLoai.Text = "";
                comboBoxQLS_MaNhaXuatBan.Text = "";
                textBoxQLS_TenNhaXuarBan.Text = "";
                textBoxQLS_NamXuatBan.Text = "";
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemSach", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@MaDauSach", comboBoxQLS_MaDauSach.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@MaNXB", comboBoxQLS_MaNhaXuatBan.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@NamXB", textBoxQLS_NamXuatBan.Text);
            command.Parameters.Add(p);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thêm Thành Công !");
                QLNSLoaddata();
                comboBoxQLS_MaSach.Text = "";
                comboBoxQLS_MaDauSach.Text = "";
                textBoxQLS_TenDauSach.Text = "";
                textBoxQLS_TacGia.Text = "";
                textBoxQLS_TheLoai.Text = "";
                comboBoxQLS_MaNhaXuatBan.Text = "";
                textBoxQLS_TenNhaXuarBan.Text = "";
                textBoxQLS_NamXuatBan.Text = "";
            }

            connection.Close();
        }

        
        public void LoadComboboxMaDauSach()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeDauSach", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
           
            comboBoxQLS_MaDauSach.DisplayMember = dt.Columns[0].ToString();
            comboBoxQLS_MaDauSach.ValueMember = dt.Columns[0].ToString();
            comboBoxQLS_MaDauSach.DataSource = dt;
            connection.Close();

        }
        public void LoadComboboxMaNXB()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeNXB", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            
            comboBoxQLS_MaNhaXuatBan.DisplayMember = dt.Columns[0].ToString();
            comboBoxQLS_MaNhaXuatBan.ValueMember = dt.Columns[0].ToString();
            comboBoxQLS_MaNhaXuatBan.DataSource = dt;
            connection.Close();

        }

        private void buttonQLS_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaSachTheoMaSach", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewQLS_DanhSachSach.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("MaSach", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa Thành Công !");
                        QLNSLoaddata();

                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Lối! Vui Lòng kiểm tra lại");
                }
            }
            else return;
        }

        private void buttonQLS_CapNhat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();

                SqlCommand command = new SqlCommand("SuaThongTinSach", connection);

                command.CommandType = CommandType.StoredProcedure;

                int masach = (int)dataGridViewQLS_DanhSachSach.CurrentRow.Cells[1].Value;
                int manxb = Convert.ToInt32(comboBoxQLS_MaNhaXuatBan.Text);
                int madausach = Convert.ToInt32(comboBoxQLS_MaDauSach.Text);
                SqlParameter p = new SqlParameter("@MaSach", masach);
                command.Parameters.Add(p);
                p = new SqlParameter("@MaNXB", manxb);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", textBoxQLS_NamXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@MaDauSach", madausach);
                command.Parameters.Add(p);
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Cập nhật thông tin sách thành công !", "Thông báo!");
                    QLNSLoaddata();

                }
                connection.Close();

            }
            else return;

            
        }

        private void comboBoxQLS_MaDauSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeDauSach4Bang", connection);
            string id = comboBoxQLS_MaDauSach.Text;
            SqlParameter p = new SqlParameter("MaDauSach", Convert.ToInt32(id));
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tendausach = (string)reader["TenDauSach"].ToString();
                textBoxQLS_TenDauSach.Text = tendausach;
                string tentacgia = (string)reader["TenTacGia"].ToString();
                textBoxQLS_TacGia.Text = tentacgia;
                string tentheloai = (string)reader["TenTheLoai"].ToString();
                textBoxQLS_TheLoai.Text = tentheloai;
            }

            connection.Close();

        }

        private void comboBoxQLS_MaNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeNXBTheoMa", connection);
            string id = comboBoxQLS_MaNhaXuatBan.Text;
            SqlParameter p = new SqlParameter("MaNXB", Convert.ToInt32(id));
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tennhaxuatban = (string)reader["TenNXB"].ToString();
                textBoxQLS_TenNhaXuarBan.Text = tennhaxuatban;

            }

            connection.Close();

        }

        private void dataGridViewQLS_DanhSachSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                comboBoxQLS_MaSach.Text = Convert.ToString(dataGridViewQLS_DanhSachSach.CurrentRow.Cells[1].Value);
                textBoxQLS_TenDauSach.Text = Convert.ToString(dataGridViewQLS_DanhSachSach.CurrentRow.Cells[2].Value);
                textBoxQLS_TacGia.Text = Convert.ToString(dataGridViewQLS_DanhSachSach.CurrentRow.Cells[3].Value);
                textBoxQLS_TheLoai.Text = Convert.ToString(dataGridViewQLS_DanhSachSach.CurrentRow.Cells[4].Value);
                textBoxQLS_TenNhaXuarBan.Text = Convert.ToString(dataGridViewQLS_DanhSachSach.CurrentRow.Cells[5].Value);
                textBoxQLS_NamXuatBan.Text = Convert.ToString(dataGridViewQLS_DanhSachSach.CurrentRow.Cells[6].Value);
            }

        }
        public void QLNSLoaddata()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeMaSachTenSachTagiaTheLoaiNamXB", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
            dt.Rows[i]["STT"] = i + 1;

            dataGridViewQLS_DanhSachSach.DataSource = dt;
            QLNSLoadComboboxMaSach();


            connection.Close();
        }
        public void QLNSLoadComboboxMaSach()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand Command = new SqlCommand("LietKeSach", connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            comboBoxQLS_MaSach.DataSource = dt;
            comboBoxQLS_MaSach.DisplayMember = "MaSach";
            connection.Close();

        }
        private void panelQuanLySach_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {
                comboBoxQLS_MaSach.Enabled = true;
                comboBoxQLS_MaSach.Text = "";
                comboBoxQLS_MaDauSach.Text = "";
                textBoxQLS_TenDauSach.Text = "";
                textBoxQLS_TacGia.Text = "";
                textBoxQLS_TheLoai.Text = "";
                comboBoxQLS_MaNhaXuatBan.Text = "";
                textBoxQLS_TenNhaXuarBan.Text = "";
                textBoxQLS_NamXuatBan.Text = "";
                buttonQLS_Luu.Visible = false;
                buttonQLS_Xoa.Enabled = true;
                buttonQLS_CapNhat.Enabled = true;
                buttonQLS_huy.Visible = false;
                buttonQLS_Them.Visible = true;
                dataGridViewQLS_DanhSachSach.Enabled = true;
            }

            dataGridViewQLS_DanhSachSach.AutoGenerateColumns = false;
            dataGridViewQLS_DanhSachSach.Columns[0].DataPropertyName = "STT";
            dataGridViewQLS_DanhSachSach.Columns[1].DataPropertyName = "MaSach";
            dataGridViewQLS_DanhSachSach.Columns[2].DataPropertyName = "TenDauSach";
            dataGridViewQLS_DanhSachSach.Columns[3].DataPropertyName = "TenTacGia";
            dataGridViewQLS_DanhSachSach.Columns[4].DataPropertyName = "TenTheLoai";
            dataGridViewQLS_DanhSachSach.Columns[5].DataPropertyName = "TenNXB";
            dataGridViewQLS_DanhSachSach.Columns[6].DataPropertyName = "NamXB";
            QLNSLoaddata();
            LoadComboboxMaNXB();
            LoadComboboxMaDauSach();
           

        }
        private void buttonQuanLySach_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    comboBoxQLS_MaSach.Enabled = true;
                    comboBoxQLS_MaSach.Text = "";
                    comboBoxQLS_MaDauSach.Text = "";
                    textBoxQLS_TenDauSach.Text = "";
                    textBoxQLS_TacGia.Text = "";
                    textBoxQLS_TheLoai.Text = "";
                    comboBoxQLS_MaNhaXuatBan.Text = "";
                    textBoxQLS_TenNhaXuarBan.Text = "";
                    textBoxQLS_NamXuatBan.Text = "";
                    buttonQLS_Luu.Visible = false;
                    buttonQLS_Xoa.Enabled = true;
                    buttonQLS_CapNhat.Enabled = true;
                    buttonQLS_huy.Visible = false;
                    buttonQLS_Them.Visible = true;
                    dataGridViewQLS_DanhSachSach.Enabled = true;
                    panelQuanLySach.BringToFront();

                }
                else return;
            }
            else panelQuanLySach.BringToFront();


        }

        private void buttonQLS_Them_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            comboBoxQLS_MaSach.Enabled = false;
            comboBoxQLS_MaSach.Text = "";
            comboBoxQLS_MaDauSach.Text = "";
            textBoxQLS_TenDauSach.Text = "";
            textBoxQLS_TacGia.Text = "";
            textBoxQLS_TheLoai.Text = "";
            comboBoxQLS_MaNhaXuatBan.Text = "";
            textBoxQLS_TenNhaXuarBan.Text = "";
            textBoxQLS_NamXuatBan.Text = "";
            buttonQLS_Luu.Visible = true;
            buttonQLS_Xoa.Enabled = false;
            buttonQLS_CapNhat.Enabled = false;
            buttonQLS_huy.Visible = true;
            buttonQLS_Them.Visible = false;
            dataGridViewQLS_DanhSachSach.Enabled = false;

        }
        private void buttonQLS_huy_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            comboBoxQLS_MaSach.Enabled = true;
            comboBoxQLS_MaSach.Text = "";
            comboBoxQLS_MaDauSach.Text = "";
            textBoxQLS_TenDauSach.Text = "";
            textBoxQLS_TacGia.Text = "";
            textBoxQLS_TheLoai.Text = "";
            comboBoxQLS_MaNhaXuatBan.Text = "";
            textBoxQLS_TenNhaXuarBan.Text = "";
            textBoxQLS_NamXuatBan.Text = "";
            buttonQLS_Luu.Visible = false;
            buttonQLS_Xoa.Enabled = true;
            buttonQLS_CapNhat.Enabled = true;
            buttonQLS_huy.Visible = false;
            buttonQLS_Them.Visible = true;
            dataGridViewQLS_DanhSachSach.Enabled = true;

        }
    }
}
