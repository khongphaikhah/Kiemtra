using EfAPI.Data;
using EfAPI.Repository.Interface;
using Entity;

namespace EfAPI.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(AppDb context) : base(context)
        {
        }
    }
}
