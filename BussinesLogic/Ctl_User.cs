using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAcces;

namespace BussinesLogic
{
    public class Ctl_User
    {
        Common da;

        public DataTable Get_Owner(string ID, string pass)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"USE [db_klinik]
SELECT [id]
      ,[email]
      ,[no_hp]
      ,[nama]
      ,[password]
  FROM [dbo].[tb_owner] WHERE [id]=@ID and [password]=@pass
";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@ID", ID));
                param.Add(new SqlParameter("@pass", pass));
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public string BuatKode()
        {
            string kode = "K1";
            DataTable dt = new DataTable();
            string query = @"USE [db_klinik]
SELECT Max([id]) as max
        FROM [dbo].[tb_user]";
            da.OpenConnection();
            dt = da.ExecuteQuery(query);
            da.CloseConnection();
            if (dt.Rows.Count > 0)
            {
                kode = "K" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
            }
            return kode;

        }
        public DataTable Get_User()
        {

            DataTable dt = new DataTable();
            try
            {

                string query = @"USE [db_klinik]
SELECT [id]
      ,[kode_karyawan]
      ,[nama]
      ,[no_hp]
      ,[email]
      ,[alamat]
      ,[jk]
      ,[password]
      ,[bagian]
  FROM [dbo].[tb_user]
";
                da = new Common();
                da.OpenConnection();
                dt = da.ExecuteQuery(query);
                da.CloseConnection();

                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Get_User_poli(string bagian)
        {

            DataTable dt = new DataTable();
            try
            {

                string query = @"USE [db_klinik]
SELECT [id]
      ,[kode_karyawan]
      ,[nama]
      ,[no_hp]
      ,[email]
      ,[alamat]
      ,[jk]
      ,[password]
      ,[bagian]
  FROM [dbo].[tb_user]
 WHERE [bagian]=@bagian";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@bagian", bagian));
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Get_User(string kode)
        {

            DataTable dt = new DataTable();
            try
            {

                string query = @"USE [db_klinik]
SELECT [id]
      ,[kode_karyawan]
      ,[nama]
      ,[no_hp]
      ,[email]
      ,[alamat]
      ,[jk]
      ,[password]
      ,[bagian]
  FROM [dbo].[tb_user]
 WHERE [kode_karyawan]=@kode";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode", kode));
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Get_User(string ID, string pwd)
        {
            DataTable dt = new DataTable();
            try
            {

                string query = @"USE [db_klinik]
SELECT [id]
      ,[kode_karyawan]
      ,[nama]
      ,[no_hp]
      ,[email]
      ,[alamat]
      ,[password]
       ,[jk]
      ,[bagian]
  FROM [dbo].[tb_user]
 WHERE [password]=@pwd and [kode_karyawan]=@ID";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@ID", ID));
                param.Add(new SqlParameter("@pwd", pwd));
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                return dt;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool Insert_User(string kode, string nama, string no_hp, string email, string alamat, string jk, string password, string bagian)
        {
            try
            {
                string query = @" USE [db_klinik]
INSERT INTO [dbo].[tb_user]
           ([kode_karyawan]
           ,[nama]
           ,[no_hp]
           ,[email]
           ,[alamat]
           ,[jk]
           ,[password]
           ,[bagian])
     VALUES
           (@kode
           ,@nama
           ,@no_hp
           ,@email
           ,@alamat
           ,@jk
           ,@password
           ,@bagian)";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode", kode));
                param.Add(new SqlParameter("@nama", nama));
                param.Add(new SqlParameter("@no_hp", no_hp));
                param.Add(new SqlParameter("@email", email));
                param.Add(new SqlParameter("@alamat", alamat));
                param.Add(new SqlParameter("@jk", jk));
                param.Add(new SqlParameter("@password", password));
                param.Add(new SqlParameter("@bagian", bagian));
                da.OpenConnection();
                da.ExecuteNonQuery(query, param);
                da.CloseConnection();

                return true;
            }
            catch (Exception)
            {

                throw;
            }




        }

        public bool Update_User(string kode_karyawan, string nama, string no_hp, string email, string alamat, string jk, string password, string bagian)
        {
            try
            {
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_user]
   SET [nama] = @nama
      ,[no_hp] =@no_hp
      ,[email] = @email
      ,[alamat] = @alamat
      ,[jk]=@jk
      ,[password] = @password
      ,[bagian] = @bagian
 WHERE [kode_karyawan]=@kode_karyawan
";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_karyawan", kode_karyawan));
                param.Add(new SqlParameter("@nama", nama));
                param.Add(new SqlParameter("@no_hp", no_hp));
                param.Add(new SqlParameter("@email", email));
                param.Add(new SqlParameter("@alamat", alamat));
                param.Add(new SqlParameter("@jk", jk));
                param.Add(new SqlParameter("@password", password));
                param.Add(new SqlParameter("@bagian", bagian));
                da.OpenConnection();
                da.ExecuteNonQuery(query, param);
                da.CloseConnection();

                return true;
            }
            catch (Exception)
            {

                throw;
            }

            return true;

        }

        public bool Delete_User(string kode_karyawan)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_user]
      WHERE [kode_karyawan]=@kode_karyawan";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_karyawan", kode_karyawan));
                da.OpenConnection();
                da.ExecuteNonQuery(query, param);
                da.CloseConnection();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
