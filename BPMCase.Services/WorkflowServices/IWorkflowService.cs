using BPMCase.Entities.Dtos.WorkflowDtos;
using BPMCase.Entities.Entities;

namespace BPMCase.Services.WorkflowServices
{
    public interface IWorkflowService
    {
        Task<WorkFlow> CreateWorkFlow(WorkflowRequest request);
        Task<WorkflowStep> AddStep(WorkflowStepRequest request);

        Task<List<WorkFlow>> GetAllWorkFlow();

        Task<WorkFlow> GetWorkflow(Guid id);

    } 
}
