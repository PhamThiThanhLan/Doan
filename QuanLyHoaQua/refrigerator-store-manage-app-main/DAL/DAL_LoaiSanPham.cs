using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_LoaiSanPham : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from LoaiHoaQua");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from LoaiHoaQua where MaLoaiSanPham = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemDayCH(LoaiSanPham dch)
        {
            string sql = string.Format("Insert into LoaiHoaQua Values ('{0}';, N'{1}', N'{2}')", dch.MaLoaiSanPham, dch.TenLoaiSanPham, dch.MoTa);
            thucthisql(sql);
            return true;
        }
        public bool SuaDCH(LoaiSanPham dch)
        {
            string sql = "Update LoaiHoaQua Set TenLoaiSanPham = N'" + dch.TenLoaiSanPham + "', MoTa = N'" + dch.MoTa + "' Where MaLoaiSanPham = '" + dch.MaLoaiSanPham + "'";
            thucthisql(sql);
            return true;
        }
        public bool XoaDCH(string ma)
        {
            string sql = "Delete from LoaiHoaQua Where MaLoaiSanPham = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public string loadcbbDCH(string ma)
        {
            string sql = "Select TenLoaiSanPham From LoaiHoaQua Where MaLoaiSanPham = '" + ma.Trim() + "'";
            return connect.valuecbb(ma, sql);
        }
    }
}
