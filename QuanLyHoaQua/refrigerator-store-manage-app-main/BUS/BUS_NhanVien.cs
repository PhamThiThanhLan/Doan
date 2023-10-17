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
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_NV = new DAL_NhanVien();
        public DataTable getData()
        {
            return dal_NV.getData();
        }
        public DataTable TimKiem(string manv, string tennv, string diachi)
        {
            return dal_NV.TimKiem(manv, tennv, diachi);
        }
        public int kiemtramatrung(string ma)
        {
            return dal_NV.kiemtramatrung(ma);
        }
        public bool ThemNV(NhanVien nv)
        {
            return dal_NV.ThemNV(nv);
        }
        public bool SuaNV(NhanVien nv)
        {
            return dal_NV.SuaNV(nv);
        }
        public bool XoaNV(string ma)
        {
            return dal_NV.XoaNV(ma);
        }
        public string valuecbbNV(string ma)
        {
            return dal_NV.valuecbbNV(ma);
        }
    }
}
