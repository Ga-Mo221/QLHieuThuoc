using QLHieuThuoc.forms.NhanVien;
using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.NhanVien;
using QLHieuThuoc.Model.sql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

namespace QLHieuThuoc.forms.FNhanVien
{
    /// <summary>
    /// Interaction logic for LichLam.xaml
    /// </summary>
    public partial class LichLam : UserControl
    {
        Modify modify = new Modify();
        CheckAccount checkAccount = new CheckAccount();
        private string idnv;


        public LichLam(string id)
        {
            InitializeComponent();
            HienThiLich();
            idnv = id;
            CapNhatNN();
        }

        private void TaoGridNgay()
        {
            // Xóa cấu trúc cũ nếu có
            gridngay.ColumnDefinitions.Clear();
            gridngay.RowDefinitions.Clear();

            // Tạo 7 cột
            for (int i = 0; i < 7; i++)
            {
                ColumnDefinition col = new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };
                gridngay.ColumnDefinitions.Add(col);
            }

            // Tạo 6 hàng
            for (int i = 0; i < 6; i++)
            {
                RowDefinition row = new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                gridngay.RowDefinitions.Add(row);
            }
        }


        private void HienThiLich()
        {
            if (gridngay != null)
            {
                gridngay.Children.Clear();
                TaoGridNgay();
            }

            DateTime today = DateTime.Today;
            int year = today.Year;
            int month = today.Month;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Xác định thứ của ngày 1 (chuyển từ Chủ Nhật -> Thứ Hai = 0 -> 6)
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = (startDay == 0) ? 6 : startDay - 1;  // Chuyển Chủ Nhật = 0 thành cột cuối (6)

            int dayNumber = 1;

            for (int row = 0; row < 6; row++) // Duyệt qua từng hàng
            {
                for (int col = 0; col < 7; col++) // Duyệt qua từng cột
                {
                    if (row == 0 && col < startDay) continue; // Bỏ qua ô trống trước ngày 1

                    if (dayNumber > daysInMonth) return; // Dừng nếu vượt quá số ngày của tháng

                    Button dayButton = CreateDayButton(dayNumber);

                    // Đặt vào đúng vị trí trong Grid
                    Grid.SetColumn(dayButton, col);
                    Grid.SetRow(dayButton, row);
                    
                    gridngay.Children.Add(dayButton);


                    if (dayNumber < DateTime.Now.Day)
                    {
                        dayButton.IsEnabled = false;
                    }
                    if (dayNumber == DateTime.Now.Day)
                    {
                        dayButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2895A"));
                    }


                        dayNumber++; // Tăng ngày
                }
            }
        }


        private Button CreateDayButton(int dayNumber)
        {
            Button button = new Button
            { 
                //Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(MaMau())),
                Background = new SolidColorBrush(Colors.White),
                BorderThickness = new Thickness(0),
                Padding = new Thickness(5),
                Margin = new Thickness(2),
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black)
            };
            // Tạo Grid với 2 hàng (RowDefinitions)
            Grid grid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch, // tôi muốn đặt chiều cao và chiều dài của grid = chiều cao và dài của button
                VerticalAlignment = VerticalAlignment.Stretch,
            };

            // Binding Width từ Button
            Binding widthBinding = new Binding("ActualWidth")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            };
            grid.SetBinding(FrameworkElement.WidthProperty, widthBinding);

            // Binding Height từ Button
            Binding heightBinding = new Binding("ActualHeight")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            };
            grid.SetBinding(FrameworkElement.HeightProperty, heightBinding);

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) }); // Hàng trên
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) }); // Hàng dưới

            // Tạo TextBlock để hiển thị ngày, đặt vào hàng đầu tiên
            TextBlock ngay = new TextBlock
            {
                Text = dayNumber.ToString(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black)
            };
            Grid.SetRow(ngay, 0); // Đặt vào hàng đầu tiên của Grid
            StackPanel s = stackPanel(dayNumber);
            Grid.SetRow(s, 1);

            // Thêm TextBlock vào Grid
            grid.Children.Add(ngay);
            grid.Children.Add(s);

            // Đặt Grid vào Border
            button.Content = grid;

            // Bắt sự kiện Click
            button.Click += (s, e) => dabutton_click(s,e, dayNumber);   

            return button;
        }




        private void dabutton_click(object s, RoutedEventArgs e, int dayNumber)
        {
            if (!checkAccount.check(idnv))
            {
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    Mo.OpenWindowWithBlur(mainWindow, new ThemLichLam(dayNumber));
                    HienThiLich();
                }
            }
        }


        private void CapNhatNN()
        {
            thu2.Text = NN.nn[210];
            thu3.Text = NN.nn[211];
            thu4.Text = NN.nn[212];
            thu5.Text = NN.nn[213];
            thu6.Text = NN.nn[214];
            thu7.Text = NN.nn[215];
            chunhat.Text = NN.nn[216];
        }


        private StackPanel stackPanel(int day)
        {
            StackPanel stp = new StackPanel
            {
            };

            string lenhSelect = "select L.ID as ID_LichLam, NV.TEN as TenNhanVien, L.NGAYLAM, L.TRANGTHAI from LichLam L join NhanVien NV on L.IDNV = NV.ID where day(L.NGAYLAM) = '"+day+"' and month(L.NGAYLAM) = month(GETDATE()) and year(L.NGAYLAM) = year(GETDATE())";
            List<Lichlam> ll = modify.lichlams(lenhSelect);
            if (ll != null)
            {
                foreach (Lichlam l in ll)
                {
                    Grid grid = new Grid()
                    {
                        Background = new SolidColorBrush(Colors.Aqua),
                    };

                    // Tạo TextBlock để hiển thị ngày, đặt vào hàng đầu tiên
                    TextBlock ngay = new TextBlock
                    {
                        Text = l.Idnv,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 13,
                        FontWeight = FontWeights.Bold,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#565656"))
                    };
                    grid.Children.Add(ngay);
                    
                    stp.Children.Add(grid);

                    if (l.TrangThai == "OK")
                    {
                        grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BAFFC2"));
                    }
                    else if (l.TrangThai == "NOTOK")
                    {
                        grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6868"));
                    }
                }
            }

            return stp;
        }

        private string MaMau()
        {
            List<string> colorCodes = new List<string>
            {
                "#F2EAED", "#CDF0E6", "#FBE9EE", "#C9E6EE", "#C7EACE", // Hàng đầu tiên

                "#FBEBF8", "#F8DFE6", "#FFEBE6", // Analogous Scheme

                "#D7E3FF", "#BED9B3", // Triadic Scheme

                "#CDF4E9", "#F9EBFF", // Tetradic Scheme

                "#F9FFE3", "#EAE4FF", // Square Scheme

                "#FFE8EA", "#FFEBE6", "#FFF0E3", "#FFF9EA", "#FFFFEF" // Neutral Scheme
            };

            Random rnd = new Random();
            int index = rnd.Next(colorCodes.Count); // Chọn một vị trí ngẫu nhiên trong danh sách
            return colorCodes[index]; // Trả về mã màu ngẫu nhiên
        }

    }
}
