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
        List<CTPhieuDatMua> CHITIETPhieuDatMua = new List<CTPhieuDatMua>();
        PhieuDatMua_BUS pdm = new PhieuDatMua_BUS();
        CTPhieuDatMua_BUS ctb = new CTPhieuDatMua_BUS();

        public DatMuaVaccineUI()
        {
            InitializeComponent();
            LayDSVaccine();
            txtNgayDat.Text = DateTime.Now.ToShortDateString();
        }

        private void LayDSVaccine()
        {
            List<Vaccine> DSVaccine = vcb.LayDSVaccine();
            int i = 0;
            foreach (Vaccine v in DSVaccine)
            {
                CTPhieuDatMua ct = new CTPhieuDatMua();
                ct.MaVaccine = v.MaVaccine;
                ct.TenVaccine = v.TenVaccine;
                ct.Gia = v.Gia;
                ct.SoLuong = 0;
                ct.ThanhTien = 0;
                CHITIETPhieuDatMua.Add(ct);

            }
            dgvDSVaccine.ItemsSource = CHITIETPhieuDatMua;
            dgvDSVaccine.Items.Refresh();
        }

        private void btnMua_Click(object sender, RoutedEventArgs e)
        {

            // Tạo phiếu đặt mua vaccine
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa có thông tin khách hàng");
                return;
            }


            if (float.Parse(txtTongTien.Text) == 0)
            {
                MessageBox.Show("Vui lòng chọn vaccine muốn đặt");
                return;
            }

            PhieuDatMua pdmua = new PhieuDatMua();
            pdmua.NgayDat = DateTime.Parse(txtNgayDat.Text);
            pdmua.MaKH = Int32.Parse(tbMaKH.Text);
            pdm.ThemPhieuDatMuaVaccine(pdmua);

            for (int i = 0; i < CHITIETPhieuDatMua.Count; i++)
            {
                if (CHITIETPhieuDatMua[i].ThanhTien > 0 && CHITIETPhieuDatMua[i].SoLuong >= 1)
                {
                    ctb.ThemChiTietPhieuDatMuaVaccine(CHITIETPhieuDatMua[i]);
                }

            }

            MessageBox.Show("Tạo phiếu thành công");
            this.Close();
            return;



        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThayDoiSoLuong(object sender, DataGridCellEditEndingEventArgs e)
        {
            CTPhieuDatMua ct = e.Row.Item as CTPhieuDatMua;
            if (ct.SoLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                e.Cancel = true;
                return;
            }

            ct.ThanhTien = ct.Gia * ct.SoLuong;
            CHITIETPhieuDatMua[e.Row.GetIndex()] = ct;
            dgvDSVaccine.ItemsSource = null;
            dgvDSVaccine.ItemsSource = CHITIETPhieuDatMua;

            decimal TongTien = 0;






            for (int i = 0; i < CHITIETPhieuDatMua.Count; i++)
            {

                TongTien = TongTien + CHITIETPhieuDatMua[i].ThanhTien;

            }

            txtTongTien.Text = TongTien.ToString();


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
