

namespace Structure.Data
{
    public class PosmWorkflowTransitAssignment : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransition? posmWorkflowTransition { get; set; }

        public Guid? posmWorkflowTransitionId { get; set; }

       public User? users { get; set; }

        public Guid? user1Id { get; set; }   
    }
}
