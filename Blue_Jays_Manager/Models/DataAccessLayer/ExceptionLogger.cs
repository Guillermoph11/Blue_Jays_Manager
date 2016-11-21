using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class ExceptionLogger
    {
        public static void Log(Exception ex)
        {
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = null;
                cmd = new OracleCommand("spInsertException", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExceptionMessage", ex.Message);
                cmd.Parameters.AddWithValue(@"StackTrace", ex.StackTrace);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}