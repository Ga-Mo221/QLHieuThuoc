using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.BanHang
{
    class ThongTinHoaDon
    {
        private string idhd;
        private DateTime ngayMua;
        private string tenNV;
        private string tenKH;
        private decimal tongTien;

        public ThongTinHoaDon()
        {
        }

        public ThongTinHoaDon(string idhd, DateTime ngayMua, string tenNV, string tenKH, decimal tongTien)
        {
            this.idhd = idhd;
            this.ngayMua = ngayMua;
            this.tenNV = tenNV;
            this.tenKH = tenKH;
            this.tongTien = tongTien;
        }

        public string Idhd { get => idhd; set => idhd = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
