using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxes.Models.Transactions;

namespace SalesTaxes.Services
{
    public interface ITaxCalculatorServices
    {
        /// <summary>
        /// This function is responsible for calculating both Sales and Import
        /// tax for a product
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns> Sales and Import taxes of a product </returns>
        CalculatedValue Calculate(Product product, int quanitity);

        /// <summary>
        /// Function responsible for assigning name of this calculator
        /// </summary>
        string Name { get; }
    }
}
