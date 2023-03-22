using AutoMapper;
using EfAPI.Model.Category;
using EfAPI.UnitOfWork;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EfAPI.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/category/getAll")]
        public List<CategoryReponseDto> GetAll()
        {
            try
            {
                var categoriesEntity = _unitOfWork.CategoryRepository.GetAll().ToList();
                var categoriesDto = _mapper.Map<List<Category>, List<CategoryReponseDto>>(categoriesEntity);
                return categoriesDto;
            }
            catch(Exception e)
            {
                return new List<CategoryReponseDto>();
            }
        }
    }
}
