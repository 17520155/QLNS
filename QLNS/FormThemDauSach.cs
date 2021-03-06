﻿using System;
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
    public partial class FormThemDauSach : Form
    {
        public FormThemDauSach()
        {
            InitializeComponent();
        }

        private void buttonThemMaTheLoai_Click(object sender, EventArgs e)
        {
            Form formThemTheLoai = new FormThemTheLoai();
            formThemTheLoai.ShowDialog();
            LoadComboboxTheLoai();

        }

        private void buttonThemMaTacGia_Click(object sender, EventArgs e)
        {
            Form formThemTacGia = new FormThemTacGia();
            formThemTacGia.ShowDialog();
            LoadComboboxTacGia();

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            if (dataGridViewQLS_DanhSachSach.RowCount > 0)
            {
                for (int i = 0; i <= dataGridViewQLS_DanhSachSach.RowCount - 1; i++)
                {
                    if (dataGridViewQLS_DanhSachSach.Rows[i].Cells[0].Value != null)
                    {

                        iCount++;

                    }
                    else continue;
                }
            }


            if (iCount > 0)
            {
                try
                {
                    if (textBoxTenDauSach.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập tên đầu sách!", "Thông Báo!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("ThemDauSachMoi", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@TenDauSach", textBoxTenDauSach.Text);
                    command.Parameters.Add(p);
                    p = new SqlParameter("@MaTheLoai", comboBoxMaTheLoai.Text);
                    command.Parameters.Add(p);
                    object obj = command.ExecuteScalar();
                    int id = Convert.ToInt32(obj);
                    for (int i = 0; i < dataGridViewQLS_DanhSachSach.Rows.Count; i++)
                    {
                        string MaTacGia = dataGridViewQLS_DanhSachSach.Rows[i].Cells[1].Value.ToString();
                        int tg = Convert.ToInt32(MaTacGia);
                        SqlCommand Command = new SqlCommand("ThemChiTietTacGia", connection);
                        Command.CommandType = CommandType.StoredProcedure;
                        p = new SqlParameter("@MaDauSach", id);
                        Command.Parameters.Add(p);
                        p = new SqlParameter("@MaTacGia", tg);
                        Command.Parameters.Add(p);
                        Command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm thành công!","Thông Báo!",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    textBoxTenDauSach.Text = "";
                    for (int i = 0; i < dataGridViewQLS_DanhSachSach.Rows.Count; i++)
                    {
                        dataGridViewQLS_DanhSachSach.Rows.Clear();
                    }


                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!","Thông Báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa có chi tiết tác giả!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadComboboxTheLoai()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTheLoai", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            
            comboBoxMaTheLoai.DisplayMember = dt.Columns[0].ToString();
            comboBoxMaTheLoai.ValueMember = dt.Columns[0].ToString();
            comboBoxMaTheLoai.DataSource = dt;
            connection.Close();

        }
        public void LoadComboboxTacGia()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTacGia", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            
            comboBoxMaTacGia.DisplayMember = dt.Columns[0].ToString();
            comboBoxMaTacGia.ValueMember = dt.Columns[0].ToString();
            comboBoxMaTacGia.DataSource = dt;
            connection.Close();

        }
        private void comboBoxMaTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTheLoaiTheoMa", connection);
            string id = comboBoxMaTheLoai.Text;
            SqlParameter p = new SqlParameter("MaTheLoai", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tentheloai = (string)reader["TenTheLoai"].ToString();
                textBoxTenTheLoai.Text = tentheloai;
                


            }

            connection.Close();
        }
        private void comboBoxMaTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTacGiaTheoMa", connection);
            string id = comboBoxMaTacGia.Text;
            SqlParameter p = new SqlParameter("MaTacGia", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tentacgia = (string)reader["TenTacGia"].ToString();
                textBoxTenTacGia.Text = tentacgia;



            }

            connection.Close();
        }

        private void FormThemDauSach_Load(object sender, EventArgs e)
        {
            LoadComboboxTheLoai();
            LoadComboboxTacGia();
        }

        private void buttonThemChiTietTacGia_Click(object sender, EventArgs e)
        {
            
           
            dataGridViewQLS_DanhSachSach.AllowUserToAddRows = false;
            dataGridViewQLS_DanhSachSach.Rows.Add(1);
            int indexRow = dataGridViewQLS_DanhSachSach.Rows.Count - 1;
            dataGridViewQLS_DanhSachSach[0, indexRow].Value = dataGridViewQLS_DanhSachSach.Rows.Count;
            dataGridViewQLS_DanhSachSach[1, indexRow].Value = comboBoxMaTacGia.Text;
            dataGridViewQLS_DanhSachSach[2, indexRow].Value = textBoxTenTacGia.Text;
            //kiem tra trung
            for (int i = 0; i < dataGridViewQLS_DanhSachSach.Rows.Count - 1; i++)
            {
                if (comboBoxMaTacGia.Text == dataGridViewQLS_DanhSachSach.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Đã tồn tại tác giả!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    dataGridViewQLS_DanhSachSach.Rows.Remove(dataGridViewQLS_DanhSachSach.Rows[i]);
                    dataGridViewQLS_DanhSachSach[0, indexRow-1].Value = dataGridViewQLS_DanhSachSach.Rows.Count;
                    return;
                }
            }



        }

        private void dataGridViewQLS_DanhSachSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonXoaChiTietTacGia_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                int RowIndex = dataGridViewQLS_DanhSachSach.CurrentRow.Index;
                dataGridViewQLS_DanhSachSach.Rows.RemoveAt(RowIndex);
            }
            else return;



        }

       
    }
    

}
