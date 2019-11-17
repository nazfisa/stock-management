using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        private CompanyManager companyManager = new CompanyManager();
        private ItemManager itemManager = new ItemManager();
        private StockOutManager stockOutManager = new StockOutManager();
        private StockInManager stockInManager = new StockInManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
            }
        }

        public void FillDropDown()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataValueField = "CompanyId";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            reorderLevelTextBox.Text = String.Empty;
            availableQuantityTextBox.Text = String.Empty;
            addButton.Enabled = false;
            companyDropDownList.Items.Insert(0, "Select Company");
        }


        protected void companyDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;

                itemDropDownList.DataSource = itemManager.GetCompanyId(companyId);
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
            }
            else
            {
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLevelTextBox.Text = String.Empty;
            }
        }


        protected void itemDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                ItemsViewModel itemViewModel = itemManager.GetItemId(itemId);

                addButton.Enabled = true;
                reorderLevelTextBox.Text = itemViewModel.ReorderLevel.ToString();
                availableQuantityTextBox.Text = itemViewModel.AvailableQuantity.ToString();
                addButton.Enabled = true;
            }
            else
            {
                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
            }
        }

        

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (stockOutQuantityTextBox.Text.Trim() == "" )
            {
                outputLabel.Text = "Give Proper Quantity";
                outputLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            int stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            if (stockOutQuantity < 1)
            {
                outputLabel.Text = "Give Proper Quantity";
                outputLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }


           

            List<ItemsViewModel> itemList = new List<ItemsViewModel>();
            int itemId = Convert.ToInt32(Convert.ToInt32(itemDropDownList.SelectedValue));

            ItemsViewModel itemViewModel = itemManager.GetItemId(itemId);

            itemViewModel.AvailableQuantity -= stockOutQuantity;

            if (ViewState["itemList"] == null)                 
            {
                if (itemViewModel.AvailableQuantity > 0)        
                {
                    itemList.Add(itemViewModel);
                    stockOutGridView.DataSource = itemList;
                    stockOutGridView.DataBind();
                    stockOutQuantityTextBox.Text = String.Empty;
                    ViewState["itemList"] = itemList;
                    outputLabel.Text = String.Empty;
                }
                else
                {
                    outputLabel.Text = "Stock Out is Out of Range";
                    outputLabel.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                itemList = (List<ItemsViewModel>)ViewState["itemList"];    

                int pointer = 0;                                           

                foreach (ItemsViewModel item in itemList)                 
                {
                    if (item.ItemId == itemId)
                    {
                        item.AvailableQuantity -= stockOutQuantity;       
                        if (item.AvailableQuantity > 0)
                        {
                            outputLabel.Text = String.Empty;
                            pointer++;
                            break;
                        }

                        outputLabel.Text = "Stock Out is Out of Range";
                        outputLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }

                if (pointer == 0)                                     
                {
                    if (itemViewModel.AvailableQuantity > 0)
                    {
                        outputLabel.Text = String.Empty;
                        itemList.Add(itemViewModel);
                    }
                    else
                    {
                        outputLabel.Text = "Stock Out is Out of Range";
                        outputLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
                stockOutGridView.DataSource = itemList;
                stockOutGridView.DataBind();
                ViewState["itemList"] = itemList;
                stockOutQuantityTextBox.Text = String.Empty;
            }   
                                            


        
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<ItemsViewModel> itemList = (List<ItemsViewModel>)ViewState["itemList"];

            if (itemList == null)
            {
                outputLabel.Text = "Your Cart is Empty ";
                outputLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            foreach (ItemsViewModel item in itemList)
            {
                ItemsViewModel itemViewModel = itemManager.GetItemId(item.ItemId);
                int totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                stockInManager.StockUpdate(item.AvailableQuantity, item.ItemId);     
                stockOutManager.StockOut("sell", totalStockOut, item.ItemId);     
            }
            outputLabel.Text = "Items Succesfully Sold";
            outputLabel.ForeColor = System.Drawing.Color.Green;

            ViewState["itemList"] = null;

            FillDropDown();
            
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<ItemsViewModel> itemList = (List<ItemsViewModel>)ViewState["itemList"];

            if (itemList == null)
            {
                outputLabel.Text = "Your Cart is Empty";
                outputLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            foreach (ItemsViewModel item in itemList)
            {
                ItemsViewModel itemViewModel = itemManager.GetItemId(item.ItemId);
                int totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                stockInManager.StockUpdate(item.AvailableQuantity, item.ItemId);
                stockOutManager.StockOut("damage", totalStockOut, item.ItemId);
            }
            outputLabel.Text = "Items Are Damaged";
            outputLabel.ForeColor = System.Drawing.Color.Red;

            ViewState["itemList"] = null;
            FillDropDown();
          
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<ItemsViewModel> itemList = (List<ItemsViewModel>)ViewState["itemList"];

            if (itemList == null)
            {
                outputLabel.Text = "Your Cart is Empty";
                outputLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            foreach (ItemsViewModel item in itemList)
            {
                ItemsViewModel itemViewModel = itemManager.GetItemId(item.ItemId);
                int totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                stockInManager.StockUpdate(item.AvailableQuantity, item.ItemId);
                stockOutManager.StockOut("lost", totalStockOut, item.ItemId);
            }
            outputLabel.Text = "Lost Item Entry Added";
            outputLabel.ForeColor = System.Drawing.Color.Red;
            ViewState["itemList"] = null;
            FillDropDown();
           
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }




    }
}