using SimpleEFCoreAPITemplate.Data.Interfaces;
using SimpleEFCoreAPITemplate.Models;
using static SimpleEFCoreAPITemplate.Data.RepositoryBase;

namespace SimpleEFCoreAPITemplate.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private DBCtx _dataContext;

        public UnitOfWork(DBCtx dataContext)
        {
            _dataContext = dataContext;
        }
        public void Commit()
        {
            _dataContext.Commit();
        }

        public async Task CommitAsync()
        {
            await _dataContext.CommitAsync();
        }

        private IRepository<Product> _productRepository;
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                { this._productRepository = new Repository<Product>(_dataContext); }
                return _productRepository;
            }
        }

        private IRepository<ProductDetail> _productDetailRepository;
        public IRepository<ProductDetail> ProductDetailRepository
        {
            get
            {
                if (this._productDetailRepository == null)
                { this._productDetailRepository = new Repository<ProductDetail>(_dataContext); }
                return _productDetailRepository;
            }
        }
    }
}
