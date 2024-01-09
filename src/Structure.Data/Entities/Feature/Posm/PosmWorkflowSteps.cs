
namespace Structure.Data
{
    public class PosmWorkflowSteps : BaseEntity
    {

        public Guid? Id { get; set; }

        public int? StepId { get; set; } 


        public PosmWorkFlow? posmWorkFlow { get; set; }  

        public Guid? posmWorkFlowId { get; set; }   

    }
}
