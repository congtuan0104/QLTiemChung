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
    /// Interaction logic for TaoHSKH_UI.xaml
    /// </summary>
    public partial class TaoHSKH_UI : Window
    {
        public TaoHSKH_UI()
        {
            InitializeComponent();
        }

        private void checkTreEm_Checked(object sender, RoutedEventArgs e)
        {
            // Nếu checkbox 'Người tiêm là trẻ em' được check
            // thì cho phép nhập thông tin người giám hộ
            tbNguoiGiamHo.IsEnabled = true;
            tbQuanHe.IsEnabled = true;
            txtNguoiGiamHo.Foreground = Brushes.Black;
            txtQuanHe.Foreground = Brushes.Black;
        }

        private void checkTreEm_Unchecked(object sender, RoutedEventArgs e)
        {
            tbNguoiGiamHo.IsEnabled = false;
            tbQuanHe.IsEnabled = false;
            txtNguoiGiamHo.Foreground = Brushes.Gray;
            txtQuanHe.Foreground = Brushes.Gray;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            // Lưu hồ sơ khách hàng
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            // Huỷ thao tác tạo hồ sơ khách hàng
            // -> Quay lại giao diện tra cứu HSKH
            this.Close();
        }

        
    }
}
