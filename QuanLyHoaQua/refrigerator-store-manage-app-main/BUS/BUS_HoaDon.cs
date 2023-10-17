using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entities;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_HD = new DAL_HoaDon();
        public DataTable getData()
        {
            return dal_HD.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return dal_HD.kiemtramatrung(ma);
        }
        public bool ThemHD(HoaDon hd)
        {
            return dal_HD.ThemHDB(hd);
        }
        public bool SuaHD(HoaDon hd)
        {
            return dal_HD.SuaHDB(hd);
        }
        public bool XoaHD(string ma)
        {
            return dal_HD.XoaHDB(ma);
        }
        public DataTable TimKiem(string mahdb, string manv, string makh)
        {
            return dal_HD.TimKiem(mahdb, manv, makh);
        }
    }
}
