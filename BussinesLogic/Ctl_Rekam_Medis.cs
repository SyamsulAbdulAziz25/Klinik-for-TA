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
    public class Ctl_Rekam_Medis
    {
        Common da;

        public string BuatKode()
        {
            string kode = "";
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT MAX([id]) as max
  FROM [dbo].[tb_rekam_medis]";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();
                if (dt.Rows.Count > 0)
                {
                    kode = "RK" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
                }

            }
            catch (Exception)
            {
                kode = "RK1";

            }

            return kode;
        }
        public DataTable Get_Rekam_Medis(string kode)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [id]
      ,[kode]
      ,[kode_kunjungan]
      ,[keluhan]
      ,[diagnosa]
      ,[tindakan]
      ,[resep]
  FROM [dbo].[tb_rekam_medis] WHERE [kode]=@kode";
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
        public DataTable Get_Rekam_Medis_for_poli(string akses)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT r.[kode] as kode
      ,r.[kode_kunjungan] as kode_kunjungan
      ,r.[keluhan] as keluhan
      ,r.[diagnosa] as diagnosa
      ,r.[tindakan] as tindakan
      ,r.[resep] as resep
  FROM tb_rekam_medis r inner join tb_kunjungan k 
        on r.kode_kunjungan=k.kode_kunjungan 
		inner join tb_poli p
		on k.kode_poli=p.kode_poli where p.nama_poli='" + akses + "'";
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



        public bool Insert_Rekam_Medis(string kode, string kode_kunjungan, string keluhan, string diagnosa, string tindakan, string resep)
        {
            try
            {
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_rekam_medis]
           ( [kode]
            ,[kode_kunjungan]
            ,[keluhan]
            ,[diagnosa]
            ,[tindakan]
            ,[resep])
     VALUES
           (@kode
           ,@kode_kunjungan
           ,@keluhan
           ,@diagnosa
           ,@tindakan
           ,@resep)";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode", kode));
                param.Add(new SqlParameter("@kode_kunjungan", kode_kunjungan));
                param.Add(new SqlParameter("@keluhan", keluhan));
                param.Add(new SqlParameter("@diagnosa", diagnosa));
                param.Add(new SqlParameter("@tindakan", tindakan));
                param.Add(new SqlParameter("@resep", resep));
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

        public bool Update_Rekam_Medis(string kode, string kode_kunjungan, string keluhan, string diagnosa, string tindakan, string resep)
        {
            try
            {
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_rekam_medis]
   SET [kode_kunjungan]=@kode_kunjungan
      ,[keluhan] = @keluhan
      ,[diagnosa] = @diagnosa
      ,[tindakan] = @tindakan
      ,[resep] = @resep
 WHERE [kode]=@kode
";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode", kode));
                param.Add(new SqlParameter("@kode_kunjungan", kode_kunjungan));
                param.Add(new SqlParameter("@keluhan", keluhan));
                param.Add(new SqlParameter("@diagnosa", diagnosa));
                param.Add(new SqlParameter("@tindakan", tindakan));
                param.Add(new SqlParameter("@resep", resep));
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

        public bool Delete_pasien(string kode)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_rekam_medis]
      WHERE [kode]=@kode";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode", kode));
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
