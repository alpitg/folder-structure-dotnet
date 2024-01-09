
namespace Structure.Data.Dto
{
    public  class PosmWorkflowStepsAssignmentDto
    {

        public Guid Id { get; set; }

        public PosmWorkflowStepsDetailsDto? PosmWorkflowSteps { get; set; }

        public User? user{ get; set; }

        public Guid? UsersId { get; set; }

        public PosmStatusDto? posmStatus { get; set; }

        public Guid? posmStatusId { get; set; }

    }
}
