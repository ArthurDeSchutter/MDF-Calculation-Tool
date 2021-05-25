using System;
using System.Collections.Generic;
using System.Text;

namespace MDF_Calculation_Tool
{
    public enum status { Active, Cancelled };

    class Order
    {

        public string Supplier { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryHour { get; set; }
        public string OrderNumber { get; set; }
        public string Location { get; set; }
        public string Product { get; set; }
        public string Comment { get; set; }
        public status Status { get; set; }
        public string Geprint { get; set; }
        public string Variant { get; set; }
        public string Type { get; set; }
        public string Sauce { get; set; }
        public string Extra { get; set; }
        public int Price { get; set; }
        public int amount { get; set; }
        public int Total { get; set; }
        public int Discount { get; set; }
        public int CouponDiscount { get; set; }
        public int TotalPayed { get; set; }
        //TODO implement payment methods from database
        public string PaymentMethod { get; set; }
        //TODO enum 
        public string TransactionType { get; set; }
        public int TransactionID { get; set; }
        public string CouponCode { get; set; }
        public int CostSupplier { get; set; }
        public int CostMDF { get; set; }
        public int ProfitMDF { get; set; }
        public int CommisionSupplier { get; set; }

    }
}
