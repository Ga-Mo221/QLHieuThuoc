using QLHieuThuoc.Model.DungNhanh;
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

namespace QLHieuThuoc.forms.NhanVien
{
    /// <summary>
    /// Interaction logic for ThemNhanVien.xaml
    /// </summary>
    public partial class ThemNhanVien : Window
    {
        TaoMaNgauNhien taoma = new TaoMaNgauNhien();
        Modify modify = new Modify();
        private List<string> ChucVu = new List<string> { NN.nn[155], NN.nn[156] };
        private string Id;

        public ThemNhanVien()
        {
            InitializeComponent();
            Loaded += ThemNhanVien_Loaded;
        }

        private void ThemNhanVien_Loaded(object sender, RoutedEventArgs e)
        {
            Id = taoma.TaoMa();
            CapNhatNN();
            cbb_ChucVu.ItemsSource = ChucVu;
            cbb_ChucVu.SelectedItem = NN.nn[155];
        }



        // Kiểm tra
        private bool KiemTra()
        {
            if (tb_Ten.Text.Length == 0) { ThongBao.Show(NN.nn[77], NN.nn[158], "Do"); return false; }
            if (tb_Sdt.Text.Length == 0) { ThongBao.Show(NN.nn[77], NN.nn[125], "Do"); return false; }
            if (tb_DiaChi.Text.Length == 0) { ThongBao.Show(NN.nn[77], NN.nn[124], "Do"); return false; }
            return true;
        }


        // Cập nhật ngôn ngữ 
        private void CapNhatNN()
        {
            tbl_TenBang.Text = NN.nn[157];
            tbl_Id.Text = $"ID:{Id}";
            tbl_Ten.Text = $"{NN.nn[98]}:";
            tbl_Sdt.Text = $"{NN.nn[99]}:";
            tbl_DiaChi.Text = $"{NN.nn[86]}:";
            tbl_bt_huy.Text = NN.nn[64];
            tbl_bt_Them.Text = NN.nn[63];
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (KiemTra())
            {
                string lenhInsert = "Insert into NhanVien values ('" + Id + "', N'" + tb_Ten.Text + "', N'" + cbb_ChucVu.SelectedItem.ToString() + "', '" + tb_Sdt.Text + "', N'" + tb_DiaChi.Text + "', CAST(GETDATE() AS DATE))";

                modify.NhanViens(lenhInsert);
                ThongBao.Show(NN.nn[2], NN.nn[159], "Cam");
                this.Close();
            }
        }
    }
}
