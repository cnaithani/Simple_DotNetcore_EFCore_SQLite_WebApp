using System.Linq.Expressions;

namespace SimpleEFCoreAPITemplate.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long Id);
        T GetById(string Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQuery();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(long Id);
        Task<T> GetByIdAsync(string Id);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetAllAsync();
        Task<T> GetManyAsync(Expression<Func<T, bool>> where);
    }
}
