using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ViewSellsGateway : BaseGateway
    {

        public List<StockOutViewModel> SearchByDate(string fromdate, string todate, string actionType)
        {

            SetConnection();
     
            string query = "SELECT * FROM StockOutView WHERE Date BETWEEN @fromDate " +
                           "AND @todate AND Action = @action";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@fromDate", fromdate);
            command.Parameters.AddWithValue("@todate", todate);
            command.Parameters.AddWithValue("@action", actionType);
            connection.Open();

            List<StockOutViewModel> AllCompanyItem = new List<StockOutViewModel>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                StockOutViewModel stockOut = new StockOutViewModel();
                stockOut.ItemId = Convert.ToInt32(reader["ItemId"]);
                stockOut.ItemName = reader["ItemName"].ToString();
                stockOut.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                stockOut.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                stockOut.CompanyName = reader["CompanyName"].ToString();
                stockOut.StockOutId = Convert.ToInt32(reader["StockOutId"]);
                stockOut.Action = reader["Action"].ToString();
                stockOut.Quantity = Convert.ToInt32(reader["Quantity"]);
                stockOut.Date = reader["Date"].ToString();

                AllCompanyItem.Add(stockOut);

            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;

        }
    }
}