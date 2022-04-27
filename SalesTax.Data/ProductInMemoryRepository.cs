using SalesTaxes.Models;
using SalesTaxes.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Data
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
                    // if imported then add to name
                    if (product.IsImported)
                        product.Name = "Imported " + product.Name;

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
            try
            {
                return productCache[id];
            }
            catch 
            {
                throw new NotFoundException($"Product {id} not found.");
            }
            
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
            if (productCache.Count > 0)
                return;

            // Default starter products
            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Book",
                Description = "An awesome book!",
                Price = 12.49M,
                IsImported = false,
                Type = ProductType.Book
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Music CD",
                Description = "An awesome CD!",
                Price = 14.99M,
                IsImported = false,
                Type = ProductType.Other
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Chocolate Bar",
                Description = "An artisan chocolate bar.",
                Price = 0.85M,
                IsImported = false,
                Type = ProductType.Food
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Box of Chocolates",
                Description = "Gourmet chocolates that feature creamy, smooth milk chocolate for a classic, sweet indulgence.",
                Price = 10.00M,
                IsImported = true,
                Type = ProductType.Food
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Bottle of Perfume",
                Description = "A handcrafted perfume with the scent of new car smell.",
                Price = 47.50M,
                IsImported = true,
                Type = ProductType.Other
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Bottle of Perfume V2",
                Description = "NEW AND IMPROVED! A perfume with the scent of new car smell.",
                Price = 27.99M,
                IsImported = true,
                Type = ProductType.Other
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Bottle of Perfume V3",
                Description = "NEW AND IMPROVED AGAIN! A generic perfume with the scent of new car smell.",
                Price = 18.99M,
                IsImported = false,
                Type = ProductType.Other
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Packet of headache pills",
                Description = "Pain reliever and fever reducer.",
                Price = 9.75M,
                IsImported = false,
                Type = ProductType.Medical
            });

            AddProduct(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Box of Chocolates V2",
                Description = "NEW AND IMPROVED! Gourmet chocolates that feature creamy, smooth milk chocolate for a classic, sweet indulgence.",
                Price = 11.25M,
                IsImported = true,
                Type = ProductType.Food
            });
        }
    }
}
