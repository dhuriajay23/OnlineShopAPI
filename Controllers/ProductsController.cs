// Microsoft
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Project
using OnlineShopAPI.Data;
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
    }
}
