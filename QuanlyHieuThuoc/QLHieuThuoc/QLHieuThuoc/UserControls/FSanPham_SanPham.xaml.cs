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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.UserControls
{
    /// <summary>
    /// Interaction logic for FSanPham_SanPham.xaml
    /// </summary>
    public partial class FSanPham_SanPham : UserControl
    {
        public event EventHandler<string> clickbt;

        private string id;
        private string tensp;
        private string soluong;
        private string giaban;
        private string tinhtrang;
        private string loai;


        public FSanPham_SanPham()
        {
            InitializeComponent();
        }

        public void setcolor(string color)
        {
            tbl_TinhTrang.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }


        public string Id
        {
            get { return id; }
            set { id = value; tbl_MaSanPham.Text = value; }
        }
        public string TenSP
        {
            get => tensp; set { tensp = value; tbl_TenSanPham.Text = value; }
        }
        public string SoLuong
        {
            get => soluong; set { soluong = value; tbl_SoLuong.Text = value; }
        }
        public string GiaBan
        {
            get => giaban; set { giaban = value; tbl_GiaBan.Text = value; }
        }
        public string TinhTrang
        {
            get => tinhtrang; set { tinhtrang = value; tbl_TinhTrang.Text = value; }
        }
        public string Loai
        {
            get => loai; set { loai = value; tbl_loai.Text = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Gọi sự kiện khi Button được Click
            string idsp = id;
            clickbt?.Invoke(this, idsp);
        }
    }
}
