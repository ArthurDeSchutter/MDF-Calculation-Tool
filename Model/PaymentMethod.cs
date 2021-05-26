using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MDF_Calculation_Tool
{
    class PaymentMethod : INotifyPropertyChanged
    {
        public PaymentMethod(string name, double fixedRate, double variableRate)
        {
            Name = name;
            FixedRate = fixedRate;
            VariableRate = variableRate;
        }

        private string name;
        private double fixedrate;
        private double variablerate;

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
