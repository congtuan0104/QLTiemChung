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
    /// Interaction logic for XemHoaDonUI.xaml
    /// </summary>
    public partial class XemHoaDonUI : Window
    {
        HoaDon_BUS hoadonBussiness = new HoaDon_BUS();
        CTHSTC_BUS DSDVBussiness = new CTHSTC_BUS();
        public XemHoaDonUI(int MaHS)
        {
            InitializeComponent();
            HienThiThongTinHoaDon(MaHS);
            HienThiDS_DVDKCuaKH(MaHS);
        }
        private void HienThiDS_DVDKCuaKH(int MaHS)
        {
            List<CTHSTC> DSDV = DSDVBussiness.LayDSDV(MaHS);
            dgvDichVuDangKy.ItemsSource = DSDV;
            dgvDichVuDangKy.Items.Refresh();
        }
        private void HienThiThongTinHoaDon(int MaHS)
        {
            // Hiển thị thông tin hóa đơn 
            
            
            HoaDon hoadon = hoadonBussiness.LayThongTinHoaDon(MaHS);
            txtMaHoaDon.Text = hoadon.MaHD.ToString();
            txtTongTien.Text = hoadon.TongTien.ToString();
            txtConLai.Text = hoadon.ConLai.ToString();
            txtSoDotThanhToan.Text = hoadon.SoDotThanhToan.ToString();
            txtSoTienTraMoiDot.Text = hoadon.TienTra_1Dot.ToString();
            if (Decimal.Parse(txtConLai.Text) == 0)
            {
                btnThanhToan.IsEnabled = false;
            }
            if (hoadon.SoDotThanhToan>1)
            {
                txtHinhThucThanhToan.Text = "Trả góp";
            }    
            else
            {
                txtHinhThucThanhToan.Text = "Thanh toán hết";
            }
           

        }
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            int MaHD=Int32.Parse(txtMaHoaDon.Text);
            decimal ChuaThanhToan= Decimal.Parse(txtConLai.Text);
            decimal TienTra1Dot =Decimal.Parse(txtSoTienTraMoiDot.Text);
            decimal temp;
            if (hoadonBussiness.CapNhatHoaDon(MaHD))
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButton.OK);
                temp = ChuaThanhToan - TienTra1Dot;
                txtConLai.Text = temp.ToString();
                if (temp < 1)
                {
                    txtConLai.Text = "0.0000";
                }
                if (Decimal.Parse(txtConLai.Text) == 0)
                {
                    btnThanhToan.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại", "Thông báo", MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
