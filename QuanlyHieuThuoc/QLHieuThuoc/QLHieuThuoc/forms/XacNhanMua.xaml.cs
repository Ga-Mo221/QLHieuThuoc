using QLHieuThuoc.Model;
using QLHieuThuoc.Model.Files;
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
    /// Interaction logic for XacNhanMua.xaml
    /// </summary>
    public partial class XacNhanMua : Window
    {
        ClickTextBox cl = new ClickTextBox();
        private int diem = 0;
        public XacNhanMua(int d)
        {
            InitializeComponent();
            Loaded += XacNhanMua_Loaded;
            diem = d;
            tbl_Diem.Text = $"{NN.nn[106]}: {diem}";
        }

        private void XacNhanMua_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }

        // nút thoát
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // nút mua
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (KiemTraNhapDiem())
            {
                XacNhan.XN = true;
                this.Close();
            }
        }

        private bool KiemTraNhapDiem()
        {
            if (tb_NhapDiem.Text != NN.nn[110])
            {
                if (int.TryParse(tb_NhapDiem.Text, out int D))
                {
                    if (D <= diem)
                    {
                        DiemThuong.diem = D;
                        return true;
                    }
                    else
                    {
                        ThongBao.Show(NN.nn[77], NN.nn[139], "Do");
                        return false;
                    }
                }
                else
                {
                    ThongBao.Show(NN.nn[77], NN.nn[138], "Do");
                    return false;
                }
            }
            else
            {
                DiemThuong.diem = 0;
                return true;
            }
        }


        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_tieude.Text = NN.nn[108];
            tbl_Hoi.Text = NN.nn[109];
            tb_NhapDiem.Text = NN.nn[110];
            tbl_bt_Huy.Text = NN.nn[64];
            tbl_bt_Mua.Text = NN.nn[107];        
        }

        private void tb_NhapDiem_GotFocus(object sender, RoutedEventArgs e)
        {
            cl.GotF(tb_NhapDiem, NN.nn[110]);
        }

        private void tb_NhapDiem_LostFocus(object sender, RoutedEventArgs e)
        {
            cl.LostF(tb_NhapDiem, NN.nn[110]);
        }
    }

    public static class DiemThuong
    {
        public static int diem;
    }
}
