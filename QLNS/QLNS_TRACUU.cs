using System;
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
using System.Drawing.Printing;

namespace QLNS
{
    public partial class FormQLNS : Form
    {
        private void buttonTraCuu_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelTraCuu.BringToFront();

                }
                else return;
            }
            else panelTraCuu.BringToFront();

        }

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

            if (textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_NamXuatBan.Text.Trim() == "" &&  textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "" )
            {
                SqlCommand command = new SqlCommand("TraCuuSach", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
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
            if (textBoxTC_TacGia.Text.Trim() !="" && textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" &&  textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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
            if (textBoxTC_TheLoai.Text.Trim() != "" && textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" )
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoai", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
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
            if (textBoxTC_NhaXuatBan.Text.Trim()!="" && textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
            {

                SqlCommand command = new SqlCommand("TraCuuNXB", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim()!="" && textBoxTC_TenSach.Text.Trim()=="" && textBoxTC_TacGia.Text.Trim()=="" && textBoxTC_NhaXuatBan.Text.Trim()=="" && textBoxTC_TheLoai.Text.Trim()=="")
            {
                SqlCommand command = new SqlCommand("TraCuuNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoai", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
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

            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
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

            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGia", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheloai", textBoxTC_TheLoai.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheloai", textBoxTC_TheLoai.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB",Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheloai", textBoxTC_TheLoai.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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

            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGiaNXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
                command.Parameters.Add(p);               
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGiaNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() == "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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

            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() != "" && textBoxTC_TacGia.Text.Trim() != "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuSachTheLoaiTacGiaNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
                p = new SqlParameter("@TenDauSach", textBoxTC_TenSach.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenTacGia", textBoxTC_TacGia.Text.Trim());
                command.Parameters.Add(p);
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
            if (textBoxTC_NamXuatBan.Text.Trim() != "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() != "" && textBoxTC_TheLoai.Text.Trim() != "")
            {
                SqlCommand command = new SqlCommand("TraCuuTheLoaiNXBNamXB", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamXB", Convert.ToInt32(textBoxTC_NamXuatBan.Text.Trim()));
                command.Parameters.Add(p);
               
                p = new SqlParameter("@TenTheLoai", textBoxTC_TheLoai.Text.Trim());
                command.Parameters.Add(p);
                
                p = new SqlParameter("@TenNXB", textBoxTC_NhaXuatBan.Text.Trim());
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
                if (textBoxTC_NamXuatBan.Text.Trim() == "" && textBoxTC_TenSach.Text.Trim() == "" && textBoxTC_TacGia.Text.Trim() == "" && textBoxTC_NhaXuatBan.Text.Trim() == "" && textBoxTC_TheLoai.Text.Trim() == "")
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        private void buttonTC_XuatFile_Click(object sender, EventArgs e)
        {
            

        }
        private void buttonTC_In_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) // this displays the dialog box and performs actions dependant on which option chosen.
            {
                printDocument1.Print();
            }

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int columnPosition = 0;
            int rowPosition = 25;

            DrawHeader(new Font(this.Font, FontStyle.Bold), e.Graphics, ref columnPosition, ref rowPosition); // runs the DrawHeader function

            rowPosition += 35; 

            DrawGridBody(e.Graphics, ref columnPosition, ref rowPosition);
        }
        

        

        private int DrawHeader(Font boldFont, Graphics g, ref int columnPosition, ref int rowPosition)
        {
            foreach (DataGridViewColumn dc in dataGridViewTC.Columns)
            {


                g.DrawString(dc.HeaderText, boldFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
                columnPosition += dc.Width + 5;  
            }

            return columnPosition;
        }

        
        private void DrawGridBody(Graphics g, ref int columnPosition, ref int rowPosition)
        {
            foreach (DataRow dr in ((DataTable)dataGridViewTC.DataSource).Rows)
            {
                columnPosition = 0;

                g.DrawLine(Pens.Black, new Point(0, rowPosition), new Point(this.Width, rowPosition));

                foreach (DataGridViewColumn dc in dataGridViewTC.Columns)
                {
                    string text = dr[dc.DataPropertyName].ToString();
                    g.DrawString(text, this.Font, Brushes.Black, (float)columnPosition, (float)rowPosition + 10f); 
                    columnPosition += dc.Width + 5;
                }

                rowPosition = rowPosition + 35; 
            }
        }

    }
}
