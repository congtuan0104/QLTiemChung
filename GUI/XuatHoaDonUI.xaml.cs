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
    /// Interaction logic for XuatHoaDonUI.xaml
    /// </summary>
    public partial class XuatHoaDonUI : Window
    {
        int maHS;
        HoaDon_BUS hoadonBussiness = new HoaDon_BUS();
        CTHSTC_BUS DSDVBussiness = new CTHSTC_BUS();
        public XuatHoaDonUI(int MaHS)
        {
            InitializeComponent();
            HienThiThongTinHoaDon(MaHS);
            HienThiDS_DVDKCuaKH(MaHS);
            maHS = MaHS;
        }
        private void HienThiThongTinHoaDon(int MaHS)
        {
            // Hiển thị thông tin hóa đơn 
            List<CTHSTC> DSDV = DSDVBussiness.LayDSDV(MaHS);
            decimal tongtien = 0;
            for (int i = 0; i < DSDV.Count(); i++)
            {
                tongtien = tongtien + DSDV[i].GiaDV;
            }
            txtTongTien.Text = tongtien.ToString();
            txtConLai.Text = txtTongTien.Text;
            if (tongtien < 10000000)
            {
                rbTraGop.IsEnabled = false;
            }
            else
            {
                rbTraDu.IsChecked = true;
            }

        }
        private void HienThiDS_DVDKCuaKH(int MaHS)
        {
            List<CTHSTC> DSDV = DSDVBussiness.LayDSDV(MaHS);
            dgvDichVuDangKy.ItemsSource = DSDV;
            dgvDichVuDangKy.Items.Refresh();
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            ChiTietHSTiemChungUI ct = new ChiTietHSTiemChungUI(maHS);
            ct.Show();
            this.Close();
        }

        private void rbTraDu_Checked(object sender, RoutedEventArgs e)
        {
            CbSoDotThanhToan.IsEnabled = false;
            txtSoTienTraMoiDot.Text = txtTongTien.Text;
        }

        private void rbTraGop_Checked(object sender, RoutedEventArgs e)
        {
            CbSoDotThanhToan.IsEnabled = true;
        }

        private void CbSoDotThanhToan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            decimal tongtien = 1;
            if (CbSoDotThanhToan.IsEnabled == true)
            {
                string text = CbSoDotThanhToan.SelectedValue.ToString();
                if (text == "2")
                {
                    tongtien = Decimal.Parse(txtTongTien.Text);
                    txtSoTienTraMoiDot.Text = (Math.Round(tongtien / 2, 4)).ToString();
                }
                if (text == "3")
                {
                    tongtien = Decimal.Parse(txtTongTien.Text);
                    txtSoTienTraMoiDot.Text = (Math.Round(tongtien / 3, 4)).ToString();
                }
                if (text == "4")
                {
                    tongtien = Decimal.Parse(txtTongTien.Text);
                    txtSoTienTraMoiDot.Text = (Math.Round(tongtien / 4, 4)).ToString();
                }
            }
        }  
        private void btnXuatHoaDon_Click(object sender, RoutedEventArgs e)
        {
            HoaDon Hdon = new HoaDon();
            Hdon.TienTra_1Dot = Decimal.Parse(txtSoTienTraMoiDot.Text);
            Hdon.TongTien = Decimal.Parse(txtTongTien.Text);
            Hdon.ConLai = Decimal.Parse(txtTongTien.Text);
            Hdon.MaHS = maHS;
            if (rbTraDu.IsChecked==true)
            {
                Hdon.SoDotThanhToan = 1;
            }
            else
            {
                Hdon.SoDotThanhToan = Int32.Parse(CbSoDotThanhToan.SelectedValue.ToString());
            }
            if (hoadonBussiness.ThemHoaDon(Hdon,maHS))
            {
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
