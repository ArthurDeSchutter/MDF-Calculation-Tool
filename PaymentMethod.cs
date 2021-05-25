using System;
using System.Collections.Generic;
using System.Text;

namespace MDF_Calculation_Tool
{
    class PaymentMethod
    {
        public PaymentMethod(string name, int fixedRate, string variableRate)
        {
            Name = name;
            FixedRate = fixedRate;
            VariableRate = variableRate;
        }

        public string Name { get; set; }
        public int FixedRate { get; set; }
        public string VariableRate { get; set; }
    }
}
