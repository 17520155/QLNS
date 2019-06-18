﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private void buttonTC_TimKiem_Click(object sender, EventArgs e)
        {
            TraCuu();

        }
        private void dataGridViewTC_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       public void TraCuu()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            if (textBoxTC_TenSach.Text != "" && textBoxTC_NamXuatBan.Text == "" &&  textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "" )
            {
                SqlCommand command = new SqlCommand("TraCuuSach", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();         

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy "+count+ " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");

            }
            if (textBoxTC_TacGia.Text !="" && textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" &&  textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);               

                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_TheLoai.Text != "" && textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" )
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoai", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);               

                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NhaXuatBan.Text!="" && textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_TheLoai.Text == "")
            {

                SqlCommand command = new SqlCommand("TraCuuNXB", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);                

                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text!="" && textBoxTC_TenSach.Text=="" && textBoxTC_TacGia.Text=="" && textBoxTC_NhaXuatBan.Text=="" && textBoxTC_TheLoai.Text=="")
            {
                SqlCommand command = new SqlCommand("TraCuuNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");

            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");

            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoai", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }

            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }

            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheloai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheloai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB",Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheloai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }

            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);               
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }

            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text != "" && textBoxTC_TacGia.Text != "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            if (textBoxTC_NamXuatBan.Text != "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text != "" && textBoxTC_TheLoai.Text != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text));
                command.Parameters.Add(p);
               
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text);
                command.Parameters.Add(p);
                
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text);
                command.Parameters.Add(p);

                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("STT");
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    count++;
                }
                dataGridViewTC.DataSource = dt;
                if (count > 0)
                {
                    MessageBox.Show("Đã tìm thấy " + count + " kết quả !");

                }
                else MessageBox.Show("Không tìm thấy kết quả ");
            }
            else
            {
                if (textBoxTC_NamXuatBan.Text == "" && textBoxTC_TenSach.Text == "" && textBoxTC_TacGia.Text == "" && textBoxTC_NhaXuatBan.Text == "" && textBoxTC_TheLoai.Text == "")
                    MessageBox.Show("Không tìm thấy kết quả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            connection.Close();
        }
        private void panelTraCuu_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewTC.AutoGenerateColumns = false;
            dataGridViewTC.Columns[0].DataPropertyName = "STT";
            dataGridViewTC.Columns[1].DataPropertyName = "MaSach";
            dataGridViewTC.Columns[2].DataPropertyName = "TenDauSach";
            dataGridViewTC.Columns[3].DataPropertyName = "TenTheLoai";
            dataGridViewTC.Columns[4].DataPropertyName = "TenTacGia";
            dataGridViewTC.Columns[5].DataPropertyName = "TenNXB";
            dataGridViewTC.Columns[6].DataPropertyName = "NamXB";
            //TraCuu();


            

        }
    }
}