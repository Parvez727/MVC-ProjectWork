using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ProjectWork.Models
{
    public class Product_Sales
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> purchase_price { get; set; }
        public string sale_id { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> sales_price { get; set; }
        public Nullable<decimal> Total_price { get; set; }

    }
}