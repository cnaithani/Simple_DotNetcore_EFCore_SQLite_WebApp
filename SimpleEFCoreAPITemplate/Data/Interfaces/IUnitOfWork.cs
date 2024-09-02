using SimpleEFCoreAPITemplate.Models;

namespace SimpleEFCoreAPITemplate.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductDetail> ProductDetailRepository { get; }
    }
}
