// Microsoft
using Microsoft.AspNetCore.Mvc;

// Project
using OnlineShopAPI.DTOs;
using OnlineShopAPI.Services;

namespace OnlineShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var response = await _productService.GetProduct(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductDto updatedProduct)
        {
            var response = await _productService.UpdateProduct(id, updatedProduct);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
