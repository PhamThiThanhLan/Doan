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
    public class BUS_ChiTietHDB
    {
        DAL_ChiTietHDB dal_CTHDB = new DAL_ChiTietHDB();
        public DataTable getData(string ma)
        {
            return dal_CTHDB.getData(ma);
        }
        public int kiemtramatrung(string ma)
        {
            return dal_CTHDB.kiemtramatrung(ma);
        }
        public bool ThemCTHDB(ChiTietHoaDonBan CTHDB)
        {
            return dal_CTHDB.ThemCTHDB(CTHDB);
        }
        public bool SuaCTHDB(ChiTietHoaDonBan CTHDB)
        {
            return dal_CTHDB.SuaCTHDB(CTHDB);
        }
        public bool XoaCTHDB(string ma)
        {
            return dal_CTHDB.XoaCTHDB(ma);
        }
        public DataTable TimKiem(string mahd, string masp)
        {
            return dal_CTHDB.TimKiem(mahd, masp);
        }
        public double ThongKeDoanhThuTheoThang(string thang, string nam)
        {
            return dal_CTHDB.ThongKeDoanhThuTheoThang(thang, nam);
        }
        public double ThongKeDoanhThuTheoNam(string nam)
        {
            return dal_CTHDB.ThongKeDoanhThuTheoNam(nam);
        }
        public DataTable ThongKeHoaDonTheoThang(string thang, string nam)
        {
            return dal_CTHDB.ThongKeHoaDonTheoThang(thang, nam);
        }
        public DataTable ThongKeHoaDonTheoNam(string nam)
        {
            return dal_CTHDB.ThongKeHoaDonTheoNam(nam);
        }
    }
}
