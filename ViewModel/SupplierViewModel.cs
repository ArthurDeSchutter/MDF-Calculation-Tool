using MDF_Calculation_Tool.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MDF_Calculation_Tool.ViewModel
{
    class SupplierViewModel
    {
        private IList<Supplier> _suppliers;

        public SupplierViewModel()
        {
            _suppliers = new List<Supplier>
            {
                new Supplier("Leverancier A", new DateTime(1/01/2020),"0123497","BE12 7512 0464 0001",0.05,0),
                new Supplier("Leverancier B", new DateTime(10/01/2020),"0123456","BE12 7512 0464 0002",0.03,1),
            };
        }
        public IList<Supplier> Suppliers
        {
            get { return _suppliers; }
            set { _suppliers = value; }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion

        }
    }
}
