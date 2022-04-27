using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Services.Tests
{
    [TestClass]
    public class ProductServicesTests
    {
        ProductInMemoryRepository? _productRepo;

        /// <summary>
        /// Initializing Test Class and filling Product Cache
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _productRepo = new ProductInMemoryRepository();
            _productRepo.DefaultProductFiller();
        }

        /// <summary>
        /// Test method for AddProduct()
        /// </summary>
        [TestMethod]
        public void AddProductTest()
        {
            var service = new ProductServices(new ProductInMemoryRepository());

            Product product = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for AddProductTest()",
                Price = 10.50M,
                IsImported = false
            };

            // Checking if product isn't already added
            Assert.IsNull(service.GetProductById(product.Id));

            // Adding Product via service
            service.AddProduct(product);

            // Checking if product is found by service
            var returnedProduct = service.GetProductById(product.Id);

            // Checking if all variables in returnedProduct match product's variables
            Assert.IsNotNull(returnedProduct);
            Assert.IsTrue(returnedProduct.Id == product.Id);
            Assert.IsTrue(returnedProduct.Type == product.Type);
            Assert.IsTrue(returnedProduct.Description == product.Description);
            Assert.IsTrue(returnedProduct.Price == product.Price);
            Assert.IsTrue(returnedProduct.IsImported == product.IsImported);

            // Removing product
            service.RemoveProduct(product.Id);
        }


        /// <summary>
        /// Test method for RemoveProduct()
        /// </summary>
        [TestMethod]
        public void RemoveProductTest()
        {
            var service = new ProductServices(new ProductInMemoryRepository());


            // Copying list over for confirmation
            var returnedList = _productRepo.GetProducts();

            // Getting product to remove
            var product = returnedList[0];

            // Adding Product via service
            service.AddProduct(product);

            // Checking if product is found by service
            var returnedProduct = service.GetProductById(product.Id);

            // Checking if returnedProduct isn't null
            Assert.IsNotNull(returnedProduct);

            // Removing Product via service
            service.RemoveProduct(returnedProduct.Id);

            // Updating returnedProduct
            returnedProduct = service.GetProductById(product.Id);

            // Checking if returnedProduct is null
            Assert.IsNull(returnedProduct);
        }

        /// <summary>
        /// Test method for UpdateProduct()
        /// </summary>
        [TestMethod]
        public void UpdateProductTest()
        {
            var service = new ProductServices(new ProductInMemoryRepository());

            // Getting product to update
            var product = _productRepo.GetProducts()[0];

            // Creating copy to update product back
            var productCopy = product;

            // Adding product that we created
            service.AddProduct(product);

            product.Name = "UpdatedTestProduct";
            product.Type = ProductType.Food;
            product.Description = "Updated Test Product for UpdateProductTest()";
            product.Price = 11.00M;
            product.IsImported = true;

            // Updating product
            service.UpdateProduct(product);

            var returnedProduct = service.GetProductById(product.Id);

            Assert.IsNotNull(returnedProduct);
            Assert.IsTrue(returnedProduct.Name == "UpdatedTestProduct");
            Assert.IsTrue(returnedProduct.Type == ProductType.Food);
            Assert.IsTrue(returnedProduct.Description == "Updated Test Product for UpdateProductTest()");
            Assert.IsTrue(returnedProduct.Price == 11.00M);
            Assert.IsTrue(returnedProduct.IsImported);

            // Reverting back to original product
            service.UpdateProduct(productCopy);
        }

        /// <summary>
        /// Test method for GetProductsById()
        /// </summary>
        [TestMethod]
        public void GetProductByIdTest()
        {
            var service = new ProductServices(new ProductInMemoryRepository());

            Product product = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for GetProductByIdTest()",
                Price = 10.50M,
                IsImported = false
            };

            // Adding Product via service
            service.AddProduct(product);

            // Checking if product is found by service
            var returnedProduct = service.GetProductById(product.Id);

            // Removing product
            service.RemoveProduct(product.Id);
        }

        /// <summary>
        /// Test method for GetProducts()
        /// </summary>
        [TestMethod]
        public void GetProductsTest()
        {
            var service = new ProductServices(new ProductInMemoryRepository());

            // Creating two products for testing
            Product productOne = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for AddProduct()",
                Price = 10.50M,
                IsImported = false
            };

            Product productTwo = new Product()
            {
                Id = Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385"),
                Name = "TestProductTwo",
                Type = ProductType.Other,
                Description = "Test Product from ProductRepositoryFiller()",
                Price = 5.00M,
                IsImported = true
            };

            // Adding products to service
            service.AddProduct(productOne);
            service.AddProduct(productTwo);

            // Getting all products via service
            var returnedProductList = service.GetProducts();

            // Checking if products are all present inside the returned list
            Assert.IsNotNull(returnedProductList);
            Assert.IsTrue(returnedProductList.Contains(productOne));
            Assert.IsTrue(returnedProductList.Contains(productTwo));

            // Removing products
            service.RemoveProduct(productOne.Id);
            service.RemoveProduct(productTwo.Id);
        }
    }
}
