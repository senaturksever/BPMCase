using BPMCase.Entities.Dtos.ApprovalDtos;
using BPMCase.Entities.Entities;

namespace BPMCase.Services.ApprovalServices
{
    public interface IApprovalService
    {
        Task<ApprovalResultDto> SubmitApprovalAsync(ApprovalRequst requst, CancellationToken cancellationToken);
        Task<ApprovalResultDto> EvaluateApproval(EvaluateApprovalRequest request);

    }
}
