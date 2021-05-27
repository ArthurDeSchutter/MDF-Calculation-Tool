using MDF_Calculation_Tool.View;
using MDF_Calculation_Tool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExcelDataReader;
using System.IO;

namespace MDF_Calculation_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void open_suppliers_Click(object sender, RoutedEventArgs e)
        {
            SupplierPage supplierPage = new SupplierPage();
            SupplierViewModel SupplierVM = new SupplierViewModel();

            supplierPage.DataContext = SupplierVM;
            supplierPage.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodWindow paymentwindow = new PaymentMethodWindow();
            PaymentMethodViewModel vm = new PaymentMethodViewModel();

            paymentwindow.DataContext = vm;
            paymentwindow.Show();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    txtFilePath.Text = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }

            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void parse_exce(object sender, RoutedEventArgs e)
        {
            using (var stream = File.Open(txtFilePath.Text, FileMode.Open, FileAccess.Read))
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
                    var result = reader.AsDataSet();
                    System.Windows.MessageBox.Show(result.Tables[0].Rows[5][0].ToString());

                    // The result of each spreadsheet is in result.Tables
                }
            }

        }
    }
}
