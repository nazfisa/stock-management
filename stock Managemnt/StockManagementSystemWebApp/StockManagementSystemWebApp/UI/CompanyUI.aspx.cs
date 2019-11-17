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
    public partial class CompanyUI : System.Web.UI.Page
    {
        private CompanyManager companyManager=new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyGridView.DataSource = companyManager.GetAllCompany();
            companyGridView.DataBind();
        }

        protected void companyNameSaveButton_Click(object sender, EventArgs e)
        {
            if (companyNameTextBox.Text.Trim() != "")
            {
                string copanyName = companyNameTextBox.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(copanyName, "^[a-zA-Z ]")) 
                {
                    Company company = new Company();
                    company.CompanyName = companyNameTextBox.Text.Trim();
                    string message = companyManager.SaveCompany(company);
                    companyOutputShowLabel.Text = message;
                    companyGridView.DataSource = companyManager.GetAllCompany();
                    companyGridView.DataBind();
                    companyNameTextBox.Text = String.Empty;
                }
                else
                {
                    companyOutputShowLabel.Text = "You need Insert Your Company Name Correctly";
                    companyNameTextBox.Text = String.Empty;
                    companyOutputShowLabel.ForeColor = System.Drawing.Color.Red;

                }

            }
            else
            {
                companyOutputShowLabel.Text = "You need Insert Your Company Name Correctly";
                companyNameTextBox.Text = String.Empty;
                companyOutputShowLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void companyGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}