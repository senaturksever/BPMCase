namespace BPMCase.Entities.Dtos.EvualtionDtos
{
    public class CommentResponse
    {
        public Guid WorkFlowItemId { get; set; }  // Eklenen yorumun kimliği (WorkflowItem Id)
        public Guid WorkFlowId { get; set; }  // Yorumun eklendiği değerlendirme adımının kimliği
        public string Status { get; set; }  // Yorum ekleme işleminin durumu
        public DateTime CreatedDate { get; set; }
    }
}
