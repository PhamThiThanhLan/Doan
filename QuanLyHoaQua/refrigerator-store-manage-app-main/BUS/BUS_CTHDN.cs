using DAL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CTHDN
    {
        DAL_ChiTietHDN dal_CTHDB = new DAL_ChiTietHDN();
        public DataTable getData(string ma)
        {
            return dal_CTHDB.getData(ma);
        }
        public int kiemtramatrung(string ma)
        {
            return dal_CTHDB.kiemtramatrung(ma);
        }
        public bool ThemCTHDB(ChiTietHDN CTHDB)
        {
            return dal_CTHDB.ThemCTHDB(CTHDB);
        }
        public bool SuaCTHDB(ChiTietHDN CTHDB)
        {
            return dal_CTHDB.SuaCTHDB(CTHDB);
        }
        public bool XoaCTHDB(string ma, string mahd)
        {
            return dal_CTHDB.XoaCTHDB(ma, mahd);
        }
    }
}
