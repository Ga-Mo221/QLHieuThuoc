using QLHieuThuoc.forms.CaiDat;
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

namespace QLHieuThuoc.forms.CaiDat
{
    /// <summary>
    /// Interaction logic for CaiDat.xaml
    /// </summary>
    public partial class CaiDat : UserControl
    {
        CapNhatNgonNgu cnnn = new CapNhatNgonNgu();
        Modify modify = new Modify();
        private List<string> NgonNgus = new List<string>();
        LayThongBao thongbao = new LayThongBao();
        private List<string> TiLeManHinh = new List<string> { NN.nn[144], NN.nn[143], "1440x950"};
        CheckFileNN CF = new CheckFileNN();
        DocGhi dg = new DocGhi();
        private int x = 1240;
        private int y = 800;
        private int x1 = 1440;
        private int y1 = 950;
        private string idnv;

        public CaiDat(string id)
        {
            InitializeComponent();
            LayTen();
            CapNhatNN();
            thongbao.BatThongBao(CoThongBao);
            idnv = id;
            CapNhatTaiKhoan();
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
                List<string> kiemtra = new List<string>();
                dg.Ngongu(kiemtra, cbb_NgonNgu.SelectedItem.ToString());
                if (kiemtra.Count == NN.nn.Count)
                {
                    dg.SaveSetting($"{cbb_NgonNgu.SelectedItem.ToString()}|{NN.folderPathLuong}|{NN.folderPathHoaDon}");
                    ThongBao.Show(NN.nn[2], NN.nn[140], "Cam");

                    cnnn.UpdateDataBase(kiemtra);
                    NN.nn.Clear();
                    System.Windows.Application.Current.Shutdown();
                }
                else
                {
                    cbb_NgonNgu.SelectedItem = NN.NgonNguSetting;
                    ThongBao.Show(NN.nn[2], $"{NN.nn[154]},{kiemtra.Count },{NN.nn.Count }", "Cam");
                }
            }
        }


        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[35]}";
            tbl_LoaiNgonNgu.Text = NN.nn[141];
            tbl_TiLeManHinh.Text = NN.nn[145];
            tbl_FolderPathLuong.Text = NN.nn[184];
            tbl_FolderPathHoaDon.Text = NN.nn[185];
            tb_FolderPathHoaDon.Text = NN.folderPathHoaDon;
            tb_FolderPathLuong.Text = NN.folderPathLuong;
            tbl_doimatkhau.Text = NN.nn[205] ;
        }


        private void cbb_TiLeManHinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_TiLeManHinh.SelectedItem == NN.nn[144])
            {
                RestoreWindow(x, y);
                NN.TileManHinh = cbb_TiLeManHinh.SelectedItem.ToString();
            }
            else if (cbb_TiLeManHinh.SelectedItem == NN.nn[143])
            {
                FullMan();
                NN.TileManHinh = cbb_TiLeManHinh.SelectedItem.ToString();
            }
            else if (cbb_TiLeManHinh.SelectedItem == "1440x950")
            {
                RestoreWindow(x1, y1);
                NN.TileManHinh = cbb_TiLeManHinh.SelectedItem.ToString();
            }
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

        private void tb_FolderPathLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_FolderPathLuong !=  null)
            {
                if (tb_FolderPathLuong.Text.Length > 0 && tb_FolderPathLuong.Text != NN.folderPathLuong)
                {
                    dg.SaveSetting($"{cbb_NgonNgu.SelectedItem.ToString()}|{tb_FolderPathLuong.Text}|{NN.folderPathHoaDon}");
                    dg.Setting();
                }
            }
        }

        private void tb_FolderPathHoaDon_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_FolderPathHoaDon != null)
            {
                if (tb_FolderPathHoaDon.Text.Length > 0 && tb_FolderPathHoaDon.Text != NN.folderPathHoaDon)
                {
                    dg.SaveSetting($"{cbb_NgonNgu.SelectedItem.ToString()}|{NN.folderPathLuong}|{tb_FolderPathHoaDon.Text}");
                    dg.Setting();
                }
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                Mo.OpenWindowWithBlur(mainWindow, new DoiMatKhau(idnv));
                
            }
        }
    }

}
