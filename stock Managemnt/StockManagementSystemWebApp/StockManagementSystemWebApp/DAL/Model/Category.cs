﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category()
        {

        }
        public Category(int category, string categoryName)
        {
            CategoryId = category;
            CategoryName = categoryName;
        }
    }
}