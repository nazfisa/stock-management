using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.BLL
{
    public class ViewSearchManager
    {
        ViewSearchGateway viewSearchGateWay = new ViewSearchGateway();
        public List<ItemsViewModel> SearchByCompany(int companyId, string companyName)
        {

            return viewSearchGateWay.SearchByCompany(companyId, companyName);

        }
        public List<ItemsViewModel> SearchByCategory(int categoryId)
        {
            return viewSearchGateWay.SearchByCategory(categoryId);
        }

        public List<ItemsViewModel> SearchByCompanyAndCategory(int companyid, int CategoryId)
        {
            return viewSearchGateWay.SearchByCompanyAndCategory(companyid, CategoryId);
        }

        public List<ItemsViewModel> SearchByAll()
        {
            return viewSearchGateWay.SearchByAll();
        }
    }
}