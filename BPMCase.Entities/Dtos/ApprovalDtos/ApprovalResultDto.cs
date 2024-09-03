using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Entities.Dtos.ApprovalDtos
{
    public class ApprovalResultDto
    {
        public Guid WorkflowStepId { get; set; }
        public AssignmentStatus Status { get; set; }
    }
}
