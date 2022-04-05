using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DealerOn.SalesTaxes.Services.Tests
{
    [TestClass]
    public class TransactionServicesTest
    {
        /// <summary>
        /// Test method for AddProduct()
        /// </summary>
        [TestMethod]
        public void AddProductTest()
        {
            var service = new TransactionServices(ProductRepositoryFiller(), CalculatorFiller());

            Product productThree = new Product()
            {
                Id = Guid.Parse("f22cab50-7f1c-4666-8eb0-76fb2fda1f9d"),
                Name = "TestProductTwo",
                Type = ProductType.Other,
                Description = "Test Product for AddProductTest()",
                Price = 5.00M,
                IsImported = true
            };

            // Initializing receipt
            var receipt = service.GenerateReceipt();

            Assert.IsNotNull(receipt);

            // Adding productThree to transaction
            service.AddProduct(productThree);

            // Updating receipt
            receipt = service.GenerateReceipt();

            Assert.IsTrue(receipt.LineItems?.Count == 3);
        }

        /// <summary>
        /// Test method for RemoveProduct()
        /// </summary>
        [TestMethod]
        public void RemoveProductTest()
        {
            var service = new TransactionServices(ProductRepositoryFiller(), CalculatorFiller());

            Product productThree = new Product()
            {
                Id = Guid.Parse("f22cab50-7f1c-4666-8eb0-76fb2fda1f9d"),
                Name = "TestProductTwo",
                Type = ProductType.Other,
                Description = "Test Product for RemoveProductTest()",
                Price = 5.00M,
                IsImported = true
            };

            // Adding productThree to transaction
            service.AddProduct(productThree);

            // Initializing receipt
            var receipt = service.GenerateReceipt();

            Assert.IsTrue(receipt.LineItems?.Count == 2);

            service.RemoveProduct(productThree);

            Assert.IsTrue(receipt.LineItems?.Count == 2);
        }

        /// <summary>
        /// Test method for GenerateReceipt
        /// </summary>
        [TestMethod]
        public void GenerateReceiptTest()
        {
            var service = new TransactionServices(ProductRepositoryFiller(), CalculatorFiller());

            // Initializing receipt
            var receipt = service.GenerateReceipt();

            Assert.IsNotNull(receipt);
            Assert.IsTrue(receipt.LineItems?.Count == 2);
        }

        /// <summary>
        /// This helper function creates and returns a ProductRepository
        /// for testing the above functions
        /// </summary>
        /// <returns> Filled ProductRepository </returns>
        public IProductRepository ProductRepositoryFiller()
        {
            var repo = new ProductInMemoryRepository();

            // Creating two test products
            Product productOne = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProductOne",
                Type = ProductType.Other,
                Description = "Test Product from ProductRepositoryFiller()",
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

            // Adding products that we created
            repo.AddProduct(productOne);
            repo.AddProduct(productTwo);

            return repo;
        }

        /// <summary>
        /// This helper function creates and returns an array of Calculators
        /// One being for Sales Tax and the other for Import tax
        /// </summary>
        /// <returns> Array of Calculators </returns>
        public ITaxCalculatorServices[] CalculatorFiller()
        {
            ITaxCalculatorServices[] calcArray = new ITaxCalculatorServices[2]; 

            var salesCalc = new SalesTaxCalculatorServices(new ProductTaxRepository());
            var importCalc = new ImportTaxCalculatorServices();

            calcArray[0] = salesCalc;
            calcArray[1] = importCalc;

            return calcArray;
        }
    }
}