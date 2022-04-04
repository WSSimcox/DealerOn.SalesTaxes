﻿using DealerOn.SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerOn.SalesTaxes.Models.Transactions;

namespace DealerOn.SalesTaxes.Services
{
    public interface ICalculator
    {
        /// <summary>
        /// This function is responsible for calculating both Sales and Import
        /// tax for a product
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns> Sales and Import taxes of a product </returns>
        CalculatedValue Calculate(Product product, int quanitity);

        string Name { get; }
    }
}
