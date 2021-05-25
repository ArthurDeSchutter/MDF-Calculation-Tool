using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MDF_Calculation_Tool
{
    class PaymentMethod : INotifyPropertyChanged
    {
        public PaymentMethod(string name, int fixedRate, int variableRate)
        {
            Name = name;
            FixedRate = fixedRate;
            VariableRate = variableRate;
        }

        private string name;
        private int fixedrate;
        private int variablerate;

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
        public int FixedRate
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
        public int VariableRate
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
