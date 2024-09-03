using BPMCase.Services.ResultServices;
using Microsoft.AspNetCore.Mvc;

namespace BPMCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }


        [HttpGet("{workflowId}")]
        public async Task<IActionResult> GetResultPage(Guid workflowId)
        {
            try
            {
                var resultPage = await _resultService.GetResultPageAsync(workflowId);
                return Ok(resultPage);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
