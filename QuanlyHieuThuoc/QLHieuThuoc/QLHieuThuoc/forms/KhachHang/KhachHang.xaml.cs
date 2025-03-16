using QLHieuThuoc.forms.Thongbaos;
using QLHieuThuoc.Model.BanHang;
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
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class KhachHang : UserControl
    {

        Modify modify = new Modify();
        ClickTextBox cl = new ClickTextBox();
        LayThongBao thongbao = new LayThongBao();
        private string idnv;


        public KhachHang(string id)
        {
            InitializeComponent();
            Loaded += KhachHang_Loaded;
            thongbao.BatThongBao(CoThongBao);
            idnv = id;
        }

        private void KhachHang_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            CapNhatTongKhachHang();
            CapNhatKhachHangMoi();

            string lenhSelect = "select * from KhachHang";
            AddKhachHang(modify.KhachHangs(lenhSelect));
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

        // cập nhật tông số khách hàng
        private void CapNhatTongKhachHang()
        {
            string lenhSelect = "select * from KhachHang";
            tbl_TongKhachHang.Text = modify.KhachHangs(lenhSelect).Count.ToString();
        }

        // cập nhật số lượng khách hàng mới
        private void CapNhatKhachHangMoi()
        {
            string lenhSelect = "select * from KhachHang where MONTH(NGAYTHEM) = MONTH(GETDATE()) AND YEAR(NGAYTHEM) = YEAR(GETDATE())";
            tbl_KhachHangMoi.Text = modify.KhachHangs(lenhSelect).Count.ToString();
        }

        // tìm kiếm
        private void tb_TimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_TimKiem.Text != NN.nn[39])
            {
                List<Khachhang> sp = modify.KhachHangs("select * from KhachHang");

                string tuKhoa = tb_TimKiem.Text.Trim().ToLower();

                // Tìm sản phẩm có tên chứa từ khóa
                List<Khachhang> ketQua = sp.Where(x => x.Ten.ToLower().Contains(tuKhoa)).ToList();


                // Xóa tất cả sản phẩm cũ trong stackpanel
                if (stb_ListKhachHang != null)
                {
                    if (tb_TimKiem.Text != NN.nn[39])
                        stb_ListKhachHang.Children.Clear();
                }
                //MessageBox.Show("xoa roi");

                // Hiển thị sản phẩm tìm được
                AddKhachHang(ketQua);
            }
        }

        // Thêm khách hàng vào list
        private void AddKhachHang(List<Khachhang> kh)
        {
            foreach (var k in  kh)
            {
                FNhapHang_DonNhapHang khachhang = new FNhapHang_DonNhapHang();
                khachhang.Height = 46;
                khachhang.MaDonNhap = k.Id;
                khachhang.MaNhaCungCap = k.Ten;
                khachhang.NgayNhap = k.NgayThem;
                khachhang.TongTien = k.Diem;
                khachhang.PhuongThuc = k.Sdt;

                stb_ListKhachHang.Children.Add(khachhang);
            }
        }


        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[32]}";
            tbl_title_TongKhachHang.Text = NN.nn[115];
            tbl_title_KhachHangMoi.Text = NN.nn[116];
            tb_TimKiem.Text = NN.nn[39];
            tbl_title_MaKhachHang.Text = NN.nn[104];
            tbl_title_TenKhachHang.Text = NN.nn[111];
            tbl_title_SDT.Text = NN.nn[87];
            tbl_title_Diem.Text = NN.nn[106];
            tbl_title_NgayThem.Text = NN.nn[117];
        }


        // sự kiện click textbox
        private void tb_TimKiem_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_TimKiem, NN.nn[39]);
        }
        private void tb_TimKiem_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_TimKiem, NN.nn[39]);
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
