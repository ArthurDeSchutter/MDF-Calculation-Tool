using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MDF_Calculation_Tool.Model
{
    class Supplier : INotifyPropertyChanged
    {
        #region properties
        private string name;
        private DateTime startdate;
        private string suppliernumber;
        private string bank_account_number;
        private double variablecommision;
        private double fixedcommision;

        public Supplier(string name, DateTime startdate, string suppliernumber, string bank_account_number, double variablecommision, double fixedcommision)
        {
            Name = name;
            this.startdate = startdate;
            this.suppliernumber = suppliernumber;
            this.bank_account_number = bank_account_number;
            this.variablecommision = variablecommision;
            this.fixedcommision = fixedcommision;
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
        public DateTime StartDate
        {
            get
            {
                return startdate;
            }
            set
            {
                startdate = value;
                OnPropertyChanged("startdate");
            }
        }
        public string SupplierNumber
        {
            get
            {
                return suppliernumber;
            }
            set
            {
                suppliernumber = value;
                OnPropertyChanged("suppliernumber");
            }
        }
        public string Bank_Account_Number
        {
            get
            {
                return bank_account_number;
            }
            set
            {
                bank_account_number = value;
                OnPropertyChanged("bank_account_number");
            }
        }
        public double VariableCommision
        {
            get
            {
                return variablecommision;
            }
            set
            {
                variablecommision = value;
                OnPropertyChanged("variablecommision");
            }
        }
        public double FixedCommission
        {
            get
            {
                return fixedcommision;
            }
            set
            {
                fixedcommision = value;
                OnPropertyChanged("variablecommision");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}