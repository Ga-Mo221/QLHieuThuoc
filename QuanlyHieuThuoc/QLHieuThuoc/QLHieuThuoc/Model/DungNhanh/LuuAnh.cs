using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace QLHieuThuoc.Model.DungNhanh
{
    class LuuAnh
    {
        public void SaveGridAsImage(Border grid, string fileName, string folderPath)
        {
            try
            {
                // Xác định kích thước của Grid
                int width = (int)grid.ActualWidth;
                int height = (int)grid.ActualHeight;

                if (width == 0 || height == 0)
                {
                    MessageBox.Show("Lỗi: Kích thước Grid chưa xác định!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Đường dẫn đầy đủ của file
                string fullPath = Path.Combine(folderPath, $"{fileName}.png");

                // Render Grid thành Bitmap
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Pbgra32);
                renderBitmap.Render(grid);

                // Lưu ảnh thành PNG
                using (FileStream outStream = new FileStream(fullPath, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(outStream);
                }

                MessageBox.Show($"Lưu hình ảnh thành công tại:\n{fullPath}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
