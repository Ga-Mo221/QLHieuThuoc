using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLHieuThuoc.Model.DungNhanh
{
    class CapNhatNgonNgu
    {
        Modify modify = new Modify();
        public void UpdateDataBase(List<string> ngonngumoi)
        {
            DonBan(ngonngumoi);
            
            DonNhapHang(ngonngumoi);

            NhanVien(ngonngumoi);

            SanPham(ngonngumoi);
        }

        private void DonBan(List<string> ngonngumoi)
        {
            string updatedonbantienmat = "update DonBan set PHUONGTHUC = N'" + ngonngumoi[120] + "' where PHUONGTHUC = N'" + NN.nn[120] + "'";
            modify.ThucThi(updatedonbantienmat);
            string updatedonbanchuyenkhoan = "update DonBan set PHUONGTHUC = N'" + ngonngumoi[128] + "' where PHUONGTHUC = N'" + NN.nn[128] + "'";
            modify.ThucThi(updatedonbanchuyenkhoan);
        }

        private void DonNhapHang(List<string> ngonngumoi)
        {
            string updatedonbantienmat = "update DonNhapHang set PHUONGTHUC = N'" + ngonngumoi[120] + "' where PHUONGTHUC = N'" + NN.nn[120] + "'";
            modify.ThucThi(updatedonbantienmat);
            string updatedonbanchuyenkhoan = "update DonNhapHang set PHUONGTHUC = N'" + ngonngumoi[128] + "' where PHUONGTHUC = N'" + NN.nn[128] + "'";
            modify.ThucThi(updatedonbanchuyenkhoan);
        }

        private void NhanVien(List<string> ngonngumoi)
        {
            string updatenhanvienchucvu = "update NhanVien set CHUCVU = N'" + ngonngumoi[155] + "' where CHUCVU = N'" + NN.nn[155] + "'";
            modify.ThucThi(updatenhanvienchucvu);
            updatenhanvienchucvu = "update NhanVien set CHUCVU = N'" + ngonngumoi[156] + "' where CHUCVU = N'" + NN.nn[156] + "'";
            modify.ThucThi(updatenhanvienchucvu);
        }

        private void SanPham(List<string> ngonngumoi)
        {
            string updateloai = "update SanPham set LOAI = N'" + ngonngumoi[47] + "' where LOAI = N'" + NN.nn[47] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[48] + "' where LOAI = N'" + NN.nn[48] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[49] + "' where LOAI = N'" + NN.nn[49] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[50] + "' where LOAI = N'" + NN.nn[50] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[51] + "' where LOAI = N'" + NN.nn[51] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[52] + "' where LOAI = N'" + NN.nn[52] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[53] + "' where LOAI = N'" + NN.nn[53] + "'";
            modify.ThucThi(updateloai);

            updateloai = "update SanPham set LOAI = N'" + ngonngumoi[54] + "' where LOAI = N'" + NN.nn[54] + "'";
            modify.ThucThi(updateloai);
        }
    }
}
