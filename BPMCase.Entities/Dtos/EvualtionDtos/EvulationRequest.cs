namespace BPMCase.Entities.Dtos.EvualtionDtos
{
    public class EvulationRequest
    {
        public Guid WorkflowStepId { get; set; }  // Değerlendirme yapılacak iş akış adımı
        public string Content { get; set; }  // Değerlendirme içeriği (yorumlar, görüşler, vs.)
        public List<Guid> AssignedUserIds { get; set; }
    }
}
