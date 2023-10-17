using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DBConnect
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataTable dt;
        string chuoikn = @"Data Source=LENOVO\MSSQLSERVER01;Initial Catalog=Lan_ProjectNew;Integrated Security=True";
        public void ketnoi()
        {
            con = new SqlConnection(chuoikn);
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void ngatkn()
        {
            con = new SqlConnection(chuoikn);
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public void thucthisql(string sql)
        {
            ketnoi();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ngatkn();
        }
        public DataTable getData(string sql)
        {
            ketnoi();
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            ngatkn();
            return dt;
        }
        public int kiemtramatrung(string ma, string sql)
        {
            ketnoi();
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            ngatkn();
            return i;
        }
        public double ThongKeDoanhThu(string sql)
        {
            ketnoi();
            double i;
            cmd = new SqlCommand(sql, con);
            i = (double)cmd.ExecuteScalar();
            ngatkn();
            return i;
        }
        public int DangNhap(string tk, string mk)
        {
            ketnoi();
            int code = 0;
            cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthoLogin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@tk", tk.Trim());
            cmd.Parameters.AddWithValue("@mk", mk.Trim());

            SqlParameter param3 = new SqlParameter("@role", SqlDbType.BigInt);
            param3.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(param3);
            cmd.ExecuteNonQuery();

            ngatkn();

            code = (int)param3.Value;
            return code;
        }
        public string valuecbb(string ma, string sql)
        {
            string val = "";
            ketnoi();
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                val = dr.GetString(0);
            }
            return val;
        }
    }
}
