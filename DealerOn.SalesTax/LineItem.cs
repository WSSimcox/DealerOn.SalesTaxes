using SalesTaxes.Models.Transactions;

namespace SalesTaxes.Models
{
    /// <summary>
    /// Class that represents LineItem inside reciept
    /// </summary>
    public class LineItem : ILineItem
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LineItem() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quanitity"></param>
        public LineItem(Product product, int quanitity = 1)
        {
            this.Product = product;
            this.Quantity = quanitity;
            this.ProductId = product.Id;
        }

        /// <summary>
        /// Unique Identifier of the Product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// LineItem's product
        /// </summary>
        public Product Product { get; set; }
        
        /// <summary>
        /// Quanitity of Products inside LineItem
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Total post tax cost for individual lineItem's product
        /// </summary>
        public decimal TotalCostPerItem { get; set; }

        /// <summary>
        /// List of CalulatedValues for tax purposes
        /// Currently Deprecated...
        /// </summary>
        public IList<CalculatedValue> ComputedValue { get; set; }
    }
}
