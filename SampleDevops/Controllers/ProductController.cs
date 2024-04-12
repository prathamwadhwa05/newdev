using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleDevops.Interfaces;
using SampleDevops.Models;

namespace SampleDevops.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller

    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepositoryBL _productRepository;
        public ProductController(IProductRepositoryBL productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductEntity product)
        {
            try
            {
                _productRepository.AddProduct(product);


                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected Error Occured");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }


        }
        [HttpGet("GetProductbyId/{id}")]
        public IActionResult GetProductById([FromRoute] Guid id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                if (_productRepository.NotAvailable(id))//Notavailable fxn
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteProduct/{id}")]

        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            try
            {

                var product = _productRepository.DeleteProduct(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected Error Occured");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
