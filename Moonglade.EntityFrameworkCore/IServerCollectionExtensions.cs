using Microsoft.Extensions.DependencyInjection;
using Moonglade.Domain;

namespace Moonglade.EntityFrameworkCore
{
    public static class IServerCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<MoongladeDbContext>>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IRoleResourceRepository, RoleResourceRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();
            return services;
        }
    }
}
