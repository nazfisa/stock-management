using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.DAL.Model.View_Model;

namespace StockManagementSystemWebApp.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();

        public string SaveItem(Item item)
        {
            if (itemGateway.IsItemExist(item))
            {
                return "Item Already Exist...";
            }
            int rowAffect = itemGateway.SaveItem(item);
            if (rowAffect > 0)
            {
                return "Item Saved Succesfully";
            }
            return "Item Save Failed";
        }

        public List<ItemsViewModel> GetCompanyId(int companyId)
        {
            return itemGateway.GetCompanyId(companyId);
        }

        public ItemsViewModel GetItemId(int itemId)
        {
            return itemGateway.GetItemId(itemId);
        }


       
    }
}