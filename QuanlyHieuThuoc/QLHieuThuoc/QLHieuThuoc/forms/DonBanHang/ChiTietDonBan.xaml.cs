using QLHieuThuoc.Model.BanHang;
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
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for ChiTietDonBan.xaml
    /// </summary>
    public partial class ChiTietDonBan : Window
    {
        Modify modify = new Modify();
        private string Tenbang;
        private string iddb;


        public ChiTietDonBan(List<string> thongtin)
        {
            InitializeComponent();
            iddb = thongtin[0];
            Tenbang = thongtin[1];
            if (Tenbang == "BanHang")
            {
                bt_XacNhanThanhToan.Visibility = Visibility.Collapsed;
            }
            Loaded += ChiTietDonBan_Loaded;
        }

        private void ChiTietDonBan_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            if (Tenbang == "BanHang")
            {
                CapNhatThongTinDonHang();
            }
            else
            {
                CapNhatThongTinDonHang(XacNhan.hd);
                CapNhatKhachHang(XacNhan.kh);
                AddSanPhamMuaHang();
            }
        }


        // chi tiết hóa đơn
        private void CapNhatThongTinDonHang()
        {
            string lenhSelect = "select * from DonBan where ID = '"+iddb+"'";
            List<Donban> hoadon = modify.DonBans(lenhSelect);
            if (hoadon.Count > 0)
            {
                tbl_MaDonBan.Text = $"{NN.nn[95]} : {hoadon[0].Id}";
                tbl_TongTien.Text = $"{NN.nn[83]} : {hoadon[0].TongTien}";
                tbl_NgayBan.Text = $"{NN.nn[114]} : {hoadon[0].NgayMua}";
                tbl_PhuongThucThanhToan.Text = $"{NN.nn[84]} : {hoadon[0].PhuongThuc}";
                string lenh = "select * from NhanVien where ID = '" + hoadon[0].Idnv + "'";
                List<nhanVien> nv = modify.NhanViens(lenh);
                tbl_ThuNgan.Text = $"{NN.nn[192]} : {nv[0].Ten1}";
                CapNhatKhachHang(hoadon[0].Idkh);
                AddSanPhamMuaHang(iddb);
            }
        }

        private void CapNhatKhachHang(string id)
        {
            string lenhSelect = "select * from KhachHang where ID = '"+id+"'";
            List<Khachhang> kh = modify.KhachHangs(lenhSelect);
            if (kh.Count > 0)
            {
                tbl_MaKhachHang.Text = $"{NN.nn[95]} : {kh[0].Id}";
                tbl_SDT.Text = $"{NN.nn[99]} : {kh[0].Sdt}";
                tbl_TenKhachHang.Text = $"{NN.nn[98]} : {kh[0].Ten}";
                tbl_Diem.Text = $"{NN.nn[106]} : {kh[0].Diem}";
            }
        }

        private void AddSanPhamMuaHang(string id)
        {
            string lenhSelect = "select * from ChiTietDonBan where IDDB = '" + id + "'";
            List<Chitietdonban> chitietdonbans = modify.ChiTietDonBans(lenhSelect);
            tbl_SoLuongSanPham.Text = $"{NN.nn[100]} : {chitietdonbans.Count.ToString()}";
            foreach (var ct in chitietdonbans) {
                string lenhSelect2 = "select * from SanPham where ID = '" + ct.Idsp+"'";
                string ten = modify.SanPhams(lenhSelect2)[0].TenSanPham1;


                FNhapHang_SanPhamChiTiet ctsp = new FNhapHang_SanPhamChiTiet();
                ctsp.TenSanPham = ten;
                ctsp.SoLuong = ct.SoLuong.ToString();
                ctsp.Gia = ct.GiaBan.ToString();

                stb_ListSanPham.Children.Add(ctsp);
                
            } 
        }


        // tạo hóa đơn
        private void CapNhatThongTinDonHang(Donban hoadon)
        {
            tbl_MaDonBan.Text = $"{NN.nn[95]} : {hoadon.Id}";
            tbl_TongTien.Text = $"{NN.nn[83]} : {hoadon.TongTien}";
            tbl_NgayBan.Text = $"{NN.nn[114]} : {hoadon.NgayMua}";
            tbl_PhuongThucThanhToan.Text = $"{NN.nn[84]} : {hoadon.PhuongThuc}";
            string lenh = "select * from NhanVien where ID = '" + hoadon.Idnv + "'";
            List<nhanVien> nv = modify.NhanViens(lenh);
            tbl_ThuNgan.Text = $"{NN.nn[192]} : {nv[0].Ten1}";
        }

        private void CapNhatKhachHang(Khachhang kh)
        {
            tbl_MaKhachHang.Text = $"{NN.nn[95]} : {kh.Id}";
            tbl_SDT.Text = $"{NN.nn[99]} : {kh.Sdt}";
            tbl_TenKhachHang.Text = $"{NN.nn[98]} : {kh.Ten}";
            tbl_Diem.Text = $"{NN.nn[106]} : {kh.Diem}";
        }

        private void AddSanPhamMuaHang()
        {
            foreach (var i in lspmua.listspmua)
            {
                FNhapHang_SanPhamChiTiet s = new FNhapHang_SanPhamChiTiet();
                s.TenSanPham = i.Ten;
                s.SoLuong = i.Soluong.ToString();
                s.Gia = i.Giaban.ToString();

                tbl_SoLuongSanPham.Text = $"{NN.nn[100]} : {lspmua.listspmua.Count.ToString()}";

                stb_ListSanPham.Children.Add(s);
            }
        }

        // thoat
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CapNhatNN()
        {
            tbl_TieuDe.Text = NN.nn[93];
            tbl_ThongTinDonBan.Text = NN.nn[94];
            tbl_ThongTinKhachHang.Text = NN.nn[113];
            tbl_TenSanPham.Text = NN.nn[42];
            tbl_SoLuong.Text = NN.nn[43];
            tbl_Gia.Text = NN.nn[44];
        }

        // xác nhận thanh toán
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XacNhan.YN = true;
            this.Close();
        }
    }
}
