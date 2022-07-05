using API._Services.Interfaces;
using API.Dtos;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SD3_API.Helpers.Utilities;

namespace API._Services.Services
{
    public class PermissionSettingService : IPermissionSettingService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MapperConfiguration _configMapper;

        public PermissionSettingService(
            RoleManager<ApplicationRole> roleManager, 
            MapperConfiguration configMapper)
        {
            _roleManager = roleManager;
            _configMapper = configMapper;
        }

        public async Task<OperationResult> CreateNewRoles(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var applicationRole = new ApplicationRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                };
                await _roleManager.CreateAsync(applicationRole);
                return new OperationResult(true);
            }
            else
            {
                if (role.IsDelete)
                {
                    role.IsDelete = false;
                    await _roleManager.UpdateAsync(role);
                    return new OperationResult(true);
                }
                else
                {
                    return new OperationResult(false, "Role_Exists");
                }
            }
        }

        public async Task DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            role.IsDelete = true;
            await _roleManager.UpdateAsync(role);
        }

        public async Task<List<RoleDto>> GetRoles()
        {
            var roles = await _roleManager.Roles.Where(x => !x.IsDelete).ProjectTo<RoleDto>(_configMapper).ToListAsync();
            return roles;
        }
    }
}