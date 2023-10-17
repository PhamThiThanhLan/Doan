using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_SanPham : DBConnect
    {
        //chứa mọi xử lý liên quan đến CSDL
        //xử lý lấy dữ liệu để đưa ra dgv
        //khởi tạo đối tượng thuộc lớp DBConnect
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from SanPham";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from SanPham where MaSanPham = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemCH(SanPham ch)
        {
            string sql = string.Format("Insert into SanPham values('{0}',N'{1}', '{2}', N'{3}', N'{4}','{5}','{6}')", ch.MaSanPham, ch.TenSanPham, ch.HangTonKho, ch.GiaBan, ch.TinhTrang,ch.MaLoaiSanPham,ch.DonViTinh);
            thucthisql(sql);
            return true;
        }
        public bool SuaCH(SanPham ch)
        {
            string sql = string.Format("Update SanPham set TenSanPham = N'{1}', HangTonKho = '{2}', GiaBan = '{3}', TinhTrang = N'{4}',MaLoaiSanPham = '{5}', DonViTinh = '{6}' Where MaSanPham = '{0}' ", ch.MaSanPham,ch.TenSanPham, ch.HangTonKho, ch.GiaBan, ch.TinhTrang, ch.MaLoaiSanPham, ch.DonViTinh);
            thucthisql(sql);
            return true;
        }
        public bool XoaCH(string ma)
        {
            string sql = "DELETE from SanPham Where MaSanPham = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TimKiemCH(string maSanPHam,  string GiaBan)
        {
            string sql = "Select * from SanPham";
            string dk = "";
            if (maSanPHam.Trim() == ""  && GiaBan.Trim() == "")
            {
                return null;
            }
            if (maSanPHam.Trim() != "" && dk == "")
            {
                dk += " MaSanPham like '%" + maSanPHam.Trim() + "%'";
            }
            
            if (GiaBan.Trim() != "" && dk != "")
            {
                dk += " and GiaBan between  " + GiaBan + " - 50 and " + GiaBan + " + 50";
            }
            if (GiaBan.Trim() != "" && dk == "")
            {
                dk += " GiaBan between  " + GiaBan + " - 20 and " + GiaBan + " + 20";
            }
            if (dk != "")
            {
                sql += " Where " + dk;
            }
            //string sql = "Select * from SanPham where masanpham = 'CH01'";
            return connect.getData(sql);
        }
        public string valuecbbNV(string ma)
        {
            string sql = "Select TenSanPham From SanPham Where MaSanPham = '" + ma.Trim() + "'";
            return connect.valuecbb(ma, sql);
        }
    }
}
