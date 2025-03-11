using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace QLHieuThuoc.UserControls
{
    /// <summary>
    /// Interaction logic for FSanPham_Loai.xaml
    /// </summary>
    public partial class FSanPham_Loai : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Click;

        private string loaiSanPham;
        private string soLuong;
        private string maMau;
        private string sourceImg;

        public FSanPham_Loai()
        {
            InitializeComponent();
            DataContext = this; // Gán DataContext để Binding hoạt động
        }

        public void UpdateBackground(string mamau1)
        {
            if (string.IsNullOrWhiteSpace(mamau1)) return;

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0.5, 0);
            gradientBrush.EndPoint = new Point(0.5, 1);

            GradientStop stop1 = new GradientStop((Color)ColorConverter.ConvertFromString(mamau1), 0);
            GradientStop stop2 = new GradientStop(Colors.White, 1);

            gradientBrush.GradientStops.Add(stop1);
            gradientBrush.GradientStops.Add(stop2);

            butoon.Background = gradientBrush;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LOAISANPHAM
        {
            get => loaiSanPham;
            set
            {
                loaiSanPham = value;
                tbl_Loai.Text = value;
                OnPropertyChanged(nameof(LOAISANPHAM));
            }
        }

        public string SOLUONG
        {
            get => soLuong;
            set
            {
                soLuong = value;
                tbl_soluong.Text = value;
                OnPropertyChanged(nameof(SOLUONG));
            }
        }

        public string MAMAU
        {
            get => maMau;
            set
            {
                maMau = value;
                OnPropertyChanged(nameof(MAMAU));
                UpdateBackground(maMau);
            }
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

        private void butoon_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
