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

namespace QLHieuThuoc.UserControls.ThongBaosp
{
    /// <summary>
    /// Interaction logic for NoiDungThongBao.xaml
    /// </summary>
    public partial class NoiDungThongBao : UserControl
    {
        private string noiDung;
        private int trangthai;
        public NoiDungThongBao()
        {
            InitializeComponent();
        }

        public string Content { get => noiDung; set => noiDung = value; }
        public int Status { get => trangthai; set => trangthai = value; }


        public void HienThi()
        {
            if (noiDung.Length > 0 && trangthai != null)
            {
                switch (trangthai)
                {
                    case 0:
                        kyhieu.Text = "❌";
                        kyhieu.Foreground = new SolidColorBrush(Colors.Red);
                        noidung.Text = noiDung;
                        break;
                    case 1:
                        kyhieu.Text = "⚠️";
                        kyhieu.Foreground = new SolidColorBrush(Colors.Orange);
                        noidung.Text = noiDung;
                        break;
                    case 2:
                        kyhieu.Text = "☠️";
                        kyhieu.Foreground = new SolidColorBrush(Colors.Red);
                        noidung.Text = noiDung;
                        break;
                    case 3:
                        kyhieu.Text = "⏳";
                        kyhieu.Foreground = new SolidColorBrush(Colors.Orange);
                        noidung.Text = noiDung;
                        break;
                    case 4:
                        kyhieu.Text = "⏳";
                        kyhieu.Foreground = new SolidColorBrush(Colors.Orange);
                        noidung.Text = noiDung;
                        break;
                }
            }
        }
    }
}
