using GymWebDeploy.Models.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
namespace GymWebDeploy.Models.Dao
{
    public class GenericBaseDao
    {
        public List<T> Get<T>(string querySQL) where T : class, new()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = querySQL,
                Connection = conn
            };
            try
            {
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<T> listData = SqlUtils.SqlToList<T>(sdr);
                return listData;
            }
            finally {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public bool ExecuteQuery(string query)
        {
            int result = -1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = query,
                Connection = conn
            };
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
                if (result == 1) { return true; }
                else { return false; }
            }catch(Exception ex)
            {
                System.Console.Write(ex.Message.ToString());
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }
    }
}