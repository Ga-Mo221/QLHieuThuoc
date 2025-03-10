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

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for ThongBao.xaml
    /// </summary>
    public partial class ThongBao : Window
    {
        private const string Do = "#FC6060";
        private const string Cam = "#E2895A";

        public ThongBao(string TieuDe, string NoiDung, string Mau)
        {
            InitializeComponent();

            // Sử dụng switch expression để chọn màu
            string mau = Mau switch
            {
                "Do" => Do,
                "Cam" => Cam,
                _ => Mau // Nếu không phải "Do" hay "Cam", dùng mã màu trực tiếp
            };

            CapNhat(TieuDe, NoiDung, mau);
        }



        private void CapNhat(string TieuDe, string NoiDung, string Mau)
        {
            
            style.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Mau));
            style.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Mau));
            ok.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Mau));
            tbl_TieuDe.Text = TieuDe;
            tbl_conten.Text = NoiDung;
        }





        public static void Show(string TieuDe, string NoiDung, string Mau = "#E2895A")
        {
            ThongBao tb = new ThongBao(TieuDe, NoiDung, Mau);
            tb.ShowDialog(); // Hiển thị dưới dạng modal, chặn thao tác cửa sổ khác
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; // Xác nhận người dùng đã nhấn OK
        }
    }
}
