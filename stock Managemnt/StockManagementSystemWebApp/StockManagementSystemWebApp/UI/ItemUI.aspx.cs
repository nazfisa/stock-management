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
    public partial class ItemUI : System.Web.UI.Page
    {
        private CategoryManager categoryManager = new CategoryManager();
        private CompanyManager companyManager = new CompanyManager();
        private ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryDropDownList.DataSource = categoryManager.GetAllCategory();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "CategoryId";
                categoryDropDownList.DataBind();
            }
        }
        protected void categoryDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
                companyDropDownList.DataSource = companyManager.GetAllCompany();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();  
                companyDropDownList.Items.Insert(0,"Select Company"); 
        }

        private bool ValidateFrom()
        {
            int reorderLevel = Convert.ToInt32(reorderLabelTextBox.Text);
            string item = itemTextBox.Text;
            if (itemTextBox.Text.Trim() != "" && System.Text.RegularExpressions.Regex.IsMatch(item, "^[a-zA-Z ]")
                && categoryDropDownList.SelectedIndex != 0 &&
                companyDropDownList.SelectedIndex != 0 && reorderLevel > -1)
            {
                return true;
            }
            else
            {
                itemMessageLabel.Text = "Please Input Correctly";
                itemMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
            return false;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string rvalue = reorderLabelTextBox.Text;
            if (rvalue == "")
            {
                int value = 0;
                reorderLabelTextBox.Text = value.ToString();

                if (ValidateFrom())
                {
                    Item item = new Item();
                    item.ItemName = itemTextBox.Text.Trim();

                    item.ReorderLevel = Convert.ToInt32(reorderLabelTextBox.Text.Trim());
                    item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                    item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);

                    string message = itemManager.SaveItem(item);
                    itemMessageLabel.Text = message;
                }
            }
            else
            {
                int reorderValue = Convert.ToInt32(rvalue);
                if (reorderValue < 0)
                {
                    itemMessageLabel.Text = "Enter positive number";
                }
                else if (reorderValue >= 0)
                {
                    if (ValidateFrom())
                    {
                        Item item = new Item();
                        item.ItemName = itemTextBox.Text.Trim();

                        item.ReorderLevel = Convert.ToInt32(reorderLabelTextBox.Text.Trim());
                        item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                        item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);

                        string message = itemManager.SaveItem(item);
                        itemMessageLabel.Text = message;
                    }
                }
            }
           
          
         
        }

    }
}