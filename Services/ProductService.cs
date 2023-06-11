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

        public async Task<ServiceResponse<List<GetProductsDto>>> GetAllProducts()
        {
            var serviceResponse =  new ServiceResponse<List<GetProductsDto>>();
            var dbProducts = await _onlineShopDbContext.Products.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetProductsDto>>(dbProducts);
            return serviceResponse;
        }
    }
}
