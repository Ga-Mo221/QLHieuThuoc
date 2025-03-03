namespace QLHieuThuoc.Model.Account
{
    internal class TaiKhoan
    {

        private string TenTaiKhoan;
        private string MatKhau;
        private string MaNhanVien;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string tenTaiKhoan, string matKhau, string maNhanVien)
        {
            this.TenTaiKhoan = tenTaiKhoan;
            this.MatKhau = matKhau;
            this.MaNhanVien = maNhanVien;
        }

        public string TenTaiKhoan1 { get => TenTaiKhoan; set => TenTaiKhoan = value; }
        public string MatKhau1 { get => MatKhau; set => MatKhau = value; }
        public string MaNhanVien1 { get => MaNhanVien; set => MaNhanVien = value; }
    }
}
