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
                new Order("test",new DateTime(),new DateTime(),"test","test","test","test","test","test","test","test","test","test",1,1,1,1,1,1,"test","test",1,"test",1,1,1,1),
                new Order("2",new DateTime(),new DateTime(),"test","test","test","test","test","test","test","test","test","test",1,1,1,1,1,1,"test","test",1,"test",1,1,1,1),
                new Order("2",new DateTime(),new DateTime(),"test","test","test","test","test","test","test","test","test","test",1,1,1,1,1,1,"test","test",1,"test",1,1,1,1),
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
                OrderList.Add(new Order(
                    result.Tables[0].Rows[i][0].ToString(),
                    Convert.ToDateTime(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToDateTime(result.Tables[0].Rows[i][1].ToString()),
                    result.Tables[0].Rows[i][3].ToString(),
                    result.Tables[0].Rows[i][4].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    result.Tables[0].Rows[i][5].ToString(),
                    result.Tables[0].Rows[i][5].ToString(),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    result.Tables[0].Rows[i][1].ToString(),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString()),
                    Convert.ToInt32(result.Tables[0].Rows[i][1].ToString())

                    ));

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
