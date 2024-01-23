using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.File;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTypeController : ControllerBase
    {
        private readonly IFileTypeService _fileTypeService;

        public FileTypeController(IFileTypeService fileTypeService)
        {
            _fileTypeService = fileTypeService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFileTypes()
        {
            var res = await _fileTypeService.GetAll();
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
        public async Task<IActionResult> GetFileTypeById([FromQuery] int id)
        {
            var res = await _fileTypeService.Get(id);
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
        public async Task<IActionResult> CreateFileType([FromBody] FileType file)
        {
            var res = await _fileTypeService.Create(file);
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
        public async Task<IActionResult> UpdateFileType([FromBody] FileType file)
        {
            var res = await _fileTypeService.Update(file);
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
        public async Task<IActionResult> DeleteFileType(int id)
        {
            var res = await _fileTypeService.Delete(id);
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
