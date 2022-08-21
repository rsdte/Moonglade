using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moonglade.Application.Contracts;
using Moonglade.Web.Areas.Admin.ViewModels;

namespace Moonglade.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class PermissionController : Moonglade.Web.Commons.ControllerBase
    {
        private readonly IResourceService resourceService;

        public PermissionController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }


        [HttpGet]
        public async Task<IActionResult> GetMenuTree()
        {
            var roleIds = this.User.FindFirst("RoleIds")!.Value.Split(",").Select(x=> Int32.Parse(x)).Cast<int>().ToList();
            var resources = await resourceService.GetAllResources(roleIds);
            var tree = new List<ResourceTreeViewModel>();
            foreach (var res in resources.Where(p => p.ResourceType == Domain.ResourceType.Menu))
            {
                var item = new ResourceTreeViewModel
                {
                    Description = res.Description,
                    Link = res.Url,
                    DisplayName = res.DisplayName,
                    Type = 0,
                };


                item.Children = resources.Where(p => p.ParentId == res.Id).Select(x => new ResourceTreeViewModel
                {
                    Description = x.Description,
                    Link = x.Url,
                    DisplayName = x.DisplayName,
                    Type = 1
                }).ToList();

                tree.Add(item);
            }
            return SuccessResult(tree);
        }

    }
}
