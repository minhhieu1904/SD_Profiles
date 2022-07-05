using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class AboutController : ApiController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AboutDto dataDto)
        {
            dataDto.Create_By = userName;
            return Ok(await _aboutService.Create(dataDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AboutDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _aboutService.Update(dataDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(AboutDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _aboutService.Delete(dataDto));
        }

        [HttpPut("SetDefault")]
        public async Task<IActionResult> SetDefault(AboutDto dataDto)
        {
            dataDto.Update_By = userName;
            return Ok(await _aboutService.SetDefault(dataDto));
        }

        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string text)
        {
            return Ok(await _aboutService.GetDataPagination(pagination, text));
        }
    }
}