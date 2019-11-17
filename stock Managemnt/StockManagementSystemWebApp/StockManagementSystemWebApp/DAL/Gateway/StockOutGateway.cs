using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class StockOutGateway : BaseGateway
    {
        public int StockOut(string action, int quantity, int itemId)
        {
            SetConnection();
            string query = "INSERT INTO StockOut(Action,Quantity,ItemId,Date)" +
                           " VALUES(@action, @quantity,@itemId,@Date)";
            command = new SqlCommand(query, connection);


            string ad = DateTime.Now.ToString("yyyy-MM-dd");
            command.Parameters.AddWithValue("@action", action);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@itemId", itemId);
            command.Parameters.AddWithValue("@Date", ad);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}