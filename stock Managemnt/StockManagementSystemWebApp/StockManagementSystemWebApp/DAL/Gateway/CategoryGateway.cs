using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class CategoryGateway : BaseGateway
    {
        public Category IsExisted(Category category)
        {
            SetConnection();
            string query = "SELECT * FROM Category WHERE CategoryName='" + category.CategoryName + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            Category aCategory = null;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                string categoryName = reader["CategoryName"].ToString();
                aCategory = new Category(categoryId, categoryName);
                reader.Close();
                connection.Close();
                return aCategory;
            }
            reader.Close();
            connection.Close();
            return aCategory;
        }
        public int SaveCategory(Category categoryObj)
        {
            SetConnection();
            string query = "INSERT INTO Category VALUES('" + categoryObj.CategoryName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Category> GetAllCategory()
        {
            SetConnection();
            string query = "SELECT * FROM Category";
            command = new SqlCommand(query, connection);
            connection.Open();

            List<Category> Categorylist = new List<Category>();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int categoryId = (int)reader["CategoryId"];
                string categoryName = reader["CategoryName"].ToString();
                Category aCategory = new Category();
                aCategory.CategoryId = categoryId;
                aCategory.CategoryName = categoryName;
                Categorylist.Add(aCategory);
            }
            reader.Close();
            connection.Close();

            return Categorylist;
        }

        public Category GetCategoryById(int id)
        {
            SetConnection();
            string query = "SELECT * FROM Category WHERE CategoryId =" + id;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Category category = null;
            if (reader.HasRows)
            {
                category = new Category();
                int categoryID = (int)reader["CategoryId"];
                string categoryName = reader["CategoryName"].ToString();
                category.CategoryId = categoryID;
                category.CategoryName = categoryName;
                reader.Close();
                connection.Close();
            }
            return category;

        }

        public int UpdateByCategoryId(Category category)
        {
            SetConnection();
            string query = "UPDATE Category SET CategoryName='" + category.CategoryName +
                "'WHERE CategoryId =" + category.CategoryId;
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }


        public Category UpateCategoryIsExcited(Category category)
        {
            SetConnection();
            string query = "SELECT * FROM Category WHERE CategoryName='" + category.CategoryName + 
                "' AND CategoryId <>" + category.CategoryId;
            command = new SqlCommand(query, connection);
            connection.Open();
            Category aCategory = null;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int categoryID = Convert.ToInt32(reader["CategoryId"]);
                string categoryName = reader["CategoryName"].ToString();
                aCategory = new Category(categoryID, categoryName);
                reader.Close();
                connection.Close();
                return aCategory;
            }
            reader.Close();
            connection.Close();
            return aCategory;
        }
    }
}