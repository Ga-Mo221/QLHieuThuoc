namespace QLHieuThuoc.Model.BanHang
{
    class Chitietdonban
    {
        private string id;
        private string iddb;
        private string idsp;
        private int soLuong;
        private decimal giaBan;

        public Chitietdonban()
        {
        }

        public Chitietdonban(string id, string iddb, string idsp, int soLuong, decimal giaBan)
        {
            this.id = id;
            this.iddb = iddb;
            this.idsp = idsp;
            this.soLuong = soLuong;
            this.giaBan = giaBan;
        }

        public string Id { get => id; set => id = value; }
        public string Iddb { get => iddb; set => iddb = value; }
        public string Idsp { get => idsp; set => idsp = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
    }
}
