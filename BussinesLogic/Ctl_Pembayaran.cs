using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using System.Data;
using System.Data.SqlClient;

namespace BussinesLogic
{
    public class Ctl_Pembayaran
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
  FROM [dbo].[tb_pembayaran]";
                da = new Common();
                da.OpenConnection();
                dt = da.ExecuteQuery(query);
                da.CloseConnection();

                if (dt.Rows.Count > 0)
                {
                    kode = "KP" + (int.Parse(dt.Rows[0]["max"].ToString()) + 1).ToString();
                }

            }
            catch (Exception)
            {
                kode = "KP1";
            }


            return kode;
        }
        public DataTable Get_Pembayaran(string kode_pembayaran)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @" USE [db_klinik] SELECT 
       p.[id] as id
      ,p.[kode_pembayaran] as kode_pembayaran
      ,p.[kode_kunjungan] as kode_kunjungan
      ,p.[waktu] as waktu
      ,p.[tarif_dokter] as tarif_dokter
      ,p.[obat] as obat
      ,p.[tindakan] as tindakan
      ,k.[metode_pembayaran] as metode
      ,p.[harga] as harga
      ,p.[total] as total
  FROM [dbo].[tb_pembayaran] p inner join tb_kunjungan k on k.kode_kunjungan=p.kode_kunjungan where p.kode_pembayaran=@kode_pembayaran";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pembayaran", kode_pembayaran));
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
        public DataTable Get_Laporan_Pendapatan(string pembayaran)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT  p.[id] as id
      ,p.[kode_pembayaran] as kode_pembayaran
      ,p.[kode_kunjungan] as kode_kunjungan
      ,p.[waktu] as waktu
      ,p.[tarif_dokter] as tarif_dokter
      ,p.[obat] as obat
      ,p.[tindakan] as tindakan
      ,k.[metode_pembayaran] as metode
      ,p.[harga] as harga
      ,p.[total] as total
  FROM [dbo].[tb_pembayaran] p inner join tb_kunjungan k on k.kode_kunjungan=p.kode_kunjungan WHERE k.metode_pembayaran=@pembayaran";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@pembayaran", pembayaran));
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
        public DataTable Get_Laporan_Pendapatan_Waktu(string waktu1, string waktu2)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT p.[id] as id
      ,p.[kode_pembayaran] as kode_pembayaran
      ,p.[kode_kunjungan] as kode_kunjungan
      ,p.[waktu] as waktu
      ,p.[tarif_dokter] as tarif_dokter
      ,p.[obat] as obat
      ,p.[tindakan] as tindakan
      ,k.[metode_pembayaran] as metode
      ,p.[harga] as harga
      ,p.[total] as total
  FROM [dbo].[tb_pembayaran] p inner join tb_kunjungan k on k.kode_kunjungan=p.kode_kunjungan WHERE p.waktu>=@waktu1 and p.waktu<=@waktu2";
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
        public DataTable Get_Pembayaran()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
