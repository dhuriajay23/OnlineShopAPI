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

        public async Task<ServiceResponse<GetProductsDto>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductsDto>();
            newProduct.Id = Guid.NewGuid();
            var product = _mapper.Map<Product>(newProduct);
            await _onlineShopDbContext.Products.AddAsync(product);
            await _onlineShopDbContext.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetProductsDto>(product);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> GetProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductsDto>>();
            var dbProducts = await _onlineShopDbContext.Products.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetProductsDto>>(dbProducts);
            serviceResponse.Message = $"Total Products: {dbProducts.Count}";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductsDto>> GetProduct(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetProductsDto>();

            try
            {
                var dbProduct = await _onlineShopDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (dbProduct != null)
                {
                    serviceResponse.Data = _mapper.Map<GetProductsDto>(dbProduct);
                    serviceResponse.Message = "Product found.";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Product not found.";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductsDto>> UpdateProduct(Guid id, UpdateProductDto updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductsDto>();
            var dbProduct = await _onlineShopDbContext.Products.FindAsync(id);

            if (dbProduct != null)
            {
                dbProduct.Price = updatedProduct.Price;
                dbProduct.Quantity = updatedProduct.Quantity;
                dbProduct.Name = updatedProduct.Name;
                dbProduct.Category = updatedProduct.Category;

                _onlineShopDbContext.Products.Update(dbProduct);
                await _onlineShopDbContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetProductsDto>(dbProduct);
                serviceResponse.Message = "Product updated successfully.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductsDto>> DeleteProduct(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetProductsDto>();
            var dbProduct = await _onlineShopDbContext.Products.FindAsync(id);

            if (dbProduct != null)
            {
                _onlineShopDbContext.Products.Remove(dbProduct);
                await _onlineShopDbContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetProductsDto>(dbProduct);
                serviceResponse.Message = "Product deleted successfully.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
            }

            return serviceResponse;
        }
    }
}
