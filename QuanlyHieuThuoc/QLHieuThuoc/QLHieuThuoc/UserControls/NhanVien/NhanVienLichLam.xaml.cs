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
    /// Interaction logic for NhanVienLichLam.xaml
    /// </summary>
    public partial class NhanVienLichLam : UserControl
    {
        public event EventHandler<string> Click;
        private string Ten;
        public NhanVienLichLam()
        {
            InitializeComponent();
        }

        public string TEN
        {
            get { return Ten; }
            set { Ten = value; tbl_TenNhanVien.Text = Ten; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ten = Ten;
            Click?.Invoke(this, ten);
        }
    }
}
