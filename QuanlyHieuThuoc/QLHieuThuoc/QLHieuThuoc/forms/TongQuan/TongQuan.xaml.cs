using QLHieuThuoc.forms.Thongbaos;
using QLHieuThuoc.Model.BanHang;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
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
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for TongQuan.xaml
    /// </summary>
    public partial class TongQuan : UserControl
    {
        Modify modify = new Modify();
        LayThongBao thongbao = new LayThongBao();
        private string idnv;


        public TongQuan(string id)
        {
            InitializeComponent();
            thongbao.BatThongBao(CoThongBao);
            Loaded += TongQuan_Loaded;
            idnv = id;
            
        }

        private void TongQuan_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            DanhThuThangNay();
            KhachHangMoiThangNay();
            LuotMuaThangNay();
            TongDanhThu();
            DonHangMoiNhat();
            SanPhamBanChayNhat();
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

        private void DanhThuThangNay()
        {
            // Lấy tổng doanh thu tháng này
            string lenhSelectThangNay = "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = MONTH(GETDATE()) AND YEAR(NGAYMUA) = YEAR(GETDATE())";
            List<Donban> donbansThangNay = modify.DonBans(lenhSelectThangNay);
            decimal doanhThuThangNay = donbansThangNay.Sum(d => d.TongTien);

            // Lấy tổng doanh thu tháng trước
            string lenhSelectThangTruoc = "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = MONTH(DATEADD(MONTH, -1, GETDATE())) AND YEAR(NGAYMUA) = YEAR(DATEADD(MONTH, -1, GETDATE()))";
            List<Donban> donbansThangTruoc = modify.DonBans(lenhSelectThangTruoc);
            decimal doanhThuThangTruoc = donbansThangTruoc.Sum(d => d.TongTien);

            // Tính tỷ lệ phần trăm tăng/giảm
            decimal tyLeThayDoi = doanhThuThangTruoc == 0 ? 100 : ((doanhThuThangNay - doanhThuThangTruoc) / doanhThuThangTruoc) * 100;

            tbl_TienDanhThu.Text = $"$ {doanhThuThangNay}";
            if (tyLeThayDoi > 0)
            {
                bd_PhanTram1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D0F2CA"));
                tbl_PhanTram1.Text = $"+{tyLeThayDoi:F2}%";
            }
            else
            {
                bd_PhanTram1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9D9"));
                tbl_PhanTram1.Text = $"-{tyLeThayDoi:F2}%";
            }
        }

        private void KhachHangMoiThangNay()
        {
            // Lấy số khách hàng mới trong tháng này
            string lenhSelectThangNay = "SELECT * FROM KhachHang WHERE MONTH(NGAYTHEM) = MONTH(GETDATE()) AND YEAR(NGAYTHEM) = YEAR(GETDATE())";
            List<Khachhang> khachhangsThangNay = modify.KhachHangs(lenhSelectThangNay);
            int soKhachThangNay = khachhangsThangNay.Count;

            // Lấy số khách hàng mới trong tháng trước
            string lenhSelectThangTruoc = "SELECT * FROM KhachHang WHERE MONTH(NGAYTHEM) = MONTH(DATEADD(MONTH, -1, GETDATE())) AND YEAR(NGAYTHEM) = YEAR(DATEADD(MONTH, -1, GETDATE()))";
            List<Khachhang> khachhangsThangTruoc = modify.KhachHangs(lenhSelectThangTruoc);
            int soKhachThangTruoc = khachhangsThangTruoc.Count;

            // Tính tỷ lệ phần trăm thay đổi
            decimal tyLeThayDoi = soKhachThangTruoc == 0 ? 100 : ((decimal)(soKhachThangNay - soKhachThangTruoc) / soKhachThangTruoc) * 100;

            // Hiển thị số khách hàng mới tháng này
            tbl_LuongKhachHangMoi.Text = soKhachThangNay.ToString();

            // Hiển thị tỷ lệ phần trăm và đổi màu
            if (tyLeThayDoi > 0)
            {
                tbl_PhanTram2.Text = $"+{tyLeThayDoi:F2}%";
                bd_PhanTram2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D0F2CA")); // WPF
            }
            else
            {
                tbl_PhanTram2.Text = $"{tyLeThayDoi:F2}%";
                bd_PhanTram2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9D9")); // WPF
            }
        }

        private void LuotMuaThangNay()
        {
            // Lấy số lượt mua trong tháng này
            string lenhSelectThangNay = "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = MONTH(GETDATE()) AND YEAR(NGAYMUA) = YEAR(GETDATE())";
            List<Donban> donbansThangNay = modify.DonBans(lenhSelectThangNay);
            int soLuotMuaThangNay = donbansThangNay.Count;

            // Lấy số lượt mua trong tháng trước
            string lenhSelectThangTruoc = "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = MONTH(DATEADD(MONTH, -1, GETDATE())) AND YEAR(NGAYMUA) = YEAR(DATEADD(MONTH, -1, GETDATE()))";
            List<Donban> donbansThangTruoc = modify.DonBans(lenhSelectThangTruoc);
            int soLuotMuaThangTruoc = donbansThangTruoc.Count;

            // Tính tỷ lệ phần trăm thay đổi
            decimal tyLeThayDoi = soLuotMuaThangTruoc == 0 ? 100 : ((decimal)(soLuotMuaThangNay - soLuotMuaThangTruoc) / soLuotMuaThangTruoc) * 100;

            // Hiển thị số lượt mua tháng này
            tbl_LuongLuotMua.Text = soLuotMuaThangNay.ToString();

            // Hiển thị tỷ lệ phần trăm và đổi màu
            if (tyLeThayDoi > 0)
            {
                tbl_PhanTram3.Text = $"+{tyLeThayDoi:F2}%";
                bd_PhanTram3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D0F2CA")); // WPF
            }
            else
            {
                tbl_PhanTram3.Text = $"{tyLeThayDoi:F2}%";
                bd_PhanTram3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9D9")); // WPF
            }
        }

        private void TongDanhThu()
        {
            List<string> lenh = new List<string> {
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '1' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '2' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '3' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '4' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '5' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '6' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '7' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '8' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '9' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '10' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '11' AND YEAR(NGAYMUA) = YEAR(GETDATE())",
                "SELECT * FROM DonBan WHERE MONTH(NGAYMUA) = '12' AND YEAR(NGAYMUA) = YEAR(GETDATE())"
            };

            List<Border> borders = new List<Border> {
                Thang1,
                Thang2,
                Thang3,
                Thang4,
                Thang5,
                Thang6,
                Thang7,
                Thang8,
                Thang9,
                Thang10,
                Thang11,
                Thang12 
            };

            for (int i = 0; i < 12; i++)
            {
                decimal giatri = 0;
                List<Donban> donbans = modify.DonBans(lenh[i]);
                foreach (var d in donbans)
                {
                    giatri += d.TongTien;
                }
                if (giatri == 0)
                {
                    borders[i].Height = 10;
                }
                else
                {
                    double phantram = (double)giatri / 30000000 * 100;
                    double chieucao = phantram / 100 * (int)gr.ActualHeight;
                    if (borders[i].ActualHeight > borders[i].ActualWidth + 10)
                    {
                        borders[i].CornerRadius = new CornerRadius(borders[i].ActualWidth/2);
                    }
                    borders[i].Height = 10+chieucao;
                }
            }
        }

        private void DonHangMoiNhat()
        {
            string lenh = "SELECT TOP 3 * FROM DonBan ORDER BY NGAYMUA DESC, TONGTIEN DESC";
            List<Donban> donbans = modify.DonBans(lenh);
            foreach (var d in donbans)
            {
                FNhapHang_DonNhapHang donban = new FNhapHang_DonNhapHang();
                donban.Height = 46;
                donban.MaDonNhap = d.Id;
                donban.MaNhaCungCap = d.Idkh;
                donban.NgayNhap = d.NgayMua;
                donban.TongTien = d.TongTien;
                donban.PhuongThuc = d.PhuongThuc;
                stb_lisdonban.Children.Add(donban);
            }
        }

        private void SanPhamBanChayNhat()
        {
            int stt = 1;
            string lenh = "SELECT TOP 3  MIN(ID) AS ID, MIN(IDDB) AS IDDB, IDSP, SUM(SOLUONG) AS TongSoLuongBan, AVG(GIABAN) AS GiaBan FROM ChiTietDonBan GROUP BY IDSP ORDER BY TongSoLuongBan DESC";
            List<Chitietdonban> sanphams = modify.ChiTietDonBans(lenh);
            foreach(var d in sanphams)
            {
                string select = "select * from SanPham where ID = '" + d.Idsp + "'";
                switch (stt) {
                    case 1:
                        stt += 1;
                        tbl_TenThuoc1.Text = modify.SanPhams(select)[0].TenSanPham1;
                        break;
                    case 2:
                        stt += 1;
                        tbl_TenThuoc2.Text = modify.SanPhams(select)[0].TenSanPham1;
                        break;
                    case 3:
                        stt += 1;
                        tbl_TenThuoc3.Text = modify.SanPhams(select)[0].TenSanPham1;
                        break;
                }
            }
        }

        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[27]}";
            tbl_DanhThu.Text = NN.nn[146];
            tbl_KhachHangMoi.Text = NN.nn[116];
            tbl_LuotMua.Text = NN.nn[147];
            tbl_ThangNay1.Text = NN.nn[119];
            tbl_ThangNay2.Text = NN.nn[119];
            tbl_ThangNay3.Text = NN.nn[119];
            tbl_TongDanhThu.Text = NN.nn[148];
            tbl_DonHangMoiNhat.Text = NN.nn[149];
            tbl_ThuocBanChayNhat.Text = NN.nn[150];
            tbl_Id.Text = NN.nn[193];
            tbl_Idkh.Text = NN.nn[104];
            tbl_NgayMua.Text = NN.nn[209];
            tbl_TongTien.Text = NN.nn[83];
            tbl_ThanhToan.Text = NN.nn[96];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThongBaoSanPham.status = false;
            CoThongBao.Visibility = Visibility.Collapsed;
            ThanhThongBaoSanPham thanhthongbao = new ThanhThongBaoSanPham();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                thanhthongbao.Left = parentWindow.Left + (parentWindow.Width - thanhthongbao.Width)/1.17;
                thanhthongbao.Top = parentWindow.Top + 110;
            }
            thanhthongbao.Show();
        }
    }
}
