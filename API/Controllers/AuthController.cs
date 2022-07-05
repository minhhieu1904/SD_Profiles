using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API._Services.Interfaces;
using API.Helpers.Params;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(
            IConfiguration config, 
            IAuthService authService, 
            UserManager<ApplicationUser> userManager)
        {
            _config = config;
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginParam param)
        {
            var userlogin = await _authService.Login(param);
            if (userlogin == null)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userlogin.Id.ToString()),
                    new Claim(ClaimTypes.Name, userlogin.UserName)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiration = DateTime.UtcNow.AddDays(7);
                var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

                var result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user = userlogin,
                    menus = await _authService.GetMenu(userlogin)
                };

                return Ok(result);
            }
        }
    }
}