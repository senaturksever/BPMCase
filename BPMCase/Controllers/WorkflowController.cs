using BPMCase.Entities.Dtos.WorkflowDtos;
using BPMCase.Services.WorkflowServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPMCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;
        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpPost("create-workflow")]
        public async Task<IActionResult> CreateWorkFlow([FromBody] WorkflowRequest request)
        {
            var workflow = await _workflowService.CreateWorkFlow(request);
            return Ok(workflow);
        }

        [HttpPost("add-Step")]
        public async Task<IActionResult> AddStepWorkflow([FromBody] WorkflowStepRequest request)
        {
            var workflow = await _workflowService.AddStep(request);
            return Ok(workflow);
        }

        [HttpGet("getAllWorkFlow")]
        public async Task<IActionResult> GetAllWorkFlow()
        {
            return Ok(await _workflowService.GetAllWorkFlow());
        }


        [HttpGet("getWorkFlow")]
        public async Task<IActionResult> GetWorkFlow(Guid id)
        {
            return Ok(await _workflowService.GetWorkflow(id));
        }
    }
}
