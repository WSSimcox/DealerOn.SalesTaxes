using SalesTaxes.Models;
using SalesTaxes.Models.Exceptions;
using SalesTaxes.Models.Transactions;
using SalesTaxes.Services;
using SalesTaxes.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace SalesTaxes.Web.Controllers
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
        [HttpPost]
        public IActionResult CreateTransaction(IList<LineItemViewModel> lineItemViewModels)
        {
            try
            {
                var transaction = _transactionServices.GenerateTransaction(lineItemViewModels.Select(p => (ILineItem)p).ToList());

                if (transaction == null)
                    return NotFound();
                return Ok(transaction);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    };
}