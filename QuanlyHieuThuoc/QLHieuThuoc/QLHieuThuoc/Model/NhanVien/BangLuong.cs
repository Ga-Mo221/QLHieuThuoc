using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.NhanVien
{
    class BangLuong
    {
        private string id;
        private string idnv;
        private int thang;
        private int nam;
        private DateTime ngayTao;
        private decimal soGioLam;
        private decimal tienThuong;
        private decimal tienTroCap;
        private decimal luong;

        public BangLuong()
        {
        }

        public BangLuong(string id, string idnv, int thang, int nam, DateTime ngayTao, decimal soGioLam, decimal tienThuong, decimal tienTroCap, decimal luong)
        {
            this.id = id;
            this.idnv = idnv;
            this.thang = thang;
            this.nam = nam;
            this.ngayTao = ngayTao;
            this.soGioLam = soGioLam;
            this.tienThuong = tienThuong;
            this.tienTroCap = tienTroCap;
            this.luong = luong;
        }

        public string Id { get => id; set => id = value; }
        public string Idnv { get => idnv; set => idnv = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = value; }
        public decimal SoGioLam { get => soGioLam; set => soGioLam = value; }
        public decimal TienThuong { get => tienThuong; set => tienThuong = value; }
        public decimal TienTroCap { get => tienTroCap; set => tienTroCap = value; }
        public decimal Luong { get => luong; set => luong = value; }
    }
}
