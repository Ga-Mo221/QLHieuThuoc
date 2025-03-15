using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
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

namespace QLHieuThuoc.forms.NhanVien
{
    /// <summary>
    /// Interaction logic for CTBangLuong.xaml
    /// </summary>
    public partial class CTBangLuong : Window
    {
        BangLuongDayDu Baangluong = new BangLuongDayDu();
        public CTBangLuong(BangLuongDayDu luongdaydu)
        {
            InitializeComponent();
            Baangluong = luongdaydu;
            Loaded += CTBangLuong_Loaded;
        }

        private void CTBangLuong_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }

        private void CapNhatNN()
        {
            tbl_TenBang.Text = NN.nn[153];
            tbl_bt_Thoat.Text = NN.nn[21];
            tbl_bt_XuatHoaDon.Text = NN.nn[173];
            tbl_TThang.Text = NN.nn[174];
            tbl_TNgayTao.Text = NN.nn[176];
            tbl_TTienThuong.Text = NN.nn[177];
            tbl_TTienTroCap.Text = NN.nn[178];
            tbl_TSoGioLam.Text = NN.nn[179];
            tbl_TLuong.Text = NN.nn[180];

            tbl_ThangNam.Text = $"{NN.nn[174]} {Baangluong.Thang} {NN.nn[175]} {Baangluong.Nam}";

            tbl_Ten.Text = $"{NN.nn[181]} : {Baangluong.Ten}";
            tbl_Sdt.Text = $"{NN.nn[87]} : {Baangluong.Sdt}";
            tbl_DiaChi.Text = $"{NN.nn[86]} : {Baangluong.DiaChi}";

            tbl_DThang.Text = Baangluong.Thang.ToString();
            tbl_DNgayTao.Text = Baangluong.NgayTao.ToString("dd/MM/yyyy");
            tbl_DTienThuong.Text = Baangluong.TienThuong.ToString();
            tbl_DTienTroCap.Text = Baangluong.TienTroCap.ToString();
            tbl_DSoGioLam.Text = Baangluong.SoGioLam.ToString();
            tbl_DLuong.Text = Baangluong.Luong.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string filename = $"{Baangluong.Ten}_{Baangluong.Thang}_{Baangluong.Nam}";

            LuuAnh xuatfile = new LuuAnh();
            xuatfile.SaveGridAsImage(border_bangluong, filename, NN.folderPathLuong);
        }
    }
}
