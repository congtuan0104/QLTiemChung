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
        Vaccine_BUS vcb = new Vaccine_BUS();
        GoiVaccine_BUS gvcb = new GoiVaccine_BUS();
        public DangKyTiemChungUI()
        {
            InitializeComponent();
            HienThiDSVaccine();
            HienThiDSGoiVaccine();
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
    }
}
