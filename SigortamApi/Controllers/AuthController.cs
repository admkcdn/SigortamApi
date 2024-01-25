using DTOs.Libs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Users;
using SigortamApi.Controllers.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilities.Results;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            this.configuration = configuration;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> LoginUser([FromQuery] string email, string password)
        {
            var pssw = HashPassword(password);
            var res = await _userService.Login(email, pssw);
            if (res.Success)
            {
                SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));

                var dateTimeNow = DateTime.UtcNow;

                var userRole = await _userService.GetUserRole(res.Data.ID);

                JwtSecurityToken jwt = new JwtSecurityToken(
                        issuer: configuration["AppSettings:ValidIssuer"],
                        audience: configuration["AppSettings:ValidAudience"],
                        claims: new List<Claim> {
                    new Claim("ID", res.Data.ID.ToString()),
                    new Claim("RoleID", userRole.ToString()),
                        },
                        notBefore: dateTimeNow,
                        expires: dateTimeNow.Add(TimeSpan.FromDays(7)),
                        signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new SuccessDataResult<TokenResponse>(new TokenResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                    TokenExpireDate = dateTimeNow.Add(TimeSpan.FromDays(7))
                }));
            }
            return BadRequest(res);
        }
    }
}
