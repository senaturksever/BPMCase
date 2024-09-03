using BPMCase.DataAccess.Context;
using BPMCase.Entities.Dtos.EvualtionDtos;
using BPMCase.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Services.EvaluationServices
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IPersistenceContext _persistenceContext;
        public EvaluationService(IPersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task<CommentResponse> AddCommentToEvaluationAsync(CommentRequest request)
        {
            var comment = new WorkflowItem
            {
                Id = Guid.NewGuid(),
                WorkflowStepId = request.WorkFlowId,
                ItemType = ItemType.Comment,
                Content = request.Comment
            };

            var items = _persistenceContext.Query<WorkflowItem>().Where(c => c.WorkflowStep.WorkflowId == request.WorkFlowId);

            _persistenceContext.Add(comment);
            await _persistenceContext.SaveChangesAsync();
            return new CommentResponse
            {
                WorkFlowItemId = comment.Id,
                WorkFlowId = request.WorkFlowId,
                Status = "Başarılı",
                CreatedDate = DateTime.UtcNow
            };
        }

        public async Task<EvulationResponse> SubmitEvaluationAsync(EvulationRequest request)
        {
            var evulation = _persistenceContext.Query<WorkflowItem>().Where(c=>c.WorkflowStepId == request.WorkflowStepId).ToList();

            if(evulation !=null )
            {
                throw new Exception("Evulation found");

            }

            var evaluation = new WorkflowItem
            {
                Id = Guid.NewGuid(),
                WorkflowStepId = request.WorkflowStepId,
                ItemType = ItemType.Evaluation,
                Content = request.Content,
            };
            _persistenceContext.Add(evaluation);
            await _persistenceContext.SaveChangesAsync();

            var assignments = request.AssignedUserIds
                         .Select(async userId => new WorkflowAssignment
                         {
                             Id = Guid.NewGuid(),
                             WorkflowStepId = request.WorkflowStepId,
                             User = _persistenceContext.Query<User>().FirstOrDefault(c => c.Id ==userId),
                             Status = AssignmentStatus.Pending
                         }).ToList();

            _persistenceContext.AddRange(assignments);
            await _persistenceContext.SaveChangesAsync();


            return new EvulationResponse
            {
                EvaluationId = evaluation.Id,
                Status = "Başlatıldı",
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}
