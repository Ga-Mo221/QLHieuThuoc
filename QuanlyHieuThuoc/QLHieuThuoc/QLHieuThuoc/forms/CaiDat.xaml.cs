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

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for CaiDat.xaml
    /// </summary>
    public partial class CaiDat : UserControl
    {
        private List<string> NgonNgus = new List<string>();
        private List<string> TiLeManHinh = new List<string> { NN.nn[144], NN.nn[143] };
        CheckFileNN CF = new CheckFileNN();
        DocGhi dg = new DocGhi();
        private int x = 1440;
        private int y = 930;

        public CaiDat()
        {
            InitializeComponent();
            LayTen();
            CapNhatNN();
        }

        private void LayTen()
        {
            NgonNgus = CF.GetNameFileTXT();
            cbb_NgonNgu.ItemsSource = NgonNgus;
            cbb_NgonNgu.SelectedItem = NN.NgonNguSetting;
            cbb_TiLeManHinh.ItemsSource = TiLeManHinh;
            if (NN.TileManHinh == null)
                cbb_TiLeManHinh.SelectedItem = NN.nn[144];
            else
                cbb_TiLeManHinh.SelectedItem = NN.TileManHinh;
        }

        private void cbb_NgonNgu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_NgonNgu.SelectedItem != NN.NgonNguSetting)
            {
                dg.SaveSetting($"{cbb_NgonNgu.SelectedItem.ToString()},gsdaf");
                ThongBao.Show(NN.nn[2], NN.nn[140], "Cam");
                System.Windows.Application.Current.Shutdown();
            }
        }


        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[35]}";
            tbl_LoaiNgonNgu.Text = NN.nn[141];
            tbl_TiLeManHinh.Text = NN.nn[145];
        }

        // mở full màn
        private void FullMan()
        {
            // Lấy Window cha của UserControl
            Window mainWindow = Window.GetWindow(this);

            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Maximized; // Full màn hình
                mainWindow.ResizeMode = ResizeMode.NoResize;    // Không cho phép thay đổi kích thước
            }
        }

        private void RestoreWindow(double x, double y)
        {
            // Lấy Window cha của UserControl
            Window mainWindow = Window.GetWindow(this);

            if (mainWindow != null)
            {
                mainWindow.WindowState = WindowState.Normal;    // Trở lại kích thước mặc định
                mainWindow.ResizeMode = ResizeMode.CanResize;  // Cho phép thay đổi kích thước
                mainWindow.Width = x;  // Gán lại kích thước chiều rộng
                mainWindow.Height = y; // Gán lại kích thước chiều cao
            }
        }


        private void cbb_TiLeManHinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_TiLeManHinh.SelectedItem == NN.nn[144])
            {
                RestoreWindow(x,y);
                NN.TileManHinh = cbb_TiLeManHinh.SelectedItem.ToString();
            }
            else if (cbb_TiLeManHinh.SelectedItem == NN.nn[143])
            {
                FullMan();
                NN.TileManHinh = cbb_TiLeManHinh.SelectedItem.ToString();
            }
        }
    }

}
