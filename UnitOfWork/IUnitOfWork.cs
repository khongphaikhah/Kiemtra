using EfAPI.Data;
using EfAPI.Repository.Interface;

namespace EfAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IImageRepository ImageRepository { get; }

        void SaveChanges();
        void CreateTransaction();
        void Commit();
        void Rollback();
    }
}
