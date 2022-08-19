
using Microsoft.AspNetCore.Mvc;

namespace Moonglade.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
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
