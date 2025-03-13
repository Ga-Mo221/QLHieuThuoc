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

namespace QLHieuThuoc.UserControls.NhanVien
{
    /// <summary>
    /// Interaction logic for ThoiGianLamCuaNhanVien.xaml
    /// </summary>
    public partial class ThoiGianLamCuaNhanVien : UserControl
    {
        private DateTime ngaylam;
        private TimeSpan giovao;
        private TimeSpan giora;
        private decimal tonggio;

        public ThoiGianLamCuaNhanVien()
        {
            InitializeComponent();
        }


        public DateTime NgayLam
        {
            get { return ngaylam; }
            set { ngaylam = value; tbl_NgayLam.Text = ngaylam.ToString("dd/MM/yyyy"); }
        }
        public TimeSpan GioVao
        {
            get { return giovao; }
            set { giovao = value; tbl_GioVao.Text = giovao.ToString(@"hh\:mm"); }
        }
        public TimeSpan GioRa
        {
            get { return giora; }
            set { giora = value; tbl_GioRa.Text = giora.ToString(@"hh\:mm"); }
        }
        public decimal TongGio
        {
            get { return tonggio; }
            set { tonggio = value; tbl_TongGio.Text = tonggio.ToString(); }
        }

    }
}
