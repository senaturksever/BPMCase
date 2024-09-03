namespace BPMCase.Core.Infrastructure
{
    public class Enums
    {
        public enum StepType
        {
            Request,
            Approval,
            Evaluation,
            Result
        }

        public enum AssignmentStatus
        {
            Pending,
            Approved,
            Rejected
        }

        public enum ItemType
        {
            Evaluation, 
            Comment,   
            Document,   
            Approval, 
            Result
        }
    }
}
