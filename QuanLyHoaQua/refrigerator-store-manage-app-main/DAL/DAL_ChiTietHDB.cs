using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_ChiTietHDB : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData(string ma)
        {
            return connect.getData("Select * from CHiTietHDB Where MaHDB = '" + ma.Trim() + "'");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from ChiTietHDB where MaHDB = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemCTHDB(ChiTietHoaDonBan CT)
        {
            string sql = string.Format("Insert into ChiTietHDB Values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", CT.MaHDB, CT.MaSanPham, CT.DonGia, CT.GiamGia, CT.ThanhTien, CT.SoLuongBan);
            string TTCanHo = string.Format("Update SanPham Set TinhTrang = N'Hoạt động' Where MaSanPham = '" + CT.MaSanPham + "'");
            thucthisql(sql);
            thucthisql(TTCanHo);
            return true;
        }
        public bool SuaCTHDB(ChiTietHoaDonBan CT)
        {
            string sql = string.Format("Update ChiTietHDB Set DonGia = '{0}', GiamGia ='{1}' , ThanhTien = '{2}', SoLuongBan = '{3}' Where MaSanPham = '{4}' AND MaHDB = '{5}'", CT.DonGia, CT.GiamGia, CT.ThanhTien,CT.SoLuongBan, CT.MaSanPham, CT.MaHDB);
            thucthisql(sql);
            return true;
        }
        public bool XoaCTHDB(string ma)
        {
            string sql = "Delete from ChiTietHDB where MaSanPham = '" + ma.Trim() + "'";
            string TTCanHo = string.Format("Update SanPham Set TinhTrang = N'Hoạt động' Where MaSanPham = '" + ma.Trim() + "'");
            thucthisql(sql);
            thucthisql(TTCanHo);
            return true;
        }
        public DataTable TimKiem(string mahd, string sonha)
        {
            string sql = "Select * from ChiTietHDB";
            string dk = "";
            if (mahd.Trim() == "" && sonha.Trim() == "")
            {
                // 1
                return null;
            }
            if (mahd.Trim() != "" && dk == "")
            {
                // 2
                dk += " MaHDB like '%" + mahd.Trim() + "%'";
            }
            if (sonha.Trim() != "" && dk != "")
            {
                // 3
                dk += " and MaSanPham like '%" + sonha.Trim() + "%'";
            }
            if (sonha.Trim() != "" && dk == "")
            {
                // 4
                dk += "MaSanPham like '%" + sonha.Trim() + "%'";
            }
            if (dk != "")
            {
                sql += " WHERE " + dk;
            }
            return connect.getData(sql);
        }
        public double ThongKeDoanhThuTheoThang(string thang, string nam)
        {
            string sql = "SELECT SUM(ChiTietHDB.ThanhTien * ChiTietHDB.SoLuongBan) FROM ChiTietHDB INNER JOIN HoaDonBan ON ChiTietHDB.MaHDB = HoaDonBan.MaHDB WHERE MONTH(NgayBan) ="+thang.Trim()+" AND YEAR(NgayBan) = "+nam.Trim()+"";
            return connect.ThongKeDoanhThu(sql);
        }

        public DataTable ThongKeHoaDonTheoThang(string thang, string nam)
        {
            string sql = string.Format("Select H.MaHDB, H.MaNV, H.MaKH, h.NgayBan, C.MaSanPham, C.DonGia, C.GiamGia, C.ThanhTien from HoaDonBan H inner join ChiTietHDB C on H.MaHDB = C.MaHDB Where Month(ngayban) = " + thang.Trim() + " and Year(ngayban) = " + nam.Trim() + "");
            return connect.getData(sql);
        }
        public DataTable ThongKeHoaDonTheoNam(string nam)
        {
            string sql = string.Format("Select H.MaHDB, H.MaNV, H.MaKH, h.NgayBan, C.MaSanPham, C.DonGia, C.GiamGia, C.ThanhTien from HoaDonBan H inner join ChiTietHDB C on H.MaHDB = C.MaHDB Where Year(ngayban) = " + nam.Trim() + "");
            return connect.getData(sql);
        }
        public double ThongKeDoanhThuTheoNam(string nam)
        {
            string sql = "SELECT SUM(ChiTietHDB.ThanhTien * ChiTietHDB.SoLuongBan) FROM ChiTietHDB INNER JOIN HoaDonBan ON ChiTietHDB.MaHDB = HoaDonBan.MaHDB WHERE  YEAR(NgayBan) = " + nam.Trim() + "";
            return connect.ThongKeDoanhThu(sql);
        }
    }
}
