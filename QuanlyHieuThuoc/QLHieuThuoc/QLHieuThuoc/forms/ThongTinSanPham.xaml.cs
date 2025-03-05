using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.SanPham;
using QLHieuThuoc.Model.sql;
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
    /// Interaction logic for ThongTinSanPham.xaml
    /// </summary>
    public partial class ThongTinSanPham : Window
    {
        Modify modify = new Modify();
        // list loại sản phẩm
        private List<string> ListLoaiSanPham = new List<string>
        {
            "Thuoc Khang Sinh",
            "Thuoc Giam Dau",
            "Vitamin",
            "Thuc Pham Bo Sung",
            "Thuoc Khang Virus",
            "Thuoc Tim Mach",
            "Thuoc Di Ung",
            "Thuoc Ho Hap"
        };


        private Sanpham sp;
        public ThongTinSanPham(Sanpham sp)
        {
            InitializeComponent();
            this.sp = sp;

            Loaded += ThongTinSanPham_Loaded;
        }

        private void ThongTinSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            CapNhatSP();
            cbb_LoaiSanPham.ItemsSource = ListLoaiSanPham;
        }

        // Nút Đóng Cửa Sổ
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Nút Xóa Sản Phẩm
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string CauLenhDelete = "Delete from SanPham where ID = '"+sp.MaSanPham1+"'";

            MessageBoxResult result = MessageBox.Show(NN.nn[71], NN.nn[2], MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                modify.ThucThi(CauLenhDelete);
                MessageBox.Show(NN.nn[72], NN.nn[2], MessageBoxButton.OK);
                this.Close();
            }
        }

        // Nút Sửa Sản Phẩm
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (KiemTraDuLieu(tb_SoLuong.Text, tb_GiaNhap.Text, tb_GiaBan.Text))
            {
                string CauLenhUpdate = "Update SanPham set TEN = '"+tb_TenSanPham.Text+"', LOAI = '"+cbb_LoaiSanPham.SelectedItem+"', SOLUONG = '"+tb_SoLuong.Text+"', HAMLUONG = '"+tb_HamLuong.Text+"', HANSUDUNG = '"+date_HanSuDung.SelectedDate+"', GIANHAP = '"+tb_GiaNhap.Text+"', GIABAN = '"+tb_GiaBan.Text+"', THANHPHAN = '"+tb_ThanhPhan.Text+"', CONGDUNG = '"+tb_CongDung.Text+"', CACHDUNG = '"+tb_CachDung.Text+"', CHUY = '"+tb_ChuY.Text+"' where ID = '" + sp.MaSanPham1+"'";
                modify.ThucThi(CauLenhUpdate);
                MessageBox.Show(NN.nn[66], NN.nn[2], MessageBoxButton.OK);
                this.Close();
            }
        }


        // Kiểm tra dữ liệu
        private bool KiemTraDuLieu(string soluong, string gianhap, string giaban)
        {
            int sl;
            decimal gn, gb;

            // Kiểm tra Số Lượng có phải số nguyên không
            if (!int.TryParse(soluong, out sl))
            {
                MessageBox.Show("Số lượng phải là số nguyên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Kiểm tra Giá Nhập có phải kiểu decimal không
            if (!decimal.TryParse(gianhap, out gn))
            {
                MessageBox.Show("Giá nhập phải là số thực!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Kiểm tra Giá Bán có phải kiểu decimal không
            if (!decimal.TryParse(giaban, out gb))
            {
                MessageBox.Show("Giá bán phải là số thực!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Nếu tất cả đều đúng thì trả về true
            return true;
        }

        private void CapNhatNN()
        {
            tbl_TieuDe.Text = $" *{NN.nn[68]}";
            tbl_title_id.Text = $" *{NN.nn[41]}";
            tbl_title_TenSanPham.Text = $" *{NN.nn[42]}";
            tbl_title_SoLuong.Text = $" *{NN.nn[43]}";
            tbl_title_LoaiSanPham.Text = $" *{NN.nn[69]}";
            tbl_title_GiaBan.Text = $" *{NN.nn[57]}";
            tbl_title_GiaNhap.Text = $" *{NN.nn[56]}";
            tbl_title_HanSuDung.Text = $" *{NN.nn[70]}";
            tbl_title_HamLuong.Text = $" *{NN.nn[61]}";
            tbl_title_CongDung.Text = $" *{NN.nn[59]}";
            tbl_title_ThanhPhan.Text = $" *{NN.nn[58]}";
            tbl_title_ChuY.Text = $" *{NN.nn[60]}";
            tbl_title_CachDung.Text = $" *{NN.nn[62]}";
        }


        private void CapNhatSP()
        {
            tbl_Id.Text = sp.MaSanPham1;
            tb_TenSanPham.Text = sp.TenSanPham1;
            tb_SoLuong.Text = sp.SoLuong1;
            cbb_LoaiSanPham.SelectedItem = sp.LoaiSanPham1;
            tb_GiaBan.Text = sp.GiaBan1;
            tb_GiaNhap.Text = sp.GiaNhap1;
            date_HanSuDung.SelectedDate = sp.HanSuDung1;
            tb_HamLuong.Text = sp .HamLuong1;
            tb_CongDung.Text = sp .CongDung1;
            tb_ThanhPhan.Text = sp.ThanhPhan1;
            tb_ChuY.Text = sp.ChuY1;
            tb_CachDung.Text = sp.CachDung1;
        }
    }
}
