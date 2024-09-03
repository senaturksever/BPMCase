namespace BPMCase.Entities.Entities
{
    public class WorkFlow
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<WorkflowStep> Steps { get; set; } = new List<WorkflowStep>();
        public virtual ICollection<WorkflowAssignment> Assignments { get; set; } = new List<WorkflowAssignment>();
    }
}