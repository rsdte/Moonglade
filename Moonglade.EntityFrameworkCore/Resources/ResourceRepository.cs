using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public class ResourceRepository : RepositoryBase<ResourceEntity, int>, IResourceRepository
    {
        private readonly MoongladeDbContext dbContext;

        public ResourceRepository(MoongladeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public override async Task<bool> DeleteableAsync(ResourceEntity entity)
        {
            entity.Deleted = true;
            this.dbContext.Set<ResourceEntity>().Update(entity);
            return await this.dbContext.SaveChangesAsync() > 0;
        }
    }
}
