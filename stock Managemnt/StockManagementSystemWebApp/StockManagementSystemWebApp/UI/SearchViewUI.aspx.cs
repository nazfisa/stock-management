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
    public partial class SearchViewUI : System.Web.UI.Page
    {
        public CategoryManager categoryManager = new CategoryManager();
        public CompanyManager companyManager = new CompanyManager();
        public ItemManager itemManager = new ItemManager();
        public ViewSearchManager viewSearchManager = new ViewSearchManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownList();

            }
        }

        protected void FillDropDownList()
        {
            companySearchDropDownList.DataSource = companyManager.GetAllCompany();
            companySearchDropDownList.DataTextField = "CompanyName";
            companySearchDropDownList.DataValueField = "CompanyId";
            companySearchDropDownList.DataBind();
            companySearchDropDownList.Items.Insert(0, "Select Company");

            categorySearchDropDownList.DataSource = categoryManager.GetAllCategory();
            categorySearchDropDownList.DataTextField = "CategoryName";
            categorySearchDropDownList.DataValueField = "CategoryId";
            categorySearchDropDownList.DataBind();
            categorySearchDropDownList.Items.Insert(0, "Select Category");


        }
        



        protected void searchButton_Click(object sender, EventArgs e)
        {
            ViewSearchManager viewSearchManager = new ViewSearchManager();

            if (companySearchDropDownList.SelectedIndex != 0 && categorySearchDropDownList.SelectedIndex == 0)
            {
                int companyId = Convert.ToInt32(companySearchDropDownList.SelectedItem.Value);
                string companyName = companySearchDropDownList.SelectedItem.Text;
                List<ItemsViewModel> asearchView = viewSearchManager.SearchByCompany(companyId, companyName);
                if (asearchView.Count > 0)
                {
                    ViewState["stockin"] = asearchView;
                    searchGridViewList.DataSource = asearchView;
                    searchGridViewList.DataBind();
                }


            }

            else if (companySearchDropDownList.SelectedIndex == 0 && categorySearchDropDownList.SelectedIndex != 0)
            {
                int categoryId = Convert.ToInt32(categorySearchDropDownList.SelectedItem.Value);
                List<ItemsViewModel> asearchView = viewSearchManager.SearchByCategory(categoryId);
                if (asearchView.Count > 0)
                {
                    ViewState["stockin"] = asearchView;
                    searchGridViewList.DataSource = asearchView;
                    searchGridViewList.DataBind();
                }
                
            }
            else if (companySearchDropDownList.SelectedIndex != 0 && companySearchDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companySearchDropDownList.SelectedItem.Value);
                int categoryId = Convert.ToInt32(categorySearchDropDownList.SelectedItem.Value);
                List<ItemsViewModel> asearchView = viewSearchManager.SearchByCompanyAndCategory(companyId, categoryId);
                if (asearchView.Count > 0)
                {
                    ViewState["stockin"] = asearchView;
                    searchGridViewList.DataSource = asearchView;
                    searchGridViewList.DataBind();
                }
                else
                {
                    outputLabel.Visible = true;
                    outputLabel.Text = "Quantity not Available";
                    outputLabel.ForeColor = System.Drawing.Color.Red;
                    searchGridViewList.DataSource = asearchView;
                    searchGridViewList.DataBind();

                }
            }
            
            else if (companySearchDropDownList.SelectedIndex == 0 && categorySearchDropDownList.SelectedIndex == 0)
            {
                searchGridViewList.DataSource = viewSearchManager.SearchByAll();
                searchGridViewList.DataBind();

            }
        }



    }
}