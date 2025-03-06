using QLHieuThuoc.Model;
using QLHieuThuoc.Model.DonNhapHangvsNCC;
using QLHieuThuoc.Model.Files;
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
    /// Interaction logic for NhapHang.xaml
    /// </summary>
    public partial class NhapHang : UserControl
    {
        ClickTextBox clickk = new ClickTextBox();
        Modify modify = new Modify();
        private string IDNV;
        private List<string> ListThang = new List<string> { "Tháng Trước", "Tháng Này"};


        public NhapHang(string idnv)
        {
            InitializeComponent();
            IDNV = idnv;

            tbl_SoLuongNhaCungCap.Text = SoLuongNhaCungCap();
            CapNhatTongDonNhap();
            cbb_Thang.ItemsSource = ListThang;
            Loaded += NhapHang_Loaded;
        }

        // set ngôn ngữ
        private void NhapHang_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_Thang.SelectedItem = "Tháng Này";
            CapNhatNN();
            AddDonNhap();
        }

        // Cập nhật Tổng đơn Nhập
        private void CapNhatTongDonNhap()
        {
            string caulenh = "select * from DonNhapHang";

            tbl_SoLuongDonNhap.Text = modify.DonNhaps(caulenh).Count.ToString();
        }

        // Cập nhật số lượng nhà cung cấp
        private string SoLuongNhaCungCap()
        {
            string caulenh = "select * from NhaCungCap";
            string sl = modify.NhaCungCaps(caulenh).Count.ToString();
            return sl;
        }

        // Thêm Đơn nhập mới
        private void bt_ThemDonNhap_Click(object sender, RoutedEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            DonNhapHangMoi donnhapmoi = new DonNhapHangMoi();
            donnhapmoi.ShowDialog();
            

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
            AddDonNhap();
            CapNhatTongDonNhap();
            SoLuongNhaCungCap();
        }

        // button mở danh sách nhà cung cấp
        private void bt_NhaCungCap_Click(object sender, RoutedEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.ShowDialog();


            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
        }

        // Cập nhật đơn nhập
        private void AddDonNhap()
        {
            if (stb_ListDonNhap.Children.Count > 0) stb_ListDonNhap.Children.Clear();

            string lenhSelect = "select * from DonNhapHang";

            List<DonNhap> ls = modify.DonNhaps(lenhSelect);
            foreach (DonNhap d in ls)
            {
                FNhapHang_DonNhapHang donnhap = new FNhapHang_DonNhapHang();
                donnhap.Height = 50;
                donnhap.MaDonNhap = d.MaDonNhapHang1;
                donnhap.MaNhaCungCap = d.MaNhaCungCap1;
                donnhap.NgayNhap = d.NhayNhap1;
                donnhap.TongTien = decimal.Parse(d.TongTien1);
                donnhap.PhuongThuc = d.PhuongThucThanhToan1;

                if (donnhap.PhuongThuc == "Tien Mat")
                {
                    donnhap.setcolor("Green");
                }
                else
                {
                    donnhap.setcolor("Red");
                }
                stb_ListDonNhap.Children.Add(donnhap);
                donnhap.Click += Donnhap_Click;
            }
        }

        private void Donnhap_Click(object? sender, string e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            ChiTietDonNhap chitietdonnhap = new ChiTietDonNhap(e);
            chitietdonnhap.ShowDialog();


            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
        }

        // lấy ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[30]}";
            tbl_NhaCungCap.Text = NN.nn[78];
            tbl_TongDonNhap.Text = NN.nn[79];
            tb_TimKiem.Text = NN.nn[39];
            tbl_title_SoLuongDonHangTrongThang.Text = NN.nn[43];
            tbl_title_IdDonNhap.Text = NN.nn[80];
            tbl_title_IdNhaCungCap.Text = NN.nn[81];
            tbl_title_NgayNhap.Text = NN.nn[82];
            tbl_title_TongTien.Text = NN.nn[83];
            tbl_title_PhuongThuc.Text = NN.nn[84];
        }


        private void tb_TimKiem_GotFocus(object sender, RoutedEventArgs e)
        {
            clickk.GotF(tb_TimKiem, NN.nn[39]);
        }
        private void tb_TimKiem_LostFocus(object sender, RoutedEventArgs e)
        {
            clickk.LostF(tb_TimKiem, NN.nn[39]);
        }
    }
}
