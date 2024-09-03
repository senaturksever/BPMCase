using BPMCase.Entities.Dtos.EvualtionDtos;

namespace BPMCase.Services.EvaluationServices
{
    public interface IEvaluationService
    {
        Task<EvulationResponse> SubmitEvaluationAsync(EvulationRequest request);
        Task<CommentResponse> AddCommentToEvaluationAsync(CommentRequest request);
    }
}
