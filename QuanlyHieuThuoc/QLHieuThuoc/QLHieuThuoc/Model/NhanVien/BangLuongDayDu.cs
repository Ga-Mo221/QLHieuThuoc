using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.NhanVien
{
    class BangLuongDayDu
    {
        private string idNhanVien;
        private string ten;
        private string chucVu;
        private string sdt;
        private string diaChi;
        private DateTime ngayThem;
        private string idLuong;
        private int thang;
        private int nam;
        private DateTime ngayTao;
        private decimal soGioLam;
        private decimal tienThuong;
        private decimal tienTroCap;
        private decimal luong;

        public BangLuongDayDu()
        {
        }

        public BangLuongDayDu(string idNhanVien, string ten, string chucVu, string sdt, string diaChi, DateTime ngayThem, string idLuong, int thang, int nam, DateTime ngayTao, decimal soGioLam, decimal tienThuong, decimal tienTroCap, decimal luong)
        {
            this.idNhanVien = idNhanVien;
            this.ten = ten;
            this.chucVu = chucVu;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.ngayThem = ngayThem;
            this.idLuong = idLuong;
            this.thang = thang;
            this.nam = nam;
            this.ngayTao = ngayTao;
            this.soGioLam = soGioLam;
            this.tienThuong = tienThuong;
            this.tienTroCap = tienTroCap;
            this.luong = luong;
        }

        public string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string Ten { get => ten; set => ten = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public DateTime NgayThem { get => ngayThem; set => ngayThem = value; }
        public string IdLuong { get => idLuong; set => idLuong = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = value; }
        public decimal SoGioLam { get => soGioLam; set => soGioLam = value; }
        public decimal TienThuong { get => tienThuong; set => tienThuong = value; }
        public decimal TienTroCap { get => tienTroCap; set => tienTroCap = value; }
        public decimal Luong { get => luong; set => luong = value; }
    }
}
