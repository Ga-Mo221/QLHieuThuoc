using QLHieuThuoc.forms;
using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.SanPham;
using QLHieuThuoc.Model.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace QLHieuThuoc.Model.DungNhanh
{
    public class LayThongBao
    {
        
        public void LayThongTin()
        {
            Modify modify = new Modify();
            string lenh = "select * from SanPham";
            List<Sanpham> sanphams = modify.SanPhams(lenh);
            if (ThongBaoSanPham.ThongBao != null) ThongBaoSanPham.ThongBao.Clear();


            foreach (var sanpham in sanphams)
            {
                KiemTraSoLuong(sanpham.SoLuong1, sanpham.TenSanPham1);
                KiemTraHanSuDung(sanpham.HanSuDung1, sanpham.TenSanPham1, sanpham.SoLuong1);
            }
        }

        private void KiemTraSoLuong(int soluong, string name)
        {
            if (soluong == 0)
            {
                string thongbao = $"{NN.nn[195]} '{name}' {NN.nn[196]}";
                Tb tb = new Tb(thongbao,0);
                ThongBaoSanPham.ThongBao.Add(tb);
            }
            else if (soluong <= 10)
            {
                string thongbao = $"{NN.nn[195]} '{name}' {NN.nn[197]} {soluong} {NN.nn[198]}";
                Tb tb = new Tb(thongbao, 1);
                ThongBaoSanPham.ThongBao.Add(tb);
            }
        }


        private void KiemTraHanSuDung(DateTime HSD, string name, int soluong)
        {
            DateTime ngayHienTai = DateTime.Now;

            if (HSD < ngayHienTai && soluong != 0)
            {
                string thongbao = $"{NN.nn[195]} '{name}' {NN.nn[199]}";
                Tb tb = new Tb(thongbao, 2);
                ThongBaoSanPham.ThongBao.Add(tb);
            }
            else if ((HSD - ngayHienTai).TotalDays <= 7 && soluong != 0) // Cảnh báo nếu sắp hết hạn trong 7 ngày
            {
                string thongbao = $"{NN.nn[195]} '{name}' {NN.nn[200]}";
                Tb tb = new Tb(thongbao, 3);
                ThongBaoSanPham.ThongBao.Add(tb);
            }
            else if ((HSD - ngayHienTai).TotalDays <= 30 && soluong != 0)
            {
                string thongbao = $"{NN.nn[195]} '{name}' {NN.nn[201]}";
                Tb tb = new Tb(thongbao, 4);
                ThongBaoSanPham.ThongBao.Add(tb);
            }
        }

        public void KiemTraThongBao()
        {
            if (ThongBaoSanPham.ThongBao.Count > 0)
            {
                ThongBaoSanPham.status = true;
            }
        }

        public void BatThongBao(Ellipse tb)
        {
            if (ThongBaoSanPham.status == true)
            {
                tb.Visibility = Visibility.Visible;
            }
            else
            {
                tb.Visibility = Visibility.Collapsed;
            }
        }

    }
}
