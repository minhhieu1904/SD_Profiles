using API._Repositories;
using API._Services.Interfaces;
using API.Dtos;
using API.Helpers.Constants;
using API.Helpers.Utilities;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SD3_API.Helpers.Utilities;

namespace API._Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryAccessor _repository;
        private readonly MapperConfiguration _configMapper;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IRepositoryAccessor repository,
            MapperConfiguration configMapper,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _repository = repository;
            _configMapper = configMapper;
            _roleManager = roleManager;
        }

        public async Task<bool> ChangePassword(UserDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            var result = await _userManager.ChangePasswordAsync(user, userDto.Password, userDto.NewPassword);
            return result.Succeeded;
        }

        public async Task<OperationResult> Create(UserDto userDto)
        {
            if (await _userManager.FindByNameAsync(userDto.UserName) != null)
                return new OperationResult { IsSuccess = false, Error = "Username was exists !", Data = "Exists" };
            
            userDto.Password = "sd@1234";

            var user = new ApplicationUser
            {
                Id = new Guid(),
                Name = userDto.Name,
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                IsDelete = false,
                IsEnabled = true
            };
            
            if (!string.IsNullOrEmpty(userDto.Avatar))
            {
                user.Avatar = await new UploadUtility().UploadAsync(userDto.Avatar, "uploaded\\images\\users\\", $"{userDto.UserName}_{Guid.NewGuid().ToString()}");
            }
            else
            {
                user.Avatar = CommonConstants.USER_AVATAR_DEFAULT;
            }

            var result = await _userManager.CreateAsync(user, userDto.Password);
            await AddRoles(user, userDto.Roles.Where(x => x.isActive).ToList());
            if (result.Succeeded)
                return new OperationResult { IsSuccess = result.Succeeded };
            else
                return new OperationResult { IsSuccess = result.Succeeded, Error = result.Errors.ToString() };
        }

        public async Task<bool> Delete(UserDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            user.IsDelete = true;
            user.IsEnabled = false;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<List<KeyValuePair<string, string>>> GetListUser()
        {
            var data = _userManager.Users.Where(x => !x.IsDelete)
                .Select(x => new KeyValuePair<string, string>(
                    x.UserName,
                    x.Name
                )).ToList();
            return await Task.FromResult(data);
        }

        public async Task<UserDto> GetUserDetail(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var litsRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles
                .Select(x => new RoleDto
                {
                    id = x.Id.ToString(),
                    name = x.Name.Trim(),
                    isActive = litsRoles == null ? false : litsRoles.Contains(x.Name) ? true : false
                }).ToListAsync();

            var detail = new UserDto
            {
                Avatar = user.Avatar,
                Email = user.Email,
                IsDelete = user.IsDelete,
                IsEnabled = user.IsEnabled,
                Name = user.Name,
                UserId = user.Id,
                UserName = userName,
                PhoneNumber = user.PhoneNumber,
                Roles = roles
            };
            return detail;
        }

        public async Task<PaginationUtility<UserDto>> GetUserPagination(PaginationParam pagination, string userName, bool isPaging = true)
        {
            var pred = PredicateBuilder.New<ApplicationUser>(x => !x.IsDelete);
            if (!string.IsNullOrWhiteSpace(userName) && userName != "All")
            {
                pred.And(x => x.UserName == userName);
            }
            var data = _userManager.Users.Where(pred).OrderBy(x => x.UserName).ProjectTo<UserDto>(_configMapper);
            return await PaginationUtility<UserDto>.CreateAsync(data, pagination.PageNumber, pagination.PageSize, isPaging);
        }

        public async Task<bool> Update(UserDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            user.PhoneNumber = userDto.PhoneNumber;
            user.Email = userDto.Email;
            user.Name = userDto.Name;

            if (!string.IsNullOrEmpty(userDto.Avatar))
            {
                if (user.Avatar != CommonConstants.USER_AVATAR_DEFAULT)
                {
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploaded\\images\\users\\");
                    var filePath = Path.Combine(folderPath, user.Avatar);

                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                user.Avatar = await new UploadUtility().UploadAsync(userDto.Avatar, "uploaded\\images\\users\\", $"{userDto.UserName}_{Guid.NewGuid().ToString()}");
            }

            await AddRoles(user, userDto.Roles.Where(x => x.isActive).ToList());

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        private async Task AddRoles(ApplicationUser user, List<RoleDto> roles)
        {
            var rolesUser = await _userManager.GetRolesAsync(user);
            if (rolesUser.Any())
                await _userManager.RemoveFromRolesAsync(user, rolesUser);

            foreach (var role in roles)
            {
                if (!await _userManager.IsInRoleAsync(user, role.name))
                {
                    await _userManager.AddToRoleAsync(user, role.name);
                }
            }
        }
    }
}