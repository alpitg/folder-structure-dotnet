

namespace Structure.Data.Dto
{
    public class PosmWorksflowStepsDto
    {

        public Guid Id { get; set; }    

        public int StepId { get; set; }

        public PosmWorkflowDto? posmWorkflow { get; set; }

        public Guid? posmWorkflowId { get; set; }   

    }
}
