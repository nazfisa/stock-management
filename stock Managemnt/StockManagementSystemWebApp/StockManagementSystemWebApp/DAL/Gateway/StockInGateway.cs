using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class StockInGateway : BaseGateway
    {

        public int StockIn(int sumOfTotalQuantity, int itemId)
        {
            SetConnection();
            string query = "UPDATE Item SET AvailableQuantity = @sumOfTotalQuantity WHERE ItemId = @itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@sumOfTotalQuantity", sumOfTotalQuantity);
            command.Parameters.AddWithValue("@itemId", itemId);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}