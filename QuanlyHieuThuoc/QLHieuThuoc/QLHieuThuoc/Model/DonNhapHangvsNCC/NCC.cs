using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.DonNhapHangvsNCC
{
    class NCC
    {
        private string MaNhaCungCap;
        private string TenNhaCungCap;
        private string SoDienThoai;
        private string DiaChi;

        public NCC()
        {
        }

        public NCC(string maNhaCungCap, string tenNhaCungCap, string soDienThoai, string diaChi)
        {
            MaNhaCungCap = maNhaCungCap;
            TenNhaCungCap = tenNhaCungCap;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }

        public string MaNhaCungCap1 { get => MaNhaCungCap; set => MaNhaCungCap = value; }
        public string TenNhaCungCap1 { get => TenNhaCungCap; set => TenNhaCungCap = value; }
        public string SoDienThoai1 { get => SoDienThoai; set => SoDienThoai = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
    }
}
