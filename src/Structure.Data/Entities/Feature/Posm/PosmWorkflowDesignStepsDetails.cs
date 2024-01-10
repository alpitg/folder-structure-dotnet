

namespace Structure.Data
{
    public class PosmWorkflowDesignStepsDetails : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkFlow? PosmWorkFlow { get; set; }

        public Guid? PosmWorkflowId { get; set; }

        public int? PosmTypeId { get; set; }

        public int? Quantity { get; set; }

        public string? Description { get; set; }

        public string? PONumber { get; set; }

        public float? Cost { get; set; }

        public string? Comments { get; set; }


    }
}
