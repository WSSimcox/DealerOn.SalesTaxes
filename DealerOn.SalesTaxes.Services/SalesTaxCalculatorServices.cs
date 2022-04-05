using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public class SalesTaxCalculatorServices : ITaxCalculatorServices
    {
        private readonly decimal _basicTaxRate = 0.10M;
        private readonly IProductTaxRepository _productTaxRepository;
        private readonly Dictionary<ProductType, decimal> _taxMap = new Dictionary<ProductType, decimal>();   

        public SalesTaxCalculatorServices(IProductTaxRepository productTaxRepository)
        { 
            _productTaxRepository = productTaxRepository;
            var rates = _productTaxRepository.GetTaxRates();
            foreach (var rate in rates)
                _taxMap.Add(rate.Item1, rate.Item2);
        }

        public CalculatedValue Calculate(Product product, int quanitity)
        {
            var calcVal = new CalculatedValue();

            var totalTax = (product.Price * _basicTaxRate) * quanitity;

            // return total amount rounded to nearest 5 cents
            calcVal.CostPerItem = Math.Ceiling(totalTax / quanitity * 20M) / 20M;
            calcVal.TotalTax = Math.Ceiling(totalTax * 20M) / 20M;
            calcVal.TotalCost = (calcVal.CostPerItem * quanitity) + totalTax;

            return calcVal;
        }

        public string Name => "SalesTax";
    }
}