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
        public void LPHD_LoadComboboxMaKH()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeKhachHang", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);

            comboBoxLHDBS_MaKH.DataSource = dt;
            comboBoxLHDBS_MaKH.DisplayMember = "MaKH";
            comboBoxLHDBS_MaKH.ValueMember = "MaKH";

            connection.Close();

        }
        private void comboBoxLHDBS_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeKhachHangTheoMaKH", connection);
            int id = Convert.ToInt32(comboBoxLHDBS_MaKH.Text);
            SqlParameter p = new SqlParameter("@MaKH",(id));
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string hotenkh = (string)reader["HoTenKH"].ToString();
                textBoxLHDBS_TenKH.Text = hotenkh;                
                string DienThoai = (string)reader["DienThoai"].ToString();
                textBoxLHDBS_DienThoai.Text = DienThoai;

            }

            connection.Close();

        }
        public void LHDBS_LoadComboboxMaSach()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeSach", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            comboBoxLHDBS_MaSach.DataSource = dt;
            comboBoxLHDBS_MaSach.DisplayMember = "MaSach";
            comboBoxLHDBS_MaSach.ValueMember = "MaSach";
            connection.Close();
        }
        private void comboBoxLHDBS_MaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTenSachTagiaTheLoaiNamXBTheoMaSach", connection);
            int id = Convert.ToInt32(comboBoxLHDBS_MaSach.Text);
            SqlParameter p = new SqlParameter("@MaSach", (id));
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tendausach = (string)reader["TenDauSach"].ToString();
                textBoxLHDBS_TenDauSach.Text = tendausach;
                string tennxb = (string)reader["TenNXB"].ToString();
                textBoxLHDBS_NhaXuatBan.Text = tennxb;
                string tentheloai = (string)reader["TenTheLoai"].ToString();
                textBoxLHDBS_TheLoai.Text = tentheloai;
                string namxb = (string)reader["NamXB"].ToString();
                textBoxLHDBS_NamXuatBan.Text = namxb;
            }
            connection.Close();
        }

        private void buttonLHDBS_Luu_Click(object sender, EventArgs e)
        {
            buttonLHDBS_Luu.Visible = false;
            buttonLHDBS_Them.Name = "Thêm";
            buttonLHDBS_Xoa.Enabled = true;
            buttonLHDBS_CapNhat.Enabled = true;
            dataGridViewLHDBS_DanhSachMua.Enabled = true ;
            if (textBoxLHDBS_SoLuong.Text == ""|| textBoxLHDBS_DonGiaBan.Text =="" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();
                connection.Close();
            }
        }

        private void buttonLHDBS_Them_Click(object sender, EventArgs e)
        {
            textBoxLHDBS_SoLuong.Text = "";
            comboBoxLHDBS_MaKH.Text = "";
            textBoxLHDBS_TenKH.Text = "";
            textBoxLHDBS_DienThoai.Text = "";
            comboBoxLHDBS_MaSach.Text = "";
            textBoxLHDBS_TenDauSach.Text = "";
            textBoxLHDBS_NamXuatBan.Text = "";
            textBoxLHDBS_TheLoai.Text = "";
            textBoxLHDBS_NhaXuatBan.Text = "";
            textBoxLHDBS_DonGiaBan.Text = "";
            buttonLHDBS_Luu.Visible = true;
            buttonLHDBS_Them.Name = "Hủy";
            buttonLHDBS_Xoa.Enabled = false;
            buttonLHDBS_CapNhat.Enabled = false;
            dataGridViewLHDBS_DanhSachMua.Enabled = false;


        }

        private void buttonLHDBS_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void buttonLHDBS_CapNhat_Click(object sender, EventArgs e)
        {

        }

        private void panelLapHoaDonBanSach_Paint(object sender, PaintEventArgs e)
        {
            LHDBS_LoadComboboxMaSach();

        }
        private void dataGridViewLHDBS_DanhSachMua_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
