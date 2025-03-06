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
    /// Interaction logic for FNhapHang_TenNhaCungCap.xaml
    /// </summary>
    public partial class FNhapHang_TenNhaCungCap : UserControl
    {
        public event EventHandler<string> Click;
        private string tenNhaCungCap;

        public FNhapHang_TenNhaCungCap()
        {
            InitializeComponent();
        }

        public string TenNhaCungCap
        {
            get { return tenNhaCungCap; }
            set { tenNhaCungCap = value; tbl_NCCName.Text = tenNhaCungCap; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string TNCC = tenNhaCungCap;
            Click?.Invoke(this, TenNhaCungCap);
        }
    }
}
