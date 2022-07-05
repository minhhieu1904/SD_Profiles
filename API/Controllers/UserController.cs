using API._Services.Interfaces;
using API.Dtos;
using API.Helpers.Params;
using Microsoft.AspNetCore.Mvc;
using SD3_API.Helpers.Utilities;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            return Ok(await _userService.Create(userDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            return Ok(await _userService.Update(userDto));
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(UserDto userDto)
        {
            return Ok(await _userService.Delete(userDto));
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserDto userDto)
        {
            return Ok(await _userService.ChangePassword(userDto));
        }

        [HttpGet("GetListUser")]
        public async Task<IActionResult> GetListUser()
        {
            return Ok(await _userService.GetListUser());
        }

        [HttpGet("GetUserPagination")]
        public async Task<IActionResult> GetUserPagination([FromQuery] PaginationParam pagination, string userName)
        {
            return Ok(await _userService.GetUserPagination(pagination, userName));
        }

        [HttpGet("GetUserDetail")]
        public async Task<IActionResult> GetUserDetail(string userName)
        {
            return Ok(await _userService.GetUserDetail(userName));
        }
    }
}