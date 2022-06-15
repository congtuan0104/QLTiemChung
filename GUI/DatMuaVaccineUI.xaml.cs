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
    /// Interaction logic for DatMuaVaccineUI.xaml
    /// </summary>
    public partial class DatMuaVaccineUI : Window
    {
        Vaccine_BUS vcb = new Vaccine_BUS();
        HSKH_BUS HSKH_BUS = new HSKH_BUS();
        List<CTPhieuDatMua> PhieuDatMua = new List<CTPhieuDatMua>();

        public DatMuaVaccineUI()
        {
            InitializeComponent();
            LayDSVaccine();
            txtNgayDat.Text = DateTime.Now.ToShortDateString();
        }

        private void LayDSVaccine()
        {
            List<Vaccine> DSVaccine = vcb.LayDSVaccine();
            
            foreach (Vaccine v in DSVaccine)
            {
                CTPhieuDatMua ct = new CTPhieuDatMua();
                ct.MaVaccine = v.MaVaccine;
                ct.TenVaccine = v.TenVaccine;
                ct.Gia = v.Gia;
                ct.SoLuong = 0;
                ct.ThanhTien = 0;
                PhieuDatMua.Add(ct);
            }
            dgvDSVaccine.ItemsSource = PhieuDatMua;
            dgvDSVaccine.Items.Refresh();
        }

        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            // Tạo phiếu đặt mua vaccine
            if(txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa có thông tin khách hàng");
                return;
            }
            if(Int32.Parse(txtTongTien.Text) == 0)
            {
                MessageBox.Show("Vui lòng chọn vaccine muốn đặt");
                return;
            }

            // Viết tiếp vào đây
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThayDoiSoLuong(object sender, DataGridCellEditEndingEventArgs e)
        {
            CTPhieuDatMua ct = e.Row.Item as CTPhieuDatMua;
            if(ct.SoLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                e.Cancel = true;
                return;
            }
            ct.ThanhTien = ct.Gia * ct.SoLuong;
            PhieuDatMua[e.Row.GetIndex()] = ct;
            dgvDSVaccine.ItemsSource = null;
            dgvDSVaccine.ItemsSource = PhieuDatMua;

            decimal TongTien = 0;
            for(int i = 0; i < PhieuDatMua.Count; i++)
            {
                TongTien = TongTien + PhieuDatMua[i].ThanhTien;
            }

            txtTongTien.Text = TongTien.ToString() + "VNĐ";
        }

        private void ThayDoiMaKH(object sender, TextChangedEventArgs e)
        {
            if (tbMaKH.Text.Length == 0)
                return;
            try
            {
                int makh = Int32.Parse(tbMaKH.Text);
                HSKH KH = HSKH_BUS.LayThongTinKH(makh);
                if (KH == null)
                {
                    txtHoTen.Text = "";
                    txtSDT.Text = "";
                    return;
                }        
                txtHoTen.Text = KH.TenKH;
                txtSDT.Text = KH.SDT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
