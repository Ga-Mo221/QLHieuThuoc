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
using QLHieuThuoc.forms;
using QLHieuThuoc.Model.Files;

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
                    ThongBao.Show(NN.nn[77], NN.nn[217], "Do");
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

                ThongBao.Show(NN.nn[2], $"{NN.nn[218]}\n{fullPath}", "Cam");
            }
            catch (Exception ex)
            {
                ThongBao.Show(NN.nn[77], NN.nn[219] + ex.Message, "Do");
            }
        }

    }
}
