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
            dg.Setting(); // đọng file setting để lấy được ngôn ngữ đã thiết lập 
            dg.Ngongu(NN.nn,NN.NgonNguSetting); // cập nhật ngôn ngữ vào list

            this.Loaded += DangNhap_Loaded;
        }


        // Cập nhật ngôn ngữ vs theme cho hệ thống
        private void DangNhap_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }


        // Chuyển sang cửa sổ quên mật khẩu
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

        // Thoát chương trình
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        // Sự kiện kiểm tra tài khoản mật khẩu và đăng nhập
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //string tk = tb_TaiKhoanDangNhap.Text;
            //string mk = pw_MatKhauDangNhap.Password;

            //if (tk.Trim() == "") { return; }
            //else if (mk.Trim() == "") { MessageBox.Show(NN.nn[1], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            //else
            //{
            //    string LenhTruyVan = "Select * from TaiKhoan where TK = '" + tk + "' and MK = '" + mk + "'";
            //    List<TaiKhoan> tkl = modify.TaiKhoans(LenhTruyVan);
            //    if (tkl.Count > 0)
            //    {
            //        string idnv = tkl[0].MaNhanVien1;
            //        MainWindow CuaSoChinh = new MainWindow(idnv);
            //        this.Hide();
            //        CuaSoChinh.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show(NN.nn[3], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning);
            //    }
            //}
            string idnv = "gde";
            MainWindow CuaSoChinh = new MainWindow(idnv);
            this.Hide();
            CuaSoChinh.Show();
        }


        // Sự kiện đăng ký tài khoản
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string IDNV = tb_MaNhanVien.Text;
            string TKDK = tb_TaiKhoanDangKy.Text;
            string MKDK = pw_MatKhauDangKy.Password;

            if(IDNV.Trim() == "") { MessageBox.Show(NN.nn[6], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (TKDK.Trim() == "") { MessageBox.Show(NN.nn[7], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (MKDK.Trim() == "") { MessageBox.Show(NN.nn[8], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }


            string CauLenhTruyVanMaNhanVien = "Select * from NhanVien where ID = '"+IDNV+"'";
            if (modify.NhanViens(CauLenhTruyVanMaNhanVien).Count == 1)
            {
                string CauLenhTruyVanMaNhanVienDaCoTaiKhoanChua = "Select * from TaiKhoan where IDNV = '"+IDNV+"'";
                if (modify.TaiKhoans(CauLenhTruyVanMaNhanVienDaCoTaiKhoanChua).Count == 0)
                {
                    string CauLenhTruyVanTaiKhoan = "Select * from TaiKhoan where TK = '"+TKDK+"'";
                    if (modify.TaiKhoans(CauLenhTruyVanTaiKhoan).Count == 0)
                    {
                        string CauLenhAddNewAcc = "Insert into TaiKhoan values ('"+TKDK+"','"+MKDK+"','"+IDNV+"')";
                        modify.ThucThi(CauLenhAddNewAcc);

                        MessageBox.Show(NN.nn[9], NN.nn[2], MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show(NN.nn[10], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(NN.nn[11], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(NN.nn[12], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }




        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            // thoat
            tbl_bt_thoat.Text = NN.nn[21];

            // đăng nhập
            tbl_titel1.Text = NN.nn[13];
            tb_TaiKhoanDangNhap.Text = NN.nn[4];
            tbl_HienThiMatKhau.Text = NN.nn[14];
            tbl_QuenMatKhau.Text = NN.nn[15];  
            tbl_bt_Dangnhap.Text = NN.nn[16];
            tbl_quadangky.Text = $"{NN.nn[17]}   ";
            tbl_txtquadangky.Text = NN.nn[18];

            // đăng ký
            tbl_titel2.Text = NN.nn[19];
            tb_MaNhanVien.Text = NN.nn[5];
            tb_TaiKhoanDangKy.Text = NN.nn[4];
            tbl_HienThiMatKhauDangKy.Text = NN.nn[14];
            tbl_bt_Dangky.Text = NN.nn[18];
            tbl_qldangnhap.Text = $"{NN.nn[20]}   ";
            tbl_txtqldangnhap.Text = NN.nn[16];
        }









        // stting TextBox

        // TextBox tài khoản đăng nhập
        private void tb_TaiKhoanDangNhap_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_TaiKhoanDangNhap.Text == NN.nn[4])
            {
                tb_TaiKhoanDangNhap.Text = "";
                tb_TaiKhoanDangNhap.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_TaiKhoanDangNhap_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoanDangNhap.Text))
            {
                tb_TaiKhoanDangNhap.Text = NN.nn[4];
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
            if (tb_MaNhanVien.Text == NN.nn[5])
            {
                tb_MaNhanVien.Text = "";
                tb_MaNhanVien.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_MaNhanVien_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_MaNhanVien.Text))
            {
                tb_MaNhanVien.Text = NN.nn[5];
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
            if (tb_TaiKhoanDangKy.Text == NN.nn[4])
            {
                tb_TaiKhoanDangKy.Text = "";
                tb_TaiKhoanDangKy.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_TaiKhoanDangKy_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoanDangKy.Text))
            {
                tb_TaiKhoanDangKy.Text = NN.nn[4];
                tb_TaiKhoanDangKy.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

    }
}
