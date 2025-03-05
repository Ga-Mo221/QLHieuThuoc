using QLHieuThuoc.forms;
using QLHieuThuoc.Model.Account;
using QLHieuThuoc.Model.DonNhapHangvsNCC;
using QLHieuThuoc.Model.SanPham;
using System.Data.SqlClient;

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
