using Microsoft.Extensions.DependencyInjection;
using Moonglade.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonglade.Application
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAllService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IResourceService, ResourceService>();
            return services;
        }
    }
}
