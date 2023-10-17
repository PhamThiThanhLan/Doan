using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_HoaDon : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from HoaDonBan";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from HoaDonBan where MaHDB='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemHDB(HoaDon hd)
        {
            string sql = string.Format("Insert into HoaDonBan values('{0}','{1}', '{2}', '{3}')", hd.MaHDB, hd.NhanVien, hd.KhachHang, hd.NgayBan.ToString("yyyy/MM/dd"));
            thucthisql(sql);
            return true;
        }
        public bool SuaHDB(HoaDon hd)
        {
            string sql = string.Format("Update HoaDonBan Set MaNV = '{0}', MaKH = '{1}', NgayBan = '{2}' Where MaHDB = '{3}'", hd.NhanVien, hd.KhachHang, hd.NgayBan.ToString("yyyy/MM/dd"),  hd.MaHDB);
            thucthisql(sql);
            return true;
        }
        public bool XoaHDB(string ma)
        {
            string sql = "Delete from HoaDonBan where MaHDB = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TimKiem(string mahdb, string manv, string makh)
        {
            string sql = "Select * from HoaDonBan";
            string dk = "";
            if (mahdb.Trim() == "" && manv.Trim() == "" && makh.Trim() == "")
            {
                // 1
                return null;
            }
            if (mahdb.Trim() != "" && dk == "")
            {
                // 2
                dk += " MaHDB like '%" + mahdb.Trim() + "%' ";
            }
            if(manv.Trim() != "" && dk != "")
            {
                // 3
                dk += " and MaNV like '%" + manv.Trim() + "%' ";
            }
            if(manv.Trim() != "" && dk == "")
            {
                // 4
                dk += " MaNV like '%" + manv.Trim() + "%' ";
            }
            if(makh.Trim() != "" && dk != "")
            {
                // 5
                dk += " and MaKH like '%" + makh.Trim() + "%' ";
            }
            if(makh.Trim() != "" && dk == "")
            {
                dk += " MaKH like '%" + makh.Trim() + "%' ";
            }
            if(dk != "")
            {
                sql += " Where " + dk;
            }
            return connect.getData(sql);
        }
    }
}
