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
    /// Interaction logic for ChiTietDonDatHangUI.xaml
    /// </summary>
    public partial class ChiTietDonDatHangUI : Window
    {
        CTPhieuDatMua_BUS ctpdm = new CTPhieuDatMua_BUS();
        PhieuDatMua_BUS pdmBus = new PhieuDatMua_BUS();
        HSKH_BUS hskhBussiness = new HSKH_BUS();

        public ChiTietDonDatHangUI(int MaKH, int MaPhieu)
        {
            InitializeComponent();
            HienThiThongTinKH(MaKH);
            HienThiThongTinPhieu(MaPhieu);
            HienThiChiTietPhieu(MaPhieu);
        }

        private void HienThiThongTinKH(int MaKH)
        {
            HSKH kh = hskhBussiness.LayThongTinKH(MaKH);
            txtMaKH.Text = MaKH.ToString();
            txtHoten.Text = kh.TenKH;
            txtNgSinh.Text = kh.NgaySinh.ToShortDateString();
            txtSDT.Text = kh.SDT;
        }

        private void HienThiThongTinPhieu(int maPhieu)
        {
            PhieuDatMua pdm = pdmBus.XemPhieuDatMua(maPhieu);
            txtMaPhieu.Text = pdm.MaPhieu.ToString();
            txtNgayDat.Text = pdm.NgayDat.ToShortDateString();
            // -1 : ko duyệt
            // 0: chưa xét 
            // 1: đã duyệt 
            if (pdm.TinhTrang == 0)
                return;
            if (pdm.TinhTrang == -1)
            {
                rbKoDuyet.IsChecked = true;
                btnXacNhan.IsEnabled = false;
                return;
            }
            if (pdm.TinhTrang == 1)
            {
                rbDuyet.IsChecked = true;
                btnXacNhan.IsEnabled = false;
                return;
            }
        }

        private void HienThiChiTietPhieu(int MaPhieu)
        {
            List<CTPhieuDatMua> CT = ctpdm.XEMCHITIETPHIEU(MaPhieu);
            decimal TongTien = 0;
            for (int i = 0; i < CT.Count; i++)
                TongTien = CT[i].ThanhTien + TongTien;
            DSVacXin.ItemsSource = CT;
            DSVacXin.Items.Refresh();
            txtTongTien.Text = TongTien.ToString();
        }


        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            // -1 : ko duyệt
            // 0: chưa xét 
            // 1: đã duyệt 
            if (rbDuyet.IsChecked == false && rbKoDuyet.IsChecked == false)
            {
                MessageBox.Show("Vui lòng lựa chọn duyệt phiếu trước khi xác nhận");
                return;
            }
            int maPhieu = Int32.Parse(txtMaPhieu.Text);
            int tinhTrang = rbDuyet.IsChecked == true ? 1 : -1;
            if(pdmBus.CapNhatTinhTrangPhieu(maPhieu, tinhTrang))
            {
                MessageBox.Show("Cập nhật thành công");
                btnXacNhan.IsEnabled = false;
                if (tinhTrang == 1)
                {
                    // Tạo đơn đặt hàng
                }
            }
            
            return;
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
