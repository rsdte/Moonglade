using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public class RoleResourceRepository : RepositoryBase<RoleResourceEntity, int>, IRoleResourceRepository
    {
        private readonly MoongladeDbContext dbContext;

        public RoleResourceRepository(MoongladeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task<bool> DeleteableAsync(RoleResourceEntity entity)
        {
            entity.Deleted = true;
            this.dbContext.Set<RoleResourceEntity>().Update(entity);
            return await this.dbContext.SaveChangesAsync() > 0;
        }
    }
}
