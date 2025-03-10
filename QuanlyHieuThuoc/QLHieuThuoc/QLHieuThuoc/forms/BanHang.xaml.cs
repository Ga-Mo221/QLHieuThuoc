using QLHieuThuoc.Model;
using QLHieuThuoc.Model.BanHang;
using QLHieuThuoc.Model.DonNhapHangvsNCC;
using QLHieuThuoc.Model.Files;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for BanHang.xaml
    /// </summary>
    public partial class BanHang : UserControl
    {
        Modify modify = new Modify();
        ClickTextBox cl = new ClickTextBox();
        private List<string> ListThang = new List<string> { NN.nn[118], NN.nn[119] };


        public BanHang()
        {
            InitializeComponent();
            Loaded += BanHang_Loaded;
        }

        private void BanHang_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_Thang.ItemsSource = ListThang;
            cbb_Thang.SelectedIndex = 1;
            CapNhatNN();
            string lenhSelect = "select * from DonBan";
            List<Donban> donbans = modify.DonBans(lenhSelect);
            AddDonHang(donbans);

            string lenSelect = "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = MONTH(GETDATE()) AND YEAR(NGAYMUA) = YEAR(GETDATE())";
            tbl_SoLuongDonBanThangNay.Text = modify.DonBans(lenSelect).Count.ToString();

        }


        // Thêm đơn bán mới
        private void bt_ThemDonBan_Click(object sender, RoutedEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            ThemDonBan themDonBan = new ThemDonBan();
            themDonBan.ShowDialog();


            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
            string lenhSelect = "select * from DonBan";
            List<Donban> donbans = modify.DonBans(lenhSelect);
            AddDonHang(donbans);
        }


        private void AddDonHang(List<Donban> donbans)
        {
            if (stb_ListDonBan.Children.Count > 0) stb_ListDonBan.Children.Clear();

            tbl_SoLuongDonHangTrongThang.Text = donbans.Count.ToString();
            tbl_SoLuongTongDonBan.Text = donbans.Count.ToString();

            if (donbans.Count > 0)
            {
                foreach (var s in donbans) 
                {
                    FNhapHang_DonNhapHang hoadon = new FNhapHang_DonNhapHang();
                    hoadon.Height = 46;
                    hoadon.MaDonNhap = s.Id;
                    hoadon.MaNhaCungCap = s.Idkh;
                    hoadon.NgayNhap = s.NgayMua;
                    hoadon.TongTien = s.TongTien;
                    hoadon.PhuongThuc = s.PhuongThuc;
                    if (hoadon.PhuongThuc == NN.nn[120])
                    {
                        hoadon.setcolor("Green");
                    }
                    else
                    {
                        hoadon.setcolor("Red");
                    }
                    stb_ListDonBan.Children.Add(hoadon);
                    hoadon.Click += Hoadon_Click;
                }
            }
        }

        private void Hoadon_Click(object? sender, string e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            List<string> s = new List<string> { e, "BanHang" };
            ChiTietDonBan chiTietDonBan = new ChiTietDonBan(s);
            chiTietDonBan.ShowDialog();

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
        }

        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[29]}";
            tbl_TongSoDonBan.Text = NN.nn[101];
            tbl_DonBanThanNay.Text = NN.nn[102];
            tb_TimKiem.Text = NN.nn[39];
            tbl_title_SoLuongDonHangTrongThang.Text = NN.nn[43];
            tbl_title_IdDonBan.Text = NN.nn[103];
            tbl_title_IdKhachHang.Text = NN.nn[104];
            tbl_title_NgayNhap.Text = NN.nn[82];
            tbl_title_TongTien.Text = NN.nn[83];
            tbl_title_PhuongThuc.Text = NN.nn[84];
        }

        // click textbox tìm kiếm
        private void tb_TimKiem_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_TimKiem, NN.nn[39]);
        }
        private void tb_TimKiem_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_TimKiem, NN.nn[39]);
        }

        private void tb_TimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_TimKiem.Text != NN.nn[39])
            {
                List<Donban> sp = modify.DonBans("select * from DonBan");

                string tuKhoa = tb_TimKiem.Text.Trim().ToLower();

                // Tìm sản phẩm có tên chứa từ khóa
                List<Donban> ketQua = sp.Where(x => x.Id.ToLower().Contains(tuKhoa)).ToList();


                // Xóa tất cả sản phẩm cũ trong stackpanel
                if (tb_TimKiem.Text != NN.nn[39])
                    stb_ListDonBan.Children.Clear();
                //MessageBox.Show("xoa roi");

                // Hiển thị sản phẩm tìm được
                AddDonHang(ketQua);
            }
        }
    }
}
