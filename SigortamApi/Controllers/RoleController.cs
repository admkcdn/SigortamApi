using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Roles;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRoles()
        {
            var res = await _roleService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetRoleById([FromQuery] int id)
        {
            var res = await _roleService.Get(id);
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
        public async Task<IActionResult> CreateRole([FromBody] Role role)
        {
            var res = await _roleService.Create(role);
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
        public async Task<IActionResult> UpdateStatus([FromBody] Role role)
        {
            var res = await _roleService.Update(role);
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
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var res = await _roleService.Delete(id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
