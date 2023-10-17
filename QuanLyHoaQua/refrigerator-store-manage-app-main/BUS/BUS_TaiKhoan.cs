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
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dal_TK = new DAL_TaiKhoan();
        public DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return dal_TK.getData();
        }
        public int DangNhap(string tk, string mk)
        {
            return connect.DangNhap(tk, mk);
        }
        public int kiemtramatrung(string ma)
        {
            return dal_TK.kiemtramatrung(ma);
        }
        public bool KiemTraDangNhap(string userName, string password)
        {
            return dal_TK.KiemTraDangNhap(userName, password);
        }
        public bool ThemUser(TaiKhoan tk)
        {
            return dal_TK.ThemUser(tk);
        }
    }
}
