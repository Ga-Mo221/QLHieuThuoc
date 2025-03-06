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
    /// Interaction logic for FNhapHang_DonNhapHang.xaml
    /// </summary>
    public partial class FNhapHang_DonNhapHang : UserControl
    {
        public event EventHandler<string> Click;

        private string madonnhap;
        private string manhacungcap;
        private DateTime ngaynhap;
        private decimal tongtien;
        private string phuongthuc;


        public FNhapHang_DonNhapHang()
        {
            InitializeComponent();
        }

        public void setcolor(string color)
        {
            tbl_PhuongThuc.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        public string MaDonNhap
        {
            get { return madonnhap; }
            set { madonnhap = value; tbl_IdDonNhap.Text = value; }
        }
        public string MaNhaCungCap
        {
            get { return manhacungcap; }
            set { manhacungcap = value; tbl_IdNhaCungCap.Text = value; }
        }
        public decimal TongTien
        {
            get { return tongtien; }
            set { tongtien = value; tbl_TongTien.Text = value.ToString(); }
        }
        public DateTime NgayNhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; tbl_NgayNhap.Text = value.ToString("dd/MM/yyyy"); }
        }
        public string PhuongThuc
        {
            get { return phuongthuc; }
            set { phuongthuc = value; tbl_PhuongThuc.Text = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ma = madonnhap;
            Click?.Invoke(this, ma);
        }
    }
}
