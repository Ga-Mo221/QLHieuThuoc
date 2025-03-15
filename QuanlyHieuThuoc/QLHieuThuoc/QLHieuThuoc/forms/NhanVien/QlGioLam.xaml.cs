using QLHieuThuoc.forms.NhanVien;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
using QLHieuThuoc.Model.sql;
using QLHieuThuoc.UserControls.NhanVien;
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
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms.FNhanVien
{
    /// <summary>
    /// Interaction logic for QlGioLam.xaml
    /// </summary>
    public partial class QlGioLam : UserControl
    {
        Modify modify = new Modify();
        private List<string> ChucVu = new List<string> { NN.nn[155], NN.nn[156] };
        private string idnvduocchon;

        public QlGioLam()
        {
            InitializeComponent();
            Loaded += QlGioLam_Loaded;
        }

        private void QlGioLam_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            string lenhSelect = "select * from NhanVien";
            List<nhanVien> nhanViens = modify.NhanViens(lenhSelect);
            AddTenNhanVien(nhanViens);
            OnOffTB("Off");
            cbb_ChucVu.ItemsSource = ChucVu;
            CapNhatSoLuongNhanVien();
            CapNhatSoLuongNhanVienMoi();
            CapNhatSoLuongQuanLy();
            CapNhatTongSoLuongNhanVien();
        }

        private void CapNhatSoLuongNhanVien()
        {
            string lenhSelect = "select * from NhanVien where CHUCVU = '" + NN.nn[155] + "'";
            tbl_SoNhanVien.Text = modify.NhanViens(lenhSelect).Count.ToString();
        }
        private void CapNhatTongSoLuongNhanVien()
        {
            string lenhSelect = "select * from NhanVien";
            tbl_SoTongNhanVien.Text = modify.NhanViens(lenhSelect).Count.ToString();
        }
        private void CapNhatSoLuongQuanLy()
        {
            string lenhSelect = "select * from NhanVien where CHUCVU = '" + NN.nn[156] + "'";
            tbl_SoQuanLy.Text = modify.NhanViens(lenhSelect).Count.ToString();
        }
        private void CapNhatSoLuongNhanVienMoi()
        {
            string lenhSelect = "SELECT * FROM NhanVien WHERE MONTH(NGAYTHEM) = MONTH(GETDATE()) AND YEAR(NGAYTHEM) = YEAR(GETDATE())";
            tbl_SoNhanVienMoi.Text = modify.NhanViens(lenhSelect).Count.ToString();
        }


        // thêm Tên Nhân Viên Vào Bảng Tên Nhân Viên
        private void AddTenNhanVien(List<nhanVien> nhanViens)
        {
            if (stb_listNhanVien != null)
            {
                stb_listNhanVien.Children.Clear();
            }
            if (nhanViens != null)
            {
                foreach (var nv in nhanViens)
                {
                    TenNhanVien nhanVien = new TenNhanVien();
                    nhanVien.Height = 44;
                    nhanVien.Name = nv.Ten1;
                    nhanVien.Click += NhanVien_Click;
                    stb_listNhanVien.Children.Add(nhanVien);
                }
            }
        }
        private void NhanVien_Click(object? sender, string e)
        {
            string lenhSelect = "select * from NhanVien where TEN = N'"+e+"'";
            List<nhanVien> nhanViens = modify.NhanViens(lenhSelect);

            if (nhanViens != null)
            {
                idnvduocchon = nhanViens[0].IdNhanVien1;
                tbl_IdNhanVien.Text = $"ID: {nhanViens[0].IdNhanVien1}";
                tb_TenNhanVien.Text = nhanViens[0].Ten1;
                tb_Sdt.Text = nhanViens[0].Sdt1 ;
                tb_DiaChi.Text = nhanViens[0].DiaChi1 ;
                cbb_ChucVu.SelectedItem = nhanViens[0].ChucVu1 ;

                string lenhSelect2 = "select * from ThoiGianLam where IDNV = '" + nhanViens[0].IdNhanVien1 +"'";
                List<ThoiGianLam> thoiGians = modify.ThoiGianLams(lenhSelect2);
                if (stb_ThoiGian != null)
                {
                    stb_ThoiGian.Children.Clear();
                }
                if (thoiGians != null)
                {
                    foreach (var thoiGian in thoiGians)
                    {
                        ThoiGianLamCuaNhanVien thoigianlam = new ThoiGianLamCuaNhanVien();
                        thoigianlam.Height = 42;
                        thoigianlam.NgayLam = thoiGian.NgayLam;
                        thoigianlam.GioVao = thoiGian.GioVao;
                        thoigianlam.GioRa = thoiGian.GioRa;
                        thoigianlam.TongGio = thoiGian.TongGioLam;

                        stb_ThoiGian.Children.Add(thoigianlam);
                    }
                }
            }
        }


        // tắt bật textbox
        private void OnOffTB(string On_or_Off)
        {
            switch (On_or_Off)
            {
                case "On":
                    tb_TenNhanVien.IsEnabled = true;
                    tb_Sdt.IsEnabled = true;
                    tb_DiaChi.IsEnabled = true;
                    cbb_ChucVu.IsEnabled = true;
                    break;


                case "Off":
                    tb_TenNhanVien.IsEnabled = false;
                    tb_Sdt.IsEnabled = false;
                    tb_DiaChi.IsEnabled = false;
                    cbb_ChucVu.IsEnabled = false;
                    break;
            }
        }

        // Cập nHật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_NhanVien.Text = NN.nn[33];
            tbl_QuanLy.Text = NN.nn[156];
            tbl_TongNhanVien.Text = NN.nn[161];
            tbl_NhanVienMoi.Text = NN.nn[162];
            tbl_IdNhanVien.Text = $"{NN.nn[95]}:";
            tbl_TenNhanVien.Text = $"{NN.nn[168]}:";
            tbl_Tennhanvien.Text = $"{NN.nn[98]}:";
            tbl_ChucVu.Text = $"{NN.nn[163]}:";
            tbl_Sdt.Text = $"{NN.nn[87]}:";
            tbl_DiaChi.Text = $"{NN.nn[86]}:";
            tbl_NgayLam.Text = NN.nn[164];
            tbl_GioVao.Text = NN.nn[166];
            tbl_GioRa.Text = NN.nn[165];
            tbl_TongGioLam.Text = NN.nn[167];
            tbl_bt_sua.Text = NN.nn[160];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                Mo.OpenWindowWithBlur(mainWindow, new ThemNhanVien());
            }
            string lenhSelect = "select * from NhanVien";
            List<nhanVien> nhanViens = modify.NhanViens(lenhSelect);
            AddTenNhanVien(nhanViens);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tbl_bt_sua.Text == NN.nn[160])
            {
                tbl_bt_sua.Text = NN.nn[91];
                OnOffTB("On");
            }
            else if (tbl_bt_sua.Text == NN.nn[91])
            {
                string lenh = "update NhanVien set TEN = N'"+tb_TenNhanVien.Text+"', SDT = '"+tb_Sdt.Text+"', DIACHI = N'"+tb_DiaChi.Text+"', CHUCVU = N'"+cbb_ChucVu.SelectedItem.ToString()+"' where ID = '"+idnvduocchon+"'";

                modify.ThucThi(lenh);
                ThongBao.Show(NN.nn[2], NN.nn[92], "Cam");

                tbl_bt_sua.Text = NN.nn[160];
                OnOffTB("Off");
            }
        }
    }
}
