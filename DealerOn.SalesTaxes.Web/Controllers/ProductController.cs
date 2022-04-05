using DealerOn.SalesTaxes.Models;
using DealerOn.SalesTaxes.Models.Exceptions;
using DealerOn.SalesTaxes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealerOn.SalesTaxes.Web.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {

        /// <summary>
        /// Adds product to Transaction
        /// </summary>
        /// <param name="product"></param>
        /// <returns> IActionResult status </returns>
        [HttpPut]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _transactionServices.AddProduct(product);
                return Ok();
            }
            catch (NotFoundException nex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                //Returns Exception and message Description
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Removes product from Transaction
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult RemoveProduct(Product product)
        {
            try
            {
                _transactionServices.RemoveProduct(product);
                return Ok();
            }
            catch (NotFoundException nex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                //Returns the exception and message description
                return StatusCode(500, ex.Message);
            }
        }
    }
}