using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Entities.Entities
{
    public class WorkflowItem
    {
        public Guid Id { get; set; }
        public ItemType ItemType { get; set; } 
        public string Content { get; set; } 
        public Guid WorkflowStepId { get; set; } 

        public virtual WorkflowStep WorkflowStep { get; set; } = new WorkflowStep();
    }
}
