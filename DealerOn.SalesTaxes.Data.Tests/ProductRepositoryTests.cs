using Microsoft.VisualStudio.TestTools.UnitTesting;
using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using System;

namespace DealerOn.SalesTaxes.Data.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        /// <summary>
        /// Test method for AddProduct()
        /// Note: also tests GetProducts()
        /// </summary>
        [TestMethod]
        public void AddProductTest()
        {
            var repo = new ProductInMemoryRepository();

            // Creating two test products
            Product productOne = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for AddProductTest()",
                Price = 10.50M,
                IsImported = false
            };

            Product productTwo = new Product()
            {
                Id = Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385"),
                Name = "TestProductOne",
                Type = ProductType.Other,
                Price = 5.00M,
                IsImported = true
            };

            // Adding products that we created
            repo.AddProduct(productOne);
            repo.AddProduct(productTwo);

            // Copying list over for confirmation
            var returnList = repo.GetProducts();

            // Checking if products were added
            Assert.IsNotNull(returnList);
            Assert.IsTrue(returnList.Count == 2);
        }

        /// <summary>
        /// Test method for RemoveProduct()
        /// </summary>
        [TestMethod]
        public void RemoveProductTest()
        {
            var repo = new ProductInMemoryRepository();

            // Creating a test product
            Product product = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for RemoveProductTest()",
                Price = 10.50M,
                IsImported = false
            };

            // Adding product that we created
            repo.AddProduct(product);

            // Copying list over for confirmation
            var returnedList = repo.GetProducts();

            // Checking if productOne was added
            Assert.IsNotNull(returnedList);
            Assert.IsTrue(returnedList.Contains(product));

            // Removing product
            repo.RemoveProduct(product.Id);

            // Updating returnList
            returnedList = repo.GetProducts();

            // Checking if productOne was removed 
            Assert.IsFalse(returnedList.Contains(product));
        }

        /// <summary>
        /// Test method for UpdateProduct()
        /// </summary>
        [TestMethod]
        public void UpdateProductTest()
        {
            var repo = new ProductInMemoryRepository();

            // Creating a test product
            Product product = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for UpdateProductTest()",
                Price = 10.50M,
                IsImported = false
            };

            // Adding product that we created
            repo.AddProduct(product);

            product.Name = "UpdatedTestProduct";
            product.Type = ProductType.Food;
            product.Description = "Updated Test Product for UpdateProductTest()";
            product.Price = 11.00M;
            product.IsImported = true;

            // Updating product
            repo.UpdateProduct(product);

            var returnedProduct = repo.GetProductById(product.Id);

            Assert.IsNotNull(returnedProduct);
            Assert.IsTrue(returnedProduct.Name == "UpdatedTestProduct");
            Assert.IsTrue(returnedProduct.Type == ProductType.Food);
            Assert.IsTrue(returnedProduct.Description == "Updated Test Product for UpdateProductTest()");
            Assert.IsTrue(returnedProduct.Price == 11.00M);
            Assert.IsTrue(returnedProduct.IsImported);
        }

        /// <summary>
        /// Test method for GetProductsById()
        /// </summary>
        [TestMethod]
        public void GetProductByIdTest()
        {
            var repo = new ProductInMemoryRepository();

            // Creating a test product
            Product product = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Price = 10.50M,
                IsImported = false
            };

            // Adding product that we created
            repo.AddProduct(product);

            // Trying to copy product from repo
            var returnedProduct = repo.GetProductById(product.Id);

            // Checking if all variables in returnedProduct match productOne's variables
            Assert.IsNotNull(returnedProduct);
            Assert.IsTrue(returnedProduct.Id == product.Id);
            Assert.IsTrue(returnedProduct.Type == product.Type);
            Assert.IsTrue(returnedProduct.Price == product.Price);
            Assert.IsTrue(returnedProduct.IsImported == product.IsImported); 
        }
    }
}