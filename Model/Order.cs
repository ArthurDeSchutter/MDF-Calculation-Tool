using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MDF_Calculation_Tool
{
    public enum status { Active, Cancelled };

    class Order : INotifyPropertyChanged
    {
        public Order(string supplier, DateTime deliveryDate, DateTime deliveryHour, string orderNumber, string location, string product, string comment, string status, string geprint, string variant, string type, string sauce, string extra, int price, int amount, int total, int discount, int couponDiscount, int totalPayed, string paymentMethod, string transactionType, int transactionID, string couponCode, int costSupplier, int costMDF, int profitMDF, int commisionSupplier)
        {
            Supplier = supplier;
            DeliveryDate = deliveryDate;
            DeliveryHour = deliveryHour;
            OrderNumber = orderNumber;
            Location = location;
            Product = product;
            Comment = comment;
            Status = status;
            Geprint = geprint;
            Variant = variant;
            Type = type;
            Sauce = sauce;
            Extra = extra;
            Price = price;
            this.amount = amount;
            Total = total;
            Discount = discount;
            CouponDiscount = couponDiscount;
            TotalPayed = totalPayed;
            PaymentMethod = paymentMethod;
            TransactionType = transactionType;
            TransactionID = transactionID;
            CouponCode = couponCode;
            CostSupplier = costSupplier;
            CostMDF = costMDF;
            ProfitMDF = profitMDF;
            CommisionSupplier = commisionSupplier;
        }

        private string supplier;
        public string Supplier
        {
            get
            {
                return supplier;
            }
            set
            {
                supplier = value;
                OnPropertyChanged("supplier");
            }
        }
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryHour { get; set; }
        public string OrderNumber { get; set; }
        public string Location { get; set; }
        public string Product { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
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
        public string PaymentMethod { get; set; }
        public string TransactionType { get; set; }
        public int TransactionID { get; set; }
        public string CouponCode { get; set; }
        public int CostSupplier { get; set; }
        public int CostMDF { get; set; }
        public int ProfitMDF { get; set; }
        public int CommisionSupplier { get; set; }


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
