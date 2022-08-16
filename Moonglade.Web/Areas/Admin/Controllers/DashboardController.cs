using Microsoft.AspNetCore.Mvc;

namespace Moonglade.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Moonglade.Web.Commons.ControllerBase
    {
        public IActionResult Index() => View();


    }
}
