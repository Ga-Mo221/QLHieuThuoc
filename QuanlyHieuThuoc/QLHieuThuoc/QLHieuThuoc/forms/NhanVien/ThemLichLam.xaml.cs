using Microsoft.VisualBasic;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms.NhanVien
{
    /// <summary>
    /// Interaction logic for ThemLichLam.xaml
    /// </summary>
    public partial class ThemLichLam : Window
    {
        Modify modify = new Modify();
        TaoMaNgauNhien taoma = new TaoMaNgauNhien();
        private int Day;
        private List<string> tennvl = new List<string>();
        private List<Lichlam> tennhanvienlam = new List<Lichlam>();
        private bool coghichu = false;

        public ThemLichLam(int day)
        {
            InitializeComponent();
            Loaded += ThemLichLam_Loaded;
            Day = day;
        }

        private void ThemLichLam_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            LayDanhSanhTenNhanVien();
            AddNhanVien();
            CapNhatGhiChu();
        }


        private void CapNhatGhiChu()
        {
            int selectedDay = Day; // Ví dụ một ngày cụ thể
            string lenh = "select * from GhiChu where day(NGAYLAM) = " + selectedDay + " and month(NGAYLAM) = month(Getdate()) and year(NGAYLAM) = year(Getdate())";
            List<GhiChu> ghichus = modify.GhiChus(lenh);
            if (ghichus.Count > 0)
            {
                tb_GhiChu.Text = ghichus[0].NoiDung;
                coghichu = true;
            }
        }


        private void AddNhanVien()
        {
            if (stb_listnhanvien != null)
            {
                stb_listnhanvien.Children.Clear();
            }

            string lenh = "select * from LichLam where day(NGAYLAM) = "+Day+" and month(NGAYLAM) = month(Getdate()) and year(NGAYLAM) = year(Getdate())";
            List<Lichlam> lichlams = modify.lichlams(lenh);
            if (lichlams != null)
            {
                foreach (var lichlam in lichlams)
                {
                    string lenh2 = "select * from NhanVien where ID = '"+lichlam.Idnv+"'";
                    List<nhanVien> nhanViens = modify.NhanViens(lenh2);
                    
                    if (nhanViens != null)
                    {
                        foreach (var nhanVien in nhanViens)
                        {
                            NhanVienLichLam nv = new NhanVienLichLam();
                            nv.Height = 40;
                            nv.TEN = nhanVien.Ten1;

                            stb_listnhanvien.Children.Add(nv);
                            nv.Click += Nv_Click;
                        }
                    }
                }
            }
        }

        // xóa nhân viên ra khỏi lịch làm
        private void Nv_Click(object? sender, string e)
        {
            string select = "select * from NhanVien where TEN = N'" + e + "'";
            List<nhanVien> nhanViens = modify.NhanViens(select);
            if (nhanViens != null)
            {
                string idnv = nhanViens[0].IdNhanVien1;

                string delete = "delete from LichLam where IDNV = '" + idnv + "' and day(NGAYLAM) = "+Day+" and month(NGAYLAM) = month(Getdate()) and year(NGAYLAM) = year(Getdate())";
                modify.ThucThi(delete);
                AddNhanVien();
            }
        }


        // lấy danh sách tên nhân viên
        private void LayDanhSanhTenNhanVien()
        {
            string lenh = "select * from NhanVien";
            List<nhanVien> nhanViens = modify.NhanViens(lenh);
            foreach (var nhanVien in nhanViens)
            {
                tennvl.Add(nhanVien.Ten1);
            }
            cbb_NhanVien.ItemsSource = tennvl;
        }


        // Thêm Nhân Viên Vào Lịch Làm
        private void cbb_NhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_NhanVien.SelectedItem != null)
            {
                Ghi(cbb_NhanVien.SelectedItem.ToString());   
            }
        }

        // ghi nhân viên vào lịch làm
        private void Ghi(string TenNV)
        {
            string id = taoma.TaoMa();
            DateTime ngaylam = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day);
            string idnv = LayIDNhanVien(TenNV);
            string trangthai = "NOTOK";

            if (idnv != null)
            {
                string lenh = "select * from LichLam where IDNV = '" + idnv + "' and day(NGAYLAM) = "+Day+" and month(NGAYLAM) = month(Getdate()) and year(NGAYLAM) = year(Getdate())";
                List<Lichlam> lichlams = modify.lichlams(lenh);
                if (lichlams.Count == 0)
                {
                    string lenh2 = "insert into LichLam values ('"+id+"', '"+idnv+"', '"+ngaylam+"', '"+trangthai+"')";
                    modify.ThucThi(lenh2);

                    // add lai bang
                    AddNhanVien();
                }
            }
        }


        private string LayIDNhanVien(string TenNV)
        {
            string id;
            string lenh = "select * from NhanVien where TEN = N'" + TenNV + "'";
            List<nhanVien> nhanviens = modify.NhanViens(lenh);
            id = nhanviens[0].IdNhanVien1;
            
            return id;
        }

        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TenBang.Text = NN.nn[170];
            tbl_Ngay.Text = $"{NN.nn[169]} {Day}";
            tbl_ThemNhanVien.Text = $" {NN.nn[171]}";
            tbl_GhiChu.Text = $" {NN.nn[172]}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (coghichu)
            {
                if (tb_GhiChu.Text.Length > 0)
                {
                    string update = "update GhiChu set NOIDUNG = N'" + tb_GhiChu.Text + "' where day(NGAYLAM) = " + Day + " and month(NGAYLAM) = month(Getdate()) and year(NGAYLAM) = year(Getdate())";
                    modify.ThucThi(update);
                    MessageBox.Show("da update");
                }
            }
            else
            {
                if (tb_GhiChu.Text.Length > 0)
                {
                    DateTime ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day);
                    string insert = "INSERT INTO GhiChu VALUES ('" + taoma.TaoMa() + "', '"+ngay.ToString("yyyy-MM-dd") + "', '" + tb_GhiChu.Text + "')";

                    modify.ThucThi(insert);
                    MessageBox.Show("da luu");
                }
            }
        }
    }
}
