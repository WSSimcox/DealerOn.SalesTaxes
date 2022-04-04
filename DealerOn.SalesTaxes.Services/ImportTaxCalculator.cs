﻿using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public class ImportTaxCalculator : ICalculator
    {
        private readonly decimal _importTaxRate = 0.5M;

        public ImportTaxCalculator() { }

        public CalculatedValue Calculate(Product product, int quanitity)
        {
            var calcVal = new CalculatedValue();

            var totalTax = (product.Price * _importTaxRate) * quanitity;

            // return total amount rounded to nearest 5 cents
            calcVal.CostPerItem = Math.Ceiling(totalTax / quanitity * 20M) / 20M;
            calcVal.TotalTax = Math.Ceiling(totalTax * 20M) / 20M;
            calcVal.TotalCost = (calcVal.CostPerItem * quanitity) + totalTax;

            return calcVal;
        }

        public string Name => "ImportTax";

    }
}