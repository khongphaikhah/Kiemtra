using Entity;

namespace EfAPI.Repository.Interface
{
    public interface IImageRepository : IRepository<Images>
    {
       string DoiFileAnhSangChuoi(IFormFile file);
       string DoiNhieuFileAnhSangChuoi(IList<IFormFile> files);
    }
}
