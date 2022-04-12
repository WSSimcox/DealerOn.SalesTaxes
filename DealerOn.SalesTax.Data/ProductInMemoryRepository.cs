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
        /// This function is responsible for updating a product in our memory
        /// cache of products
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            // Establishing lock for thread safety
            lock (_lock)
            {
                if (productCache.ContainsKey(product.Id))
                {
                    productCache[product.Id] = product;
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

        /// <summary>
        /// This function is responsible for filling the cache with some basic
        /// starter items.
        /// </summary>
        public void DefaultProductFiller()
        {
            // Default starter products
            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "DealerOn Book",
                Description = "An awesome book!",
                Price = 12.49M,
                IsImported = false,
                Type = ProductType.Book
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "DealerOn Music CD",
                Description = "An awesome CD!",
                Price = 14.99M,
                IsImported = false,
                Type = ProductType.Other
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "DealerOn Chocolate Bar",
                Description = "A chocolate bar with the taste of a new car's smell.",
                Price = 0.85M,
                IsImported = false,
                Type = ProductType.Food
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Imported DealerOn Box of Chocolates",
                Description = "Gourmet chocolate bar features creamy, smooth milk chocolate for a classic, sweet indulgence.",
                Price = 10.00M,
                IsImported = true,
                Type = ProductType.Food
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Imported Bottle of DealerOn Perfume",
                Description = "A handcrafted perfume with the scent of new car smell.",
                Price = 47.50M,
                IsImported = true,
                Type = ProductType.Other
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "DealerOn's Packet of headache pills",
                Description = "PAIN RELIEVER AND FEVER REDUCER: Proven pain relief without" +
                " a prescription for tough pain such as muscular aches, minor arthritis pain," +
                " toothache, backache, menstrual cramps or minor aches and pains from the common" +
                " cold; also temporarily reduces fever.",
                Price = 9.75M,
                IsImported = false,
                Type = ProductType.Medical
            });
        }
    }
}
