using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moonglade.Web.Commons;

namespace Moonglade.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class MainController : Commons.ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
