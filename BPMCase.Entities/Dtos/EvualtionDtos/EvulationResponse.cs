namespace BPMCase.Entities.Dtos.EvualtionDtos
{
    public class EvulationResponse
    {
        public Guid EvaluationId { get; set; }  // Başlatılan değerlendirme adımının kimliği
        public string Status { get; set; }  // Değerlendirme adımının durumu (örneğin, "Başlatıldı")
        public DateTime CreatedDate { get; set; }
    }
}
