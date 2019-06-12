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
    public partial class FormThemTheLoai : Form
    {
        public FormThemTheLoai()
        {
            InitializeComponent();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (textBoxTenTheLoai.Text == "")
            {
                MessageBox.Show("Nhập tên nhà xuất bản");
                return;
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Global.ConnectionStr;
            connection.Open();
            SqlCommand command = new SqlCommand("ThemTheLoai", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@TenTheLoai", textBoxTenTheLoai.Text);
            command.Parameters.Add(p);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thêm Thành Công !");

            }
            else MessageBox.Show("Thêm thất bại!");
            connection.Close();
        }
    }
}
