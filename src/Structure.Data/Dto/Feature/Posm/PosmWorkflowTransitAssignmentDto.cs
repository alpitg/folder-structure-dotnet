
namespace Structure.Data.Dto
{
     public  class PosmWorkflowTransitAssignmentDto
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransitionDto? posmWorkflowTransition { get; set; }

        public Guid? posmWorkflowTransitionId { get; set; }

        public UsersDto? user1 { get; set; }

        public Guid? user1Id { get; set; }

    }
}
