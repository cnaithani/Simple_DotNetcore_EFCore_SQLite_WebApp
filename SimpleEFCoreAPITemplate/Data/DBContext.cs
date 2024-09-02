using Microsoft.EntityFrameworkCore;
using SimpleEFCoreAPITemplate.Models;

namespace SimpleEFCoreAPITemplate.Data
{
    public class DBCtx : DbContext
    {
        public DBCtx(DbContextOptions options) : base(options) {}
        public virtual void Commit()
        {
            SaveChanges();
        }
        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //Do any final changes before saving here 
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            //Do any final changes before saving here 
            return base.SaveChanges();
        }


        //DBSets
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
    }
}
