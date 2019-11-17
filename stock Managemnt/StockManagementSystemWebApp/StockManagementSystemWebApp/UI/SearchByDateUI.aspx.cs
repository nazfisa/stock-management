using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;

namespace StockManagementSystemWebApp.UI
{
    public partial class SearchByDateUI : System.Web.UI.Page
    {
        ViewSellManager viewSellManager = new ViewSellManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Text == "" || toDateTextBox.Text == "")
            {
                outputLabel.Text = "Please Insert both Date";
                outputLabel.ForeColor = System.Drawing.Color.Red;
                viewSellsGridView.DataBind();
            }
            else
            {
                if (DateTime.Compare(Convert.ToDateTime(fromDateTextBox.Text), Convert.ToDateTime(toDateTextBox.Text)) >
                    0)
                {
                    outputLabel.Text = "Give Proper Date";
                    
                }
                else
                {
                 DateTime formDateTime = Convert.ToDateTime((fromDateTextBox.Text));
                string formdatetimeone = formDateTime.ToString("yyyy-MM-dd");
                DateTime toDateTime = Convert.ToDateTime(toDateTextBox.Text);
                string todatetimeone = toDateTime.ToString("yyyy-MM-dd");
                viewSellsGridView.DataSource = viewSellManager.SearchByDate(formdatetimeone, todatetimeone,"sell");
                viewSellsGridView.DataBind();
                outputLabel.Text = String.Empty;
                }
                
            }

        }
    }
}