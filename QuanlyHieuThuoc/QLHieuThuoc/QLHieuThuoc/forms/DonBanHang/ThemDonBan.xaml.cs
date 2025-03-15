using QLHieuThuoc.forms.DonBanHang;
using QLHieuThuoc.Model.BanHang;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.SanPham;
using QLHieuThuoc.Model.sql;
using QLHieuThuoc.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
    /// Interaction logic for ThemDonBan.xaml
    /// </summary>
    public partial class ThemDonBan : Window
    {
        Modify modify = new Modify();
        ClickTextBox cl = new ClickTextBox();
        TaoMaNgauNhien TaoMa = new TaoMaNgauNhien();
        private List<string> ListItemPhuongThucThanhToan = new List<string> { NN.nn[120], NN.nn[128], NN.nn[121] };
        private decimal tongtien = 0;
        private int diem = 0;
        private string idnv;


        public ThemDonBan(string id)
        {
            InitializeComponent();
            Loaded += ThemDonBan_Loaded;
            idnv = id;
        }

        private void ThemDonBan_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            tbl_IdDonBan.Text = TaoMa.TaoMa();
            tbl_IdKhachHang.Text = TaoMa.TaoMa();
            cbb_PhuongThucThanhToan.Items.Clear();
            cbb_PhuongThucThanhToan.ItemsSource = ListItemPhuongThucThanhToan;
            cbb_PhuongThucThanhToan.SelectedItem = NN.nn[121];
            tbl_TongTien.Text = $"{NN.nn[88]} : {tongtien}";
            if (lspmua.listspmua.Count > 0) lspmua.listspmua.Clear();
        }

        // Cập nhật tổng tiền
        private void CapNhatTongTien()
        {
            tongtien = 0;
            foreach(var i in lspmua.listspmua)
            {
                decimal gia = (i.Giaban * i.Soluong);
                tongtien += gia;
            }
            tbl_TongTien.Text = $"{NN.nn[88]} : {tongtien}";
        }


        // nút thoát
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // mở bảng xác nhận mua
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tb_SoDienThoai.Text.Length == 0 || tb_SoDienThoai.Text == NN.nn[87]) { ThongBao.Show(NN.nn[77], NN.nn[125], "Do"); return; }
            if (tb_TenKhachHang.Text.Length == 0 || tb_TenKhachHang.Text == NN.nn[111]) { ThongBao.Show(NN.nn[77], NN.nn[132], "Do"); return; }
            if (tongtien == 0) { ThongBao.Show(NN.nn[77], NN.nn[126], "Do"); return ; }
            if (cbb_PhuongThucThanhToan.SelectedItem == NN.nn[121]) { ThongBao.Show(NN.nn[77], NN.nn[127], "Do"); return; }

            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            XacNhanMua xacNhanMua = new XacNhanMua(diem);
            xacNhanMua.ShowDialog();
            if (XacNhan.XN)
            {
                KiemtraDiem();
                ThongTinDuPhong();
                List<string> tenbang = new List<string> { "sdj", "djdj"};
                ChiTietDonBan chitiet = new ChiTietDonBan(tenbang);
                chitiet.ShowDialog();
                
            }

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
            if (XacNhan.XN && XacNhan.YN)
            {
                LuuThongTinKhachHang();
                LuuThongTinDonBan();
                LuuThongTinChiTietDonBan();
                HoaDon hd = new HoaDon(tbl_IdDonBan.Text);
                hd.ShowDialog();
                ThongBao.Show(NN.nn[2], NN.nn[142], "Cam");
                XacNhan.XN = false;
                XacNhan.YN = false;
                this.Close() ;
                
            }
        }

        private void ThongTinDuPhong()
        {
            Donban db = new Donban(tbl_IdDonBan.Text, tbl_IdKhachHang.Text, DateTime.Now, tongtien, cbb_PhuongThucThanhToan.SelectedItem.ToString(), idnv);
            Khachhang khh = new Khachhang(tbl_IdKhachHang.Text, tb_TenKhachHang.Text, tb_SoDienThoai.Text, diem, DateTime.Now);

            XacNhan.hd = db;
            XacNhan.kh = khh;
        }

        private void KiemtraDiem()
        {
            diem -= DiemThuong.diem;
            int d = (int)(tongtien / 10);
            tongtien -= DiemThuong.diem * 1/2;
            diem += d;
        }

        // mở bảng thêm sản phẩm
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            ThemSanPhamDonBan themsanpham = new ThemSanPhamDonBan();
            themsanpham.ShowDialog();

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
            AddSanPham(); 
            CapNhatTongTien();
        }

        // Kiểm tra thông tin khách hàng
        private void KiemTraThongTinkKhachHang()
        {
            string sdt = tb_SoDienThoai.Text;

            string lenhSelect = "select * from KhachHang where SDT = '"+sdt+"'";

            List<Khachhang> listKhachHang = modify.KhachHangs(lenhSelect);
            if (listKhachHang.Count > 0)
            {
                tbl_IdKhachHang.Text = listKhachHang[0].Id;
                tb_TenKhachHang.Text = listKhachHang[0].Ten;
                diem = listKhachHang[0].Diem;
                tbl_Diem.Text = $"{NN.nn[106]} : {diem}";
            }
        }
        private void tb_SoDienThoai_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_SoDienThoai.Text != NN.nn[87]) 
            {
                KiemTraThongTinkKhachHang();
            }
        }


        // thêm sản phẩm vào
        private void AddSanPham()
        {
            if (stb_ListSanPham.Children.Count > 0)
                stb_ListSanPham.Children.Clear();

            foreach (var i in lspmua.listspmua)
            {
                FNhapHang_SanPham sanpham = new FNhapHang_SanPham();
                sanpham.Height = 46;
                sanpham.TenSanPham = i.Ten;
                sanpham.SoLuong = i.Soluong.ToString();
                sanpham.GiaSanPham = i.Giaban.ToString();

                stb_ListSanPham.Children.Add(sanpham);
                sanpham.Click += Sanpham_Click;
            }
        }

        // xóa sản phẩm
        private void Sanpham_Click(object? sender, string e)
        {
            lspmua.listspmua.RemoveAll(x => x.Ten == e);
            AddSanPham();
            CapNhatTongTien();
        }

        // lưu thông tin vào database
        private void LuuThongTinKhachHang()
        {
            string lenhcheck = "select * from KhachHang where ID = '" + tbl_IdKhachHang.Text + "'";
            if (modify.KhachHangs(lenhcheck).Count == 0)
            {
                string lenhInsert = "Insert into KhachHang values ('"+tbl_IdKhachHang.Text+"', N'"+tb_TenKhachHang.Text+"', '"+tb_SoDienThoai.Text+"', '"+diem+ "', CAST(GETDATE() AS DATE))";
                modify.ThucThi(lenhInsert);
            }
            else
            {
                string lenhUpdate = "Update KhachHang set DIEM = '"+diem+"' where ID = '"+tbl_IdKhachHang.Text+"'";
                modify.ThucThi(lenhUpdate);
            }
        }

        private void LuuThongTinDonBan()
        {
            string lenhInsert = "Insert into DonBan values ('" + tbl_IdDonBan.Text + "', N'" + tbl_IdKhachHang.Text + "', CAST(GETDATE() AS DATE), '" + tongtien + "', N'" + cbb_PhuongThucThanhToan.SelectedItem.ToString() + "', '"+idnv+"')";
            modify.ThucThi(lenhInsert);
        }

        private void LuuThongTinChiTietDonBan()
        {
            foreach(var i in lspmua.listspmua)
            {
                string id = TaoMa.TaoMa();
                string idsp = "000";
                string lenhCheck = "Select * from SanPham where TEN = N'"+i.Ten+"'";
                List<Sanpham> sp = modify.SanPhams(lenhCheck);
                if (sp.Count > 0)
                {
                    idsp = sp[0].MaSanPham1;
                    int sl = sp[0].SoLuong1;

                    sl -= i.Soluong;
                    string LenhUpdate = "Update SanPham set SOLUONG = '"+sl+"' where ID = '"+idsp+"'";
                    modify.ThucThi(LenhUpdate);
                }

                string lenhInsert = "Insert into ChiTietDonBan values ('"+id+"', '"+tbl_IdDonBan.Text+"', '"+idsp+"', '"+i.Soluong+"', '"+i.Giaban+"')";
                modify.ThucThi(lenhInsert);
            }
        }

        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_tieude.Text = NN.nn[105];
            tb_SoDienThoai.Text = NN.nn[87];
            tb_TenKhachHang.Text = NN.nn[111];
            tbl_title_TenSanPham.Text = NN.nn[42];
            tbl_title_SoLuong.Text = NN.nn[43];
            tbl_title_GiaBan.Text = NN.nn[44];
            tbl_bt_Huy.Text = NN.nn[64];
            tbl_bt_Mua.Text = NN.nn[107];
            tbl_bt_ThemSanPham.Text = NN.nn[40];
        }








        // click textbox
        // textbox số điện thoại 
        private void tb_SoDienThoai_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_SoDienThoai, NN.nn[87]);
        }
        private void tb_SoDienThoai_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_SoDienThoai, NN.nn[87]);
        }

        // textbox tên khách hàng
        private void tb_TenKhachHang_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_TenKhachHang, NN.nn[111]);
        }
        private void tb_TenKhachHang_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_TenKhachHang, NN.nn[111]);
        }

    }

    public static class XacNhan
    {
        public static bool XN = false;
        public static bool YN = false;
        public static Khachhang kh = new Khachhang();
        public static Donban hd = new Donban();
    }
}
