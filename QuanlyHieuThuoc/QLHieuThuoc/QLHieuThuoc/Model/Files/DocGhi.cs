using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace QLHieuThuoc.Model.Files
{
    class DocGhi
    {
        // Đọc file Ngôn Ngữ
        public void Ngongu(List<string> ngonngu, string tenNN)
        {
            // lấy đường dẫn
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NgonNgu");
            string filePath = Path.Combine(folderPath, tenNN + ".txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                foreach (string line in lines)
                {
                    ngonngu.Add(line);
                }
            }
            else
            {
                MessageBox.Show($"không tồn tại {filePath} để đọc", "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Đọc file Setting
        public void Setting()
        {
            // lấy đường dẫn
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setting");
            string filePath = Path.Combine(folderPath, "Setting.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                foreach (string line in lines)
                {
                    // tách thông tin từ dòng
                    string[] parts = line.Split(new[] { "|" }, StringSplitOptions.None);

                    NN.NgonNguSetting = parts[0];
                    NN.folderPathLuong = parts[1];
                    NN.folderPathHoaDon = parts[2];
                }
            }
            else
            {
                MessageBox.Show($"không tồn tại {filePath} để đọc", "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Ghi file Setting
        public void SaveSetting(string newSetting)
        {
            // Lấy đường dẫn
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setting");
            string filePath = Path.Combine(folderPath, "Setting.txt");

            try
            {
                // Kiểm tra nếu thư mục chưa tồn tại thì tạo mới
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Ghi nội dung vào file (Ghi đè nội dung cũ)
                File.WriteAllText(filePath, newSetting, Encoding.UTF8);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi file: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

    public static class NN
    {
        public static List<string> nn = new List<string>();
        public static string NgonNguSetting;
        public static string TileManHinh;
        public static string folderPathLuong;
        public static string folderPathHoaDon;
    }
}