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

namespace QLHieuThuoc.UserControls.HoaDonDonBan
{
    /// <summary>
    /// Interaction logic for ThanhSanPhamHoaDon.xaml
    /// </summary>
    public partial class ThanhSanPhamHoaDon : UserControl
    {
        private string ten;
        private int soluong;
        private decimal gia;

        public ThanhSanPhamHoaDon()
        {
            InitializeComponent();
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; tbl_TenSanPham.Text = ten; }
        }
        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; tbl_SoLuong.Text = soluong.ToString(); }
        }

        public decimal Gia
        {
            get { return gia; }
            set { gia = value; tbl_DonGia.Text = gia.ToString(); }
        }

        public void ThanhTien()
        {
            if (soluong != 0 && gia != 0)
            {
                tbl_ThanhTien.Text = (soluong * gia).ToString();
            }
        }
    }
}
