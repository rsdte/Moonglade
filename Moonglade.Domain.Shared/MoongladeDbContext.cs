using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonglade.Domain.Shared
{
    public class MoongladeDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<ResourceEntity> Resources { get; set; }
        public DbSet<RoleResourceEntity> RoleResources { get; set; }

        public MoongladeDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
