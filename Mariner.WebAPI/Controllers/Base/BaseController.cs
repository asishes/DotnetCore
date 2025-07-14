using Microsoft.AspNetCore.Mvc;

namespace Mariner.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
