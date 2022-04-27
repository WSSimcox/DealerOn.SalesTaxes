using Microsoft.VisualStudio.TestTools.UnitTesting;
using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using System;

namespace DealerOn.SalesTaxes.Data.Tests
{
    [TestClass]
    public class ProductRepositoryTests
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
        /// Note: also tests GetProducts()
        /// </summary>
        [TestMethod]
        public void AddProductTest()
        {
            // Getting product to update
            var product = _productRepo.GetProducts()[0];

            // Adding products that we created
            _productRepo.AddProduct(product);

            // Copying list over for confirmation
            var returnList = _productRepo.GetProducts();

            // Checking if products were added
            Assert.IsNotNull(returnList);
            Assert.IsTrue(returnList.Contains(product));

            // Removing product
            _productRepo.RemoveProduct(product.Id);
        }

        /// <summary>
        /// Test method for RemoveProduct()
        /// </summary>
        [TestMethod]
        public void RemoveProductTest()
        {
            // Copying list over for confirmation
            var returnedList = _productRepo.GetProducts();

            // Getting product to remove
            var product = returnedList[0];

            // Checking if productOne was added
            Assert.IsNotNull(returnedList);
            Assert.IsTrue(returnedList.Contains(product));

            // Removing product
            _productRepo.RemoveProduct(product.Id);

            // Updating returnList
            returnedList = _productRepo.GetProducts();

            // Checking if productOne was removed 
            Assert.IsFalse(returnedList.Contains(product));

            // Adding product back
            _productRepo.AddProduct(product);
        }

        /// <summary>
        /// Test method for UpdateProduct()
        /// </summary>
        [TestMethod]
        public void UpdateProductTest()
        {
            // Getting product to update
            var product = _productRepo.GetProducts()[0];

            // Creating copy to update product back
            var productCopy = product;

            product.Name = "UpdatedTestProduct";
            product.Type = ProductType.Food;
            product.Description = "Updated Test Product for UpdateProductTest()";
            product.Price = 69.00M;
            product.IsImported = true;

            // Updating product
            _productRepo.UpdateProduct(product);

            var returnedProduct = _productRepo.GetProductById(product.Id);

            Assert.IsNotNull(returnedProduct);
            Assert.IsTrue(returnedProduct.Name == "UpdatedTestProduct");
            Assert.IsTrue(returnedProduct.Type == ProductType.Food);
            Assert.IsTrue(returnedProduct.Description == "Updated Test Product for UpdateProductTest()");
            Assert.IsTrue(returnedProduct.Price == 69.00M);
            Assert.IsTrue(returnedProduct.IsImported);

            // Reverting back to original product
            _productRepo.UpdateProduct(productCopy);
        }

        /// <summary>
        /// Test method for GetProductsById()
        /// </summary>
        [TestMethod]
        public void GetProductByIdTest()
        {
            // Copying list over for confirmation
            var returnedList = _productRepo.GetProducts();

            // Getting product to retrieve
            var product = returnedList[0];

            // Trying to copy product from repo
            var returnedProduct = _productRepo.GetProductById(product.Id);

            // Checking if all variables in returnedProduct match productOne's variables
            Assert.IsNotNull(returnedProduct);
            Assert.IsTrue(returnedProduct.Id == product.Id);
            Assert.IsTrue(returnedProduct.Type == product.Type);
            Assert.IsTrue(returnedProduct.Price == product.Price);
            Assert.IsTrue(returnedProduct.IsImported == product.IsImported); 
        }
    }
}