using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Moonglade.Application.Contracts;

namespace Moonglade.WebApi.Permissions
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IResourceService resourceService;

        public PermissionHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.Resource is DefaultHttpContext httpContext)
            {
                var roleIds = context.User?.FindFirst("RoleIds")?.Value.Split(',').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
                if (roleIds != null)
                {
                    var url = httpContext.Request.Path.Value;
                    var resources = await resourceService.GetAllResources(roleIds);
                    if (resources != null && resources.Any(resource => string.Compare(resource.Url, url, true) == 0))
                    {
                        context.Succeed(requirement);
                        return;
                    }
                }
            }
            context.Fail();
        }
    }
}
