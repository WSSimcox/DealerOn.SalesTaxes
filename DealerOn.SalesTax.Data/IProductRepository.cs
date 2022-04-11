using System;
using DealerOn.SalesTaxes.Models;

namespace DealerOn.SalesTaxes.Data
{
    public interface IProductRepository
    {
        /// <summary>
        /// This function is responsible for adding a product to our memory
        /// cache of products
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(Product product);

        /// <summary>
        /// This function is repsonsible for removing a product from our memory
        /// cache of products
        /// </summary>
        /// <param name="id"></param>
        void RemoveProduct(Guid id);

        /// <summary>
        /// This function is responsible for updating a product in our memory
        /// cache of products
        /// </summary>
        /// <param name="product"></param>
        void UpdateProduct(Product product);

        /// <summary>
        /// This function is responsbile for retrieving a product with a given
        /// specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Product with corresponding id if found </returns>
        Product GetProductById(Guid id);

        /// <summary>
        /// This function is responsbile for returning a list of all products
        /// that are stored in the memory cache of products
        /// </summary>
        /// <returns> List of all products in memory cache of products </returns>
        IList<Product> GetProducts();
    }
}