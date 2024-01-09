

namespace Structure.Data
{
    public class PosmWorkflowStepsAssignment : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowStepsDetails? PosmWorkflowSteps { get; set; }

        public User1? User1 { get; set; }

        public Guid? UserId { get; set; }

        public PosmStatus? posmStatus { get; set; } 
        
        public Guid? posmStatusId { get; set; }
    }
}
