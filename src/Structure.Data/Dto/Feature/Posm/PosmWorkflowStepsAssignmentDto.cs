
namespace Structure.Data.Dto
{
    public  class PosmWorkflowStepsAssignmentDto
    {

        public Guid Id { get; set; }

        public PosmWorkflowStepsDetailsDto? PosmWorkflowSteps { get; set; }

        public User1? User1 { get; set; }

        public Guid? UserId { get; set; }

        public PosmStatusDto? posmStatus { get; set; }

        public Guid? posmStatusId { get; set; }

    }
}
