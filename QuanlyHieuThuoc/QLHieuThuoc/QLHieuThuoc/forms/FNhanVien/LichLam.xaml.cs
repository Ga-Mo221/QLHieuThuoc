using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QLHieuThuoc.forms.FNhanVien
{
    /// <summary>
    /// Interaction logic for LichLam.xaml
    /// </summary>
    public partial class LichLam : UserControl
    {
        public LichLam()
        {
            InitializeComponent();
            HienThiLich();
        }

        private void HienThiLich()
        {

            DateTime today = DateTime.Today;
            int year = today.Year;
            int month = today.Month;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Xác định thứ của ngày 1 (chuyển từ Chủ Nhật -> Thứ Hai = 0 -> 6)
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = (startDay == 0) ? 6 : startDay - 1;  // Chuyển Chủ Nhật = 0 thành cột cuối (6)

            int dayNumber = 1;

            for (int row = 1; row < 7; row++) // Duyệt qua từng hàng
            {
                for (int col = 0; col < 7; col++) // Duyệt qua từng cột
                {
                    if (row == 1 && col < startDay) continue; // Bỏ qua ô trống trước ngày 1

                    if (dayNumber > daysInMonth) return; // Dừng nếu vượt quá số ngày của tháng

                    Border border = borderr(dayNumber);

                    // Đặt vào đúng vị trí trong Grid
                    Grid.SetColumn(border, col);
                    Grid.SetRow(border, row);
                    gridngay.Children.Add(border);

                    dayNumber++; // Tăng ngày
                }
            }
        }


        private Border borderr(int dayNumber)
        {
            // Tạo Border bao quanh
            Border border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Colors.Gray),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(5),
                Margin = new Thickness(2),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(MaMau()))
            };

            // Tạo Grid với 2 hàng (RowDefinitions)
            Grid grid = new Grid();
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

            // Thêm TextBlock vào Grid
            grid.Children.Add(ngay);

            // Đặt Grid vào Border
            border.Child = grid;
            return border;
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
