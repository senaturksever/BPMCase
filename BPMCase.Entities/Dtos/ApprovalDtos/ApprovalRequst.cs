using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCase.Entities.Dtos.ApprovalDtos
{
    public class ApprovalRequst
    {
        public Guid WorkflowStepId { get; set; }  
        public bool IsApproved { get; set; } 
        public string Comments { get; set; }  
        public DateTime ApprovalDate { get; set; } 
        public Guid UserId { get; set; }  
        public string UserName { get; set; }
    }
}
