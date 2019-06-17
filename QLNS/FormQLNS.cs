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
            panelTrangChu.BringToFront();
        }

        private void buttonNhapSach_Click(object sender, EventArgs e)
        {
            panelLapPhieuNhapSach.BringToFront();
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
            //QLTacGia
            dataGridViewQLK_QLTG.AutoGenerateColumns = false;
            dataGridViewQLK_QLTG.Columns[0].DataPropertyName = "STT";
            dataGridViewQLK_QLTG.Columns[1].DataPropertyName = "MaTacGia";
            dataGridViewQLK_QLTG.Columns[2].DataPropertyName = "TenTacGia";
            QLTG_LoadData();
            //QLNhaXuatBan
            dataGridViewQLK_QLNXB.AutoGenerateColumns = false;
            dataGridViewQLK_QLNXB.Columns[0].DataPropertyName = "STT";
            dataGridViewQLK_QLNXB.Columns[1].DataPropertyName = "MaNXB";
            dataGridViewQLK_QLNXB.Columns[2].DataPropertyName = "TenNXB";
            QLNXB_LoadData();

            //QLTheLoai
            dataGridViewQLK_QLTL.AutoGenerateColumns = false;
            dataGridViewQLK_QLTL.Columns[0].DataPropertyName = "STT";
            dataGridViewQLK_QLTL.Columns[1].DataPropertyName = "MaTheLoai";
            dataGridViewQLK_QLTL.Columns[2].DataPropertyName = "TenTheLoai";
            QLTL_LoadData();
        }

        private void buttonLapHoaDonBanSach_Click(object sender, EventArgs e)
        {
            panelLapHoaDonBanSach.BringToFront();
            LPHD_LoadComboboxMaKH();
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
            LPHD_LoadComboboxMaKH();

        }

        private void buttonQLDS_ThemMaTheLoai_Click(object sender, EventArgs e)
        {
            Form formThemTheLoai = new FormThemTheLoai();
            formThemTheLoai.ShowDialog();
            LoadComboboxTheloai();
        }

        private void buttonQLDS_ThemMaTacGia_Click(object sender, EventArgs e)
        {
            Form formThemTacGia = new FormThemTacGia();
            formThemTacGia.ShowDialog();
            LoadComboboxTacGia();

        }

        private void buttonQLS_ThemMaNhaXuatBan_Click(object sender, EventArgs e)
        {
            Form formThemNhaXuatBan = new FormThemNhaXuatBan();
            formThemNhaXuatBan.ShowDialog();
            LoadComboboxMaNXB();
        }

        private void buttonQLS_ThemMaDauSach_Click(object sender, EventArgs e)
        {
            Form formThemDauSach = new FormThemDauSach();
            formThemDauSach.ShowDialog();
            LoadComboboxMaDauSach();

        }

        private void buttonNS_ThemMaSach_Click(object sender, EventArgs e)
        {
            Form formThemSach = new FormThemSach();
            formThemSach.ShowDialog();
            LoadComboboxMaSach();
        }

        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
            panelTrangChu.BringToFront();
        }

        
    }
}
