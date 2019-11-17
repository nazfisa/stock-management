using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ViewSearchGateway : BaseGateway
    {
        public List<ItemsViewModel> SearchByCompany(int companyId, string companyName)
        {

            SetConnection();
            string query = "SELECT * FROM ItemsView WHERE CompanyId= @companyId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyId", companyId);
            connection.Open();

            List<ItemsViewModel> companyList = new List<ItemsViewModel>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                ItemsViewModel aitem = new ItemsViewModel();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = Convert.ToInt32(reorderLevel);
                aitem.AvailableQuantity = Convert.ToInt32(availableQuantity);
                aitem.CompanyName = companyName;
                companyList.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return companyList;

        }

        public List<ItemsViewModel> SearchByCategory(int categoryId)
        {
            SetConnection();
            string query = "SELECT * FROM ItemsView WHERE CategoryId= @categoryId";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);

            connection.Open();

            List<ItemsViewModel> AllCompanyItem = new List<ItemsViewModel>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                string companyName = reader["CompanyName"].ToString();

                ItemsViewModel aitem = new ItemsViewModel();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel;
                aitem.AvailableQuantity = availableQuantity;
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        }

        public List<ItemsViewModel> SearchByCompanyAndCategory(int companyid, int categoryId)
        {
            SetConnection();
            string query = "SELECT * FROM ItemsView WHERE CompanyId = @companyId AND CategoryId = @categoryId";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@companyId", companyid);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            connection.Open();

            List<ItemsViewModel> AllCompanyItem = new List<ItemsViewModel>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                string companyName = reader["CompanyName"].ToString();

                ItemsViewModel aitem = new ItemsViewModel();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel;
                aitem.AvailableQuantity = availableQuantity;
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        }


        public List<ItemsViewModel> SearchByAll()
        {
            SetConnection();
            string query = "SELECT * FROM ItemsView";
            command = new SqlCommand(query, connection);
            connection.Open();

            List<ItemsViewModel> AllCompanyItem = new List<ItemsViewModel>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                int companyId = Convert.ToInt32(reader["CompanyId"]);
                string companyName = reader["CompanyName"].ToString();

                ItemsViewModel aitem = new ItemsViewModel();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel;
                aitem.AvailableQuantity = availableQuantity;
                aitem.CompanyId = companyId;
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        }
    }
}