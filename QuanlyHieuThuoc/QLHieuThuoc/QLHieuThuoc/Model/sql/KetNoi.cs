using System.Data.SqlClient;

namespace QLHieuThuoc.Model.sql
{
    class KetNoi
    {
        private static string ChuoiKetNoi = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\QLHieuThuoc\QuanlyHieuThuoc\QLHieuThuoc\QLHieuThuoc\QLHT.mdf;Integrated Security=True";

        public static SqlConnection GetSqlconnection()
        {
            return new SqlConnection(ChuoiKetNoi);
        }
    }
}
