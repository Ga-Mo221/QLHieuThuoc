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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for ThemSanPham.xaml
    /// </summary>
    public partial class ThemSanPham : Window
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
        // list sản phẩm
        private List<string> listSanPham;
        private bool check = false;




        public ThemSanPham()
        {
            InitializeComponent();

            this.Loaded += ThemSanPham_Loaded;
        }

        // Load form
        private void ThemSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            CapNhatSanPham();
            cbb_TenSanPham.ItemsSource = listSanPham;
            cbb_LoaiSanPham.ItemsSource = ListLoaiSanPham;
            tbl_ID.Text = $"#{TaoMaSanPham()}";
        }

        // Thoát cửa sổ
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Cập Nhật Ngôn Ngữ
        private void CapNhatNN()
        {
            tbl_ThemSanPham.Text = NN.nn[40];
            tb_SoLuong.Text = NN.nn[55];
            tb_GiaNhap.Text = NN.nn[56];
            tb_GiaBan.Text = NN.nn[57];
            tb_ThanhPhan.Text = NN.nn[58];
            tb_CongDung.Text = NN.nn[59];
            tb_ChuY.Text = NN.nn[60];
            tb_HamLuong.Text = NN.nn[61];
            tb_CachDung.Text = NN.nn[62];
            tbl_bt_Them.Text = NN.nn[63];
            tbl_bt_Huy.Text = NN.nn[64];
        }







        // set click vào textbox
        // số lượng
        private void tb_SoLuong_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_SoLuong.Text == NN.nn[55])
            {
                tb_SoLuong.Text = "";
                tb_SoLuong.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_SoLuong_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_SoLuong.Text))
            {
                tb_SoLuong.Text = NN.nn[55];
                tb_SoLuong.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // giá nhập
        private void tb_GiaNhap_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_GiaNhap.Text == NN.nn[56])
            {
                tb_GiaNhap.Text = "";
                tb_GiaNhap.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_GiaNhap_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_GiaNhap.Text))
            {
                tb_GiaNhap.Text = NN.nn[56];
                tb_GiaNhap.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // giá bán
        private void tb_GiaBan_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_GiaBan.Text == NN.nn[57])
            {
                tb_GiaBan.Text = "";
                tb_GiaBan.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_GiaBan_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_GiaBan.Text))
            {
                tb_GiaBan.Text = NN.nn[57];
                tb_GiaBan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // thành phần
        private void tb_ThanhPhan_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_ThanhPhan.Text == NN.nn[58])
            {
                tb_ThanhPhan.Text = "";
                tb_ThanhPhan.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_ThanhPhan_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ThanhPhan.Text))
            {
                tb_ThanhPhan.Text = NN.nn[58];
                tb_ThanhPhan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // công dụng
        private void tb_CongDung_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_CongDung.Text == NN.nn[59])
            {
                tb_CongDung.Text = "";
                tb_CongDung.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_CongDung_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_CongDung.Text))
            {
                tb_CongDung.Text = NN.nn[59];
                tb_CongDung.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // chú ý
        private void tb_ChuY_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_ChuY.Text == NN.nn[60])
            {
                tb_ChuY.Text = "";
                tb_ChuY.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_ChuY_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ChuY.Text))
            {
                tb_ChuY.Text = NN.nn[60];
                tb_ChuY.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // hàm lượng
        private void tb_HamLuong_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_HamLuong.Text == NN.nn[61])
            {
                tb_HamLuong.Text = "";
                tb_HamLuong.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_HamLuong_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_HamLuong.Text))
            {
                tb_HamLuong.Text = NN.nn[61];
                tb_HamLuong.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }

        // cách dùng
        private void tb_CachDung_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_CachDung.Text == NN.nn[62])
            {
                tb_CachDung.Text = "";
                tb_CachDung.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }
        private void tb_CachDung_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_CachDung.Text))
            {
                tb_CachDung.Text = NN.nn[62];
                tb_CachDung.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C8C8C")); // Trả lại màu xám
            }
        }



        
        

        // Taọ mã sản phẩm
        public static string TaoMaSanPham()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(chars.Length);
                result.Append(chars[index]);
            }

            return result.ToString();
        }


        private void CapNhatSanPham()
        {
            listSanPham = new List<string>();
            string CauLenhTruyVan = "Select * from SanPham";
            List<Sanpham> Sp = modify.SanPhams(CauLenhTruyVan);
            foreach (Sanpham sp in Sp)
            {
                listSanPham.Add(sp.TenSanPham1);
            }
        }

        private void cbb_TenSanPham_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = cbb_TenSanPham.Text.ToLower();
            var result = listSanPham.Where(sp => sp.ToLower().Contains(filter)).ToList();

            cbb_TenSanPham.ItemsSource = result;
            cbb_TenSanPham.IsDropDownOpen = true; // Mở dropdown khi tìm kiếm
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

        // Thêm sản phẩm
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cbb_TenSanPham.Text == "") { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning) ; return; }
            if (cbb_LoaiSanPham.Text == "") { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_SoLuong.Text == "" || tb_SoLuong.Text == NN.nn[55]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_GiaNhap.Text == "" || tb_GiaNhap.Text == NN.nn[56]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_GiaBan.Text == "" || tb_GiaBan.Text == NN.nn[57]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_ThanhPhan.Text == "" || tb_ThanhPhan.Text == NN.nn[58]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_CongDung.Text == "" || tb_CongDung.Text == NN.nn[59]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_ChuY.Text == "" || tb_ChuY.Text == NN.nn[60]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_HamLuong.Text == "" || tb_HamLuong.Text == NN.nn[61]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (tb_CachDung.Text == "" || tb_CachDung.Text == NN.nn[62]) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (Date_HanSuDung.SelectedDate == null) { MessageBox.Show(NN.nn[65], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Warning); return; }


            string id = tbl_ID.Text;
            string tensp = cbb_TenSanPham.Text;
            string loaisp = cbb_LoaiSanPham.Text;
            string soluong = tb_SoLuong.Text;
            string gianhap = tb_GiaNhap.Text;
            string giaban = tb_GiaBan.Text;
            string thanhphan = tb_ThanhPhan.Text;
            string congdung = tb_CongDung.Text;
            string chuy = tb_ChuY.Text;
            string hamluong = tb_HamLuong.Text;
            string cachdung = tb_CachDung.Text;
            DateTime HSD = Date_HanSuDung.SelectedDate.Value.Date;

            if (!KiemTraDuLieu(soluong, gianhap, giaban)) return;


            if (!check)
            {
                string CauLenhTruyVan = "Insert into SanPham values ('"+id+"','"+tensp+"','"+loaisp+ "','"+soluong+"','"+gianhap+"','"+giaban+ "','"+thanhphan+"','"+congdung+ "','"+chuy+"','"+hamluong+"','"+cachdung+ "','"+HSD+"')";
                modify.SanPhams(CauLenhTruyVan);
                MessageBox.Show(NN.nn[66], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Information);

                check = false;
                this.Close();
            }
            else
            {
                //, GIANHAP = '"+gianhap+"', GIABAN = '"+giaban+"', HANSUDUNG = '"+HSD+"' 
                string CauLenhUpdate = "Update SanPham set SOLUONG = '"+soluong+ "', GIANHAP = '"+gianhap+"', GIABAN = '"+giaban+"', HANSUDUNG = '"+HSD+"' where ID = '" + id+"'";
                modify.ThucThi(CauLenhUpdate);
                MessageBox.Show(NN.nn[67], NN.nn[2], MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        // Chọn sản phẩm
        private void cbb_TenSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tensp = cbb_TenSanPham.SelectedItem.ToString();
            string CauLenhTruyVan = "Select * from SanPham where TEN = '" + tensp + "'";
            List<Sanpham> Sp = modify.SanPhams(CauLenhTruyVan);
            if (Sp.Count == 1)
            {
                tbl_ID.Text = Sp[0].MaSanPham1;
                cbb_LoaiSanPham.SelectedItem = Sp[0].LoaiSanPham1;
                tb_GiaNhap.Text = Sp[0].GiaNhap1;
                tb_GiaBan.Text = Sp[0].GiaBan1;
                tb_CachDung.Text = Sp[0].CachDung1;
                tb_ChuY.Text = Sp[0].ChuY1;
                tb_CongDung.Text = Sp[0].CongDung1;
                tb_HamLuong.Text = Sp[0].HamLuong1;
                tb_ThanhPhan.Text = Sp[0].ThanhPhan1;
                check = true;
            }
        }
    }
}
