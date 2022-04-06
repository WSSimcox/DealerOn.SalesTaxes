using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DealerOn.SalesTaxes.Services.Tests
{
    [TestClass]
    public class CalculatorServicesTests
    {
        /// <summary>
        /// Test method for Calculate()
        /// </summary>
        [TestMethod]
        public void Calculate()
        {
            // Initializing Calculators
            var salesCalc = new SalesTaxCalculatorServices(new ProductTaxRepository());
            var importCalc = new ImportTaxCalculatorServices();

            // Creating new product to test calculators
            Product productOne = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for Calculate()",
                Price = 47.50M,
                IsImported = true
            };

            var receipt = new Receipt();

            // Making price the starting TotalCost
            receipt.TotalCost += productOne.Price;
            // Adding the Sales tax
            receipt.TotalCost += salesCalc.Calculate(productOne, 1).TotalTax;
            // Adding the Import tax
            receipt.TotalCost += importCalc.Calculate(productOne, 1).TotalTax;

            Assert.IsTrue(receipt.TotalCost == 54.65M);
        }
    }
}