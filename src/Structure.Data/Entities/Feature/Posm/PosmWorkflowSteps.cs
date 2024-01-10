
namespace Structure.Data
{
    public class PosmWorkflowSteps : BaseEntity
    {

        public Guid? Id { get; set; }

        public int? StepId { get; set; } 


        public PosmWorkFlow? PosmWorkFlow { get; set; }  

        public Guid? PosmWorkFlowId { get; set; }   

    }
}
