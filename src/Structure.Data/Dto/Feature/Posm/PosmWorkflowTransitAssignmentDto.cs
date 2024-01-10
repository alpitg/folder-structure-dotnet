
namespace Structure.Data.Dto
{
     public  class PosmWorkflowTransitAssignmentDto
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransitionDto? PosmWorkflowTransition { get; set; }

        public Guid? PosmWorkflowTransitionId { get; set; }

        public User? Users { get; set; }

        public Guid? UsersId { get; set; }

    }
}
