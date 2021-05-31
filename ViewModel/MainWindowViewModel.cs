using ExcelDataReader;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.Configuration;

namespace MDF_Calculation_Tool.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Order> _orderlist;
        private string pathtoexcel;

        public MainWindowViewModel()
        {
            _orderlist = new ObservableCollection<Order>
            {
            };
        }

        public ObservableCollection<Order> OrderList
        {
            get { return _orderlist; }
            set { _orderlist = value; }
        }

        public string PathToExcel
        {
            get
            {
                return pathtoexcel;
            }
            set
            {
                pathtoexcel = value;
                OnPropertyChanged("pathtoexcel");
            }
        }

        public ICommand PassExcelPath
        {
            get { return new DelegateCommand<object>(FuncToCall, FuncToEvaluate); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FuncToCall(object context)
        {
            DataSet result = ReadExcel(PathToExcel);

            for (int i = 1; i < result.Tables[0].Rows.Count; i++)
            {
                string Supplier = result.Tables[0].Rows[i][0].ToString();
                DateTime DeliveryDate = Convert.ToDateTime(result.Tables[0].Rows[i][1].ToString());
                DateTime DeliveryHour = Convert.ToDateTime(result.Tables[0].Rows[i][2].ToString());
                string OrderNumber = result.Tables[0].Rows[i][4].ToString();
                string Location = result.Tables[0].Rows[i][5].ToString();
                string Product = result.Tables[0].Rows[i][6].ToString();
                string Status = result.Tables[0].Rows[i][8].ToString();
                string Geprint = result.Tables[0].Rows[i][9].ToString();
                string Variant = result.Tables[0].Rows[i][10].ToString();
                double Price = Convert.ToDouble(result.Tables[0].Rows[i][14]);
                int amount = Convert.ToInt32(result.Tables[0].Rows[i][15]);
                double Total = Convert.ToDouble(result.Tables[0].Rows[i][16]);
                double Discount = (double)getDoubleFromExcel(result.Tables[0].Rows[i][17]);
                int CouponDiscount = (int)getIntFromExcel(result.Tables[0].Rows[i][18]);
                double TotalPayed = Convert.ToDouble(result.Tables[0].Rows[i][19]);
                string PaymentMethod = result.Tables[0].Rows[i][20].ToString();
                string TransactionType = result.Tables[0].Rows[i][21].ToString(); 
                string TransactionID = result.Tables[0].Rows[i][22].ToString();
                string CouponCode = result.Tables[0].Rows[i][22].ToString();
                double CostSupplier = (double)getDoubleFromExcel(result.Tables[0].Rows[i][23]);
                double CostMDF = (double)getDoubleFromExcel(result.Tables[0].Rows[i][24]);
                double ProfitMDF = (double)getDoubleFromExcel(result.Tables[0].Rows[i][25]);
                double CommisionSupplier = (double)getDoubleFromExcel(result.Tables[0].Rows[i][26]);

                _orderlist.Add(new Order(Supplier, DeliveryDate, DeliveryHour, OrderNumber, Location, Product, Status,
                                         Geprint, Variant, Price, amount, Total, Discount, CouponDiscount, TotalPayed,
                                         PaymentMethod, TransactionType, TransactionID, CouponCode, CostSupplier,
                                         CostMDF, ProfitMDF, CommisionSupplier));



            }
            
        }
        private bool FuncToEvaluate(object value)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }


        public DataSet ReadExcel(string path)
        {
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    DataSet result = reader.AsDataSet();
                    return result;

                    //System.Windows.MessageBox.Show(result.Tables[0].Rows[1][0].ToString());
                    // The result of each spreadsheet is in result.Tables
                }
            }

        }
        public static double? getDoubleFromExcel(object value)
        {
            if (value == DBNull.Value) return 0;
            return Convert.ToDouble(value);
        }
        public static int? getIntFromExcel(object value)
        {
            if (value == DBNull.Value) return 0;
            return Convert.ToInt32(value);
        }


        #region properties
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
        private DateTime deliverydate;
        public DateTime DeliveryDate
        {
            get
            {
                return deliverydate;
            }
            set
            {
                deliverydate = value;
                OnPropertyChanged("deliverydate");
            }
        }
        private DateTime deliveryhour;
        public DateTime DeliveryHour
        {
            get
            {
                return deliveryhour;
            }
            set
            {
                deliveryhour = value;
                OnPropertyChanged("deliveryhour");
            }
        }
        private string ordernumber;
        public string OrderNumber
        {
            get
            {
                return ordernumber;
            }
            set
            {
                ordernumber = value;
                OnPropertyChanged("ordernumber");
            }
        }
        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged("location");
            }
        }
        private string product;
        public string Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged("product");
            }
        }
        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("status");
            }
        }
        private string variant;
        public string Variant
        {
            get
            {
                return variant;
            }
            set
            {
                variant = value;
                OnPropertyChanged("variant");
            }
        }
        private string geprint;
        public string Geprint
        {
            get
            {
                return geprint;
            }
            set
            {
                geprint = value;
                OnPropertyChanged("geprint");
            }
        }
        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("price");
            }
        }
        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("amount");
            }
        }
        private double total;
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged("total");
            }
        }
        private int discount;
        public int Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                OnPropertyChanged("discount");
            }
        }
        private int coupondiscount;
        public int CouponDiscount
        {
            get
            {
                return coupondiscount;
            }
            set
            {
                coupondiscount = value;
                OnPropertyChanged("coupondiscount");
            }
        }
        private double totalpayed;
        public double TotalPayed
        {
            get
            {
                return totalpayed;
            }
            set
            {
                totalpayed = Price * amount - Discount;
                OnPropertyChanged("totalpayed");
            }
        }
        private string paymentmethod;
        public string PaymentMethod
        {
            get
            {
                return paymentmethod;
            }
            set
            {
                paymentmethod = value;
                OnPropertyChanged("paymentmethod");
            }
        }
        private string transactiontype;
        public string TransactionType
        {
            get
            {
                return transactiontype;
            }
            set
            {
                transactiontype = value;
                OnPropertyChanged("transactiontype");
            }
        }
        private double costsupplier;
        public double CostSupplier
        {
            get
            {
                return costsupplier;
            }
            set
            {
                costsupplier = value;
                OnPropertyChanged("costsupplier");
            }
        }
        private double costmdf;
        public double CostMDF
        {
            get
            {
                return costmdf;
            }
            set
            {
                costmdf = value;
                OnPropertyChanged("costmdf");
            }
        }
        private double profitmdf;
        public double ProfitMDF
        {
            get
            {
                return profitmdf;
            }
            set
            {
                profitmdf = value;
                OnPropertyChanged("profitmdf");
            }
        }
        private double commisionsupplier;
        public double CommisionSupplier
        {
            get
            {
                return commisionsupplier;
            }
            set
            {
                commisionsupplier = value;
                OnPropertyChanged("commisionsupplier");
            }
        }

        #endregion
    }
}
