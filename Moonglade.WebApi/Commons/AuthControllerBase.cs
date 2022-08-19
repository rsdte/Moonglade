using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Moonglade.WebApi.Commons
{
    [Authorize]
    public abstract class AuthApiControllerBase : ApiControllerBase
    {
    }
}
