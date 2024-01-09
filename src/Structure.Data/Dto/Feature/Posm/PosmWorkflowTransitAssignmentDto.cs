
namespace Structure.Data.Dto
{
     public  class PosmWorkflowTransitAssignmentDto
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransitionDto? posmWorkflowTransition { get; set; }

        public Guid? posmWorkflowTransitionId { get; set; }

        public User? users { get; set; }

        public Guid? usersId { get; set; }

    }
}
