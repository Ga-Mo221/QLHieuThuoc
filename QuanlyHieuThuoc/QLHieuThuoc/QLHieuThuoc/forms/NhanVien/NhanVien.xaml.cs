using QLHieuThuoc.forms.FNhanVien;
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
        public NhanVien()
        {
            InitializeComponent();
            Loaded += NhanVien_Loaded;
            KiemTra(1);
            Mo(Grid_NoiDung, child, new LichLam());
        }

        private void NhanVien_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
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
            Mo(Grid_NoiDung, child, new LichLam());
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
    }
}
