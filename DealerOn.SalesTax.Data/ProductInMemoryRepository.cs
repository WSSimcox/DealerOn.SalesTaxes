using DealerOn.SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Data
{
    public class ProductInMemoryRepository : IProductRepository
    {
        // Cache that's responsible for storing all products created at runtime in memory
        private static Dictionary<Guid, Product> productCache = new Dictionary<Guid, Product>();
        private readonly object _lock = new object();

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductInMemoryRepository() {}

        /// <summary>
        /// This function is responsible for adding a product to our memory
        /// cache of products
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            // Establishing lock for thread safety
            lock (_lock)
            {
                if (!productCache.ContainsKey(product.Id))
                {
                    productCache.Add(product.Id, product);
                }
            }
        }

        /// <summary>
        /// This function is repsonsible for removing a product from our memory
        /// cache of products
        /// </summary>
        /// <param name="id"></param>
        public void RemoveProduct(Guid id)
        {
            // Establishing lock for thread safety
            lock (_lock)
            {
                if (productCache.ContainsKey(id))
                {
                    productCache.Remove(id);
                }
            }
        }

        /// <summary>
        /// This function is responsbile for retrieving a product with a given
        /// specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Product with corresponding id if found </returns>
        public Product GetProductById(Guid id)
        {
            return productCache[id];
        }

        /// <summary>
        /// This function is responsbile for returning a list of all products
        /// that are stored in the memory cache of products
        /// </summary>
        /// <returns> List of all products in memory cache of products </returns>
        public IList<Product> GetProducts()
        {
            return productCache.Values.ToList();
        }
    }
}
