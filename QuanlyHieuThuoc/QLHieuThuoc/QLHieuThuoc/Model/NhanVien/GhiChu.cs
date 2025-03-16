using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.NhanVien
{
    class GhiChu
    {
        private string id;
        private DateTime ngayLam;
        private string noiDung;

        public GhiChu()
        {
        }

        public GhiChu(string id, DateTime ngayLam, string noiDung)
        {
            this.id = id;
            this.ngayLam = ngayLam;
            this.noiDung = noiDung;
        }

        public string Id { get => id; set => id = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
    }
}
