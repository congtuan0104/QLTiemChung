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
        HoaDon_BUS hoadonBussiness = new HoaDon_BUS();
        public XuatHoaDonUI(int MaHS)
        {
            InitializeComponent();
            HienThiThongTinHoaDon(MaHS);

        }
        private void HienThiThongTinHoaDon(int MaHS)
        {
            // Hiển thị thông tin hóa đơn 
            HoaDon hoadon = hoadonBussiness.LayThongTinHoaDon(MaHS);
            txtTongTien.Text = hoadon.TongTien.ToString();
            txtConLai.Text = hoadon.ConLai.ToString();
            txtSoTienTraMoiDot.Text = hoadon.TienTra_1Dot.ToString();
            
        }

    }
}
