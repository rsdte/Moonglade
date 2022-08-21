using Microsoft.AspNetCore.Mvc;
using Moonglade.Application.Contracts;
using Moonglade.Application.Contracts.Dtos;

namespace Moonglade.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AuthController : Moonglade.Web.Commons.ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return FailResult("数据校验错误。");
            }

            var token = await userService.GenerateTokenAsync(model);
            return SuccessResult(token);
        }
    }
}
