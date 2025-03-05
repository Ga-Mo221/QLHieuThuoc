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

namespace QLHieuThuoc.UserControls
{
    /// <summary>
    /// Interaction logic for FNhapHang_SanPham.xaml
    /// </summary>
    public partial class FNhapHang_SanPham : UserControl
    {
        public event EventHandler<string> Click;

        private string ten;
        private string sl;
        private string gia;

        public FNhapHang_SanPham()
        {
            InitializeComponent();
        }

        public string TenSanPham
        {
            get => ten; set { ten = value; tbl_TenSanPham.Text = value; }
        }
        public string SoLuong
        {
            get => sl; set { sl = value; tbl_SoLuongSanPham.Text = value; }
        }
        public string GiaSanPham
        {
            get => gia; set { gia = value; tbl_GiaSanPham.Text = value; }
        }

        private void bt_Xoa_Click(object sender, RoutedEventArgs e)
        {
            string TenSanPham = ten;
            Click?.Invoke(this, TenSanPham);
        }
    }
}
