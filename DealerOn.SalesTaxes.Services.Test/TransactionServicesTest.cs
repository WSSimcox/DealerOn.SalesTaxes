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
        [TestInitialize]
        public void Initialize()
        {
            var productRepo = new ProductInMemoryRepository();

            // Creating two test products
            Product productOne = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProductOne",
                Type = ProductType.Other,
                Description = "Test Product from ProductRepositoryFiller()",
                Price = 47.50M,
                IsImported = true
            };

            Product productTwo = new Product()
            {
                Id = Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385"),
                Name = "TestProductTwo",
                Type = ProductType.Food,
                Description = "Test Product from ProductRepositoryFiller()",
                Price = 10.00M,
                IsImported = true
            };

            // Adding products that we created
            productRepo.AddProduct(productOne);
            productRepo.AddProduct(productTwo);
        }

        /// <summary>
        /// Test method for AddProduct()
        /// </summary>
        [TestMethod]
        public void AddProductTest()
        {
            // Initializing ProductInMemoryRepository
            var productRepo = new ProductInMemoryRepository();

            // Initializing TransactionServices
            var transaction = new TransactionServices(productRepo, CalculatorFiller());

            // Adding LineItems to transaction
            transaction.AddLineItem(productRepo.GetProductById(Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5")));
            transaction.AddLineItem(productRepo.GetProductById(Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385")));

            Product productThree = new Product()
            {
                Id = Guid.Parse("f22cab50-7f1c-4666-8eb0-76fb2fda1f9d"),
                Name = "TestProductTwo",
                Type = ProductType.Other,
                Description = "Test Product for AddProductTest()",
                Price = 5.00M,
                IsImported = true
            };

            // Adding to ProductMemory
            productRepo.AddProduct(productThree);

            // Adding productThree to transaction
            transaction.AddLineItem(productThree);

            // Updating receipt
            var receipt = transaction.GenerateReceipt();

            Assert.IsTrue(receipt.LineItems?.Count == 3);
        }

        /// <summary>
        /// Test method for RemoveProduct()
        /// </summary>
        [TestMethod]
        public void RemoveProductTest()
        {
            // Initializing ProductInMemoryRepository
            var productRepo = new ProductInMemoryRepository();

            // Initializing TransactionServices
            var transaction = new TransactionServices(productRepo, CalculatorFiller());

            // Adding LineItems to transaction
            transaction.AddLineItem(productRepo.GetProductById(Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5")));
            transaction.AddLineItem(productRepo.GetProductById(Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385")));

            // Initializing receipt
            var receipt = transaction.GenerateReceipt();

            // Checking if everything is added
            Assert.IsTrue(receipt.LineItems?.Count == 2);

            // Removing LineItem
            transaction.RemoveLineItem(Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385"));

            // Updating Receipt
            receipt = transaction.GenerateReceipt();

            // Checking if LineItem was removed
            Assert.IsTrue(receipt.LineItems?.Count == 1);
        }

        /// <summary>
        /// Test method for GenerateReceipt
        /// </summary>
        [TestMethod]
        public void GenerateReceiptTest()
        {
            // Initializing ProductInMemoryRepository
            var productRepo = new ProductInMemoryRepository();

            // Initializing TransactionServices
            var transaction = new TransactionServices(productRepo, CalculatorFiller());

            // Adding LineItems to transaction
            transaction.AddLineItem(productRepo.GetProductById(Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5")));
            transaction.AddLineItem(productRepo.GetProductById(Guid.Parse("83fefeaa-8154-43bd-9ca8-30e5fabc1385")));

            // Initializing receipt
            var receipt = transaction.GenerateReceipt();

            // Checking if LineItems are inside Transaction
            Assert.IsNotNull(receipt);
            Assert.IsTrue(receipt.LineItems?.Count == 2);
            Assert.IsTrue(receipt.TotalTax == 7.65M);
            Assert.IsTrue(receipt.TotalCost == 65.15M);
        }

        /// <summary>
        /// This helper function creates and returns an array of Calculators
        /// One being for Sales Tax and the other for Import tax
        /// </summary>
        /// <returns> Array of Calculators </returns>
        private ITaxCalculatorServices[] CalculatorFiller()
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