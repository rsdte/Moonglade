using Microsoft.AspNetCore.Mvc;

namespace Moonglade.Web.Commons
{
    public class ControllerBase : Controller
    {
        public JsonResult FailResult(string msg, int code = 400)
        {
            return new JsonResult(new FailResult { Code = code, Message = msg });
        }

        public JsonResult SuccessResult<T>(T data, string msg = "")
        {

            return new JsonResult(new SuccessResult<T>
            {
                Code = 200,
                Message = msg,
                Data = data
            });
        }
    }
}
