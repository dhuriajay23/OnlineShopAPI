// Project
using OnlineShopAPI.DTOs;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductsDto>>> GetAllProducts();
        Task<ServiceResponse<GetProductsDto>> AddNewProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductsDto>> GetProduct(Guid id);
    }
}
