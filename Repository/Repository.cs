using EfAPI.Data;
using EfAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EfAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDb _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDb context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public ICollection<T> Get(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match).ToList();
        }
        public ICollection<T> Get(Expression<Func<T, bool>> match, int pageSize, int pageIndex, out int total)
        {
            var filteredElements = _dbSet.Where(match.Compile());
            total = filteredElements.Count();
            var pageElements = filteredElements.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return pageElements.ToList();
        }

        public T? Update(T t, object key)
        {
            T? entity = _dbSet.Find(key);

            if (entity != null)
            {
                // nên sử dụng để check id và id object
                _context.Entry(entity).CurrentValues.SetValues(t);
                // cách này vẫn sử dụng được 
                //_context.Entry(t).State = EntityState.Modified;
            }

            return entity;
        }
        public T Create(T t)
        {
            _dbSet.Add(t);
            return t;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T? Get(int id)
        {
            return _dbSet.Find(id);
        }
        
        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

    }
}
