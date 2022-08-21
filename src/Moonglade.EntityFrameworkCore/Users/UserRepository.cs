using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public class UserRepository : RepositoryBase<UserEntity, int>, IUserRepository
    {
        private readonly MoongladeDbContext dbContext;

        public UserRepository(MoongladeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override Task DeleteableAsync(UserEntity entity)
        {
            entity.Deleted = true;
            this.dbContext.Set<UserEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
