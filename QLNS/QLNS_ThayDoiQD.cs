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
        
        public void TDQD_SoLuongNhapToiThieu()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand command = new SqlCommand("LietKeSoLuongNhapToiThieu", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();    

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string soluongnhaptoithieu = (string)reader["GiaTri"].ToString();
                textBoxTDQD_SoLuongNhapToiThieu.Text = soluongnhaptoithieu;

            }
            connection.Close();

        }
        public void TDQD_SoLuongTonToiThieu()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("LietKeSoLuongTonToiThieu", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string soluongtontoithieu = (string)reader["GiaTri"].ToString();
                textBoxTDQD_SoLuongTonToiDa.Text = soluongtontoithieu;

            }
            connection.Close();

        }
        public void TDQD_TiLeDonGiaBan()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand command = new SqlCommand("LietKeTiLeDonGiaBan", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tiledongiaban = (string)reader["GiaTri"].ToString();
                textBoxTDQD_TiLeDonGiaBan.Text = tiledongiaban;

            }
            connection.Close();

        }
        public void TDQD_SoTienNoToiDa()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand command = new SqlCommand("LietKeSoTienNoToiDa", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string sotiennotoida = (string)reader["GiaTri"].ToString();
                textBoxTDQD_SoTienNoToiDa.Text = sotiennotoida;

            }
            connection.Close();

        }
        public void TDQD_SoLuongTonToiThieuSauKhiBan()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand command = new SqlCommand("LietKeSLTonMinSauKhiBan", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string soluongtontoithieusaukhiban = (string)reader["GiaTri"].ToString();
                textBoxTDQD_SoLuongTonToiThieu.Text = soluongtontoithieusaukhiban;

            }
            connection.Close();

        }
        public void TDQD_KiemTraSoTienThu()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand command = new SqlCommand("LietKeKiemTraSoTienThu", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string kiemtrasotienthu = (string)reader["GiaTri"].ToString();
                if (Convert.ToInt32(kiemtrasotienthu) == 1) radioButtonTDQD_KiemTraSoTienThu_Yes.Checked = true;
                else if (Convert.ToInt32(kiemtrasotienthu) == 0) radioButtonButtonTDQD_KiemTraSoTienThu_No.Checked = true;

            }
            connection.Close();

        }
        private void buttonButtonTDQD_Luu_Click(object sender, EventArgs e)
        {
            buttonButtonTDQD_Luu.Enabled = false;
            buttonButtonTDQD_huy.Visible = false;
            buttonButtonTDQD_Sua.Visible = true;
            textBoxTDQD_SoLuongNhapToiThieu.Enabled = false;
            textBoxTDQD_SoLuongTonToiDa.Enabled = false;
            textBoxTDQD_SoTienNoToiDa.Enabled = false;
            textBoxTDQD_SoLuongTonToiThieu.Enabled = false;
            textBoxTDQD_TiLeDonGiaBan.Enabled = false;
            radioButtonTDQD_KiemTraSoTienThu_Yes.Enabled = false;
            radioButtonButtonTDQD_KiemTraSoTienThu_No.Enabled = false;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();

            SqlCommand command1 = new SqlCommand("SuaSoLuongNhapToiThieu", connection);
            command1.CommandType = CommandType.StoredProcedure;
            //int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
            float value = Convert.ToSingle(textBoxTDQD_SoLuongNhapToiThieu.Text);
            SqlParameter p = new SqlParameter("@GiaTri", value);
            command1.Parameters.Add(p);
            int count = command1.ExecuteNonQuery();
            if (count > 0)
            {
                //MessageBox.Show("Cập Nhật Thành Công !", "Thông báo!");
                TDQD_SoLuongNhapToiThieu();

            }

            SqlCommand command2 = new SqlCommand("SuaSoLuongTonToiThieu", connection);
            command2.CommandType = CommandType.StoredProcedure;
            //int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
            value = Convert.ToSingle(textBoxTDQD_SoLuongTonToiDa.Text);
            p = new SqlParameter("@GiaTri", value);
            command2.Parameters.Add(p);
            count = command2.ExecuteNonQuery();
            if (count > 0)
            {
                TDQD_SoLuongTonToiThieu();

            }

            SqlCommand command3 = new SqlCommand("SuaSoTienNoToiDa", connection);
            command3.CommandType = CommandType.StoredProcedure;
            //int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
            value = Convert.ToSingle(textBoxTDQD_SoTienNoToiDa.Text);
            p = new SqlParameter("@GiaTri", value);
            command3.Parameters.Add(p);
            count = command3.ExecuteNonQuery();
            if (count > 0)
            {
                TDQD_SoTienNoToiDa();

            }

            SqlCommand command4 = new SqlCommand("SuaSLTonMinSauKhiBan", connection);
            command4.CommandType = CommandType.StoredProcedure;
            //int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
            value = Convert.ToSingle(textBoxTDQD_SoLuongTonToiThieu.Text);
            p = new SqlParameter("@GiaTri", value);
            command4.Parameters.Add(p);
            count = command4.ExecuteNonQuery();
            if (count > 0)
            {
                TDQD_SoLuongTonToiThieuSauKhiBan();

            }

            SqlCommand command5 = new SqlCommand("SuaTiLeDongiaBan", connection);
            command5.CommandType = CommandType.StoredProcedure;
            //int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
            value = float.Parse(textBoxTDQD_TiLeDonGiaBan.Text);
            
            p = new SqlParameter("@GiaTri", Math.Round(value, 2, MidpointRounding.ToEven));
            command5.Parameters.Add(p);
            count = command5.ExecuteNonQuery();
            if (count > 0)
            {
                TDQD_TiLeDonGiaBan();

            }

            SqlCommand command6 = new SqlCommand("SuaKiemTraSoTienThu", connection);
            command6.CommandType = CommandType.StoredProcedure;
            //int id = (int)dataGridViewQLKH_DanhSachKH.CurrentRow.Cells[1].Value;
            if (radioButtonTDQD_KiemTraSoTienThu_Yes.Checked == true)
            {

                value = 1;

            }
            else
             if (radioButtonButtonTDQD_KiemTraSoTienThu_No.Checked == true)
             {
                value = 0;
             }
            p = new SqlParameter("@GiaTri", value);
            command6.Parameters.Add(p);
            count = command6.ExecuteNonQuery();
            if (count > 0)
            {
                TDQD_KiemTraSoTienThu();

            }


            MessageBox.Show("Thay đổi qui định thành công! ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            connection.Close();

        }

        private void groupBoxTDQD_Enter(object sender, EventArgs e)
        {
            
        }
        private void panelThayDoiQuyDinh_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void buttonThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            textBoxTDQD_SoLuongNhapToiThieu.Enabled = false;
            textBoxTDQD_SoLuongTonToiDa.Enabled = false;
            textBoxTDQD_SoTienNoToiDa.Enabled = false;
            textBoxTDQD_SoLuongTonToiThieu.Enabled = false;
            textBoxTDQD_TiLeDonGiaBan.Enabled = false;
            radioButtonTDQD_KiemTraSoTienThu_Yes.Enabled = false;
            radioButtonButtonTDQD_KiemTraSoTienThu_No.Enabled = false;
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelThayDoiQuyDinh.BringToFront();

                }
                else return;
            }
            else panelThayDoiQuyDinh.BringToFront();
            TDQD_SoLuongNhapToiThieu();
            TDQD_SoLuongTonToiThieu();
            TDQD_TiLeDonGiaBan();
            TDQD_SoTienNoToiDa();
            TDQD_SoLuongTonToiThieuSauKhiBan();
            TDQD_KiemTraSoTienThu();
        }
        private void buttonButtonTDQD_Sua_Click(object sender, EventArgs e)
        {
            buttonButtonTDQD_Luu.Enabled = true;
            textBoxTDQD_SoLuongNhapToiThieu.Enabled = true;
            buttonButtonTDQD_huy.Visible = true;
            buttonButtonTDQD_Sua.Visible = false;
            textBoxTDQD_SoLuongTonToiDa.Enabled = true;
            textBoxTDQD_SoTienNoToiDa.Enabled = true;
            textBoxTDQD_SoLuongTonToiThieu.Enabled = true;
            textBoxTDQD_TiLeDonGiaBan.Enabled = true;
            radioButtonTDQD_KiemTraSoTienThu_Yes.Enabled = true;
            radioButtonButtonTDQD_KiemTraSoTienThu_No.Enabled = true;
        }
        private void buttonButtonTDQD_huy_Click(object sender, EventArgs e)
        {
            buttonButtonTDQD_Luu.Enabled = false;
            textBoxTDQD_SoLuongNhapToiThieu.Enabled = false;
            buttonButtonTDQD_huy.Visible = false;
            buttonButtonTDQD_Sua.Visible = true;
            textBoxTDQD_SoLuongTonToiDa.Enabled = false;
            textBoxTDQD_SoTienNoToiDa.Enabled = false;
            textBoxTDQD_SoLuongTonToiThieu.Enabled = false;
            textBoxTDQD_TiLeDonGiaBan.Enabled = false;
            radioButtonTDQD_KiemTraSoTienThu_Yes.Enabled = false;
            radioButtonButtonTDQD_KiemTraSoTienThu_No.Enabled = false;
            buttonThayDoiQuyDinh_Click(null, null);
        }
    }
}

