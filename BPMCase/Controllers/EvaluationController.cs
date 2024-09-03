using BPMCase.Entities.Dtos.EvualtionDtos;
using BPMCase.Services.EvaluationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPMCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        // Yorum Ekleme Endpoint'i
        [HttpPost("add-comment")]
        public async Task<IActionResult> AddCommentToEvaluation([FromBody] CommentRequest request)
        {
            try
            {
                var result = await _evaluationService.AddCommentToEvaluationAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Değerlendirme Gönderme Endpoint'i
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitEvaluation([FromBody] EvulationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _evaluationService.SubmitEvaluationAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
