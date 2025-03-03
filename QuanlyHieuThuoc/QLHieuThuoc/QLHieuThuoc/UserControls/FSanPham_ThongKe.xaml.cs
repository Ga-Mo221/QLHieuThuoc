using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;


namespace QLHieuThuoc.UserControls
{
    /// <summary>
    /// Interaction logic for FSanPham_ThongKe.xaml
    /// </summary>
    public partial class FSanPham_ThongKe : UserControl
    {
        private string title;
        private string value;

        public FSanPham_ThongKe()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return title; }
            set { title = value; tbl_chu.Text = value; }
        }
        public string Value
        {
            get => value; set { this.value = value; tbl_so.Text = value; }
        }
    }
}
