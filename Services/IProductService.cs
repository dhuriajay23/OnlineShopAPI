// Project
using OnlineShopAPI.DTOs;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductsDto>>> GetAllProducts();
    }
}
