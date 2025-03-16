using QLHieuThuoc.forms;
using System.Windows;
using System.Windows.Media.Effects;

namespace QLHieuThuoc.Model.DungNhanh
{
    public static class Mo
    {
        public static void OpenWindowWithBlur(Window parentWindow, Window childWindow)
        {
            if (parentWindow == null || childWindow == null) return;

            // Áp dụng hiệu ứng mờ cho cửa sổ cha
            parentWindow.Effect = new BlurEffect()
            {
                Radius = 10 // Độ mờ
            };

            // Lấy MainWindow để chỉnh Overlay (nếu có)
            if (parentWindow is MainWindow mainWindow)
            {
                mainWindow.Overlay.Visibility = Visibility.Visible;
                mainWindow.Overlay.Opacity = 0.5;
            }

            // Mở cửa sổ con
            childWindow.ShowDialog();

            // Khi đóng cửa sổ con, xóa hiệu ứng mờ
            parentWindow.Effect = null;
            if (parentWindow is MainWindow mainWin)
            {
                mainWin.Overlay.Visibility = Visibility.Collapsed;
            }
        }

        public static void moshow(Window parentWindow, Window childWindow)
        {
            if (parentWindow == null || childWindow == null) return;

            // Áp dụng hiệu ứng mờ cho cửa sổ cha
            parentWindow.Effect = new BlurEffect()
            {
                Radius = 10 // Độ mờ
            };

            // Lấy MainWindow để chỉnh Overlay (nếu có)
            if (parentWindow is MainWindow mainWindow)
            {
                mainWindow.Overlay.Visibility = Visibility.Visible;
                mainWindow.Overlay.Opacity = 0.5;
            }

            // Mở cửa sổ con
            childWindow.Show();

            // Khi đóng cửa sổ con, xóa hiệu ứng mờ
            parentWindow.Effect = null;
            if (parentWindow is MainWindow mainWin)
            {
                mainWin.Overlay.Visibility = Visibility.Collapsed;
            }
        }
    }
}
