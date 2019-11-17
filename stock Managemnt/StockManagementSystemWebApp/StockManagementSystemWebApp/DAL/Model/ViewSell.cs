using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Model
{
    [Serializable]
    public class ViewSell
    {
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int SaleQuantity { get; set; }
    }
}