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
        public XemHoaDonUI(int MaHS)
        {
            InitializeComponent();
            HienThiThongTinHoaDon(MaHS);
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
            if(hoadon.SoDotThanhToan>1)
            {
                txtHinhThucThanhToan.Text = "Trả góp";
            }    
            else
            {
                txtHinhThucThanhToan.Text = "Thanh toán hết";
                btnThanhToan.IsEnabled=false;
            }
            
        }
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            int MaHD=Int32.Parse(txtMaHoaDon.Text);
            decimal ChuaThanhToan= Decimal.Parse(txtConLai.Text);
            decimal TienTra1Dot =Decimal.Parse(txtSoTienTraMoiDot.Text);
            if (hoadonBussiness.CapNhatHoaDon(MaHD))
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButton.OK);
                txtConLai.Text = (ChuaThanhToan - TienTra1Dot).ToString();
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
