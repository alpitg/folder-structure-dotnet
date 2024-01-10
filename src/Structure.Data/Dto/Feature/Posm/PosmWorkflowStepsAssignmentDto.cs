
namespace Structure.Data.Dto
{
    public  class PosmWorkflowStepsAssignmentDto
    {

        public Guid Id { get; set; }

        public PosmWorkflowStepsDetailsDto? PosmWorkflowSteps { get; set; }

        public User? User{ get; set; }

        public Guid? UsersId { get; set; }

        public PosmStatusDto? PosmStatus { get; set; }

        public Guid? PosmStatusId { get; set; }

    }
}
