using AutoMapper;
using EfAPI.Model;
using EfAPI.Model.Product;
using EfAPI.UnitOfWork;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace EfAPI.Controllers
{
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Api/Images/UploadImage")]
        public string UploadImage(ImageDto input)
        {
            try
            {
                var stringImage = _unitOfWork.ImageRepository.DoiFileAnhSangChuoi(input.files);
                _unitOfWork.ImageRepository.Create(new Images
                {
                    FileName = stringImage
                });
                return "Tạo ảnh thành công";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
