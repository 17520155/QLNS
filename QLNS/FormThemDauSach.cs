using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormThemDauSach : Form
    {
        public FormThemDauSach()
        {
            InitializeComponent();
        }

        private void buttonThemMaTheLoai_Click(object sender, EventArgs e)
        {
            Form formThemTheLoai = new FormThemTheLoai();
            formThemTheLoai.ShowDialog();
        }

        private void buttonThemMaTacGia_Click(object sender, EventArgs e)
        {
            Form formThemTacGia = new FormThemTacGia();
            formThemTacGia.ShowDialog();
        }
    }
}
