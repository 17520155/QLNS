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
        private void buttonQuanLyDauSach_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    buttonQLDS_Luu.Visible = false;
                    buttonQLDS_huy.Visible = false;
                    buttonQLDS_ThemDauSach.Visible = true;
                    buttonQLDS_XoaDauSach.Enabled = true;
                    buttonQLDS_CapNhatDauSach.Enabled = true;
                    comboBoxQLDS_MaDauSach.Enabled = true;
                    comboBoxQLDS_MaDauSach.Text = "";
                    textBoxQLDS_TenDauSach.Text = "";
                    textBoxQLDS_TheLoai.Text = "";
                    comboBoxQLDS_MaTheLoai.Text = "";
                    dataGridViewQLDS_DanhSachDauSach.Enabled = true;

                    panelQuanLyDauSach.BringToFront();

                }
                else return;
            }
            else panelQuanLyDauSach.BringToFront();
        }
        private void buttonQLDS_ThemChiTietTacGia_Click(object sender, EventArgs e)
        {
            
            dataGridViewQLDS_ChiTietTacGia.AllowUserToAddRows = false;
            if (dataGridViewQLDS_ChiTietTacGia.Rows.Count == 0)
            {
                dataGridViewQLDS_ChiTietTacGia.Rows.Add(1);

            }
            
            int indexRow = dataGridViewQLDS_ChiTietTacGia.Rows.Count - 1;
            kiemtraluu = 1;
            int kt = 0;
            for (int i = 0; i < dataGridViewQLDS_ChiTietTacGia.Rows.Count - 1; i++)
            {
                if (comboBoxQLDS_ThemMaTacGia.Text == dataGridViewQLDS_ChiTietTacGia.Rows[i].Cells[1].Value.ToString())
                {
                    kt = 1;
                    break;
                }
                else
                {
                    kt = 0;
                }

            }
            if(kt==0)
            {
                dataGridViewQLDS_ChiTietTacGia[0, indexRow].Value = dataGridViewQLDS_ChiTietTacGia.Rows.Count;
                dataGridViewQLDS_ChiTietTacGia[1, indexRow].Value = comboBoxQLDS_ThemMaTacGia.Text;
                dataGridViewQLDS_ChiTietTacGia[2, indexRow].Value = textBoxQLDS_TenTacGia.Text;
                dataGridViewQLDS_ChiTietTacGia.Rows.Add(1);
                MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;

            }
            else
            {
                MessageBox.Show("Đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //dataGridViewQLDS_ChiTietTacGia[0, indexRow].Value = dataGridViewQLDS_ChiTietTacGia.Rows.Count;
            //dataGridViewQLDS_ChiTietTacGia[1, indexRow].Value = comboBoxQLDS_ThemMaTacGia.Text;
            //dataGridViewQLDS_ChiTietTacGia[2, indexRow].Value = textBoxQLDS_TenTacGia.Text;
            //kiem tra trung
            //for (int i = 0; i < dataGridViewQLDS_ChiTietTacGia.Rows.Count - 1; i++)
            //{
            //    if (comboBoxQLDS_ThemMaTacGia.Text == dataGridViewQLDS_ChiTietTacGia.Rows[i].Cells[1].Value.ToString())
            //    {
            //        MessageBox.Show("Đã có  tồn tại tác giả !");
            //        dataGridViewQLDS_ChiTietTacGia.Rows.Remove(dataGridViewQLDS_ChiTietTacGia.Rows[i]);
            //        dataGridViewQLDS_ChiTietTacGia[0, indexRow - 1].Value = dataGridViewQLDS_ChiTietTacGia.Rows.Count;
            //        return;
            //    }
            //}

        }

        private void buttonQLDS_XoaChiTietTacGia_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    int RowIndex = dataGridViewQLDS_ChiTietTacGia.CurrentRow.Index;
                    if (dataGridViewQLDS_ChiTietTacGia.Rows[RowIndex].Cells[0].Value == null)
                    {

                        MessageBox.Show("Lỗi ! Vui lòng kiểm tra lại");
                        return;

                    }
                    else  dataGridViewQLDS_ChiTietTacGia.Rows.RemoveAt(RowIndex);
                    return;


                }
                else return;
            }
            catch
            {
                MessageBox.Show("Chưa có tác giả !");
            }
        }

        private void comboBoxQLDS_ThemMaTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTacGiaTheoMa", connection);
            string id = comboBoxQLDS_ThemMaTacGia.Text;
            SqlParameter p = new SqlParameter("MaTacGia", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tentacgia = (string)reader["TenTacGia"].ToString();
                textBoxQLDS_TenTacGia.Text = tentacgia;



            }

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
            comboBoxQLDS_ThemMaTacGia.DataSource = dt;
            comboBoxQLDS_ThemMaTacGia.DisplayMember = "MaTacGia";
            comboBoxQLDS_ThemMaTacGia.ValueMember = "MaTacGia";
            connection.Close();

        }
        private void buttonQLDS_Luu_Click(object sender, EventArgs e)
        {
            buttonQLDS_Luu.Visible = false;
            buttonQLDS_huy.Visible = false;
            buttonQLDS_ThemDauSach.Visible = true;
            buttonQLDS_XoaDauSach.Enabled = true;
            buttonQLDS_CapNhatDauSach.Enabled = true;
            comboBoxQLDS_MaDauSach.Enabled = true;
            comboBoxQLDS_MaDauSach.Text = "";
            textBoxQLDS_TenDauSach.Text = "";
            textBoxQLDS_TheLoai.Text = "";
            comboBoxQLDS_MaTheLoai.Text = "";
            dataGridViewQLDS_DanhSachDauSach.Enabled = true;
            if (textBoxQLDS_TenDauSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đầu sách");
                kiemtraluu = 0;
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemDauSachMoi", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@TenDauSach", textBoxQLDS_TenDauSach.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@MaTheLoai", comboBoxQLDS_MaTheLoai.Text);
            command.Parameters.Add(p);
            object obj = command.ExecuteScalar();
            int id = Convert.ToInt32(obj);
            for (int i = 0; i < dataGridViewQLDS_ChiTietTacGia.Rows.Count-1; i++)
            {
                string MaTacGia = dataGridViewQLDS_ChiTietTacGia.Rows[i].Cells[1].Value.ToString();
                int tg = Convert.ToInt32(MaTacGia);
                SqlCommand Command = new SqlCommand("ThemChiTietTacGia", connection);
                Command.CommandType = CommandType.StoredProcedure;
                p = new SqlParameter("@MaDauSach", id);
                Command.Parameters.Add(p);
                p = new SqlParameter("@MaTacGia", tg);
                Command.Parameters.Add(p);
                Command.ExecuteNonQuery();
            }
            QLDS_LoadData();
            kiemtraluu = 0;

            dataGridViewQLDS_ChiTietTacGia.Rows.Clear();
            dataGridViewQLDS_ChiTietTacGia.AllowUserToAddRows = false;
            dataGridViewQLDS_ChiTietTacGia.Rows.Add(1);

            MessageBox.Show("Thêm thành công");
            connection.Close();
        }

        private void buttonQLDS_ThemDauSach_Click(object sender, EventArgs e)
        {
            kiemtraluu = 1;
            buttonQLDS_Luu.Visible = true;
            buttonQLDS_huy.Visible = true;
            buttonQLDS_ThemDauSach.Visible = false;
            buttonQLDS_XoaDauSach.Enabled = false;
            buttonQLDS_CapNhatDauSach.Enabled = false;
            comboBoxQLDS_MaDauSach.Enabled = false;
            comboBoxQLDS_MaDauSach.Text = "";
            textBoxQLDS_TenDauSach.Text = "";
            textBoxQLDS_TheLoai.Text = "";
            comboBoxQLDS_MaTheLoai.Text = "";
            dataGridViewQLDS_DanhSachDauSach.Enabled = false;

        }

        private void buttonQLDS_XoaDauSach_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = Global.ConnectionStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand("XoaDauSachTheoMaDauSach", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int id = (int)dataGridViewQLDS_DanhSachDauSach.CurrentRow.Cells[1].Value;
                    SqlParameter p = new SqlParameter("@MaDauSach", id);
                    command.Parameters.Add(p);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa Thành Công !");
                        QLDS_LoadData();
                        QLDS_LoadMaDauSach();
                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
                }
            }
            else return;
        }

        private void buttonQLDS_CapNhatDauSach_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muôn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = Global.ConnectionStr;
                connection.Open();

                SqlCommand command = new SqlCommand("SuaDauSach", connection);

                command.CommandType = CommandType.StoredProcedure;

                int id = (int)dataGridViewQLDS_DanhSachDauSach.CurrentRow.Cells[1].Value;

                SqlParameter p = new SqlParameter("@MaDauSach", id);
                command.Parameters.Add(p);

                p = new SqlParameter("@TenDauSach", textBoxQLDS_TenDauSach.Text);
                command.Parameters.Add(p);
                p = new SqlParameter("@MaTheLoai", Convert.ToInt32(comboBoxQLDS_MaTheLoai.Text));
                command.Parameters.Add(p);

                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Cập Nhật Thành Công !");
                    QLDS_LoadData();

                }
                connection.Close();
            }
            else return;
            

        }
        public void LoadComboboxTheloai()
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
            comboBoxQLDS_MaTheLoai.DataSource = dt;
            comboBoxQLDS_MaTheLoai.DisplayMember = "MaTheLoai";
            comboBoxQLDS_MaTheLoai.ValueMember = "MaTheLoai";
            connection.Close();

        }
        private void comboBoxQLDS_MaTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeTheLoaiTheoMa", connection);
            string id = comboBoxQLDS_MaTheLoai.Text;
            SqlParameter p = new SqlParameter("MaTheLoai", id);
            command.Parameters.Add(p);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tentheloai = (string)reader["TenTheLoai"].ToString();
                textBoxQLDS_TheLoai.Text = tentheloai;

            }

            connection.Close();

        }

        private void dataGridViewQLDS_DanhSachDauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.ColumnIndex>=0)
            {
                comboBoxQLDS_MaDauSach.Text = Convert.ToString(dataGridViewQLDS_DanhSachDauSach.CurrentRow.Cells[1].Value);
                textBoxQLDS_TenDauSach.Text = Convert.ToString(dataGridViewQLDS_DanhSachDauSach.CurrentRow.Cells[2].Value);
                //comboBoxQLDS_MaTheLoai.Text = Convert.ToString(dataGridViewQLDS_DanhSachDauSach.CurrentRow.Cells[3].Value);
                textBoxQLDS_TheLoai.Text = Convert.ToString(dataGridViewQLDS_DanhSachDauSach.CurrentRow.Cells[4].Value);
            }
        }

        private void dataGridViewQLDS_ChiTietTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void QLDS_LoadData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeMaDauSachTenDauSachTacGiaTheLoai", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("STT");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
            dataGridViewQLDS_DanhSachDauSach.DataSource = dt;
            connection.Close();
        }
        public void QLDS_LoadMaDauSach()
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
            comboBoxQLDS_MaDauSach.DataSource = dt;
            comboBoxQLDS_MaDauSach.DisplayMember = "MaDauSach";
            comboBoxQLDS_MaDauSach.ValueMember = "MaDauSach";
            connection.Close();
        }
        private void panelQuanLyDauSach_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {

                dataGridViewQLDS_ChiTietTacGia.Rows.Clear();
                dataGridViewQLDS_ChiTietTacGia.AllowUserToAddRows = false;
                dataGridViewQLDS_ChiTietTacGia.Rows.Add(1);

                buttonQLDS_Luu.Visible = false;
                buttonQLDS_huy.Visible = false;
                buttonQLDS_ThemDauSach.Visible = true;
                buttonQLDS_XoaDauSach.Enabled = true;
                buttonQLDS_CapNhatDauSach.Enabled = true;
                comboBoxQLDS_MaDauSach.Enabled = true;
                comboBoxQLDS_MaDauSach.Text = "";
                textBoxQLDS_TenDauSach.Text = "";
                textBoxQLDS_TheLoai.Text = "";
                comboBoxQLDS_MaTheLoai.Text = "";
                dataGridViewQLDS_DanhSachDauSach.Enabled = true;

            }

            dataGridViewQLDS_DanhSachDauSach.AutoGenerateColumns = false;
            dataGridViewQLDS_DanhSachDauSach.Columns[0].DataPropertyName = "STT";
            dataGridViewQLDS_DanhSachDauSach.Columns[1].DataPropertyName = "MaDauSach";
            dataGridViewQLDS_DanhSachDauSach.Columns[2].DataPropertyName = "TenDauSach";
            dataGridViewQLDS_DanhSachDauSach.Columns[3].DataPropertyName = "TenTacGia";
            dataGridViewQLDS_DanhSachDauSach.Columns[4].DataPropertyName = "TenTheLoai";
            QLDS_LoadData();
            LoadComboboxTacGia();
            LoadComboboxTheloai();
            QLDS_LoadMaDauSach();
        }
        private void comboBoxQLDS_MaDauSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void buttonQLDS_huy_Click(object sender, EventArgs e)
        {
            kiemtraluu = 0;
            buttonQLDS_Luu.Visible = false;
            buttonQLDS_huy.Visible = false;
            buttonQLDS_ThemDauSach.Visible = true;
            buttonQLDS_XoaDauSach.Enabled = true;
            buttonQLDS_CapNhatDauSach.Enabled = true;
            comboBoxQLDS_MaDauSach.Enabled = true;
            comboBoxQLDS_MaDauSach.Text = "";
            textBoxQLDS_TenDauSach.Text = "";
            textBoxQLDS_TheLoai.Text = "";
            comboBoxQLDS_MaTheLoai.Text = "";
            dataGridViewQLDS_DanhSachDauSach.Enabled = true;
        }

    }
}
