using QLHieuThuoc.Model.BanHang;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.sql;
using QLHieuThuoc.UserControls.HoaDonDonBan;
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

namespace QLHieuThuoc.forms.DonBanHang
{
    /// <summary>
    /// Interaction logic for HoaDon.xaml
    /// </summary>
    public partial class HoaDon : Window
    {
        Modify modify = new Modify();
        private string idhd;



        public HoaDon(string id)
        {
            InitializeComponent();
            Loaded += HoaDon_Loaded;
            idhd = id;
            MessageBox.Show(idhd);
            LayThongTinHoaDon();
            AddSanPham();
        }

        private void HoaDon_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LuuAnh xuatanh = new LuuAnh();
            string filename = $"{idhd}_{DateTime.Now.Day}D_{DateTime.Now.Month}M_{DateTime.Now.Year}Y_{DateTime.Now.Hour}H_{DateTime.Now.Minute}m";

            xuatanh.SaveGridAsImage(border_HoaDon, filename, NN.folderPathHoaDon);
            this.Close();
        }


        private void LayThongTinHoaDon()
        {
            string query = @"
            SELECT 
                d.ID AS MaHoaDon,
                d.NGAYMUA,
                nv.TEN AS TenNhanVien,
                kh.TEN AS TenKhachHang,
                d.TONGTIEN
            FROM DonBan d
            LEFT JOIN NhanVien nv ON d.IDNV = nv.ID
            LEFT JOIN KhachHang kh ON d.IDKH = kh.ID
            WHERE d.ID = '"+idhd+"'";

            List<ThongTinHoaDon> tthd = modify.ThongTinHoaDons(query);
            ThongTinHoaDon thongTinHoaDon = tthd[0];

            tbl_NgayMua.Text = $"{NN.nn[191]} : {thongTinHoaDon.NgayMua.ToString("dd/MM/yyyy")}";
            tbl_ThuNgan.Text = $"{NN.nn[192]} : {thongTinHoaDon.TenNV}";
            tbl_MaHoaDon.Text = $"{NN.nn[193]} : {thongTinHoaDon.Idhd}";
            tbl_TenKhachHang.Text = $"{NN.nn[111]} : {thongTinHoaDon.TenKH}";
            tbl_TongTien.Text = $"{NN.nn[194]} : {thongTinHoaDon.TongTien}VND";
        }


        private void AddSanPham()
        {
            string query = @"
            SELECT 
                sp.TEN AS TenSanPham,
                ctdb.SOLUONG AS SoLuong,
                ctdb.GIABAN AS GiaBan
            FROM ChiTietDonBan ctdb
            JOIN SanPham sp ON ctdb.IDSP = sp.ID
            WHERE ctdb.IDDB = '"+idhd+"'";

            List<ThongTinSanPhamHoaDon> ttsphd = modify.ThongTinSPHDs(query);
            foreach(var i  in ttsphd)
            {
                ThanhSanPhamHoaDon sp = new ThanhSanPhamHoaDon();
                sp.Height = 30;
                sp.Ten = i.Tensp;
                sp.SoLuong = i.SoLuong;
                sp.Gia = i.GiaBan;
                sp.ThanhTien();

                stb_listSanPham.Children.Add(sp);
            }
        }




        // Cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = NN.nn[186];
            tbl_bt_Khong.Text = NN.nn[187];
            tbl_bt_xuat.Text = NN.nn[188];

            tbl_HoaDonTamTinh.Text = NN.nn[189];
            tbl_TenSanPham.Text = NN.nn[42];
            tbl_SoLuong.Text = NN.nn[43];
            tbl_DonGia.Text = NN.nn[44];
            tbl_ThanhTien.Text = NN.nn[190];
        }
    }
}
