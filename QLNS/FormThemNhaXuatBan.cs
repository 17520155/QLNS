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
    public partial class FormThemNhaXuatBan : Form
    {
        public FormThemNhaXuatBan()
        {
            InitializeComponent();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (textBoxTenNhaXuatBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemNXB", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p;
            p = new SqlParameter(@"TenNXB", textBoxTenNhaXuatBan.Text);
            command.Parameters.Add(p);

            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBoxTenNhaXuatBan.Text = "";
            }

            connection.Close();
        }
    }
}
