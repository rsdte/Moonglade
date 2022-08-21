using Moonglade.Application.Contracts.Dtos;
using Moonglade.Application.Contracts.Users.Dtos;
using Moonglade.Domain;

namespace Moonglade.Application.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// 生成用户登录凭证
        /// </summary>
        /// <param name="model">登录数据</param>
        /// <returns></returns>
        Task<string> GenerateTokenAsync(LoginDto model);

        /// <summary>
        /// 获取所有的用户。
        /// </summary>
        /// <returns></returns>
        Task<IPage<UserEntity>> SearchUserAsync(SearchUserDto model);

        /// <summary>
        /// 获取指定的用户信息
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<IEnumerable<UserEntity>> GetUsersAsync(IList<int> userIds);


        /// <summary>
        /// 获取某一用户的详细信息。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserEntity?> GetAsync(int id);

        /// <summary>
        /// 更新用户信息。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        Task<bool> UpdatePwdAsync(UpdatePwdDto model, int updatedUserId);
    }
}
