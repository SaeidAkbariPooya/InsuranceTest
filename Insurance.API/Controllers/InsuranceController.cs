using Insurance.Application.Dtos;
using Insurance.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpPost("requests")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateInsuranceRequestDto requestDto)
        {
            try
            {
                var result = await _insuranceService.CreateInsuranceRequestAsync(requestDto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "خطای داخلی سرور" });
            }
        }

        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests()
        {
            try
            {
                var requests = await _insuranceService.GetAllInsuranceRequestsAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "خطای داخلی سرور" });
            }
        }
    }
}
