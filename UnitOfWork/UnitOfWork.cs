using EfAPI.Data;
using EfAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace EfAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDb _context;
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }
        public IImageRepository ImageRepository { get; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(AppDb context, IProductRepository productRepository, ICategoryRepository categoryRepository, IProductImageRepository productImageRepository, IImageRepository imageRepository)
        {
            _context = context;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            ProductImageRepository = productImageRepository;
            ImageRepository = imageRepository;
        }
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction.RollbackAsync();
            _transaction.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
