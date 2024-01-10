

namespace Structure.Data.Dto
{
    public class PosmWorksflowStepsDto
    {

        public Guid Id { get; set; }    

        public int StepId { get; set; }

        public PosmWorkflowDto? PosmWorkflow { get; set; }

        public Guid? PosmWorkflowId { get; set; }   

    }
}
