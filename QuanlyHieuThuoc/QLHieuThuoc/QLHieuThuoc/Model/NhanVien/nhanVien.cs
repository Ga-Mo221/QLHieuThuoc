using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.NhanVien
{
    class nhanVien
    {
        private string IdNhanVien;
        private string Ten;
        private string ChucVu;
        private string Sdt;
        private string DiaChi;
        private DateTime ngayThem;

        public nhanVien()
        {
        }

        public nhanVien(string idNhanVien, string ten, string chucVu, string sdt, string diaChi , DateTime ngayThem)
        {
            IdNhanVien = idNhanVien;
            Ten = ten;
            ChucVu = chucVu;
            Sdt = sdt;
            DiaChi = diaChi;
            this.ngayThem = ngayThem;
        }

        public string IdNhanVien1 { get => IdNhanVien; set => IdNhanVien = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public string ChucVu1 { get => ChucVu; set => ChucVu = value; }
        public string Sdt1 { get => Sdt; set => Sdt = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public DateTime NgayThem { get => ngayThem; set => ngayThem = value; }
    }
}
