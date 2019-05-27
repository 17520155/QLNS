using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

enum Panel_Type
{
    NhapSach = 0,
    QuanLySach = 1,
    QuanLyDauSach = 2,
}

namespace QLNS
{
    public partial class FormQLNS : Form
    {
        public FormQLNS()
        {
            InitializeComponent();
            panelNhapSach.BringToFront();
        }

        private void buttonNhapSach_Click(object sender, EventArgs e)
        {
            panelNhapSach.BringToFront();
        }

        private void buttonQuanLySach_Click(object sender, EventArgs e)
        {
            panelQuanLySach.BringToFront();
        }

        private void buttonQuanLyDauSach_Click(object sender, EventArgs e)
        {
            panelQuanLyDauSach.BringToFront();
        }

        private void buttonKhac_Click(object sender, EventArgs e)
        {
            panelQuanLyKhac.BringToFront();
        }

        private void buttonLapHoaDonBanSach_Click(object sender, EventArgs e)
        {
            panelLapHoaDonBanSach.BringToFront();
        }

        private void buttonQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            panelQuanLyKhachHang.BringToFront();
        }

        private void buttonLapPhieuThuTien_Click(object sender, EventArgs e)
        {
            panelLapPhieuThuTien.BringToFront();
        }

        private void buttonBaoCaoSachTon_Click(object sender, EventArgs e)
        {
            panelBaoCaoSachTon.BringToFront();
        }

        private void buttonBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            panelBaoCaoCongNo.BringToFront();
        }

        private void buttonThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            panelThayDoiQuyDinh.BringToFront();
        }

        private void buttonTraCuu_Click(object sender, EventArgs e)
        {
            panelTraCuu.BringToFront();
        }

        private void buttonLHDBS_ThemMaKH_Click(object sender, EventArgs e)
        {
            Form formThemKH = new FormThemKH();
            formThemKH.ShowDialog();
        }

        private void buttonQLDS_ThemMaTheLoai_Click(object sender, EventArgs e)
        {
            Form formThemTheLoai = new FormThemTheLoai();
            formThemTheLoai.ShowDialog();
        }

        private void buttonQLDS_ThemMaTacGia_Click(object sender, EventArgs e)
        {
            Form formThemTacGia = new FormThemTacGia();
            formThemTacGia.ShowDialog();
        }

        private void buttonQLS_ThemMaNhaXuatBan_Click(object sender, EventArgs e)
        {
            Form formThemNhaXuatBan = new FormThemNhaXuatBan();
            formThemNhaXuatBan.ShowDialog();
        }

        private void buttonQLS_ThemMaDauSach_Click(object sender, EventArgs e)
        {
            Form formThemDauSach = new FormThemDauSach();
            formThemDauSach.ShowDialog();
        }

        private void buttonNS_ThemMaSach_Click(object sender, EventArgs e)
        {
            Form formThemSach = new FormThemSach();
            formThemSach.ShowDialog();
        }
    }
}
