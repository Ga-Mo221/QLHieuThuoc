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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHieuThuoc.forms
{
    /// <summary>
    /// Interaction logic for CaiDat.xaml
    /// </summary>
    public partial class CaiDat : UserControl
    {
        private List<string> NgonNgus = new List<string>();
        CheckFileNN CF = new CheckFileNN();
        DocGhi dg = new DocGhi();

        public CaiDat()
        {
            InitializeComponent();
            LayTen();
            CapNhatNN();
        }

        private void LayTen()
        {
            NgonNgus = CF.GetNameFileTXT();
            cbb_NgonNgu.ItemsSource = NgonNgus;
            cbb_NgonNgu.SelectedItem = NN.NgonNguSetting;
        }

        private void cbb_NgonNgu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_NgonNgu.SelectedItem != NN.NgonNguSetting)
            {
                dg.SaveSetting($"{cbb_NgonNgu.SelectedItem.ToString()},gsdaf");
                ThongBao.Show(NN.nn[2], NN.nn[140], "Cam");
                System.Windows.Application.Current.Shutdown();
            }
        }


        private void CapNhatNN()
        {
            tbl_TenBang.Text = $"  {NN.nn[35]}";
            tbl_LoaiNgonNgu.Text = NN.nn[141];
        }
    }
}
