using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Statuses;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStatuses()
        {
            var res = await _statusService.GetAll();
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
        public async Task<IActionResult> GetStatusById([FromQuery] int id)
        {
            var res = await _statusService.Get(id);
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
        public async Task<IActionResult> CreateStatus([FromBody] Status status)
        {
            var res = await _statusService.Create(status);
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
        public async Task<IActionResult> UpdateStatus([FromBody] Status status)
        {
            var res = await _statusService.Update(status);
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
            var res = await _statusService.Delete(id);
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
