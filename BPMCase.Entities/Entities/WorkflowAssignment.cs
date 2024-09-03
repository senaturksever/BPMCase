using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Entities.Entities
{
    public class WorkflowAssignment
    {
        public Guid  Id { get; set; }

        public Guid WorkflowStepId { get; set; }

        public User User { get; set; }

        public virtual WorkflowStep WorkflowStep { get; set; } = new WorkflowStep();
        public AssignmentStatus Status { get; set; }
    }
}
