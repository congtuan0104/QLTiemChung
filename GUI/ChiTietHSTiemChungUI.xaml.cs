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
    /// Interaction logic for ChiTietHSTiemChungUI.xaml
    /// </summary>
    public partial class ChiTietHSTiemChungUI : Window
    {
        HoaDon_BUS HoaDonHSTC = new HoaDon_BUS();
        HSTiemChung_BUS hstcBussiness = new HSTiemChung_BUS();
        CTHSTC_BUS DSDVBussiness = new CTHSTC_BUS();
        public ChiTietHSTiemChungUI(int MaHS)
        {
            InitializeComponent();
            if (KiemTraHDTonTai(MaHS))
            {
                btnXuatHoaDon.IsEnabled = false;
            }
            else
            {
                btnXemHoaDon.IsEnabled = false;
            }

            HienThiThongTinTC(MaHS);
            HienThiDS_DVDKCuaKH(MaHS);
        }

        private void HienThiDS_DVDKCuaKH(int MaHS)
        {
            List<CTHSTC> DSDV = DSDVBussiness.LayDSDV(MaHS);
            dgvDichVuDangKy.ItemsSource = DSDV;
            dgvDichVuDangKy.Items.Refresh();
        }

        private void HienThiThongTinTC(int maHS)
        {
            //Hiển thị thông tin tiêm chủng của khách hàng
            HSTiemChung hstc = hstcBussiness.LayThongTinTC(maHS);
            dpNgayLap.SelectedDate = hstc.NgayLapHS;
            dpNgayHen.SelectedDate = hstc.NgayHenTiem;
            tbKhamSangLoc.Text = hstc.KQ_KhamSangLoc;
            tbKhamSauTiem.Text = hstc.KQ_KhamSauTiem;
        }

        private bool KiemTraHDTonTai(int MaHS)
        {
            return HoaDonHSTC.KiemTraHD(MaHS);
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnXuatHoaDon_Click(object sender, RoutedEventArgs e)
        {
            XuatHoaDonUI xuathoadon = new XuatHoaDonUI(Int32.Parse(txtMaHS.Text));
            xuathoadon.ShowDialog();
        }

        private void btnXemHoaDon_Click(object sender, RoutedEventArgs e)
        {
            XemHoaDonUI xemhoadon = new XemHoaDonUI(Int32.Parse(txtMaHS.Text));
            xemhoadon.ShowDialog();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
