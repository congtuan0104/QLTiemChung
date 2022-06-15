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
    /// Interaction logic for DangKyTiemChungUI.xaml
    /// </summary>
    public partial class DangKyTiemChungUI : Window
    {
        HSKH_BUS hskhb = new HSKH_BUS();
        Vaccine_BUS vcb = new Vaccine_BUS();
        GoiVaccine_BUS gvcb = new GoiVaccine_BUS();
        TrungTam_BUS ttb = new TrungTam_BUS();
        public DangKyTiemChungUI(int MaKH)
        {
            InitializeComponent();
            HienThiThongTin(MaKH);
            HienThiDSVaccine();
            HienThiDSGoiVaccine();
            HienThiTrungTam();
        }

        private void HienThiThongTin(int MaKH)
        {
            HSKH kh = hskhb.LayThongTinKH(MaKH);
            txtMaKH.Text = MaKH.ToString();
            txtTenKH.Text = kh.TenKH;
        }

        private void HienThiDSGoiVaccine()
        {
            List<GoiVaccine> DS_GoiVaccine = gvcb.LayDSGoiVaccine();
            dgvDSGoiVaccine.ItemsSource = DS_GoiVaccine;
            dgvDSGoiVaccine.Items.Refresh();
        }

        private void HienThiDSVaccine()
        {
            List<Vaccine> DS_Vaccine = vcb.LayDSVaccine();
            dgvDSVaccine.ItemsSource = DS_Vaccine;
            dgvDSVaccine.Items.Refresh();
        }

        private void HienThiTrungTam()
        {
            List<TrungTam> DS_TrungTam = ttb.LayDSTrungTam();
            cbNoiTiem.ItemsSource = DS_TrungTam;
            cbNoiTiem.DisplayMemberPath = "TenTT";
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại giao diện Hồ sơ khach hang
            this.Close();
        }

    }
}
