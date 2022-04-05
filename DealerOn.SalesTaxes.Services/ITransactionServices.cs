using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public interface ITransactionServices
    {
        /// <summary>
        /// This function is responsible for adding a product to a SalesTransaction
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(Product product);

        /// <summary>
        /// This function is responsible for generating a receipt
        /// </summary>
        /// <returns> The receipt that was generated </returns>
        Receipt GenerateReceipt();

        /// <summary>
        /// This function is responsbile for removing a product from a SalesTransaction
        /// </summary>
        /// <param name="product"></param>
        void RemoveProduct(Product product);
    }
}