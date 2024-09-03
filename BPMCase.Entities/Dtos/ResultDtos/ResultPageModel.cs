using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Entities.Dtos.ResultDtos
{
    public class ResultPageModel
    {
        public Guid WorkflowId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<StepDto> Steps { get; set; }
        public List<AssignmentDto> Assignments { get; set; }
    }

    public class StepDto
    {
        public Guid StepId { get; set; }
        public string StepName { get; set; }
        public StepType StepType { get; set; }
        public string Status { get; set; } // Completed, Pending, etc.
        public List<ItemDto> Items { get; set; }
  
    }

    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public string Content { get; set; }
    }

    public class AssignmentDto
    {
        public Guid AssignmentId { get; set; }
        public string UserName { get; set; }
        public AssignmentStatus Status { get; set; }
    }
}
