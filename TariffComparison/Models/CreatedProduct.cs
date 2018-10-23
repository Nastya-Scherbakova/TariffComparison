using System;
using System.Collections.Generic;
using System.Text;

namespace TariffComparison.Models
{
    public class CreatedProduct
    {
        public readonly string TariffName;
        public decimal AnnualCosts {get; set;}
        public CreatedProduct(string name)
        {
            TariffName = name;
        }
    }
}
