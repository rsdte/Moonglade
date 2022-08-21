using Microsoft.AspNetCore.Mvc;
using Moonglade.Application.Contracts;
using Moonglade.WebApi.Commons;
using Moonglade.WebApi.ViewModels;

namespace Moonglade.WebApi.Controllers
{
    public class ResourceController : ApiAuthControllerBase
    {
        private readonly IResourceService resourceService;

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        /// <summary>
        /// 获取菜单列表。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roleIds = this.User?.FindFirst("RoleIds")?.Value.Split(',').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
            var resources = await this.resourceService.GetAllResources(roleIds!);
            var tree = new List<PermissionViewModel>();
            foreach (var res in resources.Where(p => p.ResourceType == Domain.ResourceType.Menu))
            {
                var item = new PermissionViewModel
                {
                    Id = res.Id,
                    Link = res.Url,
                    DisplayName = res.DisplayName,
                };

                item.Children = resources.Where(p => p.ParentId == res.Id).Select(x => new PermissionViewModel
                {
                    Id = res.Id,
                    Link = x.Url,
                    DisplayName = x.DisplayName,
                }).ToList();

                tree.Add(item);
            }
            return SuccessResult(tree);
        }


        /// <summary>
        /// 获取某个菜单页面下所有可用按钮列表。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBtnLinksAsync(int viewCode)
        {
            var resources = await this.resourceService.GetDetailResource(viewCode);
            var data = resources.Select(x => new PermissionViewModel { DisplayName = x.DisplayName, Id = x.Id, Link = x.Url }).ToList();
            return SuccessResult(data);
        }
    }
}
