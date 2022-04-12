using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// This function is responsbile for adding a Product to our memory cache
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                product.Id = Guid.NewGuid(); ;

                _productRepository.AddProduct(product);
            }
        }

        /// <summary>
        /// This function is responsible for removing a Product from our
        /// memory cache
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Guid id)
        {
            try
            {
                _productRepository.RemoveProduct(id);
            }
            catch { return;  }
        }

        /// <summary>
        /// This function is responsible for removing a Product from
        /// our memory cache
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            try
            {
                _productRepository.UpdateProduct(product);
            }
            catch { return; }
        }

        /// <summary>
        /// This function is responsbile for retrieving a Product from
        /// our memory cache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(Guid id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                return product;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// This function is responsible for retrieving all Products from
        /// our memory cache
        /// </summary>
        /// <returns> List of Products </returns>
        public IList<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
