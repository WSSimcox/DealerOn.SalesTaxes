using DealerOn.SalesTaxes.Models;

namespace DealerOn.SalesTaxes.Web.ViewModel
{
    public class LineItemViewModel : ILineItem
    {
        /// <summary>
        /// Unique Identifier of the Product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quanitity of Products inside LineItem
        /// </summary>
        public int Quantity { get; set; }
    }
}
