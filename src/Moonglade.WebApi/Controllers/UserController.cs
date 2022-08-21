using Microsoft.AspNetCore.Mvc;
using Moonglade.Application.Contracts;
using Moonglade.Application.Contracts.Users.Dtos;
using Moonglade.Domain;
using Moonglade.EntityFrameworkCore;
using Moonglade.WebApi.Commons;
using Moonglade.WebApi.ViewModels;

namespace Moonglade.WebApi.Controllers
{
    public class UserController : ApiAuthControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 获取所有有效用户。
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<IPage<UserViewModel>>> SearchAsync([FromBody]SearchUserDto model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("数据错误.");
            }

            var users = await this.userService.SearchUserAsync(model);
            var createdUserIds = users.Data.Select(x => x.CreatedUserId).ToList();
            var createdUsers = await this.userService.GetUsersAsync(createdUserIds);
            var data = new List<UserViewModel>();
            foreach (var u in users.Data)
            {
                var d = new UserViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    CreatedUserId = u.CreatedUserId,
                    CreatedTime = u.CreatedTime,
                    Password = u.Password,
                    CreatedUserName = createdUsers.First(x => x.Id == u.CreatedUserId).UserName
                };

                data.Add(d);
            }
            return SuccessResult(new Page<UserViewModel> { Data = data, Count = users.Count, Index = users.Index });
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePwdAsync(UpdatePwdDto model)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("Id")!.Value);
            if (await this.userService.UpdatePwdAsync(model, userId))
            {
                return SuccessResult("成功!");
            }
            return FailResult("操作错误!");
        }
    }
}
