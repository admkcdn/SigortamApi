using Data.Model;
using DTOs.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Users;
using SigortamApi.Controllers.Base;
using System.Security.Cryptography;
using System.Text;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var res = await _userService.Get(id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            user.Photo = await SavePhoto(user.PhotoFile);
            user.Password = HashPassword(user.Password);
            var res = await _userService.Create(user);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await _userService.Delete(id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var res = await _userService.Update(user);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _userService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpGet("GetUserRole")]
        public async Task<IActionResult> GetUsersRole([FromQuery] int id)
        {
            var res = await _userService.GetUserRole(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        private async Task<string> SavePhoto(IFormFile file)
        {
            try
            {
                string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "photos");
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                string filePathLink = Path.Combine("photos", file.FileName);
                return filePathLink;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
