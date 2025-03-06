using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.DonNhapHangvsNCC
{
    class chiTietDonNhap
    {
        private string maChiTietDonNhap;
        private string maDonNhap;
        private string maSanPham;
        private string soluong;
        private string giaNhap;

        public chiTietDonNhap()
        {
        }

        public chiTietDonNhap(string maChiTietDonNhap, string maDonNhap, string maSanPham, string soluong, string giaNhap)
        {
            this.maChiTietDonNhap = maChiTietDonNhap;
            this.maDonNhap = maDonNhap;
            this.maSanPham = maSanPham;
            this.soluong = soluong;
            this.giaNhap = giaNhap;
        }

        public string MaChiTietDonNhap { get => maChiTietDonNhap; set => maChiTietDonNhap = value; }
        public string MaDonNhap { get => maDonNhap; set => maDonNhap = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string Soluong { get => soluong; set => soluong = value; }
        public string GiaNhap { get => giaNhap; set => giaNhap = value; }
    }
}
