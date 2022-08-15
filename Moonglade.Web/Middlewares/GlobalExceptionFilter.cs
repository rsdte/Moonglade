using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moonglade.Web.Commons;
using Moonglade.Web.Extensions;
using System.Web;

namespace Moonglade.Web.Middlewares
{
    public class GlobalExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                var msg = context.Exception.GetOriginalException().Message;
                if (string.IsNullOrEmpty(msg))
                {
                    msg = "抱歉，系统错误，请联系管理员！";
                }
                context.Result = new JsonResult(ResultHelper.CreateFailResult(msg));
                context.ExceptionHandled = true;
            }
            else
            {
                string errorMessage = context.Exception.GetOriginalException().Message;
                // TODO: 修改异常错误显示视图。
                context.Result = new RedirectResult("~/Home/Error?message=" + HttpUtility.UrlEncode(errorMessage));
                context.ExceptionHandled = true;
            }
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
