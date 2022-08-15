using Microsoft.Extensions.DependencyInjection;

namespace Moonglade.Domain.Shared
{
    public static class IServerCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleResourceRepository, RoleResourceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            return services;
        }
    }
}
