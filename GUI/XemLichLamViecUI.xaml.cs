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
            //btnDong.IsEnabled = false;
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
            string ngayBatDau = dataPicker_ngayBatDau.SelectedDate.Value.ToString("yyyy-MM-dd"),
            ngayKetThuc = dataPicker_ngayKetThuc.SelectedDate.Value.ToString("yyyy-MM-dd"),
                Ca = comboBox_caLamViec.Text, MaNV = textBox_MaNV.Text;

            string dieukien = "where Ngay between '" + ngayBatDau + "' and '" + ngayKetThuc +
                              "' and MaNV = " + MaNV +
                              " and Ca = N'" + Ca + "'";




            //if (ngayBatDau != "" || ngayKetThuc != "" || Ca != "" || MaNV != "")
            //{
            //    //dieukien = "where " + "Ngay between '" + ngayBatDau + "' and '" + ngayKetThuc +
            //    //"' and MaNV = " + MaNV +
            //    //" and Ca = N'" + Ca + "';";
            //    dieukien = "where ";
            //    if (ngayBatDau != "" || ngayKetThuc != "")
            //    {
            //        if (ngayBatDau != "" && ngayKetThuc != "")
            //        {
            //            dieukien = dieukien + "Ngay between '" + ngayBatDau + "' and '" + ngayKetThuc + "' ";
            //        }
            //        else if (ngayBatDau == "")
            //        {
            //            dieukien = dieukien + "Ngay < '" + ngayKetThuc + "' ";
            //        }
            //        else if (ngayKetThuc == "")
            //        {
            //            dieukien = dieukien + "Ngay > '" + ngayBatDau + "' ";
            //        };

            //    } 
            //    if (Ca != "")
            //    {
            //        dieukien = dieukien + "Ca = N'" + Ca + "' ";
            //        if (MaNV != "")
            //        {
            //            dieukien = dieukien + "and MaNV = " + MaNV;
            //        };
            //    }else if (MaNV != "")
            //    {
            //        dieukien = dieukien + "MaNV = " + MaNV;   
            //    }


            //}
            MessageBox.Show(dieukien);
            this.Close();
            //List < LICHLAMVIEC> lichLamViec = lichLamViecBussiness.layLichLamViec_1NhanVien(dieukien);
            //dgvLichLamViec.ItemsSource = lichLamViec;
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
            this.Close();
        }
    }
}
