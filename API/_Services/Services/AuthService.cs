using API._Repositories;
using API._Services.Interfaces;
using API.Dtos;
using API.Helpers.Params;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API._Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRepositoryAccessor _repository;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IRepositoryAccessor repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _repository = repository;
        }

        public async Task<List<MenuDto>> GetMenu(ApplicationUser userlogin)
        {
            var useRoles = await _userManager.GetRolesAsync(userlogin);
            var menus = _roleManager.Roles.Where(x => useRoles.Contains(x.Name)).AsNoTracking()
                .Join(_repository.Menu.FindAll().AsNoTracking(),
                    x => x.Id,
                    y => y.Role_Id,
                    (x, y) => new MenuDto {
                        Active = y.Active,
                        BadgeType = y.BadgeType,
                        BadgeValue = y.BadgeValue,
                        Bookmark = y.Bookmark,
                        Icon = y.Icon,
                        Path = y.Path,
                        Role_Name = x.Name,
                        Sequent = y.Sequent,
                        Title = y.Title,
                        Type = y.Type,
                        Id = y.Id,
                        Parent_Id = y.Parent_Id,
                        Role_Id = x.Id
                    }
                ).ToList();
            return await Task.FromResult(menus.OrderBy(x => x.Sequent).ToList());
        }

        public async Task<ApplicationUser> Login(UserForLoginParam param)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(param.UserName, param.PassWord, false, false);
            return signInResult.Succeeded ? await _userManager.FindByNameAsync(param.UserName) : null;
        }
    }
}