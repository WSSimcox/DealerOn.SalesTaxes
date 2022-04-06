using DealerOn.SalesTaxes.Models;

namespace DealerOn.SalesTaxes.Services
{
    public interface IProductServices
    {
        /// <summary>
        /// This function is responsbile for adding a Product to our memory cache
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(Product product);

        /// <summary>
        /// This function is responsible for removing a Product from our memory cache
        /// </summary>
        /// <param name="product"></param>
        void RemoveProduct(Product product);

        /// <summary>
        /// This function is responsbile for retrieving a Product from our memory cache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(Guid id);

        /// <summary>
        /// This function is responsible for retrieving all Products from
        /// our memory cache
        /// </summary>
        /// <returns> List of Products </returns>
        public IList<Product> GetProducts();
    }
}