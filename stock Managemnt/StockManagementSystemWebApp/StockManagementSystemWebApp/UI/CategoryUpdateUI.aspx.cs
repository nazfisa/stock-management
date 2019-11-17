using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class CategoryUpdateUI : System.Web.UI.Page
    {
        CategoryManager categoryManager=new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                Category categoryItem = categoryManager.GetCategoryById(id);

                if (categoryItem != null)
                {
                    idHiddenField.Value = categoryItem.CategoryId.ToString();
                    categoryTextBox.Text = categoryItem.CategoryName;
                }
            }
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
             if (categoryTextBox.Text.Trim() != "")
            {
                string catagoryName = categoryTextBox.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(catagoryName, "^[a-zA-Z ]"))
                {
                    Category categoryItem = new Category();
                    categoryItem.CategoryId = Convert.ToInt32(idHiddenField.Value);
                    categoryItem.CategoryName = categoryTextBox.Text;
                    categoryManager.UpdateCategoryById(categoryItem);
                    Response.Redirect("CategoryUI.aspx");
                }
                else
                {
                    outputLabel.Text = "You need to Insert Your Category Name Correctly";
                    categoryTextBox.Text = String.Empty;
                    outputLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
             else
             {
                 outputLabel.Text = "You need to Insert Your Category Name Correctly";
                 categoryTextBox.Text = String.Empty;
                 outputLabel.ForeColor = System.Drawing.Color.Red;
             }


            }
    }
}