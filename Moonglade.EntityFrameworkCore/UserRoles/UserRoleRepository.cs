
using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public class UserRoleRepository : RepositoryBase<UserRoleEntity, int>, IUserRoleRepository
    {
        private readonly MoongladeDbContext dbContext;

        public UserRoleRepository(MoongladeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task<bool> DeleteableAsync(UserRoleEntity entity)
        {
            entity.Deleted = true;
            this.dbContext.Set<UserRoleEntity>().Update(entity);
            return await this.dbContext.SaveChangesAsync() > 0;
        }
    }
}
