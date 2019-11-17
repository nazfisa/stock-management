using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway = new StockInGateway();
        public string StockUpdate(int sumOfTotalQuantity, int itemId)
        {
            if (stockInGateway.StockIn(sumOfTotalQuantity, itemId) > 0)
            {
                return "Stock In Successfull";
            }

            return "Stock In Unsuccessfull";
        }
    }
}