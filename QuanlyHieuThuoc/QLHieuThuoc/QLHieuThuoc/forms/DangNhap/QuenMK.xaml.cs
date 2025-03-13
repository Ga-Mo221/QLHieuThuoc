using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.sql;
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
        Modify modify = new Modify();


        public QuenMK()
        {
            InitializeComponent();

            this.Loaded += QuenMK_Loaded;
        }


        // Cập Nhật cửa sổ
        private void QuenMK_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }


        // thoát cửa sổ quên mật khẩu
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // sự kiện kiểm tra tài khoản và mã nhân viên có đúng không
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string IDNV = tb_MaNhanVien.Text;
            string TK = tb_TaiKhoan.Text;
            string MKM = pw_MatKhau.Password;

            if (IDNV.Trim() == "" || IDNV.Trim() == NN.nn[5]) { ThongBao.Show(NN.nn[77], NN.nn[6], "Do"); return; }
            if (TK.Trim() == "" || TK.Trim() == NN.nn[4]) { ThongBao.Show(NN.nn[77], NN.nn[7], "Do"); return; }
            if (MKM.Trim() == "") { ThongBao.Show(NN.nn[77], NN.nn[8], "Do"); return; }


            string CauTruyVanKiemTraIDNV = "Select * from NhanVien where ID = '" + IDNV + "'";
            if (modify.NhanViens(CauTruyVanKiemTraIDNV).Count > 0)
            {
                string CauTruyVanKiemTraTK = "Select * from TaiKhoan where TK = '"+TK+"'";
                if (modify.TaiKhoans(CauTruyVanKiemTraTK).Count > 0)
                {
                    string CauTruyVanUpdateMK = "Update TaiKhoan set MK = '"+MKM+"' where TK = '"+TK+"'";
                    modify.ThucThi(CauTruyVanUpdateMK);

                    ThongBao.Show(NN.nn[2], NN.nn[26], "Do");
                }
                else
                {
                    ThongBao.Show(NN.nn[2], NN.nn[25], "Do");
                }
            }
            else
            {
                ThongBao.Show(NN.nn[2], NN.nn[12], "Do");
            }
        }

        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_titel.Text = NN.nn[22];
            tb_MaNhanVien.Text = NN.nn[5];
            tb_TaiKhoan.Text = NN.nn[4];
            tbl_HienThiMatKhau.Text = NN.nn[23];
            tbl_bt_Dangky.Text = NN.nn[24];
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
            if (tb_TaiKhoan.Text == NN.nn[4])
            {
                tb_TaiKhoan.Text = "";
                tb_TaiKhoan.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_TaiKhoan_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoan.Text))
            {
                tb_TaiKhoan.Text = NN.nn[4];
                tb_TaiKhoan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // textBox mã nhân viên
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

    }
}
