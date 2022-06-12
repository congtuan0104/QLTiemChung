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
    /// Interaction logic for ChinhSuaLichLamViec_UI.xaml
    /// </summary>
    public partial class ChinhSuaLichLamViec_UI : Window
    {
        public ChinhSuaLichLamViec_UI()
        {
            InitializeComponent();
        }

        

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            XemLichLamViecUI xemLich = new XemLichLamViecUI();
            xemLich.Show();
            this.Close();
        }
    }
}
