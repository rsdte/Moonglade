using Microsoft.AspNetCore.Mvc;

namespace Moonglade.Web.Commons
{

    public abstract class ResultBase : ActionResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class FailResult : ResultBase, IActionResult { }

    public class SuccessResult<T> : ResultBase, IActionResult
    {
        public T Data { get; set; }
    }

    public class PageSuccessResult<T> : SuccessResult<T>
    {
        public int PageCount { get; set; }
        public int PageNum { get; set; }
    }

    public class ResultHelper
    {
        public static FailResult CreateFailResult(string msg, int code = 400)
        {
            return new FailResult { Code = code, Message = msg };
        }

        public static SuccessResult<T> CreateSuccessResult<T>(T data, string msg = "")
        {
            return new SuccessResult<T>
            {
                Code = 200,
                Message = msg,
                Data = data
            };
        }

    }

}
