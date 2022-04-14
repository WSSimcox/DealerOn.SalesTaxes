using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public interface ITransactionServices
    {
        /// <summary>
        /// This function is responsbile adding a LineItem and its quanitity to
        /// a Transaction
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quanitity"></param>
        void AddLineItem(Guid productId, int quanitity = 1);

        /// <summary>
        /// This function is responsible for adding a product to a SalesTransaction
        /// </summary>
        /// <param name="product"></param>
        void AddLineItem(Product product);

        /// <summary>
        /// This function is responsbile for updating LineItem's quanitity or
        /// removes entire LineItem if quantity is greater than LineItem's quantity
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quanitity"></param>
        void AdjustLineItemQuanitity(Guid productId, int quanitity);

        /// <summary>
        /// This function is responsible for generating a receipt
        /// </summary>
        /// <returns> The receipt that was generated </returns>
        Receipt GenerateReceipt(IList<ILineItem>? lineItems = null);

        /// <summary>
        /// This function is responsbile for returning the sum of all
        /// LineItems and their quanitities
        /// </summary>
        /// <returns> Count </returns>
        int GetAllProductCount();

        /// <summary>
        /// This function is responsbile for removing a LineItem from a Transaction
        /// </summary>
        /// <param name="productId"></param>
        void RemoveLineItem(Guid productId);

        /// <summary>
        /// This function is responsbile for removing a product from a SalesTransaction
        /// </summary>
        /// <param name="product"></param>
        void RemoveLineItem(Product product);
    }
}