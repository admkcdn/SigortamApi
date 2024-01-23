using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Companies;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            var res = await _companyService.Create(company);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetCompanyById([FromQuery] int id)
        {
            var res = await _companyService.Get(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var res = await _companyService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            var res = await _companyService.Update(company);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var res = await _companyService.Delete(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
