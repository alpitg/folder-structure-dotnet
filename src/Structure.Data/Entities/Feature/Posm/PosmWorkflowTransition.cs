

namespace Structure.Data
{
    public class PosmWorkflowTransition : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkFlow? posmWorkFlow { get; set; }  

        public Guid? posmWorkFlowId { get; set; }   

    }
}
