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

namespace QLHieuThuoc.UserControls.NhanVien
{
    /// <summary>
    /// Interaction logic for TenNhanVien.xaml
    /// </summary>
    public partial class TenNhanVien : UserControl
    {
        public event EventHandler<string> Click;
        private string name;


        public TenNhanVien()
        {
            InitializeComponent();
        }


        public string Name 
        {
            get { return name; }
            set { name = value; tbl_ten.Text = name; }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string N = name;
            Click?.Invoke(this, Name);
        }
    }
}
