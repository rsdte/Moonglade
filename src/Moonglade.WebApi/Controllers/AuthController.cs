
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moonglade.Application.Contracts;
using Moonglade.Application.Contracts.Dtos;
using Moonglade.WebApi.Commons;

namespace Moonglade.WebApi.Controllers
{
    public class AuthController : ApiAuthControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }



        [HttpGet]
        public IActionResult Test()
        {
            return Ok("hello");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody]LoginDto model)
        {
            var token = await userService.GenerateTokenAsync(model);
            return new JsonResult(new
            {
                Code = 200,
                Data = token,
                Message = "success"
            });
        }
    }
}
