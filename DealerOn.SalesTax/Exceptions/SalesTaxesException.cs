using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Models.Exceptions
{
    public class SalesTaxesException : Exception
    {
        public SalesTaxesException() { }

        public SalesTaxesException(string message) : base(message) { }
    }
}
