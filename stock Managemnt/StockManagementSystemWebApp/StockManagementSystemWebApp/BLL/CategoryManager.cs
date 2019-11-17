using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();
        public string SaveCategory(Category categoryObj)
        {

            Category acategory = categoryGateway.IsExisted(categoryObj);

            if (acategory == null)
            {
                int row = categoryGateway.SaveCategory(categoryObj);
                if (row > 0)
                {
                    return "Successfully Inserted";
                }
                else
                {
                    return "Insert Failed";
                }
            }
            else
            {
                return "Category Already Existed";
            }

        }

        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

        public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

        public bool UpdateCategoryById(Category category)
        {
            Category categoryExisted = categoryGateway.IsExisted(category);
            if (categoryExisted == null)
            {
                categoryGateway.UpdateByCategoryId(category);
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}