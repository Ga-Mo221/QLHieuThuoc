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
    /// Interaction logic for QuenMK.xaml
    /// </summary>
    public partial class QuenMK : Window
    {
        public QuenMK()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }













        // stting TextBox

        // TextBox mật khẩu
        private void pw_MatKhau_GotFocus(object sender, RoutedEventArgs e)
        {
            tbl_HienThiMatKhau.Visibility = Visibility.Hidden; // Ẩn TextBlock khi click vào PasswordBox
        }
        private void pw_MatKhau_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pw_MatKhau.Password))
            {
                tbl_HienThiMatKhau.Visibility = Visibility.Visible; // Hiện lại nếu không nhập gì
            }
        }

        // textBox tài khoản
        private void tb_TaiKhoan_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_TaiKhoan.Text == "Tài Khoản")
            {
                tb_TaiKhoan.Text = "";
                tb_TaiKhoan.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_TaiKhoan_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoan.Text))
            {
                tb_TaiKhoan.Text = "Tài Khoản";
                tb_TaiKhoan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // textBox mã nhân viên
        private void tb_MaNhanVien_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_MaNhanVien.Text == "Mã Nhân Viên")
            {
                tb_MaNhanVien.Text = "";
                tb_MaNhanVien.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_MaNhanVien_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_MaNhanVien.Text))
            {
                tb_MaNhanVien.Text = "Mã Nhân Viên";
                tb_MaNhanVien.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }
    }
}
