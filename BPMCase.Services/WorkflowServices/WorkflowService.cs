using BPMCase.DataAccess.Context;
using BPMCase.Entities.Dtos.WorkflowDtos;
using BPMCase.Entities.Entities;

namespace BPMCase.Services.WorkflowServices
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IPersistenceContext _context;
        public WorkflowService(IPersistenceContext persistenceContext)
        {
            _context = persistenceContext;
        }
        public async Task<WorkflowStep> AddStep(WorkflowStepRequest request)
        {
            var workflow = _context.Query<WorkFlow>().Where(c=> c.Id == request.WorkflowId).ToList();
            if (workflow == null)
                throw new ArgumentException("Workflow not found");

            var step = new WorkflowStep
            {
                Id = Guid.NewGuid(),
                StepName = request.StepName,
                StepType = request.StepType,
                Order = request.Order,
                WorkflowId = request.WorkflowId,
                ParentId = request.ParentId
            };

             _context.Add(step);
            await _context.SaveChangesAsync();

            return step;
        }

        public async Task<WorkFlow> CreateWorkFlow(WorkflowRequest request)
        {
            if (string.IsNullOrEmpty(request.Title))
                throw new ArgumentException("Title is required");

            var workFlow = new WorkFlow
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
               
                Assignments = request.TeamMemberIds.Select(memberId => new WorkflowAssignment
                {
                    Id = Guid.NewGuid(),
                    User = new User { Id = memberId } 
                }).ToList()
            };


            _context.Add(workFlow);
            return workFlow;
        }

        public async Task<List<WorkFlow>> GetAllWorkFlow()
        {
            return  _context.Query<WorkFlow>().ToList();

        }

        public async Task<WorkFlow> GetWorkflow(Guid id)
        {
            return  _context.Query<WorkFlow>().FirstOrDefault(c=>c.Id ==id);

        }
    }
}
