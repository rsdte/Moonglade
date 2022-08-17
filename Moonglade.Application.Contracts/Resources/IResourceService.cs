using Moonglade.Domain;

namespace Moonglade.Application.Contracts
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceEntity>> GetResources(int roleId);
        Task<IEnumerable<ResourceEntity>> GetAllResources(IList<int> roleIds);
    }
}
