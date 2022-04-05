using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public class ImportTaxCalculatorServices : ITaxCalculatorServices
    {
        private readonly decimal _importTaxRate = 0.5M;

        public ImportTaxCalculatorServices() { }

        public CalculatedValue Calculate(Product product, int quanitity)
        {
            var calcVal = new CalculatedValue();

            var taxRate = _importTaxRate;

            if (!product.IsImported)
                taxRate = 0M;

            var totalTax = (product.Price * taxRate) * quanitity;

            // return total amount rounded to nearest 5 cents
            calcVal.CostPerItem = Math.Ceiling(totalTax / quanitity * 20M) / 20M;
            calcVal.TotalTax = Math.Ceiling(totalTax * 20M) / 20M;
            calcVal.TotalCost = (calcVal.CostPerItem * quanitity) + totalTax;

            return calcVal;
        }

        public string Name => "ImportTax";

    }
}