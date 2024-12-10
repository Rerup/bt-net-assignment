using Domain.Products;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Services.ProductService.Contract;

namespace ProductApi.Controllers
{
    [Route("api/v{version:apiVersion}/")]
    [Route("api/")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("products/{guid}")]
        public async Task<IActionResult> GetProduct(Guid guid)
        {
            var product = await _productService.GetProductAsync(guid);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }

            var newProduct = await _productService.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { guid = newProduct.Id }, newProduct);
        }

        [HttpPut("products/{guid}")]
        public async Task<IActionResult> UpdateProduct(Guid guid, Product product)
        {
            var existingProduct = await _productService.GetProductAsync(guid);

            if (existingProduct is null)
            {
                return NotFound();
            }

            var updatedProduct = await _productService.UpdateProductAsync(existingProduct, product);

            return Ok(updatedProduct);
        }

        [HttpDelete("products/{guid}")]
        public async Task<IActionResult> DeleteProduct(Guid guid)
        {
            var product = await _productService.GetProductAsync(guid);

            if (product is null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(product);

            return NoContent();
        }
    }
}

