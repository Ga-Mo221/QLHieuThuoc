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
    /// Interaction logic for LuongNhanVien.xaml
    /// </summary>
    public partial class LuongNhanVien : UserControl
    {
        public event EventHandler<string> Click;
        private string mot;
        private string hai;
        private int ba;
        private decimal bon;
        private decimal nam;


        public LuongNhanVien()
        {
            InitializeComponent();
        }

        public string ID
        {
            get {  return mot; }
            set { mot = value; Mot.Text = mot; }
        }
        public string TEN
        {
            get { return hai; }
            set { hai = value; Hai.Text = hai; }
        }
        public int THANG
        {
            get { return ba; }
            set { ba = value; Ba.Text = ba.ToString(); }
        }
        public decimal TONGGIOLAM
        {
            get { return bon; }
            set { bon = value; Bon.Text = bon.ToString(); }
        }
        public decimal LUONG
        {
            get { return nam; }
            set { nam = value; Nam.Text = nam.ToString(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = mot;
            Click?.Invoke(this, id);
        }
    }
}
