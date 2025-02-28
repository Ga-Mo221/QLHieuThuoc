using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model
{
    class NhanVien
    {
        private string IdNhanVien;
        private string Ten;
        private string ChucVu;
        private string Sdt;
        private string DiaChi;

        public NhanVien()
        {
        }

        public NhanVien(string idNhanVien, string ten, string chucVu, string sdt, string diaChi)
        {
            IdNhanVien = idNhanVien;
            Ten = ten;
            ChucVu = chucVu;
            Sdt = sdt;
            DiaChi = diaChi;
        }

        public string IdNhanVien1 { get => IdNhanVien; set => IdNhanVien = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public string ChucVu1 { get => ChucVu; set => ChucVu = value; }
        public string Sdt1 { get => Sdt; set => Sdt = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
    }
}
