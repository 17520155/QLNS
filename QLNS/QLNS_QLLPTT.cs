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
        private void buttonLPTT_Them_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            buttonLPTT_Luu.Visible = true;
            buttonLPTT_huy.Visible = true;
            buttonLPTT_Them.Visible = false;
            //buttonLPTT_Them.Text = "Hủy";
            buttonLPTT_Xoa.Enabled = false;
            buttonLPTT_CapNhat.Enabled = false;
            comboBoxLPTT_MaPhieuThu.Enabled = false;
            dateTimePickerLPTT_NgayThu.Text = "";
            textBoxLPT_SoTienThu.Text = "";
            dataGridViewLPTT_DanhSachPhieuThu.Enabled = false;
            comboBoxLPTT_MaPhieuThu.Text = "";

        }

        private void buttonLPTT_Luu_Click(object sender, EventArgs e)
        {
            buttonLPTT_Luu.Visible = false;
            buttonLPTT_huy.Visible = false;
            buttonLPTT_Them.Visible = true;
            //buttonLPTT_Them.Text = "Thêm";
            buttonLPTT_Xoa.Enabled = true;
            buttonLPTT_CapNhat.Enabled = true;
            comboBoxLPTT_MaPhieuThu.Enabled = true;
            dataGridViewLPTT_DanhSachPhieuThu.Enabled = true;
            if (textBoxLPT_SoTienThu.Text.Trim() =="")
            {
                MessageBox.Show("Lỗi! Vui lòng nhập đầy đủ thông tin!");
                kiemtraluu = 0;
                return;
            }
            if (kiemtrasotienthu() == 1)
            {
                float tienno = LHDBS_LietKeSoTienNo(Convert.ToInt32(comboBoxLPTT_MaKH.Text));
                if (tienno < (float)Convert.ToDouble(textBoxLPT_SoTienThu.Text))
                {
                    MessageBox.Show("Số tiền thu vượt quá số tiền đang nợ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("ThemPhieuThu", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@MaKH", comboBoxLPTT_MaKH.Text);
                    command.Parameters.Add(p);
                    DateTime date = DateTime.ParseExact(dateTimePickerLPTT_NgayThu.Text, "dd-MM-yyyy", null);
                    p = new SqlParameter("@NgayThuTien", date);
                    command.Parameters.Add(p);
                    p = new SqlParameter("@SoTienThu", textBoxLPT_SoTienThu.Text);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                        kiemtraluu = 0;
                        QLPTT_LoadData();

                    }
                    connection.Close();
                }
            }
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();
                SqlCommand command = new SqlCommand("ThemPhieuThu", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKH", comboBoxLPTT_MaKH.Text);
                command.Parameters.Add(p);
                DateTime date = DateTime.ParseExact(dateTimePickerLPTT_NgayThu.Text, "dd-MM-yyyy", null);
                p = new SqlParameter("@NgayThuTien", date);
                command.Parameters.Add(p);
                p = new SqlParameter("@SoTienThu", textBoxLPT_SoTienThu.Text);
                command.Parameters.Add(p);
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    kiemtraluu = 0;
                    QLPTT_LoadData();

                }
                connection.Close();
            }
        }
        public void QLPTT_LoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();            
            DataTable dt = new DataTable();           
            SqlCommand Command = new SqlCommand("LietKePhieuThuKH", connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.ExecuteNonQuery();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            Adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;


            }
            dataGridViewLPTT_DanhSachPhieuThu.DataSource = dt;
            QLPT_LoadComboboxPhieuThu();
            connection.Close();

        }
        public void QLPT_LoadComboboxPhieuThu()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKePhieuThuTien", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            
            comboBoxLPTT_MaPhieuThu.DisplayMember = dt.Columns[0].ToString();
            comboBoxLPTT_MaPhieuThu.ValueMember = dt.Columns[0].ToString();
            comboBoxLPTT_MaPhieuThu.DataSource = dt;
            connection.Close();

        }
        public void QLPT_LoadComboboxMaKH()
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
            
            comboBoxLPTT_MaKH.DisplayMember = dt.Columns[0].ToString();
            comboBoxLPTT_MaKH.ValueMember = dt.Columns[0].ToString();
            comboBoxLPTT_MaKH.DataSource = dt;
            connection.Close();
        }
        private void comboBoxLPTT_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeKhachHangTheoMaKH", connection);
            string id = comboBoxLPTT_MaKH.Text;
            SqlParameter p = new SqlParameter("MaKH", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;            
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string hotenkh = (string)reader["HoTenKH"].ToString();
                textBoxLPTT_TenKH.Text = hotenkh;
                string Email = (string)reader["Email"].ToString();
                textBoxLPTT_Email.Text = Email;
                string DiaChi = (string)reader["DiaChi"].ToString();
                textBoxLPTT_DiaChi.Text = DiaChi;
                string DienThoai = (string)reader["DienThoai"].ToString();
                textBoxLPTT_DienThoai.Text = DienThoai;

            }
          
            connection.Close();             


        }
        private void dataGridViewLPTT_DanhSachPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.ColumnIndex >=0)
            {
                comboBoxLPTT_MaPhieuThu.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[1].Value);
                comboBoxQLK__MaTheLoai.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[2].Value);
                textBoxLPTT_TenKH.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[3].Value);
                textBoxLPTT_DienThoai.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[4].Value);
                textBoxLPTT_Email.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[5].Value);
                textBoxLPTT_DiaChi.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[6].Value);
                dateTimePickerLPTT_NgayThu.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[7].Value);
                textBoxLPT_SoTienThu.Text = Convert.ToString(dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[8].Value);
            }

        }

        private void buttonLPTT_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaPhieuThuTheoSoPhieuThu", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("SoPhieuThu", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        QLPTT_LoadData();

                    }
                    connection.Close();
                }
                catch
                {
                    comboBoxLPTT_MaPhieuThu.Text = "";
                    dateTimePickerLPTT_NgayThu.Text = "";
                    textBoxLPT_SoTienThu.Text = "";
                    MessageBox.Show("Lỗi! Vui lòng kiểm tra lại!");
                }

            }
            else
                return;
            

        }

        private void buttonLPTT_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemtrasotienthu() == 1)
                {
                    float tienno = LHDBS_LietKeSoTienNo(Convert.ToInt32(comboBoxLPTT_MaKH.Text));
                    if (tienno < (float)Convert.ToDouble(textBoxLPT_SoTienThu.Text))
                    {
                        MessageBox.Show("Số tiền thu vượt quá số tiền đang nợ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn cập nhật?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {

                            SqlConnection connection = new SqlConnection();
                            connection.ConnectionString = Global.ConnectionStr;
                            connection.Open();
                            //Sua ngay thu tien
                            SqlCommand command = new SqlCommand("SuaNgayThuTien", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            //int id = (int)dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[1].Value;
                            int id = Convert.ToInt32(comboBoxLPTT_MaPhieuThu.Text);
                            SqlParameter p = new SqlParameter("@SoPhieuThu", id);
                            command.Parameters.Add(p);
                            DateTime date = DateTime.ParseExact(dateTimePickerLPTT_NgayThu.Text, "dd-MM-yyyy", null);
                            p = new SqlParameter("@NgayThuTien", date);
                            command.Parameters.Add(p);
                            int count = command.ExecuteNonQuery();
                            if (count > 0)
                            {
                                QLPTT_LoadData();

                            }

                            SqlCommand Command = new SqlCommand("SuaSoTienThu", connection);
                            Command.CommandType = CommandType.StoredProcedure;
                            p = new SqlParameter("@SoPhieuThu", id);
                            Command.Parameters.Add(p);
                            p = new SqlParameter("@SoTienThu", textBoxLPT_SoTienThu.Text);
                            Command.Parameters.Add(p);


                            count = Command.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                QLPTT_LoadData();

                            }

                            connection.Close();
                        }
                        else return;
                    }
                }
                else
                {
                    DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn cập nhật?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {

                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = Global.ConnectionStr;
                        connection.Open();
                        //Sua ngay thu tien
                        SqlCommand command = new SqlCommand("SuaNgayThuTien", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        //int id = (int)dataGridViewLPTT_DanhSachPhieuThu.CurrentRow.Cells[1].Value;
                        int id = Convert.ToInt32(comboBoxLPTT_MaPhieuThu.Text);
                        SqlParameter p = new SqlParameter("@SoPhieuThu", id);
                        command.Parameters.Add(p);
                        DateTime date = DateTime.ParseExact(dateTimePickerLPTT_NgayThu.Text, "dd-MM-yyyy", null);
                        p = new SqlParameter("@NgayThuTien", date);
                        command.Parameters.Add(p);
                        int count = command.ExecuteNonQuery();
                        if (count > 0)
                        {
                            QLPTT_LoadData();

                        }

                        SqlCommand Command = new SqlCommand("SuaSoTienThu", connection);
                        Command.CommandType = CommandType.StoredProcedure;
                        p = new SqlParameter("@SoPhieuThu", id);
                        Command.Parameters.Add(p);
                        p = new SqlParameter("@SoTienThu", textBoxLPT_SoTienThu.Text);
                        Command.Parameters.Add(p);


                        count = Command.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("Cập Nhật Thành Công !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            QLPTT_LoadData();

                        }

                        connection.Close();
                    }
                    else return;

                }

                
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại! ", "Thông Báo",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void groupBoxLPTT_ChiTietThuTien_Enter(object sender, EventArgs e)
        {
           // QLPTTLoadData();

        }

        private void panelLapPhieuThuTien_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {
                buttonLPTT_Luu.Visible = false;
                buttonLPTT_Them.Visible =true;
                buttonLPTT_huy.Visible = false;
                buttonLPTT_Xoa.Enabled = true;
                buttonLPTT_CapNhat.Enabled = true;
                comboBoxLPTT_MaPhieuThu.Enabled = true;
                dataGridViewLPTT_DanhSachPhieuThu.Enabled = true;
                textBoxLPT_SoTienThu.Text = "";


            }

            dataGridViewLPTT_DanhSachPhieuThu.AutoGenerateColumns = false;
            dataGridViewLPTT_DanhSachPhieuThu.Columns[0].DataPropertyName = "STT";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[1].DataPropertyName = "SoPhieuThu";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[2].DataPropertyName = "MaKH";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[3].DataPropertyName = "HoTenKH";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[4].DataPropertyName = "DienThoai";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[5].DataPropertyName = "Email";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[6].DataPropertyName = "DiaChi";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[7].DataPropertyName = "NgayThuTien";
            dataGridViewLPTT_DanhSachPhieuThu.Columns[8].DataPropertyName = "SoTienThu";
            QLPT_LoadComboboxMaKH();
            QLPTT_LoadData();
            


        }
        private void buttonLPTT_huy_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            buttonLPTT_Luu.Visible = false;
            buttonLPTT_huy.Visible = false;
            buttonLPTT_Them.Visible = true;
            //buttonLPTT_Them.Text = "Hủy";
            buttonLPTT_Xoa.Enabled = true;
            buttonLPTT_CapNhat.Enabled = true;
            comboBoxLPTT_MaPhieuThu.Enabled = true;
            dateTimePickerLPTT_NgayThu.Text = "";
            textBoxLPT_SoTienThu.Text = "";
            dataGridViewLPTT_DanhSachPhieuThu.Enabled = true;
            comboBoxLPTT_MaPhieuThu.Text = "";

        }
        public int kiemtrasotienthu()
        {
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            //int id;
            SqlCommand command = new SqlCommand("LietKeKiemTraSoTienThu", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string ktsotienthu = dt.Rows[0]["GiaTri"].ToString().Trim();

            connection.Close();
            return Convert.ToInt32(ktsotienthu);

        }
        private void buttonLapPhieuThuTien_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    buttonLPTT_Luu.Visible = false;
                    buttonLPTT_Them.Visible = true;
                    buttonLPTT_huy.Visible = false;
                    buttonLPTT_Xoa.Enabled = true;
                    buttonLPTT_CapNhat.Enabled = true;
                    comboBoxLPTT_MaPhieuThu.Enabled = true;
                    dataGridViewLPTT_DanhSachPhieuThu.Enabled = true;
                    textBoxLPT_SoTienThu.Text = "";
                    panelLapPhieuThuTien.BringToFront();

                }
                else return;
            }
            else panelLapPhieuThuTien.BringToFront();

        }

    }

}
