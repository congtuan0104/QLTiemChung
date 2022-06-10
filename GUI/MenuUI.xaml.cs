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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MenuUI.xaml
    /// </summary>
    public partial class MenuUI : Window
    {
        public MenuUI()
        {
            InitializeComponent();
        }

        private void btnHSKH_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển sang giao diện tra cứu hồ sơ
            TraCuuHSKH_UI hSKH_UI = new TraCuuHSKH_UI();
            hSKH_UI.Show();
            this.Close();
        }

        private void btnMuaVaccine_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển sang giao diện đặt mua vaccine
            TraCuuDonDatHangUI ddh = new TraCuuDonDatHangUI();
            ddh.Show();
            this.Close();
        }

        private void btnLichLV_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển sang giao diện xem lịch làm việc
            XemLichLamViecUI xemLichLamViecUI = new XemLichLamViecUI();
            xemLichLamViecUI.Show();
            this.Close();
        }

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            // Đăng xuất khỏi tài khoản hiện đang đăng nhập
            LoginUI loginUI = new LoginUI();
            loginUI.Show();
            this.Close();
        }
    }
}
