using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Entities.Dtos.WorkflowDtos
{
    public class WorkflowStepRequest
    {
        public Guid WorkflowId { get; set; }
        public string StepName { get; set; }
        public StepType StepType { get; set; }
        public int Order { get; set; }
        public Guid? ParentId { get; set; }
    }
}
