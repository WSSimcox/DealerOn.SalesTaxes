using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models.Transactions;
using DealerOn.SalesTaxes.Models;


namespace DealerOn.SalesTaxes.Services
{
    public class TransactionServices : ITransactionServices
    {
        private SalesTransaction _salesTransaction;
        private readonly ITaxCalculator[] _calculators;
        private readonly IProductRepository _productRepository;
        private readonly object _lock = new object();

        public TransactionServices(IProductRepository productRepository, ITaxCalculator[] calculators)
        {
            _productRepository = productRepository;
            _calculators = calculators;

            // using custom static initializer
            _salesTransaction = SalesTransaction.CreateSalesTransaction();
        }

        public void AddProduct(Product product)
        {
            var item = _salesTransaction.LineItems?.Single(p => p.Product.Id == product.Id);

            // if Product is already inside receipt, then increment value
            if (item == null)
                _salesTransaction.LineItems?.Add(new LineItem(product, 1));
            else
                item.Quantity++;
        }

        public void RemoveProduct(Product product)
        {
            var item = _salesTransaction.LineItems?.Single(p => p.Product.Id == product.Id);

            if (item == null)
                return;

            // if Product is already inside receipt, then increment value
            if (item.Quantity <= 1)
                _salesTransaction.LineItems?.Remove(item);
            else
                item.Quantity--;
        }

        public Receipt GenerateReceipt()
        {
            var receipt = new Receipt();

            foreach (var item in _salesTransaction.LineItems)
            {
                foreach (var calculator in _calculators)
                {
                    var calcVal = calculator.Calculate(item.Product, item.Quantity);
                    receipt.TotalTax += calcVal.TotalTax;
                    receipt.TotalCost += calcVal.TotalCost;
                }
            }

            return receipt;
        }
    }
}