using MDF_Calculation_Tool.ViewModel;
using MDF_Calculation_Tool.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MDF_Calculation_Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            MainWindowViewModel VM = new MainWindowViewModel();
            window.DataContext = VM;
            window.Show();

            window.DataContext = VM;
            window.Show();
        }
    }
}
