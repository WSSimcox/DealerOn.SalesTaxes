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

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (product != null)
                _productRepository.AddProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            try
            {
                _productRepository.RemoveProduct(product.Id);
            }
            catch { return;  }
        }

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

        public IList<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
