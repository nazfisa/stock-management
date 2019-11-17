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
    public partial class CategoryUI : System.Web.UI.Page
    {
        private CategoryManager categoryManager=new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryGridView.DataSource = categoryManager.GetAllCategory();
            categoryGridView.DataBind();
        }

        protected void categorySaveButton_Click(object sender, EventArgs e)
        {

            if (categoryTextBox.Text.Trim() != "")
            {
                string catagoryName = categoryTextBox.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(catagoryName, "^[a-zA-Z ]"))
                {
                    Category category = new Category();
                    category.CategoryName = categoryTextBox.Text.Trim();
                    string message = categoryManager.SaveCategory(category);
                    categoryOutputLabel.Text = message;
                    categoryGridView.DataSource = categoryManager.GetAllCategory();
                    categoryGridView.DataBind();
                    categoryTextBox.Text = String.Empty;
                }
                else
                {
                    categoryOutputLabel.Text = "You need to Insert Your Category Name Correctly";
                    categoryTextBox.Text = String.Empty;
                    categoryOutputLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                categoryOutputLabel.Text = "You need to Insert Your Category Name Correctly";
                categoryTextBox.Text = String.Empty;
                categoryOutputLabel.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("idHiddenField") as HiddenField;
            int id = Convert.ToInt32(hiddenField.Value);
            Response.Redirect("CategoryUpdateUI.aspx?Id=" + id);
        }
    }
}