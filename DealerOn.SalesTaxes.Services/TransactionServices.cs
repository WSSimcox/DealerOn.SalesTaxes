using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models.Transactions;
using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Exceptions;

namespace DealerOn.SalesTaxes.Services
{
    public class TransactionServices : ITransactionServices
    {
        private SalesTransaction _salesTransaction;
        private readonly ITaxCalculatorServices[] _calculators;
        private readonly IProductRepository _productRepository;
        private readonly object _lock = new object();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="calculators"></param>
        public TransactionServices(IProductRepository productRepository, ITaxCalculatorServices[] calculators)
        {
            _productRepository = productRepository;
            _calculators = calculators;

            // using custom static initializer
            _salesTransaction = SalesTransaction.CreateSalesTransaction();
        }

        /// <summary>
        /// This function is responsible for adding a LineItem to a transaction
        /// </summary>
        /// <param name="product"></param>
        public void AddLineItem(Product product)
        {
            AddLineItem(product.Id, 1);
        }

        /// <summary>
        /// This overloaded function is responsible for adding a LineItem
        /// to a transaction
        /// </summary>
        /// <param name="product"></param>
        public void AddLineItem(Guid productId, int quanitity = 1)
        {
            var item = _salesTransaction.LineItems?.SingleOrDefault(p => p.Product.Id == productId);

            var product = _productRepository.GetProductById(productId);

            if (product == null)
                throw new NotFoundException($"Product not found for id: {productId}");

            // if Product is already inside receipt, then increment value
            if (item == null)
                _salesTransaction.LineItems?.Add(new LineItem(product, quanitity));
            else
                item.Quantity += quanitity;
        }

        /// <summary>
        /// This function is responsible for removing a LineItem from
        /// a transaction
        /// </summary>
        /// <param name="product"></param>
        public void RemoveLineItem(Product product)
        {
            RemoveLineItem(product.Id);
        }

        /// <summary>
        /// This overloaded function is responsible for removing a LineItem
        /// from a transaction
        /// </summary>
        /// <param name="productId"></param>
        public void RemoveLineItem(Guid productId)
        {
            var item = _salesTransaction.LineItems?.SingleOrDefault(p => p.Product.Id == productId);

            // if Product exists then remove 
            if (item != null)
                _salesTransaction.LineItems?.Remove(item);
        }

        /// <summary>
        /// This overloaded function is responsible for adjusting a LineItem's
        /// product's quantity a transaction
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quanitity"></param>
        public void AdjustLineItemQuanitity(Guid productId, int quanitity)
        {
            var item = _salesTransaction.LineItems?.SingleOrDefault(p => p.Product.Id == productId);

            // Checking if not null
            if (item != null)
            {
                // if item's quanitity > input then subtract, else remove item
                if (item.Quantity > quanitity)
                    item.Quantity -= quanitity;
                else
                    RemoveLineItem(item.Product.Id);
            }
        }

        /// <summary>
        /// This function is responsbile for 
        /// </summary>
        /// <returns></returns>
        public int GetAllProductCount()
        {
            int count = 0;

            foreach (var item in _salesTransaction.LineItems)
                count += item.Quantity;

            return count;
        }

        /// <summary>
        /// This function is responsible for generating a Receipt object
        /// </summary>
        /// <returns> Receiept </returns>
        public Receipt GenerateReceipt(IList<ILineItem>? lineItems = null)
        {
            var receipt = CreateTransactionReceipt();

            if (lineItems != null)
            {
                // Creating new SalesTransaction and adding provided lineItems
                _salesTransaction = SalesTransaction.CreateSalesTransaction();
                _salesTransaction.LineItems = lineItems.Select(p => new LineItem()
                    {ProductId = p.ProductId, Quantity = p.Quantity }).ToList();
            }

            // return empty Receipt
            if (_salesTransaction.LineItems == null)
                return receipt;

            // Initializing Reciept's TotalTax
            receipt.TotalTax = 0;

            // Iterating through each LineItem in the transaction
            foreach (var item in _salesTransaction.LineItems)
            {
                // Saftey to check if provided product is correct product in cache
                item.Product = _productRepository.GetProductById(item.ProductId);

                var calcVals = new List<CalculatedValue>();

                // Setting TotalCost to Product's price
                receipt.TotalCost += item.Product.Price * item.Quantity;

                // Making TotalCostPerItem the Products price
                item.TotalCostPerItem = item.Product.Price;

                // Calculating both sales and import tax
                foreach (var calculator in _calculators)
                {
                    var calcVal = calculator.Calculate(item.Product, item.Quantity);
                    // Adding the tax
                    receipt.TotalTax += calcVal.TotalTax;
                    receipt.TotalCost += calcVal.TotalTax;
                    // Updating TotalCostPerItem which includes tax
                    item.TotalCostPerItem += (calcVal.TotalTax / item.Quantity);
                    // Adding current calcVals to our list
                    calcVals.Add(calcVal);
                }

                item.ComputedValue = calcVals;
                receipt.LineItems?.Add(item);
            }

            return receipt;
        }

        /// <summary>
        /// Initializes a Receipt object based on current transaction
        /// </summary>
        /// <returns> New receipt </returns>
        private Receipt CreateTransactionReceipt()
        {
            var receipt = new Receipt();
            receipt.Id = _salesTransaction.Id;
            receipt.TransactionDate = _salesTransaction.TransactionDate;
            receipt.LineItems = new List<LineItem>();
            return receipt;
        }
    }
}