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
      public class Ctl_Antrian
    {

        Common da;
        public bool Insert_Antrian(int nomor_antrian, string kode_kunjungan, string poli)
        {
            try
            {
                string query = @"USE [db_klinik]
INSERT INTO [dbo].[tb_antrian]
           ([nomor_antrian]
           ,[kode_kunjungan]
           ,[poli]
            ,[status])
     VALUES
           (@nomor_antrian
           ,@kode_kunjungan
           ,@poli
           ,@status)
";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@nomor_antrian", nomor_antrian));
                param.Add(new SqlParameter("@poli", poli));
                param.Add(new SqlParameter("@kode_kunjungan", kode_kunjungan));
                param.Add(new SqlParameter("@status", "Masih"));
                da = new Common();
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
        public DataTable Get_Antrian(string poli)
        {

            try
            {
                string query = @"USE [db_klinik]
SELECT [id]
      ,[nomor_antrian]
      ,[kode_kunjungan]
      ,[poli]
      ,[status]
  FROM [dbo].[tb_antrian] WHERE [poli]=@poli
";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@poli", poli));

                Common da = new Common();
                da.OpenConnection();
                DataTable dt = da.ExecuteQuery(query, param);
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

