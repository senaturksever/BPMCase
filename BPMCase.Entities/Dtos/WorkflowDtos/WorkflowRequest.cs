namespace BPMCase.Entities.Dtos.WorkflowDtos
{
    public class WorkflowRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Guid> TeamMemberIds { get; set; }
    }
}
