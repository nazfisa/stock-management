using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class StockOutManager:BaseGateway
    {
        StockOutGateway stockOutGateway = new StockOutGateway();
        public string StockOut(string action, int quantity, int itemId)     
        {
            if (stockOutGateway.StockOut(action, quantity, itemId) > 0)
            {
                return "StockOut Entry Succesfull";
            }

            return "StockOut Entry Unsuccesfull";
        }
    }
}