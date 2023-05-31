using Microsoft.EntityFrameworkCore;

namespace RCA.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly RCADbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(RCADbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> Queryable()
        {
            return _dbSet.AsQueryable();
        }
        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }
    }
}