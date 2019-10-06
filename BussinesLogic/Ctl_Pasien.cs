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
    public class Ctl_Pasien
    {
        Common da;

        public string BuatKode()
        {
            string kode = "PS1";
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT MAX([id]) as max
  FROM [dbo].[tb_pasien]";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();
                if (dt.Rows.Count > 0)
                {
                    kode = "PS" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return kode;
        }
        public DataTable Get_Pasien(string kode_pasien)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [id]
        ,[kode_pasien]
      ,[nama_pasien]
      ,[tanggal_lahir]
      ,[no_telephon]
      ,[alamat]
      ,[jenis_kelamin]
      ,[keterangan]
  FROM [dbo].[tb_pasien] WHERE [kode_pasien]=@kode_pasien";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pasien", kode_pasien));
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
        public DataTable Get_Pasien()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [id]
        ,[kode_pasien]
      ,[nama_pasien]
      ,[tanggal_lahir]
      ,[no_telephon]
      ,[alamat]
      ,[jenis_kelamin]
      ,[keterangan]
  FROM [dbo].[tb_pasien]";
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



        public bool Insert_Pasien(string kode_pasien, string nama_pasien, string tanggal_lahir, string no_telephon, string alamat, string jenis_kelamin, string keterangan)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_pasien]
           ([kode_pasien]
           ,[nama_pasien]
           ,[tanggal_lahir]
           ,[no_telephon]
           ,[alamat]
           ,[jenis_kelamin]
           ,[keterangan])
     VALUES
           (@kode_pasien
           ,@nama_pasien
           ,@tanggal_lahir
           ,@no_telephon
           ,@alamat
           ,@jenis_kelamin
           ,@keterangan)
";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pasien", kode_pasien));
                param.Add(new SqlParameter("@nama_pasien", nama_pasien));
                param.Add(new SqlParameter("@tanggal_lahir", tanggal_lahir));
                param.Add(new SqlParameter("@no_telephon", no_telephon));
                param.Add(new SqlParameter("@alamat", alamat));
                param.Add(new SqlParameter("@jenis_kelamin", jenis_kelamin));
                param.Add(new SqlParameter("@keterangan", keterangan));
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool Update_Pasien(string kode_pasien, string nama_pasien, string tanggal_lahir, string no_telephon, string alamat, string jenis_kelamin, string keterangan)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_pasien]
   SET [nama_pasien] = @nama_pasien
      ,[tanggal_lahir] = @tanggal_lahir
      ,[no_telephon] = @no_telephon
      ,[alamat] = @alamat
      ,[jenis_kelamin] = @jenis_kelamin
      ,[keterangan] = @keterangan
 WHERE [kode_pasien]=@kode_pasien
";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pasien", kode_pasien));
                param.Add(new SqlParameter("@nama_pasien", nama_pasien));
                param.Add(new SqlParameter("@tanggal_lahir", tanggal_lahir));
                param.Add(new SqlParameter("@no_telephon", no_telephon));
                param.Add(new SqlParameter("@alamat", alamat));
                param.Add(new SqlParameter("@jenis_kelamin", jenis_kelamin));
                param.Add(new SqlParameter("@keterangan", keterangan));
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool Delete_pasien(string kode_pasien)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_pasien]
      WHERE [kode_pasien]=@kode_pasien";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pasien", kode_pasien));
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
