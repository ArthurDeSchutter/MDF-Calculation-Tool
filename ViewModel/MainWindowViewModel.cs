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
                new Order("test", new DateTime(), new DateTime(), "test", "test", "test", "Active",
                                         "test", "test", 5, 0, 0, 0, 5,
                                         "test", "test","transid", "test", 5,
                                         3, 1, 454)
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

            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
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
                double Total = Convert.ToDouble(result.Tables[0].Rows[i][15]);
                int Discount = Convert.ToInt32(result.Tables[0].Rows[i][16]);
                int CouponDiscount = Convert.ToInt32(result.Tables[0].Rows[i][17]);
                string PaymentMethod = result.Tables[0].Rows[i][19].ToString();
                string TransactionType = result.Tables[0].Rows[i][20].ToString();
                string TransactionID = result.Tables[0].Rows[i][21].ToString();
                string CouponCode = result.Tables[0].Rows[i][22].ToString();
                double CostSupplier = (double)getDoubleFromExcel(result.Tables[0].Rows[i][23]);
                double CostMDF = (double)getDoubleFromExcel(result.Tables[0].Rows[i][24]);
                double ProfitMDF = (double)getDoubleFromExcel(result.Tables[0].Rows[i][25]);
                double CommisionSupplier = (double)getDoubleFromExcel(result.Tables[0].Rows[i][26]);

                _orderlist.Add(new Order(Supplier, DeliveryDate, DeliveryHour, OrderNumber, Location, Product, Status,
                                         Geprint, Variant, Price, amount, Total, Discount, CouponDiscount,
                                         PaymentMethod, TransactionType, TransactionID, CouponCode, CostSupplier,
                                         CostMDF, ProfitMDF, CommisionSupplier));



            }
            
        }
        private bool FuncToEvaluate(object context)
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

    }
}
