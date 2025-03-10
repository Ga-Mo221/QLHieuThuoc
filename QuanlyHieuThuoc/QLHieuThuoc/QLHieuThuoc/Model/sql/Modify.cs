﻿using QLHieuThuoc.forms;
using QLHieuThuoc.Model.Account;
using QLHieuThuoc.Model.BanHang;
using QLHieuThuoc.Model.DonNhapHangvsNCC;
using QLHieuThuoc.Model.SanPham;
using System.Data.SqlClient;
using System.Windows.Data;

namespace QLHieuThuoc.Model.sql
{
    class Modify
    {
        public Modify()
        {
        }


        SqlCommand sqlConmand; // dùng để thực hiện các câu truy vấn của sql
        SqlDataReader dataReader; // dùng để đọc dữ liệu trong bản


        // check Tài Khoản
        public List<TaiKhoan> TaiKhoans(string LenhTruyVan)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2)));
                }

                sqlConnection.Close();
            }

            return taiKhoans;
        }

        // check Nhân Viên
        public List<nhanVien> NhanViens(string LenhTruyVan)
        {
            List<nhanVien> nhanViens = new List<nhanVien>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    nhanViens.Add(new nhanVien(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4)));
                }

                sqlConnection.Close();
            }

            return nhanViens;
        }

        // Check Sản PHẩm
        public List<Sanpham> SanPhams(string LenhTruyVan)
        {
            List<Sanpham> sanphams = new List<Sanpham>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    sanphams.Add(new Sanpham(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3).ToString(), dataReader.GetDecimal(4).ToString(), dataReader.GetDecimal(5).ToString(), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8), dataReader.GetString(9), dataReader.GetString(10), dataReader.GetDateTime(11)));
                }

                sqlConnection.Close();
            }

            return sanphams;
        }

        // check Nhà Cung Cấp
        public List<NCC> NhaCungCaps(string LenhTruyVan)
        {
            List<NCC> NhaCungCaps = new List<NCC>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    NhaCungCaps.Add(new NCC(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3)));
                }

                sqlConnection.Close();
            }

            return NhaCungCaps;
        }

        public List<DonNhap> DonNhaps(string LenhTruyVan)
        {
            List<DonNhap> donNhaps = new List<DonNhap>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    donNhaps.Add(new DonNhap(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetDateTime(2), dataReader.GetDecimal(3).ToString(), dataReader.GetString(4)));
                }

                sqlConnection.Close();
            }

            return donNhaps;
        }

        // check Chi tiết đơn nhập
        public List<chiTietDonNhap> ChiTietDonNhaps(string LenhTruyVan)
        {
            List<chiTietDonNhap> chiTietDonNhaps = new List<chiTietDonNhap>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    chiTietDonNhaps.Add(new chiTietDonNhap(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3).ToString(), dataReader.GetDecimal(4).ToString()));
                }

                sqlConnection.Close();
            }

            return chiTietDonNhaps;
        }

        // check đơn bán hàng
        public List<Donban> DonBans(string LenhTruyVan)
        {
            List<Donban> donbans = new List<Donban>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    donbans.Add(new Donban(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetDateTime(2), dataReader.GetDecimal(3), dataReader.GetString(4)));
                }

                sqlConnection.Close();
            }

            return donbans;
        }

        // check chi tiết đơn bán hàng
        public List<Chitietdonban> ChiTietDonBans(string LenhTruyVan)
        {
            List<Chitietdonban> chitietdonbans = new List<Chitietdonban>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    chitietdonbans.Add(new Chitietdonban(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetDecimal(4)));
                }

                sqlConnection.Close();
            }

            return chitietdonbans;
        }


        // check khách hàng
        public List<Khachhang> KhachHangs(string LenhTruyVan)
        {
            List<Khachhang> khachhangs = new List<Khachhang>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    khachhangs.Add(new Khachhang(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetDateTime(4)));
                }

                sqlConnection.Close();
            }

            return khachhangs;
        }







        // Thực hiện lệnh
        public void ThucThi(string LenhTruyVan)
        {
            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                sqlConmand.ExecuteNonQuery(); // thực thi câu truy vấn

                sqlConnection.Close();
            }
        }
    }
}
