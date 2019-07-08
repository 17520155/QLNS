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
        public int kiemtraluu = 0;

       

        private void buttonKhac_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelQuanLyKhac.BringToFront();

                }
                else return;
            }
            else panelQuanLyKhac.BringToFront();

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
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelLapHoaDonBanSach.BringToFront();

                }
                else return;
            }
            else  panelLapHoaDonBanSach.BringToFront();
           
            LPHD_LoadComboboxMaKH();
        }

        private void buttonQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelQuanLyKhachHang.BringToFront();

                }
                else return;
            }
            else panelQuanLyKhachHang.BringToFront();




        }

        private void buttonLapPhieuThuTien_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelLapPhieuThuTien.BringToFront();

                }
                else return;
            }
            else panelLapPhieuThuTien.BringToFront();

        }        

        private void buttonBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelBaoCaoCongNo.BringToFront();

                }
                else return;
            }
            else panelBaoCaoCongNo.BringToFront();


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
            if (kiemtraluu == 1)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu chưa được lưu! Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    kiemtraluu = 0;
                    panelTrangChu.BringToFront();

                }
                else return;
            }
            else panelTrangChu.BringToFront();


        }
        private void panelQuanLyKhac_Paint(object sender, PaintEventArgs e)
        {
            if (kiemtraluu == 0)
            {
                //Nha xuat ban
                buttonQLK_XoaNhaXuatBan.Enabled = true;
                buttonQLK_CapNhatNhaXuatBan.Enabled = true;
                buttonQLK_QLNXB_Luu.Visible = false;
                dataGridViewQLK_QLNXB.Enabled = true;
                comboBoxQLK_MaNhaXuatBan.Enabled = true;
                buttonQLK_ThemNhaXuatBan.Text = "Thêm";
                //tac gia
                buttonQLK_XoaTacGia.Enabled = true;
                buttonQLK_CapNhatTacGia.Enabled = true;
                buttonQLK_QLTG_Luu.Visible = false;
                dataGridViewQLK_QLTG.Enabled = true;
                comboBoxQLK_MaTacGia.Enabled = true;
                buttonQLK_ThemTacGia.Text = "Thêm";
                //the loai
                buttonQLK_XoaTheLoai.Enabled = true;
                buttonQLK_CapNhatTheLoai.Enabled = true;
                buttonQLK_QLTL_Luu.Visible = false;
                dataGridViewQLK_QLTL.Enabled = true;
                comboBoxQLK__MaTheLoai.Enabled = true;
                buttonQLK_ThemTheLoai.Text = "Thêm";

            }
        }

        private void FormQLNS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLNSDataSet.LietKeBaoCaoTon' table. You can move, or remove it, as needed.
            //this.LietKeBaoCaoTonTableAdapter.Fill(this.QLNSDataSet.LietKeBaoCaoTon);
            // TODO: This line of code loads data into the 'QLNSDataSet1.LietKeBaoCaoCongNo' table. You can move, or remove it, as needed.
            //this.LietKeBaoCaoCongNoTableAdapter.Fill(this.QLNSDataSet1.LietKeBaoCaoCongNo);
            this.KeyPreview = true;
            //this.reportViewerBCST.RefreshReport();
            //this.reportViewerBCCN.RefreshReport();
        }

        private void FormQLNS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                //phím tắt thoát chương trình
                if (e.KeyCode.Equals(Keys.X))
                {
                    DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                        this.Close();
                    else return;
                }
                //phím tắt tra cứu
                if (e.KeyCode.Equals(Keys.F))
                {
                    buttonTraCuu_Click(null, null);
                }
                //phím tắt thêm khách hàng
                if (e.KeyCode.Equals(Keys.H))
                {
                    buttonQuanLyKhachHang_Click(null, null);
                }
                //phím tắt  trang chủ
                if (e.KeyCode.Equals(Keys.O))
                {
                    buttonTrangChu_Click(null, null);
                }
                //phím tắt LPNS
                if (e.KeyCode.Equals(Keys.L))
                {
                    buttonNhapSach_Click(null, null);
                }
                //phím tắt QLS
                if (e.KeyCode.Equals(Keys.S))
                {
                    buttonQuanLySach_Click(null, null);
                }
                //Phím tắt QLDS
                if (e.KeyCode.Equals(Keys.D))
                {
                    buttonQuanLyDauSach_Click(null, null);
                }
                //Phím tắt QLkhác
                if (e.KeyCode.Equals(Keys.K))
                {
                    buttonKhac_Click(null, null);
                }
                //phím tắt báo cáo tồn
                if (e.KeyCode.Equals(Keys.A))
                {
                    buttonBaoCaoSachTon_Click(null, null);
                }
                //phím tắt lập hóa đơn
                if (e.KeyCode.Equals(Keys.B))
                {
                    buttonLapHoaDonBanSach_Click(null, null);
                }                
                //phím tắt LPTT
                if (e.KeyCode.Equals(Keys.T))
                {
                    buttonLapPhieuThuTien_Click(null, null);
                }
                //phím tắt lập phiếu nợ
                if (e.KeyCode.Equals(Keys.N))
                {
                    buttonBaoCaoCongNo_Click(null, null);
                }
                //phím tắt thay đổi qui định
                if (e.KeyCode.Equals(Keys.Q))
                {
                    buttonThayDoiQuyDinh_Click(null, null);
                }


            }
        }

       
    }
}
