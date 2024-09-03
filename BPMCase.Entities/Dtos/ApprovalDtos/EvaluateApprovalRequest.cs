namespace BPMCase.Entities.Dtos.ApprovalDtos
{
    public class EvaluateApprovalRequest
    {
        public Guid ApprovalId { get; set; }
        public bool IsApproved { get; set; }
    }
}
