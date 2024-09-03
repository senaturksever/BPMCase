using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BPMCase.Core.Infrastructure.Enums;

namespace BPMCase.Entities.Entities
{
    public class WorkflowStep
    {
        public Guid Id { get; set; }
        public string StepName { get; set; }
        public StepType StepType { get; set; }
        public int Order { get; set; }

        public Guid WorkflowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
        public virtual ICollection<WorkflowStep> ChildSteps { get; set; } = new List<WorkflowStep>(); //Alt adım

        public Guid? ParentId { get; set; }
        public virtual WorkflowStep ParentStep { get; set; } //Üst Adım
        public virtual ICollection<WorkflowItem> Items { get; set; }

        public WorkflowStep()
        {
           Items = new List<WorkflowItem>();
        }

    }
}
