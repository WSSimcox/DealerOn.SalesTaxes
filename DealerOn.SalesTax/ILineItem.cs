using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Models
{
    /// <summary>
    /// Contract between LineItems and LineItemViewModel
    /// </summary>
    public interface ILineItem
    {
        /// <summary>
        /// Unique Identifier of the Product
        /// </summary>
        Guid ProductId { get; set; }

        /// <summary>
        /// Quanitity of Products inside LineItem
        /// </summary>
        int Quantity { get; set; }
    }
}
