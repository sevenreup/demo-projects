using AutoMapper;
using ProductApi.DTOs;
using ProductApi.Entities;

namespace ProductApi.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
