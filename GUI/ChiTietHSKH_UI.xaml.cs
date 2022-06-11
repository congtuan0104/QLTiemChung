using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using BUS;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ChiTietHSKH_UI.xaml
    /// </summary>
    public partial class ChiTietHSKH_UI : Window
    {
        // Khai báo các nghiệp vụ liên quan đến giao diện tra cứu hồ sơ khách hàng
        HSKH_BUS hskhBussiness = new HSKH_BUS();
        GiamHo_BUS giamHoBussuness = new GiamHo_BUS();
        HSTiemChung_BUS hstcBussiness = new HSTiemChung_BUS();

        public ChiTietHSKH_UI(int MaKH)
        {
            InitializeComponent();
            HienThiThongTinKH(MaKH);
            HienThiThongTinNGH(MaKH);
            HienThiDS_HSTCCuaKH(MaKH);
        }

        private void HienThiThongTinKH(int MaKH)
        {
            // Hiển thị thông tin khách hàng (người được tiêm)
            HSKH kh = hskhBussiness.LayThongTinKH(MaKH);
            txtHoTen.Text = kh.TenKH;
            txtDiaChi.Text = kh.DiaChi;
            txtNgaySinh.Text = kh.NgaySinh.ToShortDateString();
            txtSDT.Text = kh.SDT;
            txtGioiTinh.Text = kh.GioiTinh;
        }

        private void HienThiThongTinNGH(int MaKH)
        {
            // Hiển thị thông tin người giám hộ (nếu có)
            GiamHo giamHo = giamHoBussuness.LayThongTinNGHCuaKH(MaKH);     
            txtGiamHo.Text = giamHo.TenNGH != null ? giamHo.TenNGH : "Không có thông tin";
            txtQuanHe.Text = giamHo.QuanHe != null ? giamHo.QuanHe : "Không có thông tin";
            return;

        }

        private void HienThiDS_HSTCCuaKH(int MaKH)
        {
            // Hiển thị lịch ĐK tiêm (ds hồ sơ tiêm chủng) của khách hàng
            List<HSTiemChung> DS_HSTC = hstcBussiness.LayDSHS(MaKH);
            dgvDS_HSTC.ItemsSource = DS_HSTC;
            dgvDS_HSTC.Items.Refresh();
        }

        private void btnDangKyTiem_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị giao diện đăng ký tiêm chủng
            DangKyTiemChungUI dangKyTiemChungUI = new DangKyTiemChungUI();
            dangKyTiemChungUI.ShowDialog();
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị giao diện xem chi tiết hồ sơ tiêm chủng 
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            // Thực hiện chức năng xoá hồ sơ tiêm chủng
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại giao diện tra cứu hồ sơ khách hàng
            TraCuuHSKH_UI traCuuHSKH_UI = new TraCuuHSKH_UI();
            traCuuHSKH_UI.Show();
            this.Close();
        }

        private void dgvDS_HSTC_Selected(object sender, SelectionChangedEventArgs e)
        {
            // Cho phép chọn xem hoặc xoá hồ sơ khi chọn khách hàng và ngược lại
            if (dgvDS_HSTC.SelectedIndex < 0)
            {
                btnChiTiet.IsEnabled = false;
                btnXoa.IsEnabled = false;
                return;
            }
            btnChiTiet.IsEnabled = true;
            btnXoa.IsEnabled = true;
            return;
        }
    }
}
