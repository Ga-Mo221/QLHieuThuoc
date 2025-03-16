using QLHieuThuoc.forms.NhanVien;
using QLHieuThuoc.Model.ChamCong;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Modify modify = new Modify();
        ChamCong chamCong = new ChamCong();
        CheckAccount checkAccount = new CheckAccount();
        LayThongBao thongbao = new LayThongBao();
        TaoMaNgauNhien taoma = new TaoMaNgauNhien();
        private string IdNv;
        UserControl child = null;
        private int x = 1240;
        private int y = 800;

        public MainWindow(string id)
        {
            InitializeComponent();
            IdNv = id;

            this.Width = x; this.Height = y;

            this.Loaded += MainWindow_Loaded;
            thongbao.LayThongTin();
            thongbao.KiemTraThongBao();
            KiemTraQuyenTruyCap();
            chamCong.GioVao();
        }

        




        // kiểm tra quyền truy cập
        private void KiemTraQuyenTruyCap()
        {
            if (checkAccount.check(IdNv))
            {
                bt_ThongKe.Visibility = Visibility.Collapsed;
                bt_TongQuan.Visibility = Visibility.Collapsed;
            }
        }

        // cập nhật ngôn ngữ
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();

            if (checkAccount.check(IdNv))
            {
                CheckSelectButton("SanPham");
                Mo(grid_NoiDung, child, new SanPham(IdNv));
            }
            else
            {
                CheckSelectButton("TongQuan");
                Mo(grid_NoiDung, child, new TongQuan(IdNv));
            }

            CapNhatLuongChoNhanVien();
        }

        // lấy ngôn ngữ
        private void CapNhatNN()
        {
            tbl_bt_TongQuan.Text =  $"📊  {NN.nn[27]}";
            tbl_bt_SanPham.Text =   $"📦   {NN.nn[28]}";
            tbl_bt_BanHang.Text =   $"🛒   {NN.nn[29]}";
            tbl_bt_NhapHang.Text =  $"📥  {NN.nn[30]}";
            tbl_bt_ThongKe.Text =   $"📈   {NN.nn[31]}";
            tbl_bt_KhachHang.Text = $"👥  {NN.nn[32]}";
            tbl_bt_NhanVien.Text =  $"👨‍💼   {NN.nn[33]}";
            tbl_bt_CaiDat.Text =    $"⚙️    {NN.nn[34]}";
            tbl_bt_DangXuat.Text =  $"🔚  {NN.nn[35]}";
        }

        // check select button
        private void CheckSelectButton(string name)
        {
            switch (name)
            {
                case "TongQuan":
                    ThayDoiMauSacButtonKhiClick(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "SanPham":
                    ThayDoiMauSacButtonKhiClick(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "BanHang":
                    ThayDoiMauSacButtonKhiClick(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "NhapHang":
                    ThayDoiMauSacButtonKhiClick(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "ThongKe":
                    ThayDoiMauSacButtonKhiClick(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "KhachHang":
                    ThayDoiMauSacButtonKhiClick(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "NhanVien":
                    ThayDoiMauSacButtonKhiClick(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "CaiDat":
                    ThayDoiMauSacButtonKhiClick(bt_CaiDat, tbl_bt_CaiDat);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_DangXuat, tbl_bt_DangXuat);
                    break;
                case "DangXuat":
                    ThayDoiMauSacButtonKhiClick(bt_DangXuat, tbl_bt_DangXuat);
                    QuayLaiMauSacBanDau(bt_TongQuan, tbl_bt_TongQuan);
                    QuayLaiMauSacBanDau(bt_SanPham, tbl_bt_SanPham);
                    QuayLaiMauSacBanDau(bt_BanHang, tbl_bt_BanHang);
                    QuayLaiMauSacBanDau(bt_NhapHang, tbl_bt_NhapHang);
                    QuayLaiMauSacBanDau(bt_ThongKe, tbl_bt_ThongKe);
                    QuayLaiMauSacBanDau(bt_KhachHang, tbl_bt_KhachHang);
                    QuayLaiMauSacBanDau(bt_NhanVien, tbl_bt_NhanVien);
                    QuayLaiMauSacBanDau(bt_CaiDat, tbl_bt_CaiDat);
                    break;
            }
        }


        // thay đổi màu sắc khi click button
        private void ThayDoiMauSacButtonKhiClick(Button button, TextBlock tbl)
        {
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCF4F0"));
            tbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#565656"));
        }


        // Quay lại màu sắc ban đầu
        private void QuayLaiMauSacBanDau(Button button, TextBlock tbl)
        {
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2895A"));
            tbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FCF4F0"));
        }



        // Click button
        // Tổng quan
        private void bt_TongQuan_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("TongQuan");

            Mo(grid_NoiDung, child, new TongQuan(IdNv));
        }

        // Sản phẩm
        private void bt_SanPham_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("SanPham");

            Mo(grid_NoiDung, child, new SanPham(IdNv));
        }

        // Bán hàng
        private void bt_BanHang_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("BanHang");

            Mo(grid_NoiDung, child, new BanHang(IdNv));
        }

        // Nhập hàng
        private void bt_NhapHang_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("NhapHang");

            Mo(grid_NoiDung, child, new NhapHang(IdNv));
        }

        // Thống kê
        private void bt_ThongKe_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("ThongKe");

            Mo(grid_NoiDung, child, new ThongKe(IdNv));
        }

        // Khách hàng
        private void bt_KhachHang_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("KhachHang");

            Mo(grid_NoiDung, child, new KhachHang(IdNv));
        }

        // Nhân viên
        private void bt_NhanVien_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("NhanVien");

            Mo(grid_NoiDung, child, new NhanVien.NhanVien(IdNv));
        }

        // Cài đặt
        private void bt_CaiDat_Click(object sender, RoutedEventArgs e)
        {
            CheckSelectButton("CaiDat");

            Mo(grid_NoiDung, child, new QLHieuThuoc.forms.CaiDat.CaiDat(IdNv));
        }

        // Đăng xuất
        private void bt_DangXuat_Click(object sender, RoutedEventArgs e)
        {
            chamCong.GioRa();
            chamCong.ChapCong(IdNv);
            CheckSelectButton("DangXuat");
            this.Close();
            DangNhap DangNhapCuaSo = new DangNhap();
            DangNhapCuaSo.ShowDialog();
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


        private void CapNhatLuongChoNhanVien()
        {
            string lenh = "select * from NhanVien";
            List<nhanVien> nhanViens = modify.NhanViens(lenh);

            foreach (var nhanVien in nhanViens)
            {
                string idnv = nhanVien.IdNhanVien1;

                lenh = "select * from Luong where IDNV = '" + idnv + "' and THANG = month(getdate()) and NAM = year(getdate())";
                List<BangLuong> Luongs = modify.Luongs(lenh);

                if (Luongs.Count == 0)
                {
                    lenh = "insert into Luong values ('"+taoma.TaoMa()+"', '"+idnv+"', "+DateTime.Now.Month+", "+DateTime.Now.Year+ ", CAST(GETDATE() AS DATE), 0, 0, 0, 0)";
                    modify.ThucThi(lenh);

                }
                else
                {
                    // Tính tổng số giờ làm trong tháng
                    lenh = "SELECT ISNULL(SUM(TONGGIOLAM), 0) FROM ThoiGianLam WHERE IDNV = '" + idnv + "' AND MONTH(NGAYLAM) = MONTH(GETDATE()) AND YEAR(NGAYLAM) = YEAR(GETDATE())";
                    decimal tongGioLam = Convert.ToDecimal(modify.LayGiaTri(lenh));

                    // Lương = tổng giờ làm * 40.000 VNĐ
                    decimal luong = tongGioLam * 40000;


                    // Cập nhật lại bảng lương
                    lenh = "UPDATE Luong SET SONGIOLAM = " + tongGioLam + ", LUONG = " + luong + " WHERE IDNV = '" + idnv + "' AND THANG = MONTH(GETDATE()) AND NAM = YEAR(GETDATE())";
                    modify.ThucThi(lenh);
                }
            }

        }


    }
}
