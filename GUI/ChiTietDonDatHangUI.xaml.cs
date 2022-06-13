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
    /// Interaction logic for ChiTietDonDatHangUI.xaml
    /// </summary>
    public partial class ChiTietDonDatHangUI : Window
    { CTPhieuDatMua_BUS ctpdm = new CTPhieuDatMua_BUS();
        PhieuDatMua_BUS pdm = new PhieuDatMua_BUS();
        HSKH_BUS hskhBussiness = new HSKH_BUS();

        public ChiTietDonDatHangUI(int MaKH, int MaPhieu)
        {
            InitializeComponent();
            HienThiThongTinKH(MaKH,MaPhieu);



        }
        private void HienThiThongTinKH(int MaKH, int MaPhieu)
        {
            HSKH kh = hskhBussiness.LayThongTinKH(MaKH);
            txtMaPhieu.Text = MaPhieu.ToString();
            txtMaKH_Copy3.Text = MaKH.ToString();
            txtHoten.Text = kh.TenKH;
            txtNgSinh.Text = kh.NgaySinh.ToShortDateString();
            txtSDT.Text = kh.SDT;
            List<CTPhieuDatMua> CT = ctpdm.XEMCHITIETPHIEU(MaPhieu);
            decimal T = 0;
            for (int i = 0; i < CT.Count; i++)
            {
                T = CT[i].ThanhTien + T;
            }

            DSVacXin.ItemsSource = CT;
            DSVacXin.Items.Refresh();
            txtTongTien.Text = T.ToString();
            // mới viết thêm ở đây nha
            // -1 : chưa xét 
            // 0: Ko duyệt
            // 1: đã duyệt 
            int tinhtrang;
            tinhtrang = pdm.XemTinhTrangPhieu(txtMaPhieu.Text);
         //   MessageBox.Show(tinhtrang.ToString());
         // -1 : chưa xét
            if (tinhtrang == -1)
            {
                RadioKoDuyet.IsEnabled = true;
                RadioDuyet.IsEnabled = true;
                
            }
            // đã được duyệt
            // 1: đã xét
            if (tinhtrang == 1)
            {
               // RadioKoDuyet.IsEnabled = false;
                RadioKoDuyet.IsEnabled = false;
                RadioDuyet.IsChecked = true;
            }

       
            // 0 bị từ chối hay không được duyệt
            if (tinhtrang == 0)
            {
                RadioDuyet.IsEnabled = false;

                RadioKoDuyet.IsChecked = true;

            }
        }
        public ChiTietDonDatHangUI()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MenuUI menuUI = new MenuUI();
            menuUI.Show();
            this.Close();
        }

        
        
        private void btnXacNhan_Click(object sender, RoutedEventArgs e)


            



          {


            //MessageBox.Show(txtMaPhieu.Text);
            int tinhtrang;
            tinhtrang = pdm.XemTinhTrangPhieu(txtMaPhieu.Text);

            // -1 : chưa xét 
            // 0: Ko duyệt
            // 1: đã duyệt 
            if (RadioDuyet.IsChecked==true)
            {
                MessageBox.Show(" Phiếu mua hàng đã được duyệt ");
                RadioKoDuyet.IsEnabled = false;
                pdm.UpdateTinhTrangPhieu(txtMaPhieu.Text, 1);

               
                // MessageBox.Show(tinhtrang.ToString());

            }    
          else if(RadioKoDuyet.IsChecked==true)
            {
                MessageBox.Show(" Phiếu mua hàng KHÔNG được duyệt ");
                RadioDuyet.IsEnabled = false;
                pdm.UpdateTinhTrangPhieu(txtMaPhieu.Text, 0);
                //MessageBox.Show(tinhtrang.ToString());
              

            }    

        }
    }
}
