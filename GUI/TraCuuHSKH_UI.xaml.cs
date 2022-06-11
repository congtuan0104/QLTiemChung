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
    /// Interaction logic for TraCuuHSKH_UI.xaml
    /// </summary>
    public partial class TraCuuHSKH_UI : Window
    {
        // Khai báo các nghiệp vụ liên quan đến giao diện tra cứu hồ sơ khách hàng
        HSKH_BUS hskhBussiness = new HSKH_BUS();

        public TraCuuHSKH_UI()
        {
            InitializeComponent();           
            btnXemHS.IsEnabled = false;
            btnXoaKH.IsEnabled = false;         
            HienThiDSKH();
        }

        private void HienThiDSKH()
        {
            // Lấy ds khách hàng đổ vào dgvDSKH
            List<HSKH> dsHSKH = hskhBussiness.LayDSKH();
            dgvDSKH.ItemsSource = dsHSKH;          
            dgvDSKH.Items.Refresh();
        }

        private void btnTaoHSKH_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển sang giao diện tạo hồ sơ khách hàng
            TaoHSKH_UI taoHSKH_UI = new TaoHSKH_UI();
            taoHSKH_UI.ShowDialog();           
        }

        private void btnXemHS_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển sang giao diện xem chi tiết hồ sơ khách hàng 
            HSKH KH_Selected = dgvDSKH.SelectedItem as HSKH;
            ChiTietHSKH_UI chiTietHSKH_UI = new ChiTietHSKH_UI(KH_Selected.MaKH);
            chiTietHSKH_UI.Show();
            this.Close();
        }

        private void btnXoaKH_Click(object sender, RoutedEventArgs e)
        {
            HSKH KH_Selected = dgvDSKH.SelectedItem as HSKH;
            string message = "Bạn có chắc muốn xoá khách hàng " + KH_Selected.TenKH;
            // Thực hiện xoá khách hàng
            if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {      
                hskhBussiness.XoaKH(KH_Selected.MaKH);
                HienThiDSKH();
            }
            return;
            
        }

        private void btnTimKiemKH_Click(object sender, RoutedEventArgs e)
        {
            // Tìm kiếm khách hàng và hiện thông tin
            string Hoten = tbHoTenKH.Text;
            string SDT = tbSDT.Text;
            if(Hoten == "" && SDT == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm");
                return;
            }
            
            // Tra cứu danh sách
            List<HSKH>  dsHSKH = hskhBussiness.TraCuuKH(Hoten, SDT);
            
            if(dsHSKH.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng");             
            }
            dgvDSKH.ItemsSource = dsHSKH;
            dgvDSKH.Items.Refresh();

        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại giao diện menu
            MenuUI menuUI = new MenuUI();
            menuUI.Show();
            this.Close();
        }

        private void dgvDSKH_Selected(object sender, SelectionChangedEventArgs e)
        {
            // Cho phép chọn xem hoặc xoá hồ sơ khi chọn khách hàng và ngược lại
            if(dgvDSKH.SelectedIndex < 0)
            {
                btnXemHS.IsEnabled = false;
                btnXoaKH.IsEnabled = false;
                return;
            }
            btnXemHS.IsEnabled = true;
            btnXoaKH.IsEnabled = true;
            return;
        }
    }
}
