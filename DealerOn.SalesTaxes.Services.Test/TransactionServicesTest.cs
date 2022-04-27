using SalesTaxes.Data;
using SalesTaxes.Models;
using SalesTaxes.Models.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Services.Tests
{
    [TestClass]
    public class TransactionServicesTest
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
            // Initializing TransactionServices
            var transactionService = new TransactionServices(_productRepo, CalculatorFiller());

            transactionService.AddLineItem(_productRepo.GetProducts()[0]);
            transactionService.AddLineItem(_productRepo.GetProducts()[1]);
            transactionService.AddLineItem(_productRepo.GetProducts()[2]);

            // Updating receipt
            var transaction = transactionService.GenerateTransaction();

            Assert.IsTrue(transaction.Receipt.LineItems?.Count == 3);
        }

        /// <summary>
        /// Test method for RemoveProduct()
        /// </summary>
        [TestMethod]
        public void RemoveProductTest()
        {
            // Initializing TransactionServices
            var transactionService = new TransactionServices(_productRepo, CalculatorFiller());

            // Adding LineItems to transaction
            transactionService.AddLineItem(_productRepo.GetProducts()[0]);
            transactionService.AddLineItem(_productRepo.GetProducts()[1]);

            // Checking if everything is added
            Assert.IsTrue(transactionService.GetAllProductCount() == 2);

            // Removing LineItem
            transactionService.RemoveLineItem(_productRepo.GetProducts()[1].Id);

            // Checking if LineItem was removed
            Assert.IsTrue(transactionService.GetAllProductCount() == 1);
        }

        /// <summary>
        /// Test method for GenerateReceipt
        /// </summary>
        [TestMethod]
        public void GenerateTransactionTest()
        {
            // Initializing TransactionServices
            var transactionService = new TransactionServices(_productRepo, CalculatorFiller());

            // Adding LineItems to transaction
            transactionService.AddLineItem(_productRepo.GetProducts()[3]);
            transactionService.AddLineItem(_productRepo.GetProducts()[4]);

            // Making new receipt
            var transaction = transactionService.GenerateTransaction();

            Assert.IsTrue(transaction.Receipt.TotalCost == 65.15M);
            Assert.IsTrue(transaction.Receipt.TotalTax == 7.65M);
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