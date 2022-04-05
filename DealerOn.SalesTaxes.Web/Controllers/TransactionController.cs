using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Exceptions;
using DealerOn.SalesTaxes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealerOn.SalesTaxes.Web.Controllers
{
    [ApiController]
    [Route("api/v1/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _transactionServices;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionServices"></param>
        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        /// <summary>
        /// Retrieves a generated Receipt
        /// </summary>
        /// <returns> IActionResult status </returns>
        [HttpGet]
        public IActionResult GetTransactionReciept()
        {
            var result = _transactionServices.GenerateReceipt();

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    };
}