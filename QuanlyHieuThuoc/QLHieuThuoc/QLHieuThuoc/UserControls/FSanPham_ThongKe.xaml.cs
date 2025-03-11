using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace QLHieuThuoc.UserControls
{
    /// <summary>
    /// Interaction logic for FSanPham_ThongKe.xaml
    /// </summary>
    public partial class FSanPham_ThongKe : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string title;
        private string value;
        private string sourceImg;

        public FSanPham_ThongKe()
        {
            InitializeComponent();
            this.DataContext = this; // Thêm dòng này
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
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SourceImg
        {
            get => sourceImg;
            set
            {
                sourceImg = value;
                OnPropertyChanged(nameof(SourceImg));
                OnPropertyChanged(nameof(SourceImgBitmap));
            }
        }

        public BitmapImage SourceImgBitmap
        {
            get
            {
                if (string.IsNullOrEmpty(SourceImg))
                    return null;
                return new BitmapImage(new Uri(SourceImg, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
