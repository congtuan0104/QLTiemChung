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
    /// Interaction logic for TraCuuDonDatHangUI.xaml
    /// </summary>
    public partial class TraCuuDonDatHangUI : Window
    {
        PhieuDatMua_BUS pdm = new PhieuDatMua_BUS();
        
        public TraCuuDonDatHangUI()
        {
            InitializeComponent();
            
            HienThiDSKH();
        }
        private void HienThiDSKH()
        {
            // Lấy ds khách hàng đổ vào dgvDSKH
            List<PhieuDatMua> dsHSKH = pdm.XEMDONDATHANG();
            dgvDDH.ItemsSource = dsHSKH;
           dgvDDH.Items.Refresh();
        }

        private void Button_ClickTKDDH(object sender, RoutedEventArgs e)
        {
            string MaKhachhang = txbMaKH.Text;
           
            if (MaKhachhang == "" )
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm");
                return;
            }

            // Tra cứu danh sách
            List<PhieuDatMua> dsHSKH = pdm.TraCuuKH(MaKhachhang);

            if (dsHSKH.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng");
            }
            dgvDDH.ItemsSource = dsHSKH;
            dgvDDH.Items.Refresh();

        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            MenuUI menuUI = new MenuUI();
            menuUI.Show();
            this.Close();
        }
       
        private void btnXemChiTietDon_Click(object sender, RoutedEventArgs e)
        { int Maphieu;
            PhieuDatMua PDM_Selected = dgvDDH.SelectedItem as PhieuDatMua;
            Maphieu = PDM_Selected.MaPhieu;
            ChiTietDonDatHangUI chiTietDDH_UI = new ChiTietDonDatHangUI(PDM_Selected.MaKH,PDM_Selected.MaPhieu);
            
           chiTietDDH_UI.Show();
            this.Close();

        }
        private void dgvDDH_Selected(object sender, SelectionChangedEventArgs e)
        {
            // Cho phép chọn xem hoặc huỷ khi chọn đơn đặt hàng và ngược lại
            if (dgvDDH.SelectedIndex < 0)
            {
                btnXemChiTietDon.IsEnabled = false;
                btnHuy.IsEnabled = false;
                return;
            }
            btnXemChiTietDon.IsEnabled = true;
            btnHuy.IsEnabled = true;
            return;
        }
    }
}
