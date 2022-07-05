using API._Services.Interfaces;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PermissionSettingController : ApiController
    {
        private readonly IPermissionSettingService _permissionSettingService;

        public PermissionSettingController(IPermissionSettingService permissionSettingService)
        {
            _permissionSettingService = permissionSettingService;
        }

        [HttpPost("CreateNewRoles")]
        public async Task<IActionResult> CreateNewRoles(string roleName)
        {
            return Ok(await _permissionSettingService.CreateNewRoles(roleName));
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles() {
            var data = await _permissionSettingService.GetRoles();
            return Ok(data);
        }

        [HttpPut("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleName) {
            await _permissionSettingService.DeleteRole(roleName);
            return Ok();
        }
    }
}