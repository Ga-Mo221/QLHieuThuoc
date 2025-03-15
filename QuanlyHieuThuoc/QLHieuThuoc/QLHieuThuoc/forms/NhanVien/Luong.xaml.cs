using QLHieuThuoc.forms.NhanVien;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
using QLHieuThuoc.Model.sql;
using QLHieuThuoc.UserControls.NhanVien;
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

namespace QLHieuThuoc.forms.FNhanVien
{
    /// <summary>
    /// Interaction logic for Luong.xaml
    /// </summary>
    public partial class Luong : UserControl
    {
        Modify modify = new Modify();
        List<BangLuongDayDu> bldd = new List<BangLuongDayDu>();
        private List<int> nams = new List<int> { 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2020, 2021, 2022, 2023, 2024, 2025, 2026};
        private string mauchon = "#C9F1B4";
        public Luong()
        {
            InitializeComponent();
            cbb_Nam.ItemsSource = nams;
            Loaded += Luong_Loaded;
            
        }

        private void Luong_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            Nhan(DateTime.Now.Month);
            AddBangLuong(DateTime.Now.Month, (int)cbb_Nam.SelectedItem);
        }

        // tháng 1
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nhan(1);
            AddBangLuong(1, (int)cbb_Nam.SelectedItem);
        }
        // tháng 2
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nhan(2);
            AddBangLuong(2, (int)cbb_Nam.SelectedItem);
        }
        // tháng 3
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nhan(3);
            AddBangLuong(3, (int)cbb_Nam.SelectedItem);
        }
        // tháng 4
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Nhan(4);
            AddBangLuong(4, (int)cbb_Nam.SelectedItem);
        }
        // tháng 5
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Nhan(5);
            AddBangLuong(5, (int)cbb_Nam.SelectedItem);
        }
        // tháng 6
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Nhan(6);
            AddBangLuong(6, (int)cbb_Nam.SelectedItem);
        }
        // tháng 7
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Nhan(7);
            AddBangLuong(7, (int)cbb_Nam.SelectedItem);
        }
        // tháng 8
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Nhan(8);
            AddBangLuong(8, (int)cbb_Nam.SelectedItem);
        }
        // tháng 19
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Nhan(9);
            AddBangLuong(9, (int)cbb_Nam.SelectedItem);
        }
        // tháng 10
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Nhan(10);
            AddBangLuong(10, (int)cbb_Nam.SelectedItem);
        }
        // tháng 11
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Nhan(11);
            AddBangLuong(11, (int)cbb_Nam.SelectedItem);
        }
        // tháng 12
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Nhan(12);
            AddBangLuong(12, (int)cbb_Nam.SelectedItem);
        }






        // Them Luong Nhan Vien
        private void AddBangLuong(int month, int year)
        {
            if (stb_listBangLuong != null)
            {
                stb_listBangLuong.Children.Clear();
            }

            string query = @"
                SELECT 
                    NV.ID AS IDNhanVien, 
                    NV.TEN, 
                    NV.CHUCVU, 
                    NV.SDT, 
                    NV.DIACHI, 
                    NV.NGAYTHEM, 
                    L.ID AS IDLuong, 
                    L.THANG, 
                    L.NAM, 
                    L.NGAYTAO, 
                    L.SONGIOLAM, 
                    L.TIENTHUONG, 
                    L.TIENTROCAP, 
                    L.LUONG
                FROM NhanVien NV
                LEFT JOIN Luong L ON NV.ID = L.IDNV;
            ";

            bldd = modify.bangLuongDayDus(query);
            foreach (var b in bldd)
            {
                if (b.Thang == month && b.Nam == year)
                {
                    LuongNhanVien luongnhanvien = new LuongNhanVien();
                    luongnhanvien.Height = 47;
                    luongnhanvien.ID = b.IdLuong;
                    luongnhanvien.TEN = b.Ten;
                    luongnhanvien.THANG = b.Thang;
                    luongnhanvien.TONGGIOLAM = b.SoGioLam;
                    luongnhanvien.LUONG = b.Luong;

                    luongnhanvien.Click += Luongnhanvien_Click;
                    stb_listBangLuong.Children.Add(luongnhanvien);
                }
            }
        }

        private void Luongnhanvien_Click(object? sender, string e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                foreach (var b in bldd)
                {
                    if (b.IdLuong == e)
                    {
                        Mo.OpenWindowWithBlur(mainWindow, new CTBangLuong(b));
                    }
                }
            }
        }



        // cap nhat ngon ngu
        private void CapNhatNN()
        {
            tbl_Nam.Text = NN.nn[175];
            tbl_Thang.Text = NN.nn[174];
            tbl_IDBangLuong.Text = NN.nn[182];
            tbl_TenNhanVien.Text = NN.nn[168];
            tbl_ThangLuong.Text = NN.nn[183];
            tbl_SoGioLam.Text = NN.nn[179];
            tbl_Luong.Text = NN.nn[180];

            cbb_Nam.SelectedItem = DateTime.Now.Year;
        }
        // select item
        private void Nhan(int thang)
        {
            switch (thang)
            {
                case 1:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 2:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 3:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 4:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 5:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 6:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 7:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 8:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 9:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 10:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 11:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    break;
                case 12:
                    Thang1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang9.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang10.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang11.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCB48E"));
                    Thang12.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(mauchon));
                    break;
            }
        }

        private void cbb_Nam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddBangLuong(1, (int)cbb_Nam.SelectedItem);
            Nhan(1);
        }
    }
}
