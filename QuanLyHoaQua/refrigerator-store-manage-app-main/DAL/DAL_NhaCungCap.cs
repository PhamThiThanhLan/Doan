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
    public class DAL_NhaCungCap : DBConnect
    {

        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from NhaCungCap");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from  NhaCungCap where NhaCungcapID = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemNCC(NhaCungCap kh)
        {
            string sql = string.Format("Insert into  NhaCungCap values('{0}', N'{1}', N'{2}', '{3}')", kh.NhaCungCapID, kh.TenNhaCungCap, kh.DiaChiNhaCungCap, kh.SoDienThoai);
            thucthisql(sql);
            return true;
        }
        public bool XoaNCC(string ma)
        {
            string sql = "Delete From  NhaCungCap Where NhaCungCapID = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public bool SuaNCC(NhaCungCap kh)
        {
            string sql = string.Format("Update  NhaCungCap Set TenNhaCungCap = N'{0}', DiaChiNhaCungCap = N'{1}', SoDienThoai = '{2}' Where NhaCungCapID = '{3}'", kh.TenNhaCungCap, kh.DiaChiNhaCungCap, kh.SoDienThoai, kh.NhaCungCapID);
            thucthisql(sql);
            return true;
        }
        public string valuecbbNCC(string ma)
        {
            string sql = "Select NhaCungCapID From  NhaCungCap Where  NhaCungCapID = '" + ma.Trim() + "'";
            return connect.valuecbb(ma, sql);
        }
    }
}
