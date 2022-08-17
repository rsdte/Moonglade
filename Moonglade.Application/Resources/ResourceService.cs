using Moonglade.Application.Contracts;
using Moonglade.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Moonglade.Application
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository resourceRepository;
        private readonly IRoleResourceRepository roleResourceRepository;

        public ResourceService(IResourceRepository resourceRepository, IRoleResourceRepository roleResourceRepository)
        {
            this.resourceRepository = resourceRepository;
            this.roleResourceRepository = roleResourceRepository;
        }

        public async Task<IEnumerable<ResourceEntity>> GetAllResources(IList<int> roleIds)
        {
            var roleResources = await this.roleResourceRepository.GetAllAsync(r => !r.Deleted && roleIds.Contains(r.RoleId));
            var resourceIds = roleResources.Select(r => r.ResourceId).ToList();
            var resources = await resourceRepository.GetAllAsync(s => !s.Deleted && resourceIds.Contains(s.Id));
            return resources;
        }

        public async Task<IEnumerable<ResourceEntity>> GetResources(int roleId)
        {
            var roleResources = await this.roleResourceRepository.GetAllAsync(r => !r.Deleted && r.RoleId == roleId);
            var resourceIds = roleResources.Select(r => r.ResourceId).ToList();
            var resources = await resourceRepository.GetAllAsync(s => !s.Deleted && resourceIds.Contains(s.Id));
            return resources;
        }
    }
}
