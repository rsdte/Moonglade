using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonglade.Domain.Shared
{
    public class RoleRepository : RepositoryBase<RoleEntity, int>, IRoleRepository
    {
        private readonly MoongladeDbContext dbContext;

        public RoleRepository(MoongladeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public  async override Task<bool> DeleteableAsync(RoleEntity entity)
        {
            entity.Deleted = true;
            this.dbContext.Set<RoleEntity>().Update(entity);
            return await this.dbContext.SaveChangesAsync() > 0;
        }
    }
}
