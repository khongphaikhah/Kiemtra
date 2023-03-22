using System.Linq.Expressions;

namespace EfAPI.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> Get(Expression<Func<T, bool>> match);
        ICollection<T> Get(Expression<Func<T, bool>> match, int pageSize, int pageIndex, out int total);
        T Create(T t);
        ICollection<T> GetAll();
        T? Update(T t, object key);
        void Delete(T entity);
        T? Get(int id);
    }
}
