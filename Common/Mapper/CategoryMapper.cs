using AutoMapper;
using EfAPI.Model.Category;
using Entity;

namespace EfAPI.Common.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryReponseDto>();
            CreateMap<CategoryReponseDto, Category>();
        }
    }
}
