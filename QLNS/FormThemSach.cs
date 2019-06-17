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
    public partial class FormThemSach : Form
    {
        public FormThemSach()
        {
            InitializeComponent();
        }

        private void buttonThemMaDauSach_Click(object sender, EventArgs e)
        {
            Form formThemDauSach = new FormThemDauSach();
            formThemDauSach.ShowDialog();
            LoadComboboxMaNXB();
            LoadComboboxMaDauSach();
        }

        private void buttonThemMaNhaXuatBan_Click(object sender, EventArgs e)
        {
            Form formThemNhaXuatBan = new FormThemNhaXuatBan();
            formThemNhaXuatBan.ShowDialog();
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
            comboBoxMaDauSach.DataSource = dt;
            comboBoxMaDauSach.DisplayMember = "MaDauSach";
            comboBoxMaDauSach.ValueMember = "MaDauSach";
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
            comboBoxMaNhaXuatBan.DataSource = dt;
            comboBoxMaNhaXuatBan.DisplayMember = "MaNXB";
            comboBoxMaNhaXuatBan.ValueMember = "MaNXB";
            connection.Close();

        }

        private void comboBoxMaDauSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeDauSach4Bang", connection);
            string id = comboBoxMaDauSach.Text;
            SqlParameter p = new SqlParameter("MaDauSach", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tendausach = (string)reader["TenDauSach"].ToString();
                textBoxTenDauSach.Text = tendausach;
                string tentacgia = (string)reader["TenTacGia"].ToString();
                textBoxTenTacGia.Text = tentacgia;
                string tentheloai = (string)reader["TenTheLoai"].ToString();
                textBoxTenTheLoai.Text = tentheloai; 
            }

            connection.Close();
        }

        private void comboBoxMaNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeNXBTheoMa", connection);
            string id = comboBoxMaNhaXuatBan.Text;
            SqlParameter p = new SqlParameter("MaNXB", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tennhaxuatban = (string)reader["TenNXB"].ToString();
                textBoxTenNhaXuatBan.Text = tennhaxuatban;
                
            }

            connection.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (textBoxNamXuatBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm xuất bản");
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemSach", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@MaDauSach", comboBoxMaDauSach.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@MaNXB", comboBoxMaNhaXuatBan.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@NamXB", textBoxNamXuatBan.Text);
            command.Parameters.Add(p);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thêm Thành Công !");
                comboBoxMaDauSach.Text = "";
                textBoxTenDauSach.Text = "";
                textBoxTenTacGia.Text = "";
                textBoxTenTheLoai.Text = "";
                comboBoxMaNhaXuatBan.Text = "";
                textBoxTenNhaXuatBan.Text = "";
                textBoxNamXuatBan.Text = "";

            }

            connection.Close();
        }

        private void FormThemSach_Load(object sender, EventArgs e)
        {
            LoadComboboxMaDauSach();
            LoadComboboxMaNXB();

        }
    }
}
