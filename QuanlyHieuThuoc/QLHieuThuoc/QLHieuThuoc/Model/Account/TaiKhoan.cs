namespace QLHieuThuoc.Model.Account
{
    internal class TaiKhoan
    {

        private string TenTaiKhoan;
        private string MatKhau;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string tenTaiKhoan, string matKhau)
        {
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
        }

        public string TenTaiKhoan1 { get => TenTaiKhoan; set => TenTaiKhoan = value; }
        public string MatKhau1 { get => MatKhau; set => MatKhau = value; }
    }
}
