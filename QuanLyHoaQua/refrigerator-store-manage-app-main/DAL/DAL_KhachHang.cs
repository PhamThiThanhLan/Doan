using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_KhachHang : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from KhachHang");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from KhachHang where MaKH = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemKH(KhachHang kh)
        {
            string sql = string.Format("Insert into KhachHang values('{0}', N'{1}', N'{2}', '{3}')", kh.MaKH, kh.TenKH, kh.DiaChi, kh.SDT);
            thucthisql(sql);
            return true;
        }
        public bool XoaKH(string ma)
        {
            string sql = "Delete From KhachHang Where MaKH = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public bool SuaKH(KhachHang kh)
        {
            string sql = string.Format("Update KhachHang Set TenKH = N'{0}', DiaChi = N'{1}', SDT = '{2}' Where MaKH = '{3}'", kh.TenKH, kh.DiaChi, kh.SDT, kh.MaKH);
            thucthisql(sql);
            return true;
        }
        public string valuecbbKH(string ma)
        {
            string sql = "Select TenKH From KhachHang Where MaKH = '" + ma.Trim() + "'";
            return connect.valuecbb(ma, sql);
        }
    }
}
