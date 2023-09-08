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
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto newProduct)
        {
            return Ok(await _productService.AddNewProduct(newProduct));
        }
    }
}
