using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IPermissionSettingService
    {
        Task<List<RoleDto>> GetRoles();
        Task<OperationResult> CreateNewRoles(string roleName);
        Task DeleteRole(string roleName);
    }
}