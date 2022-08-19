using Microsoft.AspNetCore.Authorization;

namespace Moonglade.WebApi.Commons
{
    [Authorize(Policy = "Permission")]
    public abstract class ApiAuthControllerBase : ApiControllerBase
    {
    }
}
