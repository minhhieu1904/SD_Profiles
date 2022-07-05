using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class ApiController : ControllerBase
    {
        protected string userName => (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name).Value;
    }
}