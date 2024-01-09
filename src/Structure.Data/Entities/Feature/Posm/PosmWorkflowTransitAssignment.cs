

namespace Structure.Data
{
    public class PosmWorkflowTransitAssignment : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransition? posmWorkflowTransition { get; set; }

        public Guid? posmWorkflowTransitionId { get; set; }

       public User1? user1 { get; set; }

        public Guid? user1Id { get; set; }   
    }
}
