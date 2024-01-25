using DAL;
using DTOs.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.File;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFile()
        {
            var res = await _fileService.GetAllFiles();
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
        public async Task<IActionResult> GetFileById([FromQuery] int id)
        {
            var res = await _fileService.GetFile(id);
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
        public async Task<IActionResult> CreateFile([FromForm] FileDto file)
        {
            try
            {
                file.FilePath = await SaveFile(file.File);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var res = await _fileService.CreateFile(file);
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
        public async Task<IActionResult> UpdateFile([FromForm] Data.Model.File file)
        {
            var res = await _fileService.UpdateFile(file);
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
        public async Task<IActionResult> DeleteFile(int id)
        {
            var res = await _fileService.DeleteFile(id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                string filePath = Path.Combine("files", file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return filePath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
