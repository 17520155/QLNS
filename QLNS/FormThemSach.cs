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
    public partial class FormThemSach : Form
    {
        public FormThemSach()
        {
            InitializeComponent();
        }

        private void buttonThemMaDauSach_Click(object sender, EventArgs e)
        {
            Form formThemDauSach = new FormThemDauSach();
            formThemDauSach.ShowDialog();
        }

        private void buttonThemMaNhaXuatBan_Click(object sender, EventArgs e)
        {
            Form formThemNhaXuatBan = new FormThemNhaXuatBan();
            formThemNhaXuatBan.ShowDialog();
        }
    }
}
