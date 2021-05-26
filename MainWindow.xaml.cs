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
    }
}
