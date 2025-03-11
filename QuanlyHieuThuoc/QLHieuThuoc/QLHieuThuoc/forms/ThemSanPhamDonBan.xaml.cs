using QLHieuThuoc.Model;
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
    /// Interaction logic for ThemSanPhamDonBan.xaml
    /// </summary>
    public partial class ThemSanPhamDonBan : Window
    {
        Modify modify = new Modify();
        ClickTextBox cl = new ClickTextBox();
        private int gioHang = 0;
        private Spmua sp = new Spmua();
        private int soluong = 0;
        private bool check = false;


        public ThemSanPhamDonBan()
        {
            InitializeComponent();

            Loaded += ThemSanPhamDonBan_Loaded;
        }

        private void ThemSanPhamDonBan_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            AddSanPham();
            
        }

        // cập nhật giỏ hàng
        private void ThemVaoGioHang()
        {
            gioHang += 1;
            tbl_SoLuongSanPhamGioHang.Text = gioHang.ToString();
        }

        // thêm sản phẩm vào màn hình
        private void AddSanPham()
        {
            string lenhSelect = "select * from SanPham";
            List<Sanpham> sanphams = modify.SanPhams(lenhSelect);

            if (sanphams.Count > 0)
            {
                foreach(var s in sanphams)
                {
                    FNhapHang_TenNhaCungCap tsp = new FNhapHang_TenNhaCungCap();
                    tsp.TenNhaCungCap = s.TenSanPham1;

                    tsp.Click += Tsp_Click;
                    stb_ListSanPham.Children.Add(tsp);
                }
            }
        }

        private void Tsp_Click(object? sender, string e)
        {
            check = false;
            string lenhSelect = "select * from SanPham where TEN = N'"+e+"'";
            tb_SoLuong.Text = NN.nn[112];
            tb_SoLuong.Foreground = new BrushConverter().ConvertFromString("#A4A4A4") as Brush;

            List<Sanpham> sanPhamDuocChon = modify.SanPhams(lenhSelect);
            if (sanPhamDuocChon.Count > 0)
            {
                sp.Ten = sanPhamDuocChon[0].TenSanPham1;
                sp.Giaban = decimal.Parse(sanPhamDuocChon[0].GiaBan1);
                sp.Soluong = 0;
                soluong = sanPhamDuocChon[0].SoLuong1;
            }
            tbl_TenSanPham.Text = sp.Ten;
            tbl_GiaBan.Text = sp.Giaban.ToString();
            tbl_TrangThai.Text = NN.nn[137];
            tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#565656") as Brush;
        }

        // thêm sản phẩm vào giỏ hàng
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sp.Soluong > 0 && check)
            {
                bool datontai = false;
                foreach(var i in lspmua.listspmua)
                {
                    if (i.Ten == sp.Ten)
                    {
                        i.Soluong += sp.Soluong;
                        tbl_TrangThai.Text = NN.nn[133];
                        tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#FFFF00") as Brush;
                        datontai = true;
                    }
                }
                if (!datontai)
                {
                    lspmua.listspmua.Add(new Spmua(sp.Ten, sp.Soluong, sp.Giaban));
                    tbl_TrangThai.Text = NN.nn[134];
                    tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#00FF00") as Brush;
                    ThemVaoGioHang();
                }
                tb_SoLuong.Text = NN.nn[112];
                tb_SoLuong.Foreground = new BrushConverter().ConvertFromString("#A4A4A4") as Brush;
            }else
            {
                tbl_TrangThai.Text = NN.nn[135];
                tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#FF0000") as Brush;
            }
        }

        // thoát
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // kiểm tra nhập vào số lượng
        private void tb_SoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tb_SoLuong.Text, out int sl))
            {
                sp.Soluong = sl;
                if (sp.Soluong > soluong)
                {
                    tbl_TrangThai.Text = NN.nn[136];
                    tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#FF0000") as Brush;
                    check = false;
                }
                else if (tb_SoLuong.Text == "")
                {
                    tbl_TrangThai.Text = NN.nn[137];
                    tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#565656") as Brush;
                    check = false;
                }
                else
                {
                    tbl_TrangThai.Text = NN.nn[126];
                    tbl_TrangThai.Foreground = new BrushConverter().ConvertFromString("#00FF00") as Brush;
                    check = true;
                }
            }
        }

        // click textbox
        private void tb_SoLuong_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_SoLuong, NN.nn[112]);
        }
        private void tb_SoLuong_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_SoLuong, NN.nn[112]);
        }
        private void tb_TimKiem_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_TimKiem, NN.nn[39]);
        }
        private void tb_TimKiem_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_TimKiem, NN.nn[39]);
        }


        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tb_SoLuong.Text = NN.nn[112];
            tbl_TieuDe.Text = NN.nn[28];
            tb_TimKiem.Text = NN.nn[39];
            tbl_SoLuong.Text = NN.nn[43];
            tbl_bt_Huy.Text = NN.nn[64];
            tbl_bt_Them.Text = NN.nn[63];
        }

    }

    public class Spmua
    {
        private string ten;
        private int soluong;
        private decimal giaban;

        public Spmua()
        {
        }

        public Spmua(string ten, int soluong, decimal giaban)
        {
            this.ten = ten;
            this.soluong = soluong;
            this.giaban = giaban;
        }

        public string Ten { get => ten; set => ten = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Giaban { get => giaban; set => giaban = value; }
    }

    public static class lspmua
    {
        public static List<Spmua> listspmua = new List<Spmua>();
    }
}
