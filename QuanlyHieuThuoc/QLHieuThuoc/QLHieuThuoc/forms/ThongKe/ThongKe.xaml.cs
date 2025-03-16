using QLHieuThuoc.forms.Thongbaos;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.NhanVien;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : UserControl
    {
        LayThongBao thongbao = new LayThongBao();
        Modify modify = new Modify();
        private string idnv;


        public ThongKe(string id)
        {
            InitializeComponent();
            thongbao.BatThongBao(CoThongBao);
            Loaded += ThongKe_Loaded;
            idnv = id;
        }

        private void ThongKe_Loaded(object sender, RoutedEventArgs e)
        {
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
