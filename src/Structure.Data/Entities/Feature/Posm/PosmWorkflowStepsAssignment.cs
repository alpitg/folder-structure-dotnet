

namespace Structure.Data
{
    public class PosmWorkflowStepsAssignment : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowStepsDetails? PosmWorkflowSteps { get; set; }

        public User? users{ get; set; }

        public Guid? UsersId { get; set; }

        public PosmStatus? posmStatus { get; set; } 
        
        public Guid? posmStatusId { get; set; }
    }
}
