using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Models
{
    /// <summary>
    /// Class that represents LineItem inside reciept
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quanitity"></param>
        public LineItem(Product product, int quanitity = 1)
        {
            this.Product = product;
            this.Quantity = quanitity;
        }
        
        /// <summary>
        /// LineItem's product
        /// </summary>
        public Product Product { get; set; }
        
        /// <summary>
        /// Quanitity of Products inside LineItem
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// List of CalulatedValues for tax purposes
        /// Currently Deprecated...
        /// </summary>
        public IList<CalculatedValue> ComputedValue { get; set; }
    }
}
