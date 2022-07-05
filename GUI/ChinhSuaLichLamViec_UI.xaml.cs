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
                
                if(lichLamViecBussiness.KiemTraTonTai(llv).Count()<1)
                {
                    if(datePicker_ChonNgay.SelectedDate < DateTime.Now)
                    {
                        MessageBox.Show("NGÀY ĐƯỢC CHỌN PHẢI LỚN HƠN NGÀY HIỆN TẠI!");
                    }
                    else
                    {
                        lichLamViecBussiness.ThemLichLamViec(llv);
                        MessageBox.Show("Đã thêm THÀNH CÔNG " + llv.Ngay.ToString("yyyy-MM-dd") + " " + llv.Ca.ToString() + " " + llv.MaNV.ToString() + " vào lịch làm việc!");
                        HienThiLichLamViec();
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

        private void btn_XoaKhoiLich_Click(object sender, RoutedEventArgs e)
        {
            LICHLAMVIEC llv = dgvLichLamViec.SelectedItem as LICHLAMVIEC;
            
            
            string message = "Bạn có chắc muốn xoá dòng này? ";
            if(lichLamViecBussiness.KiemTraTonTai(llv).Count < 1)
            {
                MessageBox.Show("KHÔNG TỒN TẠI DÒNG NÀY!");
            }
            else
            {
                if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    lichLamViecBussiness.XoaLichLamViec(llv);
                    HienThiLichLamViec();
                    
                }
                btn_XoaKhoiLich.IsEnabled = false;
            }
            
            return;
        }

        private void dgvLichLamViec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_XoaKhoiLich.IsEnabled = true;
            //LICHLAMVIEC llv = dgvLichLamViec.SelectedItem as LICHLAMVIEC;
            //combobox_ChonCa.Text = llv.Ca;
            //textbox_NhanVien.Text = llv.MaNV.ToString();
            //datePicker_ChonNgay.SelectedDate = llv.Ngay;
            return;
        }

        private void btn_DoiChieu_Click(object sender, RoutedEventArgs e)
        {
            string Ca, MaNV,
                   ngayBatDau, ngayKetThuc;
            //ngayBatDau = dataPicker_ngayBatDau.SelectedDate.Value.ToString("yyyy-MM-dd"),
            //ngayKetThuc = dataPicker_ngayKetThuc.SelectedDate.Value.ToString("yyyy-MM-dd");

            if (datePicker_ChonNgay.SelectedDate == null)
            {
                ngayBatDau = "2000-01-01"; ngayKetThuc = "3000-01-01";
            }
            else
            {
                ngayBatDau = datePicker_ChonNgay.SelectedDate.Value.ToString("yyyy-MM-dd");
                ngayKetThuc = datePicker_ChonNgay.SelectedDate.Value.ToString("yyyy-MM-dd");
            };
           

            if (textbox_NhanVien == null)
            {
                MaNV = "";
            }
            else
            {
                MaNV = textbox_NhanVien.Text;
            };
            if (combobox_ChonCa == null)
            {
                Ca = "";
            }
            else
            {
                Ca = combobox_ChonCa.Text;
            }

            string dieukien ;


            dieukien = "where Ngay >= '" + ngayBatDau + "' and Ngay <='" + ngayKetThuc + "' ";

            if (Ca != "")
            {
                dieukien = dieukien + "and Ca = N'" + Ca + "' ";

            };
            if (MaNV != "")
            {
                dieukien = dieukien + "and MaNV = " + MaNV;
            };


            //MessageBox.Show(dieukien);

            List<LICHLAMVIEC> lichLamViec = lichLamViecBussiness.layLichLamViec_1NhanVien(dieukien);
            dgvLichLamViec.ItemsSource = lichLamViec;
            dgvLichLamViec.Items.Refresh();

            List<PHIEUDANGKY> phieuDangKy = phieuDangKyBussiness.layPhieuDangKy_1NhanVien(dieukien);
            dgvPhieuDangKy.ItemsSource = phieuDangKy;
            dgvPhieuDangKy.Items.Refresh();
        }

        private void btn_XoaPhieuDangKy_Click(object sender, RoutedEventArgs e)
        {


            string message = "Bạn có chắc muốn xoá tất cả phiếu đăng ký này? ";

            if (MessageBox.Show(message, "Cảnh báo", MessageBoxButton.YesNo,
            MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                phieuDangKyBussiness.XoaTatCaPhieuDangKy();
                HienThiLichLamViec();
            }



        }
    }
}
