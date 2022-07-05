using API._Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe(string email)
        {
            return Ok(await _subscribeService.Subscribe(email));
        }

        [HttpDelete("UnSubscribe")]
        public async Task<IActionResult> UnSubscribe(string email)
        {
            return Ok(await _subscribeService.UnSubscribe(email));
        }
    }
}