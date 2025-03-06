using QLHieuThuoc.Model.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace QLHieuThuoc.Model
{
    public class ClickTextBox
    {
        public void GotF(TextBox TB, string content)
        {
            if (TB.Text == content)
            {
                TB.Text = "";
                TB.Foreground = Brushes.Black; // Đổi màu chữ khi nhập
            }
        }

        public void LostF(TextBox TB, string content)
        {
            if (string.IsNullOrWhiteSpace(TB.Text))
            {
                TB.Text = content;
                TB.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#565656")); // Trả lại màu xám
            }
        }
    }
}
