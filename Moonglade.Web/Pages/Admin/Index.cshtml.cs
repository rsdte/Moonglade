using Microsoft.AspNetCore.Mvc;
using Moonglade.Application.Contracts;
using Moonglade.Application.Contracts.Dtos;
using Moonglade.Web.Commons;

namespace Moonglade.Web.Pages.Admin
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModelBase
    {
        private readonly IUserService userService;

        public IndexModel(IUserService userService)
        {
            this.userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSignInAsync([FromBody]LoginDto model)
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
