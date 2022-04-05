using DealerOn.SalesTaxes.Models;

namespace DealerOn.SalesTaxes.Services
{
    public interface IProductServices
    {
        void AddProduct(Product product);
        Product GetProductById(Guid id);
        void RemoveProduct(Product product);
    }
}