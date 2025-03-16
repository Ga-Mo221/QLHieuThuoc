using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.UserControls.ThongBaosp;
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

namespace QLHieuThuoc.forms.Thongbaos
{
    /// <summary>
    /// Interaction logic for ThanhThongBaoSanPham.xaml
    /// </summary>
    public partial class ThanhThongBaoSanPham : Window
    {
        public ThanhThongBaoSanPham()
        {
            InitializeComponent();
            this.Deactivated += ThanhThongBaoSanPham_Deactivated;
            themthongbao();
        }

        private void themthongbao()
        {
            foreach (var i in ThongBaoSanPham.ThongBao)
            {
                NoiDungThongBao noidungthongbao = new NoiDungThongBao();
                noidungthongbao.Height = 80;
                noidungthongbao.Content = i.Content;
                noidungthongbao.Status = i.Status;

                noidungthongbao.HienThi();

                stb_listthongbao.Children.Add(noidungthongbao);
            }
        }

        private void ThanhThongBaoSanPham_Deactivated(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
