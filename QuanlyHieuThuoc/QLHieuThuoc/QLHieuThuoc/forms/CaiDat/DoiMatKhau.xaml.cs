using QLHieuThuoc.Model.Account;
using QLHieuThuoc.Model.Files;
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

namespace QLHieuThuoc.forms.CaiDat
{
    /// <summary>
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class DoiMatKhau : Window
    {
        Modify modify = new Modify();
        private string idnv;
        private string taikhoan;
        private string mk;
        public DoiMatKhau(string id)
        {
            InitializeComponent();
            idnv = id;
            laytaikhoan();
            Loaded += DoiMatKhau_Loaded;
        }

        private void DoiMatKhau_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }

        private void laytaikhoan()
        {
            string lenh = "select * from TaiKhoan where IDNV = '" + idnv + "'";
            List<TaiKhoan> taiKhoans = modify.TaiKhoans(lenh);
            if (taiKhoans.Count > 0 )
            {
                taikhoan = taiKhoans[0].TenTaiKhoan1;
                mk = taiKhoans[0].MatKhau1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool kiemtraRong()
        {
            if (pw_cu.Password.Trim() == "") { ThongBao.Show(NN.nn[77], NN.nn[202], "Do"); return false; } 
            if (pw_moi1.Password.Trim() == "") { ThongBao.Show(NN.nn[77], NN.nn[202], "Do"); return false; } 
            if (pw_moi2.Password.Trim() == "") { ThongBao.Show(NN.nn[77], NN.nn[202], "Do"); return false; }
            return true;
        }

        private bool KiemTraTaiKhoanVaMatKhau()
        {
            if (pw_cu.Password != mk)
            {
                ThongBao.Show(NN.nn[77], NN.nn[203], "Do");
                return false;
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (kiemtraRong())
            {
                if (KiemTraTaiKhoanVaMatKhau())
                {
                    if (pw_moi1.Password != pw_moi2.Password) { ThongBao.Show(NN.nn[2], NN.nn[204], "Do"); return; }
                    string update = "Update TaiKhoan set MK = '"+pw_moi1.Password+"' where TK = '"+taikhoan+"'";
                    modify.ThucThi(update);
                    ThongBao.Show(NN.nn[2], NN.nn[26], "Cam");
                    this.Close();
                }
            }
        }



        private void CapNhatNN()
        {
            tbl_TenBang.Text = NN.nn[205];
            tbl_MKCu.Text = $" {NN.nn[206]}";
            tbl_MKMoi.Text = $" {NN.nn[23]}";
            tbl_NhapLaiMK.Text = $" {NN.nn[207]}";
            tbl_Huy.Text = NN.nn[64];
            tbl_Doi.Text = NN.nn[208];
        }
    }
}
