

namespace Structure.Data
{
    public class PosmWorkflowTransitAssignment : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransition? posmWorkflowTransition { get; set; }

        public Guid? posmWorkflowTransitionId { get; set; }

       public User? Users { get; set; }

        public Guid? User1Id { get; set; }   
    }
}
