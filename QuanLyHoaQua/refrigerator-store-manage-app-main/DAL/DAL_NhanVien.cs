using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_NhanVien : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from NhanVien");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from NhanVien where MaNV = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public DataTable TimKiem(string manv, string tennv, string diachi)
        {
            string sql = "Select * from NhanVien";
            string dk = "";
            if (manv.Trim() == "" && tennv.Trim() == "" && diachi.Trim() == "")
            {
                // 1
                return null;
            }
            if (manv.Trim() != "" && dk == "")
            {
                // 2
                dk += " MaNV like '%" + manv.Trim() + "%' ";
            }
            if (tennv.Trim() != "" && dk != "")
            {
                // 3
                dk += " and TenNV like N'%" + tennv.Trim() + "%' ";
            }
            if (tennv.Trim() != "" && dk == "")
            {
                // 4
                dk += " TenNV like N'%" + tennv.Trim() + "%' ";
            }
            if(diachi.Trim() != "" && dk != "")
            {
                // 5
                dk += " and DiaChi like N'%" + diachi.Trim() + "%' ";
            }
            if(diachi.Trim() != "" && dk == "")
            {
                // 6
                dk += " DiaChi like N'%" + diachi.Trim() + "%' ";
            }
            if (dk != "")
            {
                sql += " WHERE " + dk;
            }
            return connect.getData(sql);
        }
        public bool ThemNV(NhanVien nv)
        {
            string sql = string.Format("Insert into NhanVien values('{0}', N'{1}', N'{2}', '{3}')", nv.MaNV, nv.TenNV, nv.DiaChi, nv.SDT);
            thucthisql(sql);
            return true;
        }
        public bool XoaNV(string ma)
        {
            string sql = "Delete From NhanVien Where MaNV = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public bool SuaNV(NhanVien nv)
        {
            string sql = string.Format("Update NhanVien Set TenNV = N'{0}', DiaChi = N'{1}', SDT = '{2}' Where MaNV = '{3}'", nv.TenNV, nv.DiaChi, nv.SDT, nv.MaNV);
            thucthisql(sql);
            return true;
        }
        public string valuecbbNV(string ma)
        {
            string sql = "Select TenNV From NhanVien Where MaNV = '" + ma.Trim() + "'";
            return connect.valuecbb(ma, sql);
        }
    }
}
