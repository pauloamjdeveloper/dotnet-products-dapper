using Microsoft.AspNetCore.Mvc;
using Products.Dapper.WebAPI.Business;
using Products.Dapper.WebAPI.Models;

namespace Products.Dapper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productBusiness.GetAllProductsAsync();

                return Ok(products);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productBusiness.GetProductByIdAsync(id);

                if (product == null) return NotFound();

                return Ok(product);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                var createProduct = await _productBusiness.CreateProductAsync(product);

                return CreatedAtAction(nameof(GetProductById), new { id = createProduct.Id }, createProduct);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product) 
        {
            try
            {
                var productExists = await _productBusiness.ExistsAsync(id);

                if (!productExists) return NotFound();

                var productToUpdate = new Product(id, product.Name, product.Description, product.Price, product.Quantity);

                var result = await _productBusiness.UpdateProductAsync(productToUpdate);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            try
            {
                var searchId = await _productBusiness.ExistsAsync(id);

                if (!searchId) return NotFound();

                await _productBusiness.DeleteProductAsync(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
