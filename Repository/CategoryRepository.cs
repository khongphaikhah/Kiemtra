using EfAPI.Data;
using EfAPI.Repository.Interface;
using Entity;

namespace EfAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDb context) : base(context)
        {
        }
    }
}
