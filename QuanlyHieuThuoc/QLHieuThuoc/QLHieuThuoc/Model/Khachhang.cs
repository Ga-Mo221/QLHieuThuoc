namespace QLHieuThuoc.Model.BanHang
{
    public class Khachhang
    {
        private string id;
        private string ten;
        private string sdt;
        private int diem;
        private DateTime ngayThem;

        public Khachhang()
        {
        }

        public Khachhang(string id, string ten, string sdt, int diem, DateTime ngayThem)
        {
            this.id = id;
            this.ten = ten;
            this.sdt = sdt;
            this.diem = diem;
            this.ngayThem = ngayThem;
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public int Diem { get => diem; set => diem = value; }
        public DateTime NgayThem { get => ngayThem; set => ngayThem = value; }
    }
}
