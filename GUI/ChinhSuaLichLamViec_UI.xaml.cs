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
    /// Interaction logic for ChinhSuaLichLamViec_UI.xaml
    /// </summary>
    public partial class ChinhSuaLichLamViec_UI : Window
    {
        LICHLAMVIEC_BUS lichLamViecBussiness = new LICHLAMVIEC_BUS();
        PHIEUDANGKY_BUS phieuDangKyBussiness = new PHIEUDANGKY_BUS();
        public ChinhSuaLichLamViec_UI()
        {
            InitializeComponent();
            HienThiLichLamViec();
            HienThiPhieuDangKy();
            btn_XoaKhoiLich.IsEnabled = false;
        }

        private void HienThiLichLamViec()
        {
            List<LICHLAMVIEC> lichLamViec = lichLamViecBussiness.layLichLamViec();
            dgvLichLamViec.ItemsSource = lichLamViec;
            dgvLichLamViec.Items.Refresh();
        }

        private void HienThiPhieuDangKy()
        {
            List<PHIEUDANGKY> phieuDangKy = phieuDangKyBussiness.layPhieuDangKy();
            dgvPhieuDangKy.ItemsSource = phieuDangKy;
            dgvPhieuDangKy.Items.Refresh();
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            XemLichLamViecUI xemLich = new XemLichLamViecUI();
            xemLich.Show();
            this.Close();
        }

        private void btn_ThemVaoLich_Click(object sender, RoutedEventArgs e)
        {
            LICHLAMVIEC llv = new LICHLAMVIEC();
            string ca = combobox_ChonCa.Text;
            string manv = textbox_NhanVien.Text.ToString();
            if (manv != "" && datePicker_ChonNgay.SelectedDate != null && ca != "")
            {
                llv.MaNV = int.Parse(textbox_NhanVien.Text.ToString());
                llv.Ngay = datePicker_ChonNgay.SelectedDate.Value;
                llv.Ca = combobox_ChonCa.Text;
                lichLamViecBussiness.ThemLichLamViec(llv);
                MessageBox.Show("Đã thêm THÀNH CÔNG " + llv.Ngay.ToString("yyyy-MM-dd") + " " + llv.Ca.ToString() + " " + llv.MaNV.ToString() + " vào lịch làm việc!");
            }
            else
            {
                MessageBox.Show("Chưa chọn đủ thông tin!");
            }  
        }

        private void btn_XoaKhoiLich_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgvLichLamViec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btn_XoaKhoiLich.IsEnabled = true;
            //LICHLAMVIEC llv = dgvLichLamViec.SelectedItem as LICHLAMVIEC;
            //combobox_ChonCa.ItemsSource = llv.Ca.ToString();
            //textbox_NhanVien.Text = llv.MaNV.ToString();
            
        }
    }
}
