using System.Linq.Expressions;

namespace SimpleEFCoreAPITemplate.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        Task DeleteAsync(Expression<Func<T, bool>> where);
        T? Get(Expression<Func<T, bool>> where);
        Task<T?> GetAsync(Expression<Func<T, bool>> where);
        T? GetById(int Id);
        Task<T?> GetByIdAsync(int Id);
        IEnumerable<T> GetAll();
        Task<T> GetAllAsync();
        IQueryable<T> GetAllQuery();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where);
        Task<T> GetManyAsync(Expression<Func<T, bool>> where);




   
    }
}
