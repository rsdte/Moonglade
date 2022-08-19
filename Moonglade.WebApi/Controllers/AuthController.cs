
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moonglade.WebApi.Commons;

namespace Moonglade.WebApi.Controllers
{
    public class AuthController : AuthApiControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Test()
        {
            return Ok("hello");
        }

        [HttpPost]
        public IActionResult Sign([FromBody]LoginDto model)
        {

            return new JsonResult(new
            {
                Code = 200,
                Data = "lksjdpfwboerlkwejroiwebrlwkejr",
                Message = "success"
            });
        }
    }

    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
