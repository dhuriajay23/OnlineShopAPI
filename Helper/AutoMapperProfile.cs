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
            CreateMap<GetProductsDto, Product>();
        }
    }
}
