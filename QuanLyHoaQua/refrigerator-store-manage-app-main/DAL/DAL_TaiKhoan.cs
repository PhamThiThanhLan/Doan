using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_TaiKhoan : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from TaiKhoan");
        }
        public bool KiemTraDangNhap(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LENOVO\MSSQLSERVER01;Initial Catalog=Lan_ProjectNew;Integrated Security=True"))
            {
                connection.Open(); 
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE UserID = @UserName AND Pass = @PassWord";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@PassWord", password);
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) From TaiKhoan Where UserID = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemUser(TaiKhoan tk)
        {
            string sql = "INSERT INTO TaiKhoan VALUES('" + tk.UserID + "','" + tk.Pass + "','" + tk.Per + "' , '"+tk.MaNV+"')";
            thucthisql(sql);
            return true;
        }
    }
}
