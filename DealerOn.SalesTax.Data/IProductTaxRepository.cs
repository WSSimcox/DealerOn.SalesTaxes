using DealerOn.SalesTaxes.Models;

namespace DealerOn.SalesTaxes.Data
{
    public interface IProductTaxRepository
    {
        /// <summary>
        /// This function is responsible for mapping TaxRates and productTypes
        /// </summary>
        /// <returns> List of Tuples </returns>
        IList<Tuple<ProductType, decimal>> GetTaxRates();
    }
}