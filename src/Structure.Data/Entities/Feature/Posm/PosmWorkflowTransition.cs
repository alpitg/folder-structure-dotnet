

namespace Structure.Data
{
    public class PosmWorkflowTransition : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkFlow? PosmWorkFlow { get; set; }  

        public Guid? PosmWorkFlowId { get; set; }   

    }
}
