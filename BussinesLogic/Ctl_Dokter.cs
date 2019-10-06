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
    public class Ctl_Dokter
    {
        Common da;

        public string BuatKode()
        {
            string kode = "DR1";
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT max([id]) as max
  FROM [dbo].[tb_dokter]";
                da = new Common();
                da.OpenConnection();
                dt = da.ExecuteQuery(query);
                da.CloseConnection();

                if (dt.Rows.Count > 0)
                {
                    kode = "DR" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString(); ;

                }
                return kode;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Get_Laporan_Dokter()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
		 select d.kode_dokter, d.nama_dokter,po.nama_poli,p.waktu ,p.tarif_dokter as tarif, p.tindakan as tindakan from tb_dokter d inner join tb_kunjungan k 
			on d.kode_dokter=k.kode_dokter inner join tb_pembayaran p 
			on p.kode_kunjungan=k.kode_kunjungan inner join tb_poli po
			on d.kode_poli= po.kode_poli order by p.id";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
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
        public DataTable Get_Laporan_Dokter_ByDokter()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
		 select d.kode_dokter as kode_dokter, d.nama_dokter as nama_dokter, po.nama_poli as nama_poli, sum(p.tarif_dokter) as tarif from tb_dokter d inner join tb_kunjungan k 
			on d.kode_dokter=k.kode_dokter inner join tb_pembayaran p 
			on p.kode_kunjungan=k.kode_kunjungan inner join tb_poli po
			on d.kode_poli= po.kode_poli GROUP by d.id,d.kode_dokter, d.nama_dokter, po.nama_poli order by d.id ";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
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
        public DataTable Get_Laporan_Dokter_Tindakan(string tindakan)
        {
            string query = "";
            try
            {
                if (tindakan == "Ya")
                {
                    query = @"USE [db_klinik]
		 select d.kode_dokter, d.nama_dokter,po.nama_poli,p.waktu ,p.tarif_dokter as tarif, p.tindakan as tindakan from tb_dokter d inner join tb_kunjungan k 
			on d.kode_dokter=k.kode_dokter inner join tb_pembayaran p 
			on p.kode_kunjungan=k.kode_kunjungan inner join tb_poli po
			on d.kode_poli= po.kode_poli  where p.tindakan<>'' order by p.id";
                }
                else
                {
                    query = @"USE [db_klinik]
		 select d.kode_dokter, d.nama_dokter,po.nama_poli,p.waktu ,p.tarif_dokter as tarif, p.tindakan as tindakan from tb_dokter d inner join tb_kunjungan k 
			on d.kode_dokter=k.kode_dokter inner join tb_pembayaran p 
			on p.kode_kunjungan=k.kode_kunjungan inner join tb_poli po
			on d.kode_poli= po.kode_poli  where p.tindakan='' order by p.id";
                }
                DataTable dt = new DataTable();

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
        public DataTable Get_Laporan_Dokter_Tanggal(string waktu1, string waktu2)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
		 select d.kode_dokter, d.nama_dokter,po.nama_poli,p.waktu ,p.tarif_dokter as tarif, p.tindakan as tindakan from tb_dokter d inner join tb_kunjungan k 
			on d.kode_dokter=k.kode_dokter inner join tb_pembayaran p 
			on p.kode_kunjungan=k.kode_kunjungan inner join tb_poli po
			on d.kode_poli= po.kode_poli where p.waktu >= @waktu1 and p.waktu<=@waktu2 order by p.id";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@waktu1", waktu1));
                param.Add(new SqlParameter("@waktu2", waktu2));
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
        public DataTable Get_Dokter(string kode_dokter)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [kode_dokter]
      ,[nama_dokter]
      ,[kode_poli]
      ,[tarif]
  FROM [dbo].[tb_dokter] WHERE [kode_dokter]=@kode_dokter";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_dokter", kode_dokter));
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
        public DataTable Get_Dokter()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT d.[kode_dokter] as kode_dokter
      ,d.[nama_dokter] as nama_dokter
      ,p.[nama_poli] as nama_poli
      ,d.[tarif] as tarif
  FROM [dbo].[tb_dokter] d inner join tb_poli p on d.kode_poli=p.kode_poli";
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



        public bool Insert_Dokter(string kode_dokter, string nama_dokter, string kode_poli, string tarif)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_dokter]
           ([kode_dokter]
           ,[nama_dokter]
           ,[kode_poli]
           ,[tarif])
     VALUES
           (@kode_dokter
           ,@nama_dokter
           ,@kode_poli
           ,@tarif)";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_dokter", kode_dokter));
                param.Add(new SqlParameter("@nama_dokter", nama_dokter));
                param.Add(new SqlParameter("@kode_poli", kode_poli));
                param.Add(new SqlParameter("@tarif", tarif));
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

        public bool Update_Dokter(string kode_dokter, string nama_dokter, string kode_poli, string tarif)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_dokter]
   SET [nama_dokter] = @nama_dokter
      ,[kode_poli] = @kode_poli
      ,[tarif]= @tarif
 WHERE [kode_dokter]=@kode_dokter";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_dokter", kode_dokter));
                param.Add(new SqlParameter("@nama_dokter", nama_dokter));
                param.Add(new SqlParameter("@kode_poli", kode_poli));
                param.Add(new SqlParameter("@tarif", tarif));
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

        public bool Delete_Dokter(string kode_dokter)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_dokter]
      WHERE [kode_dokter]=@kode_dokter";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_dokter", kode_dokter));
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
