using BPMCase.DataAccess.Context;
using BPMCase.Entities.Dtos.ResultDtos;
using BPMCase.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Services.ResultServices
{
    public class ResultService : IResultService
    {
        private readonly IPersistenceContext _persistenceContext;

        public ResultService(IPersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }
        public Task<ResultPageModel> GetResultPageAsync(Guid workflowId) { 

          var resultPageDto =  _persistenceContext.Query<WorkFlow>()
            .Where(w => w.Id == workflowId)
            .Select(workflow => new ResultPageModel
            {
                WorkflowId = workflow.Id,
                Title = workflow.Title,
                Description = workflow.Description,
                StartDate = workflow.StartDate,
                EndDate = workflow.EndDate,
                Steps = workflow.Steps.Select(step => new StepDto
                {
                    StepId = step.Id,
                    StepName = step.StepName,
                    StepType = step.StepType,
                    Status = step.Items.Any(i => i.ItemType == ItemType.Evaluation) ? "Pending" : "Completed",
                    Items = step.Items.Select(item => new ItemDto
                    {
                        ItemId = item.Id,
                        ItemType = item.ItemType,
                        Content = item.Content
                    }).ToList(),
                }).ToList(),
                Assignments = workflow.Assignments.Select(assignment => new AssignmentDto
                {
                    AssignmentId = assignment.Id,
                    UserName = assignment.User.Name,
                    Status = assignment.Status
                }).ToList()
            })
            .FirstOrDefaultAsync();

            if (resultPageDto == null)
                throw new Exception("Workflow not found");

            return resultPageDto;

        }
}
}
