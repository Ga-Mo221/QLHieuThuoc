using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.BanHang
{
    class ThongTinSanPhamHoaDon
    {
        private string tensp;
        private int soLuong;
        private decimal giaBan;

        public ThongTinSanPhamHoaDon()
        {
        }

        public ThongTinSanPhamHoaDon(string tensp, int soLuong, decimal giaBan)
        {
            this.tensp = tensp;
            this.soLuong = soLuong;
            this.giaBan = giaBan;
        }

        public string Tensp { get => tensp; set => tensp = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
    }
}
