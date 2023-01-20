using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentalWebAppR.DAL
{
    public class UtilityDB
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-A2E5028\SQLSERVEREXPRESS; Initial Catalog=PropertyRentalManagementDB; User ID=sa; Password=87857988ai";
            conn.Open();
            return conn;
        }
    }
}