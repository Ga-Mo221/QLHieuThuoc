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
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    public partial class NhaCungCap : Window
    {
        Modify modify = new Modify();


        public NhaCungCap()
        {
            InitializeComponent();
            Loaded += NhaCungCap_Loaded;
        }

        private void NhaCungCap_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            addNhacungcap();
        }

        // Thêm tên nhà cung cấp vào bảng
        private void addNhacungcap()
        {
            if (stb_ListNCC.Children.Count > 0) stb_ListNCC.Children.Clear();


            string caulenh = "select * from NhaCungCap";
            List<NCC> listNcc = modify.NhaCungCaps(caulenh);
            foreach (var ncc in listNcc)
            {
                FNhapHang_TenNhaCungCap NCC_Name = new FNhapHang_TenNhaCungCap();
                NCC_Name.Height = 40;
                NCC_Name.TenNhaCungCap = ncc.TenNhaCungCap1;

                stb_ListNCC.Children.Add(NCC_Name);

                NCC_Name.Click += NCC_Name_Click;
            }
        }

        // sự kiện chọn vào nhà cung cấp muốn xem thông tin
        private void NCC_Name_Click(object? sender, string e)
        {
            string caulenh = "select * from NhaCungCap where TEN = N'" + e + "'";

            List<NCC> lsncc = modify.NhaCungCaps(caulenh);
            if (lsncc.Count == 1)
            {
                tbl_MaNhaCungCap.Text = lsncc[0].MaNhaCungCap1;
                tb_TenNhaCungCap.Text = lsncc[0].TenNhaCungCap1;
                tb_SDT.Text = lsncc[0].SoDienThoai1;
                tb_DiaChi.Text = lsncc[0].DiaChi1;
            }
        }

        // thoát
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // button thây đổi thông tin
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string caulenh = "select * from NhaCungCap where ID = '"+tbl_MaNhaCungCap.Text+"'";

            if (modify.NhaCungCaps(caulenh).Count == 1)
            {
                string lenhupdate = "update NhaCungCap set TEN = N'"+tb_TenNhaCungCap.Text+"', SDT = '"+tb_SDT.Text+"', DIACHI = N'"+tb_DiaChi.Text+"' where ID = '"+tbl_MaNhaCungCap.Text+"'";
                modify.ThucThi(lenhupdate);
                ThongBao.Show(NN.nn[2], NN.nn[92], "Cam");
                addNhacungcap();
            }
        }





        // lấy ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TieuDe.Text = NN.nn[78];
            tbl_TenNhaCungCap.Text = NN.nn[90];
            tb_TenNhaCungCap.Text = NN.nn[90];
            tb_SDT.Text = NN.nn[87];
            tb_DiaChi.Text = NN.nn[86];
            tbl_bt_ApDung.Text = NN.nn[91];
        }
    }
}
