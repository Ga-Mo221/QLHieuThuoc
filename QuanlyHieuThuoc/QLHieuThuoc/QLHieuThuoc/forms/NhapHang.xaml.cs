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
    /// Interaction logic for NhapHang.xaml
    /// </summary>
    public partial class NhapHang : UserControl
    {
        Modify modify = new Modify();
        private string IDNV;


        public NhapHang(string idnv)
        {
            InitializeComponent();
            IDNV = idnv;

            tbl_SoLuongNhaCungCap.Text = SoLuongNhaCungCap();
            Loaded += NhapHang_Loaded;
        }

        // set ngôn ngữ
        private void NhapHang_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatNN();
        }

        private string SoLuongNhaCungCap()
        {
            string caulenh = "select * from NhaCungCap";
            string sl = modify.NhaCungCaps(caulenh).Count.ToString();
            return sl;
        }

        private void bt_ThemDonNhap_Click(object sender, RoutedEventArgs e)
        {
            // áp dụng hiệu ứng mờ cho cửa sổ hiện tại
            this.Effect = new System.Windows.Media.Effects.BlurEffect()
            {
                Radius = 10 // độ mờ
            };

            DonNhapHangMoi donnhapmoi = new DonNhapHangMoi();
            donnhapmoi.ShowDialog();
            

            // xóa hiệu ứng làm mờ khi cửa sổ con đóng lại
            this.Effect = null;
        }


        // lấy ngôn ngữ
        private void CapNhatNN()
        {

        }
    }
}
