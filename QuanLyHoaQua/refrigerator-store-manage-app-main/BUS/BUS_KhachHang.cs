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
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_KH = new DAL_KhachHang();
        public DataTable getData()
        {
            return dal_KH.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return dal_KH.kiemtramatrung(ma);
        }
        public bool ThemKH(KhachHang kh)
        {
            return dal_KH.ThemKH(kh);
        }
        public bool SuaKH(KhachHang kh)
        {
            return dal_KH.SuaKH(kh);
        }
        public bool XoaKH(string ma)
        {
            return dal_KH.XoaKH(ma);
        }
        public string valuecbbKH(string ma)
        {
            return dal_KH.valuecbbKH(ma);
        }
    }
}
