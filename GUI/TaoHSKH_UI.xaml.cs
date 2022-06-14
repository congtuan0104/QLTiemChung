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
    /// Interaction logic for TaoHSKH_UI.xaml
    /// </summary>
    public partial class TaoHSKH_UI : Window
    {
        // Khai báo các nghiệp vụ liên quan đến giao diện tra cứu hồ sơ khách hàng
        HSKH_BUS hskhBussiness = new HSKH_BUS();
        GiamHo_BUS ghBussiness = new GiamHo_BUS();
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
            // Kiểm tra thông tin nhập
            if (!KiemTraThongTinNhap())
            {
                return;
            }

            HSKH KH = new HSKH();
            KH.TenKH = tbHoTen.Text;
            KH.SDT = tbSDT.Text;
            KH.DiaChi = tbDiaChi.Text;
            KH.NgaySinh = dpNgaySinh.SelectedDate.Value;
            KH.GioiTinh = rbNam.IsChecked == true ? "Nam" : "Nữ";

            // Kiểm tra khách hàng tồn tại
            if (hskhBussiness.KiemTraKHTonTai("", KH.SDT))
            {
                MessageBox.Show("Khách hàng đã tồn tại");
                return;
            }

            // Thêm thông tin người tiêm 
            if (!hskhBussiness.ThemKH(KH))
            {
                MessageBox.Show("Tạo hồ sơ thất bại");
                this.Close();
                return;
            }

            // Lưu thông tin người giám hộ (nếu có)
            if (checkTreEm.IsChecked == true)
            {
                GiamHo GH = new GiamHo();
                GH.MaKH = hskhBussiness.TraCuuKH(KH.TenKH, KH.SDT)[0].MaKH;
                GH.TenNGH = tbNguoiGiamHo.Text;
                GH.QuanHe = tbQuanHe.Text;

                if (!ghBussiness.ThemNGH(GH))
                {
                    MessageBox.Show("Thêm thông tin người giám hộ không thành công");
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Tạo hồ sơ thành công");
            this.Close();
            return;

        }

        private bool KiemTraThongTinNhap()
        {
            // Kiếm tra xem thông tin đã được nhập đầy đủ chưa
            if (tbHoTen.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                tbHoTen.Focus();
                return false;
            }

            if (tbSDT.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                tbSDT.Focus();
                return false;
            }

            if (tbDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                tbSDT.Focus();
                return false;
            }

            if (dpNgaySinh.SelectedDate == null)
            {
                MessageBox.Show("Bạn chưa chọn ngày sinh", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                dpNgaySinh.Focus();
                return false;
            }

            if (checkTreEm.IsChecked == true)
            {
                if (tbNguoiGiamHo.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên người giám hộ", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    tbNguoiGiamHo.Focus();
                    return false;
                }

                if (tbQuanHe.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mối quan hệ", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    tbQuanHe.Focus();
                    return false;
                }
            }

            // Kiểm tra xem số điện thoại có hợp lệ không
            if(tbSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                tbSDT.Focus();
                return false;
            }

            return true;
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            // Huỷ thao tác tạo hồ sơ khách hàng
            // -> Quay lại giao diện tra cứu HSKH
            this.Close();
        }

        
    }
}
