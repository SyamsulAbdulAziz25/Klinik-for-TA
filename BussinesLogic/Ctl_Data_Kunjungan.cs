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
    public class Ctl_Data_Kunjungan
    {
        Common da;
        public int Buat_nomor_antrian(string poli)
        {

            DataTable dt = new DataTable();
            string no_antrian = "";
            try
            {
                string query = @"USE [db_klinik]
SELECT MAX([nomor_antrian]) as max
FROM [dbo].[tb_antrian] WHERE poli = @poli";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@poli", poli));
                da = new Common();
                da.OpenConnection();
                dt = da.ExecuteQuery(query, param);
                da.CloseConnection();

                if (dt.Rows.Count > 0 && dt.Rows.ToString() != null)
                {
                    no_antrian = (Int32.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
                }


            }
            catch (Exception)
            {

                no_antrian = "1";
            }


            return int.Parse(no_antrian);


        }




        public string BuatKode()
        {
            string kode = "";
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT MAX([id]) as max
  FROM [dbo].[tb_kunjungan]";
                da = new Common();
                da.OpenConnection();
                dt = da.ExecuteQuery(query);
                da.CloseConnection();

                if (dt.Rows.Count > 0)
                {
                    kode = "KJ" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
                }

            }
            catch (Exception)
            {
                kode = "KJ";
                throw;
            }


            return kode;
        }

        public DataTable Get_Kunjungan_Pembayaran_Owner(string metode_pembayaran)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT k.[id] as id
      ,[kode_kunjungan]
      ,[tanggal_kunjungan]
      ,k.[kode_poli] as kode_poli
      ,p.[nama_poli] as poli
      ,k.[kode_pasien] as kode_pasien
      ,k.[kode_dokter] as kode_dokter
      ,k.[metode_pembayaran] as metode_pembayaran
  FROM tb_kunjungan k inner join tb_poli p on k.kode_poli=p.kode_poli where k.metode_pembayaran=@metode_pembayaran ";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@metode_pembayaran", metode_pembayaran));
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
        public DataTable Get_Kunjungan_Waktu_Owner(string awal, string akhir)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT k.[id] as id
      ,[kode_kunjungan]
      ,[tanggal_kunjungan]
      ,k.[kode_poli] as kode_poli
      ,p.[nama_poli] as poli
      ,k.[kode_pasien] as kode_pasien
      ,k.[kode_dokter] as kode_dokter
      ,k.[metode_pembayaran] as metode_pembayaran
  FROM tb_kunjungan k inner join tb_poli p on k.kode_poli=p.kode_poli where k.tanggal_kunjungan>=@awal and k.tanggal_kunjungan<=@akhir ";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@awal", awal));
                param.Add(new SqlParameter("@akhir", akhir));
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
        public DataTable Get_Kunjungan(string kode_Kunjungan)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT k.[id] as id
      ,[kode_kunjungan]
      ,[tanggal_kunjungan]
      ,k.[kode_poli] as kode_poli
      ,p.[nama_poli] as poli
      ,k.[kode_pasien] as kode_pasien
      ,k.[kode_dokter] as kode_dokter
      ,k.[metode_pembayaran] as metode_pembayaran
  FROM tb_kunjungan k inner join tb_poli p on k.kode_poli=p.kode_poli where k.kode_kunjungan=@kode_kunjungan ";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_Kunjungan", kode_Kunjungan));
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
        public DataTable Get_Kunjungan()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT [id]
      ,[kode_kunjungan]
      ,[tanggal_kunjungan]
      ,[kode_poli]
      ,[kode_pasien]
      ,[kode_dokter]
      ,[metode_pembayaran]
  FROM [dbo].[tb_kunjungan]
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



        public bool Insert_Kunjungan(string kode_Kunjungan, string tanggal, string poli, string kode_pasien, string kode_dokter, string pembayaran)
        {
            try
            {
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_kunjungan]
           ([kode_kunjungan]
           ,[tanggal_kunjungan]
           ,[kode_poli]
           ,[kode_pasien]
           ,[kode_dokter]
           ,[metode_pembayaran])
     VALUES
           (@kode_kunjungan
           ,@tanggal
           ,@poli
           ,@kode_pasien
           ,@kode_dokter
           ,@pembayaran)
";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_Kunjungan", kode_Kunjungan));
                param.Add(new SqlParameter("@tanggal", tanggal));
                param.Add(new SqlParameter("@poli", poli));
                param.Add(new SqlParameter("@kode_pasien", kode_pasien));
                param.Add(new SqlParameter("@kode_dokter", kode_dokter));
                param.Add(new SqlParameter("@pembayaran", pembayaran));
                da.OpenConnection();
                da.ExecuteQuery(query, param);
                da.CloseConnection();

                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool Update_Kunjungan(string kode_Kunjungan, string tanggal, string poli, string kode_pasien, string kode_dokter, string pembayaran)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_kunjungan]
   SET [tanggal_kunjungan] = @tanggal
      ,[kode_poli] = @poli
      ,[kode_pasien] = @kode_pasien
      ,[kode_dokter] = @kode_dokter
      ,[metode_pembayaran] = @pembayaran
 WHERE [kode_kunjungan]=@kode_kunjungan
";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_Kunjungan", kode_Kunjungan));
                param.Add(new SqlParameter("@tanggal", tanggal));
                param.Add(new SqlParameter("@poli", poli));
                param.Add(new SqlParameter("@kode_pasien", kode_pasien));
                param.Add(new SqlParameter("@kode_dokter", kode_dokter));
                param.Add(new SqlParameter("@pembayaran", pembayaran));
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

        public bool Delete_Kunjungan(string kode_Kunjungan)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_Kunjungan]
      WHERE [kode_Kunjungan]=@kode_Kunjungan";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_Kunjungan", kode_Kunjungan));
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
