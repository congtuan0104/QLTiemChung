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
        HSTiemChung_BUS hstcb = new HSTiemChung_BUS();
        CTHSTC_BUS cthstcb = new CTHSTC_BUS();
        List<GoiVaccine> DS_GoiVaccine = new List<GoiVaccine>();
        List<Vaccine> DS_Vaccine = new List<Vaccine>();
        public DangKyTiemChungUI(int MaKH)
        {
            InitializeComponent();
            HienThiThongTin(MaKH);
            HienThiDSVaccine();
            HienThiDSGoiVaccine();
            HienThiTrungTam();
            dgvDSGoiVaccine.IsEnabled = false;
            dgvDSVaccine.IsEnabled = true;
        }

        private void HienThiThongTin(int MaKH)
        {
            HSKH kh = hskhb.LayThongTinKH(MaKH);
            txtMaKH.Text = MaKH.ToString();
            txtTenKH.Text = kh.TenKH;
        }

        private void HienThiDSGoiVaccine()
        {
            DS_GoiVaccine = gvcb.LayDSGoiVaccine();
            dgvDSGoiVaccine.ItemsSource = DS_GoiVaccine;
            dgvDSGoiVaccine.Items.Refresh();
        }

        private void HienThiDSVaccine()
        {
            DS_Vaccine = vcb.LayDSVaccine();
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
        private void rb_TiemGoiChecked(object sender, RoutedEventArgs e)
        {
            dgvDSGoiVaccine.IsEnabled = true;
            dgvDSVaccine.IsEnabled = false;
        }

        private void rb_TiemLeChecked(object sender, RoutedEventArgs e)
        {
            dgvDSGoiVaccine.IsEnabled = false;
            dgvDSVaccine.IsEnabled = true;
        }
        private bool checkInputControl()
        {
            if (dpNgayHenTiem.ToString() == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày hẹn tiêm", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                dpNgayHenTiem.Focus();
                return false;
            }

            if (cbNoiTiem.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa nhập nơi hẹn tiêm", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbNoiTiem.Focus();
                return false;
            }

            if (rb_TiemGoi.IsChecked == false && rb_TiemLe.IsChecked == false)
            {
                MessageBox.Show("Bạn chưa chọn gói tiêm", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            if (!checkInputControl()) return;
            HSTiemChung hstc = new HSTiemChung();
            CTHSTC cthstc = new CTHSTC();

            if (cbNoiTiem.SelectedItem.ToString() == "Rhett Rayford")
            {
                hstc.MaTT = 1;
            }
            else if (cbNoiTiem.SelectedItem.ToString() == "Bernardo Fredericks")
            {
                hstc.MaTT = 2;
            }
            else hstc.MaTT = 3;

            hstc.MaKH = Int32.Parse(txtMaKH.Text);
            hstc.NgayLapHS = DateTime.Now;
            hstc.NgayHenTiem = dpNgayHenTiem.SelectedDate.Value;

            if (!hstcb.ThemHSTC(hstc))
            {
                MessageBox.Show("Tạo hồ sơ thất bại");
                this.Close();
                return;
            }
             MessageBox.Show("Tạo hồ sơ thành công"); 
            if (rb_TiemLe.IsChecked == true)
            {
                for (int i = 0; i < DS_Vaccine.Count; i++)
                {
                    if (DS_Vaccine[i].DuocChon == true)
                    {
                        if (!vcb.KiemTraSLVaccine(DS_Vaccine[i].MaVaccine, 1))
                        {
                            MessageBox.Show("Không đủ số lượng vaccine ", DS_Vaccine[i].TenVaccine);
                            return;
                        }
                    }
                }

                for (int i = DS_Vaccine.Count - 1; i >= 0; i--)
                {
                    if (DS_Vaccine[i].DuocChon == true)
                    {
                        cthstcb.ThemChiTietHSTC(DS_Vaccine[i].MaVaccine);

                    }
                }
            }
            else
            {
                for (int i = 0; i < DS_GoiVaccine.Count; i++)
                {
                    if (DS_GoiVaccine[i].DuocChon == true)
                    {
                        if (!gvcb.KiemTraSLGoiVaccine(DS_GoiVaccine[i].MaGoiVaccine, 1))
                        {
                            MessageBox.Show("Không đủ số lượng gói vaccine ", DS_GoiVaccine[i].TenGoiVaccine);
                            return;
                        }
                    }
                }

                for (int i = 0; i < DS_GoiVaccine.Count; i++)
                {
                    if (DS_GoiVaccine[i].DuocChon == true)
                    {

                        cthstcb.ThemChiTietHSTC(DS_GoiVaccine[i].MaGoiVaccine);

                    }
                }
            }

            this.Close();
            return;
        }
    }
}

