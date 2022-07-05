using API.Dtos;
using API.Helpers.Params;
using API.Models;

namespace API._Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> Login(UserForLoginParam param);
        Task<List<MenuDto>> GetMenu(ApplicationUser userlogin);
    }
}