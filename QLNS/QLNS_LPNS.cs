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
        private void buttonLPNS_Them_Click(object sender, EventArgs e)
        {
            comboBoxLPNS_MaSach.Text = "";
            buttonLPNS_Luu.Visible = true;
            textBoxLPNS_NhaXuatBan.Text = "";
            textBoxLPNS_TenDauSach.Text = "";
            textBoxLPNS_NamXuatBan.Text = "";
            textBoxLPNS_SoLuongNhap.Text = "";
            textBoxLPNS_DonGiaNhap.Text = "";
            buttonLPNS_Xoa.Enabled = false;
            buttonLPNS_CapNhat.Enabled = false;
            dataGridViewLPNS_ChiTietPhieuNhap.Enabled = false;
            buttonLPNS_Them.Text = "Hủy";
        }

        private void buttonLPNS_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void buttonLPNS_CapNhat_Click(object sender, EventArgs e)
        {

        }

        private void buttonLPNS_Luu_Click(object sender, EventArgs e)
        {
            buttonLPNS_Luu.Visible = false;
            buttonLPNS_Xoa.Enabled = true;
            buttonLPNS_CapNhat.Enabled = true;
            dataGridViewLPNS_ChiTietPhieuNhap.Enabled = true;
            buttonLPNS_Them.Text = "Thêm";
        }

        private void dataGridViewLPNS_ChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadComboboxMaSach()
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
            comboBoxLPNS_MaSach.DataSource = dt;
            comboBoxLPNS_MaSach.DisplayMember = "MaSach";
            comboBoxLPNS_MaSach.ValueMember = "MaSach";
            connection.Close();
        }
        private void panelLapPhieuNhapSach_Paint(object sender, PaintEventArgs e)
        {
            LoadComboboxMaSach();
        }

        private void comboBoxLPNS_MaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeSachMaSachTenDauSachNXB", connection);
            string id = comboBoxLPNS_MaSach.Text;
            SqlParameter p = new SqlParameter("MaSach", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tendausach = (string)reader["TenDauSach"].ToString();
                textBoxLPNS_TenDauSach.Text = tendausach;
                string nhaxuatban = (string)reader["TenNXB"].ToString();
                textBoxLPNS_NhaXuatBan.Text = nhaxuatban;
                string namxb = (string)reader["NamXB"].ToString();
                textBoxLPNS_NamXuatBan.Text = namxb;

            }

            connection.Close();
        }

    }
}
