using QLHieuThuoc.forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLHieuThuoc.Model.Files
{
    class CheckFileNN
    {
        public List<string> GetNameFileTXT()
        {
            // Tạo danh sách chứa tên file (không có đuôi .txt)
            List<string> fileNames = new List<string>();
            // Đường dẫn thư mục
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NgonNgu");

            // Kiểm tra nếu thư mục tồn tại
            if (Directory.Exists(folderPath))
            {
                // Lấy danh sách file .txt trong thư mục
                string[] files = Directory.GetFiles(folderPath, "*.txt");

                

                foreach (string file in files)
                {
                    fileNames.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            else
            {
                ThongBao.Show(NN.nn[77], "Thư mục không tồn tại!", "Do");
            }
            return fileNames;
        }
    }
}
