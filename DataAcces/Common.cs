using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAcces
{
    public class Common
    {
        private string strConStr = @"Data Source=DESKTOP-FBRM1DJ\SQLEXPRESS;Initial Catalog=db_klinik;Integrated Security=True";
        private static SqlConnection SqlConn;
        private static SqlCommand SqlCmd;
        private static SqlTransaction SqlTrans;
        public bool OpenConnection()
        {
            try
            {
                SqlConn = new SqlConnection(strConStr); // instansiasi objek dan variable  kemungkinan error: salah string,database tdk bisa diakses

                SqlConn.Open();// buka // instansiasi jarang error dan biasanya di open terjadi error
                SqlTrans = SqlConn.BeginTransaction();// mulai
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void CloseConnection()
        {
            try
            {
                if (SqlConn.State == ConnectionState.Open) //komneksi terbuka
                {
                    SqlTrans.Commit();// setelah dikomit (proses) komit transaksionnya dtabase error, 
                    SqlConn.Close();// koneksi di klose
                }
            }
            catch (Exception ex)
            {

                if (SqlTrans.Connection != null)
                {
                    SqlTrans.Rollback(); // dikembalikan connection gk jadi
                }
                throw new Exception(ex.Message, ex);
            }
        }
        public bool ExecuteNonQuery(string query)
        {
            try
            {
                SqlCmd = new SqlCommand(query, SqlConn, SqlTrans);
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    if (SqlTrans.Connection != null)
                    {
                        SqlTrans.Rollback();
                    }
                    SqlConn.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                SqlCmd = new SqlCommand(query, SqlConn, SqlTrans);
                dt = new DataTable();
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.CommandTimeout = 0;
                da.SelectCommand = SqlCmd;


                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    if (SqlTrans.Connection != null)
                    {
                        SqlTrans.Rollback();
                    }
                    SqlConn.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }
        public DataTable ExecuteQuery(string query, List<SqlParameter> param)
        {
            DataTable dt;
            SqlDataAdapter da = new SqlDataAdapter();// sql command menjalankan peerintah, sql data adapter mengkomodasi data dari sql command
            try
            {
                SqlCmd = new SqlCommand(query, SqlConn, SqlTrans); //sql transaksi mengikuti sql connection
                dt = new DataTable();
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.CommandTimeout = 0; // perintah menjalankan aplikasi select ke database itu 60, ada waktu ada batasan, 0 tanpa batasan
                da.SelectCommand = SqlCmd;

                SqlCmd.Parameters.AddRange(param.ToArray());
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    if (SqlTrans.Connection != null)
                    {
                        SqlTrans.Rollback();
                    }
                    SqlConn.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }
        public bool ExecuteNonQuery(string query, List<SqlParameter> param)
        {
            try
            {
                SqlCmd = new SqlCommand(query, SqlConn, SqlTrans);// menjalankan semua perintah //query,koneksi,transaksi
                SqlCmd.CommandType = CommandType.Text; //menunjukan teks banget
                SqlCmd.Parameters.AddRange(param.ToArray());
                SqlCmd.ExecuteNonQuery();//eksekusi
                return true;

            }
            catch (Exception ex)
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    if (SqlTrans.Connection != null)
                    {
                        SqlTrans.Rollback();
                    }
                    SqlConn.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }
    }

}
