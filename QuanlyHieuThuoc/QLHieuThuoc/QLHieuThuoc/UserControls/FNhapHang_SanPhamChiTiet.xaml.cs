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
    /// Interaction logic for FNhapHang_SanPhamChiTiet.xaml
    /// </summary>
    public partial class FNhapHang_SanPhamChiTiet : UserControl
    {
        private string tenSanPham;
        private string soLuong;
        private string gia;

        public FNhapHang_SanPhamChiTiet()
        {
            InitializeComponent();
        }

        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; tbl_TenSanPham.Text = tenSanPham; }
        }
        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; tbl_SoLuong.Text = soLuong; }
        }
        public string Gia
        {
            get { return gia; }
            set { gia = value; tbl_Gia.Text = gia; }
        }
    }
}
