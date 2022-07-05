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
    /// Interaction logic for DangKyLichLamViec_UI.xaml
    /// </summary>
    public partial class DangKyLichLamViec_UI : Window
    {
        PHIEUDANGKY_BUS phieuDangKyBussiness = new PHIEUDANGKY_BUS();
        
        public DangKyLichLamViec_UI()
        {
            InitializeComponent();
            
            btnXoa.IsEnabled = false;
            textBox_MaNV.Text = TaiKhoan.UserID.ToString();
            HienThiPhieuDangKy();
            textBox_MaNV.IsEnabled = false;
            
        }

        private void HienThiPhieuDangKy()
        {
            //List<PHIEUDANGKY> phieuDangKy = phieuDangKyBussiness.layPhieuDangKy();
            string dieukien1 = "where MaNV = " + textBox_MaNV.Text;
            List<PHIEUDANGKY> phieuDangKy = phieuDangKyBussiness.layPhieuDangKy_1NhanVien(dieukien1);
            dgvPhieuDangKy.ItemsSource = phieuDangKy;
            dgvPhieuDangKy.Items.Refresh();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            XemLichLamViecUI xemLichLamViecUI = new XemLichLamViecUI();
            xemLichLamViecUI.Show();
            this.Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            PHIEUDANGKY pdk = new PHIEUDANGKY();
            string ca = comboBox_Ca.Text;
            string manv = textBox_MaNV.Text.ToString();
            if (manv != "" && datePicker_Ngay.SelectedDate != null && ca != "")
            {
                pdk.MaNV = int.Parse(textBox_MaNV.Text.ToString());
                pdk.Ngay = datePicker_Ngay.SelectedDate.Value;
                pdk.Ca = comboBox_Ca.Text;

                if (phieuDangKyBussiness.KiemTraTonTai(pdk).Count() < 1)
                {
                    if(datePicker_Ngay.SelectedDate < DateTime.Today)
                    {
                        MessageBox.Show("NGÀY ĐƯỢC CHỌN PHẢI LỚN HƠN NGÀY HIỆN TẠI!");
                    }
                    else
                    {
                        phieuDangKyBussiness.ThemPhieuDangKy(pdk);
                        MessageBox.Show("Đã thêm THÀNH CÔNG " + pdk.Ngay.ToString("yyyy-MM-dd") + " " + pdk.Ca.ToString() + " " + pdk.MaNV.ToString() + " vào phiếu đăng ký!");
                        HienThiPhieuDangKy();
                    }
                    
                }
                else
                {
                    MessageBox.Show("ĐÃ TỒN TẠI DÒNG NÀY!");
                }

            }
            else
            {
                MessageBox.Show("Chưa chọn đủ thông tin!");
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            PHIEUDANGKY pdk = dgvPhieuDangKy.SelectedItem as PHIEUDANGKY;


            string message = "Bạn có chắc muốn xoá dòng này? ";
            if (phieuDangKyBussiness.KiemTraTonTai(pdk).Count < 1)
            {
                MessageBox.Show("KHÔNG TỒN TẠI DÒNG NÀY!");
            }
            else
            {
                if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    phieuDangKyBussiness.XoaPhieuDangKy(pdk);
                    HienThiPhieuDangKy();
                    
                }
                btnXoa.IsEnabled = false;
            }

            return;
        }

        private void dgvPhieuDangKy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnXoa.IsEnabled = true;
            return;
        }

        private void btnHuyTatCa_Click(object sender, RoutedEventArgs e)
        {
            string message = "Bạn có chắc muốn xoá tất cả phiếu đăng ký này? ";
            
            if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.YesNo,
            MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (phieuDangKyBussiness.XoaPhieuDangKy_1NV(TaiKhoan.UserID.ToString()))
                {
                    MessageBox.Show("XÓA THÀNH CÔNG!");
                }
                else
                {
                    MessageBox.Show("KHÔNG TỒN TẠI PHIẾU ĐĂNG KÝ PHÙ HỢP ĐỂ XÓA!");
                }

                HienThiPhieuDangKy();
            }
            return;
        }
    }
}
