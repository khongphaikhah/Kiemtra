using AutoMapper;
using EfAPI.Model.Category;
using EfAPI.Model.Product;
using Entity;

namespace EfAPI.Common.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductReponseDto>();
            CreateMap<ProductReponseDto, Product>();
            CreateMap<Product, ProductRequestDto>();
            CreateMap<ProductRequestDto, Product>();
        }
    }
}
