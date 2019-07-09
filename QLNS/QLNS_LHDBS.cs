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

        public float LHDBS_LietKeSoTienNo(int x)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeSoTienNoTheoMaKH", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@MaKH", x);
            command.Parameters.Add(p);
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string sotienno = dt.Rows[0]["SoTienNo"].ToString().Trim();
            connection.Close();
            return (float)Convert.ToDouble(sotienno);
        }
        public int themmoihd = 0;
        private void textBoxLHDBS_DonGiaBan_TextChanged(object sender, EventArgs e)
        {
            

        }
        public int LHDBS_SLTonMinSauKhiBan()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            //int id;
            SqlCommand command = new SqlCommand("LietKeSLTonMinSauKhiBan", connection);
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
        public float LHDBS_LietKeSoTienNoToiDa()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            //int id;
            SqlCommand command = new SqlCommand("LietKeSoTienNoToiDa", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string sotienno = dt.Rows[0]["GiaTri"].ToString().Trim();

            connection.Close();
            return Convert.ToSingle(sotienno);

        }
        public float LHDBS_LietKeTiLeDonGiaBan()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            //int id;
            SqlCommand command = new SqlCommand("LietKeTiLeDonGiaBan", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string tile = dt.Rows[0]["GiaTri"].ToString().Trim();

            connection.Close();
            return Convert.ToSingle(tile);
        }
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

            
            comboBoxLHDBS_MaKH.DisplayMember = dt.Columns[0].ToString();
            comboBoxLHDBS_MaKH.ValueMember = dt.Columns[0].ToString();
            comboBoxLHDBS_MaKH.DataSource = dt;
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
            
            comboBoxLHDBS_MaSach.DisplayMember =dt.Columns[0].ToString();
            comboBoxLHDBS_MaSach.ValueMember = dt.Columns[0].ToString();
            comboBoxLHDBS_MaSach.DataSource = dt;
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

            connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand Command = new SqlCommand("LietKeDonGiaNhapTheoMaSach", connection);
            Command.CommandType = CommandType.StoredProcedure;
            p = new SqlParameter("@MaSach", Convert.ToInt32(comboBoxLHDBS_MaSach.Text));
            Command.Parameters.Add(p);
            Command.ExecuteNonQuery();
            reader = Command.ExecuteReader();
            while (reader.Read())
            {
                string dongianhap = (string)reader["DonGiaNhap"].ToString();                
                textBoxLHDBS_DonGiaBan.Text = String.Format("{0:0,0}", Convert.ToDouble(dongianhap)* LHDBS_LietKeTiLeDonGiaBan()).ToString();
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
                    if (dataGridViewLHDBS_DanhSachMua.Rows.Count == 0)
                    {
                        dataGridViewLHDBS_DanhSachMua.Rows.Add(1);

                    }
                    //dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
                    kiemtraluu = 1;
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
                        int SLTon = LPNS_LietKeSLT(Convert.ToInt32(comboBoxLHDBS_MaSach.Text));
                        int  SLtonmin = LHDBS_SLTonMinSauKhiBan();
                        if (SLtonmin > SLTon-Convert.ToInt32(textBoxLHDBS_SoLuong.Text))
                        {
                            string str = "Số lượng tồn tối thiểu " + SLtonmin.ToString();
                            MessageBox.Show(str, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //dataGridViewLHDBS_DanhSachMua.Rows.Remove(dataGridViewLHDBS_DanhSachMua.Rows[dataGridViewLHDBS_DanhSachMua.Rows.Count - 1]);
                        }
                        else
                        {
                            dataGridViewLHDBS_DanhSachMua[0, indexRow].Value = dataGridViewLHDBS_DanhSachMua.Rows.Count;
                            dataGridViewLHDBS_DanhSachMua[1, indexRow].Value = comboBoxLHDBS_MaSach.Text;
                            dataGridViewLHDBS_DanhSachMua[2, indexRow].Value = textBoxLHDBS_TenDauSach.Text;
                            dataGridViewLHDBS_DanhSachMua[3, indexRow].Value = textBoxLHDBS_NhaXuatBan.Text;
                            dataGridViewLHDBS_DanhSachMua[4, indexRow].Value = textBoxLHDBS_NamXuatBan.Text;
                            dataGridViewLHDBS_DanhSachMua[5, indexRow].Value = textBoxLHDBS_TheLoai.Text;
                            dataGridViewLHDBS_DanhSachMua[6, indexRow].Value = textBoxLHDBS_SoLuong.Text;
                            dataGridViewLHDBS_DanhSachMua[7, indexRow].Value = textBoxLHDBS_DonGiaBan.Text;
                            float soluongban = (float)Convert.ToDouble(textBoxLHDBS_SoLuong.Text);
                            float dongiaban = (float)Convert.ToDouble(textBoxLHDBS_DonGiaBan.Text);
                            dataGridViewLHDBS_DanhSachMua[8, indexRow].Value = (soluongban * dongiaban).ToString();
                            tongtienmua = tongtienmua + (float)Convert.ToDouble(dataGridViewLHDBS_DanhSachMua[8, indexRow].Value.ToString());
                            double sum=Math.Round(tongtienmua, 2, MidpointRounding.ToEven);
                            textBoxLHDBS_TongTien.Text = String.Format("{0:0,0}",sum).ToString(); 
                            textBoxLHDBS_SoLuong.Text = "";
                            textBoxLHDBS_DonGiaBan.Text = "";
                            dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
                            MessageBox.Show("Thêm thành công!");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại!");
                        //dataGridViewLHDBS_DanhSachMua.Rows.Remove(dataGridViewLHDBS_DanhSachMua.Rows[dataGridViewLHDBS_DanhSachMua.Rows.Count - 1]);
                        return;
                    }


                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!");
            }
            

        }

        private void buttonLHDBS_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!");
            }
        }

        private void buttonLHDBS_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int SLTon = LPNS_LietKeSLT(Convert.ToInt32(comboBoxLHDBS_MaSach.Text));
                int SLtonmin = LHDBS_SLTonMinSauKhiBan();
                if (SLtonmin > SLTon - Convert.ToInt32(textBoxLHDBS_SoLuong.Text))
                {
                    string str = "Số lượng tồn tối thiểu " + SLtonmin.ToString();
                    MessageBox.Show(str, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //dataGridViewLHDBS_DanhSachMua.Rows.Remove(dataGridViewLHDBS_DanhSachMua.Rows[dataGridViewLHDBS_DanhSachMua.Rows.Count - 1]);
                }
                else
                {

                    DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn cập nhật?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {

                        if (textBoxLHDBS_SoLuong.Text == "" || textBoxLHDBS_DonGiaBan.Text == "")
                        {
                            MessageBox.Show("Lỗi! Vui lòng nhập đầy đủ thông tin!");
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
                            MessageBox.Show("Cập nhật thành công!");
                        }
                    }
                    else return;



                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!");
            }

        }

        private void panelLapHoaDonBanSach_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {

                LapHoaDon_LuuHD.Visible = false;
                dataGridViewLHDBS_DanhSachMua.Rows.Clear();
                dataGridViewLHDBS_DanhSachMua.AllowUserToAddRows = false;
                dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
                buttonLHDBS_ThemMoi.Text = "Thêm mới";
                textBoxLHDBS_TongTien.Text = "";
                tongtienmua = 0;
                textBoxLHDBS_SoTienTra.Text = "";
                textBoxLHDBS_SoLuong.Text = "";
                textBox_LHDBS_ConLai.Text = "";

            }
            if (themmoihd == 0)
            {
                buttonLHDBS_Them.Enabled = false;
                buttonLHDBS_Xoa.Enabled = false;
                buttonLHDBS_CapNhat.Enabled = false;
                dataGridViewLHDBS_DanhSachMua.Enabled = false;
                buttonLHDBS_ThemMoi.Visible = true;
                LHDBS_huy.Visible = false;
                LapHoaDon_LuuHD.Visible = false;


            }
            else
            {
                buttonLHDBS_Them.Enabled = true;
                buttonLHDBS_Xoa.Enabled = true;
                buttonLHDBS_CapNhat.Enabled = true;
                dataGridViewLHDBS_DanhSachMua.Enabled = true;
                buttonLHDBS_ThemMoi.Visible = false;
                LHDBS_huy.Visible = true;
                LapHoaDon_LuuHD.Visible = true;

            }
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
            themmoihd = 0;
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
                if(textBoxLHDBS_SoTienTra.Text.Trim()=="")
                {
                    MessageBox.Show("Vui lòng nhập số tiền trả!");
                    textBoxLHDBS_TongTien.Text = "";
                    return;
                }
                try
                {
                    
                    LapHoaDon_LuuHD.Visible = false;
                    buttonLHDBS_ThemMoi.Text = "Thêm mới";
                    float sotienno= LHDBS_LietKeSoTienNo(Convert.ToInt32(comboBoxLHDBS_MaKH.Text));
                    float sotiennotoida = LHDBS_LietKeSoTienNoToiDa();
                    if (sotiennotoida < sotienno)
                    {
                        string str = "Số tiền nợ lớn hơn " + sotiennotoida.ToString();
                        MessageBox.Show(str, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {


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
                        for (int i = 0; i < dataGridViewLHDBS_DanhSachMua.Rows.Count-1; i++)
                        {
                            string MaSach = dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[1].Value.ToString();
                            int ms = Convert.ToInt32(MaSach);
                            string sl = dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[6].Value.ToString();
                            float slb = (float)Convert.ToDouble(sl);
                            string dg = dataGridViewLHDBS_DanhSachMua.Rows[i].Cells[7].Value.ToString();
                            float dgb = (float)Convert.ToDouble(dg);
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
                        for (int i = 0; i < dataGridViewLHDBS_DanhSachMua.Rows.Count-2; i++)
                        {
                            dataGridViewLHDBS_DanhSachMua.Rows.Clear();
                        }
                        dataGridViewLHDBS_DanhSachMua.AllowUserToAddRows = false;
                        dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
                        MessageBox.Show("Thêm thành công");
                        kiemtraluu = 0;
                        textBoxLHDBS_TongTien.Text = "";
                        textBoxLHDBS_SoTienTra.Text = "";

                        connection.Close();
                    }
                    
                }
                catch
                {
                    LapHoaDon_LuuHD.Visible = false;
                    buttonLHDBS_ThemMoi.Text = "Thêm mới";
                    kiemtraluu = 0;
                    MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!");
                }
            }
            else
            {
                MessageBox.Show("Chưa có chi tiết hóa đơn!");
                return;
            }
        }
        private void textBoxLHDBS_SoTienTra_TextChanged(object sender, EventArgs e)
        {
            float sotientra;
            float tongsotien;
            if (textBoxLHDBS_SoTienTra.Text == "") sotientra = 0;
            else    sotientra = (float)Convert.ToDouble(textBoxLHDBS_SoTienTra.Text);
            if (textBoxLHDBS_TongTien.Text == "") tongsotien = 0;
            else tongsotien = (float)Convert.ToDouble(textBoxLHDBS_TongTien.Text);
            textBox_LHDBS_ConLai.Text = String.Format("{0:0,0}",(tongsotien - sotientra)).ToString() ;


        }
        private void buttonLHDBS_ThemMoi_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            themmoihd = 1;
            textBoxLHDBS_SoTienTra.Text = "";
            textBoxLHDBS_SoLuong.Text = "";
            textBoxLHDBS_DonGiaBan.Text = "";
            LapHoaDon_LuuHD.Visible = true;

            textBoxLHDBS_TongTien.Text = "0";
            dataGridViewLHDBS_DanhSachMua.Rows.Clear();
            dataGridViewLHDBS_DanhSachMua.AllowUserToAddRows = false;
            dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
        }
        private void LHDBS_huy_Click(object sender, EventArgs e)
        {

            kiemtraluu = 0;
            themmoihd = 0;
            textBoxLHDBS_SoTienTra.Text = "";
            textBoxLHDBS_SoLuong.Text = "";
            textBoxLHDBS_DonGiaBan.Text = "";
            LapHoaDon_LuuHD.Visible = false;
            //buttonLHDBS_ThemMoi.Text = "Thêm mới";

            textBoxLHDBS_TongTien.Text = "0";
            dataGridViewLHDBS_DanhSachMua.Rows.Clear();
            dataGridViewLHDBS_DanhSachMua.AllowUserToAddRows = false;
            dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
        }
        private void buttonLapHoaDonBanSach_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    themmoihd = 0;
                    LapHoaDon_LuuHD.Visible = false;
                    buttonLPNS_huy.Visible = false;
                    dataGridViewLHDBS_DanhSachMua.Rows.Clear();
                    dataGridViewLHDBS_DanhSachMua.AllowUserToAddRows = false;
                    dataGridViewLHDBS_DanhSachMua.Rows.Add(1);
                    textBoxLHDBS_TongTien.Text = "";
                    tongtienmua = 0;
                    textBoxLHDBS_SoTienTra.Text = "";
                    textBoxLHDBS_SoLuong.Text = "";
                    textBox_LHDBS_ConLai.Text = "";
                    panelLapHoaDonBanSach.BringToFront();

                }
                else return;
            }
            else panelLapHoaDonBanSach.BringToFront();

            LPHD_LoadComboboxMaKH();
        }
    }
}
