using DealerOn.SalesTaxes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DealerOn.SalesTaxes.Services.Test
{
    [TestClass]
    public class TransactionServicesTest
    {
        [TestMethod]
        public void CalculateReceiptTaxesTest()
        {
            var service = new BasicTaxCalculator();

            Receipt reciept = new Receipt()
            {

            };
        }

        [TestMethod]
        public void CalculateProductTest()
        {
            var service = new BasicTaxCalculator();

            Product product = new Product()
            {
                Id = Guid.Parse("6297d114-6c99-4bdd-a0e5-2ab691b858a5"),
                Name = "Perfume",
                Type = ProductType.Other,
                Description = "Test Product for CalculateProductTest()",
                Price = 47.50,
                IsImported = true
            };
        }
    }
}