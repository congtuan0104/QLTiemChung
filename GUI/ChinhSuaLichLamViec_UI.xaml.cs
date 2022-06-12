﻿using System;
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
        public ChinhSuaLichLamViec_UI()
        {
            InitializeComponent();
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
            XemLichLamViecUI xemLich = new XemLichLamViecUI();
            xemLich.Show();
            this.Close();
        }
    }
}
