using Microsoft.EntityFrameworkCore;
using static SimpleEFCoreAPITemplate.Data.RepositoryBase;
using System.Data;
using System.Linq.Expressions;
using SimpleEFCoreAPITemplate.Data.Interfaces;

namespace SimpleEFCoreAPITemplate.Data
{
    public class RepositoryBase
    {
        public class Repository<T> : IRepository<T> where T : class
        {
            private DBCtx _dataContext;
            private readonly DbSet<T> dbset;

            public Repository(DBCtx dataContext)
            {
                _dataContext = dataContext;
                dbset = DataContext.Set<T>();
            }

            protected DBCtx DataContext
            {
                get { return _dataContext; }
            }

            public virtual void Add(T entity)
            {
                dbset.Add(entity);
            }
            public virtual void Update(T entity)
            {
                dbset.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
            }
            public virtual void Delete(T entity)
            {
                dbset.Remove(entity);
            }
            public void Delete(Expression<Func<T, bool>> where)
            {
                IEnumerable<T> objects = dbset.Where(where).AsEnumerable();
                foreach (T obj in objects)
                    dbset.Remove(obj);
            }
            public async Task DeleteAsync(Expression<Func<T, bool>> where)
            {
                IEnumerable<T> objects = await dbset.Where(where).ToListAsync();
                foreach (T obj in objects)
                    dbset.Remove(obj);
            }
            public virtual T? GetById(int id)
            {
                return dbset.Find(id);
            }
            public async Task<T?> GetByIdAsync(int Id)
            {
                return await dbset.FindAsync(Id);
            }
            public T? Get(Expression<Func<T, bool>> where)
            {
                return dbset.FirstOrDefault(where);
            }
            public async Task<T?> GetAsync(Expression<Func<T, bool>> where)
            {
                return await dbset.Where(where).FirstOrDefaultAsync();
            }
            public virtual IEnumerable<T> GetAll()
            {
                return dbset.ToList();
            }
            public Task<T> GetAllAsync()
            {
                return Task.Run(() => GetAllAsync());
            }
            public virtual IQueryable<T> GetAllQuery()
            {
                return dbset;
            }
            public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
            {
                return dbset.Where(where).ToList();
            }
            public Task<T> GetManyAsync(Expression<Func<T, bool>> where)
            {
                return Task.Run(() => GetManyAsync(where));
            }
            public virtual IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where)
            {
                return dbset.Where(where);
            }

        }
    }
}
