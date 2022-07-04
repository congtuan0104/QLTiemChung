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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS;
using DTO;
namespace GUI
{
    /// <summary>
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Window
    {
        LoginBUS lg = new LoginBUS();
        public LoginUI()
        {
            InitializeComponent();
        }

        private void btnLoggin_Click(object sender, RoutedEventArgs e)
        {
            // Đăng nhập
            
            if(tbUsername.Text == "" && tbPass.Password == "")
            {
                MessageBox.Show("Đăng nhập thất bại");
                return;
                
            }

            lg.DangNhap(tbUsername.Text, tbPass.Password);

            if(TaiKhoan.Username == null)
            {
                MessageBox.Show("Đăng nhập thất bại");
                return;
            }
            
            if(TaiKhoan.Role == "Khách hàng")
            {
                MessageBox.Show("Chức năng đang bảo trì");
                return;
            }

            MenuUI menuUI = new MenuUI();
            menuUI.Show();
            this.Close();
            return;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Thoát ứng dụng
            Close();
        }
    }
}

