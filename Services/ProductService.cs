// Microsoft
using Microsoft.EntityFrameworkCore;

// AutoMapper
using AutoMapper;

// Project
using OnlineShopAPI.Data;
using OnlineShopAPI.DTOs;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly OnlineShopDbContext _onlineShopDbContext;

        public ProductService(IMapper mapper, OnlineShopDbContext onlineShopDbContext)
        {
            _mapper = mapper;
            _onlineShopDbContext = onlineShopDbContext;
        }

        public async Task<ServiceResponse<GetProductsDto>> AddNewProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductsDto>();
            newProduct.Id = Guid.NewGuid();
            var product = _mapper.Map<Product>(newProduct);
            await _onlineShopDbContext.Products.AddAsync(product);
            await _onlineShopDbContext.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetProductsDto>(product);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductsDto>>();
            var dbProducts = await _onlineShopDbContext.Products.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetProductsDto>>(dbProducts);
            serviceResponse.Message = $"Total Products: {dbProducts.Count}";
            return serviceResponse;
        }
    }
}
