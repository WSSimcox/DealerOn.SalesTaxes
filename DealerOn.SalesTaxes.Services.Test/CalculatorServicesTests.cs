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
            var salesCalc = new SalesTaxCalculatorServices(new ProductTaxRepository());
            var importCalc = new ImportTaxCalculatorServices();

            Product productOne = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "TestProduct",
                Type = ProductType.Other,
                Description = "Test Product for Calculate()",
                Price = 47.50M,
                IsImported = false
            };

            var receipt = new Receipt();

            receipt.TotalCost += salesCalc.Calculate(productOne, 1).TotalCost;
            receipt.TotalCost += importCalc.Calculate(productOne, 1).TotalCost;

            Assert.IsTrue(receipt.TotalCost == 54.65M);
        }
    }
}