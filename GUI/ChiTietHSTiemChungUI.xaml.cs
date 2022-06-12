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

            txtMaHS.Text = MaHS.ToString();
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
