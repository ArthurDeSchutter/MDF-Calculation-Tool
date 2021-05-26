using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;

namespace MDF_Calculation_Tool.ViewModel
{
    //https://www.c-sharpcorner.com/UploadFile/raj1979/simple-mvvm-pattern-in-wpf/
    class PaymentMethodViewModel
    {
        private IList<PaymentMethod> _paymentMethods;

        public PaymentMethodViewModel()
        {
            _paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod("bancontact",0.5,1),
                new PaymentMethod("ideal",0.29,0),
            };
        }
        public IList<PaymentMethod> PaymentMethods
        {
            get { return _paymentMethods; }
            set { _paymentMethods = value; }
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
