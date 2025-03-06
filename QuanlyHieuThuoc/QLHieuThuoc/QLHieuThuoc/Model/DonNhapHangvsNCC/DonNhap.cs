using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.DonNhapHangvsNCC
{
    class DonNhap
    {
        private string MaDonNhapHang;
        private string MaNhaCungCap;
        private DateTime NhayNhap;
        private string TongTien;
        private string PhuongThucThanhToan;

        public DonNhap()
        {
        }

        public DonNhap(string maDonNhapHang, string maNhaCungCap, DateTime nhayNhap, string tongTien, string phuongThucThanhToan)
        {
            MaDonNhapHang = maDonNhapHang;
            MaNhaCungCap = maNhaCungCap;
            NhayNhap = nhayNhap;
            TongTien = tongTien;
            PhuongThucThanhToan = phuongThucThanhToan;
        }

        public string MaDonNhapHang1 { get => MaDonNhapHang; set => MaDonNhapHang = value; }
        public string MaNhaCungCap1 { get => MaNhaCungCap; set => MaNhaCungCap = value; }
        public DateTime NhayNhap1 { get => NhayNhap; set => NhayNhap = value; }
        public string TongTien1 { get => TongTien; set => TongTien = value; }
        public string PhuongThucThanhToan1 { get => PhuongThucThanhToan; set => PhuongThucThanhToan = value; }
    }
}
