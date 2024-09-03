using BPMCase.Entities.Dtos.ApprovalDtos;
using BPMCase.Services.ApprovalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPMCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalService _approvalService;
        public ApprovalController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

        // Onayı Değerlendirme Endpoint'i
        [HttpPost("evaluate")]
        public async Task<IActionResult> EvaluateApproval([FromBody] EvaluateApprovalRequest request)
        {
            try
            {
                var result = await _approvalService.EvaluateApproval(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Onay Gönderme Endpoint'i
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitApproval([FromBody] ApprovalRequst request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _approvalService.SubmitApprovalAsync(request, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
