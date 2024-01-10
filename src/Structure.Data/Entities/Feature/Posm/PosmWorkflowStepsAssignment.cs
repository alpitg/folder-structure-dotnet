

namespace Structure.Data
{
    public class PosmWorkflowStepsAssignment : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowStepsDetails? PosmWorkflowSteps { get; set; }

        public User? Users{ get; set; }

        public Guid? UsersId { get; set; }

        public PosmStatus? PosmStatus { get; set; } 
        
        public Guid? PosmStatusId { get; set; }
    }
}
