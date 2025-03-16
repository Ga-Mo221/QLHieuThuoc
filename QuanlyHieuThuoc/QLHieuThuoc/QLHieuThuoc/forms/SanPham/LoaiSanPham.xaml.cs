using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.SanPham;
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
    /// Interaction logic for LoaiSanPham.xaml
    /// </summary>
    public partial class LoaiSanPham : Window
    {
        Modify modify = new Modify();
        private List<Sanpham> sp;
        private string loai;
        private string idnv;


        public LoaiSanPham(List<Sanpham> Sp, string TenLoai, string id)
        {
            InitializeComponent();
            sp = Sp;
            loai = TenLoai;

            Loaded += LoaiSanPham_Loaded;
            idnv = id;
        }

        private void LoaiSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
            Aadsanpham(sp);
        }

        private void Aadsanpham(List<Sanpham> sp)
        {
            foreach (var s in sp)
            {
                FSanPham_SanPham fSanPham_SanPham = new FSanPham_SanPham();

                fSanPham_SanPham.Id = s.MaSanPham1;
                fSanPham_SanPham.TenSP = s.TenSanPham1;
                fSanPham_SanPham.SoLuong = s.SoLuong1.ToString();
                fSanPham_SanPham.GiaBan = s.GiaBan1;
                fSanPham_SanPham.Loai = s.LoaiSanPham1;
                if (s.SoLuong1 == 0)
                {
                    fSanPham_SanPham.TinhTrang = NN.nn[129];
                    fSanPham_SanPham.setcolor("Red");
                }
                else if (int.Parse(fSanPham_SanPham.SoLuong) < 10)
                {
                    fSanPham_SanPham.TinhTrang = NN.nn[130];
                    fSanPham_SanPham.setcolor("Orange");
                }
                else
                {
                    fSanPham_SanPham.TinhTrang = NN.nn[131];
                    fSanPham_SanPham.setcolor("Green");
                }
                fSanPham_SanPham.Height = 50;

                fSanPham_SanPham.clickbt += FSanPham_SanPham_clickbt;

                stb_listSanPham.Children.Add(fSanPham_SanPham);

            }
        }

        private void FSanPham_SanPham_clickbt(object? sender, string e)
        {
            string CauLenhTruyVan = "select * from SanPham where ID = '" + e + "'";

            List<Sanpham> sp = modify.SanPhams(CauLenhTruyVan);
            ThongTinSanPham ttsp = new ThongTinSanPham(sp[0], idnv);
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            ttsp.ShowDialog();

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
        }


        // cập nhật ngôn ngữ
        private void CapNhatNN()
        {
            tbl_TieuDe.Text = loai;
            tbl_MaSanPham.Text = NN.nn[41];
            tbl_TenSanPham.Text = NN.nn[42];
            tbl_SoLuong.Text = NN.nn[43];
            tbl_GiaBan.Text = NN.nn[44];
            tbl_TinhTrang.Text = NN.nn[45];
            tbl_loai.Text = NN.nn[46];
        }

        private void bt_thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
