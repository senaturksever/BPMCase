using BPMCase.DataAccess.Context;
using BPMCase.Entities.Dtos.ApprovalDtos;
using BPMCase.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Services.ApprovalServices
{
    public class ApprovalService : IApprovalService
    {
        private readonly IPersistenceContext _persistenceContext;
        public ApprovalService(IPersistenceContext persistenceContext)
        {
               _persistenceContext = persistenceContext;
        }

        public async Task<ApprovalResultDto> EvaluateApproval(EvaluateApprovalRequest request)
        {
           var approval = _persistenceContext.Query<WorkflowAssignment>().Include(a=>a.WorkflowStep).FirstOrDefault(a=> a.Id == request.ApprovalId);

            if (approval == null)
                throw new Exception("Approval not found");
            approval.Status = request.IsApproved ? AssignmentStatus.Approved : AssignmentStatus.Rejected;
            _persistenceContext.Update(approval);
           await _persistenceContext.SaveChangesAsync();

            if(!request.IsApproved)
            {
                var childSteps  = _persistenceContext.Query<WorkflowStep>().Include(ws => ws.ChildSteps).Where(ws => ws.ParentId == approval.WorkflowStep.ParentId && ws.StepType == StepType.Evaluation).ToList();
            }

            return new ApprovalResultDto
            {
                WorkflowStepId = approval.WorkflowStep.Id,
                Status = request.IsApproved ? AssignmentStatus.Approved : AssignmentStatus.Rejected
            };
        }

        public async Task<ApprovalResultDto> SubmitApprovalAsync(ApprovalRequst requst, CancellationToken cancellationToken)
        {
            var workflowStep = _persistenceContext.Query<WorkflowStep>().Include(ws => ws.WorkFlow).FirstOrDefault(ws => ws.Id == requst.WorkflowStepId);

            if (workflowStep == null)
                throw new Exception("Workflow step not found");

            var user = _persistenceContext.Query<User>().FirstOrDefault(c => c.Id == requst.UserId); ;
            var approval = new WorkflowAssignment
            {
                Id = Guid.NewGuid(),
                WorkflowStepId = requst.WorkflowStepId,
                User = user,
                Status = AssignmentStatus.Pending
            };

            var assigment = _persistenceContext.Query<WorkflowAssignment>().Where(c => c.WorkflowStepId == workflowStep.Id).ToList();

            assigment.Add(approval);
            await _persistenceContext.SaveChangesAsync();

            return new ApprovalResultDto
            {
                WorkflowStepId = approval.WorkflowStepId,
                Status = AssignmentStatus.Approved
            };

        }
    }
}
