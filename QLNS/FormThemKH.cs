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
    public partial class FormThemKH : Form
    {
        public FormThemKH()
        {
            InitializeComponent();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (textBoxTenKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
          
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemKhachHang", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p;
            p = new SqlParameter("@HoTenKH", textBoxTenKH.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@DiaChi", textBoxDiaChi.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@DienThoai", textBoxDienThoai.Text);
            command.Parameters.Add(p);
            p = new SqlParameter("@Email", textBoxEmail.Text);
            command.Parameters.Add(p);

            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Thêm thành công!","Thông Báo!",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                textBoxTenKH.Text = "";
                textBoxDiaChi.Text = "";
                textBoxDienThoai.Text = "";
                textBoxEmail.Text = "";
            }

            connection.Close();
        }
    }
}
