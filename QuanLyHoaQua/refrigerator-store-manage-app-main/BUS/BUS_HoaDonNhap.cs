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
    public class BUS_HoaDonNhap
    {
       DAL_HoaDonNhap dal = new DAL_HoaDonNhap();
        public DataTable getData()
        {
            return dal.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return dal.kiemtramatrung(ma);
        }
        public bool ThemKH(HoaDonNhap kh)
        {
            return dal.ThemHDB(kh);
        }
        public bool SuaKH(HoaDonNhap kh)
        {
            return dal.SuaHDB(kh);
        }
        public bool XoaKH(string ma)
        {
            return dal.XoaHDB(ma);
        }
    }
}
