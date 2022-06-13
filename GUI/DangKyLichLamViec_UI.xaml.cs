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

namespace GUI
{
    /// <summary>
    /// Interaction logic for DangKyLichLamViec_UI.xaml
    /// </summary>
    public partial class DangKyLichLamViec_UI : Window
    {
        public DangKyLichLamViec_UI()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            XemLichLamViecUI xemLichLamViecUI = new XemLichLamViecUI();
            xemLichLamViecUI.Show();
            this.Close();
        }
    }
}
