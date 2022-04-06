using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public class SalesTaxCalculatorServices : ITaxCalculatorServices
    {
        // Sales tax rate represented as a decimal
        private readonly decimal _basicTaxRate = 0.10M;
        private readonly IProductTaxRepository _productTaxRepository;
        // Tax map of productTypes to their tax values
        private readonly Dictionary<ProductType, decimal> _taxMap = new Dictionary<ProductType, decimal>();   

        /// <summary>
        /// Constructor that is also responsible for mapping the taxMap
        /// </summary>
        /// <param name="productTaxRepository"></param>
        public SalesTaxCalculatorServices(IProductTaxRepository productTaxRepository)
        { 
            _productTaxRepository = productTaxRepository;
            var rates = _productTaxRepository.GetTaxRates();
            foreach (var rate in rates)
                _taxMap.Add(rate.Item1, rate.Item2);
        }

        /// <summary>
        /// This function is responsible for calculating sales tax of products
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quanitity"></param>
        /// <returns> Calculated Value object </returns>
        public CalculatedValue Calculate(Product product, int quanitity)
        {
            var calcVal = new CalculatedValue();

            var taxRate = _taxMap[product.Type];

            var totalTax = (product.Price * taxRate) * quanitity;

            // return total amount rounded to nearest 5 cents
            calcVal.CostPerItem = Math.Ceiling((product.Price + totalTax) / quanitity * 20M) / 20M;
            calcVal.TotalTax = Math.Ceiling(totalTax * 20M) / 20M;
            calcVal.TotalCost = calcVal.CostPerItem * quanitity;
            calcVal.Name = Name;


            return calcVal;
        }

        /// <summary>
        /// Function responsible for assigning name of this calculator
        /// </summary>
        public string Name => "Sales Tax";
    }
}