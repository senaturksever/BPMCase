namespace BPMCase.Entities.Dtos.EvualtionDtos
{
    public class CommentRequest
    {
        public Guid WorkFlowId { get; set; }  // Yorumun ekleneceği değerlendirme adımı (WorkflowItem Id)
        public string Comment { get; set; }  // Kullanıcının yorumu
        public Guid UserId{get; set;}
    }
}
