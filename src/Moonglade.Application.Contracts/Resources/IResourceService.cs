using Moonglade.Domain;

namespace Moonglade.Application.Contracts
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceEntity>> GetResources(int roleId);
        Task<IEnumerable<ResourceEntity>> GetAllResources(IList<int> roleIds);

        /// <summary>
        /// 获取某一页面下的可操作资源。
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        Task<IEnumerable<ResourceEntity>> GetDetailResource(int resourceId);
    }
}
