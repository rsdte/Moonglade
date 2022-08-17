using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Moonglade.Domain.Shared
{
    public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable
        where TDbContext : DbContext
    {
        private IDbContextTransaction? dbContextTransaction;
        private readonly TDbContext dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            dbContextTransaction = dbContext.Database.BeginTransaction();
        }

        public bool Commit()
        {
            if (dbContextTransaction is null)
            {
                return SaveChanges() > 0;
            }
            using (dbContextTransaction)
            {
                dbContextTransaction.Commit();
            }
            return true;
        }

        public void Dispose()
        {
            this.dbContextTransaction?.Dispose();
        }

        public void Rollback()
        {
            this.dbContextTransaction?.Rollback();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
