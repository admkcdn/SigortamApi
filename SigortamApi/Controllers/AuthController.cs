using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Users;
using SigortamApi.Controllers.Base;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> LoginUser([FromQuery] string email, string password)
        {
            var pssw = HashPassword(password);
            var res = await _userService.Login(email, pssw);
            return Ok(res);
        }
    }
}
