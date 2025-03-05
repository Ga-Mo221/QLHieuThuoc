using QLHieuThuoc.Model;
using QLHieuThuoc.Model.DonNhapHangvsNCC;
using QLHieuThuoc.Model.SanPham;
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
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for DonNhapHangMoi.xaml
    /// </summary>
    public partial class DonNhapHangMoi : Window
    {
        decimal tongtien = 0;
        string Tongtien;
        Modify modify = new Modify();
        TaoMaNgauNhien TaoMa = new TaoMaNgauNhien();
        bool checkNCC = false;
        private List<string> ListItemPhuongThucThanhToan = new List<string> { "Tien Mat", "Chuyen Khoan", "Phương Thức Thanh Toán"};

        public DonNhapHangMoi()
        {
            InitializeComponent();
            TongTien();
            tbl_IdNhaCungCap.Text = TaoMa.TaoMa();
            tbl_IdDonNhap.Text = TaoMa.TaoMa();

            Loaded += DonNhapHangMoi_Loaded;
        }

        private void DonNhapHangMoi_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_PhuongThucThanhToan.Items.Clear();
            cbb_PhuongThucThanhToan.ItemsSource = ListItemPhuongThucThanhToan;
            cbb_PhuongThucThanhToan.SelectedItem = "Phương Thức Thanh Toán";

            cbb_TenNhaCungCap.ItemsSource = ListTenNhaCungCap();

        }

        private void TongTien()
        {
            Tongtien = $"Tổng Tiền: {tongtien.ToString()}";
            tbl_TongTien.Text = Tongtien ;
        }

        // thoát cửa sổ
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // thêm sản phẩm vào list
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            ThemSanPham themsp = new ThemSanPham("NhapHang");
            themsp.ShowDialog();


            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
            addsanpham();
        }


        private void addsanpham()
        {
            if (stb_ListSanPham.Children.Count > 0)
            {
                stb_ListSanPham.Children.Clear();
            }
            foreach (var sp in listSpDonHang.sps) {
                FNhapHang_SanPham sanpham = new FNhapHang_SanPham {
                    TenSanPham = sp.TenSanPham1,
                    SoLuong = sp.SoLuong1,
                    GiaSanPham = sp.GiaNhap1
                };

                stb_ListSanPham.Children.Add(sanpham);

                // tính tiền
                tongtien = decimal.Parse(sanpham.GiaSanPham) * int.Parse(sanpham.SoLuong);
                TongTien();

                sanpham.Click += Sanpham_Click;
            }
            if (stb_ListSanPham.Children.Count == 0)
            {
                tongtien = 0;
                TongTien();
            }
        }


        // xóa sản phẩm khỏi list sp
        private void Sanpham_Click(object? sender, string e)
        {
            listSpDonHang.sps.RemoveAll(x => x.TenSanPham1 == e);
            addsanpham();
        }

        // thêm đơn nhập hàng mới
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach(var sp in listSpDonHang.sps)
            {
                MessageBox.Show(sp.TenSanPham1);
            }
        }

        // lấy tên nhà cung cấp
        private List<string> ListTenNhaCungCap()
        {
            List<string> listNCCName = new List<string>();

            string lenhtruyvan = "select * from NhaCungCap";
            List<NCC> lisncc = modify.NhaCungCaps(lenhtruyvan);
            foreach (NCC ncc in lisncc)
            {
                listNCCName.Add(ncc.TenNhaCungCap1);
            }
            return listNCCName;
        }


        private void cbb_TenNhaCungCap_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = cbb_TenNhaCungCap.Text.ToLower();
            var result = ListTenNhaCungCap().Where(sp => sp.ToLower().Contains(filter)).ToList();

            cbb_TenNhaCungCap.ItemsSource = result;
            cbb_TenNhaCungCap.IsDropDownOpen = true; // Mở dropdown khi tìm kiếm
        }

        private void cbb_TenNhaCungCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string TenNCC = cbb_TenNhaCungCap.SelectedItem.ToString();
            string CauLenh = "select * from NhaCungCap where TEN = '"+TenNCC+"'";
            List<NCC> lNCC = modify.NhaCungCaps(CauLenh);
            if (lNCC.Count == 1)
            {
                tbl_IdNhaCungCap.Text = lNCC[0].MaNhaCungCap1;
                cbb_TenNhaCungCap.SelectedItem = lNCC[0].TenNhaCungCap1;
                tb_DiaChi.Text = lNCC[0].DiaChi1;
                tb_SDT.Text = lNCC[0].SoDienThoai1;
                checkNCC = true;

                tbl_IdNhaCungCap.IsEnabled = false;
                tb_DiaChi.IsEnabled = false;
                tb_SDT.IsEnabled = false;
            }
        }
    }

    public static class listSpDonHang
    {
        public static List<Sanpham> sps = new List<Sanpham>();
    }
}
