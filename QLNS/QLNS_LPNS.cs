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
        public float tongtien = 0;
        public int themmoi=0;
        public int LPNS_SoLuongNhapToiThieu()
        {
            
                //Kiem tra qui dinh nhap
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();
                //int id;
                SqlCommand command = new SqlCommand("LietKeSoLuongNhapToiThieu", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                
                string soluongnhaptoithieu = dt.Rows[0]["GiaTri"].ToString().Trim();     


                connection.Close();
                return Convert.ToInt32(soluongnhaptoithieu);
            


        }
        public int LPNS_SoLuongTonToiThieu()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            //int id;
            SqlCommand command = new SqlCommand("LietKeSoLuongTonToiThieu", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string soluongtontoithieu = dt.Rows[0]["GiaTri"].ToString().Trim();

            connection.Close();
            return Convert.ToInt32(soluongtontoithieu);

        }
        public int LPNS_LietKeSLT(int x)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            //int id;
            SqlCommand command = new SqlCommand("LietKeSoLuongTonTheoMaSach", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@MaSach",x);
            command.Parameters.Add(p);
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string SLton = dt.Rows[0]["SoLuongTon"].ToString().Trim();

            connection.Close();
            return Convert.ToInt32(SLton);
        }

        private void buttonLPNS_Them_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxLPNS_SoLuongNhap.Text == "" || textBoxLPNS_DonGiaNhap.Text == "")
                {
                    MessageBox.Show("Lỗi ! Vui lòng nhập đầy đủ thông tin ");
                    return;
                }
                else
                {
                    dataGridViewLPNS_ChiTietPhieuNhap.AllowUserToAddRows = false;
                    if (dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count==0)
                    {
                        dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);

                    }
                    int indexRow = dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count-1;
                    kiemtraluu = 1;
                    int kt = 0;
                    for (int i = 0; i < dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1; i++)
                    {
                        if (comboBoxLPNS_MaSach.Text == dataGridViewLPNS_ChiTietPhieuNhap.Rows[i].Cells[1].Value.ToString())
                        {
                            kt = 1;
                            break;
                        }
                        else
                        {
                            kt = 0;
                        }

                    }
                    if (kt == 0)
                    {
                        int SLton=LPNS_LietKeSLT(Convert.ToInt32(comboBoxLPNS_MaSach.Text));
                        int soluongnhaptoithieu = LPNS_SoLuongNhapToiThieu();
                        int soluongtontoithieu = LPNS_SoLuongTonToiThieu();
                        if (soluongnhaptoithieu > Convert.ToInt32(textBoxLPNS_SoLuongNhap.Text)|| soluongtontoithieu <SLton)
                        {
                            if (soluongnhaptoithieu > Convert.ToInt32(textBoxLPNS_SoLuongNhap.Text) && soluongtontoithieu < SLton)
                            {

                                MessageBox.Show("Lỗi! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                            }
                            else
                            if (soluongnhaptoithieu > Convert.ToInt32(textBoxLPNS_SoLuongNhap.Text))
                            {
                                string str = "Số lượng nhập tối thiểu " + soluongnhaptoithieu.ToString();
                                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                            }
                            else
                            if (soluongtontoithieu < SLton)
                            {
                                string str = "Mã sách "+ comboBoxLPNS_MaSach.Text+" Số lượng tồn " + soluongtontoithieu.ToString();
                                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                            }                           

                            return;
                        }
                        else
                        {


                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[0].Value = dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count;
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[1].Value = comboBoxLPNS_MaSach.Text;
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[2].Value = textBoxLPNS_TenDauSach.Text;
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[3].Value = textBoxLPNS_NhaXuatBan.Text;
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[4].Value = textBoxLPNS_NamXuatBan.Text;
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[5].Value = textBoxLPNS_SoLuongNhap.Text;
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[6].Value = textBoxLPNS_DonGiaNhap.Text;
                            float soluong = (float)Convert.ToDouble(textBoxLPNS_SoLuongNhap.Text);
                            float dongia = (float)Convert.ToDouble(textBoxLPNS_DonGiaNhap.Text);
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[7].Value = String.Format("{0:0,0}", (soluong * dongia)).ToString();
                            tongtien = tongtien + (float)Convert.ToDouble(dataGridViewLPNS_ChiTietPhieuNhap.Rows[indexRow].Cells[7].Value.ToString());
                            textBoxLPNS_TongTien.Text = String.Format("{0:0,0}", tongtien).ToString();
                            textBoxLPNS_SoLuongNhap.Text = "";
                            textBoxLPNS_DonGiaNhap.Text = "";
                            dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);
                            MessageBox.Show("Thêm thành công ");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại ");
                        //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                        return;
                    }


                }
            }
            catch
            {
                MessageBox.Show("Lỗi ! Vui lòng kiểm tra lại");
            }

        }

        private void buttonLPNS_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    
                        int RowIndex = dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Index;
                        tongtien = tongtien - Convert.ToSingle(dataGridViewLPNS_ChiTietPhieuNhap[7, RowIndex].Value.ToString());
                        dataGridViewLPNS_ChiTietPhieuNhap.Rows.RemoveAt(RowIndex);
                        textBoxLPNS_TongTien.Text = tongtien.ToString();
                   
                }
                else return;
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
            }

        }

        private void buttonLPNS_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int SLton = LPNS_LietKeSLT(Convert.ToInt32(comboBoxLPNS_MaSach.Text));
                int soluongnhaptoithieu = LPNS_SoLuongNhapToiThieu();
                int soluongtontoithieu = LPNS_SoLuongTonToiThieu();
                if (soluongnhaptoithieu > Convert.ToInt32(textBoxLPNS_SoLuongNhap.Text) || soluongtontoithieu < SLton)
                {
                    if (soluongnhaptoithieu > Convert.ToInt32(textBoxLPNS_SoLuongNhap.Text) && soluongtontoithieu < SLton)
                    {

                        MessageBox.Show("Lỗi! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                    }
                    else
                    if (soluongnhaptoithieu > Convert.ToInt32(textBoxLPNS_SoLuongNhap.Text))
                    {
                        string str = "Số lượng nhập tối thiểu " + soluongnhaptoithieu.ToString();
                        MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                    }
                    else
                    if (soluongtontoithieu < SLton)
                    {
                        string str = "Mã sách " + comboBoxLPNS_MaSach.Text + " Số lượng tồn " + soluongtontoithieu.ToString();
                        MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dataGridViewLPNS_ChiTietPhieuNhap.Rows.Remove(dataGridViewLPNS_ChiTietPhieuNhap.Rows[dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count - 1]);
                    }

                    return;
                }
                else
                {

                    DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {

                        if (textBoxLPNS_SoLuongNhap.Text == "" || textBoxLPNS_DonGiaNhap.Text == "")
                        {
                            MessageBox.Show("Lỗi ! Vui lòng nhập đầy đủ thông tin ");
                            return;
                        }
                        else
                        {

                            int RowIndex = dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Index;
                            float sl = Convert.ToSingle(dataGridViewLPNS_ChiTietPhieuNhap[5, RowIndex].Value.ToString());
                            float dg = Convert.ToSingle(dataGridViewLPNS_ChiTietPhieuNhap[6, RowIndex].Value.ToString());
                            dataGridViewLPNS_ChiTietPhieuNhap[5, RowIndex].Value = textBoxLPNS_SoLuongNhap.Text;
                            dataGridViewLPNS_ChiTietPhieuNhap[6, RowIndex].Value = textBoxLPNS_DonGiaNhap.Text;
                            float soluong = Convert.ToSingle(textBoxLPNS_SoLuongNhap.Text);
                            float dongia = Convert.ToSingle(textBoxLPNS_DonGiaNhap.Text);
                            dataGridViewLPNS_ChiTietPhieuNhap[7, RowIndex].Value = (soluong * dongia).ToString();
                            tongtien = tongtien - sl * dg;
                            tongtien = tongtien + Convert.ToSingle(dataGridViewLPNS_ChiTietPhieuNhap[7, RowIndex].Value.ToString());
                            textBoxLPNS_TongTien.Text = tongtien.ToString();
                            MessageBox.Show("Cập nhật thành công");
                        }

                    }
                    else return;
                }
               
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
            }
        }        

        private void dataGridViewLPNS_ChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                comboBoxLPNS_MaSach.Text = Convert.ToString(dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Cells[1].Value);
                textBoxLPNS_TenDauSach.Text = Convert.ToString(dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Cells[2].Value);
                textBoxLPNS_NhaXuatBan.Text = Convert.ToString(dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Cells[3].Value);
                textBoxLPNS_NamXuatBan.Text = Convert.ToString(dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Cells[4].Value);
                textBoxLPNS_SoLuongNhap.Text = Convert.ToString(dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Cells[5].Value);
                textBoxLPNS_DonGiaNhap.Text = Convert.ToString(dataGridViewLPNS_ChiTietPhieuNhap.CurrentRow.Cells[6].Value);
               
            }
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
            comboBoxLPNS_MaSach.DisplayMember = dt.Columns[0].ToString();
            comboBoxLPNS_MaSach.ValueMember = dt.Columns[0].ToString();
            comboBoxLPNS_MaSach.DataSource = dt;
            connection.Close();
           
        }
        private void panelLapPhieuNhapSach_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {
                
                button_LPNS_luu.Visible = false;
                themmoi = 0;
                dataGridViewLPNS_ChiTietPhieuNhap.Rows.Clear();
                dataGridViewLPNS_ChiTietPhieuNhap.AllowUserToAddRows = false;
                dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);
                buttonLPNS_ThemMoi.Text = "Thêm mới";
                textBoxLPNS_TongTien.Text = "";

            }
            if(themmoi==0)
            {
                buttonLPNS_Them.Enabled = false;
                buttonLPNS_Xoa.Enabled = false;
                buttonLPNS_CapNhat.Enabled = false;
                dataGridViewLPNS_ChiTietPhieuNhap.Enabled = false;
                buttonLPNS_ThemMoi.Visible = true;
                buttonLPNS_huy.Visible = false;


            }
            else
            {
                buttonLPNS_Them.Enabled = true;
                buttonLPNS_Xoa.Enabled = true;
                buttonLPNS_CapNhat.Enabled = true;
                dataGridViewLPNS_ChiTietPhieuNhap.Enabled = true;
                buttonLPNS_ThemMoi.Visible = false;
                buttonLPNS_huy.Visible = true;

            }
            ToolTip t = new ToolTip();
            string str = "Số lượng nhập nhỏ hơn :" + LPNS_SoLuongNhapToiThieu().ToString();
            t.SetToolTip(textBoxLPNS_SoLuongNhap,str);
            LoadComboboxMaSach();
        }

        private void comboBoxLPNS_MaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(comboBoxLPNS_MaSach.Text))
            {
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeSachMaSachTenDauSachNXB", connection);
            SqlParameter p = new SqlParameter("@MaSach", Convert.ToInt32(comboBoxLPNS_MaSach.Text));
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
        private void button_LPNS_luu_Click(object sender, EventArgs e)
        {

            themmoi = 0;
                int iCount = 0;
                
                if (dataGridViewLPNS_ChiTietPhieuNhap.RowCount > 0)
                    {
                        for (int i = 0; i <= dataGridViewLPNS_ChiTietPhieuNhap.RowCount - 1; i++)
                        {
                            if (dataGridViewLPNS_ChiTietPhieuNhap.Rows[i].Cells[0].Value != null)
                            {
                            
                                    iCount++;
                            
                            }
                            else continue;
                        }
                    }            

                if ( iCount>0)
                {
                
                    try
                    {

                        button_LPNS_luu.Visible = false;
                        buttonLPNS_ThemMoi.Text = "Thêm mới";
                        tongtien = 0;
                        textBoxLPNS_TongTien.Text = tongtien.ToString();


                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = Global.ConnectionStr;
                        connection.Open();
                        SqlCommand command = new SqlCommand("ThemPhieuNhapMoi", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        DateTime date = DateTime.ParseExact(dateTimePicker_NgayNhap.Text, "dd-MM-yyyy", null);
                        SqlParameter p = new SqlParameter("@NgayNhap", date);
                        command.Parameters.Add(p);

                        object obj = command.ExecuteScalar();
                        int id = Convert.ToInt32(obj);
                        for (int i = 0; i < dataGridViewLPNS_ChiTietPhieuNhap.Rows.Count-1; i++)
                        {
                            string MaSach = dataGridViewLPNS_ChiTietPhieuNhap.Rows[i].Cells[1].Value.ToString();
                            int ms = Convert.ToInt32(MaSach);
                            string sl = dataGridViewLPNS_ChiTietPhieuNhap.Rows[i].Cells[5].Value.ToString();
                            float sln = (float)Convert.ToDouble(sl);
                            string dg = dataGridViewLPNS_ChiTietPhieuNhap.Rows[i].Cells[6].Value.ToString();
                            float dgn = (float)Convert.ToDouble(dg);
                            SqlCommand Command = new SqlCommand("ThemChiTietPhieuNhap", connection);
                            Command.CommandType = CommandType.StoredProcedure;
                            p = new SqlParameter("@MaPhieuNhap", id);
                            Command.Parameters.Add(p);
                            p = new SqlParameter("@MaSach", ms);
                            Command.Parameters.Add(p);
                            p = new SqlParameter("@DonGiaNhap", dgn);
                            Command.Parameters.Add(p);
                            p = new SqlParameter("@SoLuongNhap", sln);
                            Command.Parameters.Add(p);
                            Command.ExecuteNonQuery();

                        }                    
                        dataGridViewLPNS_ChiTietPhieuNhap.Rows.Clear();                   
                        dataGridViewLPNS_ChiTietPhieuNhap.AllowUserToAddRows = false;
                        dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);
                        MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        textBoxLPNS_TongTien.Text = "";
                        kiemtraluu = 0;
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi ! Vui lòng kiểm tra lại ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        kiemtraluu = 0;
                    }
                }
                else
                {
                    button_LPNS_luu.Visible = false;
                    buttonLPNS_ThemMoi.Text = "Thêm mới";
                    tongtien = 0;
                    textBoxLPNS_TongTien.Text = tongtien.ToString();
                    MessageBox.Show("Chưa có phiếu nhập nào","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    kiemtraluu = 0;

                }


        }
        private void buttonLPNS_ThemMoi_Click(object sender, EventArgs e)
        {
            themmoi = 1;
            kiemtraluu = 1;
            textBoxLPNS_SoLuongNhap.Text = "";
            textBoxLPNS_DonGiaNhap.Text = "";
            comboBoxLPNS_MaSach.Text = "";
            textBoxLPNS_TenDauSach.Text = "";
            textBoxLPNS_NhaXuatBan.Text = "";
            textBoxLPNS_NamXuatBan.Text = "";
            button_LPNS_luu.Visible = true;
            buttonLPNS_ThemMoi.Text = "Hủy bỏ";
            textBoxLPNS_TongTien.Text ="0";
            dataGridViewLPNS_ChiTietPhieuNhap.Rows.Clear();
            dataGridViewLPNS_ChiTietPhieuNhap.AllowUserToAddRows = false;
            dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);

            



        }
        private void buttonLPNS_huy_Click(object sender, EventArgs e)
        {
            themmoi = 0;
            kiemtraluu = 0;
            button_LPNS_luu.Visible = false;
            textBoxLPNS_SoLuongNhap.Text = "";
            textBoxLPNS_DonGiaNhap.Text = "";
            comboBoxLPNS_MaSach.Text = "";
            textBoxLPNS_TenDauSach.Text = "";
            textBoxLPNS_NhaXuatBan.Text = "";
            textBoxLPNS_NamXuatBan.Text = "";
            button_LPNS_luu.Visible = true;
            buttonLPNS_ThemMoi.Text = "Thêm mới";
            textBoxLPNS_TongTien.Text = "0";
            dataGridViewLPNS_ChiTietPhieuNhap.Rows.Clear();
            dataGridViewLPNS_ChiTietPhieuNhap.AllowUserToAddRows = false;
            dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);
        }
        private void buttonNhapSach_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    button_LPNS_luu.Visible = false;
                    themmoi = 0;
                    dataGridViewLPNS_ChiTietPhieuNhap.Rows.Clear();
                    dataGridViewLPNS_ChiTietPhieuNhap.AllowUserToAddRows = false;
                    dataGridViewLPNS_ChiTietPhieuNhap.Rows.Add(1);
                    buttonLPNS_ThemMoi.Text = "Thêm mới";
                    textBoxLPNS_TongTien.Text = "";

                    panelLapPhieuNhapSach.BringToFront();

                }
                else return;
            }
            else panelLapPhieuNhapSach.BringToFront();



        }


    }
}
