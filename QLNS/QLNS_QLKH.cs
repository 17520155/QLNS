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
    public partial class FormQLNS : Form
    {

        private void panelQuanLyKhachHang_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {
                comboBoxQLKH_MaKH.Enabled = true;
                buttonQLKH_Luu.Visible = false;
                buttonQLKH_Xoa.Enabled = true;
                buttonQLKH_CapNhat.Enabled = true;
                buttonQLKH_huy.Visible = false;
                buttonQLKH_Them.Visible = true;
                //buttonQLKH_Them.Text = "Thêm";
                dataGridViewQLKH_DanhSachKH.Enabled = true;
                textBoxQLKH_DiaChi.Text = "";
                textBoxQLKH_Email.Text = "";
                textBoxQLKH_SDT.Text = "";
                textBoxQLKH_TenKH.Text = "";
                comboBoxQLKH_MaKH.Text = "";

            }

            dataGridViewQLKH_DanhSachKH.AutoGenerateColumns = false;
            dataGridViewQLKH_DanhSachKH.Columns[0].DataPropertyName = "STT";
            dataGridViewQLKH_DanhSachKH.Columns[1].DataPropertyName = "MaKH";
            dataGridViewQLKH_DanhSachKH.Columns[2].DataPropertyName = "HoTenKH";
            dataGridViewQLKH_DanhSachKH.Columns[3].DataPropertyName = "Email";
            dataGridViewQLKH_DanhSachKH.Columns[4].DataPropertyName = "DienThoai";
            dataGridViewQLKH_DanhSachKH.Columns[5].DataPropertyName = "DiaChi";
            QLKHLoadData();
        }

        public void QLKHLoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeKhachHang", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewQLKH_DanhSachKH.DataSource = dt;

            //Combobox

            SqlCommand Command = new SqlCommand("LietKeKhachHang", connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            comboBoxQLKH_MaKH.DataSource = dt;
            comboBoxQLKH_MaKH.DisplayMember = "MaKH";
            connection.Close();
        }
        private void dataGridViewQLKH_DanhSachKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                comboBoxQLKH_MaKH.Text = Convert.ToString(dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value);
                textBoxQLKH_TenKH.Text = Convert.ToString(dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[2].Value);
                textBoxQLKH_Email.Text = Convert.ToString(dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[3].Value);
                textBoxQLKH_SDT.Text = Convert.ToString(dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[4].Value);
                textBoxQLKH_DiaChi.Text = Convert.ToString(dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[5].Value);
            }
        }
        private void buttonQLKH_Luu_Click(object sender, EventArgs e)
        {
            comboBoxQLKH_MaKH.Enabled = true;
            buttonQLKH_Luu.Visible = false;
            buttonQLKH_Xoa.Enabled = true;
            buttonQLKH_CapNhat.Enabled = true;
            buttonQLKH_Them.Visible = true;
            buttonQLKH_huy.Visible = false;
            //buttonQLKH_Them.Text = "Thêm";
            dataGridViewQLKH_DanhSachKH.Enabled = true;

            if (textBoxQLKH_TenKH.Text == "" || textBoxQLKH_DiaChi.Text=="" || textBoxQLKH_SDT.Text=="" || textBoxQLKH_Email.Text=="")
            {
                MessageBox.Show("Lỗi! Vui lòng nhập đầy đủ thông tin!");
                kiemtraluu = 0;
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemKhachHang", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@HoTenKH", textBoxQLKH_TenKH.Text);
            command.Parameters.Add(p);

            p = new SqlParameter("@DiaChi", textBoxQLKH_DiaChi.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@DienThoai", textBoxQLKH_SDT.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@Email", textBoxQLKH_Email.Text);
            command.Parameters.Add(p);

            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thêm thành công!");
                kiemtraluu = 0;
                QLKHLoadData();               

            }

            connection.Close();
        }
        private void buttonQLKH_Them_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            comboBoxQLKH_MaKH.Text = "";
            comboBoxQLKH_MaKH.Enabled = false;
            buttonQLKH_Luu.Visible = true;
            textBoxQLKH_DiaChi.Text = "";
            textBoxQLKH_Email.Text = "";
            textBoxQLKH_SDT.Text = "";
            textBoxQLKH_TenKH.Text = "";
            buttonQLKH_Xoa.Enabled = false;
            buttonQLKH_CapNhat.Enabled = false;
            dataGridViewQLKH_DanhSachKH.Enabled = false;
            buttonQLKH_Them.Visible = false;
            buttonQLKH_huy.Visible = true;
            connection.Close();
        }
        private void buttonQLKH_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaKhachHang", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("MaKH", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        QLKHLoadData();

                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!");
                }
            }
            else return;

        }
        private void buttonQLKH_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn cập nhật?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {

                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();

                    SqlCommand command = new SqlCommand("SuaKH", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;

                    SqlParameter p = new SqlParameter("@MaKH", id);
                    command.Parameters.Add(p);

                    p = new SqlParameter("@HoTenKH", textBoxQLKH_TenKH.Text);
                    command.Parameters.Add(p);

                    p = new SqlParameter("@DiaChi", textBoxQLKH_DiaChi.Text);
                    command.Parameters.Add(p);

                    p = new SqlParameter("@DienThoai", textBoxQLKH_SDT.Text);
                    command.Parameters.Add(p);

                    p = new SqlParameter("@Email", textBoxQLKH_Email.Text);
                    command.Parameters.Add(p);

                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông Báo");
                        QLKHLoadData();

                    }
                    connection.Close();
                }
                else return;

                
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonQLKH_huy_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            comboBoxQLKH_MaKH.Text = "";
            comboBoxQLKH_MaKH.Enabled = true;
            buttonQLKH_Luu.Visible = false;
            textBoxQLKH_DiaChi.Text = "";
            textBoxQLKH_Email.Text = "";
            textBoxQLKH_SDT.Text = "";
            textBoxQLKH_TenKH.Text = "";
            buttonQLKH_Xoa.Enabled = true;
            buttonQLKH_CapNhat.Enabled = true;
            dataGridViewQLKH_DanhSachKH.Enabled = true;
            buttonQLKH_Them.Visible = true;
            buttonQLKH_huy.Visible = false;
            connection.Close();
        }
        private void buttonQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;

                    comboBoxQLKH_MaKH.Enabled = true;
                    buttonQLKH_Luu.Visible = false;
                    buttonQLKH_Xoa.Enabled = true;
                    buttonQLKH_CapNhat.Enabled = true;
                    buttonQLKH_huy.Visible = false;
                    buttonQLKH_Them.Visible = true;
                    //buttonQLKH_Them.Text = "Thêm";
                    dataGridViewQLKH_DanhSachKH.Enabled = true;
                    textBoxQLKH_DiaChi.Text = "";
                    textBoxQLKH_Email.Text = "";
                    textBoxQLKH_SDT.Text = "";
                    textBoxQLKH_TenKH.Text = "";
                    comboBoxQLKH_MaKH.Text = "";

                    panelQuanLyKhachHang.BringToFront();

                }
                else return;
            }
            else panelQuanLyKhachHang.BringToFront();




        }


    }
}
