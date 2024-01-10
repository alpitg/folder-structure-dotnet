

namespace Structure.Data
{
    public class PosmWorkflowManufacturingDetails : BaseEntity
    { 

        public Guid? Id { get; set; }   

        public PosmWorkFlow? PosmWorkFlow { get; set; }  

        public Guid? PosmWorkFlowId { get; set; }

        public string? ManufacturingCompany { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set;}

        public string? Comments { get; set; }

    }
}
