using DealerOn.SalesTaxes.Data;
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
        private readonly IProductServices _productServices;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productServices"></param>
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        /// <summary>
        /// Gets Product from memory cache using specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Product found </returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var result = _productServices.GetProductById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets all Products in memory cache
        /// </summary>
        /// <returns> All Products found </returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productServices.GetProducts();
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adds product to Product memory cache
        /// </summary>
        /// <param name="product"></param>
        /// <returns> IActionResult status </returns>
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            _productServices.AddProduct(product);
            return Ok();
        }

        /// <summary>
        /// Removes product from Product memory cache
        /// </summary>
        /// <param name="product"></param>
        /// <returns> IActionResult status </returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveProduct(Guid id)
        {
            try
            {
                _productServices.RemoveProduct(id);
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

        /// <summary>
        /// Updates a product in Product memory cache
        /// </summary>
        /// <param name="product"></param>
        /// <returns> IActionResult status </returns>
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                _productServices.UpdateProduct(product);
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