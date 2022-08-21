namespace Moonglade.Domain
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Rollback();
        void BeginTransaction();
        int SaveChanges();
    }
}