SELECT p.[id] as id
      ,p.[kode_pembayaran] as kode_pembayaran
      ,p.[kode_kunjungan] as kode_kunjungan
      ,p.[waktu] as waktu
      ,p.[tarif_dokter] as tarif_dokter
      ,p.[obat] as obat
      ,p.[tindakan] as tindakan
      ,k.[metode_pembayaran] as metode
      ,p.[harga] as harga
      ,p.[total] as total
      ,(p.[total]+p.[kembalian]) as bayaran
      ,p.[kembalian]
  FROM [dbo].[tb_pembayaran] p inner join tb_kunjungan k on k.kode_kunjungan=p.kode_kunjungan";

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



        public bool Insert_Pembayaran(string kode_pembayaran, string kode_kunjungan, string waktu, int tarif_dokter, int obat, string tindakan, int harga, int pembayaran)
        {
            try
            {
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_pembayaran]
           ([kode_pembayaran]
           ,[kode_kunjungan]
           ,[waktu]
           ,[tarif_dokter]
           ,[obat]
           ,[tindakan]
           ,[harga]
           ,[total]
           ,[kembalian])
     VALUES
           (@kode_pembayaran
           ,@kode_kunjungan
           ,@waktu
           ,@tarif_dokter
           ,@obat
           ,@tindakan
           ,@harga
           ,@total
           ,@kembalian)
";
                da = new Common();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pembayaran", kode_pembayaran));
                param.Add(new SqlParameter("@kode_kunjungan", kode_kunjungan));
                param.Add(new SqlParameter("@waktu", waktu));
                param.Add(new SqlParameter("@tarif_dokter", tarif_dokter));
                param.Add(new SqlParameter("@obat", obat));
                param.Add(new SqlParameter("@tindakan", tindakan));
                param.Add(new SqlParameter("@harga", harga));
                param.Add(new SqlParameter("@total", (tarif_dokter + obat + harga)));
                param.Add(new SqlParameter("@kembalian", pembayaran - (tarif_dokter + obat + harga)));
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

        public bool Update_Pembayaran(string kode_pembayaran, string kode_kunjungan, string waktu, int tarif_dokter, int obat, string tindakan, int harga)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"USE [db_klinik]
UPDATE [dbo].[tb_pembayaran]
   SET [kode_kunjungan] = @kode_kunjungan
      ,[waktu]= @waktu
      ,[tarif_dokter] = @tarif_dokter
      ,[obat] = @obat
      ,[tindakan] = @tindakan
      ,[harga] = @harga
      ,[total] = @total
 WHERE [kode_pembayaran]=@kode_pembayaran
";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_kunjungan", kode_kunjungan));
                param.Add(new SqlParameter("@kode_pembayaran", kode_pembayaran));
                param.Add(new SqlParameter("@waktu", waktu));
                param.Add(new SqlParameter("@tarif_dokter", tarif_dokter));
                param.Add(new SqlParameter("@obat", obat));
                param.Add(new SqlParameter("@tindakan", tindakan));
                param.Add(new SqlParameter("@harga", harga));
                param.Add(new SqlParameter("@total", (tarif_dokter + obat + harga)));
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

        public bool Delete_Pembayaran(string kode_pembayaran)
        {
            try
            {
                string query = @"USE [db_klinik]
DELETE FROM [dbo].[tb_pembayaran]
      WHERE [kode_pembayaran]=@kode_pembayaran
";
                da = new Common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pembayaran", kode_pembayaran));
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
        public DataTable Get_Data_Nota(string kode_pembayaran)
        {
            try
            {
                string query = @"SELECT p.[id] as id
      ,pe.[kode_pembayaran] as kode_pembayaran
      ,p.[kode_pasien] as kode_pasien
      ,po.[nama_poli] as nama_poli
      ,d.[nama_dokter] as nama_dokter
      ,k.[kode_kunjungan] as kode_kunjungan
      ,pe.[waktu] as waktu
      ,pe.[tarif_dokter] as tarif_dokter
      ,pe.[obat] as obat
      ,pe.[tindakan] as tindakan
      ,k.[metode_pembayaran] as metode
      ,pe.[harga] as harga
      ,pe.[total] as total
      ,(pe.[total]+pe.[kembalian]) as bayaran
      ,pe.[kembalian] as kembalian
                                from tb_kunjungan k INNER JOIN tb_dokter d 
                                on k.kode_dokter=d.kode_dokter inner join tb_pasien p 
                                on k.kode_pasien=p.kode_pasien inner join tb_pembayaran pe 
                                on pe.kode_kunjungan=k.kode_kunjungan inner join tb_poli po
                                on po.kode_poli=k.kode_poli
                                WHERE pe.kode_pembayaran=@kode_pembayaran";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_pembayaran", kode_pembayaran));
                DataTable dt = new DataTable();
                da = new Common();
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
    }
}
