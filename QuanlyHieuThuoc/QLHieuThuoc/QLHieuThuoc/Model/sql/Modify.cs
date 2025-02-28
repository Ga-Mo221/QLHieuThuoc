using QLHieuThuoc.Model.Account;
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
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }

                sqlConnection.Close();
            }

            return taiKhoans;
        }

        // check Nhân Viên
        public List<NhanVien> NhanViens(string LenhTruyVan)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();

            using (SqlConnection sqlConnection = KetNoi.GetSqlconnection())
            {
                sqlConnection.Open();

                sqlConmand = new SqlCommand(LenhTruyVan, sqlConnection);
                dataReader = sqlConmand.ExecuteReader();
                while (dataReader.Read())
                {
                    nhanViens.Add(new NhanVien(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4)));
                }

                sqlConnection.Close();
            }

            return nhanViens;
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
