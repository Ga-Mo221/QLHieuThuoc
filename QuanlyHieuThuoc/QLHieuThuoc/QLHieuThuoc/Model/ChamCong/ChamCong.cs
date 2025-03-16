using QLHieuThuoc.Model.DungNhanh;
using QLHieuThuoc.Model.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHieuThuoc.Model.ChamCong
{
    class ChamCong
    {
        TaoMaNgauNhien taoma = new TaoMaNgauNhien();
        Modify modify = new Modify();


        public void GioVao()
        {
            GhiGio.GioVao = DateTime.Now.TimeOfDay;
        }

        public void GioRa()
        {
            GhiGio.GioRa = DateTime.Now.TimeOfDay;
        }



        public void ChapCong(string idnv)
        {
            string id = taoma.TaoMa(10);

            string lenh = "INSERT INTO ThoiGianLam VALUES " +
              "('" + id + "', '" + idnv + "', CAST(GETDATE() AS DATE), " +
              "CAST('" + GhiGio.GioVao.ToString(@"hh\:mm") + "' AS TIME), " +
              "CAST('" + GhiGio.GioRa.ToString(@"hh\:mm") + "' AS TIME), " +
              "'" + TongGio(GhiGio.GioVao, GhiGio.GioRa) + "')";
            modify.ThucThi(lenh);
        }


        private decimal TongGio(TimeSpan giovao, TimeSpan giora)
        {
            TimeSpan tongGio = giora - giovao; // Lấy tổng thời gian dạng TimeSpan
            return (decimal)tongGio.TotalHours; // Chuyển đổi sang decimal với đơn vị giờ
        }
    }

    public static class GhiGio
    {
        public static TimeSpan GioVao = TimeSpan.Zero;
        public static TimeSpan GioRa = TimeSpan.Zero;
    }
}
