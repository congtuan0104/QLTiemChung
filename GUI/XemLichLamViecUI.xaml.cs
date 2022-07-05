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
    /// Interaction logic for XemLichLamViecUI.xaml
    /// </summary>
    public partial class XemLichLamViecUI : Window
    {

        //
        LICHLAMVIEC_BUS lichLamViecBussiness = new LICHLAMVIEC_BUS();
        public XemLichLamViecUI()
        {
            InitializeComponent();
            if(TaiKhoan.Role =="Khách hàng")
            {
                this.Close();
            }
            if(TaiKhoan.Role == "Bộ phận điều hành")
            {
                btnChinhSua.IsEnabled = true;
            }
            else
            {
                btnChinhSua.IsEnabled = false;
            }
            
            HienThiLichLamViec();
        }


        private void HienThiLichLamViec()
        {
            List<LICHLAMVIEC> lichLamViec = lichLamViecBussiness.layLichLamViec();
            dgvLichLamViec.ItemsSource = lichLamViec;
            dgvLichLamViec.Items.Refresh();
        }
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            MenuUI menuUI = new MenuUI();
            menuUI.Show();
            this.Close();
        }

        private void btnXem_Lich_Click(object sender, RoutedEventArgs e)
        {
            string Ca , MaNV,
                    ngayBatDau , ngayKetThuc ;
                    //ngayBatDau = dataPicker_ngayBatDau.SelectedDate.Value.ToString("yyyy-MM-dd"),
                    //ngayKetThuc = dataPicker_ngayKetThuc.SelectedDate.Value.ToString("yyyy-MM-dd");
            if(dataPicker_ngayBatDau.SelectedDate == null) { 
                ngayBatDau = "2000-01-01"; 
            } else { 
                ngayBatDau = dataPicker_ngayBatDau.SelectedDate.Value.ToString("yyyy-MM-dd"); 
            };
            if (dataPicker_ngayKetThuc.SelectedDate == null)
            {
                ngayKetThuc = "3000-01-01";
            }
            else {
                ngayKetThuc = dataPicker_ngayKetThuc.SelectedDate.Value.ToString("yyyy-MM-dd");
            };
            if (textBox_MaNV == null)
            {
                MaNV = "";
            }
            else
            {
                MaNV = textBox_MaNV.Text;
            };
            if (comboBox_caLamViec == null)
            {
                Ca = "";
            }
            else
            {
                Ca = comboBox_caLamViec.Text;
            }

            string dieukien = "";


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
            //this.Close();
            List<LICHLAMVIEC> lichLamViec = lichLamViecBussiness.layLichLamViec_1NhanVien(dieukien);
            dgvLichLamViec.ItemsSource = null;
            dgvLichLamViec.ItemsSource = lichLamViec;
            //dgvLichLamViec.Items.Refresh();
        }


        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            ChinhSuaLichLamViec_UI chinhSuaLichUI = new ChinhSuaLichLamViec_UI();
            chinhSuaLichUI.Show();
            this.Close();
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            DangKyLichLamViec_UI dangKyLichLamViecUI = new DangKyLichLamViec_UI();
            dangKyLichLamViecUI.Show();
            this.Close();
        }
    }
}
