using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MDF_Calculation_Tool
{
    public enum status { Active, Cancelled };

    class Order : INotifyPropertyChanged
    {


        private string supplier;

        public Order(string supplier, DateTime deliveryDate, DateTime deliveryHour, string orderNumber, string location, string product, string status, string geprint, string variant, double price, int amount, double total, double discount, int couponDiscount, double totalPayed, string paymentMethod, string transactionType, string transactionID, string couponCode, double costSupplier, double costMDF, double profitMDF, double commisionSupplier)
        {
            this.supplier = supplier;
            DeliveryDate = deliveryDate;
            DeliveryHour = deliveryHour;
            OrderNumber = orderNumber;
            Location = location;
            Product = product;
            Status = status;
            Geprint = geprint;
            Variant = variant;
            Price = price;
            this.amount = amount;
            Total = total;
            Discount = discount;
            CouponDiscount = couponDiscount;
            PaymentMethod = paymentMethod;
            TransactionType = transactionType;
            TransactionID = transactionID;
            CouponCode = couponCode;
            CostSupplier = costSupplier;
            CostMDF = costMDF;
            ProfitMDF = profitMDF;
            CommisionSupplier = commisionSupplier;
            TotalPayed = totalPayed;

        }

        public Order(string supplier, DateTime deliveryDate, DateTime deliveryHour, string orderNumber, string location, string product, string status, string geprint, string variant, double price, int amount, double total, double discount, int couponDiscount, double totalpayed, double totalPayed, string paymentMethod, string transactionType, string transactionID, string couponCode, double costSupplier, double costMDF, double profitMDF, double commisionSupplier)
        {
            Supplier = supplier;
            DeliveryDate = deliveryDate;
            DeliveryHour = deliveryHour;
            OrderNumber = orderNumber;
            Location = location;
            Product = product;
            Status = status;
            Geprint = geprint;
            Variant = variant;
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
        public string Status { get; set; }
        public string Geprint { get; set; }
        public string Variant { get; set; }
        public double Price { get; set; }
        public int amount { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public int CouponDiscount { get; set; }
        public double TotalPayed { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionType { get; set; }
        public string TransactionID { get; set; }
        public string CouponCode { get; set; }
        public double CostSupplier { get; set; }
        public double CostMDF { get; set; }
        public double ProfitMDF { get; set; }
        public double CommisionSupplier { get; set; }


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
