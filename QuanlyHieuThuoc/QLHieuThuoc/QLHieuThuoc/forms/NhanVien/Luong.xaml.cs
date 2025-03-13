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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms.FNhanVien
{
    /// <summary>
    /// Interaction logic for Luong.xaml
    /// </summary>
    public partial class Luong : UserControl
    {
        private List<int> nams = new List<int> { 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011};
        public Luong()
        {
            InitializeComponent();
            cbb_Nam.ItemsSource = nams;
        }

        // tháng 1
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        // tháng 2
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        // tháng 3
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        // tháng 4
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        // tháng 5
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
        // tháng 6
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
        // tháng 7
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
        // tháng 8
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
        // tháng 19
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }
        // tháng 10
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {

        }
        // tháng 11
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {

        }
        // tháng 12
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {

        }


        private void AddDanhSachBangLuong(int thang)
        {
            string lenh = "select * from Luong where THANG = "+thang+" and NAM = "+(int)cbb_Nam.SelectedItem+"";
        }
    }
}
