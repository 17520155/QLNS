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

        public float tongtienmua = 0;
        private void buttonLHDBS_Them_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxLHDBS_SoLuong.Text == "" || textBoxLHDBS_DonGiaBan.Text == "")
                {
                    MessageBox.Show("Lỗi ! Vui lòng nhập đầy đủ thông tin ");
                    return;
                }
                else
                {
                    dataGridViewLHDBS_DanhSachMua.AllowUserToAddRows = false;
                    dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
                    int indexRow = dataGridViewLHDBS_DanhSachMua.Rows.Count - 1;
                    int kt = 0;
                    for (int i = 0; i < dataGridViewLHDBS_DanhSachMua.Rows.Count - 1; i++)
                    {
                        if (comboBoxLHDBS_MaSach.Text == dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[1].Value.ToString())
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
                        dataGridViewLHDBS_DanhSachMua[0, indexRow].Value = dataGridViewLHDBS_DanhSachMua.Rows.Count;
                        dataGridViewLHDBS_DanhSachMua[1, indexRow].Value = comboBoxLHDBS_MaSach.Text;
                        dataGridViewLHDBS_DanhSachMua[2, indexRow].Value = textBoxLHDBS_TenDauSach.Text;
                        dataGridViewLHDBS_DanhSachMua[3, indexRow].Value = textBoxLHDBS_NhaXuatBan.Text;
                        dataGridViewLHDBS_DanhSachMua[4, indexRow].Value = textBoxLHDBS_NamXuatBan.Text;
                        dataGridViewLHDBS_DanhSachMua[5, indexRow].Value = textBoxLHDBS_TheLoai.Text;
                        dataGridViewLHDBS_DanhSachMua[6, indexRow].Value = textBoxLHDBS_SoLuong.Text;
                        dataGridViewLHDBS_DanhSachMua[7, indexRow].Value = textBoxLHDBS_DonGiaBan.Text;
                        float soluongban = Convert.ToSingle(textBoxLHDBS_SoLuong.Text);
                        float dongiaban = Convert.ToSingle(textBoxLHDBS_DonGiaBan.Text);
                        dataGridViewLHDBS_DanhSachMua[8, indexRow].Value = (soluongban * dongiaban).ToString();
                        tongtienmua = tongtienmua + Convert.ToSingle(dataGridViewLHDBS_DanhSachMua[8, indexRow].Value.ToString());

                        textBoxLHDBS_TongTien.Text = tongtienmua.ToString();
                        textBoxLHDBS_SoLuong.Text = "";
                        textBoxLHDBS_DonGiaBan.Text = "";
                        MessageBox.Show("Thêm thành công ");
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại ");
                        dataGridViewLHDBS_DanhSachMua.Rows.Remove(dataGridViewLHDBS_DanhSachMua.Rows[dataGridViewLHDBS_DanhSachMua.Rows.Count - 1]);
                        return;
                    }


                }
            }
            catch
            {
                MessageBox.Show("Lỗi ! Vui lòng kiểm tra lại");
            }
            

        }

        private void buttonLHDBS_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    int RowIndex = dataGridViewLHDBS_DanhSachMua.CurrentRow.Index;
                    tongtienmua = tongtienmua - Convert.ToSingle(dataGridViewLHDBS_DanhSachMua[8, RowIndex].Value.ToString());
                    dataGridViewLHDBS_DanhSachMua.Rows.RemoveAt(RowIndex);
                    textBoxLHDBS_TongTien.Text = tongtienmua.ToString();
                }
                else return;
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
            }
        }

        private void buttonLHDBS_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBoxLHDBS_SoLuong.Text == "" || textBoxLHDBS_DonGiaBan.Text == "")
                {
                    MessageBox.Show("Lỗi ! Vui lòng nhập đầy đủ thông tin ");
                    return;
                }
                else
                {

                    int RowIndex = dataGridViewLHDBS_DanhSachMua.CurrentRow.Index;
                    float sl = Convert.ToSingle(dataGridViewLHDBS_DanhSachMua[6, RowIndex].Value.ToString());
                    float dg = Convert.ToSingle(dataGridViewLHDBS_DanhSachMua[7, RowIndex].Value.ToString());
                    dataGridViewLHDBS_DanhSachMua[6, RowIndex].Value = textBoxLHDBS_SoLuong.Text;
                    dataGridViewLHDBS_DanhSachMua[7, RowIndex].Value = textBoxLHDBS_DonGiaBan.Text;
                    float soluong = Convert.ToSingle(textBoxLHDBS_SoLuong.Text);
                    float dongia = Convert.ToSingle(textBoxLHDBS_DonGiaBan.Text);
                    dataGridViewLHDBS_DanhSachMua[8, RowIndex].Value = (soluong * dongia).ToString();
                    tongtienmua = tongtienmua - sl * dg;
                    tongtienmua = tongtienmua + Convert.ToSingle(dataGridViewLHDBS_DanhSachMua[8, RowIndex].Value.ToString());
                    textBoxLHDBS_TongTien.Text = tongtienmua.ToString();
                    MessageBox.Show("Cập nhật thành công");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
            }

        }

        private void panelLapHoaDonBanSach_Paint(object sender, PaintEventArgs e)
        {
            LHDBS_LoadComboboxMaSach();

        }
        private void dataGridViewLHDBS_DanhSachMua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                comboBoxLHDBS_MaSach.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[1].Value);
                textBoxLHDBS_TenDauSach.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[2].Value);
                textBoxLHDBS_NhaXuatBan.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[3].Value);
                textBoxLHDBS_NamXuatBan.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[4].Value);
                textBoxLHDBS_TheLoai.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[5].Value);
                textBoxLHDBS_SoLuong.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[6].Value);
                textBoxLHDBS_DonGiaBan.Text = Convert.ToString(dataGridViewLHDBS_DanhSachMua.CurrentRow.Cells[7].Value);

            }

        }
        private void LapHoaDon_LuuHD_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            if (dataGridViewLHDBS_DanhSachMua.RowCount > 0)
            {
                for (int i = 0; i <= dataGridViewLHDBS_DanhSachMua.RowCount - 1; i++)
                {
                    if (dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[0].Value != null)
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
                    
                    LapHoaDon_LuuHD.Visible = false;
                    buttonLHDBS_ThemMoi.Text = "Thêm mới";
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("ThemHoaDonMoi", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    DateTime date = DateTime.ParseExact(dateTimePickerLHDBS_NgayNhap.Text, "dd-MM-yyyy", null);
                    SqlParameter p = new SqlParameter("@NgayLap", date);
                    command.Parameters.Add(p);
                    p = new SqlParameter("@MaKH", comboBoxLHDBS_MaKH.Text);
                    command.Parameters.Add(p);

                    object obj = command.ExecuteScalar();
                    int id = Convert.ToInt32(obj);
                    //
                    //
                    for (int i = 0; i < dataGridViewLHDBS_DanhSachMua.Rows.Count; i++)
                    {
                        string MaSach = dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[1].Value.ToString();
                        int ms = Convert.ToInt32(MaSach);
                        string sl = dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[6].Value.ToString();
                        int slb = Convert.ToInt32(sl);
                        string dg = dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[7].Value.ToString();
                        int dgb = Convert.ToInt32(dg);
                        SqlCommand Command = new SqlCommand("ThemCTHD", connection);
                        Command.CommandType = CommandType.StoredProcedure;
                        p = new SqlParameter("@SoHD", id);
                        Command.Parameters.Add(p);
                        p = new SqlParameter("@MaSach", ms);
                        Command.Parameters.Add(p);
                        p = new SqlParameter("@DonGiaBan", dgb);
                        Command.Parameters.Add(p);
                        p = new SqlParameter("@SoLuongBan", slb);
                        Command.Parameters.Add(p);
                        Command.ExecuteNonQuery();

                    }
                    SqlCommand Commands = new SqlCommand("ThanhToanHoaDon", connection);
                    Commands.CommandType = CommandType.StoredProcedure;
                    p = new SqlParameter("@SoHD", id);
                    Commands.Parameters.Add(p);
                    p = new SqlParameter("@SoTienTra", textBoxLHDBS_SoTienTra.Text);
                    Commands.Parameters.Add(p);
                    Commands.ExecuteNonQuery();
                    for (int i = 0; i < dataGridViewLHDBS_DanhSachMua.Rows.Count; i++)
                    {
                        dataGridViewLHDBS_DanhSachMua.Rows.Clear();
                    }
                    MessageBox.Show("Thêm thành công");
                    textBoxLHDBS_TongTien.Text = "";
                    textBoxLHDBS_SoTienTra.Text = "";

                    connection.Close();
                }
                catch
                {
                    LapHoaDon_LuuHD.Visible = false;
                    buttonLHDBS_ThemMoi.Text = "Thêm mới";
                    MessageBox.Show("Lỗi Vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Chưa có chi tiết hóa đơn");
                return;
            }
        }
        private void textBoxLHDBS_SoTienTra_TextChanged(object sender, EventArgs e)
        {
            float sotientra;
            float tongsotien;
            if (textBoxLHDBS_SoTienTra.Text == "") sotientra = 0;
            else    sotientra = Convert.ToSingle(textBoxLHDBS_SoTienTra.Text);
            if (textBoxLHDBS_TongTien.Text == "") tongsotien = 0;
            else tongsotien = Convert.ToSingle(textBoxLHDBS_TongTien.Text);
            textBox_LHDBS_ConLai.Text = (tongsotien - sotientra).ToString() ;


        }
        private void buttonLHDBS_ThemMoi_Click(object sender, EventArgs e)
        {
            textBoxLHDBS_SoTienTra.Text = "";
            textBoxLHDBS_SoLuong.Text = "";
            textBoxLHDBS_DonGiaBan.Text = "";
            LapHoaDon_LuuHD.Visible = true;
            buttonLHDBS_ThemMoi.Text = "Hủy";
        }
    }
}
