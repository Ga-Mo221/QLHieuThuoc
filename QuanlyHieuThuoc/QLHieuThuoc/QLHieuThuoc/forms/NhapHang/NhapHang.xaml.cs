using QLHieuThuoc.forms.Thongbaos;
using QLHieuThuoc.Model.BanHang;
using QLHieuThuoc.Model.DonNhapHangvsNCC;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
using QLHieuThuoc.Model.sql;
using QLHieuThuoc.UserControls;
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
    /// Interaction logic for NhapHang.xaml
    /// </summary>
    public partial class NhapHang : UserControl
    {
        ClickTextBox clickk = new ClickTextBox();
        LayThongBao thongbao = new LayThongBao();
        Modify modify = new Modify();
        private string idnv;
        private List<string> ListThang = new List<string> { NN.nn[118], NN.nn[119] };


        public NhapHang(string id)
        {
            InitializeComponent();
            idnv = id;

            tbl_SoLuongNhaCungCap.Text = SoLuongNhaCungCap();
            CapNhatTongDonNhap();
            cbb_Thang.ItemsSource = ListThang;
            thongbao.BatThongBao(CoThongBao);
            Loaded += NhapHang_Loaded;
        }

        // set ngôn ngữ
        private void NhapHang_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_Thang.SelectedItem = NN.nn[119];
            CapNhatNN();
            string lenhSelect = "select * from DonNhapHang";

            List<DonNhap> ls = modify.DonNhaps(lenhSelect);
            AddDonNhap(ls);

            string lenSelect = "SELECT * FROM DonNhapHang WHERE MONTH(NGAYNHAP) = MONTH(GETDATE()) AND YEAR(NGAYNHAP) = YEAR(GETDATE())";
            tbl_SoLuongDonHangTrongThang.Text = modify.DonNhaps(lenSelect).Count.ToString();
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

        // Cập nhật Tổng đơn Nhập
        private void CapNhatTongDonNhap()
        {
            string caulenh = "select * from DonNhapHang";

            tbl_SoLuongDonNhap.Text = modify.DonNhaps(caulenh).Count.ToString();
        }

        // Cập nhật số lượng nhà cung cấp
        private string SoLuongNhaCungCap()
        {
            string caulenh = "select * from NhaCungCap";
            string sl = modify.NhaCungCaps(caulenh).Count.ToString();
            return sl;
        }

        // Thêm Đơn nhập mới
        private void bt_ThemDonNhap_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                Mo.OpenWindowWithBlur(mainWindow, new DonNhapHangMoi());
            }

            string lenhSelect = "select * from DonNhapHang";
            List<DonNhap> ls = modify.DonNhaps(lenhSelect);
            AddDonNhap(ls);
            CapNhatTongDonNhap();
            SoLuongNhaCungCap();

            int cu = ThongBaoSanPham.ThongBao.Count;
            thongbao.LayThongTin();
            if (cu < ThongBaoSanPham.ThongBao.Count)
            {
                ThongBaoSanPham.status = true;
            }
        }

        // button mở danh sách nhà cung cấp
        private void bt_NhaCungCap_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                Mo.OpenWindowWithBlur(mainWindow, new NhaCungCap());
            }
        }

        // Cập nhật đơn nhập
        private void AddDonNhap(List<DonNhap> ls)
        {
            if (stb_ListDonNhap != null)
            {
                if (stb_ListDonNhap.Children.Count > 0) stb_ListDonNhap.Children.Clear();
            }

            foreach (DonNhap d in ls)
            {
                FNhapHang_DonNhapHang donnhap = new FNhapHang_DonNhapHang();
                donnhap.Height = 50;
                donnhap.MaDonNhap = d.MaDonNhapHang1;
                donnhap.MaNhaCungCap = d.MaNhaCungCap1;
                donnhap.NgayNhap = d.NhayNhap1;
                donnhap.TongTien = decimal.Parse(d.TongTien1);
                donnhap.PhuongThuc = d.PhuongThucThanhToan1;

                if (donnhap.PhuongThuc == NN.nn[120])
                {
                    donnhap.setcolor("Green");
                }
                else
                {
                    donnhap.setcolor("Red");
                }
                stb_ListDonNhap.Children.Add(donnhap);
                donnhap.Click += Donnhap_Click;
            }
        }

        private void Donnhap_Click(object? sender, string e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                Mo.OpenWindowWithBlur(mainWindow, new ChiTietDonNhap(e, "NhapHang"));
            }
        }

        // lấy ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[30]}";
            tbl_NhaCungCap.Text = NN.nn[78];
            tbl_TongDonNhap.Text = NN.nn[79];
            tb_TimKiem.Text = NN.nn[39];
            tbl_title_SoLuongDonHangTrongThang.Text = NN.nn[43];
            tbl_title_IdDonNhap.Text = NN.nn[80];
            tbl_title_IdNhaCungCap.Text = NN.nn[81];
            tbl_title_NgayNhap.Text = NN.nn[82];
            tbl_title_TongTien.Text = NN.nn[83];
            tbl_title_PhuongThuc.Text = NN.nn[84];
        }


        private void tb_TimKiem_GotFocus(object sender, RoutedEventArgs e)
        {
            clickk.GotF(tb_TimKiem, NN.nn[39]);
        }
        private void tb_TimKiem_LostFocus(object sender, RoutedEventArgs e)
        {
            clickk.LostF(tb_TimKiem, NN.nn[39]);
        }

        private void tb_TimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_TimKiem.Text != NN.nn[39])
            {
                List<DonNhap> sp = modify.DonNhaps("select * from DonNhapHang");

                string tuKhoa = tb_TimKiem.Text.Trim().ToLower();

                // Tìm sản phẩm có tên chứa từ khóa
                List<DonNhap> ketQua = sp.Where(x => x.MaDonNhapHang1.ToLower().Contains(tuKhoa)).ToList();


                // Xóa tất cả sản phẩm cũ trong stackpanel
                if (stb_ListDonNhap != null)
                {
                    if (tb_TimKiem.Text != NN.nn[39])
                        stb_ListDonNhap.Children.Clear();
                    //MessageBox.Show("xoa roi");
                }
                // Hiển thị sản phẩm tìm được
                AddDonNhap(ketQua);
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
    }
}
