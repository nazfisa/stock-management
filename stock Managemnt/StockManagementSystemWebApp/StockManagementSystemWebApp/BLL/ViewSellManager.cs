using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.BLL
{
    public class ViewSellManager
    {
        ViewSellsGateway viewSalesGateWay = new ViewSellsGateway();
        public List<StockOutViewModel> SearchByDate(string fromdate, string todate, string actionType)

        {
            return viewSalesGateWay.SearchByDate(fromdate, todate,actionType);
        }
    }
}