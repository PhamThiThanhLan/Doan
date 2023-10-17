using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDonNhap: DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from HoaDonNhap";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from HoaDonNhap where MaHDN='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemHDB(HoaDonNhap hd)
        {
            string sql = string.Format("Insert into HoaDonNhap values('{0}','{1}', '{2}', '{3}')", hd.MaHDN, hd.MaNV, hd.NgayNhap, hd.NhaCungCapID);
            thucthisql(sql);
            return true;
        }
        public bool SuaHDB(HoaDonNhap hd)
        {
            string sql = string.Format("Update HoaDonNhap Set MaNV = '{0}', NhaCungCapID = '{1}', NgayNhap = '{2}' Where MaHDN = '{3}'", hd.MaNV, hd.NhaCungCapID, hd.NgayNhap, hd.MaHDN);
            thucthisql(sql);
            return true;
        }
        public bool XoaHDB(string ma)
        {
            string sql = "Delete from HoaDonNhap where MaHDN = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
    }
}
