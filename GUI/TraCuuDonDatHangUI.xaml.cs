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
            HienThiDSDH();
            
        }
        private void HienThiDSDH()
        {
            // Lấy ds khách hàng đổ vào dgvDSKH
            List<PhieuDatMua> dsPDM = pdm.LayDSDonDatHang();
            dgvDDH.ItemsSource = dsPDM;
            dgvDDH.Items.Refresh();
            
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (tbMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm");
                return;
            }

            // Tra cứu danh sách
            int makh = Int32.Parse(tbMaKH.Text);
            int tinhtrang = cbbTinhTrang.SelectedIndex - 2;
            List<PhieuDatMua> dsPDM = pdm.TraCuuDDHCuaKH(makh, tinhtrang);

            if (dsPDM.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin");
            }
            dgvDDH.ItemsSource = dsPDM;
            dgvDDH.Items.Refresh();

        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            PhieuDatMua PDM_Selected = dgvDDH.SelectedItem as PhieuDatMua;
            ChiTietDonDatHangUI chiTietDDH_UI = new ChiTietDonDatHangUI(PDM_Selected.MaKH, PDM_Selected.MaPhieu);
            chiTietDDH_UI.Show();
            this.Close();
        }

        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            // Đặt mua vaccine
            DatMuaVaccineUI muaVaccineUI = new DatMuaVaccineUI();
            muaVaccineUI.ShowDialog();
            HienThiDSDH();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            // Xoá đơn đặt hàng
            PhieuDatMua pdm_Selected = dgvDDH.SelectedItem as PhieuDatMua;
            string message = "Bạn có chắc muốn xoá đơn đặt hàng " + pdm_Selected.MaPhieu;

            if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                pdm.XoaDonDatHang(pdm_Selected.MaPhieu);
                HienThiDSDH();
            }
            return;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            MenuUI menuUI = new MenuUI();
            menuUI.Show();
            this.Close();
        }


        private void dgvDDH_Selected(object sender, SelectionChangedEventArgs e)
        {
            // Cho phép chọn xem hoặc huỷ khi chọn đơn đặt hàng và ngược lại
            if (dgvDDH.SelectedIndex < 0)
            {
                btnChiTiet.IsEnabled = false;
                btnHuy.IsEnabled = false;
                return;
            }
            btnChiTiet.IsEnabled = true;
            btnHuy.IsEnabled = true;
            return;
        }
        

        private void cbbTinhTrang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if(cbbTinhTrang.SelectedIndex==1)
            {
                List<PhieuDatMua> dsPDM = pdm.LayDSDonDatHangTheoTinhTrang(-1);
                dgvDDH.ItemsSource = dsPDM;
                dgvDDH.Items.Refresh();


            } 
            else if (cbbTinhTrang.SelectedIndex == 2)
            {
                List<PhieuDatMua> dsPDM = pdm.LayDSDonDatHangTheoTinhTrang(0);
                dgvDDH.ItemsSource = dsPDM;
                dgvDDH.Items.Refresh();


            }
            else if(cbbTinhTrang.SelectedIndex==3)
            {

                List<PhieuDatMua> dsPDM = pdm.LayDSDonDatHangTheoTinhTrang(1);
                dgvDDH.ItemsSource = dsPDM;
                dgvDDH.Items.Refresh();
            }
            else
            {
                HienThiDSDH();
            } 
                
        }
    }
}
