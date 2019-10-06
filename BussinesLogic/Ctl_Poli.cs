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
    public class Ctl_poli
    {
        Common da;
        public string BuatKode()
        {
            string kode;
            try
            {
                kode = "PL1";
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT Max([id]) as max
        FROM [dbo].[tb_poli]";
                da.OpenConnection();
                dt = da.ExecuteQuery(query);
                da.CloseConnection();
                if (dt.Rows.Count > 0)
                {
                    kode = "PL" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
                }


            }
            catch (Exception)
            {

                kode = "PL1";
            }
            return kode;

        }


        public DataTable Get_poli(string kode_poli)
        {

            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [id]
        ,[kode_poli]
      ,[nama_poli]
      ,[keterangan]
  FROM [dbo].[tb_poli] WHERE [kode_poli]=@kode_poli";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_poli", kode_poli));
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
        public DataTable Get_poli()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [id]
        ,[kode_poli]
      ,[nama_poli]
      ,[keterangan]
  FROM [dbo].[tb_poli]";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
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



        public bool Insert_poli(string kode_poli, string nama_poli, string keterangan)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_poli]
           ([kode_poli]
           ,[nama_poli]
           ,[keterangan])
     VALUES
           (@kode_poli
           ,@nama_poli
           ,@keterangan)";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_poli", kode_poli));
                param.Add(new SqlParameter("@nama_poli", nama_poli));
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

        public bool Update_poli(string kode_poli, string nama_poli, string keterangan)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_poli]
   SET [nama_poli] = @nama_poli
      ,[keterangan] = @keterangan
 WHERE [kode_poli]=@kode_poli";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_poli", kode_poli));
                param.Add(new SqlParameter("@nama_poli", nama_poli));
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

        public bool Delete_poli(string kode_poli)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_poli]
      WHERE [kode_poli]=@kode_poli";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_poli", kode_poli));
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
