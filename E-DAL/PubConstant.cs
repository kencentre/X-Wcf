using System;
using System.Configuration;
using E_Common;
namespace OracleDAL
{
    public class PubConstant
    {
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


            return connectionString;
        }
    }
}
