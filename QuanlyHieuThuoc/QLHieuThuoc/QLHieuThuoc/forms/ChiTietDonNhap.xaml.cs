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
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for ChiTietDonNhap.xaml
    /// </summary>
    public partial class ChiTietDonNhap : Window
    {
        Modify modify = new Modify();
        private string Id;
        public ChiTietDonNhap(string IdDonNhap)
        {
            InitializeComponent();
            Loaded += ChiTietDonNhap_Loaded;
            Id = IdDonNhap;
        }

        private void ChiTietDonNhap_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            CapNhatDonNhap();
        }

        // nút thoát
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        // cập nhật thông tin đơn nhập và nhà cung cấp
        private void CapNhatDonNhap()
        {
            string caulenh = "select * from DonNhapHang where ID = '"+Id+"'";
            List<DonNhap> ls = modify.DonNhaps(caulenh);

            if (ls.Count == 1)
            {
                tbl_MaDonNhap.Text = $"{NN.nn[95]} : {ls[0].MaDonNhapHang1}";
                tbl_TongTien.Text = $"{NN.nn[83]} : {ls[0].TongTien1}";
                tbl_NgayNhap.Text = $"{NN.nn[82]} : {ls[0].NhayNhap1.ToString("dd/MM/yyyy")}";
                tbl_PhuongThucThanhToan.Text = $"{NN.nn[96]} : {ls[0].PhuongThucThanhToan1}";

                string caulenhNCC = "select * from NhaCungCap where ID = '" + ls[0].MaNhaCungCap1 +"'";

                List<NCC> lncc = modify.NhaCungCaps(caulenhNCC);
                if (lncc.Count == 1)
                {
                    tbl_MaNhaCungCap.Text = $"{NN.nn[95]} : {lncc[0].MaNhaCungCap1}";
                    tbl_TenNhaCungCap.Text = $"{NN.nn[98]} : {lncc[0].TenNhaCungCap1}";
                    tbl_SDT.Text = $"{NN.nn[99]} : {lncc[0].SoDienThoai1}";
                    tbl_DiaChi.Text = $"{NN.nn[86]} : {lncc[0].DiaChi1}";

                    AddSanPham();
                }
            }
        }


        // lập danh sách các mã chi tiết đơn nhập
        private List<chiTietDonNhap> DanhSachMaChiTietDonNhap()
        {
            List<chiTietDonNhap> lctdn = new List<chiTietDonNhap>();

            string caulenh = "select * from ChiTietDonNhap where IDDNH = '"+Id+"'";
            lctdn = modify.ChiTietDonNhaps(caulenh);
            tbl_SoLuongLoaiSanPham.Text = $"{NN.nn[100]} : {lctdn.Count.ToString()}";

            return lctdn;
        }


        // danh sách sản phẩm trong chi tiết đơn nhập
        private List<ChiTietSanPhamNhapHang> DanhsachSanPham()
        {
            List<ChiTietSanPhamNhapHang> ls = new List<ChiTietSanPhamNhapHang> ();

            List<chiTietDonNhap> lctdn = DanhSachMaChiTietDonNhap();
            foreach (var s in lctdn)
            {
                ChiTietSanPhamNhapHang con = new ChiTietSanPhamNhapHang();
                con.Gianhap = s.GiaNhap;
                con.Soluong = s.Soluong;
                string caulenh = "select * from SanPham where ID = '"+s.MaSanPham+"'";
                List<Sanpham> lsp = modify.SanPhams(caulenh);
                if (lsp.Count == 1)
                {
                    con.TenSanPham = lsp[0].TenSanPham1;
                }

                ls.Add(con);
            }

            return ls;
        }


        // thêm vào list sản phẩm
        private void AddSanPham()
        {
            if (stb_ListSanPham.Children.Count > 0) stb_ListSanPham.Children.Clear ();

            List<ChiTietSanPhamNhapHang> Ds = DanhsachSanPham();

            foreach (var s in Ds)
            {
                FNhapHang_SanPhamChiTiet sp = new FNhapHang_SanPhamChiTiet();
                sp.TenSanPham = s.TenSanPham;
                sp.SoLuong = s.Soluong;
                sp.Gia = s.Gianhap;

                stb_ListSanPham.Children.Add(sp);
            }
        }

        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TieuDe.Text = NN.nn[93];
            tbl_ThongTinDonNhap.Text = NN.nn[94];
            tbl_ThongTinNhaCungCap.Text = NN.nn[97];
            tbl_TenSanPham.Text = NN.nn[42];
            tbl_SoLuong.Text = NN.nn[43];
            tbl_Gia.Text = NN.nn[56];
        }
    }

    public class ChiTietSanPhamNhapHang
    {
        private string tenSanPham;
        private string soluong;
        private string gianhap;

        public ChiTietSanPhamNhapHang()
        {
        }

        public ChiTietSanPhamNhapHang(string tenSanPham, string soluong, string gianhap)
        {
            this.tenSanPham = tenSanPham;
            this.soluong = soluong;
            this.gianhap = gianhap;
        }

        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string Soluong { get => soluong; set => soluong = value; }
        public string Gianhap { get => gianhap; set => gianhap = value; }
    }
}
