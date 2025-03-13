using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.NhanVien
{
    class ThoiGianLam
    {
        private string id;
        private string idnv;
        private DateTime ngayLam;
        private TimeSpan gioVao;
        private TimeSpan gioRa;
        private decimal tongGioLam;

        public ThoiGianLam()
        {
        }

        public ThoiGianLam(string id, string idnv, DateTime ngayLam, TimeSpan gioVao, TimeSpan gioRa, decimal tongGioLam)
        {
            this.id = id;
            this.idnv = idnv;
            this.ngayLam = ngayLam;
            this.gioVao = gioVao;
            this.gioRa = gioRa;
            this.tongGioLam = tongGioLam;
        }

        public string Id { get => id; set => id = value; }
        public string Idnv { get => idnv; set => idnv = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public TimeSpan GioVao { get => gioVao; set => gioVao = value; }
        public TimeSpan GioRa { get => gioRa; set => gioRa = value; }
        public decimal TongGioLam { get => tongGioLam; set => tongGioLam = value; }
    }
}
