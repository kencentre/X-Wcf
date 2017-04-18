using System;
using System.Configuration;
using E_Common;
namespace SqlServerDAL
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
