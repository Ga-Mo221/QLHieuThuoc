namespace QLHieuThuoc.Model.BanHang
{
    public class Donban
    {
        private string id;
        private string idkh;
        private DateTime ngayMua;
        private decimal tongTien;
        private string phuongThuc;
        private string idnv;

        public Donban()
        {
        }

        public Donban(string id, string idkh, DateTime ngayMua, decimal tongTien, string phuongThuc , string idnv)
        {
            this.id = id;
            this.idkh = idkh;
            this.ngayMua = ngayMua;
            this.tongTien = tongTien;
            this.phuongThuc = phuongThuc;
            this.idnv = idnv;
        }

        public string Id { get => id; set => id = value; }
        public string Idkh { get => idkh; set => idkh = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public string PhuongThuc { get => phuongThuc; set => phuongThuc = value; }
        public string Idnv { get => idnv; set => idnv = value; }
    }
}
