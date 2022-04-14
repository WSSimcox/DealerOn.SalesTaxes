using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public class ImportTaxCalculatorServices : ITaxCalculatorServices
    {
        // Import tax rate represented as a decimal
        private readonly decimal _importTaxRate = 0.05M;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImportTaxCalculatorServices() { }

        /// <summary>
        /// This function is responsible for calculating import tax of products
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quanitity"></param>
        /// <returns> Calculated Value object </returns>
        public CalculatedValue Calculate(Product product, int quanitity)
        {
            var calcVal = new CalculatedValue();

            var taxRate = _importTaxRate;

            if (!product.IsImported)
                taxRate = 0M;

            // return total amount rounded to nearest 5 cents
            calcVal.CostPerItemTaxed = product.Price + Math.Ceiling((product.Price * taxRate) * 20M) / 20M;
            calcVal.TotalCost = calcVal.CostPerItemTaxed * quanitity;
            calcVal.TotalTax = (calcVal.CostPerItemTaxed - product.Price) * quanitity;
            calcVal.Name = Name;
            
            return calcVal;
        }

        /// <summary>
        /// Function responsible for assigning name of this calculator
        /// </summary>
        public string Name => "Import Tax";

    }
}