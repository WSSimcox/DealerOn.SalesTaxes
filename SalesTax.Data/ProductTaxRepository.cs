using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Data
{
    public class ProductTaxRepository : IProductTaxRepository
    {
        // Tax rates
        private readonly double _basicTaxRate = 0.10;
        private readonly double _importTaxRate = 0.5;

        /// <summary>
        /// Returns a mapped list of taxRates to their productTypes (enum)
        /// </summary>
        /// <returns></returns>
        public IList<Tuple<ProductType, decimal>> GetTaxRates()
        {
            var taxMap = new List<Tuple<ProductType, decimal>>();

            taxMap.Add(new Tuple<ProductType, decimal>(ProductType.Book, 0));
            taxMap.Add(new Tuple<ProductType, decimal>(ProductType.Food, 0));
            taxMap.Add(new Tuple<ProductType, decimal>(ProductType.Medical, 0));
            taxMap.Add(new Tuple<ProductType, decimal>(ProductType.Other, 0.10M));

            return taxMap;
        }
    }
}
