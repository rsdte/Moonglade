using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moonglade.WebApi.Commons;
using Moonglade.WebApi.Extensions;
using System.Web;

namespace Moonglade.WebApi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var msg = context.Exception.GetOriginalException().Message;
            if (string.IsNullOrEmpty(msg))
            {
                msg = "抱歉，系统错误，请联系管理员！";
            }
            context.Result = new JsonResult(ApiResultHelper.CreateFailResult(msg));
            context.ExceptionHandled = true;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
