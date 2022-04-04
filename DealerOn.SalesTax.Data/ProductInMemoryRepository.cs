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
        private static Dictionary<Guid, Product> productCache = new Dictionary<Guid, Product>();
        private readonly object _lock = new object();

        public ProductInMemoryRepository() {}

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

        public Product GetProductById(Guid id)
        {
            return productCache[id];
        }

        public IList<Product> GetProducts()
        {
            return productCache.Values.ToList();
        }
    }
}
