using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        private CompanyManager companyManager = new CompanyManager();
        private StockInManager stockInManager = new StockInManager();
        private ItemManager itemManager = new ItemManager();
             
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillUpDropDown();
            }
        }

        private void FillUpDropDown()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataValueField = "CompanyId";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.Items.Insert(0, "Select Item");
            itemDropDownList.Enabled = false;
            saveButton.Enabled = false;
        }

        protected void companyDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0)
            {
                itemDropDownList.Enabled = false;
                stockInQuantityTextBox.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLevelTextBox.Text = String.Empty;
                itemDropDownList.SelectedIndex = 0;
                saveButton.Enabled = false;
                
            }
            else
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;
                itemDropDownList.DataSource = itemManager.GetCompanyId(companyId);
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
            }

        }

        protected void itemDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                stockInQuantityTextBox.Enabled = true;
                saveButton.Enabled = true;
                ItemsViewModel item = itemManager.GetItemId(itemId);
                availableQuantityIdHiddenField.Value = item.AvailableQuantity.ToString();
                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
            }
            else
            { 
                stockInQuantityTextBox.Enabled = false;
                saveButton.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLevelTextBox.Text = String.Empty;
            }
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            

            if (stockInQuantityTextBox.Text.Trim() != "" && System.Text.RegularExpressions.Regex.IsMatch(stockInQuantityTextBox.Text, "^[0-9]*$"))
            {
                int availableQuantity = Convert.ToInt32(availableQuantityIdHiddenField.Value);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                int stockQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                if (stockQuantity != 0)
                {
                    int sumOfTotalQuantity = availableQuantity + stockQuantity;
                    string message = stockInManager.StockUpdate(sumOfTotalQuantity, itemId);
                    outputLabel.Text = message;
                    reorderLevelTextBox.Text = String.Empty;
                    availableQuantityTextBox.Text = String.Empty;
                    itemDropDownList.SelectedIndex = 0;
                    stockInQuantityTextBox.Text = String.Empty;
                    FillUpDropDown();
                    
                }
            }
            else
            {
                stockInQuantityTextBox.Text = String.Empty;
                outputLabel.Text = "Please Give a Valid StockIn Quantity";
                outputLabel.ForeColor = System.Drawing.Color.Red;
            }

        }       
}
}