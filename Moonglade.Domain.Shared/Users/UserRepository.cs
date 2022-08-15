namespace Moonglade.Domain.Shared
{
    public class UserRepository : RepositoryBase<UserEntity, int>, IUserRepository
    {
        private readonly MoongladeDbContext dbContext;

        public UserRepository(MoongladeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async override Task<bool> DeleteableAsync(UserEntity entity)
        {
            entity.Deleted = true;
            this.dbContext.Set<UserEntity>().Update(entity);
            return await this.dbContext.SaveChangesAsync() > 0;
        }
    }
}
