using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace MDF_Calculation_Tool.ViewModel
{
    //https://www.c-sharpcorner.com/UploadFile/raj1979/simple-mvvm-pattern-in-wpf/
    class PaymentMethodViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PaymentMethod> _paymentMethods;

        public PaymentMethodViewModel()
        {
            _paymentMethods = new ObservableCollection<PaymentMethod>
            {
                new PaymentMethod("bancontact",0.5,1),
                new PaymentMethod("ideal",0.29,0),
            };
        }
        public ObservableCollection<PaymentMethod> PaymentMethods
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
        public ICommand AddPaymentMethod
        {
            get { return new DelegateCommand<object>(FuncToCall, FuncToEvaluate); }
        }

        private void FuncToCall(object context)
        {
            _paymentMethods.Add(new PaymentMethod(name, Convert.ToDouble(FixedRate), Convert.ToDouble(VariableRate)));
        }

        private bool FuncToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
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

        private string name;
        private double fixedrate;
        private double variablerate;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }
        public double FixedRate
        {
            get
            {
                return fixedrate;
            }
            set
            {
                fixedrate = value;
                OnPropertyChanged("fixedrate");
            }
        }
        public double VariableRate
        {
            get
            {
                return variablerate;
            }
            set
            {
                variablerate = value;
                OnPropertyChanged("variablerate");
            }
        }

    }
}
