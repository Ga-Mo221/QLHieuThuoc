using QLHieuThuoc.Model;
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
    /// Interaction logic for DonNhapHangMoi.xaml
    /// </summary>
    public partial class DonNhapHangMoi : Window
    {
        decimal tongtien = 0;
        string Tongtien;
        Modify modify = new Modify();
        TaoMaNgauNhien TaoMa = new TaoMaNgauNhien();
        bool checkNCC = false;
        private List<string> ListItemPhuongThucThanhToan = new List<string> { NN.nn[120], NN.nn[128], NN.nn[121] };

        public DonNhapHangMoi()
        {
            InitializeComponent();
            TongTien();
            tbl_IdNhaCungCap.Text = TaoMa.TaoMa();
            tbl_IdDonNhap.Text = TaoMa.TaoMa();
            if (listSpDonHang.sps.Count > 0 )
            {
                listSpDonHang.sps.Clear();
            }

            Loaded += DonNhapHangMoi_Loaded;
        }

        private void DonNhapHangMoi_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_PhuongThucThanhToan.Items.Clear();
            cbb_PhuongThucThanhToan.ItemsSource = ListItemPhuongThucThanhToan;
            cbb_PhuongThucThanhToan.SelectedItem = NN.nn[121];

            cbb_TenNhaCungCap.ItemsSource = ListTenNhaCungCap();

            CapNhatNN();
        }

        private void TongTien()
        {
            Tongtien = $"{NN.nn[88]}: {tongtien.ToString()}";
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
            tongtien = 0;
            foreach (var sp in listSpDonHang.sps) {
                FNhapHang_SanPham sanpham = new FNhapHang_SanPham {
                    TenSanPham = sp.TenSanPham1,
                    SoLuong = sp.SoLuong1.ToString(),
                    GiaSanPham = sp.GiaNhap1
                };

                stb_ListSanPham.Children.Add(sanpham);

                // tính tiền
                tongtien += decimal.Parse(sanpham.GiaSanPham) * int.Parse(sanpham.SoLuong);
                TongTien();
                MessageBox.Show(tongtien.ToString() );
                sanpham.Click += Sanpham_Click;
            }
            if (listSpDonHang.sps.Count == 0)
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
            if (KiemTra())
            {
                ThemNhaCungCap();
                ThemDonNhapHangMoi();
                ThemChiTietDonNhap();
                ThemSanPham();
                ThongBao.Show("Thông Báo", NN.nn[122], "Cam");
                this.Close();
            }
        }

        // Thêm sản phẩm
        private void ThemSanPham()
        {
            foreach (var sp in listSpDonHang.sps)
            {
                string lenhCheck = "select * from SanPham where ID = '" + sp.MaSanPham1 + "'";
                if (modify.SanPhams(lenhCheck).Count == 0)
                {
                    string lenhInsert = "Insert into SanPham values ('" + sp.MaSanPham1 + "', N'" + sp.TenSanPham1 + "', N'" + sp.LoaiSanPham1 + "','" + sp.SoLuong1 + "','" + sp.GiaNhap1 + "','" + sp.GiaBan1 + "', N'" + sp.ThanhPhan1 + "', N'" + sp.CongDung1 + "', N'" + sp.ChuY1 + "', N'" + sp.HamLuong1 + "', N'" + sp.CachDung1 + "','" + sp.HanSuDung1 + "')";
                    modify.ThucThi(lenhInsert);
                }
                else
                {
                    // cập nhật lại số lượng của sản phẩm
                    string caulenh = "select * from SanPham where ID = '" + sp.MaSanPham1 + "'";
                    List<Sanpham> lsp = modify.SanPhams(caulenh);
                    int sl = lsp[0].SoLuong1 + sp.SoLuong1;
                    string SL = sl.ToString();

                    //, GIANHAP = '"+gianhap+"', GIABAN = '"+giaban+"', HANSUDUNG = '"+HSD+"' 
                    string CauLenhUpdate = "Update SanPham set SOLUONG = '" + SL + "', GIANHAP = '" + sp.GiaNhap1 + "', GIABAN = '" + sp.GiaBan1 + "', HANSUDUNG = '" + sp.HanSuDung1 + "' where ID = '" + sp.MaSanPham1 + "'";
                    modify.ThucThi(CauLenhUpdate);
                }
            }
        }

        
        // Thêm chi tiết đơn hàng
        private void ThemChiTietDonNhap()
        {
            string iddnh = tbl_IdDonNhap.Text;
            foreach(var sp in listSpDonHang.sps)
            {
                string id = TaoMa.TaoMa();
                string lenhInsert = "Insert into ChiTietDonNhap values('" + id + "', '" + tbl_IdDonNhap.Text + "', '" + sp.MaSanPham1 + "', '" + sp.SoLuong1 + "', '" + decimal.Parse(sp.GiaNhap1) + "')";
                modify.ThucThi(lenhInsert);
            }
        }


        // thêm đơn nhập mới
        private void ThemDonNhapHangMoi()
        {
            string lenhInsert = "Insert into DonNhapHang values ('" + tbl_IdDonNhap.Text + "', '" + tbl_IdNhaCungCap.Text + "', cast(getdate() as date), '" + tongtien + "', N'" + cbb_PhuongThucThanhToan.SelectedItem.ToString() + "')";
            modify.ThucThi(lenhInsert);
        }


        // Thêm nhà cung cấp
        private void ThemNhaCungCap()
        {
            string caulenh = "select * from NhaCungCap where TEN = N'" + cbb_TenNhaCungCap.Text + "'";
            if (modify.NhaCungCaps(caulenh).Count == 0)
            {
                string lenhInsert = "insert into NhaCungCap values ('" + tbl_IdNhaCungCap.Text + "', N'" + cbb_TenNhaCungCap.Text + "', '" + tb_SDT.Text + "', N'" + tb_DiaChi.Text + "')";
                modify.ThucThi(lenhInsert);
            }
        }

        private bool KiemTra()
        {
            // check nha cung cap
            if (cbb_TenNhaCungCap.Text == "") { ThongBao.Show(NN.nn[77], NN.nn[123], "Do"); return false; }
            if (tb_DiaChi.Text == NN.nn[86]) { ThongBao.Show(NN.nn[77], NN.nn[124], "Do"); return false; }
            if (tb_SDT.Text == NN.nn[87]) { ThongBao.Show(NN.nn[77], NN.nn[125], "Do"); return false; }

            // check đơn nhập
            if (tongtien == 0) { ThongBao.Show(NN.nn[77], NN.nn[126], "Do"); return false; }
            if (cbb_PhuongThucThanhToan.SelectedItem == NN.nn[121]) { ThongBao.Show(NN.nn[77], NN.nn[127], "Do"); return false; }
            

            return true;
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
            string CauLenh = "select * from NhaCungCap where TEN = N'"+TenNCC+"'";
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

        // lấy ngôn ngữ
        private void CapNhatNN()
        {
            tbl_tieude.Text = NN.nn[85];
            tb_DiaChi.Text = NN.nn[86];
            tb_SDT.Text = NN.nn[87];
            tbl_bt_ThemSP.Text = NN.nn[89];
            tbl_bt_Huy.Text = NN.nn[64];
            tbl_bt_Them.Text = NN.nn[63];
            tbl_title_TenSanPham.Text = NN.nn[42];
            tbl_title_SoLuong.Text = NN.nn[43];
            tbl_title_GiaNhap.Text = NN.nn[56];
        }

        // sự kiện click textblock
        ClickTextBox cl = new ClickTextBox();
        // textbox địa chỉ
        private void tb_DiaChi_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_DiaChi, NN.nn[86]);
        }
        private void tb_DiaChi_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_DiaChi, NN.nn[86]);
        }

        // textbox số điện thoại
        private void tb_SDT_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_SDT, NN.nn[87]);
        }
        private void tb_SDT_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_SDT, NN.nn[87]);
        }
    }

    public static class listSpDonHang
    {
        public static List<Sanpham> sps = new List<Sanpham>();
    }
}
