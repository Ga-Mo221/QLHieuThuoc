using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.DungNhanh
{
    public class Tb
    {
        private string content;
        private int status; // 0 hết, 1 sắp hết ,  2 hết hạn, 3 sắp hết hạn, 4 còn lại 1 tháng

        public Tb()
        {
        }

        public Tb(string content, int status)
        {
            this.content = content;
            this.status = status;
        }

        public string Content { get => content; set => content = value; }
        public int Status { get => status; set => status = value; }
    }


    public static class ThongBaoSanPham
    {
        public static List<Tb> ThongBao = new List<Tb>();
        public static bool status = false; // da xem hay chua
    }
}
