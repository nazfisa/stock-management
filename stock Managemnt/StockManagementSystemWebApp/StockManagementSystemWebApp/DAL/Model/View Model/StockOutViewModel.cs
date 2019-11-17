using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Model.View_Model
{
    public class StockOutViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int AvailableQuantity { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int StockOutId { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
    }
}