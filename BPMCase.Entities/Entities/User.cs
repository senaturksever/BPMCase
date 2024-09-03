namespace BPMCase.Entities.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<WorkflowAssignment> Assignments { get; set; } = new List<WorkflowAssignment>(); // Kullanıcıya atanmış görevler

    }
}
