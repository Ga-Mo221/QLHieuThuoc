using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.NhanVien
{
    class Lichlam
    {
        private string id;
        private string idnv;
        private DateTime ngayLam;
        private string trangThai;

        public Lichlam()
        {
        }

        public Lichlam(string id, string idnv, DateTime ngayLam, string trangThai)
        {
            this.id = id;
            this.idnv = idnv;
            this.ngayLam = ngayLam;
            this.trangThai = trangThai;
        }

        public string Id { get => id; set => id = value; }
        public string Idnv { get => idnv; set => idnv = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
