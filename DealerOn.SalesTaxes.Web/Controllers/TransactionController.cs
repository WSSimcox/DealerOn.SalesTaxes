using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Exceptions;
using DealerOn.SalesTaxes.Models.Transactions;
using DealerOn.SalesTaxes.Services;
using DealerOn.SalesTaxes.Web.ViewModel;
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
        [HttpPost]
        public IActionResult CreateTransactionReciept(IList<LineItemViewModel> lineItemViewModels)
        {
            try
            {
                var result = _transactionServices.GenerateReceipt(lineItemViewModels.Select(p => (ILineItem)p).ToList());

                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    };
}