using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Service.PaymentDetails;

namespace SigortamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailService _paymentDetailService;

        public PaymentDetailController(IPaymentDetailService paymentDetailService)
        {
            _paymentDetailService = paymentDetailService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePaymentDetail([FromBody] PaymentDetail paymentDetail)
        {
            var res = await _paymentDetailService.Create(paymentDetail);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePaymentDetail(PaymentDetail paymentDetail)
        {
            var res = await _paymentDetailService.Update(paymentDetail);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetPaymentDetailById([FromQuery] int id)
        {
            var res = await _paymentDetailService.Get(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPaymentDetail()
        {
            var res = await _paymentDetailService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            var res = await _paymentDetailService.Delete(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpGet("GetAllByCompanyId")]
        public async Task<IActionResult> GetPaymentByCompanyId([FromQuery] int companyId)
        {
            var res = await _paymentDetailService.GetByCompanyId(companyId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
