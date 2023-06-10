// Microsoft
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Project
using OnlineShopAPI.Data;

namespace OnlineShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly OnlineShopDbContext _onlineShopDbContext;

        public ProductsController(OnlineShopDbContext onlineShopDbContext)
        {
            _onlineShopDbContext = onlineShopDbContext;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _onlineShopDbContext.Products.ToListAsync());
        }
    }
}
