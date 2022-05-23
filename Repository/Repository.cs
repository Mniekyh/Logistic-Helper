using LogisticHelper.DataAccess;
using LogisticHelper.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LogisticHelper.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
      

            private readonly ApplicationDbContext _db;

            internal DbSet<T> dbSet;
            public Repository(ApplicationDbContext db)
            {
                _db = db;
                this.dbSet = _db.Set<T>();
            }
            public void Add(T entity)
            {
                // Working as in controller (Category Controller), entity here is obj there
                _db.Set<T>().Add(entity);
            }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }


        // Filter query, means check if checks requirements, and return first which checks
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
            {
                IQueryable<T> query = dbSet;
                query = query.Where(filter);
                return query.FirstOrDefault();
            }

            public void Remove(T entity)
            {
                dbSet.Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entity)
            {
                dbSet.RemoveRange(entity);
            }
        
    }
}
