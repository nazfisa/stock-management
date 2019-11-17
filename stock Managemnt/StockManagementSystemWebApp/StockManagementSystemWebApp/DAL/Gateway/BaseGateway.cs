using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class BaseGateway
    {
        public string connectionString;
        public SqlConnection connection;
        public  SqlCommand command;
        public SqlDataReader reader;

        public void SetConnection()
        {
            connectionString = "Data Source=DESKTOP-5EO1ILG;Initial Catalog=StockManagementNauticDb;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
        }
    }
}