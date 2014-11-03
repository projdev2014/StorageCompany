using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StorageCompany.DataAccessLayer
{
    public class ConnectionSql
    {
        public static SqlConnection connection;

        public static SqlConnection getConnection()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/StorageCompany");
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["StorageEntityDataModel"];
                if (connString != null)
                {
                    Console.WriteLine("StorageEntityDataModel connection string = \"{0}\"", connString.ConnectionString);
                    connection = new SqlConnection(connString.ConnectionString);
                }
                else
                {
                    Console.WriteLine("No StorageEntityDataModel connection string");
                }

            }
            return connection;
        }
    }
}