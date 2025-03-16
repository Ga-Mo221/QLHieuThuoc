using QLHieuThuoc.forms.FNhanVien;
using QLHieuThuoc.forms.Thongbaos;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms.NhanVien
{
    /// <summary>
    /// Interaction logic for NhanVien.xaml
    /// </summary>
    public partial class NhanVien : UserControl
    {
        UserControl child = null;
        LayThongBao thongbao = new LayThongBao();
        Modify modify = new Modify();
        CheckAccount checkAccount = new CheckAccount();
        private string idnv;
        public NhanVien(string id)
        {
            InitializeComponent();
            Loaded += NhanVien_Loaded;
            KiemTra(1);
            idnv = id;   
            Mo(Grid_NoiDung, child, new LichLam(idnv));
            thongbao.BatThongBao(CoThongBao);
        }

        private void NhanVien_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            CapNhatTaiKhoan();
            CapNhatQuyenTruyCap();
        }

        private void CapNhatTaiKhoan()
        {
            string lenh = "select * from NhanVien where ID = '" + idnv + "'";
            List<nhanVien> nhanViens = modify.NhanViens(lenh);
            if (nhanViens.Count > 0)
            {
                tbl_TenNhanVienThanhTiemKiem.Text = nhanViens[0].Ten1;
                tbl_IdNhanVienThanhTimKiem.Text = idnv;
            }
        }

        private void CapNhatQuyenTruyCap()
        {
            if (checkAccount.check(idnv))
            {
                bt_Luong.Visibility = Visibility.Collapsed;
                bt_ThoiGian.Visibility = Visibility.Collapsed;
            }
        }

        // Hiển thị giao diện
        private void Mo(Grid panel1, UserControl activeform, UserControl childform)
        {
            if (activeform != null)
            {
                panel1.Children.Remove(activeform); // Xóa giao diện cũ
            }
            activeform = childform; // Gán giao diện mới
            panel1.Children.Add(childform); // Thêm vào Grid
        }


        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[33]}";
            tbl_bt_LichLam.Text = NN.nn[151];
            tbl_bt_ThoiGian.Text = NN.nn[152];
            tbl_bt_Luong.Text = NN.nn[153];
        }

        // sự kiện clik button
        private void KiemTra(int nut)
        {
            switch (nut)
            {
                case 1:
                    bt_LichLam.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2895A"));
                    bt_ThoiGian.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEB99D"));
                    bt_Luong.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEB99D"));
                    break;
                case 2:
                    bt_LichLam.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEB99D"));
                    bt_ThoiGian.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2895A"));
                    bt_Luong.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEB99D"));
                    break;
                case 3:
                    bt_LichLam.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEB99D"));
                    bt_ThoiGian.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEB99D"));
                    bt_Luong.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2895A"));
                    break;
            }
        }

        private void bt_LichLam_Click(object sender, RoutedEventArgs e)
        {
            KiemTra(1);
            Mo(Grid_NoiDung, child, new LichLam(idnv));
        }

        private void bt_ThoiGian_Click(object sender, RoutedEventArgs e)
        {
            KiemTra(2);
            Mo(Grid_NoiDung, child, new QlGioLam());
        }

        private void bt_Luong_Click(object sender, RoutedEventArgs e)
        {
            KiemTra(3);
            Mo(Grid_NoiDung, child, new Luong());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThongBaoSanPham.status = false;
            CoThongBao.Visibility = Visibility.Collapsed;
            ThanhThongBaoSanPham thanhthongbao = new ThanhThongBaoSanPham();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                thanhthongbao.Left = parentWindow.Left + (parentWindow.Width - thanhthongbao.Width) / 1.17;
                thanhthongbao.Top = parentWindow.Top + 110;
            }
            thanhthongbao.Show();
        }
    }
}
