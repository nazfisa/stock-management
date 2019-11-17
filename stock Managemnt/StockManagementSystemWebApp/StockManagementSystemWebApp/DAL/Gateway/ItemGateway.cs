using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ItemGateway : BaseGateway
    {
        public int SaveItem(Item item)
        {
            SetConnection();
            string query = "INSERT INTO Item (ItemName,ReorderLevel,AvailableQuantity,CompanyId,CategoryId)" +
                           " VALUES(@itemName,@reorderLevel,@availableQuantity,@companyId,@categoryId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemName", item.ItemName);
            command.Parameters.AddWithValue("@reorderLevel", item.ReorderLevel);
            command.Parameters.AddWithValue("@availableQuantity", item.AvailableQuantity);
            command.Parameters.AddWithValue("@companyId", item.CompanyId);
            command.Parameters.AddWithValue("@categoryId", item.CategoryId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsItemExist(Item item)
        {
            SetConnection();
            string query =
                "SELECT * FROM ItemsView WHERE "
                    + "ItemName = @itemName AND CompanyId = @companyId AND CategoryId = @categoryId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemName", item.ItemName);
            command.Parameters.AddWithValue("@companyId", item.CompanyId);
            command.Parameters.AddWithValue("@categoryId", item.CategoryId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public List<ItemsViewModel> GetCompanyId(int companyId)
        {
            SetConnection();
            string query = "SELECT * FROM ItemsView WHERE CompanyId = @companyId";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@companyId", companyId);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemsViewModel> itemList = new List<ItemsViewModel>();
            while (reader.Read())                                       
            {
                ItemsViewModel item = new ItemsViewModel();
                item.ItemId = Convert.ToInt32(reader["ItemId"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyName"]).ToString();
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.CategoryName = (reader["CategoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

        public ItemsViewModel GetItemId(int itemId)
        {
            SetConnection();
            string query = "SELECT * FROM ItemsView WHERE  ItemId = @itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", itemId);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();

            ItemsViewModel item = new ItemsViewModel();
            item.ItemId= Convert.ToInt32(reader["ItemId"]);
            item.ItemName = reader["ItemName"].ToString();
            item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
            item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
            item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
            item.CompanyName = (reader["CompanyName"]).ToString();
            item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
            item.CategoryName = (reader["CategoryName"]).ToString();

            connection.Close();

            return item;
        }  
    }
}