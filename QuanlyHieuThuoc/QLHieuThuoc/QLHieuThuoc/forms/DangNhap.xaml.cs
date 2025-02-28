using QLHieuThuoc.Model.Account;
using QLHieuThuoc.Model.Files;
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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        Model.sql.Modify modify = new Model.sql.Modify();
        DocGhi dg = new DocGhi();


        public DangNhap()
        {
            InitializeComponent();

            // lấy ngôn ngữ
            dg.Setting();
            dg.Ngongu(NN.nn,NN.NgonNguSetting);

            this.Loaded += DangNhap_Loaded;
        }

        private void DangNhap_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbl_QuenMatKhau_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            QuenMK QuenMatKhau_windown = new QuenMK();
            QuenMatKhau_windown.ShowDialog();

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tk = tb_TaiKhoanDangNhap.Text;
            string mk = pw_MatKhauDangNhap.Password;

            if (tk.Trim() == "") { return; }
            else if (mk.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            else
            {
                string LenhTruyVan = "Select * from TaiKhoan where TK = '" + tk + "' and MK = '" + mk + "'";
                if (modify.TaiKhoans(LenhTruyVan).Count > 0)
                {
                    MessageBox.Show("Đăng Nhập Thành Công");
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string IDNV = tb_MaNhanVien.Text;
            string TKDK = tb_TaiKhoanDangKy.Text;
            string MKDK = pw_MatKhauDangKy.Password;

            if(IDNV.Trim() == "") { MessageBox.Show("Vui lòng nhập ID Nhân Viên", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (TKDK.Trim() == "") { MessageBox.Show("Vui lòng nhập Tài Khoản", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (MKDK.Trim() == "") { MessageBox.Show("Vui lòng nhập Mật Khẩu", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning); return; }


            string CauLenhTruyVanMaNhanVien = "Select * from NhanVien where ID = '"+IDNV+"'";
            if (modify.NhanViens(CauLenhTruyVanMaNhanVien).Count == 1)
            {
                string CauLenhTruyVanTaiKhoan = "Select * from TaiKhoan where TK = '"+TKDK+"'";
                if (modify.TaiKhoans(CauLenhTruyVanTaiKhoan).Count == 0)
                {
                    string CauLenhAddNewAcc = "Insert into TaiKhoan values ('"+TKDK+"','"+MKDK+"','"+IDNV+"')";
                    modify.ThucThi(CauLenhAddNewAcc);

                    MessageBox.Show("Bạn đã đăng ký thành công. Hãy quay lại để đăng nhập.", "Thông Báo", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Tài Khoản đã tồn tại!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("ID nhân viên không tồn tại!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }








        // stting TextBox

        // TextBox tài khoản đăng nhập
        private void tb_TaiKhoanDangNhap_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_TaiKhoanDangNhap.Text == "Tài Khoản")
            {
                tb_TaiKhoanDangNhap.Text = "";
                tb_TaiKhoanDangNhap.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_TaiKhoanDangNhap_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoanDangNhap.Text))
            {
                tb_TaiKhoanDangNhap.Text = "Tài Khoản";
                tb_TaiKhoanDangNhap.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // PasswordBox đăng nhập
        private void pw_MatKhauDangNhap_GotFocus(object sender, RoutedEventArgs e)
        {
            tbl_HienThiMatKhau.Visibility = Visibility.Hidden; // Ẩn TextBlock khi click vào PasswordBox
        }
        private void pw_MatKhauDangNhap_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pw_MatKhauDangNhap.Password))
            {
                tbl_HienThiMatKhau.Visibility = Visibility.Visible; // Hiện lại nếu không nhập gì
            }
        }

        // TextBox mã nhân viên đăng ký
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

        // PasswordBox đăng ký
        private void pw_MatKhauDangKy_GotFocus(object sender, RoutedEventArgs e)
        {
            tbl_HienThiMatKhauDangKy.Visibility = Visibility.Hidden; // Ẩn TextBlock khi click vào PasswordBox
        }
        private void pw_MatKhauDangKy_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pw_MatKhauDangKy.Password))
            {
                tbl_HienThiMatKhauDangKy.Visibility = Visibility.Visible; // Hiện lại nếu không nhập gì
            }
        }

        // TextBox tài khoản đăng ký
        private void tb_TaiKhoanDangKy_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_TaiKhoanDangKy.Text == "Tài Khoản")
            {
                tb_TaiKhoanDangKy.Text = "";
                tb_TaiKhoanDangKy.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_TaiKhoanDangKy_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoanDangKy.Text))
            {
                tb_TaiKhoanDangKy.Text = "Tài Khoản";
                tb_TaiKhoanDangKy.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

    }
}
