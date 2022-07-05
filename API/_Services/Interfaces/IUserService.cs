using API.Dtos;
using SD3_API.Helpers.Utilities;

namespace API._Services.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult> Create(UserDto userDto);
        Task<bool> Update(UserDto userDto);
        Task<bool> Delete(UserDto userDto);
        Task<bool> ChangePassword(UserDto userDto);
        Task<PaginationUtility<UserDto>> GetUserPagination(PaginationParam pagination, string userName, bool isPaging = true);
        Task<List<KeyValuePair<string, string>>> GetListUser();
        Task<UserDto> GetUserDetail(string userName);
    }
}