using AutoMapper;
using EfAPI.Model.Category;
using EfAPI.Model.Product;
using EfAPI.UnitOfWork;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace EfAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Api/Products/Create")]
        public ProductRequestDto Create(ProductRequestDto input)
        {
            try
            {
                var product = _mapper.Map<ProductRequestDto, Product>(input);
                var data = _unitOfWork.ProductRepository.Create(product);
                _unitOfWork.SaveChanges();
                return input;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut]
        [Route("Api/Products/Update")]
        public ProductRequestDto Update(ProductRequestDto input, int idProduct)
        {
            try
            {
                var product = _mapper.Map<ProductRequestDto, Product>(input);
                product.Id = idProduct;
                var data = _unitOfWork.ProductRepository.Update(product, idProduct);
                _unitOfWork.SaveChanges();
                return input;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Api/Products/Get")]
        public ProductReponseDto GetById(int idProduct)
        {
            try
            {
                var products = _unitOfWork.ProductRepository.Get(idProduct);
                var productDto = _mapper.Map<Product, ProductReponseDto>(products);

                return productDto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Api/Products/GetAll")]
        public List<ProductReponseDto> GetAll()
        {
            try
            {
                var products = _unitOfWork.ProductRepository.GetAll();
                var listProduct = _mapper.Map<List<Product>, List<ProductReponseDto>>(products.ToList());
                return listProduct;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
