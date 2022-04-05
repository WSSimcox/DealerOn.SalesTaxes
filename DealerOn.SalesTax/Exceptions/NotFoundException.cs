using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Models.Exceptions
{
    public class NotFoundException : SalesTaxesException
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }
    }
}
