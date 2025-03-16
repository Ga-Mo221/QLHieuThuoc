using QLHieuThuoc.Model.Files;
using QLHieuThuoc.Model.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLHieuThuoc.Model.DungNhanh
{
    class CheckAccount
    {
        Modify modify = new Modify();
        public bool check(string IdNv)
        {
            string lenh = "select * from NhanVien where CHUCVU = N'" + NN.nn[156] + "' and ID = '" + IdNv + "'";
            if (modify.NhanViens(lenh).Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
