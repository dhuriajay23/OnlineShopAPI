// Project
using OnlineShopAPI.DTOs;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductsDto>>> GetProducts();
        Task<ServiceResponse<GetProductsDto>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductsDto>> GetProduct(Guid id);
        Task<ServiceResponse<GetProductsDto>> UpdateProduct(Guid id, UpdateProductDto updatedProduct);
        Task<ServiceResponse<GetProductsDto>> DeleteProduct(Guid id);
    }
}
