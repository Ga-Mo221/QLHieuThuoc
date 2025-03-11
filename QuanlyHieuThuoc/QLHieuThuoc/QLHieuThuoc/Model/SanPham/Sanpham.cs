using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.SanPham
{
    public class Sanpham
    {
        private string MaSanPham;
        private string TenSanPham;
        private string LoaiSanPham;
        private int SoLuong;
        private string GiaNhap;
        private string GiaBan;
        private string ThanhPhan;
        private string HamLuong;
        private string CongDung;
        private string CachDung;
        private string ChuY;
        private DateTime HanSuDung;

        public Sanpham()
        {
        }

        public Sanpham(string maSanPham, string tenSanPham, string loaiSanPham, int soLuong, string giaNhap, string giaBan, string thanhPhan, string hamLuong, string congDung, string cachDung, string chuY, DateTime hanSuDung)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            LoaiSanPham = loaiSanPham;
            SoLuong = soLuong;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            ThanhPhan = thanhPhan;
            HamLuong = hamLuong;
            CongDung = congDung;
            CachDung = cachDung;
            ChuY = chuY;
            HanSuDung = hanSuDung;
        }

        public string MaSanPham1 { get => MaSanPham; set => MaSanPham = value; }
        public string TenSanPham1 { get => TenSanPham; set => TenSanPham = value; }
        public string LoaiSanPham1 { get => LoaiSanPham; set => LoaiSanPham = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public string GiaNhap1 { get => GiaNhap; set => GiaNhap = value; }
        public string GiaBan1 { get => GiaBan; set => GiaBan = value; }
        public string ThanhPhan1 { get => ThanhPhan; set => ThanhPhan = value; }
        public string HamLuong1 { get => HamLuong; set => HamLuong = value; }
        public string CongDung1 { get => CongDung; set => CongDung = value; }
        public string CachDung1 { get => CachDung; set => CachDung = value; }
        public string ChuY1 { get => ChuY; set => ChuY = value; }
        public DateTime HanSuDung1 { get => HanSuDung; set => HanSuDung = value; }
    }
}
