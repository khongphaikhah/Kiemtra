using EfAPI.Data;
using EfAPI.Repository.Interface;
using Entity;

namespace EfAPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDb context) : base(context)
        {
        }
    }
}
