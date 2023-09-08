// AutoMapper
using AutoMapper;

// Project
using OnlineShopAPI.DTOs;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, AddProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<GetProductsDto, Product>();
            CreateMap<Product, GetProductsDto>();
        }
    }
}
