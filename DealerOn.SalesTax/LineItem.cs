using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Models
{
    /// <summary>
    /// Class that represents LineItem inside reciept
    /// </summary>
    public class LineItem
    {
        public LineItem(Product product, int quanitity = 1)
        {
            this.Product = product;
            this.Quantity = quanitity;
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CalculatedValue ComputedValue { get; set; }
    }
}
