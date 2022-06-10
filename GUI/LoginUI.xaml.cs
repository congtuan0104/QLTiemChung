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

namespace GUI
{
    /// <summary>
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Window
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void btnLoggin_Click(object sender, RoutedEventArgs e)
        {
            // Đăng nhập
            if(tbUsername.Text == "" && tbPass.Password == "")
            {
                MenuUI menuUI = new MenuUI();                
                menuUI.Show();
                this.Close();
                return;
            }
            MessageBox.Show("Đăng nhập thất bại");
            return;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Thoát ứng dụng
            Close();
        }
    }
}

