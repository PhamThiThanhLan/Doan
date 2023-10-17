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
    public class DAL_ChiTietHDN: DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData(string ma)
        {
            return connect.getData("Select * from CHiTietHDN Where MaHDN = '" + ma.Trim() + "'");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from ChiTietHDN where MaHDN = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemCTHDB( ChiTietHDN CT)
        {
            string sql = string.Format("Insert into ChiTietHDN Values ('{0}', '{1}', '{2}', '{3}')", CT.MaHDN, CT.MaSanPham, CT.SoLuong, CT.DonGia);
            string TTCanHo = string.Format("Update SanPham Set TinhTrang = N'Hoạt động' Where MaSanPham = '" + CT.MaSanPham + "'");
            thucthisql(sql);
            thucthisql(TTCanHo);
            return true;
        }
        public bool SuaCTHDB(ChiTietHDN CT)
        {
            string sql = string.Format("Update ChiTietHDN Set  SoLuong ='{0}' , DonGia = '{1}'  Where MaSanPham = '{2}' AND MaHDN = '{3}'", CT.SoLuong, CT.DonGia, CT.MaSanPham, CT.MaHDN);
            thucthisql(sql);
            return true;
        }
        public bool XoaCTHDB(string ma, string mahd)
        {
            string sql = "Delete from ChiTietHDN where MaSanPham = '" + ma.Trim() + "' AND MAHDN = '" +mahd.Trim()+ "'";
            string TTCanHo = string.Format("Update SanPham Set TinhTrang = N'Hoạt động' Where MaSanPham = '" + ma.Trim() + "'");
            thucthisql(sql);
            thucthisql(TTCanHo);
            return true;
        }
    }
}
